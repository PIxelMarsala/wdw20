Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class JobDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function countJobBySiteId(ByVal site_id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Site_ID", site_id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "CountJobBySiteId", sqlParameter)
        End Function

        Public Function countJobBySiteIdDate(ByVal site_id As Integer, ByVal yy As Integer, ByVal mm As Integer, ByVal dd As Integer) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Site_ID", 8), Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(site_id)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@YearIn", 8)
            sqlParameter(1).Value=(yy)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@MonthIn", 8)
            sqlParameter(2).Value=(mm)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@DayIn", 8)
            sqlParameter(3).Value=(dd)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "CountJobBySiteIdDate", sqlParameter)
        End Function

        Public Function countJobBySiteIdStatus(ByVal site_id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Site_ID", site_id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "CountJobBySiteIdStatus", sqlParameter)
        End Function

        Public Function countJobBySubStartDate(ByVal sub_id As Integer, ByVal start_date As DateTime) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub_ID", 8), Nothing}
            sqlParameter(0).Value=(sub_id)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Start_Date", 4)
            sqlParameter(1).Value=(start_date)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "CountJobBySubStartDate", sqlParameter)
        End Function

        Public Function countJobWithBalanceDueBySite(ByVal site_id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Site_ID", site_id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "CountJobWithBalanceDueBySite", sqlParameter)
        End Function

        Public Shared Function getJobByAlternatePhone(ByVal alternatePhone As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Alt_Phone", alternatePhone)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetJobByAltPhone", sqlParameter)
        End Function

        Public Shared Function getJobByClientID(ByVal client_Id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Client_ID", client_Id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetJobByClientID", sqlParameter)
        End Function

        Public Shared Function getJobById(ByVal job_ID As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Job_ID", job_ID)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetJobByID", sqlParameter)
        End Function

        Public Shared Function getJobByLastName(ByVal lastName As String) As SqlDataReader
            Dim str As String = lastName.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Last_Name", str1)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetJobByLastName", sqlParameter)
        End Function

        Public Shared Function getJobByPrimaryPhone(ByVal primaryPhone As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Primary_Phone", primaryPhone)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetJobByPrimaryPhone", sqlParameter)
        End Function

        Public Function getJobBySub(ByVal sub_Id As Integer, ByVal begin_date As DateTime, ByVal end_date As DateTime) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub_ID", 8), Nothing, Nothing}
            sqlParameter(0).Value=(sub_Id)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@begin_date", 4)
            sqlParameter(1).Value=(begin_date)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@end_date", 4)
            sqlParameter(2).Value=(end_date)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetJobBySub", sqlParameter)
        End Function

        Public Function getJobBySubByDateRange(ByVal begin_date As DateTime, ByVal end_date As DateTime) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@begin_date", 4), Nothing}
            sqlParameter(0).Value=(begin_date)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@end_date", 4)
            sqlParameter(1).Value=(end_date)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetJobBySubByDateRange", sqlParameter)
        End Function

        Public Function getJobOrphans(ByVal priorSchedule As Integer) As DataSet
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@priorSchedule", priorSchedule)}
            Return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetJobOrphans", sqlParameter)
        End Function

        Public Function isrtJob(ByRef tran As TransactionContext, ByVal sub_id As Integer, ByVal site_id As Integer, ByVal bidHeader_ID As Integer, ByVal priorSchedule As Integer, ByVal job_description As String, ByVal notes As String, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal pay_basis As Decimal, ByVal bill_amount As Decimal, ByVal sub_pay As Decimal, ByVal schedule_amount As Decimal, ByVal status As String, ByVal cancel_reason As String, ByVal create_user As String, ByVal modified_user As String) As Integer
            Dim sqlParameter(15) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@Sub_ID", 8)
            If (sub_id <> 0) Then
                sqlParameter(0).Value=(sub_id)
            Else
                sqlParameter(0).Value=(DBNull.Value)
            End If
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Site_ID", 8)
            sqlParameter(1).Value=(site_id)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@BidHeader_ID", 8)
            If (bidHeader_ID <> 0) Then
                sqlParameter(2).Value=(bidHeader_ID)
            Else
                sqlParameter(2).Value=(DBNull.Value)
            End If
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Prior_Schedule", 20)
            sqlParameter(3).Value=(priorSchedule)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Job_Description", 22)
            sqlParameter(4).Value=(job_description)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(5).Value=(notes)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Start_Date", 4)
            sqlParameter(6).Value=(start_date)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@End_Date", 4)
            sqlParameter(7).Value=(end_date)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Pay_Basis", 9)
            sqlParameter(8).Value=(pay_basis)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Bill_Amount", 9)
            sqlParameter(9).Value=(bill_amount)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Sub_Pay", 9)
            sqlParameter(10).Value=(sub_pay)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Schedule_Amount", 9)
            sqlParameter(11).Value=(schedule_amount)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Status", 3)
            sqlParameter(12).Value=(status)
            sqlParameter(13) = New System.Data.SqlClient.SqlParameter("@Cancel_Reason", 3)
            sqlParameter(13).Value=(cancel_reason)
            sqlParameter(14) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(14).Value=(create_user)
            sqlParameter(15) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(15).Value=(modified_user)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtJob", sqlParameter))
            Return num
        End Function

        Public Function updateJob(ByRef tran As TransactionContext, ByVal job_id As Integer, ByVal sub_id As Integer, ByVal priorSchedule As Integer, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal modified_user As String, ByVal modified_date As DateTime, ByVal status As String, ByVal cancel_reason As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Job_ID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(job_id)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Sub_ID", 8)
            If (sub_id <> 0) Then
                sqlParameter(1).Value=(sub_id)
            Else
                sqlParameter(1).Value=(DBNull.Value)
            End If
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Prior_Schedule", 20)
            sqlParameter(2).Value=(priorSchedule)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Start_Date", 4)
            sqlParameter(3).Value=(start_date)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@End_Date", 4)
            sqlParameter(4).Value=(end_date)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(5).Value=(modified_user)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Modified_Date", 4)
            sqlParameter(6).Value=(modified_date)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Status", 22)
            sqlParameter(7).Value=(status)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Cancel_Reason", 22)
            sqlParameter(8).Value=(cancel_reason)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdtJob", sqlParameter)
            Return num
        End Function

        Public Function updateJobAll(ByRef tran As TransactionContext, ByVal job_id As Integer, ByVal sub_id As Integer, ByVal bidHeader_ID As Integer, ByVal reminder As Integer, ByVal critical As Integer, ByVal priorSchedule As Integer, ByVal job_Description As String, ByVal notes As String, ByVal start_date As DateTime, ByVal end_date As DateTime, ByVal outside_only As Integer, ByVal pay_basis As Decimal, ByVal bill_amount As Decimal, ByVal sub_pay As Decimal, ByVal schedule_amount As Decimal, ByVal payment_method As String, ByVal status As String, ByVal cancel_reason As String, ByVal create_user As String, ByVal create_date As DateTime, ByVal modified_user As String, ByVal modified_date As DateTime) As Integer
            Dim sqlParameter(21) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@Job_ID", 8)
            sqlParameter(0).Value=(job_id)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Sub_ID", 8)
            If (sub_id <> 0) Then
                sqlParameter(1).Value=(sub_id)
            Else
                sqlParameter(1).Value=(DBNull.Value)
            End If
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@BidHeader_ID", 8)
            If (bidHeader_ID <> 0) Then
                sqlParameter(2).Value=(bidHeader_ID)
            Else
                sqlParameter(2).Value=(DBNull.Value)
            End If
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Reminder", 20)
            sqlParameter(3).Value=(reminder)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Critical", 20)
            sqlParameter(4).Value=(critical)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Prior_Schedule", 20)
            sqlParameter(5).Value=(priorSchedule)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Job_Description", 22)
            sqlParameter(6).Value=(job_Description)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(7).Value=(notes)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Start_Date", 4)
            sqlParameter(8).Value=(start_date)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@End_Date", 4)
            sqlParameter(9).Value=(end_date)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Outside_Only", 8)
            sqlParameter(10).Value=(outside_only)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Pay_Basis", 9)
            sqlParameter(11).Value=(pay_basis)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Bill_Amount", 9)
            sqlParameter(12).Value=(bill_amount)
            sqlParameter(13) = New System.Data.SqlClient.SqlParameter("@Sub_Pay", 9)
            sqlParameter(13).Value=(sub_pay)
            sqlParameter(14) = New System.Data.SqlClient.SqlParameter("@Schedule_Amount", 9)
            sqlParameter(14).Value=(schedule_amount)
            sqlParameter(15) = New System.Data.SqlClient.SqlParameter("@Payment_Method", 3)
            sqlParameter(15).Value=(payment_method)
            sqlParameter(16) = New System.Data.SqlClient.SqlParameter("@Status", 3)
            sqlParameter(16).Value=(status)
            sqlParameter(17) = New System.Data.SqlClient.SqlParameter("@Cancel_Reason", 3)
            sqlParameter(17).Value=(cancel_reason)
            sqlParameter(18) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(18).Value=(create_user)
            sqlParameter(19) = New System.Data.SqlClient.SqlParameter("@Create_Date", 4)
            sqlParameter(19).Value=(create_date)
            sqlParameter(20) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(20).Value=(modified_user)
            sqlParameter(21) = New System.Data.SqlClient.SqlParameter("@Modified_Date", 4)
            sqlParameter(21).Value=(modified_date)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdtJobAll", sqlParameter)
            Return num
        End Function
    End Class
End Namespace