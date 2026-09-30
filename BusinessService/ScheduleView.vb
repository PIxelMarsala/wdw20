Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Namespace BusinessService
    Public Class ScheduleView
        Public subcontractors As ArrayList

        Public Sub New()
            MyBase.New()
            Me.subcontractors = New ArrayList()
        End Sub

        Private Sub buildDateLookupCollection(ByRef dateCollection As Hashtable, ByVal suDate As DateTime, ByVal moDate As DateTime, ByVal tuDate As DateTime, ByVal weDate As DateTime, ByVal thDate As DateTime, ByVal frDate As DateTime, ByVal saDate As DateTime)
            Dim _dateEntry As ScheduleView.dateEntry = New ScheduleView.dateEntry(1, 0)
            dateCollection.Add(suDate, _dateEntry)
            Dim _dateEntry1 As ScheduleView.dateEntry = New ScheduleView.dateEntry(2, 0)
            dateCollection.Add(moDate, _dateEntry1)
            Dim _dateEntry2 As ScheduleView.dateEntry = New ScheduleView.dateEntry(3, 0)
            dateCollection.Add(tuDate, _dateEntry2)
            Dim _dateEntry3 As ScheduleView.dateEntry = New ScheduleView.dateEntry(4, 0)
            dateCollection.Add(weDate, _dateEntry3)
            Dim _dateEntry4 As ScheduleView.dateEntry = New ScheduleView.dateEntry(5, 0)
            dateCollection.Add(thDate, _dateEntry4)
            Dim _dateEntry5 As ScheduleView.dateEntry = New ScheduleView.dateEntry(6, 0)
            dateCollection.Add(frDate, _dateEntry5)
            Dim _dateEntry6 As ScheduleView.dateEntry = New ScheduleView.dateEntry(7, 0)
            dateCollection.Add(saDate, _dateEntry6)
        End Sub

        Public Function buildName(ByRef rdr As SqlDataReader) As String
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("OccClient_ID")))) Then
                If (Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("Occ_Last")))) Then
                    Return "DATAFIX"
                End If
                Return StringType.FromObject(rdr.Item("Occ_Last"))
            End If
            If (Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("BillClient_ID")))) Then
                Return "RESIDENT"
            End If
            Return StringType.FromObject(rdr.Item("Bill_Last"))
        End Function

        Private Sub createJobs(ByRef dateCollection As Hashtable, ByVal rdr As SqlDataReader, ByRef subJobRowcount As Integer, ByRef subcontractorView As ScheduleView.SubcontractorView)
            Dim jobView As ScheduleView.JobView = New ScheduleView.JobView()
            Dim dateTime As System.DateTime = DateType.FromObject(LateBinding.LateGet(rdr.Item("Start_Date"), Nothing, "Date", New Object(-1) {}, Nothing, Nothing))
            Dim item As ScheduleView.dateEntry = DirectCast(dateCollection.Item(dateTime), ScheduleView.dateEntry)
            Dim num As Integer = item.slotNumber
            Dim num1 As Integer = item.slotRowCount
            If (subJobRowcount <> num1) Then
                jobView = DirectCast(subcontractorView.subJobs.Item(num1), ScheduleView.JobView)
                Me.updateDateSlot(rdr, num, jobView, subcontractorView)
                num1 = num1 + 1
            Else
                num1 = num1 + 1
                subJobRowcount = subJobRowcount + 1
                Me.updateDateSlot(rdr, num, jobView, subcontractorView)
                subcontractorView.subJobs.Add(jobView)
            End If
            Dim obj As Object = dateCollection.Item(dateTime)
            Dim objArray() As Object = {num1}
            LateBinding.LateSetComplex(obj, Nothing, "slotRowCount", objArray, Nothing, False, True)
        End Sub

        Private Function createSubcontractor(ByVal rdr As SqlDataReader) As ScheduleView.SubcontractorView
            Dim subcontractorView As ScheduleView.SubcontractorView = New ScheduleView.SubcontractorView()

            subcontractorView.sub_ID = IntegerType.FromObject(rdr.Item("Sub_ID"))
            subcontractorView.nick_Name = StringType.FromObject(rdr.Item("Nick_Name"))
            subcontractorView.dollarMaxAmount = IntegerType.FromObject(rdr.Item("dollarMaxAmount"))
            subcontractorView.suRemainder = subcontractorView.dollarMaxAmount
            subcontractorView.suAM = IntegerType.FromObject(rdr.Item("Sun_AM"))
            subcontractorView.suPM = IntegerType.FromObject(rdr.Item("Sun_PM"))
            subcontractorView.moRemainder = subcontractorView.dollarMaxAmount
            subcontractorView.moAM = IntegerType.FromObject(rdr.Item("Mon_AM"))
            subcontractorView.moPM = IntegerType.FromObject(rdr.Item("Mon_PM"))
            subcontractorView.tuRemainder = subcontractorView.dollarMaxAmount
            subcontractorView.tuAM = IntegerType.FromObject(rdr.Item("Tues_AM"))
            subcontractorView.tuPM = IntegerType.FromObject(rdr.Item("Tues_PM"))
            subcontractorView.weRemainder = subcontractorView.dollarMaxAmount
            subcontractorView.weAM = IntegerType.FromObject(rdr.Item("Wed_AM"))
            subcontractorView.wePM = IntegerType.FromObject(rdr.Item("Wed_PM"))
            subcontractorView.thRemainder = subcontractorView.dollarMaxAmount
            subcontractorView.thAM = IntegerType.FromObject(rdr.Item("Th_AM"))
            subcontractorView.thPM = IntegerType.FromObject(rdr.Item("Th_PM"))
            subcontractorView.frRemainder = subcontractorView.dollarMaxAmount
            subcontractorView.frAM = IntegerType.FromObject(rdr.Item("Fri_AM"))
            subcontractorView.frPM = IntegerType.FromObject(rdr.Item("Fri_PM"))
            subcontractorView.saRemainder = subcontractorView.dollarMaxAmount
            subcontractorView.saAM = IntegerType.FromObject(rdr.Item("Sat_AM"))
            subcontractorView.saPM = IntegerType.FromObject(rdr.Item("Sat_PM"))
            subcontractorView.height = IntegerType.FromObject(rdr.Item("Height"))

            Return subcontractorView
        End Function

        Public Function getSchedule(ByVal area As Integer, ByVal areaText As String, ByVal begin_date As DateTime, ByVal end_date As DateTime, ByVal suDate As DateTime, ByVal moDate As DateTime, ByVal tuDate As DateTime, ByVal weDate As DateTime, ByVal thDate As DateTime, ByVal frDate As DateTime, ByVal saDate As DateTime) As Object
            Dim obj As Object = Nothing
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader
            Dim subcontractor As BusinessService.Subcontractor = New BusinessService.Subcontractor()
            Dim job As BusinessService.Job = New BusinessService.Job()
            Dim flag As Boolean = False
            Dim hashtable As System.Collections.Hashtable = New System.Collections.Hashtable()
            sqlDataReader = If(StringType.StrCmp(areaText, "ALL", False) <> 0, subcontractor.getActiveSubsByArea(area), subcontractor.getActiveSubs())
            Me.buildDateLookupCollection(hashtable, suDate, moDate, tuDate, weDate, thDate, frDate, saDate)
            While sqlDataReader.Read()
                Dim num As Integer = 0
                Me.refreshDateLookupCollection(hashtable)
                Dim subcontractorView As ScheduleView.SubcontractorView = Me.createSubcontractor(sqlDataReader)
                Me.subcontractors.Add(subcontractorView)
                Dim jobBySub As System.Data.SqlClient.SqlDataReader = job.getJobBySub(subcontractorView.sub_ID, begin_date, end_date)
                While jobBySub.Read()
                    Me.createJobs(hashtable, jobBySub, num, subcontractorView)
                    flag = True
                End While
                If (Not flag) Then
                    subcontractorView.subJobs.Add(New ScheduleView.JobView())
                Else
                    flag = False
                End If
                jobBySub.Close()
            End While
            sqlDataReader.Close()
            Return obj
        End Function

        Private Sub refreshDateLookupCollection(ByRef dateCollection As Hashtable)
            Dim enumerator As IDictionaryEnumerator = dateCollection.GetEnumerator()
            While enumerator.MoveNext()
                Dim value As Object = DirectCast((If(enumerator.Current(), Activator.CreateInstance(GetType(DictionaryEntry)))), DictionaryEntry).Value
                Dim objArray() As Object = {0}
                LateBinding.LateSetComplex(value, Nothing, "slotRowcount", objArray, Nothing, False, True)
            End While
        End Sub

        Private Sub updateDateSlot(ByVal rdr As SqlDataReader, ByVal slotNumber As Integer, ByRef jobView As ScheduleView.JobView, ByRef subContractorView As ScheduleView.SubcontractorView)
            Select Case slotNumber
                Case 1
                    Me.updateSunday(rdr, jobView, subContractorView)
                    Exit Select
                Case 2
                    Me.updateMonday(rdr, jobView, subContractorView)
                    Exit Select
                Case 3
                    Me.updateTuesday(rdr, jobView, subContractorView)
                    Exit Select
                Case 4
                    Me.updateWednesday(rdr, jobView, subContractorView)
                    Exit Select
                Case 5
                    Me.updateThursday(rdr, jobView, subContractorView)
                    Exit Select
                Case 6
                    Me.updateFriday(rdr, jobView, subContractorView)
                    Exit Select
                Case 7
                    Me.updateSaturday(rdr, jobView, subContractorView)
                    Exit Select
            End Select
        End Sub

        Private Sub updateFriday(ByRef rdr As SqlDataReader, ByRef job As ScheduleView.JobView, ByRef subcontractorView As ScheduleView.SubcontractorView)
            job.frJob_Id = IntegerType.FromObject(rdr.Item("Job_ID"))
            job.frSite_Id = IntegerType.FromObject(rdr.Item("Site_ID"))
            job.frStartDate = DateType.FromObject(rdr.Item("Start_Date"))
            job.frReminder = IntegerType.FromObject(rdr.Item("Reminder"))
            job.frCritical = IntegerType.FromObject(rdr.Item("critical"))
            job.frLastName = Me.buildName(rdr)
            job.frZipCode = StringType.FromObject(rdr.Item("ZipCode"))
            job.frNoStories = IntegerType.FromObject(rdr.Item("No_Stories"))
            job.frNoteType = IntegerType.FromObject(rdr.Item("Note_Type"))
            job.frSchdAmt = DecimalType.FromObject(rdr.Item("Schedule_Amount"))
            job.frSchdAmtInt = IntegerType.FromObject(rdr.Item("Schedule_Amount"))
            job.frModifiedDate = DateType.FromObject(rdr.Item("Modified_Date"))
            job.frStatus = StringType.FromObject(rdr.Item("Status"))
            job.frCancelReason = StringType.FromObject(rdr.Item("Cancel_Reason"))
            subcontractorView.frRemainder = Convert.ToInt32(Decimal.Subtract(New Decimal(subcontractorView.frRemainder), job.frSchdAmt))
        End Sub

        Private Sub updateMonday(ByRef rdr As SqlDataReader, ByRef job As ScheduleView.JobView, ByRef subcontractorView As ScheduleView.SubcontractorView)
            job.moJob_Id = IntegerType.FromObject(rdr.Item("Job_ID"))
            job.moSite_Id = IntegerType.FromObject(rdr.Item("Site_ID"))
            job.moStartDate = DateType.FromObject(rdr.Item("Start_Date"))
            job.moReminder = IntegerType.FromObject(rdr.Item("Reminder"))
            job.moCritical = IntegerType.FromObject(rdr.Item("critical"))
            job.moLastName = Me.buildName(rdr)
            job.moZipCode = StringType.FromObject(rdr.Item("ZipCode"))
            job.moNoStories = IntegerType.FromObject(rdr.Item("No_Stories"))
            job.moNoteType = IntegerType.FromObject(rdr.Item("Note_Type"))
            job.moSchdAmt = DecimalType.FromObject(rdr.Item("Schedule_Amount"))
            job.moSchdAmtInt = IntegerType.FromObject(rdr.Item("Schedule_Amount"))
            job.moModifiedDate = DateType.FromObject(rdr.Item("Modified_Date"))
            job.moStatus = StringType.FromObject(rdr.Item("Status"))
            job.moCancelReason = StringType.FromObject(rdr.Item("Cancel_Reason"))
            subcontractorView.moRemainder = Convert.ToInt32(Decimal.Subtract(New Decimal(subcontractorView.moRemainder), job.moSchdAmt))
        End Sub

        Private Sub updateSaturday(ByRef rdr As SqlDataReader, ByRef job As ScheduleView.JobView, ByRef subcontractorView As ScheduleView.SubcontractorView)
            job.saJob_Id = IntegerType.FromObject(rdr.Item("Job_ID"))
            job.saSite_Id = IntegerType.FromObject(rdr.Item("Site_ID"))
            job.saStartDate = DateType.FromObject(rdr.Item("Start_Date"))
            job.saReminder = IntegerType.FromObject(rdr.Item("Reminder"))
            job.saCritical = IntegerType.FromObject(rdr.Item("critical"))
            job.saLastName = Me.buildName(rdr)
            job.saZipCode = StringType.FromObject(rdr.Item("ZipCode"))
            job.saNoStories = IntegerType.FromObject(rdr.Item("No_Stories"))
            job.saNoteType = IntegerType.FromObject(rdr.Item("Note_Type"))
            job.saSchdAmt = DecimalType.FromObject(rdr.Item("Schedule_Amount"))
            job.saSchdAmtInt = IntegerType.FromObject(rdr.Item("Schedule_Amount"))
            job.saModifiedDate = DateType.FromObject(rdr.Item("Modified_Date"))
            job.saStatus = StringType.FromObject(rdr.Item("Status"))
            job.saCancelReason = StringType.FromObject(rdr.Item("Cancel_Reason"))
            subcontractorView.saRemainder = Convert.ToInt32(Decimal.Subtract(New Decimal(subcontractorView.saRemainder), job.saSchdAmt))
        End Sub

        Private Sub updateSunday(ByRef rdr As SqlDataReader, ByRef job As ScheduleView.JobView, ByRef subcontractorView As ScheduleView.SubcontractorView)
            job.suJob_Id = IntegerType.FromObject(rdr.Item("Job_ID"))
            job.suSite_Id = IntegerType.FromObject(rdr.Item("Site_ID"))
            job.suStartDate = DateType.FromObject(rdr.Item("Start_Date"))
            job.suReminder = IntegerType.FromObject(rdr.Item("Reminder"))
            job.suCritical = IntegerType.FromObject(rdr.Item("critical"))
            job.suLastName = Me.buildName(rdr)
            job.suZipCode = StringType.FromObject(rdr.Item("ZipCode"))
            job.suNoStories = IntegerType.FromObject(rdr.Item("No_Stories"))
            job.suNoteType = IntegerType.FromObject(rdr.Item("Note_Type"))
            job.suSchdAmt = DecimalType.FromObject(rdr.Item("Schedule_Amount"))
            job.suSchdAmtInt = IntegerType.FromObject(rdr.Item("Schedule_Amount"))
            job.suModifiedDate = DateType.FromObject(rdr.Item("Modified_Date"))
            job.suStatus = StringType.FromObject(rdr.Item("Status"))
            job.suCancelReason = StringType.FromObject(rdr.Item("Cancel_Reason"))
            subcontractorView.suRemainder = Convert.ToInt32(Decimal.Subtract(New Decimal(subcontractorView.suRemainder), job.suSchdAmt))
        End Sub

        Private Sub updateThursday(ByRef rdr As SqlDataReader, ByRef job As ScheduleView.JobView, ByRef subcontractorView As ScheduleView.SubcontractorView)
            job.thJob_Id = IntegerType.FromObject(rdr.Item("Job_ID"))
            job.thSite_Id = IntegerType.FromObject(rdr.Item("Site_ID"))
            job.thStartDate = DateType.FromObject(rdr.Item("Start_Date"))
            job.thReminder = IntegerType.FromObject(rdr.Item("Reminder"))
            job.thCritical = IntegerType.FromObject(rdr.Item("critical"))
            job.thLastName = Me.buildName(rdr)
            job.thZipCode = StringType.FromObject(rdr.Item("ZipCode"))
            job.thNoStories = IntegerType.FromObject(rdr.Item("No_Stories"))
            job.thNoteType = IntegerType.FromObject(rdr.Item("Note_Type"))
            job.thSchdAmt = DecimalType.FromObject(rdr.Item("Schedule_Amount"))
            job.thSchdAmtInt = IntegerType.FromObject(rdr.Item("Schedule_Amount"))
            job.thModifiedDate = DateType.FromObject(rdr.Item("Modified_Date"))
            job.thStatus = StringType.FromObject(rdr.Item("Status"))
            job.thCancelReason = StringType.FromObject(rdr.Item("Cancel_Reason"))
            subcontractorView.thRemainder = Convert.ToInt32(Decimal.Subtract(New Decimal(subcontractorView.thRemainder), job.thSchdAmt))
        End Sub

        Private Sub updateTuesday(ByRef rdr As SqlDataReader, ByRef job As ScheduleView.JobView, ByRef subcontractorView As ScheduleView.SubcontractorView)
            job.tuJob_Id = IntegerType.FromObject(rdr.Item("Job_ID"))
            job.tuSite_Id = IntegerType.FromObject(rdr.Item("Site_ID"))
            job.tuStartDate = DateType.FromObject(rdr.Item("Start_Date"))
            job.tuReminder = IntegerType.FromObject(rdr.Item("Reminder"))
            job.tuCritical = IntegerType.FromObject(rdr.Item("critical"))
            job.tuLastName = Me.buildName(rdr)
            job.tuZipCode = StringType.FromObject(rdr.Item("ZipCode"))
            job.tuNoStories = IntegerType.FromObject(rdr.Item("No_Stories"))
            job.tuNoteType = IntegerType.FromObject(rdr.Item("Note_Type"))
            job.tuSchdAmt = DecimalType.FromObject(rdr.Item("Schedule_Amount"))
            job.tuSchdAmtInt = IntegerType.FromObject(rdr.Item("Schedule_Amount"))
            job.tuModifiedDate = DateType.FromObject(rdr.Item("Modified_Date"))
            job.tuStatus = StringType.FromObject(rdr.Item("Status"))
            job.tuCancelReason = StringType.FromObject(rdr.Item("Cancel_Reason"))
            subcontractorView.tuRemainder = Convert.ToInt32(Decimal.Subtract(New Decimal(subcontractorView.tuRemainder), job.tuSchdAmt))
        End Sub

        Private Sub updateWednesday(ByRef rdr As SqlDataReader, ByRef job As ScheduleView.JobView, ByRef subcontractorView As ScheduleView.SubcontractorView)
            job.weJob_Id = IntegerType.FromObject(rdr.Item("Job_ID"))
            job.weSite_Id = IntegerType.FromObject(rdr.Item("Site_ID"))
            job.weStartDate = DateType.FromObject(rdr.Item("Start_Date"))
            job.weReminder = IntegerType.FromObject(rdr.Item("Reminder"))
            job.weCritical = IntegerType.FromObject(rdr.Item("critical"))
            job.weLastName = Me.buildName(rdr)
            job.weZipCode = StringType.FromObject(rdr.Item("ZipCode"))
            job.weNoStories = IntegerType.FromObject(rdr.Item("No_Stories"))
            job.weNoteType = IntegerType.FromObject(rdr.Item("Note_Type"))
            job.weSchdAmt = DecimalType.FromObject(rdr.Item("Schedule_Amount"))
            job.weSchdAmtInt = IntegerType.FromObject(rdr.Item("Schedule_Amount"))
            job.weModifiedDate = DateType.FromObject(rdr.Item("Modified_Date"))
            job.weStatus = StringType.FromObject(rdr.Item("Status"))
            job.weCancelReason = StringType.FromObject(rdr.Item("Cancel_Reason"))
            subcontractorView.weRemainder = Convert.ToInt32(Decimal.Subtract(New Decimal(subcontractorView.weRemainder), job.weSchdAmt))
        End Sub

        Private Class dateEntry
            Public slotNumber As Integer

            Public slotRowCount As Integer

            Public Sub New(ByVal slot As Integer, ByVal count As Integer)
                MyBase.New()
                Me.slotNumber = slot
                Me.slotRowCount = count
            End Sub
        End Class

        Public Class JobView
            Private m_suJob_Id As Integer

            Private m_suSite_Id As Integer

            Private m_suReminder As Integer

            Private m_suCritical As Integer

            Private m_suStartDate As DateTime

            Private m_suZipCode As String

            Private m_suNoStories As Integer

            Private m_suNoteType As Integer

            Private m_suLastName As String

            Private m_suSchdAmtInt As Integer

            Private m_suSchdAmt As Decimal

            Private m_suModifiedDate As DateTime

            Private m_suStatus As String

            Private m_suCancelReason As String

            Private m_moJob_Id As Integer

            Private m_moSite_Id As Integer

            Private m_moReminder As Integer

            Private m_moCritical As Integer

            Private m_moStartDate As DateTime

            Private m_moZipCode As String

            Private m_moNoStories As Integer

            Private m_moNoteType As Integer

            Private m_moLastName As String

            Private m_moSchdAmtInt As Integer

            Private m_moSchdAmt As Decimal

            Private m_moModifiedDate As DateTime

            Private m_moStatus As String

            Private m_moCancelReason As String

            Private m_tuJob_Id As Integer

            Private m_tuSite_Id As Integer

            Private m_tuReminder As Integer

            Private m_tuCritical As Integer

            Private m_tuStartDate As DateTime

            Private m_tuZipCode As String

            Private m_tuNoStories As Integer

            Private m_tuNoteType As Integer

            Private m_tuLastName As String

            Private m_tuSchdAmtInt As Integer

            Private m_tuSchdAmt As Decimal

            Private m_tuModifiedDate As DateTime

            Private m_tuStatus As String

            Private m_tuCancelReason As String

            Private m_weJob_Id As Integer

            Private m_weSite_Id As Integer

            Private m_weReminder As Integer

            Private m_weCritical As Integer

            Private m_weStartDate As DateTime

            Private m_weZipCode As String

            Private m_weNoStories As Integer

            Private m_weNoteType As Integer

            Private m_weLastName As String

            Private m_weSchdAmtInt As Integer

            Private m_weSchdAmt As Decimal

            Private m_weModifiedDate As DateTime

            Private m_weStatus As String

            Private m_weCancelReason As String

            Private m_thJob_Id As Integer

            Private m_thSite_Id As Integer

            Private m_thReminder As Integer

            Private m_thCritical As Integer

            Private m_thStartDate As DateTime

            Private m_thZipCode As String

            Private m_thNoStories As Integer

            Private m_thNoteType As Integer

            Private m_thLastName As String

            Private m_thSchdAmtInt As Integer

            Private m_thSchdAmt As Decimal

            Private m_thModifiedDate As DateTime

            Private m_thStatus As String

            Private m_thCancelReason As String

            Private m_frJob_Id As Integer

            Private m_frSite_Id As Integer

            Private m_frReminder As Integer

            Private m_frCritical As Integer

            Private m_frStartDate As DateTime

            Private m_frZipCode As String

            Private m_frNoStories As Integer

            Private m_frNoteType As Integer

            Private m_frLastName As String

            Private m_frSchdAmtInt As Integer

            Private m_frSchdAmt As Decimal

            Private m_frModifiedDate As DateTime

            Private m_frStatus As String

            Private m_frCancelReason As String

            Private m_saJob_Id As Integer

            Private m_saSite_Id As Integer

            Private m_saReminder As Integer

            Private m_saCritical As Integer

            Private m_saStartDate As DateTime

            Private m_saZipCode As String

            Private m_saNoStories As Integer

            Private m_saNoteType As Integer

            Private m_saLastName As String

            Private m_saSchdAmtInt As Integer

            Private m_saSchdAmt As Decimal

            Private m_saModifiedDate As DateTime

            Private m_saStatus As String

            Private m_saCancelReason As String

            Public Property frCancelReason As String
                Get
                    Return Me.m_frCancelReason
                End Get
                Set(ByVal value As String)
                    Me.m_frCancelReason = value
                End Set
            End Property

            Public Property frCritical As Integer
                Get
                    Return Me.m_frCritical
                End Get
                Set(ByVal value As Integer)
                    Me.m_frCritical = value
                End Set
            End Property

            Public Property frJob_Id As Integer
                Get
                    Return Me.m_frJob_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_frJob_Id = value
                End Set
            End Property

            Public Property frLastName As String
                Get
                    Return Me.m_frLastName
                End Get
                Set(ByVal value As String)
                    Me.m_frLastName = value
                End Set
            End Property

            Public Property frModifiedDate As DateTime
                Get
                    Return Me.m_frModifiedDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_frModifiedDate = value
                End Set
            End Property

            Public Property frNoStories As Integer
                Get
                    Return Me.m_frNoStories
                End Get
                Set(ByVal value As Integer)
                    Me.m_frNoStories = value
                End Set
            End Property

            Public Property frNoteType As Integer
                Get
                    Return Me.m_frNoteType
                End Get
                Set(ByVal value As Integer)
                    Me.m_frNoteType = value
                End Set
            End Property

            Public Property frReminder As Integer
                Get
                    Return Me.m_frReminder
                End Get
                Set(ByVal value As Integer)
                    Me.m_frReminder = value
                End Set
            End Property

            Public Property frSchdAmt As Decimal
                Get
                    Return Me.m_frSchdAmt
                End Get
                Set(ByVal value As Decimal)
                    Me.m_frSchdAmt = value
                End Set
            End Property

            Public Property frSchdAmtInt As Integer
                Get
                    Return Me.m_frSchdAmtInt
                End Get
                Set(ByVal value As Integer)
                    Me.m_frSchdAmtInt = value
                End Set
            End Property

            Public Property frSite_Id As Integer
                Get
                    Return Me.m_frSite_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_frSite_Id = value
                End Set
            End Property

            Public Property frStartDate As DateTime
                Get
                    Return Me.m_frStartDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_frStartDate = value
                End Set
            End Property

            Public Property frStatus As String
                Get
                    Return Me.m_frStatus
                End Get
                Set(ByVal value As String)
                    Me.m_frStatus = value
                End Set
            End Property

            Public Property frZipCode As String
                Get
                    Return Me.m_frZipCode
                End Get
                Set(ByVal value As String)
                    Me.m_frZipCode = value
                End Set
            End Property

            Public Property moCancelReason As String
                Get
                    Return Me.m_moCancelReason
                End Get
                Set(ByVal value As String)
                    Me.m_moCancelReason = value
                End Set
            End Property

            Public Property moCritical As Integer
                Get
                    Return Me.m_moCritical
                End Get
                Set(ByVal value As Integer)
                    Me.m_moCritical = value
                End Set
            End Property

            Public Property moJob_Id As Integer
                Get
                    Return Me.m_moJob_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_moJob_Id = value
                End Set
            End Property

            Public Property moLastName As String
                Get
                    Return Me.m_moLastName
                End Get
                Set(ByVal value As String)
                    Me.m_moLastName = value
                End Set
            End Property

            Public Property moModifiedDate As DateTime
                Get
                    Return Me.m_moModifiedDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_moModifiedDate = value
                End Set
            End Property

            Public Property moNoStories As Integer
                Get
                    Return Me.m_moNoStories
                End Get
                Set(ByVal value As Integer)
                    Me.m_moNoStories = value
                End Set
            End Property

            Public Property moNoteType As Integer
                Get
                    Return Me.m_moNoteType
                End Get
                Set(ByVal value As Integer)
                    Me.m_moNoteType = value
                End Set
            End Property

            Public Property moReminder As Integer
                Get
                    Return Me.m_moReminder
                End Get
                Set(ByVal value As Integer)
                    Me.m_moReminder = value
                End Set
            End Property

            Public Property moSchdAmt As Decimal
                Get
                    Return Me.m_moSchdAmt
                End Get
                Set(ByVal value As Decimal)
                    Me.m_moSchdAmt = value
                End Set
            End Property

            Public Property moSchdAmtInt As Integer
                Get
                    Return Me.m_moSchdAmtInt
                End Get
                Set(ByVal value As Integer)
                    Me.m_moSchdAmtInt = value
                End Set
            End Property

            Public Property moSite_Id As Integer
                Get
                    Return Me.m_moSite_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_moSite_Id = value
                End Set
            End Property

            Public Property moStartDate As DateTime
                Get
                    Return Me.m_moStartDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_moStartDate = value
                End Set
            End Property

            Public Property moStatus As String
                Get
                    Return Me.m_moStatus
                End Get
                Set(ByVal value As String)
                    Me.m_moStatus = value
                End Set
            End Property

            Public Property moZipCode As String
                Get
                    Return Me.m_moZipCode
                End Get
                Set(ByVal value As String)
                    Me.m_moZipCode = value
                End Set
            End Property

            Public Property saCancelReason As String
                Get
                    Return Me.m_saCancelReason
                End Get
                Set(ByVal value As String)
                    Me.m_saCancelReason = value
                End Set
            End Property

            Public Property saCritical As Integer
                Get
                    Return Me.m_saCritical
                End Get
                Set(ByVal value As Integer)
                    Me.m_saCritical = value
                End Set
            End Property

            Public Property saJob_Id As Integer
                Get
                    Return Me.m_saJob_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_saJob_Id = value
                End Set
            End Property

            Public Property saLastName As String
                Get
                    Return Me.m_saLastName
                End Get
                Set(ByVal value As String)
                    Me.m_saLastName = value
                End Set
            End Property

            Public Property saModifiedDate As DateTime
                Get
                    Return Me.m_saModifiedDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_saModifiedDate = value
                End Set
            End Property

            Public Property saNoStories As Integer
                Get
                    Return Me.m_saNoStories
                End Get
                Set(ByVal value As Integer)
                    Me.m_saNoStories = value
                End Set
            End Property

            Public Property saNoteType As Integer
                Get
                    Return Me.m_saNoteType
                End Get
                Set(ByVal value As Integer)
                    Me.m_saNoteType = value
                End Set
            End Property

            Public Property saReminder As Integer
                Get
                    Return Me.m_saReminder
                End Get
                Set(ByVal value As Integer)
                    Me.m_saReminder = value
                End Set
            End Property

            Public Property saSchdAmt As Decimal
                Get
                    Return Me.m_saSchdAmt
                End Get
                Set(ByVal value As Decimal)
                    Me.m_saSchdAmt = value
                End Set
            End Property

            Public Property saSchdAmtInt As Integer
                Get
                    Return Me.m_saSchdAmtInt
                End Get
                Set(ByVal value As Integer)
                    Me.m_saSchdAmtInt = value
                End Set
            End Property

            Public Property saSite_Id As Integer
                Get
                    Return Me.m_saSite_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_saSite_Id = value
                End Set
            End Property

            Public Property saStartDate As DateTime
                Get
                    Return Me.m_saStartDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_saStartDate = value
                End Set
            End Property

            Public Property saStatus As String
                Get
                    Return Me.m_saStatus
                End Get
                Set(ByVal value As String)
                    Me.m_saStatus = value
                End Set
            End Property

            Public Property saZipCode As String
                Get
                    Return Me.m_saZipCode
                End Get
                Set(ByVal value As String)
                    Me.m_saZipCode = value
                End Set
            End Property

            Public Property suCancelReason As String
                Get
                    Return Me.m_suCancelReason
                End Get
                Set(ByVal value As String)
                    Me.m_suCancelReason = value
                End Set
            End Property

            Public Property suCritical As Integer
                Get
                    Return Me.m_suCritical
                End Get
                Set(ByVal value As Integer)
                    Me.m_suCritical = value
                End Set
            End Property

            Public Property suJob_Id As Integer
                Get
                    Return Me.m_suJob_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_suJob_Id = value
                End Set
            End Property

            Public Property suLastName As String
                Get
                    Return Me.m_suLastName
                End Get
                Set(ByVal value As String)
                    Me.m_suLastName = value
                End Set
            End Property

            Public Property suModifiedDate As DateTime
                Get
                    Return Me.m_suModifiedDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_suModifiedDate = value
                End Set
            End Property

            Public Property suNoStories As Integer
                Get
                    Return Me.m_suNoStories
                End Get
                Set(ByVal value As Integer)
                    Me.m_suNoStories = value
                End Set
            End Property

            Public Property suNoteType As Integer
                Get
                    Return Me.m_suNoteType
                End Get
                Set(ByVal value As Integer)
                    Me.m_suNoteType = value
                End Set
            End Property

            Public Property suReminder As Integer
                Get
                    Return Me.m_suReminder
                End Get
                Set(ByVal value As Integer)
                    Me.m_suReminder = value
                End Set
            End Property

            Public Property suSchdAmt As Decimal
                Get
                    Return Me.m_suSchdAmt
                End Get
                Set(ByVal value As Decimal)
                    Me.m_suSchdAmt = value
                End Set
            End Property

            Public Property suSchdAmtInt As Integer
                Get
                    Return Me.m_suSchdAmtInt
                End Get
                Set(ByVal value As Integer)
                    Me.m_suSchdAmtInt = value
                End Set
            End Property

            Public Property suSite_Id As Integer
                Get
                    Return Me.m_suSite_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_suSite_Id = value
                End Set
            End Property

            Public Property suStartDate As DateTime
                Get
                    Return Me.m_suStartDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_suStartDate = value
                End Set
            End Property

            Public Property suStatus As String
                Get
                    Return Me.m_suStatus
                End Get
                Set(ByVal value As String)
                    Me.m_suStatus = value
                End Set
            End Property

            Public Property suZipCode As String
                Get
                    Return Me.m_suZipCode
                End Get
                Set(ByVal value As String)
                    Me.m_suZipCode = value
                End Set
            End Property

            Public Property thCancelReason As String
                Get
                    Return Me.m_thCancelReason
                End Get
                Set(ByVal value As String)
                    Me.m_thCancelReason = value
                End Set
            End Property

            Public Property thCritical As Integer
                Get
                    Return Me.m_thCritical
                End Get
                Set(ByVal value As Integer)
                    Me.m_thCritical = value
                End Set
            End Property

            Public Property thJob_Id As Integer
                Get
                    Return Me.m_thJob_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_thJob_Id = value
                End Set
            End Property

            Public Property thLastName As String
                Get
                    Return Me.m_thLastName
                End Get
                Set(ByVal value As String)
                    Me.m_thLastName = value
                End Set
            End Property

            Public Property thModifiedDate As DateTime
                Get
                    Return Me.m_thModifiedDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_thModifiedDate = value
                End Set
            End Property

            Public Property thNoStories As Integer
                Get
                    Return Me.m_thNoStories
                End Get
                Set(ByVal value As Integer)
                    Me.m_thNoStories = value
                End Set
            End Property

            Public Property thNoteType As Integer
                Get
                    Return Me.m_thNoteType
                End Get
                Set(ByVal value As Integer)
                    Me.m_thNoteType = value
                End Set
            End Property

            Public Property thReminder As Integer
                Get
                    Return Me.m_thReminder
                End Get
                Set(ByVal value As Integer)
                    Me.m_thReminder = value
                End Set
            End Property

            Public Property thSchdAmt As Decimal
                Get
                    Return Me.m_thSchdAmt
                End Get
                Set(ByVal value As Decimal)
                    Me.m_thSchdAmt = value
                End Set
            End Property

            Public Property thSchdAmtInt As Integer
                Get
                    Return Me.m_thSchdAmtInt
                End Get
                Set(ByVal value As Integer)
                    Me.m_thSchdAmtInt = value
                End Set
            End Property

            Public Property thSite_Id As Integer
                Get
                    Return Me.m_thSite_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_thSite_Id = value
                End Set
            End Property

            Public Property thStartDate As DateTime
                Get
                    Return Me.m_thStartDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_thStartDate = value
                End Set
            End Property

            Public Property thStatus As String
                Get
                    Return Me.m_thStatus
                End Get
                Set(ByVal value As String)
                    Me.m_thStatus = value
                End Set
            End Property

            Public Property thZipCode As String
                Get
                    Return Me.m_thZipCode
                End Get
                Set(ByVal value As String)
                    Me.m_thZipCode = value
                End Set
            End Property

            Public Property tuCancelReason As String
                Get
                    Return Me.m_tuCancelReason
                End Get
                Set(ByVal value As String)
                    Me.m_tuCancelReason = value
                End Set
            End Property

            Public Property tuCritical As Integer
                Get
                    Return Me.m_tuCritical
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuCritical = value
                End Set
            End Property

            Public Property tuJob_Id As Integer
                Get
                    Return Me.m_tuJob_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuJob_Id = value
                End Set
            End Property

            Public Property tuLastName As String
                Get
                    Return Me.m_tuLastName
                End Get
                Set(ByVal value As String)
                    Me.m_tuLastName = value
                End Set
            End Property

            Public Property tuModifiedDate As DateTime
                Get
                    Return Me.m_tuModifiedDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_tuModifiedDate = value
                End Set
            End Property

            Public Property tuNoStories As Integer
                Get
                    Return Me.m_tuNoStories
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuNoStories = value
                End Set
            End Property

            Public Property tuNoteType As Integer
                Get
                    Return Me.m_tuNoteType
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuNoteType = value
                End Set
            End Property

            Public Property tuReminder As Integer
                Get
                    Return Me.m_tuReminder
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuReminder = value
                End Set
            End Property

            Public Property tuSchdAmt As Decimal
                Get
                    Return Me.m_tuSchdAmt
                End Get
                Set(ByVal value As Decimal)
                    Me.m_tuSchdAmt = value
                End Set
            End Property

            Public Property tuSchdAmtInt As Integer
                Get
                    Return Me.m_tuSchdAmtInt
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuSchdAmtInt = value
                End Set
            End Property

            Public Property tuSite_Id As Integer
                Get
                    Return Me.m_tuSite_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuSite_Id = value
                End Set
            End Property

            Public Property tuStartDate As DateTime
                Get
                    Return Me.m_tuStartDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_tuStartDate = value
                End Set
            End Property

            Public Property tuStatus As String
                Get
                    Return Me.m_tuStatus
                End Get
                Set(ByVal value As String)
                    Me.m_tuStatus = value
                End Set
            End Property

            Public Property tuZipCode As String
                Get
                    Return Me.m_tuZipCode
                End Get
                Set(ByVal value As String)
                    Me.m_tuZipCode = value
                End Set
            End Property

            Public Property weCancelReason As String
                Get
                    Return Me.m_weCancelReason
                End Get
                Set(ByVal value As String)
                    Me.m_weCancelReason = value
                End Set
            End Property

            Public Property weCritical As Integer
                Get
                    Return Me.m_weCritical
                End Get
                Set(ByVal value As Integer)
                    Me.m_weCritical = value
                End Set
            End Property

            Public Property weJob_Id As Integer
                Get
                    Return Me.m_weJob_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_weJob_Id = value
                End Set
            End Property

            Public Property weLastName As String
                Get
                    Return Me.m_weLastName
                End Get
                Set(ByVal value As String)
                    Me.m_weLastName = value
                End Set
            End Property

            Public Property weModifiedDate As DateTime
                Get
                    Return Me.m_weModifiedDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_weModifiedDate = value
                End Set
            End Property

            Public Property weNoStories As Integer
                Get
                    Return Me.m_weNoStories
                End Get
                Set(ByVal value As Integer)
                    Me.m_weNoStories = value
                End Set
            End Property

            Public Property weNoteType As Integer
                Get
                    Return Me.m_weNoteType
                End Get
                Set(ByVal value As Integer)
                    Me.m_weNoteType = value
                End Set
            End Property

            Public Property weReminder As Integer
                Get
                    Return Me.m_weReminder
                End Get
                Set(ByVal value As Integer)
                    Me.m_weReminder = value
                End Set
            End Property

            Public Property weSchdAmt As Decimal
                Get
                    Return Me.m_weSchdAmt
                End Get
                Set(ByVal value As Decimal)
                    Me.m_weSchdAmt = value
                End Set
            End Property

            Public Property weSchdAmtInt As Integer
                Get
                    Return Me.m_weSchdAmtInt
                End Get
                Set(ByVal value As Integer)
                    Me.m_weSchdAmtInt = value
                End Set
            End Property

            Public Property weSite_Id As Integer
                Get
                    Return Me.m_weSite_Id
                End Get
                Set(ByVal value As Integer)
                    Me.m_weSite_Id = value
                End Set
            End Property

            Public Property weStartDate As DateTime
                Get
                    Return Me.m_weStartDate
                End Get
                Set(ByVal value As DateTime)
                    Me.m_weStartDate = value
                End Set
            End Property

            Public Property weStatus As String
                Get
                    Return Me.m_weStatus
                End Get
                Set(ByVal value As String)
                    Me.m_weStatus = value
                End Set
            End Property

            Public Property weZipCode As String
                Get
                    Return Me.m_weZipCode
                End Get
                Set(ByVal value As String)
                    Me.m_weZipCode = value
                End Set
            End Property

            Public Sub New()
                MyBase.New()
            End Sub
        End Class

        Public Class SubcontractorView
            Private m_sub_ID As Integer

            Private m_nick_Name As String

            Private m_dollarMaxAmount As String

            Private m_suDef As String

            Private m_suRemainder As Integer

            Private m_suAM As Integer

            Private m_suPM As Integer

            Private m_moDef As String

            Private m_moRemainder As Integer

            Private m_moAM As Integer

            Private m_moPM As Integer

            Private m_tuDef As String

            Private m_tuRemainder As Integer

            Private m_tuAM As Integer

            Private m_tuPM As Integer

            Private m_weDef As String

            Private m_weRemainder As Integer

            Private m_weAM As Integer

            Private m_wePM As Integer

            Private m_thDef As String

            Private m_thRemainder As Integer

            Private m_thAM As Integer

            Private m_thPM As Integer

            Private m_frDef As String

            Private m_frRemainder As Integer

            Private m_frAM As Integer

            Private m_frPM As Integer

            Private m_saDef As String

            Private m_saRemainder As Integer

            Private m_saAM As Integer

            Private m_saPM As Integer

            Private m_Height As Integer

            Private m_subJobs As ArrayList

            Public Property dollarMaxAmount As Integer
                Get
                    Return IntegerType.FromString(Me.m_dollarMaxAmount)
                End Get
                Set(ByVal value As Integer)
                    Me.m_dollarMaxAmount = StringType.FromInteger(value)
                End Set
            End Property

            Public Property frAM As Integer
                Get
                    Return Me.m_frAM
                End Get
                Set(ByVal value As Integer)
                    Me.m_frAM = value
                End Set
            End Property

            Public Property frDef As String
                Get
                    Return Me.m_frDef
                End Get
                Set(ByVal value As String)
                    Me.m_frDef = value
                End Set
            End Property

            Public Property frPM As Integer
                Get
                    Return Me.m_frPM
                End Get
                Set(ByVal value As Integer)
                    Me.m_frPM = value
                End Set
            End Property

            Public Property frRemainder As Integer
                Get
                    Return Me.m_frRemainder
                End Get
                Set(ByVal value As Integer)
                    Me.m_frRemainder = value
                End Set
            End Property

            Public Property height As Integer
                Get
                    Return Me.m_Height
                End Get
                Set(ByVal value As Integer)
                    Me.m_Height = value
                End Set
            End Property

            Public Property moAM As Integer
                Get
                    Return Me.m_moAM
                End Get
                Set(ByVal value As Integer)
                    Me.m_moAM = value
                End Set
            End Property

            Public Property moDef As String
                Get
                    Return Me.m_moDef
                End Get
                Set(ByVal value As String)
                    Me.m_moDef = value
                End Set
            End Property

            Public Property moPM As Integer
                Get
                    Return Me.m_moPM
                End Get
                Set(ByVal value As Integer)
                    Me.m_moPM = value
                End Set
            End Property

            Public Property moRemainder As Integer
                Get
                    Return Me.m_moRemainder
                End Get
                Set(ByVal value As Integer)
                    Me.m_moRemainder = value
                End Set
            End Property

            Public Property nick_Name As String
                Get
                    Return Me.m_nick_Name
                End Get
                Set(ByVal value As String)
                    Me.m_nick_Name = value
                End Set
            End Property

            Public Property saAM As Integer
                Get
                    Return Me.m_saAM
                End Get
                Set(ByVal value As Integer)
                    Me.m_saAM = value
                End Set
            End Property

            Public Property saDef As String
                Get
                    Return Me.m_saDef
                End Get
                Set(ByVal value As String)
                    Me.m_saDef = value
                End Set
            End Property

            Public Property saPM As Integer
                Get
                    Return Me.m_saPM
                End Get
                Set(ByVal value As Integer)
                    Me.m_saPM = value
                End Set
            End Property

            Public Property saRemainder As Integer
                Get
                    Return Me.m_saRemainder
                End Get
                Set(ByVal value As Integer)
                    Me.m_saRemainder = value
                End Set
            End Property

            Public Property suAM As Integer
                Get
                    Return Me.m_suAM
                End Get
                Set(ByVal value As Integer)
                    Me.m_suAM = value
                End Set
            End Property

            Public Property sub_ID As Integer
                Get
                    Return Me.m_sub_ID
                End Get
                Set(ByVal value As Integer)
                    Me.m_sub_ID = value
                End Set
            End Property

            Public Property subJobs As ArrayList
                Get
                    Return Me.m_subJobs
                End Get
                Set(ByVal value As ArrayList)
                    Me.m_subJobs = Me.subJobs
                End Set
            End Property

            Public Property suDef As String
                Get
                    Return Me.m_suDef
                End Get
                Set(ByVal value As String)
                    Me.m_suDef = value
                End Set
            End Property

            Public Property suPM As Integer
                Get
                    Return Me.m_suPM
                End Get
                Set(ByVal value As Integer)
                    Me.m_suPM = value
                End Set
            End Property

            Public Property suRemainder As Integer
                Get
                    Return Me.m_suRemainder
                End Get
                Set(ByVal value As Integer)
                    Me.m_suRemainder = value
                End Set
            End Property

            Public Property thAM As Integer
                Get
                    Return Me.m_thAM
                End Get
                Set(ByVal value As Integer)
                    Me.m_thAM = value
                End Set
            End Property

            Public Property thDef As String
                Get
                    Return Me.m_thDef
                End Get
                Set(ByVal value As String)
                    Me.m_thDef = value
                End Set
            End Property

            Public Property thPM As Integer
                Get
                    Return Me.m_thPM
                End Get
                Set(ByVal value As Integer)
                    Me.m_thPM = value
                End Set
            End Property

            Public Property thRemainder As Integer
                Get
                    Return Me.m_thRemainder
                End Get
                Set(ByVal value As Integer)
                    Me.m_thRemainder = value
                End Set
            End Property

            Public Property tuAM As Integer
                Get
                    Return Me.m_tuAM
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuAM = value
                End Set
            End Property

            Public Property tuDef As String
                Get
                    Return Me.m_tuDef
                End Get
                Set(ByVal value As String)
                    Me.m_tuDef = value
                End Set
            End Property

            Public Property tuPM As Integer
                Get
                    Return Me.m_tuPM
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuPM = value
                End Set
            End Property

            Public Property tuRemainder As Integer
                Get
                    Return Me.m_tuRemainder
                End Get
                Set(ByVal value As Integer)
                    Me.m_tuRemainder = value
                End Set
            End Property

            Public Property weAM As Integer
                Get
                    Return Me.m_weAM
                End Get
                Set(ByVal value As Integer)
                    Me.m_weAM = value
                End Set
            End Property

            Public Property weDef As String
                Get
                    Return Me.m_weDef
                End Get
                Set(ByVal value As String)
                    Me.m_weDef = value
                End Set
            End Property

            Public Property wePM As Integer
                Get
                    Return Me.m_wePM
                End Get
                Set(ByVal value As Integer)
                    Me.m_wePM = value
                End Set
            End Property

            Public Property weRemainder As Integer
                Get
                    Return Me.m_weRemainder
                End Get
                Set(ByVal value As Integer)
                    Me.m_weRemainder = value
                End Set
            End Property

            Public Sub New()
                MyBase.New()
                Me.m_subJobs = New ArrayList()
            End Sub
        End Class
    End Class
End Namespace