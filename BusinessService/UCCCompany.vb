Imports System
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class UCCCompany
        Private company As Company

        Public Sub New()
            MyBase.New()
            Me.company = New Company()
        End Sub

        Public Function getAll() As SqlDataReader
            Return Me.company.getAll()
        End Function
    End Class
End Namespace