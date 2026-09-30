Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class ClientDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getClientByAltPhone(ByVal alt_phone As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Alt_Phone", alt_phone)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetClientByAltPhone", sqlParameter)
        End Function

        Public Shared Function getClientByContactName(ByVal contact_name As String) As SqlDataReader
            Dim str As String = contact_name.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Contact_Name", str1)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetClientByContactName", sqlParameter)
        End Function

        Public Shared Function getClientById(ByVal client_ID As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Client_ID", client_ID)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetClientById", sqlParameter)
        End Function

        Public Shared Function getClientByLastName(ByVal last_name As String) As SqlDataReader
            Dim str As String = last_name.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Last_Name", str1)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetClientByLastName", sqlParameter)
        End Function

        Public Shared Function getClientByPrimaryPhone(ByVal primary_phone As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Primary_Phone", primary_phone)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetClientByPrimaryPhone", sqlParameter)
        End Function

        Public Function isrtClient(ByRef tran As TransactionContext, ByVal BillAddress_ID As Integer, ByVal First_Name As String, ByVal Last_Name As String, ByVal Discount As String, ByVal Client_Type As String, ByVal COD As Integer, ByVal Spouse_Name As String, ByVal Contact_Name As String, ByVal Primary_Phone As String, ByVal Prm_Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal Acct_Type As String, ByVal Notes As String, ByVal Other1_Phone As String, ByVal Other1_Phone_Type As String, ByVal Other2_Phone As String, ByVal Other2_Phone_Type As String, ByVal E_Mail As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As Integer
            Dim sqlParameter(21) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@BillAddress_ID", 8)
            If (BillAddress_ID <> 0) Then
                sqlParameter(0).Value=(BillAddress_ID)
            Else
                sqlParameter(0).Value=(DBNull.Value)
            End If
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@First_Name", 22)
            sqlParameter(1).Value=(First_Name)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Last_Name", 22)
            sqlParameter(2).Value=(Last_Name)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Discount", 22)
            sqlParameter(3).Value=(Discount)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Client_Type", 22)
            sqlParameter(4).Value=(Client_Type)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@COD", 8)
            sqlParameter(5).Value=(COD)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Spouse_Name", 22)
            sqlParameter(6).Value=(Spouse_Name)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Contact_Name", 22)
            sqlParameter(7).Value=(Contact_Name)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Primary_Phone", 22)
            sqlParameter(8).Value=(Primary_Phone)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Prm_Phone_Type", 3)
            sqlParameter(9).Value=(Prm_Phone_Type)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Alt_Phone", 22)
            sqlParameter(10).Value=(Alt_Phone)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Alt_Phone_Type", 3)
            sqlParameter(11).Value=(Alt_Phone_Type)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Acct_Type", 3)
            sqlParameter(12).Value=(Acct_Type)
            sqlParameter(13) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(13).Value=(Notes)
            sqlParameter(14) = New System.Data.SqlClient.SqlParameter("@Other1_Phone", 22)
            sqlParameter(14).Value=(Other1_Phone)
            sqlParameter(15) = New System.Data.SqlClient.SqlParameter("@Other1_Phone_Type", 3)
            sqlParameter(15).Value=(Other1_Phone_Type)
            sqlParameter(16) = New System.Data.SqlClient.SqlParameter("@Other2_Phone", 22)
            sqlParameter(16).Value=(Other2_Phone)
            sqlParameter(17) = New System.Data.SqlClient.SqlParameter("@Other2_Phone_Type", 3)
            sqlParameter(17).Value=(Other2_Phone_Type)
            sqlParameter(18) = New System.Data.SqlClient.SqlParameter("@E_Mail", 22)
            sqlParameter(18).Value=(E_Mail)
            sqlParameter(19) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(19).Value=(Active)
            sqlParameter(20) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(20).Value=(Create_User)
            sqlParameter(21) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(21).Value=(Modified_User)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtClient", sqlParameter))
            Return num
        End Function

        Public Function updtClientAll(ByRef tran As TransactionContext, ByVal Client_ID As Integer, ByVal BillAddress_ID As Integer, ByVal First_Name As String, ByVal Last_Name As String, ByVal Discount As String, ByVal Client_Type As String, ByVal COD As Integer, ByVal Spouse_Name As String, ByVal Contact_Name As String, ByVal Primary_Phone As String, ByVal Prm_Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal Acct_Type As String, ByVal Notes As String, ByVal Other1_Phone As String, ByVal Other1_Phone_Type As String, ByVal Other2_Phone As String, ByVal Other2_Phone_Type As String, ByVal E_Mail As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As Integer
            Dim sqlParameter(22) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@Client_ID", 8)
            sqlParameter(0).Value=(Client_ID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@BillAddress_ID", 8)
            If (BillAddress_ID <> 0) Then
                sqlParameter(1).Value=(BillAddress_ID)
            Else
                sqlParameter(1).Value=(DBNull.Value)
            End If
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@First_Name", 22)
            sqlParameter(2).Value=(First_Name)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Last_Name", 22)
            sqlParameter(3).Value=(Last_Name)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Discount", 22)
            sqlParameter(4).Value=(Discount)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Client_Type", 22)
            sqlParameter(5).Value=(Client_Type)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@COD", 8)
            sqlParameter(6).Value=(COD)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Spouse_Name", 22)
            sqlParameter(7).Value=(Spouse_Name)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Contact_Name", 22)
            sqlParameter(8).Value=(Contact_Name)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Primary_Phone", 22)
            sqlParameter(9).Value=(Primary_Phone)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Prm_Phone_Type", 3)
            sqlParameter(10).Value=(Prm_Phone_Type)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Alt_Phone", 22)
            sqlParameter(11).Value=(Alt_Phone)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Alt_Phone_Type", 3)
            sqlParameter(12).Value=(Alt_Phone_Type)
            sqlParameter(13) = New System.Data.SqlClient.SqlParameter("@Acct_Type", 22)
            sqlParameter(13).Value=(Acct_Type)
            sqlParameter(14) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(14).Value=(Notes)
            sqlParameter(15) = New System.Data.SqlClient.SqlParameter("@Other1_Phone", 22)
            sqlParameter(15).Value=(Other1_Phone)
            sqlParameter(16) = New System.Data.SqlClient.SqlParameter("@Other1_Phone_Type", 3)
            sqlParameter(16).Value=(Other1_Phone_Type)
            sqlParameter(17) = New System.Data.SqlClient.SqlParameter("@Other2_Phone", 22)
            sqlParameter(17).Value=(Other2_Phone)
            sqlParameter(18) = New System.Data.SqlClient.SqlParameter("@Other2_Phone_Type", 3)
            sqlParameter(18).Value=(Other2_Phone_Type)
            sqlParameter(19) = New System.Data.SqlClient.SqlParameter("@E_Mail", 22)
            sqlParameter(19).Value=(E_Mail)
            sqlParameter(20) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(20).Value=(Active)
            sqlParameter(21) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(21).Value=(Modified_User)
            sqlParameter(22) = New System.Data.SqlClient.SqlParameter("@Modified_Date", 4)
            sqlParameter(22).Value=(Modified_Date)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdtClientAll", sqlParameter)
            Return num
        End Function
    End Class
End Namespace