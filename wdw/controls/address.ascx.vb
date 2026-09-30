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

Public MustInherit Class address
    Inherits wdw.ControlBase

    '<AccessedThroughProperty("Label1")>
    'Private _Label1 As Label

    '<AccessedThroughProperty("lstHiddenZipCity")>
    'Private _lstHiddenZipCity As ListBox

    '<AccessedThroughProperty("pnlMore")>
    'Private _pnlMore As Panel

    '<AccessedThroughProperty("txtModifiedDate")>
    'Private _txtModifiedDate As TextBox

    '<AccessedThroughProperty("txtSrchAddr1")>
    'Private _txtSrchAddr1 As TextBox

    '<AccessedThroughProperty("txtModifiedUser")>
    'Private _txtModifiedUser As TextBox

    '<AccessedThroughProperty("txtCreateDate")>
    'Private _txtCreateDate As TextBox

    '<AccessedThroughProperty("txtCreateUser")>
    'Private _txtCreateUser As TextBox

    '<AccessedThroughProperty("txtAddressID")>
    'Private _txtAddressID As TextBox

    '<AccessedThroughProperty("TextBox1")>
    'Private _TextBox1 As TextBox

    '<AccessedThroughProperty("t")>
    'Private _t As TextBox

    '<AccessedThroughProperty("Label18")>
    'Private _Label18 As Label

    '<AccessedThroughProperty("btnCancel")>
    'Private _btnCancel As Button

    '<AccessedThroughProperty("btnSave")>
    'Private _btnSave As Button

    '<AccessedThroughProperty("btnSelect")>
    'Private _btnSelect As Button

    '<AccessedThroughProperty("Label17")>
    'Private _Label17 As Label

    '<AccessedThroughProperty("Label16")>
    'Private _Label16 As Label

    '<AccessedThroughProperty("Label2")>
    'Private _Label2 As Label

    '<AccessedThroughProperty("Label15")>
    'Private _Label15 As Label

    '<AccessedThroughProperty("Label14")>
    'Private _Label14 As Label

    '<AccessedThroughProperty("txtCounty")>
    'Private _txtCounty As TextBox

    '<AccessedThroughProperty("txtSrchAddr2")>
    'Private _txtSrchAddr2 As TextBox

    '<AccessedThroughProperty("Label13")>
    'Private _Label13 As Label

    '<AccessedThroughProperty("txtCountry")>
    'Private _txtCountry As TextBox

    '<AccessedThroughProperty("Label12")>
    'Private _Label12 As Label

    '<AccessedThroughProperty("txtAddr1")>
    'Private _txtAddr1 As TextBox

    '<AccessedThroughProperty("txtZip")>
    'Private _txtZip As TextBox

    '<AccessedThroughProperty("Label8")>
    'Private _Label8 As Label

    '<AccessedThroughProperty("Label7")>
    'Private _Label7 As Label

    '<AccessedThroughProperty("Label6")>
    'Private _Label6 As Label

    '<AccessedThroughProperty("Label5")>
    'Private _Label5 As Label

    '<AccessedThroughProperty("lblErrorMsg")>
    'Private _lblErrorMsg As Label

    '<AccessedThroughProperty("UWGAddress")>
    'Private _UWGAddress As UltraWebGrid

    '<AccessedThroughProperty("btnNew")>
    'Private _btnNew As Button

    '<AccessedThroughProperty("btnSearch")>
    'Private _btnSearch As Button

    '<AccessedThroughProperty("txtSrchAddrId")>
    'Private _txtSrchAddrId As TextBox

    '<AccessedThroughProperty("Label4")>
    'Private _Label4 As Label

    '<AccessedThroughProperty("txtSrchCareOf")>
    'Private _txtSrchCareOf As TextBox

    '<AccessedThroughProperty("Label11")>
    'Private _Label11 As Label

    '<AccessedThroughProperty("Label3")>
    'Private _Label3 As Label

    '<AccessedThroughProperty("txtAddr2")>
    'Private _txtAddr2 As TextBox

    '<AccessedThroughProperty("txtAddr3")>
    'Private _txtAddr3 As TextBox

    '<AccessedThroughProperty("chkActive")>
    'Private _chkActive As CheckBox

    '<AccessedThroughProperty("txtCity")>
    'Private _txtCity As TextBox

    '<AccessedThroughProperty("Label9")>
    'Private _Label9 As Label

    '<AccessedThroughProperty("txtCareOf")>
    'Private _txtCareOf As TextBox

    '<AccessedThroughProperty("Label10")>
    'Private _Label10 As Label

    '<AccessedThroughProperty("lstState")>
    'Private _lstState As DropDownList

    Private uccAddress As UCCAddress

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
    '            Dim _address As address = Me
    '            Me._btnCancel.remove_Click(New EventHandler(_address, _address.btnCancel_Click))
    '        End If
    '        Me._btnCancel = value
    '        If (Me._btnCancel IsNot Nothing) Then
    '            Dim _address1 As address = Me
    '            Me._btnCancel.add_Click(New EventHandler(_address1, _address1.btnCancel_Click))
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
    '            Dim _address As address = Me
    '            Me._btnNew.remove_Click(New EventHandler(_address, _address.btnNewClient_Click))
    '        End If
    '        Me._btnNew = value
    '        If (Me._btnNew IsNot Nothing) Then
    '            Dim _address1 As address = Me
    '            Me._btnNew.add_Click(New EventHandler(_address1, _address1.btnNewClient_Click))
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
    '            Dim _address As address = Me
    '            Me._btnSave.remove_Click(New EventHandler(_address, _address.btnSave_Click))
    '        End If
    '        Me._btnSave = value
    '        If (Me._btnSave IsNot Nothing) Then
    '            Dim _address1 As address = Me
    '            Me._btnSave.add_Click(New EventHandler(_address1, _address1.btnSave_Click))
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
    '            Dim _address As address = Me
    '            Me._btnSearch.remove_Click(New EventHandler(_address, _address.btnSearch_Click))
    '        End If
    '        Me._btnSearch = value
    '        If (Me._btnSearch IsNot Nothing) Then
    '            Dim _address1 As address = Me
    '            Me._btnSearch.add_Click(New EventHandler(_address1, _address1.btnSearch_Click))
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
    '            Dim _address As address = Me
    '            Me._btnSelect.remove_Click(New EventHandler(_address, _address.btnSelect_Click))
    '        End If
    '        Me._btnSelect = value
    '        If (Me._btnSelect IsNot Nothing) Then
    '            Dim _address1 As address = Me
    '            Me._btnSelect.add_Click(New EventHandler(_address1, _address1.btnSelect_Click))
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

    'Protected Overridable Property Label13 As Label
    '    Get
    '        Return Me._Label13
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As Label)
    '        Me._Label13 Is Nothing
    '        Me._Label13 = value
    '        Me._Label13 Is Nothing
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

    'Protected Overridable Property Label15 As Label
    '    Get
    '        Return Me._Label15
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As Label)
    '        Me._Label15 Is Nothing
    '        Me._Label15 = value
    '        Me._Label15 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property Label16 As Label
    '    Get
    '        Return Me._Label16
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As Label)
    '        Me._Label16 Is Nothing
    '        Me._Label16 = value
    '        Me._Label16 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property Label17 As Label
    '    Get
    '        Return Me._Label17
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As Label)
    '        Me._Label17 Is Nothing
    '        Me._Label17 = value
    '        Me._Label17 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property Label18 As Label
    '    Get
    '        Return Me._Label18
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As Label)
    '        Me._Label18 Is Nothing
    '        Me._Label18 = value
    '        Me._Label18 Is Nothing
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

    'Protected Overridable Property Label3 As Label
    '    Get
    '        Return Me._Label3
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As Label)
    '        Me._Label3 Is Nothing
    '        Me._Label3 = value
    '        Me._Label3 Is Nothing
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

    'Protected Overridable Property lstHiddenZipCity As ListBox
    '    Get
    '        Return Me._lstHiddenZipCity
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As ListBox)
    '        Me._lstHiddenZipCity Is Nothing
    '        Me._lstHiddenZipCity = value
    '        Me._lstHiddenZipCity Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property lstState As DropDownList
    '    Get
    '        Return Me._lstState
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As DropDownList)
    '        Me._lstState Is Nothing
    '        Me._lstState = value
    '        Me._lstState Is Nothing
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

    'Protected Overridable Property t As TextBox
    '    Get
    '        Return Me._t
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._t Is Nothing
    '        Me._t = value
    '        Me._t Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property TextBox1 As TextBox
    '    Get
    '        Return Me._TextBox1
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._TextBox1 Is Nothing
    '        Me._TextBox1 = value
    '        Me._TextBox1 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtAddr1 As TextBox
    '    Get
    '        Return Me._txtAddr1
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtAddr1 Is Nothing
    '        Me._txtAddr1 = value
    '        Me._txtAddr1 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtAddr2 As TextBox
    '    Get
    '        Return Me._txtAddr2
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtAddr2 Is Nothing
    '        Me._txtAddr2 = value
    '        Me._txtAddr2 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtAddr3 As TextBox
    '    Get
    '        Return Me._txtAddr3
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtAddr3 Is Nothing
    '        Me._txtAddr3 = value
    '        Me._txtAddr3 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtAddressID As TextBox
    '    Get
    '        Return Me._txtAddressID
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtAddressID Is Nothing
    '        Me._txtAddressID = value
    '        Me._txtAddressID Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtCareOf As TextBox
    '    Get
    '        Return Me._txtCareOf
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtCareOf Is Nothing
    '        Me._txtCareOf = value
    '        Me._txtCareOf Is Nothing
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

    'Protected Overridable Property txtCountry As TextBox
    '    Get
    '        Return Me._txtCountry
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtCountry Is Nothing
    '        Me._txtCountry = value
    '        Me._txtCountry Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtCounty As TextBox
    '    Get
    '        Return Me._txtCounty
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtCounty Is Nothing
    '        Me._txtCounty = value
    '        Me._txtCounty Is Nothing
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

    'Protected Overridable Property txtSrchAddr1 As TextBox
    '    Get
    '        Return Me._txtSrchAddr1
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtSrchAddr1 Is Nothing
    '        Me._txtSrchAddr1 = value
    '        Me._txtSrchAddr1 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtSrchAddr2 As TextBox
    '    Get
    '        Return Me._txtSrchAddr2
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtSrchAddr2 Is Nothing
    '        Me._txtSrchAddr2 = value
    '        Me._txtSrchAddr2 Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtSrchAddrId As TextBox
    '    Get
    '        Return Me._txtSrchAddrId
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtSrchAddrId Is Nothing
    '        Me._txtSrchAddrId = value
    '        Me._txtSrchAddrId Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtSrchCareOf As TextBox
    '    Get
    '        Return Me._txtSrchCareOf
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtSrchCareOf Is Nothing
    '        Me._txtSrchCareOf = value
    '        Me._txtSrchCareOf Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property txtZip As TextBox
    '    Get
    '        Return Me._txtZip
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As TextBox)
    '        Me._txtZip Is Nothing
    '        Me._txtZip = value
    '        Me._txtZip Is Nothing
    '    End Set
    'End Property

    'Protected Overridable Property UWGAddress As UltraWebGrid
    '    Get
    '        Return Me._UWGAddress
    '    End Get
    '    <MethodImpl(32)>
    '    Set(ByVal value As UltraWebGrid)
    '        If (Me._UWGAddress IsNot Nothing) Then
    '            Dim _address As address = Me
    '            RemoveHandler Me._UWGAddress.InitializeRow, New InitializeRowEventHandler(AddressOf _address.UWGClient_InitializeRow)
    '        End If
    '        Me._UWGAddress = value
    '        If (Me._UWGAddress IsNot Nothing) Then
    '            Dim _address1 As address = Me
    '            AddHandler Me._UWGAddress.InitializeRow, New InitializeRowEventHandler(AddressOf _address1.UWGClient_InitializeRow)
    '        End If
    '    End Set
    'End Property

    Public Sub New()
        MyBase.New()
        Dim _address As address = Me
        'MyBase.add_Init(New EventHandler(_address, _address.Page_Init))
        Dim _address1 As address = Me
        'MyBase.add_Load(New EventHandler(_address1, _address1.Page_Load))
        Me.uccAddress = New UCCAddress()
        Me.isChild = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Dim str As String = String.Concat("<script language=""javascript"">", "window.close();")
        str = String.Concat(str, "</script>")
        Page().RegisterClientScriptBlock("", str)
    End Sub

    Private Sub btnNewClient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNew.Click
        Me.setDefaultValues()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If (Me.txtAddressID.Text().Length() <> 0) Then
            Me.updateAddress()
        Else
            Me.createAddress()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
        messageHelper.status = False

        Me.setDefaultValues()
        messageHelper = Me.searchAddress(txtSrchAddr1.Text.Trim(), txtSrchAddr2.Text.Trim(), txtSrchCareOf.Text.Trim(), txtSrchAddrId.Text.Trim())
        If (messageHelper.status) Then
            Me.UWGAddress.DisplayLayout.ViewType = ViewType.Flat
            Me.UWGAddress.DataSource = (RuntimeHelpers.GetObjectValue(messageHelper.messageObject))
            Me.UWGAddress.DataBind()
            If (Me.UWGAddress.Rows.Count() = 0) Then
                messageHelper.messageText = "No Records Found for Search Criteria"
            End If
        End If
        Me.lblErrorMsg.Text = (messageHelper.messageText)
    End Sub

    Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelect.Click
        Dim str As String = "<script language=""javascript"">"
        str = If(StringType.StrCmp(Me.fromParent, "3", False) <> 0, String.Concat(str, "window.opener.setAddress("), String.Concat(str, "window.opener.setAlternateAddress("))
        str = String.Concat(str, Me.txtAddressID.Text(), ", ")
        str = String.Concat(String.Concat(str, """", Me.txtAddr1.Text()), """, ")
        str = String.Concat(String.Concat(str, """", Me.txtCity.Text()), """, ")
        str = String.Concat(String.Concat(str, """", Me.lstState.SelectedItem().Value), """, ")
        str = String.Concat(str, """", Me.txtZip.Text(), """")
        str = String.Concat(str, ");window.close();")
        str = String.Concat(str, "</script>")
        Me.Page().RegisterClientScriptBlock("", str)
    End Sub

    Private Sub createAddress()
        Dim messageHelper As SystemFramework.MessageHelper = Me.createAddressAll()
        If (Not messageHelper.status) Then
            Me.lblErrorMsg.Text = (messageHelper.messageText)
        Else
            Me.getAddress(StringType.FromObject(messageHelper.messageObject))
            If (Me.isChild) Then
                Dim str As String = "<script language=""javascript"">"
                str = If(StringType.StrCmp(Me.fromParent, "3", False) <> 0, String.Concat(str, "window.opener.setAddress("), String.Concat(str, "window.opener.setAlternateAddress("))
                str = String.Concat(str, Me.txtAddressID.Text(), ", ")
                str = String.Concat(String.Concat(str, """", Me.txtAddr1.Text()), """, ")
                str = String.Concat(String.Concat(str, """", Me.txtCity.Text()), """, ")
                str = String.Concat(String.Concat(str, """", Me.lstState.SelectedItem().Value), """, ")
                str = String.Concat(str, """", Me.txtZip.Text(), """")
                str = String.Concat(str, ");window.close();")
                str = String.Concat(str, "</script>")
                Me.Page().RegisterClientScriptBlock("", str)
            End If
        End If
    End Sub

    Private Function createAddressAll() As SystemFramework.MessageHelper
        Dim num As Integer
        num = If(Not Me.chkActive.Checked, 0, 1)
        Dim messageHelper As SystemFramework.MessageHelper = Me.uccAddress.createAddress(Microsoft.VisualBasic.Strings.Trim(Me.txtCareOf.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtAddr1.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtAddr2.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtAddr3.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtCity.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtCounty.Text()), Me.lstState.SelectedItem().Value, Microsoft.VisualBasic.Strings.Trim(Me.txtZip.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtCountry.Text()), num, MyBase.[Operator].userId, MyBase.[Operator].userId)
        Return messageHelper
    End Function

    Public Sub getAddress(ByVal address_id As String)
        Dim uCCAddress As BusinessService.UCCAddress = New BusinessService.UCCAddress()
        Me.rdr = uCCAddress.getAddressById(IntegerType.FromString(address_id))
        Me.rdr.Read()
        Me.txtCareOf.Text = (StringType.FromObject(Me.rdr.Item("CareOf")))
        Me.txtAddr1.Text = (StringType.FromObject(Me.rdr.Item("Address1")))
        Me.txtAddr2.Text = (StringType.FromObject(Me.rdr.Item("Address2")))
        Me.txtAddr3.Text = (StringType.FromObject(Me.rdr.Item("Address3")))
        Me.txtAddressID.Text = (address_id)
        Me.txtCity.Text = (StringType.FromObject(Me.rdr.Item("City")))
        Me.txtCounty.Text = (StringType.FromObject(Me.rdr.Item("County")))
        Me.txtCountry.Text = (StringType.FromObject(Me.rdr.Item("Country")))
        Me.txtZip.Text = (StringType.FromObject(Me.rdr.Item("ZipCode")))
        If (Not BooleanType.FromObject(Me.rdr.Item("Active"))) Then
            Me.chkActive.Checked = (False)
        Else
            Me.chkActive.Checked = (True)
        End If
        Dim dateTime As System.DateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
        Me.txtCreateDate.Text = (dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
        Me.txtCreateUser.Text = (StringType.FromObject(Me.rdr.Item("Create_User")))
        dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
        Me.txtModifiedDate.Text = (dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
        Me.txtModifiedUser.Text = (StringType.FromObject(Me.rdr.Item("Modified_User")))
        Me.setDropDown(Me.lstState, Microsoft.VisualBasic.Strings.Trim(StringType.FromObject(Me.rdr.Item("State"))))
        Me.ViewState().Item("isChild") = Me.isChild
    End Sub

    <DebuggerStepThrough>
    Private Sub InitializeComponent()
    End Sub

    Private Sub loadListBoxes()
        Me.rdr = UCCCode.getActiveCodesByCodeDescription("State")
        Me.lstState.DataSource = (Me.rdr)
        Me.lstState.DataValueField = ("Element_ID")
        Me.lstState.DataTextField = ("Element_Description")
        Me.lstState.DataBind()
        Me.rdr = Me.uccAddress.getAreaZip()
        Me.lstHiddenZipCity.DataSource = (Me.rdr)
        Me.lstHiddenZipCity.DataValueField = ("Site_Zip")
        Me.lstHiddenZipCity.DataTextField = ("Site_City")
        Me.lstHiddenZipCity.DataBind()
    End Sub

    Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        Me.InitializeComponent()
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If (Me.Page().IsPostBack()) Then
            Me.isChild = BooleanType.FromObject(Me.ViewState().Item("isChild"))
            Me.fromParent = StringType.FromObject(Me.ViewState().Item("fromParent"))
            If (Me.isChild) Then
                Me.btnSelect.Visible = (True)
            End If
        Else
            Me.loadListBoxes()
            Me.setDefaultValues()
            Me.txtAddressID.Text = ("")
            Me.fromParent = Me.Parent().Page().Request().Item("From_Parent")
            If (Me.fromParent IsNot Nothing) Then
                Me.isChild = True
                Me.btnSelect.Visible = (True)
                Dim item As String = Me.Parent().Page().Request().Item("Address_ID")
                If (item.Length() > 0) Then
                    Me.getAddress(item)
                End If
            End If
            Me.ViewState().Item("isChild") = Me.isChild
            Me.ViewState().Item("fromParent") = Me.fromParent
        End If
        Me.lblErrorMsg.Text = ("")
    End Sub

    Public Function searchAddress(ByVal addr1 As String, ByVal addr2 As String, ByVal careOf As String, ByVal address_id As String) As SystemFramework.MessageHelper
        Dim messageHelper As SystemFramework.MessageHelper = Me.validateCriteria(addr1, addr2, careOf, address_id)
        If (messageHelper.status) Then
            Dim str As String = messageHelper.messageId
            If (StringType.StrCmp(str, "1", False) = 0) Then
                Me.rdr = Me.uccAddress.getAddressByAddressLine1(addr1)
            ElseIf (StringType.StrCmp(str, "2", False) = 0) Then
                Me.rdr = Me.uccAddress.getAddressByAddressLine2(addr2)
            ElseIf (StringType.StrCmp(str, "C", False) = 0) Then
                Me.rdr = Me.uccAddress.getAddressByCareOf(careOf)
            ElseIf (StringType.StrCmp(str, "A", False) = 0) Then
                Me.rdr = Me.uccAddress.getAddressById(IntegerType.FromString(address_id))
            End If
            messageHelper.status = True
            messageHelper.messageObject = Me.rdr
        End If
        Return messageHelper
    End Function

    Private Sub setDefaultValues()
        Me.chkActive.Checked = (True)
        Me.txtAddressID.Text = ("")
        Me.txtAddr1.Text = ("")
        Me.txtAddr2.Text = ("")
        Me.txtAddr3.Text = ("")
        Me.txtCareOf.Text = ("")
        Me.txtCity.Text = ("")
        Me.txtCounty.Text = ("King")
        Me.txtCountry.Text = ("USA")
        Me.txtZip.Text = ("98")
        Me.txtModifiedDate.Text = ("")
        Me.txtModifiedDate.Text = ("")
        Me.txtCreateUser.Text = ("")
        Me.txtCreateDate.Text = ("")
        Me.setDropDown(Me.lstState, "WA")
    End Sub

    Private Function setDropDown(ByVal list As DropDownList, ByVal item As String) As Boolean
        Dim num As Integer = 0
        Dim enumerator As IEnumerator = Nothing
        Dim flag As Boolean = False
        Try
            enumerator = list.Items().GetEnumerator()
            While enumerator.MoveNext()
                Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                If (StringType.StrCmp(current.Value, item, False) <> 0) Then
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

    Private Sub updateAddress()
        Dim messageHelper As SystemFramework.MessageHelper = Me.updateAddressAll()
        Me.getAddress(Me.txtAddressID.Text())
        If (Not messageHelper.status) Then
            Me.lblErrorMsg.Text = (messageHelper.messageText)
        ElseIf (Not Me.isChild) Then
            Me.getAddress(Me.txtAddressID.Text())
        Else
            Dim str As String = "<script language=""javascript"">"
            str = If(StringType.StrCmp(Me.fromParent, "3", False) <> 0, String.Concat(str, "window.opener.setAddress("), String.Concat(str, "window.opener.setAlternateAddress("))
            str = String.Concat(str, Me.txtAddressID.Text(), ", ")
            str = String.Concat(String.Concat(str, """", Me.txtAddr1.Text()), """, ")
            str = String.Concat(String.Concat(str, """", Me.txtCity.Text()), """, ")
            str = String.Concat(String.Concat(str, """", Me.lstState.SelectedItem().Value), """, ")
            str = String.Concat(str, """", Me.txtZip.Text(), """")
            str = String.Concat(str, ");window.close();")
            str = String.Concat(str, "</script>")
            Me.Page().RegisterClientScriptBlock("", str)
        End If
    End Sub

    Private Function updateAddressAll() As SystemFramework.MessageHelper
        Dim num As Integer
        num = If(Not Me.chkActive.Checked, 0, 1)
        Dim messageHelper As SystemFramework.MessageHelper = Me.uccAddress.updateAddressAll(IntegerType.FromString(Me.txtAddressID.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtCareOf.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtAddr1.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtAddr2.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtAddr3.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtCity.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtCounty.Text()), Me.lstState.SelectedItem().Value, Microsoft.VisualBasic.Strings.Trim(Me.txtZip.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtCountry.Text()), num, MyBase.[Operator].userId, DateType.FromString(Me.txtModifiedDate.Text()))
        Return messageHelper
    End Function

    Private Sub UWGClient_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGAddress.InitializeRow
        Dim dateTime As System.DateTime = New System.DateTime()
        dateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
        e.Row.Cells.FromKey("Create_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
        dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
        e.Row.Cells.FromKey("Modified_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
    End Sub

    Private Function validateCriteria(ByVal addr1 As String, ByVal addr2 As String, ByVal careOf As String, ByVal address_id As String) As SystemFramework.MessageHelper
        Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
        messageHelper.status = False

        If (addr1.Length() > 0) Then
            If (Not (addr2.Length() > 0 Or careOf.Length() > 0 Or address_id.Length() > 0)) Then
                messageHelper.status = True
                messageHelper.messageId = "1"
            Else
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.messageText = "Address1 is mutually exclusive with others"
            End If
        ElseIf (address_id.Length() > 0) Then
            If (addr1.Length() > 0 Or careOf.Length() > 0 Or addr2.Length() > 0) Then
                messageHelper.messageId = StringType.FromInteger(2)
                messageHelper.messageText = "Address ID is mutually exclusive with others"
            ElseIf (Information.IsNumeric(address_id)) Then
                messageHelper.status = True
                messageHelper.messageId = "A"
            Else
                messageHelper.messageId = StringType.FromInteger(12)
                messageHelper.messageText = "Invalid Address ID"
            End If
        ElseIf (addr2.Length() > 0) Then
            If (Not (addr1.Length() > 0 Or careOf.Length() > 0 Or address_id.Length() > 0)) Then
                messageHelper.status = True
                messageHelper.messageId = "2"
            Else
                messageHelper.messageId = StringType.FromInteger(4)
                messageHelper.messageText = "Address 2 is mutually exclusive with others"
            End If
        ElseIf (careOf.Length() > 0) Then
            If (Not (addr2.Length() > 0 Or addr1.Length() > 0 Or address_id.Length() > 0)) Then
                messageHelper.status = True
                messageHelper.messageId = "C"
            Else
                messageHelper.messageId = StringType.FromInteger(5)
                messageHelper.messageText = "CareOf is mutually exclusive with others"
            End If
        End If
        Return messageHelper
    End Function
End Class
