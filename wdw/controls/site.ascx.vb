Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public MustInherit Class site
        Inherits ControlBase

        '<AccessedThroughProperty("txtOccClientID")>
        'Private _txtOccClientID As TextBox

        '<AccessedThroughProperty("Label2")>
        'Private _Label2 As Label

        '<AccessedThroughProperty("btnSave")>
        'Private _btnSave As Button

        '<AccessedThroughProperty("btnSelect")>
        'Private _btnSelect As Button

        '<AccessedThroughProperty("Label14")>
        'Private _Label14 As Label

        '<AccessedThroughProperty("Label4")>
        'Private _Label4 As Label

        '<AccessedThroughProperty("btnSearch")>
        'Private _btnSearch As Button

        '<AccessedThroughProperty("txtNotes")>
        'Private _txtNotes As TextBox

        '<AccessedThroughProperty("btnNew")>
        'Private _btnNew As Button

        '<AccessedThroughProperty("txtBillClientID")>
        'Private _txtBillClientID As TextBox

        '<AccessedThroughProperty("lblErrorMsg")>
        'Private _lblErrorMsg As Label

        '<AccessedThroughProperty("Label5")>
        'Private _Label5 As Label

        '<AccessedThroughProperty("Label6")>
        'Private _Label6 As Label

        '<AccessedThroughProperty("Label7")>
        'Private _Label7 As Label

        '<AccessedThroughProperty("Label8")>
        'Private _Label8 As Label

        '<AccessedThroughProperty("UWGSite")>
        'Private _UWGSite As UltraWebGrid

        '<AccessedThroughProperty("txtSiteAddressID")>
        'Private _txtSiteAddressID As TextBox

        '<AccessedThroughProperty("txtSiteID")>
        'Private _txtSiteID As TextBox

        '<AccessedThroughProperty("txtNoStories")>
        'Private _txtNoStories As TextBox

        '<AccessedThroughProperty("chkActive")>
        'Private _chkActive As CheckBox

        '<AccessedThroughProperty("txtSrchSiteAddr")>
        'Private _txtSrchSiteAddr As TextBox

        '<AccessedThroughProperty("lstCallBackMethod")>
        'Private _lstCallBackMethod As DropDownList

        '<AccessedThroughProperty("txtCity")>
        'Private _txtCity As TextBox

        '<AccessedThroughProperty("txtSrchSiteID")>
        'Private _txtSrchSiteID As TextBox

        '<AccessedThroughProperty("txtState")>
        'Private _txtState As TextBox

        '<AccessedThroughProperty("Label9")>
        'Private _Label9 As Label

        '<AccessedThroughProperty("lblCallbackMethod")>
        'Private _lblCallbackMethod As Label

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("pnlMore")>
        'Private _pnlMore As Panel

        '<AccessedThroughProperty("txtModifiedDate")>
        'Private _txtModifiedDate As TextBox

        '<AccessedThroughProperty("txtModifiedUser")>
        'Private _txtModifiedUser As TextBox

        '<AccessedThroughProperty("txtCreateDate")>
        'Private _txtCreateDate As TextBox

        '<AccessedThroughProperty("txtCreateUser")>
        'Private _txtCreateUser As TextBox

        '<AccessedThroughProperty("txtSrchOccClient")>
        'Private _txtSrchOccClient As TextBox

        '<AccessedThroughProperty("txtZipCode")>
        'Private _txtZipCode As TextBox

        '<AccessedThroughProperty("Label10")>
        'Private _Label10 As Label

        '<AccessedThroughProperty("lstSource")>
        'Private _lstSource As DropDownList

        '<AccessedThroughProperty("txtSrchBillClient")>
        'Private _txtSrchBillClient As TextBox

        '<AccessedThroughProperty("chkNoteType")>
        'Private _chkNoteType As CheckBox

        '<AccessedThroughProperty("txtBillClientLast")>
        'Private _txtBillClientLast As TextBox

        '<AccessedThroughProperty("Label11")>
        'Private _Label11 As Label

        '<AccessedThroughProperty("txtSiteAddr1")>
        'Private _txtSiteAddr1 As TextBox

        '<AccessedThroughProperty("txtOccClientFirst")>
        'Private _txtOccClientFirst As TextBox

        '<AccessedThroughProperty("Label12")>
        'Private _Label12 As Label

        '<AccessedThroughProperty("txtOccClientLast")>
        'Private _txtOccClientLast As TextBox

        '<AccessedThroughProperty("txtBillClientFirst")>
        'Private _txtBillClientFirst As TextBox

        '<AccessedThroughProperty("btnCancel")>
        'Private _btnCancel As Button

        Private uccSite As UCCSite

        Private rdr As SqlDataReader

        Private isChild As Boolean

        Private fromParent As String

        'Protected Overridable Property btnCancel As Button
        '    Get
        '        Return Me._btnCancel
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnCancel IsNot Nothing) Then
        '            Dim _site As site = Me
        '            Me._btnCancel.remove_Click(New EventHandler(_site, _site.btnCancel_Click))
        '        End If
        '        Me._btnCancel = value
        '        If (Me._btnCancel IsNot Nothing) Then
        '            Dim _site1 As site = Me
        '            Me._btnCancel.add_Click(New EventHandler(_site1, _site1.btnCancel_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnNew As Button
        '    Get
        '        Return Me._btnNew
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnNew IsNot Nothing) Then
        '            Dim _site As site = Me
        '            Me._btnNew.remove_Click(New EventHandler(_site, _site.btnNew_Click))
        '        End If
        '        Me._btnNew = value
        '        If (Me._btnNew IsNot Nothing) Then
        '            Dim _site1 As site = Me
        '            Me._btnNew.add_Click(New EventHandler(_site1, _site1.btnNew_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnSave As Button
        '    Get
        '        Return Me._btnSave
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnSave IsNot Nothing) Then
        '            Dim _site As site = Me
        '            Me._btnSave.remove_Click(New EventHandler(_site, _site.btnSave_Click))
        '        End If
        '        Me._btnSave = value
        '        If (Me._btnSave IsNot Nothing) Then
        '            Dim _site1 As site = Me
        '            Me._btnSave.add_Click(New EventHandler(_site1, _site1.btnSave_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnSearch As Button
        '    Get
        '        Return Me._btnSearch
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnSearch IsNot Nothing) Then
        '            Dim _site As site = Me
        '            Me._btnSearch.remove_Click(New EventHandler(_site, _site.btnSearch_Click))
        '        End If
        '        Me._btnSearch = value
        '        If (Me._btnSearch IsNot Nothing) Then
        '            Dim _site1 As site = Me
        '            Me._btnSearch.add_Click(New EventHandler(_site1, _site1.btnSearch_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnSelect As Button
        '    Get
        '        Return Me._btnSelect
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnSelect IsNot Nothing) Then
        '            Dim _site As site = Me
        '            Me._btnSelect.remove_Click(New EventHandler(_site, _site.btnSelect_Click))
        '        End If
        '        Me._btnSelect = value
        '        If (Me._btnSelect IsNot Nothing) Then
        '            Dim _site1 As site = Me
        '            Me._btnSelect.add_Click(New EventHandler(_site1, _site1.btnSelect_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property chkActive As CheckBox
        '    Get
        '        Return Me._chkActive
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkActive Is Nothing
        '        Me._chkActive = value
        '        Me._chkActive Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkNoteType As CheckBox
        '    Get
        '        Return Me._chkNoteType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkNoteType Is Nothing
        '        Me._chkNoteType = value
        '        Me._chkNoteType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label1 As Label
        '    Get
        '        Return Me._Label1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label1 Is Nothing
        '        Me._Label1 = value
        '        Me._Label1 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label10 As Label
        '    Get
        '        Return Me._Label10
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label10 Is Nothing
        '        Me._Label10 = value
        '        Me._Label10 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label11 As Label
        '    Get
        '        Return Me._Label11
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label11 Is Nothing
        '        Me._Label11 = value
        '        Me._Label11 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label12 As Label
        '    Get
        '        Return Me._Label12
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label12 Is Nothing
        '        Me._Label12 = value
        '        Me._Label12 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label14 As Label
        '    Get
        '        Return Me._Label14
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label14 Is Nothing
        '        Me._Label14 = value
        '        Me._Label14 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label2 As Label
        '    Get
        '        Return Me._Label2
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label2 Is Nothing
        '        Me._Label2 = value
        '        Me._Label2 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label4 As Label
        '    Get
        '        Return Me._Label4
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label4 Is Nothing
        '        Me._Label4 = value
        '        Me._Label4 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label5 As Label
        '    Get
        '        Return Me._Label5
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label5 Is Nothing
        '        Me._Label5 = value
        '        Me._Label5 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label6 As Label
        '    Get
        '        Return Me._Label6
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label6 Is Nothing
        '        Me._Label6 = value
        '        Me._Label6 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label7 As Label
        '    Get
        '        Return Me._Label7
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label7 Is Nothing
        '        Me._Label7 = value
        '        Me._Label7 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label8 As Label
        '    Get
        '        Return Me._Label8
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label8 Is Nothing
        '        Me._Label8 = value
        '        Me._Label8 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label9 As Label
        '    Get
        '        Return Me._Label9
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label9 Is Nothing
        '        Me._Label9 = value
        '        Me._Label9 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lblCallbackMethod As Label
        '    Get
        '        Return Me._lblCallbackMethod
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblCallbackMethod Is Nothing
        '        Me._lblCallbackMethod = value
        '        Me._lblCallbackMethod Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lblErrorMsg As Label
        '    Get
        '        Return Me._lblErrorMsg
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblErrorMsg Is Nothing
        '        Me._lblErrorMsg = value
        '        Me._lblErrorMsg Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstCallBackMethod As DropDownList
        '    Get
        '        Return Me._lstCallBackMethod
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstCallBackMethod Is Nothing
        '        Me._lstCallBackMethod = value
        '        Me._lstCallBackMethod Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstSource As DropDownList
        '    Get
        '        Return Me._lstSource
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstSource Is Nothing
        '        Me._lstSource = value
        '        Me._lstSource Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property pnlMore As Panel
        '    Get
        '        Return Me._pnlMore
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Panel)
        '        Me._pnlMore Is Nothing
        '        Me._pnlMore = value
        '        Me._pnlMore Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillClientFirst As TextBox
        '    Get
        '        Return Me._txtBillClientFirst
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillClientFirst Is Nothing
        '        Me._txtBillClientFirst = value
        '        Me._txtBillClientFirst Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillClientID As TextBox
        '    Get
        '        Return Me._txtBillClientID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillClientID Is Nothing
        '        Me._txtBillClientID = value
        '        Me._txtBillClientID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillClientLast As TextBox
        '    Get
        '        Return Me._txtBillClientLast
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillClientLast Is Nothing
        '        Me._txtBillClientLast = value
        '        Me._txtBillClientLast Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtCity As TextBox
        '    Get
        '        Return Me._txtCity
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtCity Is Nothing
        '        Me._txtCity = value
        '        Me._txtCity Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtCreateDate As TextBox
        '    Get
        '        Return Me._txtCreateDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtCreateDate Is Nothing
        '        Me._txtCreateDate = value
        '        Me._txtCreateDate Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtCreateUser As TextBox
        '    Get
        '        Return Me._txtCreateUser
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtCreateUser Is Nothing
        '        Me._txtCreateUser = value
        '        Me._txtCreateUser Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtModifiedDate As TextBox
        '    Get
        '        Return Me._txtModifiedDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtModifiedDate Is Nothing
        '        Me._txtModifiedDate = value
        '        Me._txtModifiedDate Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtModifiedUser As TextBox
        '    Get
        '        Return Me._txtModifiedUser
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtModifiedUser Is Nothing
        '        Me._txtModifiedUser = value
        '        Me._txtModifiedUser Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtNoStories As TextBox
        '    Get
        '        Return Me._txtNoStories
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtNoStories Is Nothing
        '        Me._txtNoStories = value
        '        Me._txtNoStories Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtNotes As TextBox
        '    Get
        '        Return Me._txtNotes
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtNotes Is Nothing
        '        Me._txtNotes = value
        '        Me._txtNotes Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccClientFirst As TextBox
        '    Get
        '        Return Me._txtOccClientFirst
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccClientFirst Is Nothing
        '        Me._txtOccClientFirst = value
        '        Me._txtOccClientFirst Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccClientID As TextBox
        '    Get
        '        Return Me._txtOccClientID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        If (Me._txtOccClientID IsNot Nothing) Then
        '            Dim _site As site = Me
        '            Me._txtOccClientID.remove_TextChanged(New EventHandler(_site, _site.txtOccClientID_TextChanged))
        '        End If
        '        Me._txtOccClientID = value
        '        If (Me._txtOccClientID IsNot Nothing) Then
        '            Dim _site1 As site = Me
        '            Me._txtOccClientID.add_TextChanged(New EventHandler(_site1, _site1.txtOccClientID_TextChanged))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property txtOccClientLast As TextBox
        '    Get
        '        Return Me._txtOccClientLast
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccClientLast Is Nothing
        '        Me._txtOccClientLast = value
        '        Me._txtOccClientLast Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSiteAddr1 As TextBox
        '    Get
        '        Return Me._txtSiteAddr1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSiteAddr1 Is Nothing
        '        Me._txtSiteAddr1 = value
        '        Me._txtSiteAddr1 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSiteAddressID As TextBox
        '    Get
        '        Return Me._txtSiteAddressID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSiteAddressID Is Nothing
        '        Me._txtSiteAddressID = value
        '        Me._txtSiteAddressID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSiteID As TextBox
        '    Get
        '        Return Me._txtSiteID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSiteID Is Nothing
        '        Me._txtSiteID = value
        '        Me._txtSiteID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchBillClient As TextBox
        '    Get
        '        Return Me._txtSrchBillClient
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchBillClient Is Nothing
        '        Me._txtSrchBillClient = value
        '        Me._txtSrchBillClient Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchOccClient As TextBox
        '    Get
        '        Return Me._txtSrchOccClient
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchOccClient Is Nothing
        '        Me._txtSrchOccClient = value
        '        Me._txtSrchOccClient Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchSiteAddr As TextBox
        '    Get
        '        Return Me._txtSrchSiteAddr
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchSiteAddr Is Nothing
        '        Me._txtSrchSiteAddr = value
        '        Me._txtSrchSiteAddr Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchSiteID As TextBox
        '    Get
        '        Return Me._txtSrchSiteID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchSiteID Is Nothing
        '        Me._txtSrchSiteID = value
        '        Me._txtSrchSiteID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtState As TextBox
        '    Get
        '        Return Me._txtState
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtState Is Nothing
        '        Me._txtState = value
        '        Me._txtState Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtZipCode As TextBox
        '    Get
        '        Return Me._txtZipCode
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtZipCode Is Nothing
        '        Me._txtZipCode = value
        '        Me._txtZipCode Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property UWGSite As UltraWebGrid
        '    Get
        '        Return Me._UWGSite
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UWGSite IsNot Nothing) Then
        '            Dim _site As site = Me
        '            RemoveHandler Me._UWGSite.InitializeRow, New InitializeRowEventHandler(AddressOf _site.UWGSite_InitializeRow)
        '        End If
        '        Me._UWGSite = value
        '        If (Me._UWGSite IsNot Nothing) Then
        '            Dim _site1 As site = Me
        '            AddHandler Me._UWGSite.InitializeRow, New InitializeRowEventHandler(AddressOf _site1.UWGSite_InitializeRow)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim _site As site = Me
            'MyBase.add_Init(New EventHandler(_site, _site.Page_Init))
            Dim _site1 As site = Me
            'MyBase.add_Load(New EventHandler(_site1, _site1.Page_Load))
            Me.uccSite = New UCCSite()
            Me.isChild = False
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Dim str As String = String.Concat("<script language=""javascript"">", "window.close();")
            str = String.Concat(str, "</script>")
            Me.Page().RegisterClientScriptBlock("", str)
        End Sub

        Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNew.Click
            Me.setDefaultValues()
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            If (Me.txtSiteID.Text().Length() <> 0) Then
                Me.updateSite()
            Else
                Me.createSite()
            End If
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            Me.setDefaultValues()
            messageHelper = Me.searchSite(Microsoft.VisualBasic.Strings.Trim(Me.txtSrchSiteAddr.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtSrchSiteID.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtSrchOccClient.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtSrchBillClient.Text()))
            messageHelper.status = True
            If (messageHelper.status) Then
                Me.UWGSite.DisplayLayout.ViewType = ViewType.Flat
                Me.UWGSite.DataSource = (Me.rdr)
                Me.UWGSite.DataBind()
                If (Me.UWGSite.Rows.Count() = 0) Then
                    messageHelper.messageText = "No Records Found for Search Criteria"
                End If
            End If
            Me.lblErrorMsg.Text = (messageHelper.messageText)
        End Sub

        Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelect.Click
            If (Me.isChild) Then
                If (StringType.StrCmp(Me.fromParent, "2", False) <> 0) Then
                    Dim str As String = String.Concat("<script language=""javascript"">", "window.close();")
                    str = String.Concat(str, "</script>")
                    Me.Page().RegisterClientScriptBlock("", str)
                Else
                    Dim str1 As String = "<script language=""javascript"">"
                    str1 = String.Concat(str1, "window.opener.", Me.Parent().Page().GetPostBackEventReference(Me.Page()), ";window.close();")
                    str1 = String.Concat(str1, "</script>")
                    Me.Page().RegisterClientScriptBlock("", str1)
                End If
            End If
        End Sub

        Private Function buildStartDate(ByVal inputDate As System.DateTime, ByVal time As Integer) As System.DateTime
            Dim dateTime As System.DateTime = New System.DateTime(inputDate.Year(), inputDate.Month(), inputDate.Day(), time, 0, 1)
            Return dateTime
        End Function

        Private Function createJob() As SystemFramework.MessageHelper
            Dim uCCJob As BusinessService.UCCJob = New BusinessService.UCCJob()
            Dim dateTime As System.DateTime = Me.buildStartDate(System.DateTime.Now(), 0)
            Dim messageHelper As SystemFramework.MessageHelper = uCCJob.createJob(0, IntegerType.FromString(Me.txtSiteID.Text()), 0, 0, "", "", dateTime, dateTime, Decimal.Zero, Decimal.Zero, Decimal.Zero, Decimal.Zero, "O", "", MyBase.[Operator].userId, MyBase.[Operator].userId)
            Return messageHelper
        End Function

        Private Sub createSite()
            Dim messageHelper As SystemFramework.MessageHelper = Me.createSiteAll()
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text = (messageHelper.messageText)
            Else
                Me.getSite(StringType.FromObject(messageHelper.messageObject))
                If (Me.isChild) Then
                    If (StringType.StrCmp(Me.fromParent, "2", False) = 0) Then
                        messageHelper = Me.createJob()
                        If (Not messageHelper.status) Then
                            Me.lblErrorMsg.Text = (messageHelper.messageText)
                        Else
                            Dim str As String = "<script language=""javascript"">"
                            str = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(String.Concat(str, "window.opener.setNewJobId("), messageHelper.messageObject), ");"))
                            str = String.Concat(str, "window.opener.", Me.Parent().Page().GetPostBackEventReference(Me.Page()), ";window.close();")
                            str = String.Concat(str, "</script>")
                            Me.Page().RegisterClientScriptBlock("", str)
                        End If
                    End If
                End If
            End If
        End Sub

        Private Function createSiteAll() As SystemFramework.MessageHelper
            Dim num As Integer = IIf(chkActive.Checked, 1, 0)
            Dim num1 As Integer = Func.CastToInt(txtBillClientID.Text, 0)
            Dim num2 As Integer = Func.CastToInt(txtNoStories.Text, 0)
            Dim num3 As Integer = IIf(chkNoteType.Checked, 1, 0)
            Dim num4 As Integer = Func.CastToInt(txtOccClientID.Text, 0)
            Dim num5 As Integer = Func.CastToInt(txtSiteAddressID.Text, 0)
            'num5 = IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtSiteAddressID.Text()).Length() <> 0, IntegerType.FromString(Me.txtSiteAddressID.Text()), 0)
            'num4 = IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtOccClientID.Text()).Length() <> 0, IntegerType.FromString(Me.txtOccClientID.Text()), 0)
            'num1 = IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtBillClientID.Text()).Length() <> 0, IntegerType.FromString(Me.txtBillClientID.Text()), 0)
            'num2 = IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtNoStories.Text()).Length() <> 0, IntegerType.FromString(Me.txtNoStories.Text()), 0)
            'num3 = IIf(Not Me.chkNoteType.Checked(), 0, 1)
            'num = IIf(Not Me.chkActive.Checked(), 0, 1)
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccSite.createSite(num4, num1, num5, num2, num3, Func.CastToStr(txtNotes.Text), Me.lstSource.SelectedItem().Value(), Me.lstCallBackMethod.SelectedItem().Value(), num, MyBase.[Operator].userId, MyBase.[Operator].userId)
            Return messageHelper
        End Function

        Private Function getClient(ByVal clientId As Integer) As SqlDataReader
            Dim clientById As SqlDataReader = (New UCCClient()).getClientById(clientId)
            clientById.Read()
            Return clientById
        End Function

        Private Sub getSite(ByVal site_id As String)
            Dim client As SqlDataReader
            Dim dateTime As System.DateTime = New System.DateTime()
            Me.rdr = Me.uccSite.getSiteById(IntegerType.FromString(site_id))
            Me.rdr.Read()
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr.Item("OccClient_ID")))) Then
                Me.txtOccClientID.Text = (StringType.FromObject(Me.rdr.Item("OccClient_ID")))
                client = Me.getClient(IntegerType.FromString(Me.txtOccClientID.Text()))
                Me.txtOccClientFirst.Text = (StringType.FromObject(client.Item("First_Name")))
                Me.txtOccClientLast.Text = (StringType.FromObject(client.Item("Last_Name")))
                client.Close()
            Else
                Me.txtOccClientID.Text = ("")
                Me.txtOccClientFirst.Text = ("")
                Me.txtOccClientLast.Text = ("")
            End If
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr.Item("BillClient_ID")))) Then
                Me.txtBillClientID.Text = (StringType.FromObject(Me.rdr.Item("BillClient_ID")))
                client = Me.getClient(IntegerType.FromString(Me.txtBillClientID.Text()))
                Me.txtBillClientFirst.Text = (StringType.FromObject(client.Item("First_Name")))
                Me.txtBillClientLast.Text = (StringType.FromObject(client.Item("Last_Name")))
                client.Close()
            Else
                Me.txtBillClientID.Text = ("")
                Me.txtBillClientFirst.Text = ("")
                Me.txtBillClientLast.Text = ("")
            End If
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr.Item("SiteAddress_ID")))) Then
                Me.txtSiteAddressID.Text = (StringType.FromObject(Me.rdr.Item("SiteAddress_ID")))
                Me.setAddress(IntegerType.FromString(Me.txtSiteAddressID.Text()))
            Else
                Me.txtSiteAddressID.Text = ("")
                Me.txtSiteAddr1.Text = ("")
                Me.txtCity.Text = ("")
                Me.txtState.Text = ("")
                Me.txtZipCode.Text = ("")
            End If
            Me.txtSiteID.Text = site_id
            Me.txtNoStories.Text = (StringType.FromObject(Me.rdr.Item("No_Stories")))
            Me.txtNotes.Text = (StringType.FromObject(Me.rdr.Item("Notes")))
            If (Not Me.setDropDown(Me.lstSource, Microsoft.VisualBasic.Strings.Trim(StringType.FromObject(Me.rdr.Item("Source"))))) Then
                Me.lstSource.SelectedIndex = (0)
            End If
            Me.setDropDown(Me.lstCallBackMethod, Microsoft.VisualBasic.Strings.Trim(StringType.FromObject(Me.rdr.Item("CallBack_Method"))))
            If (Not BooleanType.FromObject(Me.rdr.Item("Active"))) Then
                Me.chkActive.Checked = (False)
            Else
                Me.chkActive.Checked = (True)
            End If
            If (Not BooleanType.FromObject(Me.rdr.Item("Note_Type"))) Then
                Me.chkNoteType.Checked = (False)
            Else
                Me.chkNoteType.Checked = (True)
            End If
            dateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
            Me.txtCreateDate.Text = (dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtCreateUser.Text = (StringType.FromObject(Me.rdr.Item("Create_User")))
            dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
            Me.txtModifiedDate.Text = (dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtModifiedUser.Text = (StringType.FromObject(Me.rdr.Item("Modified_User")))
        End Sub

        '<DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub loadListBoxes()
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Source")
            Me.lstSource.DataSource = (Me.rdr)
            Me.lstSource.DataValueField = ("Element_ID")
            Me.lstSource.DataTextField = ("Element_Description")
            Me.lstSource.DataBind()
            Me.lstSource.Items().Insert(0, New ListItem("", ""))
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("CallBack Method")
            Me.lstCallBackMethod.DataSource = (Me.rdr)
            Me.lstCallBackMethod.DataValueField = ("Element_ID")
            Me.lstCallBackMethod.DataTextField = ("Element_Description")
            Me.lstCallBackMethod.DataBind()
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim str As String = "<script language=""javascript"">"
            Dim num As Integer = 270
            str = String.Concat(str, "function isMaxLength(txtBox) {")
            str = String.Concat(str, " if(txtBox) { ")
            str = String.Concat(str, "     return ( txtBox.value.length <=", StringType.FromInteger(num), ");")
            str = String.Concat(str, " }")
            str = String.Concat(str, "}")
            str = String.Concat(str, "</script>")
            Me.txtNotes.Attributes().Add("onkeypress", "return isMaxLength(this);")
            If (Not Me.Page().IsClientScriptBlockRegistered("lengthEdit")) Then
                Me.Page().RegisterClientScriptBlock("lengthEdit", str)
            End If
            If (Me.Page().IsPostBack()) Then
                Me.isChild = BooleanType.FromObject(Me.ViewState().Item("isChild"))
                Me.fromParent = StringType.FromObject(Me.ViewState().Item("fromParent"))
                ''VIN''               ' Not Me.isChild
            Else
                Me.loadListBoxes()
                Me.setDefaultValues()
                Me.txtSiteID.Text = ("")
                Dim item As String = Me.Parent().Page().Request().Item("Site_ID")
                Me.fromParent = Me.Parent().Page().Request().Item("From_Parent")
                If (Me.fromParent IsNot Nothing) Then
                    Me.isChild = True
                    item = Me.Parent().Page().Request().Item("Site_ID")
                    If (item.Length() > 0) Then
                        Me.getSite(item)
                    End If
                End If
                Me.ViewState().Item("isChild") = Me.isChild
                Me.ViewState().Item("fromParent") = Me.fromParent
            End If
            Me.lblErrorMsg.Text = ("")
        End Sub

        Public Function searchSite(ByVal address1 As String, ByVal site_id As String, ByVal OccClient As String, ByVal BillClient As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateCriteria(address1, site_id, OccClient, BillClient)
            If (messageHelper.status) Then
                Dim str As String = messageHelper.messageId
                If (StringType.StrCmp(str, "A", False) = 0) Then
                    Me.rdr = Me.uccSite.getSiteByAddress1(address1)
                ElseIf (StringType.StrCmp(str, "S", False) = 0) Then
                    Me.rdr = Me.uccSite.getSiteById(IntegerType.FromString(site_id))
                ElseIf (StringType.StrCmp(str, "O", False) = 0) Then
                    Me.rdr = Me.uccSite.getSiteByOccClient(OccClient)
                ElseIf (StringType.StrCmp(str, "B", False) = 0) Then
                    Me.rdr = Me.uccSite.getSiteByBillClient(BillClient)
                End If
                messageHelper.status = True
                messageHelper.messageObject = Me.rdr
            End If
            Return messageHelper
        End Function

        Private Sub setAddress(ByVal addressId As Integer)
            Dim addressById As SqlDataReader = (New UCCAddress()).getAddressById(addressId)
            addressById.Read()
            Me.txtSiteAddr1.Text = (StringType.FromObject(addressById.Item("Address1")))
            Me.txtCity.Text = (StringType.FromObject(addressById.Item("City")))
            Me.txtState.Text = (StringType.FromObject(addressById.Item("State")))
            Me.txtZipCode.Text = (StringType.FromObject(addressById.Item("ZipCode")))
            addressById.Close()
        End Sub

        Private Sub setDefaultValues()
            Me.chkActive.Checked = (True)
            Me.chkNoteType.Checked = (False)
            Me.txtSiteID.Text = ("")
            Me.txtSiteAddr1.Text = ("")
            Me.txtCity.Text = ("")
            Me.txtState.Text = ("")
            Me.txtZipCode.Text = ("")
            Me.txtOccClientID.Text = ("")
            Me.txtBillClientID.Text = ("")
            Me.txtSiteAddressID.Text = ("")
            Me.txtOccClientFirst.Text = ("")
            Me.txtOccClientLast.Text = ("")
            Me.txtBillClientFirst.Text = ("")
            Me.txtBillClientLast.Text = ("")
            Me.txtNoStories.Text = ("2")
            Me.txtNotes.Text = ("")
            Me.txtModifiedUser.Text = ("")
            Me.txtModifiedDate.Text = ("")
            Me.txtCreateUser.Text = ("")
            Me.txtCreateDate.Text = ("")
            Me.setDropDown(Me.lstSource, "REF")
            Me.setDropDown(Me.lstCallBackMethod, "NC120")   ' Changed from NC90 [vin]
        End Sub

        Private Function setDropDown(ByVal list As DropDownList, ByVal item As String) As Boolean
            Dim num As Integer = 0
            Dim enumerator As IEnumerator = Nothing
            Dim flag As Boolean = False
            Try
                enumerator = list.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (StringType.StrCmp(current.Value(), item, False) <> 0) Then
                        num = num + 1
                    Else
                        list.SelectedIndex = (num)
                        current.Selected = (True)
                        flag = True
                        Return flag
                    End If
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Return flag
        End Function

        Private Sub txtOccClientID_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOccClientID.TextChanged
        End Sub

        Private Sub updateSite()
            Dim num As Integer
            Dim messageHelper As SystemFramework.MessageHelper = Me.updateSiteAll()
            Me.getSite(Me.txtSiteID.Text())
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text = (messageHelper.messageText)
            Else
                Me.getSite(Me.txtSiteID.Text())
                If (Me.isChild) Then
                    If (StringType.StrCmp(Me.fromParent, "2", False) <> 0) Then
                        Dim str As String = "<script language=""javascript"">"
                        str = String.Concat(str, "window.opener.setSite(")
                        str = String.Concat(str, Me.txtSiteID.Text(), ",")
                        str = String.Concat(String.Concat(str, """", Microsoft.VisualBasic.Strings.Trim(Me.txtNoStories.Text())), """,")
                        str = String.Concat(String.Concat(str, """", Microsoft.VisualBasic.Strings.Trim(Me.txtNotes.Text())), """,")
                        num = If(Not Me.chkNoteType.Checked(), 0, 1)
                        str = String.Concat(str, StringType.FromInteger(num))
                        str = String.Concat(str, ");window.close();")
                        str = String.Concat(str, "</script>")
                        Me.Page().RegisterClientScriptBlock("", str)
                    Else
                        Dim str1 As String = "<script language=""javascript"">"
                        str1 = String.Concat(str1, "window.opener.", Me.Parent().Page().GetPostBackEventReference(Me.Page()), ";window.close();")
                        str1 = String.Concat(str1, "</script>")
                        Me.Page().RegisterClientScriptBlock("", str1)
                    End If
                End If
            End If
        End Sub

        Private Function updateSiteAll() As SystemFramework.MessageHelper
            Dim num As Integer = IIf(chkActive.Checked, 1, 0)
            Dim num1 As Integer = Func.CastToInt(txtBillClientID, 0)
            Dim num2 As Integer = IIf(chkNoteType.Checked, 1, 0)
            Dim num3 As Integer = Func.CastToInt(txtOccClientID.Text, 0)
            Dim num4 As Integer = Func.CastToInt(txtSiteAddressID.Text, 0)
            'num4 = IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtSiteAddressID.Text()).Length() <> 0, IntegerType.FromString(Me.txtSiteAddressID.Text()), 0)
            'num3 = IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtOccClientID.Text()).Length() <> 0, IntegerType.FromString(Me.txtOccClientID.Text()), 0)
            'num1 = IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtBillClientID.Text()).Length() <> 0, IntegerType.FromString(Me.txtBillClientID.Text()), 0)
            'num2 = If(Not Me.chkNoteType.Checked(), 0, 1)
            'num = If(Not Me.chkActive.Checked(), 0, 1)
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccSite.updateSiteAll(Func.CastToInt(Me.txtSiteID.Text, 0), num3, num1, num4, Func.CastToInt(Func.CastToStr(txtNoStories.Text), 0), num2, Func.CastToStr(txtNotes.Text()).Trim(), Me.lstSource.SelectedItem().Value(), Me.lstCallBackMethod.SelectedItem().Value(), num, MyBase.[Operator].userId, DateType.FromString(Me.txtModifiedDate.Text()))
            Return messageHelper
        End Function

        Private Sub UWGSite_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGSite.InitializeRow
            Dim dateTime As System.DateTime = New System.DateTime()
            dateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
            e.Row.Cells.FromKey("Create_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
            dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
            e.Row.Cells.FromKey("Modified_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
        End Sub

        Private Function validateCriteria(ByVal address1 As String, ByVal site_id As String, ByVal OccClient As String, ByVal BillClient As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (address1.Length() > 0) Then
                If (Not (site_id.Length() > 0 Or OccClient.Length() > 0 Or BillClient.Length() > 0)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "A"
                Else
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.messageText = "Address is mutually exclusive with others"
                End If
            ElseIf (site_id.Length() > 0) Then
                If (address1.Length() > 0 Or OccClient.Length() > 0 Or BillClient.Length() > 0) Then
                    messageHelper.messageId = StringType.FromInteger(2)
                    messageHelper.messageText = "Site ID is mutually exclusive with others"
                ElseIf (Information.IsNumeric(site_id)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "S"
                Else
                    messageHelper.messageId = StringType.FromInteger(12)
                    messageHelper.messageText = "Invalid Site ID"
                End If
            ElseIf (OccClient.Length() > 0) Then
                If (Not (address1.Length() > 0 Or site_id.Length() > 0 Or BillClient.Length() > 0)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "O"
                Else
                    messageHelper.messageId = StringType.FromInteger(3)
                    messageHelper.messageText = "Occ Client is mutually exclusive with others"
                End If
            ElseIf (BillClient.Length() > 0) Then
                If (Not (address1.Length() > 0 Or site_id.Length() > 0 Or OccClient.Length() > 0)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "B"
                Else
                    messageHelper.messageId = StringType.FromInteger(4)
                    messageHelper.messageText = "Bill Client is mutually exclusive with others"
                End If
            End If
            Return messageHelper
        End Function
    End Class
End Namespace