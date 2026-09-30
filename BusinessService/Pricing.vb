Imports DataTranslation
Imports System
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class Pricing
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getAllChildPricing() As SqlDataAdapter
            Return PricingDT.getAllChildPricing()
        End Function

        Public Shared Function getAllParentPricing() As SqlDataAdapter
            Return PricingDT.getAllParentPricing()
        End Function

        Public Shared Function updatePricing(ByVal pKey As Integer, ByVal pColumnName As String, ByVal pPrice As Decimal) As SqlDataReader
            Return PricingDT.updatePricing(pKey, pColumnName, pPrice)
        End Function
    End Class
End Namespace