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
    Public MustInherit Class _Sub
        Inherits ControlBase

        '<AccessedThroughProperty("lstParentSub")>
        'Private _lstParentSub As DropDownList

        '<AccessedThroughProperty("Label4")>
        'Private _Label4 As Label

        '<AccessedThroughProperty("UWGSub")>
        'Private _UWGSub As UltraWebGrid

        '<AccessedThroughProperty("lbl")>
        'Private _lbl As Label

        '<AccessedThroughProperty("Label3")>
        'Private _Label3 As Label

        '<AccessedThroughProperty("Label2")>
        'Private _Label2 As Label

        '<AccessedThroughProperty("btnSearch")>
        'Private _btnSearch As Button

        '<AccessedThroughProperty("txtSrchPrmArea")>
        'Private _txtSrchPrmArea As TextBox

        '<AccessedThroughProperty("btnNew")>
        'Private _btnNew As Button

        '<AccessedThroughProperty("txtSrchPrmExch")>
        'Private _txtSrchPrmExch As TextBox

        '<AccessedThroughProperty("txtSrchPrmPhone")>
        'Private _txtSrchPrmPhone As TextBox

        '<AccessedThroughProperty("lblErrorMsg")>
        'Private _lblErrorMsg As Label

        '<AccessedThroughProperty("txtSrchAltArea")>
        'Private _txtSrchAltArea As TextBox

        '<AccessedThroughProperty("Label5")>
        'Private _Label5 As Label

        '<AccessedThroughProperty("txtSrchAltExch")>
        'Private _txtSrchAltExch As TextBox

        '<AccessedThroughProperty("Label6")>
        'Private _Label6 As Label

        '<AccessedThroughProperty("txtSrchAltNumber")>
        'Private _txtSrchAltNumber As TextBox

        '<AccessedThroughProperty("Label7")>
        'Private _Label7 As Label

        '<AccessedThroughProperty("txtNickName")>
        'Private _txtNickName As TextBox

        '<AccessedThroughProperty("Label8")>
        'Private _Label8 As Label

        '<AccessedThroughProperty("txtCompanyName")>
        'Private _txtCompanyName As TextBox

        '<AccessedThroughProperty("lstPrmPhoneType")>
        'Private _lstPrmPhoneType As DropDownList

        '<AccessedThroughProperty("txtTID")>
        'Private _txtTID As TextBox

        '<AccessedThroughProperty("txtUBI")>
        'Private _txtUBI As TextBox

        '<AccessedThroughProperty("chkSunAM")>
        'Private _chkSunAM As CheckBox

        '<AccessedThroughProperty("chkActive")>
        'Private _chkActive As CheckBox

        '<AccessedThroughProperty("chkSunPM")>
        'Private _chkSunPM As CheckBox

        '<AccessedThroughProperty("chkMonAM")>
        'Private _chkMonAM As CheckBox

        '<AccessedThroughProperty("Label9")>
        'Private _Label9 As Label

        '<AccessedThroughProperty("chkMonPM")>
        'Private _chkMonPM As CheckBox

        '<AccessedThroughProperty("Label10")>
        'Private _Label10 As Label

        '<AccessedThroughProperty("chkTueAM")>
        'Private _chkTueAM As CheckBox

        '<AccessedThroughProperty("chkTuePM")>
        'Private _chkTuePM As CheckBox

        '<AccessedThroughProperty("Label11")>
        'Private _Label11 As Label

        '<AccessedThroughProperty("chkWedAM")>
        'Private _chkWedAM As CheckBox

        '<AccessedThroughProperty("chkWedPM")>
        'Private _chkWedPM As CheckBox

        '<AccessedThroughProperty("Label12")>
        'Private _Label12 As Label

        '<AccessedThroughProperty("chkThuAM")>
        'Private _chkThuAM As CheckBox

        '<AccessedThroughProperty("chkThuPM")>
        'Private _chkThuPM As CheckBox

        '<AccessedThroughProperty("Label13")>
        'Private _Label13 As Label

        '<AccessedThroughProperty("chkFriAM")>
        'Private _chkFriAM As CheckBox

        '<AccessedThroughProperty("chkFriPM")>
        'Private _chkFriPM As CheckBox

        '<AccessedThroughProperty("Label14")>
        'Private _Label14 As Label

        '<AccessedThroughProperty("chkSatAM")>
        'Private _chkSatAM As CheckBox

        '<AccessedThroughProperty("txtFirstName")>
        'Private _txtFirstName As TextBox

        '<AccessedThroughProperty("Label15")>
        'Private _Label15 As Label

        '<AccessedThroughProperty("chkSatPM")>
        'Private _chkSatPM As CheckBox

        '<AccessedThroughProperty("Label16")>
        'Private _Label16 As Label

        '<AccessedThroughProperty("txtDollarMaxAmount")>
        'Private _txtDollarMaxAmount As TextBox

        '<AccessedThroughProperty("txtLastName")>
        'Private _txtLastName As TextBox

        '<AccessedThroughProperty("Label17")>
        'Private _Label17 As Label

        '<AccessedThroughProperty("chkLstAssignedAreas")>
        'Private _chkLstAssignedAreas As CheckBoxList

        '<AccessedThroughProperty("txtHiddenNickName")>
        'Private _txtHiddenNickName As TextBox

        '<AccessedThroughProperty("btnSave")>
        'Private _btnSave As Button

        '<AccessedThroughProperty("chkHiddenActive")>
        'Private _chkHiddenActive As CheckBox

        '<AccessedThroughProperty("txtSpouseName")>
        'Private _txtSpouseName As TextBox

        '<AccessedThroughProperty("btnCancel")>
        'Private _btnCancel As Button

        '<AccessedThroughProperty("btnRetrieveAreas")>
        'Private _btnRetrieveAreas As Button

        '<AccessedThroughProperty("Label18")>
        'Private _Label18 As Label

        '<AccessedThroughProperty("lblHeight")>
        'Private _lblHeight As Label

        '<AccessedThroughProperty("txtContactName")>
        'Private _txtContactName As TextBox

        '<AccessedThroughProperty("txtHeight")>
        'Private _txtHeight As TextBox

        '<AccessedThroughProperty("chkGutters")>
        'Private _chkGutters As CheckBox

        '<AccessedThroughProperty("txtPrimaryExch")>
        'Private _txtPrimaryExch As TextBox

        '<AccessedThroughProperty("txtPrimaryAddressID")>
        'Private _txtPrimaryAddressID As TextBox

        '<AccessedThroughProperty("txtPrimaryNumber")>
        'Private _txtPrimaryNumber As TextBox

        '<AccessedThroughProperty("txtCreateUser")>
        'Private _txtCreateUser As TextBox

        '<AccessedThroughProperty("txtAlternateAddressID")>
        'Private _txtAlternateAddressID As TextBox

        '<AccessedThroughProperty("txtCreateDate")>
        'Private _txtCreateDate As TextBox

        '<AccessedThroughProperty("txtPrimaryAddress")>
        'Private _txtPrimaryAddress As TextBox

        '<AccessedThroughProperty("txtAlternateArea")>
        'Private _txtAlternateArea As TextBox

        '<AccessedThroughProperty("txtModifiedUser")>
        'Private _txtModifiedUser As TextBox

        '<AccessedThroughProperty("txtAlternateAddress")>
        'Private _txtAlternateAddress As TextBox

        '<AccessedThroughProperty("txtAlternateExch")>
        'Private _txtAlternateExch As TextBox

        '<AccessedThroughProperty("txtModifiedDate")>
        'Private _txtModifiedDate As TextBox

        '<AccessedThroughProperty("Label33")>
        'Private _Label33 As Label

        '<AccessedThroughProperty("txtAlternateNumber")>
        'Private _txtAlternateNumber As TextBox

        '<AccessedThroughProperty("pnlMore")>
        'Private _pnlMore As Panel

        '<AccessedThroughProperty("chkNewConst")>
        'Private _chkNewConst As CheckBox

        '<AccessedThroughProperty("chkPwrWash")>
        'Private _chkPwrWash As CheckBox

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("txtNotes")>
        'Private _txtNotes As TextBox

        '<AccessedThroughProperty("Label19")>
        'Private _Label19 As Label

        '<AccessedThroughProperty("Label21")>
        'Private _Label21 As Label

        '<AccessedThroughProperty("txtSrchLastName")>
        'Private _txtSrchLastName As TextBox

        '<AccessedThroughProperty("Label20")>
        'Private _Label20 As Label

        '<AccessedThroughProperty("Label23")>
        'Private _Label23 As Label

        '<AccessedThroughProperty("Label24")>
        'Private _Label24 As Label

        '<AccessedThroughProperty("Label25")>
        'Private _Label25 As Label

        '<AccessedThroughProperty("txtSrchNickName")>
        'Private _txtSrchNickName As TextBox

        '<AccessedThroughProperty("txtSubID")>
        'Private _txtSubID As TextBox

        '<AccessedThroughProperty("lstAltPhoneType")>
        'Private _lstAltPhoneType As DropDownList

        '<AccessedThroughProperty("Label26")>
        'Private _Label26 As Label

        '<AccessedThroughProperty("Label27")>
        'Private _Label27 As Label

        '<AccessedThroughProperty("Label28")>
        'Private _Label28 As Label

        '<AccessedThroughProperty("Label22")>
        'Private _Label22 As Label

        '<AccessedThroughProperty("txtPrimaryArea")>
        'Private _txtPrimaryArea As TextBox

        '<AccessedThroughProperty("Label29")>
        'Private _Label29 As Label

        '<AccessedThroughProperty("Label30")>
        'Private _Label30 As Label

        '<AccessedThroughProperty("Label31")>
        'Private _Label31 As Label

        '<AccessedThroughProperty("txtEMail")>
        'Private _txtEMail As TextBox

        '<AccessedThroughProperty("Label32")>
        'Private _Label32 As Label

        Private rdr As SqlDataReader

        Private uccSubcontractor As UCCSubcontractor

        Private isChild As Boolean

        Private parentRequestor As String

        'Protected Overridable Property btnCancel As Button
        '    Get
        '        Return Me._btnCancel
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnCancel IsNot Nothing) Then
        '            Dim __Sub As _Sub = Me
        '            Me._btnCancel.remove_Click(New EventHandler(__Sub, __Sub.btnCancel_Click))
        '        End If
        '        Me._btnCancel = value
        '        If (Me._btnCancel IsNot Nothing) Then
        '            Dim __Sub1 As _Sub = Me
        '            Me._btnCancel.add_Click(New EventHandler(__Sub1, __Sub1.btnCancel_Click))
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
        '            Dim __Sub As _Sub = Me
        '            Me._btnNew.remove_Click(New EventHandler(__Sub, __Sub.btnNew_Click))
        '        End If
        '        Me._btnNew = value
        '        If (Me._btnNew IsNot Nothing) Then
        '            Dim __Sub1 As _Sub = Me
        '            Me._btnNew.add_Click(New EventHandler(__Sub1, __Sub1.btnNew_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnRetrieveAreas As Button
        '    Get
        '        Return Me._btnRetrieveAreas
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnRetrieveAreas IsNot Nothing) Then
        '            Dim __Sub As _Sub = Me
        '            Me._btnRetrieveAreas.remove_Click(New EventHandler(__Sub, __Sub.btnRetrieveAreas_Click))
        '        End If
        '        Me._btnRetrieveAreas = value
        '        If (Me._btnRetrieveAreas IsNot Nothing) Then
        '            Dim __Sub1 As _Sub = Me
        '            Me._btnRetrieveAreas.add_Click(New EventHandler(__Sub1, __Sub1.btnRetrieveAreas_Click))
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
        '            Dim __Sub As _Sub = Me
        '            Me._btnSave.remove_Click(New EventHandler(__Sub, __Sub.btnSave_Click))
        '        End If
        '        Me._btnSave = value
        '        If (Me._btnSave IsNot Nothing) Then
        '            Dim __Sub1 As _Sub = Me
        '            Me._btnSave.add_Click(New EventHandler(__Sub1, __Sub1.btnSave_Click))
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
        '            Dim __Sub As _Sub = Me
        '            Me._btnSearch.remove_Click(New EventHandler(__Sub, __Sub.btnSearch_Click))
        '        End If
        '        Me._btnSearch = value
        '        If (Me._btnSearch IsNot Nothing) Then
        '            Dim __Sub1 As _Sub = Me
        '            Me._btnSearch.add_Click(New EventHandler(__Sub1, __Sub1.btnSearch_Click))
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

        'Protected Overridable Property chkFriAM As CheckBox
        '    Get
        '        Return Me._chkFriAM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkFriAM Is Nothing
        '        Me._chkFriAM = value
        '        Me._chkFriAM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkFriPM As CheckBox
        '    Get
        '        Return Me._chkFriPM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkFriPM Is Nothing
        '        Me._chkFriPM = value
        '        Me._chkFriPM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkGutters As CheckBox
        '    Get
        '        Return Me._chkGutters
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkGutters Is Nothing
        '        Me._chkGutters = value
        '        Me._chkGutters Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkHiddenActive As CheckBox
        '    Get
        '        Return Me._chkHiddenActive
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkHiddenActive Is Nothing
        '        Me._chkHiddenActive = value
        '        Me._chkHiddenActive Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkLstAssignedAreas As CheckBoxList
        '    Get
        '        Return Me._chkLstAssignedAreas
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBoxList)
        '        Me._chkLstAssignedAreas Is Nothing
        '        Me._chkLstAssignedAreas = value
        '        Me._chkLstAssignedAreas Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkMonAM As CheckBox
        '    Get
        '        Return Me._chkMonAM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkMonAM Is Nothing
        '        Me._chkMonAM = value
        '        Me._chkMonAM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkMonPM As CheckBox
        '    Get
        '        Return Me._chkMonPM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkMonPM Is Nothing
        '        Me._chkMonPM = value
        '        Me._chkMonPM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkNewConst As CheckBox
        '    Get
        '        Return Me._chkNewConst
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkNewConst Is Nothing
        '        Me._chkNewConst = value
        '        Me._chkNewConst Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkPwrWash As CheckBox
        '    Get
        '        Return Me._chkPwrWash
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkPwrWash Is Nothing
        '        Me._chkPwrWash = value
        '        Me._chkPwrWash Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkSatAM As CheckBox
        '    Get
        '        Return Me._chkSatAM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkSatAM Is Nothing
        '        Me._chkSatAM = value
        '        Me._chkSatAM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkSatPM As CheckBox
        '    Get
        '        Return Me._chkSatPM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkSatPM Is Nothing
        '        Me._chkSatPM = value
        '        Me._chkSatPM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkSunAM As CheckBox
        '    Get
        '        Return Me._chkSunAM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkSunAM Is Nothing
        '        Me._chkSunAM = value
        '        Me._chkSunAM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkSunPM As CheckBox
        '    Get
        '        Return Me._chkSunPM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkSunPM Is Nothing
        '        Me._chkSunPM = value
        '        Me._chkSunPM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkThuAM As CheckBox
        '    Get
        '        Return Me._chkThuAM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkThuAM Is Nothing
        '        Me._chkThuAM = value
        '        Me._chkThuAM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkThuPM As CheckBox
        '    Get
        '        Return Me._chkThuPM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkThuPM Is Nothing
        '        Me._chkThuPM = value
        '        Me._chkThuPM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkTueAM As CheckBox
        '    Get
        '        Return Me._chkTueAM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkTueAM Is Nothing
        '        Me._chkTueAM = value
        '        Me._chkTueAM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkTuePM As CheckBox
        '    Get
        '        Return Me._chkTuePM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkTuePM Is Nothing
        '        Me._chkTuePM = value
        '        Me._chkTuePM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkWedAM As CheckBox
        '    Get
        '        Return Me._chkWedAM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkWedAM Is Nothing
        '        Me._chkWedAM = value
        '        Me._chkWedAM Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkWedPM As CheckBox
        '    Get
        '        Return Me._chkWedPM
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkWedPM Is Nothing
        '        Me._chkWedPM = value
        '        Me._chkWedPM Is Nothing
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

        'Protected Overridable Property Label19 As Label
        '    Get
        '        Return Me._Label19
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label19 Is Nothing
        '        Me._Label19 = value
        '        Me._Label19 Is Nothing
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

        'Protected Overridable Property Label20 As Label
        '    Get
        '        Return Me._Label20
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label20 Is Nothing
        '        Me._Label20 = value
        '        Me._Label20 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label21 As Label
        '    Get
        '        Return Me._Label21
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label21 Is Nothing
        '        Me._Label21 = value
        '        Me._Label21 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label22 As Label
        '    Get
        '        Return Me._Label22
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label22 Is Nothing
        '        Me._Label22 = value
        '        Me._Label22 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label23 As Label
        '    Get
        '        Return Me._Label23
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label23 Is Nothing
        '        Me._Label23 = value
        '        Me._Label23 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label24 As Label
        '    Get
        '        Return Me._Label24
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label24 Is Nothing
        '        Me._Label24 = value
        '        Me._Label24 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label25 As Label
        '    Get
        '        Return Me._Label25
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label25 Is Nothing
        '        Me._Label25 = value
        '        Me._Label25 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label26 As Label
        '    Get
        '        Return Me._Label26
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label26 Is Nothing
        '        Me._Label26 = value
        '        Me._Label26 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label27 As Label
        '    Get
        '        Return Me._Label27
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label27 Is Nothing
        '        Me._Label27 = value
        '        Me._Label27 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label28 As Label
        '    Get
        '        Return Me._Label28
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label28 Is Nothing
        '        Me._Label28 = value
        '        Me._Label28 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label29 As Label
        '    Get
        '        Return Me._Label29
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label29 Is Nothing
        '        Me._Label29 = value
        '        Me._Label29 Is Nothing
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

        'Protected Overridable Property Label30 As Label
        '    Get
        '        Return Me._Label30
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label30 Is Nothing
        '        Me._Label30 = value
        '        Me._Label30 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label31 As Label
        '    Get
        '        Return Me._Label31
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label31 Is Nothing
        '        Me._Label31 = value
        '        Me._Label31 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label32 As Label
        '    Get
        '        Return Me._Label32
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label32 Is Nothing
        '        Me._Label32 = value
        '        Me._Label32 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property Label33 As Label
        '    Get
        '        Return Me._Label33
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label33 Is Nothing
        '        Me._Label33 = value
        '        Me._Label33 Is Nothing
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

        'Protected Overridable Property lbl As Label
        '    Get
        '        Return Me._lbl
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lbl Is Nothing
        '        Me._lbl = value
        '        Me._lbl Is Nothing
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

        'Protected Overridable Property lblHeight As Label
        '    Get
        '        Return Me._lblHeight
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblHeight Is Nothing
        '        Me._lblHeight = value
        '        Me._lblHeight Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstAltPhoneType As DropDownList
        '    Get
        '        Return Me._lstAltPhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstAltPhoneType Is Nothing
        '        Me._lstAltPhoneType = value
        '        Me._lstAltPhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstParentSub As DropDownList
        '    Get
        '        Return Me._lstParentSub
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstParentSub Is Nothing
        '        Me._lstParentSub = value
        '        Me._lstParentSub Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstPrmPhoneType As DropDownList
        '    Get
        '        Return Me._lstPrmPhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstPrmPhoneType Is Nothing
        '        Me._lstPrmPhoneType = value
        '        Me._lstPrmPhoneType Is Nothing
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

        'Protected Overridable Property txtAlternateAddress As TextBox
        '    Get
        '        Return Me._txtAlternateAddress
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtAlternateAddress Is Nothing
        '        Me._txtAlternateAddress = value
        '        Me._txtAlternateAddress Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtAlternateAddressID As TextBox
        '    Get
        '        Return Me._txtAlternateAddressID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtAlternateAddressID Is Nothing
        '        Me._txtAlternateAddressID = value
        '        Me._txtAlternateAddressID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtAlternateArea As TextBox
        '    Get
        '        Return Me._txtAlternateArea
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtAlternateArea Is Nothing
        '        Me._txtAlternateArea = value
        '        Me._txtAlternateArea Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtAlternateExch As TextBox
        '    Get
        '        Return Me._txtAlternateExch
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtAlternateExch Is Nothing
        '        Me._txtAlternateExch = value
        '        Me._txtAlternateExch Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtAlternateNumber As TextBox
        '    Get
        '        Return Me._txtAlternateNumber
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtAlternateNumber Is Nothing
        '        Me._txtAlternateNumber = value
        '        Me._txtAlternateNumber Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtCompanyName As TextBox
        '    Get
        '        Return Me._txtCompanyName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtCompanyName Is Nothing
        '        Me._txtCompanyName = value
        '        Me._txtCompanyName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtContactName As TextBox
        '    Get
        '        Return Me._txtContactName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtContactName Is Nothing
        '        Me._txtContactName = value
        '        Me._txtContactName Is Nothing
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

        'Protected Overridable Property txtDollarMaxAmount As TextBox
        '    Get
        '        Return Me._txtDollarMaxAmount
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtDollarMaxAmount Is Nothing
        '        Me._txtDollarMaxAmount = value
        '        Me._txtDollarMaxAmount Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtEMail As TextBox
        '    Get
        '        Return Me._txtEMail
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtEMail Is Nothing
        '        Me._txtEMail = value
        '        Me._txtEMail Is Nothing
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

        'Protected Overridable Property txtHeight As TextBox
        '    Get
        '        Return Me._txtHeight
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtHeight Is Nothing
        '        Me._txtHeight = value
        '        Me._txtHeight Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtHiddenNickName As TextBox
        '    Get
        '        Return Me._txtHiddenNickName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtHiddenNickName Is Nothing
        '        Me._txtHiddenNickName = value
        '        Me._txtHiddenNickName Is Nothing
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

        'Protected Overridable Property txtNickName As TextBox
        '    Get
        '        Return Me._txtNickName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtNickName Is Nothing
        '        Me._txtNickName = value
        '        Me._txtNickName Is Nothing
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

        'Protected Overridable Property txtPrimaryAddress As TextBox
        '    Get
        '        Return Me._txtPrimaryAddress
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPrimaryAddress Is Nothing
        '        Me._txtPrimaryAddress = value
        '        Me._txtPrimaryAddress Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtPrimaryAddressID As TextBox
        '    Get
        '        Return Me._txtPrimaryAddressID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPrimaryAddressID Is Nothing
        '        Me._txtPrimaryAddressID = value
        '        Me._txtPrimaryAddressID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtPrimaryArea As TextBox
        '    Get
        '        Return Me._txtPrimaryArea
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPrimaryArea Is Nothing
        '        Me._txtPrimaryArea = value
        '        Me._txtPrimaryArea Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtPrimaryExch As TextBox
        '    Get
        '        Return Me._txtPrimaryExch
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPrimaryExch Is Nothing
        '        Me._txtPrimaryExch = value
        '        Me._txtPrimaryExch Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtPrimaryNumber As TextBox
        '    Get
        '        Return Me._txtPrimaryNumber
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPrimaryNumber Is Nothing
        '        Me._txtPrimaryNumber = value
        '        Me._txtPrimaryNumber Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSpouseName As TextBox
        '    Get
        '        Return Me._txtSpouseName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSpouseName Is Nothing
        '        Me._txtSpouseName = value
        '        Me._txtSpouseName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchAltArea As TextBox
        '    Get
        '        Return Me._txtSrchAltArea
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchAltArea Is Nothing
        '        Me._txtSrchAltArea = value
        '        Me._txtSrchAltArea Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchAltExch As TextBox
        '    Get
        '        Return Me._txtSrchAltExch
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchAltExch Is Nothing
        '        Me._txtSrchAltExch = value
        '        Me._txtSrchAltExch Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchAltNumber As TextBox
        '    Get
        '        Return Me._txtSrchAltNumber
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchAltNumber Is Nothing
        '        Me._txtSrchAltNumber = value
        '        Me._txtSrchAltNumber Is Nothing
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

        'Protected Overridable Property txtSrchNickName As TextBox
        '    Get
        '        Return Me._txtSrchNickName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchNickName Is Nothing
        '        Me._txtSrchNickName = value
        '        Me._txtSrchNickName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchPrmArea As TextBox
        '    Get
        '        Return Me._txtSrchPrmArea
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchPrmArea Is Nothing
        '        Me._txtSrchPrmArea = value
        '        Me._txtSrchPrmArea Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchPrmExch As TextBox
        '    Get
        '        Return Me._txtSrchPrmExch
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchPrmExch Is Nothing
        '        Me._txtSrchPrmExch = value
        '        Me._txtSrchPrmExch Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSrchPrmPhone As TextBox
        '    Get
        '        Return Me._txtSrchPrmPhone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSrchPrmPhone Is Nothing
        '        Me._txtSrchPrmPhone = value
        '        Me._txtSrchPrmPhone Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSubID As TextBox
        '    Get
        '        Return Me._txtSubID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSubID Is Nothing
        '        Me._txtSubID = value
        '        Me._txtSubID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtTID As TextBox
        '    Get
        '        Return Me._txtTID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtTID Is Nothing
        '        Me._txtTID = value
        '        Me._txtTID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtUBI As TextBox
        '    Get
        '        Return Me._txtUBI
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtUBI Is Nothing
        '        Me._txtUBI = value
        '        Me._txtUBI Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property UWGSub As UltraWebGrid
        '    Get
        '        Return Me._UWGSub
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UWGSub IsNot Nothing) Then
        '            Dim __Sub As _Sub = Me
        '            RemoveHandler Me._UWGSub.InitializeRow, New InitializeRowEventHandler(AddressOf __Sub.UWGClient_InitializeRow)
        '        End If
        '        Me._UWGSub = value
        '        If (Me._UWGSub IsNot Nothing) Then
        '            Dim __Sub1 As _Sub = Me
        '            AddHandler Me._UWGSub.InitializeRow, New InitializeRowEventHandler(AddressOf __Sub1.UWGClient_InitializeRow)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim __Sub As _Sub = Me
            'MyBase.add_Init(New EventHandler(__Sub, __Sub.Page_Init))
            Dim __Sub1 As _Sub = Me
            'MyBase.add_Load(New EventHandler(__Sub1, __Sub1.Page_Load))
            Me.uccSubcontractor = New UCCSubcontractor()
            Me.isChild = False
            Me.parentRequestor = ""
        End Sub

        Private Sub assignSubsAreas()
            Me.rdr = Me.uccSubcontractor.getSubcontractorsAreas(IntegerType.FromString(Me.txtSubID.Text()))
            While Me.rdr.Read()
                Dim listItem As System.Web.UI.WebControls.ListItem = Me.chkLstAssignedAreas.Items().FindByValue(StringType.FromObject(Me.rdr.Item("Area_ID")))
                If (listItem Is Nothing) Then
                    Continue While
                End If
                listItem.Selected=(True)
            End While
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Dim str As String = String.Concat("<script language=""javascript"">", "window.close();")
            str = String.Concat(str, "</script>")
            Me.Page().RegisterClientScriptBlock("subcontractorScript", str)
        End Sub

        Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNew.Click
            Me.setDefaultValues()
        End Sub

        Private Sub btnRetrieveAreas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRetrieveAreas.Click
            Dim enumerator As IEnumerator = Nothing
            Try
                enumerator = Me.chkLstAssignedAreas.Items().GetEnumerator()
                While enumerator.MoveNext()
                    DirectCast(enumerator.Current(), ListItem).Selected = (False)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Me.populateSub(Me.getSub(Microsoft.VisualBasic.Strings.Trim(Me.txtSubID.Text())))
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            If (Me.txtSubID.Text().Length() <> 0) Then
                Me.updateSubcontractor()
            Else
                Me.createSubcontractor()
            End If
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            Me.setDefaultValues()
            Dim str As String = String.Concat(Me.txtSrchPrmArea.Text(), Me.txtSrchPrmExch.Text(), Me.txtSrchPrmPhone.Text())
            Dim str1 As String = String.Concat(Me.txtSrchAltArea.Text(), Me.txtSrchAltExch.Text(), Me.txtSrchAltNumber.Text())
            messageHelper = Me.searchSubcontractor(Microsoft.VisualBasic.Strings.Trim(Me.txtSrchLastName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtSrchNickName.Text()), str, str1)
            If (messageHelper.status) Then
                Me.UWGSub.DisplayLayout.ViewType = ViewType.Flat
                Me.UWGSub.DataSource = (RuntimeHelpers.GetObjectValue(messageHelper.messageObject))
                Me.UWGSub.DataBind()
                If (Me.UWGSub.Rows.Count() = 0) Then
                    messageHelper.messageText = "No Records Found for Search Criteria"
                ElseIf (Me.UWGSub.Rows.Count() = 1) Then
                    Me.populateSub(Me.getSub(StringType.FromObject(Me.UWGSub.Rows(0).Cells.FromKey("Sub_ID").Value)))
                End If
            End If
            Me.lblErrorMsg.Text = (messageHelper.messageText)
        End Sub

        Private Sub createSubcontractor()
            Dim str As String = "<script language=""javascript"">"
            Dim messageHelper As SystemFramework.MessageHelper = Me.createSubcontractorAll()
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text=(messageHelper.messageText)
            Else
                Me.populateSub(Me.getSub(StringType.FromObject(messageHelper.messageObject)))
                If (Me.isChild) Then
                    str = String.Concat(str, "window.close();")
                    str = String.Concat(str, "</script>")
                    Me.Page().RegisterClientScriptBlock("subcontractorScript", str)
                End If
            End If
        End Sub

        Private Function createSubcontractorAll() As SystemFramework.MessageHelper
            Dim num As Integer
            Dim num1 As Integer
            Dim num2 As Integer
            Dim num3 As Integer
            Dim num4 As Integer
            Dim num5 As Integer
            Dim num6 As Integer
            Dim num7 As Integer
            Dim num8 As Integer = 0
            Dim str As String
            Dim num9 As Integer
            Dim num10 As Integer
            Dim num11 As Integer
            Dim num12 As Integer
            Dim num13 As Integer
            Dim num14 As Integer
            Dim num15 As Integer
            Dim num16 As Integer
            Dim num17 As Integer
            Dim num18 As Integer
            Dim num19 As Integer
            Dim num20 As Integer
            num6 = If(Not Me.chkMonAM.Checked, 0, 1)
            num7 = If(Not Me.chkMonPM.Checked, 0, 1)
            num17 = If(Not Me.chkTueAM.Checked, 0, 1)
            num18 = If(Not Me.chkTuePM.Checked, 0, 1)
            num19 = If(Not Me.chkWedAM.Checked, 0, 1)
            num20 = If(Not Me.chkWedPM.Checked, 0, 1)
            num15 = If(Not Me.chkThuAM.Checked, 0, 1)
            num16 = If(Not Me.chkThuPM.Checked, 0, 1)
            num2 = If(Not Me.chkFriAM.Checked, 0, 1)
            num3 = If(Not Me.chkFriPM.Checked, 0, 1)
            num11 = If(Not Me.chkSatAM.Checked, 0, 1)
            num12 = If(Not Me.chkSatPM.Checked, 0, 1)
            num13 = If(Not Me.chkSunAM.Checked, 0, 1)
            num14 = If(Not Me.chkSunPM.Checked, 0, 1)
            num = If(Not Me.chkActive.Checked, 0, 1)
            num4 = If(Not Me.chkGutters.Checked, 0, 1)
            num10 = If(Not Me.chkPwrWash.Checked, 0, 1)
            If (Not Me.chkNewConst.Checked) Then
                num4 = 0
            Else
                num8 = 1
            End If
            str = If(StringType.StrCmp(Me.lstParentSub.SelectedItem().Value, "", False) <> 0, Me.lstParentSub.SelectedItem().Value, StringType.FromInteger(0))
            num5 = Func.CastToInt(txtDollarMaxAmount.Text, 0)  ' IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtDollarMaxAmount.Text()).Length() <> 0, IntegerType.FromString(Microsoft.VisualBasic.Strings.Trim(Me.txtDollarMaxAmount.Text())), 0)
            num9 = Func.CastToInt(txtPrimaryAddressID.Text, 0)  ' IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtPrimaryAddressID.Text()).Length() <> 0, IntegerType.FromString(Me.txtPrimaryAddressID.Text()), 0)
            num1 = Func.CastToInt(txtAlternateAddressID.Text, 0)  ' IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtAlternateAddressID.Text()).Length() <> 0, IntegerType.FromString(Me.txtAlternateAddressID.Text()), 0)
            Dim str1 As String = txtPrimaryArea.Text & txtPrimaryExch.Text & txtPrimaryNumber.Text ' String.Concat(Me.txtPrimaryArea.Text(), Me.txtPrimaryExch.Text(), Me.txtPrimaryNumber.Text())
            Dim str2 As String = txtAlternateArea.Text & txtAlternateExch.Text & txtAlternateNumber.Text
            Dim arrayList As System.Collections.ArrayList = Me.extractSelectedAreas()
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccSubcontractor.createSubcontractor(IntegerType.FromString(str), Microsoft.VisualBasic.Strings.Trim(Me.txtCompanyName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtFirstName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtLastName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtNickName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtTID.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtUBI.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtContactName.Text()), str1, Me.lstPrmPhoneType.SelectedItem().Value, str2, Me.lstAltPhoneType.SelectedItem().Value, Microsoft.VisualBasic.Strings.Trim(Me.txtEMail.Text()), num5, num6, num7, num17, num18, num19, num20, num15, num16, num2, num3, num11, num12, num13, num14, num, arrayList, MyBase.[Operator].userId, MyBase.[Operator].userId, Me.txtHeight.Text(), num4, num10, num8, Me.txtSpouseName.Text(), Me.txtNotes.Text(), num9, num1)
            Return messageHelper
        End Function

        Private Function extractSelectedAreas() As System.Collections.ArrayList
            Dim enumerator As IEnumerator = Nothing
            Dim arrayList As System.Collections.ArrayList = New System.Collections.ArrayList()
            Try
                enumerator = Me.chkLstAssignedAreas.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (Not current.Selected) Then
                        Continue While
                    End If
                    arrayList.Add(current.Value)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Return arrayList
        End Function

        Public Function getSub(ByVal sub_id As String) As SqlDataReader
            Dim uCCSubcontractor As BusinessService.UCCSubcontractor = New BusinessService.UCCSubcontractor()
            Me.rdr = uCCSubcontractor.getSubById(IntegerType.FromString(sub_id))
            Return Me.rdr
        End Function

        <DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub loadListBoxes()
            Dim uCCSchedule As BusinessService.UCCSchedule = New BusinessService.UCCSchedule()
            Dim uCCSubcontractor As BusinessService.UCCSubcontractor = New BusinessService.UCCSubcontractor()
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Phone Type")
            Me.lstPrmPhoneType.DataSource = (Me.rdr)
            Me.lstPrmPhoneType.DataValueField = ("Element_ID")
            Me.lstPrmPhoneType.DataTextField = ("Element_Description")
            Me.lstPrmPhoneType.DataBind()
            Me.lstPrmPhoneType.Items().Insert(0, New ListItem("", ""))
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Phone Type")
            Me.lstAltPhoneType.DataSource = (Me.rdr)
            Me.lstAltPhoneType.DataValueField = ("Element_ID")
            Me.lstAltPhoneType.DataTextField = ("Element_Description")
            Me.lstAltPhoneType.DataBind()
            Me.lstAltPhoneType.Items().Insert(0, New ListItem("", ""))
            Me.rdr = uCCSubcontractor.getActiveSubs()
            Me.lstParentSub.DataSource = (Me.rdr)
            Me.lstParentSub.DataValueField = ("Sub_ID")
            Me.lstParentSub.DataTextField = ("Nick_Name")
            Me.lstParentSub.DataBind()
            Me.lstParentSub.Items().Insert(0, New ListItem("", ""))
            Me.rdr = uCCSchedule.getAllActiveAreas()
            Me.chkLstAssignedAreas.DataSource = (Me.rdr)
            Me.chkLstAssignedAreas.DataValueField = ("Area_ID")
            Me.chkLstAssignedAreas.DataTextField = ("Area_Name")
            Me.chkLstAssignedAreas.DataBind()
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If (Me.Page().IsPostBack()) Then
                Me.isChild = BooleanType.FromObject(Me.ViewState().Item("isChild"))
                Me.parentRequestor = StringType.FromObject(Me.ViewState().Item("parentRequestor"))
            Else
                Me.loadListBoxes()
                Me.setDefaultValues()
                Dim item As String = Me.Parent().Page().Request().Item("From_Parent")
                Me.parentRequestor = item
                If (item IsNot Nothing) Then
                    Me.isChild = True
                    Dim str As String = Me.Parent().Page().Request().Item("Sub_ID")
                    If (str.Length() > 0) Then
                        Me.populateSub(Me.getSub(str))
                    End If
                    Me.ViewState().Item("isChild") = Me.isChild
                    Me.ViewState().Item("parentRequestor") = Me.parentRequestor
                End If
            End If
            Me.lblErrorMsg.Text = ("")
        End Sub

        Public Sub populateSub(ByVal rdr As SqlDataReader)
            Dim str As String
            rdr.Read()
            Me.txtNickName.Text = (StringType.FromObject(rdr.Item("Nick_Name")))
            Me.txtHiddenNickName.Text = (Me.txtNickName.Text())
            Me.txtFirstName.Text = (StringType.FromObject(rdr.Item("First_Name")))
            Me.txtLastName.Text = (StringType.FromObject(rdr.Item("Last_Name")))
            Me.txtSubID.Text = (StringType.FromObject(rdr.Item("Sub_ID")))
            Me.txtContactName.Text = (StringType.FromObject(rdr.Item("Contact_Name")))
            Me.txtTID.Text = (StringType.FromObject(rdr.Item("TID")))
            Me.txtUBI.Text = (StringType.FromObject(rdr.Item("UBI")))
            Me.txtEMail.Text = (StringType.FromObject(rdr.Item("E_Mail")))
            Me.txtDollarMaxAmount.Text = (StringType.FromObject(rdr.Item("dollarMaxAmount")))
            Me.txtCompanyName.Text = (StringType.FromObject(rdr.Item("Company_Name")))
            Me.txtSpouseName.Text = (StringType.FromObject(rdr.Item("Spouse_Name")))
            Me.txtHeight.Text = (StringType.FromObject(rdr.Item("Height")))
            Me.txtNotes.Text = (StringType.FromObject(rdr.Item("Notes")))
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("PrimaryAddress_ID")))) Then
                Me.txtPrimaryAddressID.Text = (StringType.FromObject(rdr.Item("PrimaryAddress_ID")))
                Me.setPrimaryAddress(IntegerType.FromString(Me.txtPrimaryAddressID.Text()))
            Else
                Me.txtPrimaryAddressID.Text = ("")
                Me.txtPrimaryAddress.Text = ("")
            End If
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("AlternateAddress_ID")))) Then
                Me.txtAlternateAddressID.Text = (StringType.FromObject(rdr.Item("AlternateAddress_ID")))
                Me.setAlternateAddress(IntegerType.FromString(Me.txtAlternateAddressID.Text()))
            Else
                Me.txtAlternateAddressID.Text = ("")
                Me.txtAlternateAddress.Text = ("")
            End If
            If (Not BooleanType.FromObject(rdr.Item("Gutters"))) Then
                Me.chkGutters.Checked = (False)
            Else
                Me.chkGutters.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("PwrWash"))) Then
                Me.chkPwrWash.Checked = (False)
            Else
                Me.chkPwrWash.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("NewConst"))) Then
                Me.chkNewConst.Checked = (False)
            Else
                Me.chkNewConst.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Mon_AM"))) Then
                Me.chkMonAM.Checked = (False)
            Else
                Me.chkMonAM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Mon_PM"))) Then
                Me.chkMonPM.Checked = (False)
            Else
                Me.chkMonPM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Tues_AM"))) Then
                Me.chkTueAM.Checked = (False)
            Else
                Me.chkTueAM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Tues_PM"))) Then
                Me.chkTuePM.Checked = (False)
            Else
                Me.chkTuePM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Wed_AM"))) Then
                Me.chkWedAM.Checked = (False)
            Else
                Me.chkWedAM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Wed_PM"))) Then
                Me.chkWedPM.Checked = (False)
            Else
                Me.chkWedPM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Th_AM"))) Then
                Me.chkThuAM.Checked = (False)
            Else
                Me.chkThuAM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Th_PM"))) Then
                Me.chkThuPM.Checked = (False)
            Else
                Me.chkThuPM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Fri_AM"))) Then
                Me.chkFriAM.Checked = (False)
            Else
                Me.chkFriAM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Fri_PM"))) Then
                Me.chkFriPM.Checked = (False)
            Else
                Me.chkFriPM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Sat_AM"))) Then
                Me.chkSatAM.Checked = (False)
            Else
                Me.chkSatAM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Sat_PM"))) Then
                Me.chkSatPM.Checked = (False)
            Else
                Me.chkSatPM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Sun_AM"))) Then
                Me.chkSunAM.Checked = (False)
            Else
                Me.chkSunAM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Sun_PM"))) Then
                Me.chkSunPM.Checked = (False)
            Else
                Me.chkSunPM.Checked = (True)
            End If
            If (Not BooleanType.FromObject(rdr.Item("Active"))) Then
                Me.chkActive.Checked = (False)
                Me.chkHiddenActive.Checked = (False)
            Else
                Me.chkActive.Checked = (True)
                Me.chkHiddenActive.Checked = (True)
            End If
            Dim str1 As String = StringType.FromObject(rdr.Item("Phone_No"))
            If (Microsoft.VisualBasic.Strings.Trim(str1).Length() > 0) Then
                Me.txtPrimaryArea.Text = (str1.Substring(0, 3))
                Me.txtPrimaryExch.Text = (str1.Substring(3, 3))
                Me.txtPrimaryNumber.Text = (str1.Substring(6, 4))
            End If
            str1 = StringType.FromObject(rdr.Item("Alt_Phone"))
            If (Microsoft.VisualBasic.Strings.Trim(str1).Length() > 0) Then
                Me.txtAlternateArea.Text = (str1.Substring(0, 3))
                Me.txtAlternateExch.Text = (str1.Substring(3, 3))
                Me.txtAlternateNumber.Text = (str1.Substring(6, 4))
            End If
            Dim dateTime As System.DateTime = DateType.FromObject(rdr.Item("Create_Date"))
            Me.txtCreateDate.Text = (dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtCreateUser.Text = (StringType.FromObject(rdr.Item("Create_User")))
            dateTime = DateType.FromObject(rdr.Item("Modified_Date"))
            Me.txtModifiedDate.Text = (dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtModifiedUser.Text = (StringType.FromObject(rdr.Item("Modified_User")))
            str = If(Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("ParentSub_ID"))), Microsoft.VisualBasic.Strings.Trim(StringType.FromObject(rdr.Item("ParentSub_ID"))), "")
            If (Not Me.setDropDown(Me.lstPrmPhoneType, Microsoft.VisualBasic.Strings.Trim(StringType.FromObject(rdr.Item("Phone_Type"))))) Then
                Me.lstPrmPhoneType.SelectedIndex = (0)
            End If
            If (Not Me.setDropDown(Me.lstAltPhoneType, Microsoft.VisualBasic.Strings.Trim(StringType.FromObject(rdr.Item("Alt_Phone_Type"))))) Then
                Me.lstAltPhoneType.SelectedIndex = (0)
            End If
            If (Not Me.setDropDown(Me.lstParentSub, str)) Then
                Me.lstParentSub.SelectedIndex = (0)
            End If
            Me.assignSubsAreas()
        End Sub

        Public Function searchSubcontractor(ByVal lastName As String, ByVal nickName As String, ByVal primaryPhone As String, ByVal altPhone As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateCriteria(lastName, nickName, primaryPhone, altPhone)
            If (messageHelper.status) Then
                Dim str As String = messageHelper.messageId
                If (StringType.StrCmp(str, "L", False) = 0) Then
                    Me.rdr = Me.uccSubcontractor.getSubcontractorByLastName(lastName)
                ElseIf (StringType.StrCmp(str, "P", False) = 0) Then
                    Me.rdr = Me.uccSubcontractor.getsubcontractorByPrimaryPhone(primaryPhone)
                ElseIf (StringType.StrCmp(str, "A", False) = 0) Then
                    Me.rdr = Me.uccSubcontractor.getsubcontractorByAltPhone(altPhone)
                ElseIf (StringType.StrCmp(str, "N", False) = 0) Then
                    Me.rdr = Me.uccSubcontractor.getsubcontractorByNickName(nickName)
                End If
                messageHelper.status = True
                messageHelper.messageObject = Me.rdr
            End If
            Return messageHelper
        End Function

        Private Sub setAlternateAddress(ByVal addressId As Integer)
            Dim addressById As SqlDataReader = (New UCCAddress()).getAddressById(addressId)
            addressById.Read()
            Me.txtAlternateAddressID.Text = (StringType.FromObject(addressById.Item("Address_ID")))
            Me.txtAlternateAddress.Text = (StringType.FromObject(ObjectType.AddObj(ObjectType.AddObj(ObjectType.AddObj(ObjectType.AddObj(ObjectType.AddObj(ObjectType.AddObj(addressById.Item("Address1"), " "), addressById.Item("City")), ", "), addressById.Item("State")), " "), addressById.Item("ZipCode"))))
            addressById.Close()
        End Sub

        Private Sub setDefaultValues()
            Dim uCCSchedule As BusinessService.UCCSchedule = New BusinessService.UCCSchedule()
            Me.chkMonAM.Checked = (True)
            Me.chkMonPM.Checked = (True)
            Me.chkTueAM.Checked = (True)
            Me.chkTuePM.Checked = (True)
            Me.chkWedAM.Checked = (True)
            Me.chkWedPM.Checked = (True)
            Me.chkThuAM.Checked = (True)
            Me.chkThuPM.Checked = (True)
            Me.chkFriAM.Checked = (True)
            Me.chkFriPM.Checked = (True)
            Me.chkSatAM.Checked = (False)
            Me.chkSatPM.Checked = (False)
            Me.chkSunAM.Checked = (False)
            Me.chkSunPM.Checked = (False)
            Me.chkGutters.Checked = (True)
            Me.chkPwrWash.Checked = (False)
            Me.chkNewConst.Checked = (True)
            Me.txtSpouseName.Text = ("")
            Me.txtNotes.Text = ("")
            Me.txtPrimaryAddress.Text = ("")
            Me.txtPrimaryAddressID.Text = ("")
            Me.txtAlternateAddress.Text = ("")
            Me.txtAlternateAddressID.Text = ("")
            Me.txtHeight.Text = ("2")
            Me.chkActive.Checked = (True)
            Me.txtSubID.Text = ("")
            Me.txtContactName.Text = ("")
            Me.txtDollarMaxAmount.Text = ("")
            Me.txtTID.Text = ("")
            Me.txtUBI.Text = ("")
            Me.txtFirstName.Text = ("")
            Me.txtLastName.Text = ("")
            Me.txtCompanyName.Text = ("")
            Me.txtNickName.Text = ("")
            Me.txtEMail.Text = ("")
            Me.txtPrimaryArea.Text = ("")
            Me.txtPrimaryExch.Text = ("")
            Me.txtPrimaryNumber.Text = ("")
            Me.txtAlternateArea.Text = ("")
            Me.txtAlternateExch.Text = ("")
            Me.txtAlternateNumber.Text = ("")
            Me.txtModifiedUser.Text = ("")
            Me.txtModifiedDate.Text = ("")
            Me.txtCreateUser.Text = ("")
            Me.txtCreateDate.Text = ("")
            Me.setDropDown(Me.lstPrmPhoneType, "R")
            Me.setDropDown(Me.lstAltPhoneType, "B")
            Me.setDropDown(Me.lstParentSub, "")
            Me.rdr = uCCSchedule.getAllActiveAreas()
            Me.chkLstAssignedAreas.DataSource = (Me.rdr)
            Me.chkLstAssignedAreas.DataValueField = ("Area_ID")
            Me.chkLstAssignedAreas.DataTextField = ("Area_Name")
            Me.chkLstAssignedAreas.DataBind()
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

        Private Sub setPrimaryAddress(ByVal addressId As Integer)
            Dim addressById As SqlDataReader = (New UCCAddress()).getAddressById(addressId)
            addressById.Read()
            Me.txtPrimaryAddressID.Text = (StringType.FromObject(addressById.Item("Address_ID")))
            Me.txtPrimaryAddress.Text = (StringType.FromObject(ObjectType.AddObj(ObjectType.AddObj(ObjectType.AddObj(ObjectType.AddObj(ObjectType.AddObj(ObjectType.AddObj(addressById.Item("Address1"), " "), addressById.Item("City")), ", "), addressById.Item("State")), " "), addressById.Item("ZipCode"))))
            addressById.Close()
        End Sub

        Private Sub updateSubcontractor()
            Dim str As String = "<script language=""javascript"">"
            Dim messageHelper As SystemFramework.MessageHelper = Me.updateSubcontractorAll()
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text = (messageHelper.messageText)
            Else
                Me.populateSub(Me.getSub(Me.txtSubID.Text()))
                If (Me.isChild) Then
                    str = String.Concat(str, "window.close();")
                    str = String.Concat(str, "</script>")
                    Me.Page().RegisterClientScriptBlock("subcontractorScript", str)
                End If
            End If
        End Sub

        Private Function updateSubcontractorAll() As SystemFramework.MessageHelper
            Dim num As Integer = If(Not Me.chkActive.Checked, 0, 1)
            Dim num1 As Integer = Func.CastToInt(txtAlternateAddressID.Text, 0)
            Dim num2 As Integer = If(Not Me.chkFriAM.Checked, 0, 1)
            Dim num3 As Integer = If(Not Me.chkFriPM.Checked, 0, 1)
            Dim num4 As Integer = If(Not Me.chkGutters.Checked, 0, 1)
            Dim num5 As Integer = If(Not Me.chkHiddenActive.Checked, 0, 1)
            Dim num6 As Integer = Func.CastToInt(txtDollarMaxAmount.Text, 0)
            Dim num7 As Integer = If(Not Me.chkMonAM.Checked, 0, 1)
            Dim num8 As Integer = If(Not Me.chkMonPM.Checked, 0, 1)
            Dim num9 As Integer = 0
            Dim num10 As Integer = Func.CastToInt(lstParentSub.SelectedItem.Value, 0)
            Dim num11 As Integer = Func.CastToInt(txtPrimaryAddressID.Text, 0)
            Dim num12 As Integer = If(Not Me.chkPwrWash.Checked, 0, 1)
            Dim num13 As Integer = If(Not Me.chkSatAM.Checked, 0, 1)
            Dim num14 As Integer = If(Not Me.chkSatPM.Checked, 0, 1)
            Dim num15 As Integer = If(Not Me.chkSunAM.Checked, 0, 1)
            Dim num16 As Integer = If(Not Me.chkSunPM.Checked, 0, 1)
            Dim num17 As Integer = If(Not Me.chkThuAM.Checked, 0, 1)
            Dim num18 As Integer = If(Not Me.chkThuPM.Checked, 0, 1)
            Dim num19 As Integer = If(Not Me.chkTueAM.Checked, 0, 1)
            Dim num20 As Integer = If(Not Me.chkTuePM.Checked, 0, 1)
            Dim num21 As Integer = If(Not Me.chkWedAM.Checked, 0, 1)
            Dim num22 As Integer = If(Not Me.chkWedPM.Checked, 0, 1)

            If (Not Me.chkNewConst.Checked) Then
                num4 = 0
            Else
                num9 = 1
            End If
            Dim str As String = txtPrimaryArea.Text & Me.txtPrimaryExch.Text & txtPrimaryNumber.Text
            Dim str1 As String = txtAlternateArea.Text & txtAlternateExch.Text & txtAlternateNumber.Text
            Dim arrayList As System.Collections.ArrayList = Me.extractSelectedAreas()
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccSubcontractor.updateSubcontractorAll(IntegerType.FromString(Me.txtSubID.Text()), num10, Microsoft.VisualBasic.Strings.Trim(Me.txtCompanyName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtFirstName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtLastName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtNickName.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtTID.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtUBI.Text()), Microsoft.VisualBasic.Strings.Trim(Me.txtContactName.Text()), str, Me.lstPrmPhoneType.SelectedItem().Value, str1, Me.lstAltPhoneType.SelectedItem().Value, Microsoft.VisualBasic.Strings.Trim(Me.txtEMail.Text()), num6, num7, num8, num19, num20, num21, num22, num17, num18, num2, num3, num13, num14, num15, num16, num, Microsoft.VisualBasic.Strings.Trim(Me.txtHiddenNickName.Text()), num5, arrayList, MyBase.[Operator].userId, DateType.FromString(Me.txtModifiedDate.Text()), Me.txtHeight.Text(), num4, num12, num9, Me.txtSpouseName.Text(), Me.txtNotes.Text(), num11, num1)
            Return messageHelper
        End Function

        Private Sub UWGClient_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGSub.InitializeRow
            Dim dateTime As System.DateTime = New System.DateTime()
            dateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
            e.Row.Cells.FromKey("Create_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
            dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
            e.Row.Cells.FromKey("Modified_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
        End Sub

        Private Function validateCriteria(ByVal lastName As String, ByVal nickName As String, ByVal primaryPhone As String, ByVal altPhone As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (lastName.Length() > 0) Then
                If (Not (nickName.Length() > 0 Or primaryPhone.Length() > 0 Or altPhone.Length() > 0)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "L"
                Else
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.messageText = "Last is mutually exclusive with others"
                End If
            ElseIf (nickName.Length() > 0) Then
                If (Not (lastName.Length() > 0 Or primaryPhone.Length() > 0 Or altPhone.Length() > 0)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "N"
                Else
                    messageHelper.messageId = StringType.FromInteger(2)
                    messageHelper.messageText = "Nick Name is mutually exclusive with others"
                End If
            ElseIf (primaryPhone.Length() <= 0) Then
                If (altPhone.Length() > 0) Then
                    If (nickName.Length() > 0 Or lastName.Length() > 0 Or primaryPhone.Length() > 0) Then
                        messageHelper.messageId = StringType.FromInteger(3)
                        messageHelper.messageText = "Alternate Phone is mutually exclusive with others"
                    ElseIf (altPhone.Length() = 10) Then
                        messageHelper.status = True
                        messageHelper.messageId = "A"
                    Else
                        messageHelper.messageId = StringType.FromInteger(8)
                        messageHelper.messageText = "Alternate Phone Invalid"
                    End If
                End If
            ElseIf (lastName.Length() > 0 Or altPhone.Length() > 0 Or nickName.Length() > 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Primary Phone is mutually exclusive with others"
            ElseIf (primaryPhone.Length() = 10) Then
                messageHelper.status = True
                messageHelper.messageId = "P"
            Else
                messageHelper.messageId = StringType.FromInteger(8)
                messageHelper.messageText = "Primary Phone Invalid"
            End If
            Return messageHelper
        End Function
    End Class
End Namespace