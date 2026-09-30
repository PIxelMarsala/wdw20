Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class SubcontractorDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function countSubActiveJobs(ByVal sub_id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub_ID", sub_id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "CountSubActiveJobs", sqlParameter)
        End Function

        Public Function countSubNickName(ByVal nick_name As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Nick_Name", nick_name)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "CountSubByNickName", sqlParameter)
        End Function

        Public Function deleteSubcontractorArea(ByRef tran As TransactionContext, ByVal Sub_ID As Integer) As Integer
            Dim sqlTransaction As System.Data.SqlClient.SqlTransaction = tran.tran
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub_ID", Sub_ID)}
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(sqlTransaction, CommandType.StoredProcedure, "DeleteSubcontractorArea", sqlParameter))
            Return num
        End Function

        Public Function getActiveSubs() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetActiveSubs")
        End Function

        Public Function getActiveSubsByArea(ByVal area As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Area_ID", area)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetActiveSubsByArea", sqlParameter)
        End Function

        Public Shared Function getSubByAltPhone(ByVal alt_phone As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Alt_Phone", alt_phone)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSubByAltPhone", sqlParameter)
        End Function

        Public Shared Function getSubById(ByVal sub_ID As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub_ID", sub_ID)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSubById", sqlParameter)
        End Function

        Public Shared Function getSubcontractorByAltPhone(ByVal alt_phone As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Alt_Phone", alt_phone)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSubByAltPhone", sqlParameter)
        End Function

        Public Function getSubcontractorByLastName(ByVal lastName As String) As SqlDataReader
            Dim str As String = lastName.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Last_Name", str1)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSubByLastName", sqlParameter)
        End Function

        Public Function getSubcontractorByNickName(ByVal nickName As String) As SqlDataReader
            Dim str As String = nickName.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Nick_Name", str1)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSubByNickName", sqlParameter)
        End Function

        Public Shared Function getSubcontractorByPrimaryPhone(ByVal primary_phone As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Phone_No", primary_phone)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSubByPrimaryPhone", sqlParameter)
        End Function

        Public Function getSubcontractorsAreas(ByVal sub_id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub_ID", sub_id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSubsAreas", sqlParameter)
        End Function

        Public Function getSubcontractorsAvailableAreas(ByVal sub_id As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub_ID", sub_id)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetSubsAvailAreas", sqlParameter)
        End Function

        Public Function isrtSubcontractor(ByRef tran As TransactionContext, ByVal ParentSub_ID As Integer, ByVal Company_Name As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Nick_Name As String, ByVal TID As String, ByVal UBI As String, ByVal Contact_Name As String, ByVal Phone_No As String, ByVal Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal E_Mail As String, ByVal dollarMaxAmount As Integer, ByVal Mon_AM As Integer, ByVal Mon_PM As Integer, ByVal Tue_AM As Integer, ByVal Tue_PM As Integer, ByVal Wed_AM As Integer, ByVal Wed_PM As Integer, ByVal Thu_AM As Integer, ByVal Thu_PM As Integer, ByVal Fri_AM As Integer, ByVal Fri_PM As Integer, ByVal Sat_AM As Integer, ByVal Sat_PM As Integer, ByVal Sun_AM As Integer, ByVal Sun_PM As Integer, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String, ByVal Height As String, ByVal Gutters As Integer, ByVal PwrWash As Integer, ByVal NewConst As Integer, ByVal SpouseName As String, ByVal Notes As String, ByVal PrimaryAddressID As Integer, ByVal AlternateAddressID As Integer) As Integer
            Dim sqlParameter(38) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@ParentSub_ID", 8)
            If (ParentSub_ID <> 0) Then
                sqlParameter(0).Value=(ParentSub_ID)
            Else
                sqlParameter(0).Value=(DBNull.Value)
            End If
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Company_Name", 22)
            sqlParameter(1).Value=(Company_Name)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@First_Name", 22)
            sqlParameter(2).Value=(First_Name)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Last_Name", 22)
            sqlParameter(3).Value=(Last_Name)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Nick_Name", 22)
            sqlParameter(4).Value=(Nick_Name)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@TID", 22)
            sqlParameter(5).Value=(TID)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@UBI", 22)
            sqlParameter(6).Value=(UBI)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Contact_Name", 22)
            sqlParameter(7).Value=(Contact_Name)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Phone_No", 22)
            sqlParameter(8).Value=(Phone_No)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Phone_Type", 3)
            sqlParameter(9).Value=(Phone_Type)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Alt_Phone", 22)
            sqlParameter(10).Value=(Alt_Phone)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Alt_Phone_Type", 3)
            sqlParameter(11).Value=(Alt_Phone_Type)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@E_Mail", 22)
            sqlParameter(12).Value=(E_Mail)
            sqlParameter(13) = New System.Data.SqlClient.SqlParameter("@dollarMaxAmount", 8)
            sqlParameter(13).Value=(dollarMaxAmount)
            sqlParameter(14) = New System.Data.SqlClient.SqlParameter("@Mon_AM", 8)
            sqlParameter(14).Value=(Mon_AM)
            sqlParameter(15) = New System.Data.SqlClient.SqlParameter("@Mon_PM", 8)
            sqlParameter(15).Value=(Mon_PM)
            sqlParameter(16) = New System.Data.SqlClient.SqlParameter("@Tues_AM", 8)
            sqlParameter(16).Value=(Tue_AM)
            sqlParameter(17) = New System.Data.SqlClient.SqlParameter("@Tues_PM", 8)
            sqlParameter(17).Value=(Tue_PM)
            sqlParameter(18) = New System.Data.SqlClient.SqlParameter("@Wed_AM", 8)
            sqlParameter(18).Value=(Wed_AM)
            sqlParameter(19) = New System.Data.SqlClient.SqlParameter("@Wed_PM", 8)
            sqlParameter(19).Value=(Wed_PM)
            sqlParameter(20) = New System.Data.SqlClient.SqlParameter("@Th_AM", 8)
            sqlParameter(20).Value=(Thu_AM)
            sqlParameter(21) = New System.Data.SqlClient.SqlParameter("@Th_PM", 8)
            sqlParameter(21).Value=(Thu_PM)
            sqlParameter(22) = New System.Data.SqlClient.SqlParameter("@Fri_AM", 8)
            sqlParameter(22).Value=(Fri_AM)
            sqlParameter(23) = New System.Data.SqlClient.SqlParameter("@Fri_PM", 8)
            sqlParameter(23).Value=(Fri_PM)
            sqlParameter(24) = New System.Data.SqlClient.SqlParameter("@Sat_AM", 8)
            sqlParameter(24).Value=(Sat_AM)
            sqlParameter(25) = New System.Data.SqlClient.SqlParameter("@Sat_PM", 8)
            sqlParameter(25).Value=(Sat_PM)
            sqlParameter(26) = New System.Data.SqlClient.SqlParameter("@Sun_AM", 8)
            sqlParameter(26).Value=(Sun_AM)
            sqlParameter(27) = New System.Data.SqlClient.SqlParameter("@Sun_PM", 8)
            sqlParameter(27).Value=(Sun_PM)
            sqlParameter(28) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(28).Value=(Active)
            sqlParameter(29) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(29).Value=(Create_User)
            sqlParameter(30) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(30).Value=(Modified_User)
            sqlParameter(31) = New System.Data.SqlClient.SqlParameter("@Height", 8)
            sqlParameter(31).Value=(Height)
            sqlParameter(32) = New System.Data.SqlClient.SqlParameter("@Gutters", 8)
            sqlParameter(32).Value=(Gutters)
            sqlParameter(33) = New System.Data.SqlClient.SqlParameter("@PwrWash", 8)
            sqlParameter(33).Value=(PwrWash)
            sqlParameter(34) = New System.Data.SqlClient.SqlParameter("@NewConst", 8)
            sqlParameter(34).Value=(NewConst)
            sqlParameter(35) = New System.Data.SqlClient.SqlParameter("@Spouse_Name", 22)
            sqlParameter(35).Value=(SpouseName)
            sqlParameter(36) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(36).Value=(Notes)
            sqlParameter(37) = New System.Data.SqlClient.SqlParameter("@PrimaryAddress_ID", 8)
            If (PrimaryAddressID <> 0) Then
                sqlParameter(37).Value=(PrimaryAddressID)
            Else
                sqlParameter(37).Value=(DBNull.Value)
            End If
            sqlParameter(38) = New System.Data.SqlClient.SqlParameter("@AlternateAddress_ID", 8)
            If (AlternateAddressID <> 0) Then
                sqlParameter(38).Value=(AlternateAddressID)
            Else
                sqlParameter(38).Value=(DBNull.Value)
            End If
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtSubcontractor", sqlParameter))
            Return num
        End Function

        Public Function isrtSubcontractorArea(ByRef tran As TransactionContext, ByVal Sub_ID As Integer, ByVal Area_ID As Integer, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub_ID", 8), Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(Sub_ID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Area_ID", 8)
            sqlParameter(1).Value=(Area_ID)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(2).Value=(Active)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(3).Value=(Create_User)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(4).Value=(Modified_User)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtSubcontractorArea", sqlParameter))
            Return num
        End Function

        Public Function updtSubcontractorAll(ByRef tran As TransactionContext, ByVal Sub_ID As Integer, ByVal ParentSub_ID As Integer, ByVal Company_Name As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Nick_Name As String, ByVal TID As String, ByVal UBI As String, ByVal Contact_Name As String, ByVal Phone_No As String, ByVal Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal E_Mail As String, ByVal dollarMaxAmount As Integer, ByVal Mon_AM As Integer, ByVal Mon_PM As Integer, ByVal Tue_AM As Integer, ByVal Tue_PM As Integer, ByVal Wed_AM As Integer, ByVal Wed_PM As Integer, ByVal Thu_AM As Integer, ByVal Thu_PM As Integer, ByVal Fri_AM As Integer, ByVal Fri_PM As Integer, ByVal Sat_AM As Integer, ByVal Sat_PM As Integer, ByVal Sun_AM As Integer, ByVal Sun_PM As Integer, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime, ByVal Height As String, ByVal Gutters As Integer, ByVal PwrWash As Integer, ByVal NewConst As Integer, ByVal SpouseName As String, ByVal Notes As String, ByVal PrimaryAddressID As Integer, ByVal AlternateAddressID As Integer) As Integer
            Dim sqlParameter(39) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@Sub_ID", 8)
            sqlParameter(0).Value=(Sub_ID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@ParentSub_ID", 8)
            If (ParentSub_ID <> 0) Then
                sqlParameter(1).Value=(ParentSub_ID)
            Else
                sqlParameter(1).Value=(DBNull.Value)
            End If
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Company_Name", 22)
            sqlParameter(2).Value=(Company_Name)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@First_Name", 22)
            sqlParameter(3).Value=(First_Name)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Last_Name", 22)
            sqlParameter(4).Value=(Last_Name)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Nick_Name", 22)
            sqlParameter(5).Value=(Nick_Name)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@TID", 22)
            sqlParameter(6).Value=(TID)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@UBI", 22)
            sqlParameter(7).Value=(UBI)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Contact_Name", 22)
            sqlParameter(8).Value=(Contact_Name)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Phone_No", 22)
            sqlParameter(9).Value=(Phone_No)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Phone_Type", 3)
            sqlParameter(10).Value=(Phone_Type)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Alt_Phone", 22)
            sqlParameter(11).Value=(Alt_Phone)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Alt_Phone_Type", 3)
            sqlParameter(12).Value=(Alt_Phone_Type)
            sqlParameter(13) = New System.Data.SqlClient.SqlParameter("@E_Mail", 22)
            sqlParameter(13).Value=(E_Mail)
            sqlParameter(14) = New System.Data.SqlClient.SqlParameter("@dollarMaxAmount", 8)
            sqlParameter(14).Value=(dollarMaxAmount)
            sqlParameter(15) = New System.Data.SqlClient.SqlParameter("@Mon_AM", 8)
            sqlParameter(15).Value=(Mon_AM)
            sqlParameter(16) = New System.Data.SqlClient.SqlParameter("@Mon_PM", 8)
            sqlParameter(16).Value=(Mon_PM)
            sqlParameter(17) = New System.Data.SqlClient.SqlParameter("@Tues_AM", 8)
            sqlParameter(17).Value=(Tue_AM)
            sqlParameter(18) = New System.Data.SqlClient.SqlParameter("@Tues_PM", 8)
            sqlParameter(18).Value=(Tue_PM)
            sqlParameter(19) = New System.Data.SqlClient.SqlParameter("@Wed_AM", 8)
            sqlParameter(19).Value=(Wed_AM)
            sqlParameter(20) = New System.Data.SqlClient.SqlParameter("@Wed_PM", 8)
            sqlParameter(20).Value=(Wed_PM)
            sqlParameter(21) = New System.Data.SqlClient.SqlParameter("@Th_AM", 8)
            sqlParameter(21).Value=(Thu_AM)
            sqlParameter(22) = New System.Data.SqlClient.SqlParameter("@Th_PM", 8)
            sqlParameter(22).Value=(Thu_PM)
            sqlParameter(23) = New System.Data.SqlClient.SqlParameter("@Fri_AM", 8)
            sqlParameter(23).Value=(Fri_AM)
            sqlParameter(24) = New System.Data.SqlClient.SqlParameter("@Fri_PM", 8)
            sqlParameter(24).Value=(Fri_PM)
            sqlParameter(25) = New System.Data.SqlClient.SqlParameter("@Sat_AM", 8)
            sqlParameter(25).Value=(Sat_AM)
            sqlParameter(26) = New System.Data.SqlClient.SqlParameter("@Sat_PM", 8)
            sqlParameter(26).Value=(Sat_PM)
            sqlParameter(27) = New System.Data.SqlClient.SqlParameter("@Sun_AM", 8)
            sqlParameter(27).Value=(Sun_AM)
            sqlParameter(28) = New System.Data.SqlClient.SqlParameter("@Sun_PM", 8)
            sqlParameter(28).Value=(Sun_PM)
            sqlParameter(29) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(29).Value=(Active)
            sqlParameter(30) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(30).Value=(Modified_User)
            sqlParameter(31) = New System.Data.SqlClient.SqlParameter("@Modified_Date", 4)
            sqlParameter(31).Value=(Modified_Date)
            sqlParameter(32) = New System.Data.SqlClient.SqlParameter("@Height", 8)
            sqlParameter(32).Value=(Height)
            sqlParameter(33) = New System.Data.SqlClient.SqlParameter("@Gutters", 8)
            sqlParameter(33).Value=(Gutters)
            sqlParameter(34) = New System.Data.SqlClient.SqlParameter("@PwrWash", 8)
            sqlParameter(34).Value=(PwrWash)
            sqlParameter(35) = New System.Data.SqlClient.SqlParameter("@NewConst", 8)
            sqlParameter(35).Value=(NewConst)
            sqlParameter(36) = New System.Data.SqlClient.SqlParameter("@Spouse_Name", 22)
            sqlParameter(36).Value=(SpouseName)
            sqlParameter(37) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(37).Value=(Notes)
            sqlParameter(38) = New System.Data.SqlClient.SqlParameter("@PrimaryAddress_ID", 8)
            If (PrimaryAddressID <> 0) Then
                sqlParameter(38).Value=(PrimaryAddressID)
            Else
                sqlParameter(38).Value=(DBNull.Value)
            End If
            sqlParameter(39) = New System.Data.SqlClient.SqlParameter("@AlternateAddress_ID", 8)
            If (AlternateAddressID <> 0) Then
                sqlParameter(39).Value=(AlternateAddressID)
            Else
                sqlParameter(39).Value=(DBNull.Value)
            End If
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdtSubcontractorAll", sqlParameter)
            Return num
        End Function
    End Class
End Namespace