Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class OperatorDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getOperatorByCompanyUserId(ByVal companyId As Integer, ByVal userId As String) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@company_ID", 8), Nothing}
            sqlParameter(0).Value=(companyId)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@userId", 22)
            sqlParameter(1).Value=(userId)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetOperatorByCompanyUserId", sqlParameter)
        End Function

        Public Function getOperatorByLastName(ByVal lastname As String) As SqlDataReader
            Dim str As String = lastname.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Last_Name", 22)}
            sqlParameter(0).Value=(str1)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetOperatorByLastName", sqlParameter)
        End Function

        Public Function getOperatorByOperatorId(ByVal operatorId As Integer) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Operator_ID", 8)}
            sqlParameter(0).Value=(operatorId)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetOperatorByOperatorId", sqlParameter)
        End Function

        Public Function getOperatorByUserId(ByVal userId As String) As SqlDataReader
            Dim str As String = userId.Replace("..", "%")
            Dim str1 As String = str.Replace(".", "_")
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@userId", 22)}
            sqlParameter(0).Value=(str1)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetOperatorByUserId", sqlParameter)
        End Function

        Public Function isrtOperator(ByVal tran As TransactionContext, ByVal User_ID As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Password As String, ByVal DefaultScheduleArea_ID As Integer, ByVal DefaultRole_ID As Integer, ByVal DefaultApp_Function_ID As Integer, ByVal Company_ID As Integer, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As Integer
            Dim sqlParameter(11) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@UserId", 22)
            sqlParameter(0).Value=(User_ID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@password", 22)
            sqlParameter(1).Value=(Password)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@First_Name", 22)
            sqlParameter(2).Value=(First_Name)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Last_Name", 22)
            sqlParameter(3).Value=(Last_Name)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@DefaultScheduleArea", 8)
            sqlParameter(4).Value=(DefaultScheduleArea_ID)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@DefaultTelephoneArea", 22)
            sqlParameter(5).Value=(0)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@DefaultApp_Function_ID", 8)
            sqlParameter(6).Value=(DefaultApp_Function_ID)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(7).Value=(Active)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(8).Value=(Create_User)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(9).Value=(Modified_User)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Role_ID", 8)
            sqlParameter(10).Value=(DefaultRole_ID)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Company_ID", 8)
            sqlParameter(11).Value=(Company_ID)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtOperator", sqlParameter))
            Return num
        End Function

        Public Function updtOperatorAll(ByVal tran As TransactionContext, ByVal Operator_ID As Integer, ByVal User_ID As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Password As String, ByVal DefaultScheduleArea_ID As Integer, ByVal DefaultRole_ID As Integer, ByVal DefaultApp_Function_ID As Integer, ByVal Company_ID As Integer, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As Integer
            Dim sqlParameter(12) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@Operator_ID", 8)
            sqlParameter(0).Value=(Operator_ID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@UserId", 22)
            sqlParameter(1).Value=(User_ID)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Password", 22)
            sqlParameter(2).Value=(Password)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@First_Name", 22)
            sqlParameter(3).Value=(First_Name)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Last_Name", 22)
            sqlParameter(4).Value=(Last_Name)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@DefaultScheduleArea", 8)
            sqlParameter(5).Value=(DefaultScheduleArea_ID)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@DefaultTelephoneArea", 22)
            sqlParameter(6).Value=(0)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@DefaultApp_Function_ID", 8)
            sqlParameter(7).Value=(DefaultApp_Function_ID)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(8).Value=(Active)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(9).Value=(Modified_User)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Modified_Date", 4)
            sqlParameter(10).Value=(Modified_Date)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Role_ID", 8)
            sqlParameter(11).Value=(DefaultRole_ID)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Company_ID", 8)
            sqlParameter(12).Value=(Company_ID)
            Return SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdtOperator", sqlParameter)
        End Function
    End Class
End Namespace