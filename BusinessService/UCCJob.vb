Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCJob
        Private job As Job

        Public Sub New()
            MyBase.New()
            Me.job = New Job()
        End Sub

        Public Function createJob(ByVal sub_id As Integer, ByVal site_id As Integer, ByVal bidHeader_ID As Integer, ByVal priorSchedule As Integer, ByVal job_description As String, ByVal notes As String, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal pay_basis As Decimal, ByVal bill_amount As Decimal, ByVal sub_pay As Decimal, ByVal schedule_amount As Decimal, ByVal status As String, ByVal cancel_reason As String, ByVal create_user As String, ByVal modified_user As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.job.createJob(transactionContext, sub_id, site_id, bidHeader_ID, priorSchedule, job_description, notes, start_date, end_date, pay_basis, bill_amount, sub_pay, schedule_amount, status, cancel_reason, create_user, modified_user)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function

        Public Function getJobById(ByVal job_id As Integer) As SqlDataReader
            Return Me.job.getJobById(job_id)
        End Function

        Public Function updateJobAll(ByVal job_id As Integer, ByVal sub_id As Integer, ByVal bidHeader_ID As Integer, ByVal reminder As Integer, ByVal critical As Integer, ByVal priorSchedule As Integer, ByVal jobDescription As String, ByVal notes As String, ByVal hoursSame As Boolean, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal outside_only As Integer, ByVal pay_basis As Decimal, ByVal bill_amount As Decimal, ByVal sub_pay As Decimal, ByVal schedule_amount As Decimal, ByVal payment_method As String, ByVal status As String, ByVal cancel_reason As String, ByVal oldStatus As String, ByVal oldUser As String, ByVal create_user As String, ByVal create_date As DateTime, ByVal modified_user As String, ByVal modified_date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.job.updateJobAll(transactionContext, job_id, sub_id, bidHeader_ID, reminder, critical, priorSchedule, jobDescription, notes, hoursSame, start_date, end_date, outside_only, pay_basis, bill_amount, sub_pay, schedule_amount, payment_method, status, cancel_reason, oldStatus, oldUser, create_user, create_date, modified_user, modified_date)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function

        Public Function updateJobSchedule(ByVal job_id As Integer, ByVal site_id As Integer, ByVal sub_id As Integer, ByVal priorSchedule As Integer, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal modified_user As String, ByVal modified_date As DateTime, ByVal status As String, ByVal cancel_reason As String, ByVal schedule_amount As Decimal) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.job.updateJobSchedule(transactionContext, job_id, site_id, sub_id, priorSchedule, start_date, end_date, modified_user, modified_date, status, cancel_reason, schedule_amount)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function
    End Class
End Namespace