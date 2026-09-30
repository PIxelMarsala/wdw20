Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class UCCCode
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getActiveCodesByCodeDescription(ByVal codeDescription As String) As SqlDataReader
            Return Code.getActiveCodesByCodeDescription(codeDescription)
        End Function

        Public Shared Function getActiveCodesByCodeDescriptionDS(ByVal codeDescription As String) As DataSet
            Return Code.getActiveCodesByCodeDescriptionDS(codeDescription)
        End Function
    End Class
End Namespace