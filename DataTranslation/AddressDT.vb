Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient


Namespace DataTranslation
    Public Class AddressDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getAddressByAddressLine1(ByVal addr1 As String) As SqlDataReader
            Dim str As String = addr1.Replace("..", "%")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@searchCriteria", str)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetAddressByAddressLine1", sqlParameter)
        End Function

        Public Function getAddressByAddressLine2(ByVal addr2 As String) As SqlDataReader
            Dim str As String = addr2.Replace("..", "%")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@searchCriteria", str)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetAddressByAddressLine2", sqlParameter)
        End Function

        Public Function getAddressByCareOf(ByVal CareOf As String) As SqlDataReader
            Dim str As String = CareOf.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@CareOf", str1)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetAddressByCareOf", sqlParameter)
        End Function

        Public Function getAddressById(ByVal Address_id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Address_ID", Address_id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetAddressById", sqlParameter)
        End Function

        Public Shared Function getAreaZip() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.ConnectionString, CommandType.StoredProcedure, "GetAreaZip")
        End Function

        Public Shared Function getBillingAddressByAddressLine1(ByVal searchCriteria As String) As SqlDataReader
            Dim str As String = searchCriteria.Replace("..", "%")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@searchCriteria", str)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetBillingAddressByAddressLine1", sqlParameter)
        End Function

        Public Shared Function getJobByAddressLine1(ByVal searchCriteria As String) As SqlDataReader
            Dim str As String = searchCriteria.Replace("..", "%")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@searchCriteria", str)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetJobByAddressLine1", sqlParameter)
        End Function

        Public Function isrtAddress(ByRef tran As TransactionContext, ByVal CareOF As String, ByVal Address1 As String, ByVal Address2 As String, ByVal Address3 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal ZipCode As String, ByVal Country As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As Integer
            Dim sqlParameter(11) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@CareOf", 22)
            sqlParameter(0).Value = (CareOF)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Address1", 22)
            sqlParameter(1).Value = (Address1)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Address2", 22)
            sqlParameter(2).Value = (Address2)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Address3", 22)
            sqlParameter(3).Value = (Address3)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@City", 22)
            sqlParameter(4).Value = (City)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@County", 22)
            sqlParameter(5).Value = (County)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@State", 22)
            sqlParameter(6).Value = (State)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@ZipCode", 22)
            sqlParameter(7).Value = (ZipCode)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Country", 22)
            sqlParameter(8).Value = (Country)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(9).Value = (Active)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(10).Value = (Create_User)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(11).Value = (Modified_User)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtAddress", sqlParameter))
            Return num
        End Function

        Public Function updtAddressAll(ByRef tran As TransactionContext, ByVal Address_ID As Integer, ByVal CareOF As String, ByVal Address1 As String, ByVal Address2 As String, ByVal Address3 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal ZipCode As String, ByVal Country As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As Integer
            Dim sqlParameter(12) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@Address_ID", 8)
            sqlParameter(0).Value = (Address_ID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@CareOf", 22)
            sqlParameter(1).Value = (CareOF)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Address1", 22)
            sqlParameter(2).Value = (Address1)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Address2", 22)
            sqlParameter(3).Value = (Address2)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Address3", 22)
            sqlParameter(4).Value = (Address3)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@City", 22)
            sqlParameter(5).Value = (City)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@County", 22)
            sqlParameter(6).Value = (County)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@State", 22)
            sqlParameter(7).Value = (State)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@ZipCode", 22)
            sqlParameter(8).Value = (ZipCode)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Country", 22)
            sqlParameter(9).Value = (Country)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(10).Value = (Active)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(11).Value = (Modified_User)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Modified_Date", 4)
            sqlParameter(12).Value = (Modified_Date)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdtAddressAll", sqlParameter)
            Return num
        End Function
    End Class
End Namespace