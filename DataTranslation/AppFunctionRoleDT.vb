Imports Common
Imports DataAccess
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class AppFunctionRoleDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getAppFunctionRoleByOperatorId(ByVal operatorId As Integer, ByVal appFunction As String) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Operator_ID", 8), Nothing}
            sqlParameter(0).Value=(operatorId)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@Function_Name", 22)
            sqlParameter(1).Value=(appFunction)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "getAppFunctionRoleByOperatorId", sqlParameter)
        End Function
    End Class
End Namespace