Imports System
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class UCCRole
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getAllRoles() As SqlDataReader
            Return Role.getAllRoles()
        End Function
    End Class
End Namespace