Imports Common
Imports DataAccess
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class CodeDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getActiveCodesByCodeDescription(ByVal codeDescription As String) As SqlDataReader
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Code_Description", codeDescription)}
            Return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, "GetActiveCodesByCodeDescription", sqlParameter)
        End Function

        Public Shared Function getActiveCodesByCodeDescriptionDS(ByVal codeDescription As String) As DataSet
            Dim connectionString As String = WDWConfiguration.ConnectionString
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Code_Description", codeDescription)}
            Return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetActiveCodesByCodeDescription", sqlParameter)
        End Function
    End Class
End Namespace