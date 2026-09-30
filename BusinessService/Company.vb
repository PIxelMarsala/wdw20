Imports DataTranslation
Imports System
Imports System.Data.SqlClient

Namespace BusinessService
    Public Class Company
        Private companyDT As CompanyDT

        Public Sub New()
            MyBase.New()
            Me.companyDT = New CompanyDT()
        End Sub

        Public Function getAll() As SqlDataReader
            Return Me.companyDT.getAll()
        End Function

        Public Function getCompany(CompanyID As Integer) As SqlDataReader
            Return Me.companyDT.getCompany(CompanyID)
        End Function

        Public Function UpdateCompany(CompanyID As Integer, InvoicePhone As String, InvoiceFax As String, InvoiceAddr1 As String, InvoiceAddr2 As String) As Integer
            Return Me.companyDT.UpdateCompany(CompanyID, InvoicePhone, InvoiceFax, InvoiceAddr1, InvoiceAddr2)
        End Function
    End Class
End Namespace