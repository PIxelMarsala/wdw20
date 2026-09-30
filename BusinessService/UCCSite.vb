Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCSite
        Private site As Site

        Public Sub New()
            MyBase.New()
            Me.site = New Site()
        End Sub

        Public Function createSite(ByVal OccClient_ID As Integer, ByVal BillClient_ID As Integer, ByVal SiteAddress_ID As Integer, ByVal No_Stories As Integer, ByVal Note_Type As Integer, ByVal Notes As String, ByVal Source As String, ByVal CBMethod As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.site.createSite(transactionContext, OccClient_ID, BillClient_ID, SiteAddress_ID, No_Stories, Note_Type, Notes, Source, CBMethod, Active, Create_User, Modified_User)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function

        Public Function getSiteByAddress1(ByVal address1 As String) As SqlDataReader
            Return Me.site.getSiteByAddress1(address1)
        End Function

        Public Function getSiteByBillClient(ByVal billClient As String) As SqlDataReader
            Return Me.site.getSiteByBillClient(billClient)
        End Function

        Public Function getSiteById(ByVal site_id As Integer) As SqlDataReader
            Return Me.site.getSiteById(site_id)
        End Function

        Public Function getSiteByOccClient(ByVal occClient As String) As SqlDataReader
            Return Me.site.getSiteByOccClient(occClient)
        End Function

        Public Function updateSiteAll(ByVal Site_ID As Integer, ByVal OccClient_ID As Integer, ByVal BillClient_ID As Integer, ByVal SiteAddress_ID As Integer, ByVal No_Stories As Integer, ByVal Note_Type As Integer, ByVal Notes As String, ByVal Source As String, ByVal CBMethod As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.site.updateSiteAll(transactionContext, Site_ID, OccClient_ID, BillClient_ID, SiteAddress_ID, No_Stories, Note_Type, Notes, Source, CBMethod, Active, Modified_User, Modified_Date)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function
    End Class
End Namespace