Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class SiteDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getSiteByAddress1(ByVal address1 As String) As SqlDataReader
            Dim str As String = address1.Replace("..", "%")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Address1", str)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSiteByAddress1", sqlParameter)
        End Function

        Public Function getSiteByBillClient(ByVal billClient As String) As SqlDataReader
            Dim str As String = billClient.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BillClient", str1)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSiteByBillClient", sqlParameter)
        End Function

        Public Function getSiteById(ByVal Site_id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Site_ID", Site_id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSiteById", sqlParameter)
        End Function

        Public Function getSiteByOccClient(ByVal occClient As String) As SqlDataReader
            Dim str As String = occClient.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@OccClient", str1)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSiteByOccClient", sqlParameter)
        End Function

        Public Function isrtSite(ByRef tran As TransactionContext, ByVal OccClient_ID As Integer, ByVal BillClient_ID As Integer, ByVal SiteAddress_ID As Integer, ByVal No_Stories As Integer, ByVal Note_Type As Integer, ByVal Notes As String, ByVal Source As String, ByVal CBMethod As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@OccClient_ID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            If (OccClient_ID <> 0) Then
                sqlParameter(0).Value=(OccClient_ID)
            Else
                sqlParameter(0).Value=(DBNull.Value)
            End If
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@BillClient_ID", 8)
            If (BillClient_ID <> 0) Then
                sqlParameter(1).Value=(BillClient_ID)
            Else
                sqlParameter(1).Value=(DBNull.Value)
            End If
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@SiteAddress_ID", 8)
            If (SiteAddress_ID <> 0) Then
                sqlParameter(2).Value=(SiteAddress_ID)
            Else
                sqlParameter(2).Value=(DBNull.Value)
            End If
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@No_Stories", 8)
            sqlParameter(3).Value=(No_Stories)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Note_Type", 8)
            sqlParameter(4).Value=(Note_Type)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(5).Value=(Notes)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Source", 22)
            sqlParameter(6).Value=(Source)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@CallBack_Method", 22)
            sqlParameter(7).Value=(CBMethod)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(8).Value=(Active)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(9).Value=(Create_User)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(10).Value=(Modified_User)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtSite", sqlParameter))
            Return num
        End Function

        Public Function updtSiteAll(ByRef tran As TransactionContext, ByVal Site_ID As Integer, ByVal OccClient_ID As Integer, ByVal BillClient_ID As Integer, ByVal SiteAddress_ID As Integer, ByVal No_Stories As Integer, ByVal Note_Type As Integer, ByVal Notes As String, ByVal Source As String, ByVal CBMethod As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As Integer
            Dim sqlParameter(11) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@Site_ID", 8)
            sqlParameter(0).Value=(Site_ID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@OccClient_ID", 8)
            If (OccClient_ID <> 0) Then
                sqlParameter(1).Value=(OccClient_ID)
            Else
                sqlParameter(1).Value=(DBNull.Value)
            End If
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@BillClient_ID", 8)
            If (BillClient_ID <> 0) Then
                sqlParameter(2).Value=(BillClient_ID)
            Else
                sqlParameter(2).Value=(DBNull.Value)
            End If
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@SiteAddress_ID", 8)
            If (SiteAddress_ID <> 0) Then
                sqlParameter(3).Value=(SiteAddress_ID)
            Else
                sqlParameter(3).Value=(DBNull.Value)
            End If
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@No_Stories", 8)
            sqlParameter(4).Value=(No_Stories)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Note_Type", 8)
            sqlParameter(5).Value=(Note_Type)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(6).Value=(Notes)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Source", 22)
            sqlParameter(7).Value=(Source)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@CallBack_Method", 22)
            sqlParameter(8).Value=(CBMethod)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(9).Value=(Active)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(10).Value=(Modified_User)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Modified_Date", 4)
            sqlParameter(11).Value=(Modified_Date)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdtSiteAll", sqlParameter)
            Return num
        End Function
    End Class
End Namespace