Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework
Imports Strings = Microsoft.VisualBasic.Strings

Namespace wdw
    Public MustInherit Class userprofile1
        Inherits ControlBase

        '<AccessedThroughProperty("txtModifiedDate")>
        'Private _txtModifiedDate As TextBox

        '<AccessedThroughProperty("btnSearch")>
        'Private _btnSearch As Button

        '<AccessedThroughProperty("txtModifiedUser")>
        'Private _txtModifiedUser As TextBox

        '<AccessedThroughProperty("lblErrorMsg")>
        'Private _lblErrorMsg As Label

        '<AccessedThroughProperty("Label5")>
        'Private _Label5 As Label

        '<AccessedThroughProperty("txtCreateDate")>
        'Private _txtCreateDate As TextBox

        '<AccessedThroughProperty("pnlMore")>
        'Private _pnlMore As Panel

        '<AccessedThroughProperty("txtCreateUser")>
        'Private _txtCreateUser As TextBox

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("Label6")>
        'Private _Label6 As Label

        '<AccessedThroughProperty("txtuserprofileID")>
        'Private _txtuserprofileID As TextBox

        '<AccessedThroughProperty("lblConfirmPswrd")>
        'Private _lblConfirmPswrd As Label

        '<AccessedThroughProperty("Label7")>
        'Private _Label7 As Label

        '<AccessedThroughProperty("Label18")>
        'Private _Label18 As Label

        '<AccessedThroughProperty("Label4")>
        'Private _Label4 As Label

        '<AccessedThroughProperty("lblPassword")>
        'Private _lblPassword As Label

        '<AccessedThroughProperty("Label3")>
        'Private _Label3 As Label

        '<AccessedThroughProperty("btnCancel")>
        'Private _btnCancel As Button

        '<AccessedThroughProperty("lstCompany")>
        'Private _lstCompany As DropDownList

        '<AccessedThroughProperty("btnSave")>
        'Private _btnSave As Button

        '<AccessedThroughProperty("txtUserId")>
        'Private _txtUserId As TextBox

        '<AccessedThroughProperty("lstDefaultArea")>
        'Private _lstDefaultArea As DropDownList

        '<AccessedThroughProperty("Label17")>
        'Private _Label17 As Label

        '<AccessedThroughProperty("txtPswrdRpt")>
        'Private _txtPswrdRpt As TextBox

        '<AccessedThroughProperty("txtLastName")>
        'Private _txtLastName As TextBox

        '<AccessedThroughProperty("lstRole")>
        'Private _lstRole As DropDownList

        '<AccessedThroughProperty("Label15")>
        'Private _Label15 As Label

        '<AccessedThroughProperty("txtSrchuserprofile")>
        'Private _txtSrchuserprofile As TextBox

        '<AccessedThroughProperty("Label14")>
        'Private _Label14 As Label

        '<AccessedThroughProperty("txtFirstName")>
        'Private _txtFirstName As TextBox

        '<AccessedThroughProperty("txtNewPswrdRpt")>
        'Private _txtNewPswrdRpt As TextBox

        '<AccessedThroughProperty("txtSrchLastName")>
        'Private _txtSrchLastName As TextBox

        '<AccessedThroughProperty("txtNewPswrd")>
        'Private _txtNewPswrd As TextBox

        '<AccessedThroughProperty("Label13")>
        'Private _Label13 As Label

        '<AccessedThroughProperty("txtPassword")>
        'Private _txtPassword As TextBox

        '<AccessedThroughProperty("pnlUserSearch")>
        'Private _pnlUserSearch As Panel

        '<AccessedThroughProperty("Label12")>
        'Private _Label12 As Label

        '<AccessedThroughProperty("lstDefaultFunction")>
        'Private _lstDefaultFunction As DropDownList

        '<AccessedThroughProperty("Label8")>
        'Private _Label8 As Label

        '<AccessedThroughProperty("chkActive")>
        'Private _chkActive As CheckBox

        '<AccessedThroughProperty("btnNew")>
        'Private _btnNew As Button

        '<AccessedThroughProperty("Label9")>
        'Private _Label9 As Label

        '<AccessedThroughProperty("Label10")>
        'Private _Label10 As Label

        '<AccessedThroughProperty("UWGuserprofile")>
        'Private _UWGuserprofile As UltraWebGrid

        '<AccessedThroughProperty("Label11")>
        'Private _Label11 As Label

        Private uccUserProfile As UCCUserprofile

        Private FUNCTIONNAME As String

        Private isAdmin As Boolean

        Private rdr As SqlDataReader

        'Protected Overridable Property btnCancel As Button
        '    Get
        '        Return Me._btnCancel
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnCancel IsNot Nothing) Then
        '            Dim _userprofile1 As userprofile1 = Me
        '            Me._btnCancel.remove_Click(New EventHandler(_userprofile1, _userprofile1.btnCancel_Click))
        '        End If
        '        Me._btnCancel = value
        '        If (Me._btnCancel IsNot Nothing) Then
        '            Dim _userprofile11 As userprofile1 = Me
        '            Me._btnCancel.add_Click(New EventHandler(_userprofile11, _userprofile11.btnCancel_Click))
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
        '            Dim _userprofile1 As userprofile1 = Me
        '            Me._btnNew.remove_Click(New EventHandler(_userprofile1, _userprofile1.btnNew_Click))
        '        End If
        '        Me._btnNew = value
        '        If (Me._btnNew IsNot Nothing) Then
        '            Dim _userprofile11 As userprofile1 = Me
        '            Me._btnNew.add_Click(New EventHandler(_userprofile11, _userprofile11.btnNew_Click))
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
        '            Dim _userprofile1 As userprofile1 = Me
        '            Me._btnSave.remove_Click(New EventHandler(_userprofile1, _userprofile1.btnSave_Click))
        '        End If
        '        Me._btnSave = value
        '        If (Me._btnSave IsNot Nothing) Then
        '            Dim _userprofile11 As userprofile1 = Me
        '            Me._btnSave.add_Click(New EventHandler(_userprofile11, _userprofile11.btnSave_Click))
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
        '            Dim _userprofile1 As userprofile1 = Me
        '            Me._btnSearch.remove_Click(New EventHandler(_userprofile1, _userprofile1.btnSearch_Click))
        '        End If
        '        Me._btnSearch = value
        '        If (Me._btnSearch IsNot Nothing) Then
        '            Dim _userprofile11 As userprofile1 = Me
        '            Me._btnSearch.add_Click(New EventHandler(_userprofile11, _userprofile11.btnSearch_Click))
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

        'Protected Overridable Property lblConfirmPswrd As Label
        '    Get
        '        Return Me._lblConfirmPswrd
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblConfirmPswrd Is Nothing
        '        Me._lblConfirmPswrd = value
        '        Me._lblConfirmPswrd Is Nothing
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

        'Protected Overridable Property lblPassword As Label
        '    Get
        '        Return Me._lblPassword
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblPassword Is Nothing
        '        Me._lblPassword = value
        '        Me._lblPassword Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstCompany As DropDownList
        '    Get
        '        Return Me._lstCompany
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstCompany Is Nothing
        '        Me._lstCompany = value
        '        Me._lstCompany Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstDefaultArea As DropDownList
        '    Get
        '        Return Me._lstDefaultArea
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstDefaultArea Is Nothing
        '        Me._lstDefaultArea = value
        '        Me._lstDefaultArea Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstDefaultFunction As DropDownList
        '    Get
        '        Return Me._lstDefaultFunction
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstDefaultFunction Is Nothing
        '        Me._lstDefaultFunction = value
        '        Me._lstDefaultFunction Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstRole As DropDownList
        '    Get
        '        Return Me._lstRole
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstRole Is Nothing
        '        Me._lstRole = value
        '        Me._lstRole Is Nothing
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

        'Protected Overridable Property pnlUserSearch As Panel
        '    Get
        '        Return Me._pnlUserSearch
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Panel)
        '        Me._pnlUserSearch Is Nothing
        '        Me._pnlUserSearch = value
        '        Me._pnlUserSearch Is Nothing
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

        'Protected Overridable Property txtFirstName As TextBox
        '    Get
        '        Return Me._txtFirstName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtFirstName Is Nothing
        '        Me._txtFirstName = value
        '        Me._txtFirstName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtLastName As TextBox
        '    Get
        '        Return Me._txtLastName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtLastName Is Nothing
        '        Me._txtLastName = value
        '        Me._txtLastName Is Nothing
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

        'Protected Overridable Property txtNewPswrd As TextBox
        '    Get
        '        Return Me._txtNewPswrd
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtNewPswrd Is Nothing
        '        Me._txtNewPswrd = value
        '        Me._txtNewPswrd Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtNewPswrdRpt As TextBox
        '    Get
        '        Return Me._txtNewPswrdRpt
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtNewPswrdRpt Is Nothing
        '        Me._txtNewPswrdRpt = value
        '        Me._txtNewPswrdRpt Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtPassword As TextBox
        '    Get
        '        Return Me._txtPassword
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPassword Is Nothing
        '        Me._txtPassword = value
        '        Me._txtPassword Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtPswrdRpt As TextBox
        '    Get
        '        Return Me._txtPswrdRpt
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPswrdRpt Is Nothing
        '        Me._txtPswrdRpt = value
        '        Me._txtPswrdRpt Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchLastName As TextBox
        '    Get
        '        Return Me._txtSrchLastName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchLastName Is Nothing
        '        Me._txtSrchLastName = value
        '        Me._txtSrchLastName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchuserprofile As TextBox
        '    Get
        '        Return Me._txtSrchuserprofile
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchuserprofile Is Nothing
        '        Me._txtSrchuserprofile = value
        '        Me._txtSrchuserprofile Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtUserId As TextBox
        '    Get
        '        Return Me._txtUserId
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtUserId Is Nothing
        '        Me._txtUserId = value
        '        Me._txtUserId Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtuserprofileID As TextBox
        '    Get
        '        Return Me._txtuserprofileID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtuserprofileID Is Nothing
        '        Me._txtuserprofileID = value
        '        Me._txtuserprofileID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property UWGuserprofile As UltraWebGrid
        '    Get
        '        Return Me._UWGuserprofile
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UWGuserprofile IsNot Nothing) Then
        '            Dim _userprofile1 As userprofile1 = Me
        '            RemoveHandler Me._UWGuserprofile.InitializeLayout, New InitializeLayoutEventHandler(AddressOf _userprofile1.UWGuserprofile_InitializeLayout)
        '            Dim _userprofile11 As userprofile1 = Me
        '            RemoveHandler Me._UWGuserprofile.InitializeRow, New InitializeRowEventHandler(AddressOf _userprofile11.UWGuserprofile_InitializeRow)
        '        End If
        '        Me._UWGuserprofile = value
        '        If (Me._UWGuserprofile IsNot Nothing) Then
        '            Dim _userprofile12 As userprofile1 = Me
        '            AddHandler Me._UWGuserprofile.InitializeLayout, New InitializeLayoutEventHandler(AddressOf _userprofile12.UWGuserprofile_InitializeLayout)
        '            Dim _userprofile13 As userprofile1 = Me
        '            AddHandler Me._UWGuserprofile.InitializeRow, New InitializeRowEventHandler(AddressOf _userprofile13.UWGuserprofile_InitializeRow)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim _userprofile1 As userprofile1 = Me
            'MyBase.add_Init(New EventHandler(_userprofile1, _userprofile1.Page_Init))
            Dim _userprofile11 As userprofile1 = Me
            'MyBase.add_Load(New EventHandler(_userprofile11, _userprofile11.Page_Load))
            Me.uccUserProfile = New UCCUserprofile()
            Me.FUNCTIONNAME = "UserProfile"
            Me.isAdmin = False
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Dim str As String = String.Concat("<script language=""javascript"">", "window.close();")
            str = String.Concat(str, "</script>")
            Me.Page().RegisterClientScriptBlock("", str)
        End Sub

        Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNew.Click
            Me.setDefaultValues()
            Me.txtPassword.TextMode = (2)
            Me.txtPassword.Visible = (True)
            Me.lblPassword.Visible = (True)
            Me.lblConfirmPswrd.Text = ("Confirm Password")
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            If (Me.txtuserprofileID.Text().Length() <> 0) Then
                Me.updateUserProfile()
            Else
                Me.createUserProfile()
            End If
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            messageHelper = Me.searchUserProfile(Strings.Trim(Me.txtSrchuserprofile.Text()), Strings.Trim(Me.txtSrchLastName.Text()))
            If (messageHelper.status) Then
                Me.UWGuserprofile.DisplayLayout.ViewType = ViewType.Flat
                Me.UWGuserprofile.DataSource = (RuntimeHelpers.GetObjectValue(messageHelper.messageObject))
                Me.UWGuserprofile.DataBind()
                If (Me.UWGuserprofile.Rows.Count() = 0) Then
                    messageHelper.messageText = "No Records Found for Search Criteria"
                End If
            End If
            Me.txtPassword.TextMode = (0)
            Me.txtPassword.Visible = (False)
            Me.lblPassword.Visible = (False)
            Me.lblErrorMsg.Text = (messageHelper.messageText)
        End Sub

        Private Sub createUserProfile()
            Dim messageHelper As SystemFramework.MessageHelper = Me.createUserProfileAll()
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text = (messageHelper.messageText)
            Else
                Me.getUserProfileByID(IntegerType.FromObject(messageHelper.messageObject))
            End If
        End Sub

        Private Function createUserProfileAll() As SystemFramework.MessageHelper
            Dim num As Integer
            num = If(Not Me.chkActive.Checked, 0, 1)
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccUserProfile.createUserprofile(Me.isAdmin, MyBase.[Operator].password, Strings.Trim(Me.txtUserId.Text()), Strings.Trim(Me.txtFirstName.Text()), Strings.Trim(Me.txtLastName.Text()), Strings.Trim(Me.txtPassword.Text()), Strings.Trim(Me.txtPswrdRpt.Text()), Strings.Trim(Me.txtNewPswrd.Text()), Strings.Trim(Me.txtNewPswrdRpt.Text()), IntegerType.FromString(Me.lstDefaultArea.SelectedItem().Value), IntegerType.FromString(Me.lstRole.SelectedItem().Value), IntegerType.FromString(Me.lstDefaultFunction.SelectedItem().Value), IntegerType.FromString(Me.lstCompany.SelectedItem().Value), num, MyBase.[Operator].userId, MyBase.[Operator].userId)
            Return messageHelper
        End Function

        Private Sub getUserProfile(ByVal company_id As Integer, ByVal user_id As String)
            Me.rdr = Me.uccUserProfile.getOperatorByCompanyUserId(company_id, user_id)
            Me.populateFields()
        End Sub

        Private Sub getUserProfileByID(ByVal operator_id As Integer)
            Me.rdr = Me.uccUserProfile.getUserprofileById(operator_id)
            Me.populateFields()
        End Sub

        <DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub loadAppFunction()
            Dim allAppFunctions As SqlDataReader = UCCSecurity.getAllAppFunctions()
            Me.lstDefaultFunction.DataSource = (allAppFunctions)
            Me.lstDefaultFunction.DataValueField = ("App_Function_ID")
            Me.lstDefaultFunction.DataTextField = ("Function_Name")
            Me.lstDefaultFunction.DataBind()
            allAppFunctions.Close()
        End Sub

        Private Sub loadArea()
            Dim uCCSchedule As BusinessService.UCCSchedule = New BusinessService.UCCSchedule()
            Dim allActiveAreas As SqlDataReader = uCCSchedule.getAllActiveAreas()
            Me.lstDefaultArea.DataSource = (allActiveAreas)
            Me.lstDefaultArea.DataValueField = ("Area_ID")
            Me.lstDefaultArea.DataTextField = ("Area_Name")
            Me.lstDefaultArea.DataBind()
            Me.lstDefaultArea.Items().Insert(0, New ListItem("ALL", "0"))
            allActiveAreas.Close()
        End Sub

        Private Sub loadCompany()
            Dim uCCCompany As BusinessService.UCCCompany = New BusinessService.UCCCompany()
            Dim all As SqlDataReader = uCCCompany.getAll()
            Me.lstCompany.DataSource = (all)
            Me.lstCompany.DataValueField = ("Company_ID")
            Me.lstCompany.DataTextField = ("name")
            Me.lstCompany.DataBind()
            all.Close()
        End Sub

        Private Sub loadListBoxes()
            Me.loadArea()
            Me.loadAppFunction()
            Me.loadRoles()
            Me.loadCompany()
        End Sub

        Private Sub loadRoles()
            Dim allRoles As SqlDataReader = UCCRole.getAllRoles()
            Me.lstRole.DataSource = (allRoles)
            Me.lstRole.DataValueField = ("Role_ID")
            Me.lstRole.DataTextField = ("Role_Name")
            Me.lstRole.DataBind()
            allRoles.Close()
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Me.setSecurity()
            If (Not Me.Page().IsPostBack()) Then
                Me.loadListBoxes()
                Me.setDefaultValues()
                Me.txtuserprofileID.Text = ("")
                Me.getUserProfile(MyBase.[Operator].company_ID, MyBase.[Operator].userId)
            End If
            Me.lblErrorMsg.Text = ("")
        End Sub

        Private Sub populateFields()
            Dim dateTime As System.DateTime = New System.DateTime()
            Me.rdr.Read()
            Me.txtuserprofileID.Text = (StringType.FromObject(Me.rdr.Item("Operator_ID")))
            Me.txtUserId.Text = (StringType.FromObject(Me.rdr.Item("UserId")))
            Me.txtFirstName.Text = (StringType.FromObject(Me.rdr.Item("First_Name")))
            Me.txtLastName.Text = (StringType.FromObject(Me.rdr.Item("Last_Name")))
            If (Not Me.setDropDown(Me.lstDefaultArea, StringType.FromObject(Me.rdr.Item("DefaultScheduleArea")))) Then
                Me.lstDefaultArea.SelectedIndex = (0)
            End If
            If (Not Me.setDropDown(Me.lstRole, StringType.FromObject(Me.rdr.Item("Role_ID")))) Then
                Me.lstRole.SelectedIndex = (0)
            End If
            If (Not Me.setDropDown(Me.lstDefaultFunction, StringType.FromObject(Me.rdr.Item("DefaultApp_Function_ID")))) Then
                Me.lstDefaultFunction.SelectedIndex = (0)
            End If
            If (Not Me.setDropDown(Me.lstCompany, StringType.FromObject(Me.rdr.Item("Company_ID")))) Then
                Me.lstCompany.SelectedIndex = (1)
            End If
            If (Not BooleanType.FromObject(Me.rdr.Item("Active"))) Then
                Me.chkActive.Checked = (False)
            Else
                Me.chkActive.Checked = (True)
            End If
            dateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
            Me.txtCreateDate.Text = (dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtCreateUser.Text = (StringType.FromObject(Me.rdr.Item("Create_User")))
            dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
            Me.txtModifiedDate.Text = (dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtModifiedUser.Text = (StringType.FromObject(Me.rdr.Item("Modified_User")))
            Me.txtUserId.Enabled = (False)
            Me.txtPassword.TextMode = (0)
            Me.txtPassword.Visible = (False)
            Me.lblPassword.Visible = (False)
            Me.txtPassword.Text = (StringType.FromObject(Me.rdr.Item("password")))
        End Sub

        Public Function searchUserProfile(ByVal userid As String, ByVal LastName As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateCriteria(userid, LastName)
            If (messageHelper.status) Then
                Dim str As String = messageHelper.messageId
                If (StringType.StrCmp(str, "U", False) = 0) Then
                    Me.rdr = Me.uccUserProfile.getOperatorByUserId(userid)
                ElseIf (StringType.StrCmp(str, "L", False) = 0) Then
                    Me.rdr = Me.uccUserProfile.getOperatorByLastName(LastName)
                End If
                messageHelper.status = True
                messageHelper.messageObject = Me.rdr
            End If
            Return messageHelper
        End Function

        Private Sub setDefaultValues()
            Me.chkActive.Checked = (True)
            Me.txtuserprofileID.Text = ("")
            Me.txtUserId.Text = ("")
            Me.txtFirstName.Text = ("")
            Me.txtLastName.Text = ("")
            Me.txtPassword.Text = ("")
            Me.txtPswrdRpt.Text = ("")
            Me.txtNewPswrd.Text = ("")
            Me.txtNewPswrdRpt.Text = ("")
            Me.txtModifiedUser.Text = ("")
            Me.txtModifiedDate.Text = ("")
            Me.txtCreateUser.Text = ("")
            Me.txtCreateDate.Text = ("")
            Me.setDropDown(Me.lstDefaultArea, "0")
            Me.setDropDown(Me.lstRole, "2")
            Me.setDropDown(Me.lstDefaultFunction, "1")
            Me.setDropDown(Me.lstCompany, "1")
            Me.txtUserId.Enabled = (True)
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

        Private Function setSecurity() As Object
            Dim obj As Object = Nothing
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (Not BooleanType.FromObject(LateBinding.LateGet((New UISecurity()).validateSecurity(Me.FUNCTIONNAME).messageObject, Nothing, "canCreate", New Object(-1) {}, Nothing, Nothing))) Then
                Me.pnlUserSearch.Visible = (False)
                Me.txtFirstName.Enabled = (False)
                Me.txtLastName.Enabled = (False)
                Me.lstRole.Enabled = (False)
                Me.chkActive.Enabled = (False)
                Me.lblConfirmPswrd.Text = ("Confirm Password")
                Me.isAdmin = False
            Else
                Me.pnlUserSearch.Visible = (True)
                Me.lstRole.Enabled = (True)
                Me.chkActive.Enabled = (True)
                Me.lblConfirmPswrd.Text = ("Confirm Admin Password")
                Me.txtFirstName.Enabled = (True)
                Me.txtLastName.Enabled = (True)
                Me.isAdmin = True
            End If
            Return obj
        End Function

        Private Sub updateUserProfile()
            Dim messageHelper As SystemFramework.MessageHelper = Me.updateUserProfileAll()
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text = (messageHelper.messageText)
            Else
                If (Not Me.isAdmin Or StringType.StrCmp(MyBase.[Operator].password, Strings.Trim(Me.txtPassword.Text()), False) = 0) Then
                    MyBase.[Operator].defaultApp_Function_ID = IntegerType.FromString(Me.lstDefaultFunction.SelectedItem().Value)
                    MyBase.[Operator].defaultScheduleArea = IntegerType.FromString(Me.lstDefaultArea.SelectedItem().Value)
                End If
                Me.getUserProfileByID(IntegerType.FromString(Me.txtuserprofileID.Text()))
            End If
        End Sub

        Private Function updateUserProfileAll() As SystemFramework.MessageHelper
            Dim num As Integer
            num = If(Not Me.chkActive.Checked, 0, 1)
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccUserProfile.updateOperatorAll(Me.isAdmin, MyBase.[Operator].password, IntegerType.FromString(Me.txtuserprofileID.Text()), Strings.Trim(Me.txtUserId.Text()), Strings.Trim(Me.txtFirstName.Text()), Strings.Trim(Me.txtLastName.Text()), Strings.Trim(Me.txtPassword.Text()), Strings.Trim(Me.txtPswrdRpt.Text()), Strings.Trim(Me.txtNewPswrd.Text()), Strings.Trim(Me.txtNewPswrdRpt.Text()), IntegerType.FromString(Me.lstDefaultArea.SelectedItem().Value), IntegerType.FromString(Me.lstRole.SelectedItem().Value), IntegerType.FromString(Me.lstDefaultFunction.SelectedItem().Value), IntegerType.FromString(Me.lstCompany.SelectedItem().Value), num, MyBase.[Operator].userId, DateType.FromString(Me.txtModifiedDate.Text()))
            Return messageHelper
        End Function

        Private Sub UWGuserprofile_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UWGuserprofile.InitializeLayout
            Dim layout As UltraGridLayout = e.Layout
            layout.Bands(0).Columns.FromKey("password").Hidden = True
            layout.Bands(0).Columns.FromKey("DefaultTelephoneArea").Hidden = True
            layout = Nothing
        End Sub

        Private Sub UWGuserprofile_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGuserprofile.InitializeRow
            Dim dateTime As System.DateTime = New System.DateTime()
            dateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
            e.Row.Cells.FromKey("Create_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
            dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
            e.Row.Cells.FromKey("Modified_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
        End Sub

        Private Function validateCriteria(ByVal UserId As String, ByVal last_name As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (UserId.Length() > 0) Then
                If (last_name.Length() <= 0) Then
                    messageHelper.status = True
                    messageHelper.messageId = "U"
                Else
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.messageText = "UserId is mutually exclusive with others"
                End If
            ElseIf (last_name.Length() <= 0) Then
                messageHelper.messageId = StringType.FromInteger(2)
                messageHelper.messageText = "Enter Search Criteria"
            Else
                messageHelper.status = True
                messageHelper.messageId = "L"
            End If
            Return messageHelper
        End Function
    End Class
End Namespace