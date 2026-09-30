Imports DataTranslation
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class Code
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getActiveCodesByCodeDescription(ByVal codeDescription As String) As SqlDataReader
            Return CodeDT.getActiveCodesByCodeDescription(codeDescription)
        End Function

        Public Shared Function getActiveCodesByCodeDescriptionDS(ByVal codeDescription As String) As DataSet
            Return CodeDT.getActiveCodesByCodeDescriptionDS(codeDescription)
        End Function
    End Class
End Namespace