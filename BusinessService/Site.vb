Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class Site
        Private tableName As String

        Private pkColumn As String

        Private siteDT As SiteDT

        Public Sub New()
            MyBase.New()
            Me.tableName = "Site"
            Me.pkColumn = "Site_ID"
            Me.siteDT = New SiteDT()
        End Sub

        Public Function createSite(ByRef tran As TransactionContext, ByVal OccClient_ID As Integer, ByVal BillClient_ID As Integer, ByVal SiteAddress_ID As Integer, ByVal No_Stories As Integer, ByVal Note_Type As Integer, ByVal Notes As String, ByVal Source As String, ByVal CBMethod As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            messageHelper = Me.validateIds(StringType.FromInteger(SiteAddress_ID), StringType.FromInteger(OccClient_ID), StringType.FromInteger(BillClient_ID), 0, 1)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = Me.siteDT.isrtSite(tran, OccClient_ID, BillClient_ID, SiteAddress_ID, No_Stories, Note_Type, Notes, Source, CBMethod, Active, Create_User, Modified_User)
            If (Information.IsDBNull(num)) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Site Insert Failed"
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Function getSiteByAddress1(ByVal address1 As String) As SqlDataReader
            Return Me.siteDT.getSiteByAddress1(address1)
        End Function

        Public Function getSiteByBillClient(ByVal billClient As String) As SqlDataReader
            Return Me.siteDT.getSiteByBillClient(billClient)
        End Function

        Public Function getSiteById(ByVal Site_id As Integer) As SqlDataReader
            Return Me.siteDT.getSiteById(Site_id)
        End Function

        Public Function getSiteByOccClient(ByVal occClient As String) As SqlDataReader
            Return Me.siteDT.getSiteByOccClient(occClient)
        End Function

        Public Function updateSiteAll(ByRef tran As TransactionContext, ByVal Site_ID As Integer, ByVal OccClient_ID As Integer, ByVal BillClient_ID As Integer, ByVal SiteAddress_ID As Integer, ByVal No_Stories As Integer, ByVal Note_Type As Integer, ByVal Notes As String, ByVal Source As String, ByVal CBMethod As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateIds(StringType.FromInteger(SiteAddress_ID), StringType.FromInteger(OccClient_ID), StringType.FromInteger(BillClient_ID), Site_ID, 2)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateSite(Site_ID, Modified_Date)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (Me.siteDT.updtSiteAll(tran, Site_ID, OccClient_ID, BillClient_ID, SiteAddress_ID, No_Stories, Note_Type, Notes, Source, CBMethod, Active, Modified_User, DateTime.Now()) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Site Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Private Function validateIds(ByVal addressId As String, ByVal occClientId As String, ByVal billClientId As String, ByVal Site_ID As Integer, ByVal request As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DoubleType.FromString(addressId) <> 0) Then
                messageHelper.status = True
            Else
                messageHelper.messageText = "Site Address Required"
                messageHelper.messageId = StringType.FromInteger(5)
                messageHelper.status = False
            End If
            If (messageHelper.status) Then
                If (Not (DoubleType.FromString(occClientId) = 0 And DoubleType.FromString(billClientId) = 0)) Then
                    messageHelper.status = True
                ElseIf (request = 1) Then
                    messageHelper.messageText = "Either Occ or Bill Client is Required"
                    messageHelper.messageId = StringType.FromInteger(6)
                    messageHelper.status = False
                ElseIf (Not Me.validateSiteJobs(Site_ID)) Then
                    messageHelper.messageText = "Un-closed Jobs for Site, Either Occ or Bill Client is Required"
                    messageHelper.messageId = StringType.FromInteger(7)
                    messageHelper.status = False
                ElseIf (Not Me.validateJobWithBalanceDueBySite(Site_ID)) Then
                    messageHelper.messageText = "Jobs Exist with Balance Due, Either Occ or Bill Client is Required"
                    messageHelper.messageId = StringType.FromInteger(8)
                    messageHelper.status = False
                End If
            End If
            Return messageHelper
        End Function

        Private Function validateJobWithBalanceDueBySite(ByVal site_id As Integer) As Boolean
            Dim jobDT As DataTranslation.JobDT = New DataTranslation.JobDT()
            Return True
        End Function

        Public Function validateSite(ByVal Site_id As Integer, ByVal modified_date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Not SystemDT.checkDirtyRead(Me.tableName, Me.pkColumn, Site_id, modified_date)) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(3)
            messageHelper.messageText = "Item Changed By Another User, Action Cancelled"
            Return messageHelper
        End Function

        Private Function validateSiteJobs(ByVal site_id As Integer) As Boolean
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = (New JobDT()).countJobBySiteIdStatus(site_id)
            sqlDataReader.Read()
            If (IntegerType.FromObject(sqlDataReader.Item(0)) = 0) Then
                Return True
            End If
            Return False
        End Function
    End Class
End Namespace