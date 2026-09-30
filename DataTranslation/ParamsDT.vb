Imports Common
Imports DataAccess
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class ParamsDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getActiveSubs() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllSubs")
        End Function

        Public Shared Function getAllCities() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllCities")
        End Function

        Public Shared Function getAllSubs() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllSubs")
        End Function

        Public Shared Function getAllUsers() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllUsers")
        End Function

        Public Shared Function getAllZips() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllZips")
        End Function

        Public Shared Function getMinMaxMonthDay() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetMinMaxMonthDay")
        End Function

        Public Shared Function updateDepositStatus(ByRef tran As TransactionContext) As Integer
            Return SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdateDepositStatus")
        End Function

        Public Shared Function updateJobStatus(ByRef tran As TransactionContext, ByVal pFrom As DateTime, ByVal pTo As DateTime, ByVal pSub As String) As Integer
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@FromDate", 4), Nothing, Nothing}
            sqlParameter(0).Value=(pFrom)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@ToDate", 4)
            sqlParameter(1).Value=(pTo)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Sub", 22)
            sqlParameter(2).Value=(pSub)
            Dim num As Integer = SqlHelper.ExecuteNonQuery(tran.tran, CommandType.StoredProcedure, "UpdateJobStatus", sqlParameter)
            Return num
        End Function
    End Class
End Namespace