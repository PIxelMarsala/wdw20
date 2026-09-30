Imports DataTranslation
Imports System
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class Area
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getAllActiveAreas() As SqlDataReader
            Return AreaDT.getAllActiveAreas()
        End Function
    End Class
End Namespace