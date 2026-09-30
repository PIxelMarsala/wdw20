Imports Common
Imports DataAccess
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class CompanyDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getAll() As SqlDataReader
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "GetAllCompanies")
        End Function

        Public Function getCompany(CompanyID As Integer) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@CompanyID", CompanyID)}
            Return SqlHelper.ExecuteReader(WDWConfiguration.ConnectionString, CommandType.StoredProcedure, "GetCompany", sqlParameter)
        End Function

        Public Function UpdateCompany(CompanyID As Integer, InvoicePhone As String, InvoiceFax As String, InvoiceAddr1 As String, InvoiceAddr2 As String) As Integer

            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@CompanyID", CompanyID),
                New System.Data.SqlClient.SqlParameter("@InvoicePhone", InvoicePhone),
                New System.Data.SqlClient.SqlParameter("@InvoiceFax", InvoiceFax),
                New System.Data.SqlClient.SqlParameter("@InvoiceAddrLine1", InvoiceAddr1),
                New System.Data.SqlClient.SqlParameter("@InvoiceAddrLine2", InvoiceAddr2)}

            'Dim p As New SqlClient.SqlParameterCollection
            'p.AddWithValue("@CompanyID", CompanyID)
            'p.AddWithValue("@InvoicePhone", InvoicePhone)
            'p.AddWithValue("@InvoiceFax", InvoiceFax)
            'p.AddWithValue("@InvoiceAddrLine1", InvoiceAddr1)
            'p.AddWithValue("@InvoiceAddrLine2", InvoiceAddr2)

            Return SqlHelper.ExecuteNonQuery(WDWConfiguration.ConnectionString, CommandType.StoredProcedure, "UpdateCompany", sqlParameter)

        End Function

    End Class
End Namespace