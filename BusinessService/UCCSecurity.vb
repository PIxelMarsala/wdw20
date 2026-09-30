Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCSecurity
        Private [operator] As [Operator]

        Public Sub New()
            MyBase.New()
            Me.[operator] = New [Operator]()
        End Sub

        Public Function authorizeAppFunction(ByVal operatorId As Integer, ByVal app_function As String) As MessageHelper
            Return Me.[operator].authorizeAppFunction(operatorId, app_function)
        End Function

        Public Shared Function getAllAppFunctions() As SqlDataReader
            Return Role.getAllAppFunctions()
        End Function

        Public Function logon(ByVal companyId As Integer, ByVal UserId As String, ByVal password As String) As MessageHelper
            Return Me.[operator].authorize(companyId, UserId, password)
        End Function
    End Class
End Namespace