Imports DataTranslation
Imports System
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class Role
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getAllAppFunctions() As SqlDataReader
            Return AppFunctionDT.getAllAppFunctions()
        End Function

        Public Shared Function getAllRoles() As SqlDataReader
            Return RoleDT.getAllRoles()
        End Function
    End Class
End Namespace