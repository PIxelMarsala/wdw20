Imports Common
Imports DataAccess
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class AppFunctionDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getAllAppFunctions() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllAppFunction")
        End Function

        Public Function getAppFunctionById(ByVal appFunctionId As Integer) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@App_Function_ID", 8)}
            sqlParameter(0).Value=(appFunctionId)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "getAppFunctionById", sqlParameter)
        End Function
    End Class
End Namespace