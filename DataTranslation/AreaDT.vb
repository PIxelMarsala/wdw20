Imports Common
Imports DataAccess
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class AreaDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getAllActiveAreas() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllActiveAreas")
        End Function
    End Class
End Namespace