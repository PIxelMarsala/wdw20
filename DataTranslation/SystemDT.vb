Imports Common
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient

Namespace DataTranslation
    Public Class SystemDT
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function checkDirtyRead(ByVal table_name As String, ByVal pk_column As String, ByVal pk_value As Integer, ByVal modified_date As DateTime) As Boolean
            Dim sqlParameter() As System.Data.SqlClient.SqlParameter = {New System.Data.SqlClient.SqlParameter("@Table_Name", 22), Nothing, Nothing, Nothing}
            sqlParameter(0).Value=(table_name)
            sqlParameter(1) = New System.Data.SqlClient.SqlParameter("@PK_Column", 22)
            sqlParameter(1).Value=(pk_column)
            sqlParameter(2) = New System.Data.SqlClient.SqlParameter("@PK_Value", 8)
            sqlParameter(2).Value=(pk_value)
            sqlParameter(3) = New System.Data.SqlClient.SqlParameter("@Modified_Date", 22)
            sqlParameter(3).Value=(modified_date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = SqlHelper.ExecuteReader(WDWConfiguration.connectionString, CommandType.StoredProcedure, "CheckDirtyRead", sqlParameter)
            sqlDataReader.Read()
            If (IntegerType.FromObject(sqlDataReader.Item(0)) = 1) Then
                Return False
            End If
            Return True
        End Function
    End Class
End Namespace