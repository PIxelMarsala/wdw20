Imports Common
Imports DataAccess
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class RoleDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getAllRoles() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllRoles")
        End Function
    End Class
End Namespace