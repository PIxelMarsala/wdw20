Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class EstimateDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createEstimate(ByRef tran As TransactionContext, ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pColumnName As String, ByVal pKey As Integer, ByVal pPrice As Decimal, ByVal pQty As Decimal, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeaderID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pHeaderID)
            sqlParameter(0).Direction=(3)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@OverrideTotal", 9)
            sqlParameter(1).Value=(pOTotal)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@ElementName", 22)
            sqlParameter(2).Value=(pColumnName)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@ServOffID", 8)
            sqlParameter(3).Value=(pKey)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Price", 9)
            sqlParameter(4).Value=(pPrice)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Qty", 5)
            sqlParameter(5).Value=(pQty)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(6).Value=(pCreateUser)
            sqlParameter(7) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(7).Value=(pModifyUser)
            SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "InsrtEstimate", sqlParameter)
            Dim num As Integer = IntegerType.FromObject(sqlParameter(0).Value)
            If (num > 0) Then
                Return num
            End If
            Return 0
        End Function

        Public Shared Function getAllChildEstimate() As SqlDataAdapter
            Return New SqlDataAdapter("EXEC GetAllChildEstimate", WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function getAllChildEstimateByBid(ByVal pHeaderID As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlParameterArray(0) As SqlParameter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("EXEC GetAllChildEstimateByBid ", StringType.FromInteger(pHeaderID)), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function getAllParentEstimate() As SqlDataAdapter
            Return New SqlDataAdapter("EXEC GetAllParentEstimate", WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function getAllParentEstimateByBid(ByVal pHeaderId As Integer) As System.Data.SqlClient.SqlDataAdapter
            Dim sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(String.Concat("Exec GetAllParentEstimateByBid ", StringType.FromInteger(pHeaderId)), WDWConfiguration.ConnectionString)
            Return sqlDataAdapter
        End Function

        Public Shared Function getBidById(ByVal pHeaderID As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeader_ID", pHeaderID)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetAllBidById", sqlParameter)
        End Function

        Public Shared Function getBidHeaderById(ByVal tran As TransactionContext, ByVal pHeaderId As Integer) As SqlDataReader
            Dim sqlTransaction As System.Data.SqlClient.SqlTransaction = tran.tran
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeader_ID", pHeaderId)}
            Return SqlHelper.ExecuteReader(sqlTransaction, CommandType.StoredProcedure, "GetBidHeaderById", sqlParameter)
        End Function

        Public Shared Function getHeaderAmts(ByVal pHeaderId As Integer) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeader_ID", pHeaderId)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "getHeaderAmts", sqlParameter)
        End Function

        Public Shared Function getJobDescription(ByVal pHeader As Integer) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeader_ID", 8)}
            sqlParameter(0).Value=(pHeader)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetJobDescriptionByBid", sqlParameter)
        End Function

        Public Function isrtBidDetail(ByRef tran As TransactionContext, ByVal BidHeader_ID As Integer, ByVal ServOffElem_ID As Integer, ByVal Qty As Decimal, ByVal Detail_Total As Decimal, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeader_ID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(BidHeader_ID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@ServOffElem_ID", 8)
            sqlParameter(1).Value=(ServOffElem_ID)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Qty", 5)
            sqlParameter(2).Value=(Qty)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Detail_Total", 9)
            sqlParameter(3).Value=(Detail_Total)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(4).Value=(Active)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(5).Value=(Create_User)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(6).Value=(Modified_User)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtBidHeaderDetail", sqlParameter))
            Return num
        End Function

        Public Function isrtBidHeader(ByRef tran As TransactionContext, ByVal Bid_Total As Decimal, ByVal Override_Amt As Decimal, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Bid_Total", 9), Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(Bid_Total)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Override_Amt", 9)
            sqlParameter(1).Value=(Override_Amt)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Active", 8)
            sqlParameter(2).Value=(Active)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Create_User", 22)
            sqlParameter(3).Value=(Create_User)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Modified_User", 22)
            sqlParameter(4).Value=(Modified_User)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "IsrtBidHeader", sqlParameter))
            Return num
        End Function

        Public Shared Function removeEstimate(ByRef tran As TransactionContext, ByVal pHeaderID As Integer) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeaderID", 8)}
            sqlParameter(0).Value=(pHeaderID)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "RemoveEstimate", sqlParameter)
            Return num
        End Function

        Public Shared Function updateEstimate(ByRef tran As TransactionContext, ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pColumnName As String, ByVal pKey As Integer, ByVal pPrice As Decimal, ByVal pQty As Decimal, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeaderID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pHeaderID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@OverrideTotal", 9)
            sqlParameter(1).Value=(pOTotal)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@ElementName", 22)
            sqlParameter(2).Value=(pColumnName)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@ServOffID", 8)
            sqlParameter(3).Value=(pKey)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Price", 9)
            sqlParameter(4).Value=(pPrice)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Qty", 5)
            sqlParameter(5).Value=(pQty)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Modify_User", 22)
            sqlParameter(6).Value=(pModifyUser)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdteEstimate", sqlParameter)
            Return num
        End Function

        Public Shared Function updateOverride(ByRef tran As TransactionContext, ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pModifyUser As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@BidHeaderID", 8), Nothing, Nothing}
            sqlParameter(0).Value=(pHeaderID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@OverrideTotal", 9)
            sqlParameter(1).Value=(pOTotal)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Modify_User", 22)
            sqlParameter(2).Value=(pModifyUser)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdteOverride", sqlParameter)
            Return num
        End Function
    End Class
End Namespace