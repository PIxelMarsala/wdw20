Imports Microsoft.VisualBasic.CompilerServices
Imports SystemFramework

Namespace BusinessService
    Public Class UCCSearch
        Public Sub New()
            MyBase.New()
        End Sub

        Private Function searchAlternatePhone(ByVal alternatePhone As String) As BusinessService.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView = New BusinessService.SiteSearchView()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            siteSearchView.getJobByAlternatePhone(alternatePhone)
            Return siteSearchView
        End Function

        Private Function searchBillingAddress(ByVal billingAddress As String) As BusinessService.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView = New BusinessService.SiteSearchView()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            siteSearchView.getBillingAddressByAddressLine1(billingAddress)
            Return siteSearchView
        End Function

        Public Function searchClient(ByVal siteAddress As String, ByVal billAddress As String, ByVal areaCode As String, ByVal areaExchange As String, ByVal areaPhoneNumber As String, ByVal altAreaCode As String, ByVal altAreaExchange As String, ByVal altAreaPhoneNumber As String, ByVal clientId As String, ByVal lastName As String) As SystemFramework.MessageHelper
            Dim siteSearchView As BusinessService.SiteSearchView = Nothing
            Dim str As String = String.Concat(areaCode, areaExchange, areaPhoneNumber)
            Dim str1 As String = String.Concat(altAreaCode, altAreaExchange, altAreaPhoneNumber)
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateCriteria(siteAddress, billAddress, str, str1, clientId, lastName)
            If (messageHelper.status) Then
                Dim str2 As String = messageHelper.messageId
                If (StringType.StrCmp(str2, "S", False) = 0) Then
                    siteSearchView = Me.searchSiteAddress(siteAddress)
                ElseIf (StringType.StrCmp(str2, "B", False) = 0) Then
                    siteSearchView = Me.searchBillingAddress(billAddress)
                ElseIf (StringType.StrCmp(str2, "P", False) = 0) Then
                    siteSearchView = Me.searchPrimaryPhone(str)
                ElseIf (StringType.StrCmp(str2, "A", False) = 0) Then
                    siteSearchView = Me.searchAlternatePhone(str1)
                ElseIf (StringType.StrCmp(str2, "C", False) = 0) Then
                    siteSearchView = Me.searchClientId(clientId)
                ElseIf (StringType.StrCmp(str2, "L", False) = 0) Then
                    siteSearchView = Me.searchLastName(lastName)
                End If
                If (siteSearchView.clients.Count() <> 0) Then
                    messageHelper.status = True
                    messageHelper.messageObject = siteSearchView
                Else
                    messageHelper.status = False
                    messageHelper.messageText = "No Records Found For Search Criteria"
                    messageHelper.messageId = StringType.FromInteger(1)
                End If
            End If
            Return messageHelper
        End Function

        Private Function searchClientId(ByVal clientId As String) As BusinessService.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView = New BusinessService.SiteSearchView()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            siteSearchView.getJobByClientID(IntegerType.FromString(clientId))
            Return siteSearchView
        End Function

        Private Function searchLastName(ByVal lastName As String) As BusinessService.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView = New BusinessService.SiteSearchView()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            siteSearchView.getJobByLastName(lastName)
            Return siteSearchView
        End Function

        Private Function searchPrimaryPhone(ByVal primaryPhone As String) As BusinessService.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView = New BusinessService.SiteSearchView()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            siteSearchView.getJobByPrimaryPhone(primaryPhone)
            Return siteSearchView
        End Function

        Private Function searchSiteAddress(ByVal siteAddress As String) As BusinessService.SiteSearchView
            Dim siteSearchView As BusinessService.SiteSearchView = New BusinessService.SiteSearchView()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            siteSearchView.getJobByAddressLine1(siteAddress)
            Return siteSearchView
        End Function

        Private Function validateCriteria(ByVal siteAddress As String, ByVal billAddress As String, ByVal primaryPhone As String, ByVal alternatePhone As String, ByVal clientId As String, ByVal lastName As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            If (primaryPhone.Length() = 3) Then
                primaryPhone = ""
            End If
            If (alternatePhone.Length() = 3) Then
                alternatePhone = ""
            End If
            If (siteAddress.Length() > 0) Then
                If (Not (billAddress.Length() > 0 Or primaryPhone.Length() > 0 Or alternatePhone.Length() > 0 Or clientId.Length() > 0 Or lastName.Length() > 0)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "S"
                Else
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.messageText = "Site Address is mutually exclusive with others"
                End If
            ElseIf (billAddress.Length() > 0) Then
                If (Not (siteAddress.Length() > 0 Or primaryPhone.Length() > 0 Or alternatePhone.Length() > 0 Or clientId.Length() > 0 Or lastName.Length() > 0)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "B"
                Else
                    messageHelper.messageId = StringType.FromInteger(2)
                    messageHelper.messageText = "Bill Address is mutually exclusive with others"
                End If
            ElseIf (primaryPhone.Length() > 0) Then
                If (billAddress.Length() > 0 Or siteAddress.Length() > 0 Or alternatePhone.Length() > 0 Or clientId.Length() > 0 Or lastName.Length() > 0) Then
                    messageHelper.messageId = StringType.FromInteger(3)
                    messageHelper.messageText = "Phone is mutually exclusive with others"
                ElseIf (primaryPhone.Length() = 10) Then
                    messageHelper.status = True
                    messageHelper.messageId = "P"
                Else
                    messageHelper.messageId = StringType.FromInteger(8)
                    messageHelper.messageText = "Primary Phone Invalid"
                End If
            ElseIf (alternatePhone.Length() > 0) Then
                If (billAddress.Length() > 0 Or siteAddress.Length() > 0 Or primaryPhone.Length() > 0 Or clientId.Length() > 0 Or lastName.Length() > 0) Then
                    messageHelper.messageId = StringType.FromInteger(4)
                    messageHelper.messageText = "Alt Phone is mutually exclusive with others"
                ElseIf (alternatePhone.Length() = 10) Then
                    messageHelper.status = True
                    messageHelper.messageId = "A"
                Else
                    messageHelper.messageId = StringType.FromInteger(9)
                    messageHelper.messageText = "Alternate Phone Invalid"
                End If
            ElseIf (clientId.Length() > 0) Then
                If (billAddress.Length() > 0 Or siteAddress.Length() > 0 Or primaryPhone.Length() > 0 Or lastName.Length() > 0 Or alternatePhone.Length() > 0) Then
                    messageHelper.messageId = StringType.FromInteger(5)
                    messageHelper.messageText = "Client Id is mutually exclusive with others"
                ElseIf (Information.IsNumeric(clientId)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "C"
                Else
                    messageHelper.messageId = StringType.FromInteger(12)
                    messageHelper.messageText = "Invalid Client ID"
                End If
            ElseIf (lastName.Length() <= 0) Then
                messageHelper.messageId = StringType.FromInteger(13)
                messageHelper.messageText = "No Search Criteria Entered"
            ElseIf (Not (billAddress.Length() > 0 Or siteAddress.Length() > 0 Or primaryPhone.Length() > 0 Or clientId.Length() > 0 Or alternatePhone.Length() > 0)) Then
                messageHelper.status = True
                messageHelper.messageId = "L"
            Else
                messageHelper.messageId = StringType.FromInteger(11)
                messageHelper.messageText = "Last Name is mutually exclusive with others"
            End If
            Return messageHelper
        End Function
    End Class
End Namespace