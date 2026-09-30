Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient


Namespace DataTranslation
    Public Class TaskDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createChildServOff(ByRef tran As TransactionContext, ByVal pServName As String, ByVal pPServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@ServName", 22), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pServName)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@PServName", 22)
            sqlParameter(1).Value=(pPServName)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Active", 20)
            sqlParameter(2).Value=(pActive)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Tax", 20)
            sqlParameter(3).Value=(pTax)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Pricing", 20)
            sqlParameter(4).Value=(pPricing)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Grouping", 8)
            sqlParameter(5).Value=(pGrouping)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Position", 8)
            sqlParameter(6).Value=(pPosition)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "InsrtChildServOff", sqlParameter))
            Return num
        End Function

        Public Shared Function createParentServOff(ByRef tran As TransactionContext, ByVal pServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@ServName", 22), Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pServName)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Active", 20)
            sqlParameter(1).Value=(pActive)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Tax", 20)
            sqlParameter(2).Value=(pTax)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Pricing", 20)
            sqlParameter(3).Value=(pPricing)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Grouping", 8)
            sqlParameter(4).Value=(pGrouping)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Position", 8)
            sqlParameter(5).Value=(pPosition)
            Dim num As Integer = IntegerType.FromObject(SqlHelper.ExecuteScalar(tran.tran, CommandType.StoredProcedure, "InsrtParentServOff", sqlParameter))
            Return num
        End Function

        Public Shared Function getAllChildTasks() As SqlDataAdapter
            Return New SqlDataAdapter("EXEC GetAllChildTasks", WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function getAllParentTasks() As SqlDataAdapter
            Return New SqlDataAdapter("EXEC GetAllParentTasks", WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function getMaxServOffID() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetMaxServOff")
        End Function

        Public Shared Function removeChildServOff(ByRef tran As TransactionContext, ByVal pServOffID As Integer) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@ServOff_ID", 8)}
            sqlParameter(0).Value=(pServOffID)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "RemoveChildServOffer", sqlParameter)
            Return num
        End Function

        Public Shared Function removeParentandChildrentServOff(ByRef tran As TransactionContext, ByVal pServOffID As Integer) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@ParentServOff_ID", 8)}
            sqlParameter(0).Value=(pServOffID)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "RemoveParentAndChildServOffer", sqlParameter)
            Return num
        End Function

        Public Shared Function updateServOff(ByRef tran As TransactionContext, ByVal pServOffID As Integer, ByVal pServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@ServOffID", 8), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(pServOffID)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@ServName", 22)
            sqlParameter(1).Value=(pServName)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Active", 20)
            sqlParameter(2).Value=(pActive)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Tax", 20)
            sqlParameter(3).Value=(pTax)
            sqlParameter(4) = New System.Data.SqlClient.SqlParameter("@Pricing", 20)
            sqlParameter(4).Value=(pPricing)
            sqlParameter(5) = New System.Data.SqlClient.SqlParameter("@Grouping", 8)
            sqlParameter(5).Value=(pGrouping)
            sqlParameter(6) = New System.Data.SqlClient.SqlParameter("@Position", 8)
            sqlParameter(6).Value=(pPosition)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdateServOff", sqlParameter)
            Return num
        End Function
    End Class
End Namespace