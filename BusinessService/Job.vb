Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports SystemFramework

Namespace BusinessService
    Public Class Job
        Private tableName As String

        Private pkColumn As String

        Private warningMessage As String

        Public Sub New()
            MyBase.New()
            Me.tableName = "Job"
            Me.pkColumn = "Job_ID"
        End Sub

        Public Function createJob(ByRef tran As TransactionContext, ByVal sub_id As Integer, ByVal site_id As Integer, ByVal bidHeader_ID As Integer, ByVal priorSchedule As Integer, ByVal job_description As String, ByVal notes As String, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal pay_basis As Decimal, ByVal bill_amount As Decimal, ByVal sub_pay As Decimal, ByVal schedule_amount As Decimal, ByVal status As String, ByVal cancel_reason As String, ByVal create_user As String, ByVal modified_user As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim jobDT As DataTranslation.JobDT = New DataTranslation.JobDT()
            If (Not Me.validateOccBillClient(site_id)) Then
                messageHelper.messageText = "Site has no Occ or Bill Client"
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.status = False
                Return messageHelper
            End If
            messageHelper.status = True
            If (sub_id <> 0) Then
                If (Me.validateDupSiteDay(site_id, start_date)) Then
                    messageHelper.status = True
                Else
                    messageHelper.messageText = "Duplicate Job for Site/Day"
                    Me.warningMessage = messageHelper.messageText
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.status = True
                End If
            End If
            If (sub_id <> 0 AndAlso Not Me.validateOverBooking(False, sub_id, start_date)) Then
                messageHelper.messageText = "Duplicate Time"
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.status = False
                Return messageHelper
            End If
            messageHelper = Me.validateSchedAmt(sub_id, schedule_amount)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (Not Me.validateOrphanPresence(site_id)) Then
                messageHelper.messageText = "Site Already Has Job In An Unscheduled Status"
                messageHelper.messageId = StringType.FromInteger(2)
                messageHelper.status = False
                Return messageHelper
            End If
            If (bidHeader_ID > 0) Then
                messageHelper = UCCEstimate.cloneEstimate(tran, bidHeader_ID, create_user, modified_user)
                If (messageHelper.status) Then
                    bidHeader_ID = IntegerType.FromObject(messageHelper.messageObject)
                    Dim bidHeaderById As SqlDataReader = UCCEstimate.getBidHeaderById(tran, bidHeader_ID)
                    bidHeaderById.Read()
                    Dim num As Decimal = DecimalType.FromObject(bidHeaderById.Item("Bid_Total"))
                    Dim num1 As Decimal = DecimalType.FromObject(bidHeaderById.Item("Override_Amt"))
                    bidHeaderById.Close()
                    If (Decimal.Compare(num1, Decimal.Zero) > 0) Then
                        num = num1
                    End If
                    pay_basis = num
                    schedule_amount = num
                    bill_amount = num
                Else
                    messageHelper.status = True
                End If
            End If
            Dim num2 As Integer = jobDT.isrtJob(tran, sub_id, site_id, bidHeader_ID, priorSchedule, job_description, notes, start_date, end_date, pay_basis, bill_amount, sub_pay, schedule_amount, status, cancel_reason, create_user, modified_user)
            If (num2 <= 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Job Insert Failed"
                messageHelper.status = False
            Else
                messageHelper.status = True
                messageHelper.messageObject = num2
            End If
            If (StringType.StrCmp(Me.warningMessage, "", False) <> 0) Then
                messageHelper.messageText = Me.warningMessage
                Me.warningMessage = ""
            End If
            Return messageHelper
        End Function

        Public Shared Function getJobByAlternatePhone(ByVal alternatePhone As String) As SqlDataReader
            Return JobDT.getJobByAlternatePhone(alternatePhone)
        End Function

        Public Shared Function getJobByClientID(ByVal client_ID As Integer) As SqlDataReader
            Return JobDT.getJobByClientID(client_ID)
        End Function

        Public Function getJobById(ByVal job_ID As Integer) As SqlDataReader
            Dim jobDT As DataTranslation.JobDT = New DataTranslation.JobDT()
            Return DataTranslation.JobDT.getJobById(job_ID)
        End Function

        Public Shared Function getJobByLastName(ByVal lastName As String) As SqlDataReader
            Return JobDT.getJobByLastName(lastName)
        End Function

        Public Shared Function getJobByPrimaryPhone(ByVal primaryPhone As String) As SqlDataReader
            Return JobDT.getJobByPrimaryPhone(primaryPhone)
        End Function

        Public Function getJobBySub(ByVal sub_ID As Integer, ByVal begin_date As DateTime, ByVal end_date As DateTime) As SqlDataReader
            Return (New JobDT()).getJobBySub(sub_ID, begin_date, end_date)
        End Function

        Public Function getJobBySubByDateRange(ByVal begin_date As DateTime, ByVal end_date As DateTime) As SqlDataReader
            Return (New JobDT()).getJobBySubByDateRange(begin_date, end_date)
        End Function

        Public Function getJobOrphans(ByVal priorSchedule As Integer) As DataSet
            Return (New JobDT()).getJobOrphans(priorSchedule)
        End Function

        Public Function updateJobAll(ByRef tran As TransactionContext, ByVal job_id As Integer, ByVal sub_id As Integer, ByVal bidHeader_ID As Integer, ByVal reminder As Integer, ByVal critical As Integer, ByVal priorSchedule As Integer, ByVal jobDescription As String, ByVal notes As String, ByVal hoursSame As Boolean, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal outside_only As Integer, ByVal pay_basis As Decimal, ByVal bill_amount As Decimal, ByVal sub_pay As Decimal, ByVal schedule_amount As Decimal, ByVal payment_method As String, ByVal status As String, ByVal cancel_reason As String, ByVal oldStatus As String, ByVal oldUser As String, ByVal create_user As String, ByVal create_date As DateTime, ByVal modified_user As String, ByVal modified_date As DateTime) As SystemFramework.MessageHelper
            Dim jobDT As DataTranslation.JobDT = New DataTranslation.JobDT()
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateSchedAmt(sub_id, schedule_amount)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateClosedStatus(status)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateCancelReason(status, cancel_reason)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateJob(hoursSame, job_id, 0, sub_id, start_date, modified_date)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (Not (oldStatus="C" Or oldStatus="X")) Then
                modified_date = DateTime.Now()
            Else
                modified_user = oldUser
            End If
            If (jobDT.updateJobAll(tran, job_id, sub_id, bidHeader_ID, reminder, critical, priorSchedule, jobDescription, notes, start_date, end_date, outside_only, pay_basis, bill_amount, sub_pay, schedule_amount, payment_method, status, cancel_reason, create_user, create_date, modified_user, modified_date) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Job Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Function updateJobSchedule(ByRef tran As TransactionContext, ByVal job_id As Integer, ByVal site_id As Integer, ByVal sub_id As Integer, ByVal priorSchedule As Integer, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal modified_user As String, ByVal modified_date As DateTime, ByVal status As String, ByVal cancel_reason As String, ByVal schedule_amount As Decimal) As SystemFramework.MessageHelper
            Dim jobDT As DataTranslation.JobDT = New DataTranslation.JobDT()
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateSchedAmt(sub_id, schedule_amount)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateStatus(status)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateJob(False, job_id, 0, sub_id, start_date, modified_date)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (sub_id <> 0) Then
                If (Me.validateDupSiteDay(site_id, start_date)) Then
                    messageHelper.status = True
                Else
                    messageHelper.messageText = "Duplicate Job for Site/Day"
                    Me.warningMessage = messageHelper.messageText
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.status = True
                End If
            End If
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (jobDT.updateJob(tran, job_id, sub_id, priorSchedule, start_date, end_date, modified_user, DateTime.Now(), "O", cancel_reason) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(2)
                messageHelper.status = False
                messageHelper.messageText = "Job Update Failed"
            Else
                messageHelper.status = True
            End If
            If (StringType.StrCmp(Me.warningMessage, "", False) <> 0) Then
                messageHelper.messageText = Me.warningMessage
                Me.warningMessage = ""
            End If
            Return messageHelper
        End Function

        Private Function validateCancelReason(ByVal status As String, ByVal cancel_reason As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            ' if (StringType.StrCmp(status, "X", false) == 0 & cancel_reason.Length == 0 | (StringType.StrCmp(status, "O", false) == 0 | StringType.StrCmp(status, "C", false) == 0 | StringType.StrCmp(status, "D", false) == 0) & cancel_reason.Length != 0)
            If (Not (status = "X" And cancel_reason.Length() = 0 Or (status = "O" Or status = "C" Or status = "D") And cancel_reason.Length() <> 0)) Then
                messageHelper.status = True
            Else
                messageHelper.messageText = "Cancel Status and Reason Required"
                messageHelper.messageId = StringType.FromInteger(5)
                messageHelper.status = False
            End If
            Return messageHelper
        End Function

        Private Function validateClosedStatus(ByVal status As String) As MessageHelper
            Dim messageHelper As New SystemFramework.MessageHelper()
            messageHelper.status = True
            Return messageHelper
        End Function

        Private Function validateDupSiteDay(ByVal site_id As Integer, ByVal start_date As DateTime) As Boolean
            Dim jobDT As DataTranslation.JobDT = New DataTranslation.JobDT()
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = jobDT.countJobBySiteIdDate(site_id, start_date.Year(), start_date.Month(), start_date.Day())
            sqlDataReader.Read()
            If (IntegerType.FromObject(sqlDataReader.Item(0)) = 0) Then
                Return True
            End If
            Return False
        End Function

        Public Function validateJob(ByVal hoursSame As Boolean, ByVal job_id As Integer, ByVal site_id As Integer, ByVal sub_id As Integer, ByVal start_date As DateTime, ByVal modified_date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (sub_id <> 0) Then
                If (Not Me.validateOverBooking(hoursSame, sub_id, start_date)) Then
                    messageHelper.messageText = "Duplicate Time"
                    messageHelper.messageId = StringType.FromInteger(1)
                    Return messageHelper
                End If
                messageHelper.status = True
            End If
            If (Not SystemDT.checkDirtyRead(Me.tableName, Me.pkColumn, job_id, modified_date)) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(3)
            messageHelper.messageText = "Item Changed By Another User, Action Cancelled"
            Return messageHelper
        End Function

        Private Function validateOccBillClient(ByVal site_id As Integer) As Boolean
            Dim siteById As SqlDataReader = (New SiteDT()).getSiteById(site_id)
            siteById.Read()
            If (Information.IsDBNull(RuntimeHelpers.GetObjectValue(siteById.Item("OccClient_Id"))) And Information.IsDBNull(RuntimeHelpers.GetObjectValue(siteById.Item("BillClient_Id")))) Then
                Return False
            End If
            Return True
        End Function

        Private Function validateOrphanPresence(ByVal site_id As Integer) As Boolean
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = (New JobDT()).countJobBySiteId(site_id)
            sqlDataReader.Read()
            If (IntegerType.FromObject(sqlDataReader.Item(0)) = 0) Then
                Return True
            End If
            Return False
        End Function

        Private Function validateOverBooking(ByVal hoursSame As Boolean, ByVal sub_id As Integer, ByVal start_date As DateTime) As Boolean
            Dim jobDT As DataTranslation.JobDT = New DataTranslation.JobDT()
            If (hoursSame Or start_date.Hour() = 0 Or start_date.Hour() = 1 Or start_date.Hour() = 22 Or start_date.Hour() = 23) Then
                Return True
            End If
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = jobDT.countJobBySubStartDate(sub_id, start_date)
            sqlDataReader.Read()
            If (IntegerType.FromObject(sqlDataReader.Item(0)) = 0) Then
                Return True
            End If
            Return False
        End Function

        Private Function validateSchedAmt(ByVal sub_id As Integer, ByVal schedule_amount As Decimal) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Not (sub_id <> 0 And Decimal.Compare(schedule_amount, Decimal.Zero) = 0)) Then
                messageHelper.status = True
            Else
                messageHelper.messageText = "Schedule Amount Required"
                messageHelper.messageId = StringType.FromInteger(4)
            End If
            Return messageHelper
        End Function

        Private Function validateStatus(ByVal status As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (StringType.StrCmp(status, "C", False) <> 0) Then
                messageHelper.status = True
            Else
                messageHelper.messageText = "Cannot Un-Sched Closed Job"
                messageHelper.messageId = StringType.FromInteger(5)
            End If
            Return messageHelper
        End Function
    End Class
End Namespace