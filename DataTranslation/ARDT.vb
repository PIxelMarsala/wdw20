Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class ARDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createAR(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pNotes As String, ByVal pNDate As DateTime, ByVal pClient As Integer, ByVal pResults As String, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@DetailID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value = (pDetail)
            sqlParameter(0).Direction = (3)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(1).Value=(pNotes)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@CBDate", 4)
            sqlParameter(2).Value=(pNDate)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Client", 8)
            sqlParameter(3).Value=(pClient)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Results", 22)
            sqlParameter(4).Value=(pResults)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(5).Value=(pCreateUser)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(6).Value=(pModifyUser)
            SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "InsrtAR", sqlParameter)
            Dim num As Integer = IntegerType.FromObject(sqlParameter(0).Value)
            If (num > 0) Then
                Return num
            End If
            Return 0
        End Function

        Public Shared Function GetAllChildAR() As SqlDataAdapter
            Return New SqlDataAdapter("getChildAR", WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function GetAllChildARByClient(ByVal pClient As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getChildARByClient ", StringType.FromInteger(pClient)), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetAllParentAR() As SqlDataAdapter
            Return New SqlDataAdapter("getParentAR", WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function GetAllParentARByClient(ByVal pClient As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getParentARByClient ", StringType.FromInteger(pClient)), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetResultCodes(ByVal pCode As String) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Code_Description", 22)}
            sqlParameter(0).Value = (pCode)
            Return SqlHelper.ExecuteReader(WDWConfiguration.ConnectionString, CommandType.StoredProcedure, "GetActiveCodesByCodeDescription", sqlParameter)
        End Function

        Public Shared Function modifyAR(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pNotes As String, ByVal pNDate As DateTime, ByVal pResults As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@DetailID", 8), Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value = (pDetail)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Notes", 22)
            sqlParameter(1).Value = (pNotes)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@CBDate", 4)
            sqlParameter(2).Value = (pNDate)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Results", 22)
            sqlParameter(3).Value = (pResults)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(4).Value = (pModifyUser)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdteAR", sqlParameter)
            Return num
        End Function

        Public Shared Function modifyARMethod(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pDate As DateTime, ByVal pPaid As Decimal, ByVal pMethod As String, ByVal pLate As Decimal, ByVal pInt As Decimal, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@DetailID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value = (pDetail)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@PDate", 15)
            sqlParameter(1).Value = (pDate)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Paid", 9)
            sqlParameter(2).Value = (pPaid)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Method", 22)
            sqlParameter(3).Value = (pMethod)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Late", 9)
            sqlParameter(4).Value = (pLate)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Int", 9)
            sqlParameter(5).Value = (pInt)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(6).Value = (pModifyUser)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdtePayMethod", sqlParameter)
            Return num
        End Function
    End Class
End Namespace