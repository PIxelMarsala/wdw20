Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class CloseOutDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createCloseOutDetail(ByRef tran As TransactionContext, ByVal pHeader As Integer, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pBillAmt As Decimal, ByVal pPayBasis As Decimal, ByVal pPayCode As String, ByVal pPayPer As Integer, ByVal pPayAmt As Decimal, ByVal pTip As Decimal, ByVal pARCode As String, ByVal pPayRecd As Decimal, ByVal pTax As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter(14) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@HeaderID", 8)
            sqlParameter(0).Value=(pHeader)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@DetailID", 8)
            sqlParameter(1).Value=(pDetail)
            sqlParameter(1).Direction=(3)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@JobNbr", 8)
            sqlParameter(2).Value=(pJobNbr)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@BillAmt", 9)
            sqlParameter(3).Value=(pBillAmt)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@PayBasis", 9)
            sqlParameter(4).Value=(pPayBasis)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@PayCode", 22)
            sqlParameter(5).Value=(pPayCode)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@PayPer", 8)
            sqlParameter(6).Value=(pPayPer)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@PayAmt", 9)
            sqlParameter(7).Value=(pPayAmt)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@Tip", 5)
            sqlParameter(8).Value=(pTip)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@ARCode", 22)
            sqlParameter(9).Value=(pARCode)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@PayRecd", 5)
            sqlParameter(10).Value=(pPayRecd)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Tax", 5)
            sqlParameter(11).Value=(pTax)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(12).Value=(pActive)
            sqlParameter(13) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(13).Value=(pCreateUser)
            sqlParameter(14) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(14).Value=(pModifyUser)
            SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "InsrtCloseOutDetail", sqlParameter)
            Dim num As Integer = IntegerType.FromObject(sqlParameter(1).Value)
            If (num > 0) Then
                Return num
            End If
            Return 0
        End Function

        Public Shared Function createCloseOutDetailCredit(ByRef tran As TransactionContext, ByVal pHeader As Integer, ByVal pDetail As Integer, ByVal pJobnbr As Integer, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@HeaderID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pHeader)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@DetailID", 8)
            sqlParameter(1).Value=(pDetail)
            sqlParameter(1).Direction=(3)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@JobNbr", 22)
            sqlParameter(2).Value=(pJobnbr)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@PayCode", 22)
            sqlParameter(3).Value=(pPayCode)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@PayAmt", 9)
            sqlParameter(4).Value=(pPayAmt)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(5).Value=(pActive)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(6).Value=(pCreateUser)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(7).Value=(pModifyUser)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "InsrtCloseOutDetailSpec", sqlParameter))
            Return num
        End Function

        Public Shared Function createCloseOutDetailSpec(ByRef tran As TransactionContext, ByVal pHeader As Integer, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@HeaderID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value = (pHeader)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@DetailID", 8)
            sqlParameter(1).Value = (pDetail)
            sqlParameter(1).Direction = (3)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@JobNbr", 8)
            sqlParameter(2).Value = (pJobNbr)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@PayCode", 22)
            sqlParameter(3).Value = (pPayCode)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@PayAmt", 9)
            sqlParameter(4).Value = (pPayAmt)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(5).Value = (pActive)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(6).Value = (pCreateUser)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(7).Value = (pModifyUser)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "InsrtCloseOutDetailSpec", sqlParameter))
            Return num
        End Function

        Public Shared Function createCloseOutHeader(ByRef tran As TransactionContext, ByVal pHeader As Integer, ByVal pSub As String, ByVal pTotal As Decimal, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@HeaderID", 8), Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pHeader)
            sqlParameter(0).Direction=(3)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Sub_ID", 22)
            sqlParameter(1).Value=(pSub)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Total", 5)
            sqlParameter(2).Value=(pTotal)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(3).Value=(pCreateUser)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(4).Value=(pModifyUser)
            SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "InsrtCloseOutHeader", sqlParameter)
            Dim num As Integer = IntegerType.FromObject(sqlParameter(0).Value)
            If (num > 0) Then
                Return num
            End If
            Return 0
        End Function

        Public Shared Function GetAllChildCloseOutBySub(ByVal pSub As String) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub", 22)}
            sqlParameter(0).Value=(pSub)
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getAllChildCloseOutBySub ", pSub), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetAllParentCloseOutBySub(ByVal pSub As String) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Sub", 22)}
            If pSub = "ALL" Then pSub = "'ALL'" ' need to add quote for the "ALL" Keyword
            sqlParameter(0).Value=(pSub)
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec getParentCloseOutBySub ", pSub), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function GetARCodes(ByVal pCode As String) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Code_Description", 22)}
            sqlParameter(0).Value=(pCode)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetActiveCodesByCodeDescription", sqlParameter)
        End Function

        Public Shared Function getExistingChildCOBySub(ByVal pDAte As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@CloseoutHeader_ID", 8)}
            sqlParameter(0).Value=(pDAte)
            Dim sqlDataAdapter As New System.Data.SqlClient.SqlDataAdapter("Exec getExistingChildCOBySub " & pDAte, WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function getExistingParentCOBySub(ByVal pDAte As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@CloseoutHeader_ID", 8)}
            sqlParameter(0).Value=(pDAte)
            Dim sqlDataAdapter As New System.Data.SqlClient.SqlDataAdapter("Exec getExistingParentCOBySub " & pDAte, WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function getLastCloseOuts(ByVal pSub As String) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Nick_Name", 22)}
            sqlParameter(0).Value=(pSub)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "getlastcobysub", sqlParameter)
        End Function

        Public Shared Function GetPayCodes(ByVal pCode As String) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Code_Description", 22)}
            sqlParameter(0).Value=(pCode)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetActiveCodesByCodeDescription", sqlParameter)
        End Function

        Public Shared Function modifyCloseOutDetail(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pBillAmt As Decimal, ByVal pPayBasis As Decimal, ByVal pPayCode As String, ByVal pPayPer As Integer, ByVal pPayAmt As Decimal, ByVal pTip As Decimal, ByVal pARCode As String, ByVal pPayRecd As Decimal, ByVal pTax As Decimal, ByVal pActive As Integer, ByVal pModifyUser As String) As Integer
            Dim sqlParameter(12) As System.Data.SqlClient.SqlParameter
            sqlParameter(0) = New System.Data.SqlClient.SqlParameter("@DetailID", 8)
            sqlParameter(0).Value=(pDetail)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@JobNbr", 8)
            sqlParameter(1).Value=(pJobNbr)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@BillAmt", 9)
            sqlParameter(2).Value=(pBillAmt)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@PayBasis", 9)
            sqlParameter(3).Value=(pPayBasis)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@PayCode", 22)
            sqlParameter(4).Value=(pPayCode)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@PayPer", 8)
            sqlParameter(5).Value=(pPayPer)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@PayAmt", 9)
            sqlParameter(6).Value=(pPayAmt)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Tip", 5)
            sqlParameter(7).Value=(pTip)
            sqlParameter(8) = New System.Data.SqlClient.SqlParameter("@ARCode", 22)
            sqlParameter(8).Value=(pARCode)
            sqlParameter(9) = New System.Data.SqlClient.SqlParameter("@PayRecd", 5)
            sqlParameter(9).Value=(pPayRecd)
            sqlParameter(10) = New System.Data.SqlClient.SqlParameter("@Tax", 5)
            sqlParameter(10).Value=(pTax)
            sqlParameter(11) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(11).Value=(pActive)
            sqlParameter(12) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(12).Value=(pModifyUser)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdteCloseOutDetail", sqlParameter)
            Return num
        End Function

        Public Shared Function modifyCloseOutDetailCredit(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@DetailID", 8), Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pDetail)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@PayCode", 22)
            sqlParameter(1).Value=(pPayCode)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@PayAmt", 9)
            sqlParameter(2).Value=(pPayAmt)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(3).Value=(pActive)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(4).Value=(pModifyUser)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdteCloseOutDetailCredit", sqlParameter)
            Return num
        End Function
    End Class
End Namespace