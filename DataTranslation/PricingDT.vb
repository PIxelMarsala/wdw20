Imports Common
Imports DataAccess
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class PricingDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getAllChildPricing() As SqlDataAdapter
            Return New SqlDataAdapter("EXEC GetAllChildPricing", WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function getAllParentPricing() As SqlDataAdapter
            Return New SqlDataAdapter("EXEC GetAllParentPricing", WDWConfiguration.ConnectionString)
        End Function

        Public Shared Function updatePricing(ByVal pKey As Integer, ByVal pColumnName As String, ByVal pPrice As Decimal) As SqlDataReader
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@ServOffID", 8), Nothing, Nothing}
            sqlParameter(0).Value=(pKey)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@ElementName", 22)
            sqlParameter(1).Value=(pColumnName)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@Price", 9)
            sqlParameter(2).Value=(pPrice)
            Return SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "UpdatePricing", sqlParameter)
        End Function
    End Class
End Namespace