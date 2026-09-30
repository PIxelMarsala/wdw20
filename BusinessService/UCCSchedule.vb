Imports DataAccess
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCSchedule
        Private subcontractor As Subcontractor

        Private job As Job

        Private trans As TransactionContext

        Public Sub New()
            MyBase.New()
            Me.subcontractor = New Subcontractor()
            Me.job = New Job()
            Me.trans = New TransactionContext()
        End Sub

        Public Function createJob(ByVal sub_id As Integer, ByVal site_id As Integer, ByVal bidHeader_ID As Integer, ByVal priorSchedule As Integer, ByVal job_description As String, ByVal notes As String, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal pay_basis As Decimal, ByVal bill_amount As Decimal, ByVal sub_pay As Decimal, ByVal schedule_amount As Decimal, ByVal status As String, ByVal cancel_reason As String, ByVal create_user As String, ByVal modified_user As String) As MessageHelper
            Dim uCCJob As BusinessService.UCCJob = New BusinessService.UCCJob()
            Return uCCJob.createJob(sub_id, site_id, bidHeader_ID, priorSchedule, job_description, notes, start_date, end_date, pay_basis, bill_amount, sub_pay, schedule_amount, status, cancel_reason, create_user, modified_user)
        End Function

        Public Function getAllActiveAreas() As SqlDataReader
            Return Area.getAllActiveAreas()
        End Function

        Public Function getJobById(ByVal job_id As Integer) As SqlDataReader
            Return (New UCCJob()).getJobById(job_id)
        End Function

        Public Function getJobOrphans(ByVal priorSchedule As Integer) As DataSet
            Return (New Job()).getJobOrphans(priorSchedule)
        End Function

        Public Function getSubcontractorSchedule(ByVal area As Integer, ByVal areaText As String, ByVal begin_date As DateTime, ByVal end_date As DateTime, ByVal suDate As DateTime, ByVal moDate As DateTime, ByVal tuDate As DateTime, ByVal weDate As DateTime, ByVal thDate As DateTime, ByVal frDate As DateTime, ByVal saDate As DateTime) As BusinessService.ScheduleView
            Dim scheduleView As BusinessService.ScheduleView = New BusinessService.ScheduleView()
            scheduleView.getSchedule(area, areaText, begin_date, end_date, suDate, moDate, tuDate, weDate, thDate, frDate, saDate)
            Return scheduleView
        End Function

        Public Function updateJob(ByVal job_id As Integer, ByVal site_id As Integer, ByVal sub_id As Integer, ByVal priorSchedule As Integer, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal modified_user As String, ByVal modified_date As DateTime, ByVal status As String, ByVal cancel_reason As String, ByVal schedule_amount As Decimal) As MessageHelper
            Dim uCCJob As BusinessService.UCCJob = New BusinessService.UCCJob()
            Return uCCJob.updateJobSchedule(job_id, site_id, sub_id, priorSchedule, start_date, end_date, modified_user, modified_date, status, cancel_reason, schedule_amount)
        End Function
    End Class
End Namespace