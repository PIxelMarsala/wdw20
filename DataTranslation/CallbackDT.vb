Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class CallbackDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createCallback(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pNotes As String, ByVal pResult As String, ByVal pNDate As DateTime, ByVal pSite As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@DetailID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pDetail)
            sqlParameter(0).Direction=(3)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(1).Value=(pNotes)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Result", 22)
            sqlParameter(2).Value=(pResult)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@CBDate", 4)
            sqlParameter(3).Value=(pNDate)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Site", 8)
            sqlParameter(4).Value=(pSite)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(5).Value=(pCreateUser)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(6).Value = (pModifyUser)

            SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "InsrtCallBack", sqlParameter)
            Dim num As Integer = IntegerType.FromObject(sqlParameter(0).Value)
            If (num > 0) Then
                Return num
            End If
            Return 0
        End Function

        Public Shared Function createChildrecords(ByRef tran As TransactionContext, ByVal pCB As String, ByVal pFromDate As DateTime, ByVal pToDate As DateTime, ByVal pFromZip As String, ByVal pToZip As String, ByVal pLastName As String, ByVal pAddress1 As String, ByVal pCreateUser As String, ByVal pModifyUser As String, ByVal pFromStart As DateTime, ByVal pToStart As DateTime) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@CBMethod", 22), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pCB)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@FromDate", 15)
            sqlParameter(1).Value=(pFromDate)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@ToDate", 15)
            sqlParameter(2).Value=(pToDate)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@FromZip", 22)
            sqlParameter(3).Value=(pFromZip)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@ToZip", 22)
            sqlParameter(4).Value=(pToZip)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@LastName", 22)
            sqlParameter(5).Value=(pLastName)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Address1", 22)
            sqlParameter(6).Value=(pAddress1)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@CreateUser", 22)
            sqlParameter(7).Value=(pCreateUser)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@ModifyUser", 22)
            sqlParameter(8).Value=(pModifyUser)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@FromStart", 15)
            sqlParameter(9).Value=(pFromDate)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@ToStart", 15)
            sqlParameter(10).Value=(pToDate)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "CreateChildRecords", sqlParameter)
            Return num
        End Function

        Public Shared Function GetAllChildCallBack(ByVal pCB As String) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getChildCallBack ", pCB), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetAllChildCallBackByAddress(ByVal pAddress As String) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getChildCallBackByAddress '", pAddress, "'"), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetAllChildCallBackByClient(ByVal pClient As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getChildCallBackByClient ", StringType.FromInteger(pClient)), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetAllChildCallBackByDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pTo As DateTime, ByVal pFromZip As Integer, ByVal pToZip As Integer) As SqlDataAdapter
            Dim strArray() As String = {"Exec getChildCallBackByDate ", pCB, ", ", "'", StringType.FromDate(pFrom), "'", ", ", "'", StringType.FromDate(pTo), "'", ", ", StringType.FromInteger(pFromZip), ", ", StringType.FromInteger(pToZip)}
            Return New SqlDataAdapter(String.Concat(strArray), WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function GetAllChildCallBackByLName(ByVal pName As String) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getChildCallBackByLName '", pName, "'"), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetAllChildCallBackByStartDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pTo As DateTime) As SqlDataAdapter
            Dim strArray() As String = {"Exec getChildCallBackByStartDate ", pCB, ", ", "'", StringType.FromDate(pFrom), "'", ", ", "'", StringType.FromDate(pTo), "'"}
            Return New SqlDataAdapter(String.Concat(strArray), WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function GetAllParentCallBack(ByVal pCB As String) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getParentCallBack ", pCB), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetAllParentCallBackByAddress(ByVal pAddress As String) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As Object = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getParentCallBackByAddress '", pAddress, "'"), WDWConfiguration.ConnectionString)
            Return DirectCast(sqlDataAdapter, System.Data.SqlClient.SqlDataAdapter)
        End Function

        Public Shared Function GetAllParentCallBackByClient(ByVal pClient As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As Object = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getParentCallBackByClient ", StringType.FromInteger(pClient)), WDWConfiguration.ConnectionString)
            Return DirectCast(sqlDataAdapter, System.Data.SqlClient.SqlDataAdapter)
        End Function

        Public Shared Function GetAllParentCallBackByDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pTo As DateTime, ByVal pFromzip As Integer, ByVal pToZip As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim strArray() As String = {"Exec getParentCallBackByDate '", pCB, "'", ",", "'", StringType.FromDate(pFrom), "'", ",", "'", StringType.FromDate(pTo), "'", ", ", StringType.FromInteger(pFromzip), ", ", StringType.FromInteger(pToZip)}
            Dim sqlDataAdapter As Object = New System.Data.SqlClient.SqlDataAdapter(String.Concat(strArray), WDWConfiguration.ConnectionString)
            Return DirectCast(sqlDataAdapter, System.Data.SqlClient.SqlDataAdapter)
        End Function

        Public Shared Function GetAllParentCallBackByLName(ByVal pName As String) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As Object = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getParentCallBackByLName '", pName, "'"), WDWConfiguration.ConnectionString)
            Return DirectCast(sqlDataAdapter, System.Data.SqlClient.SqlDataAdapter)
        End Function

        Public Shared Function GetAllParentCallBackByStartDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pTo As DateTime) As System.Data.SqlClient.SqlDataAdapter
            Dim strArray() As String = {"Exec getParentCallBackByStartDate '", pCB, "'", ",", "'", StringType.FromDate(pFrom), "'", ",", "'", StringType.FromDate(pTo), "'"}
            Dim sqlDataAdapter As Object = New System.Data.SqlClient.SqlDataAdapter(String.Concat(strArray), WDWConfiguration.ConnectionString)
            Return DirectCast(sqlDataAdapter, System.Data.SqlClient.SqlDataAdapter)
        End Function

        Public Shared Function modifyCallBack(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pNotes As String, ByVal pResult As String, ByVal pNDate As DateTime, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@DetailID", 8), Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pDetail)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(1).Value=(pNotes)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Result", 22)
            sqlParameter(2).Value=(pResult)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@CBDate", 4)
            sqlParameter(3).Value=(pNDate)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(4).Value=(pModifyUser)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdteCallBack", sqlParameter)
            Return num
        End Function

        Public Shared Function modifyCBMethod(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pMethod As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@DetailID", 8), Nothing, Nothing}
            sqlParameter(0).Value=(pDetail)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Method", 22)
            sqlParameter(1).Value=(pMethod)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(2).Value=(pModifyUser)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdteCBMethod", sqlParameter)
            Return num
        End Function
    End Class
End Namespace