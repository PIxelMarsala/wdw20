Imports DataAccess
Imports System
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class UCCPricing
        Private trans As TransactionContext

        Public Sub New()
            MyBase.New()
            Me.trans = New TransactionContext()
        End Sub

        Public Shared Function getAllChildPricing() As SqlDataAdapter
            Return Pricing.getAllChildPricing()
        End Function

        Public Shared Function getAllParentPricing() As SqlDataAdapter
            Return Pricing.getAllParentPricing()
        End Function

        Public Shared Function updatePricing(ByVal pKey As Integer, ByVal pColumnName As String, ByVal pPrice As Decimal) As SqlDataReader
            Return Pricing.updatePricing(pKey, pColumnName, pPrice)
        End Function
    End Class
End Namespace