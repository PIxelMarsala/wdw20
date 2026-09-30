Imports BusinessService
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public MustInherit Class job
        Inherits ControlBase

        '<AccessedThroughProperty("Label2")>
        'Private _Label2 As Label

        '<AccessedThroughProperty("txtZipCode")>
        'Private _txtZipCode As TextBox

        '<AccessedThroughProperty("txtState")>
        'Private _txtState As TextBox

        '<AccessedThroughProperty("chkReminder")>
        'Private _chkReminder As CheckBox

        '<AccessedThroughProperty("Label32")>
        'Private _Label32 As Label

        '<AccessedThroughProperty("lstOccO2PhoneType")>
        'Private _lstOccO2PhoneType As DropDownList

        '<AccessedThroughProperty("lstBillPPhoneType")>
        'Private _lstBillPPhoneType As DropDownList

        '<AccessedThroughProperty("lstBillO2PhoneType")>
        'Private _lstBillO2PhoneType As DropDownList

        '<AccessedThroughProperty("lstBillO1PhoneType")>
        'Private _lstBillO1PhoneType As DropDownList

        '<AccessedThroughProperty("lstBillAPhoneType")>
        'Private _lstBillAPhoneType As DropDownList

        '<AccessedThroughProperty("lstOccO1PhoneType")>
        'Private _lstOccO1PhoneType As DropDownList

        '<AccessedThroughProperty("lstOccAPhoneType")>
        'Private _lstOccAPhoneType As DropDownList

        '<AccessedThroughProperty("lstOccPPhoneType")>
        'Private _lstOccPPhoneType As DropDownList

        '<AccessedThroughProperty("txtBillO2Phone")>
        'Private _txtBillO2Phone As TextBox

        '<AccessedThroughProperty("txtBillO1Phone")>
        'Private _txtBillO1Phone As TextBox

        '<AccessedThroughProperty("Label31")>
        'Private _Label31 As Label

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("Label30")>
        'Private _Label30 As Label

        '<AccessedThroughProperty("txtOccO2Phone")>
        'Private _txtOccO2Phone As TextBox

        '<AccessedThroughProperty("txtOccO1Phone")>
        'Private _txtOccO1Phone As TextBox

        '<AccessedThroughProperty("pnlMore")>
        'Private _pnlMore As Panel

        '<AccessedThroughProperty("Label29")>
        'Private _Label29 As Label

        '<AccessedThroughProperty("txtModifiedDate")>
        'Private _txtModifiedDate As TextBox

        '<AccessedThroughProperty("Label22")>
        'Private _Label22 As Label

        '<AccessedThroughProperty("txtModifiedUser")>
        'Private _txtModifiedUser As TextBox

        '<AccessedThroughProperty("Label28")>
        'Private _Label28 As Label

        '<AccessedThroughProperty("txtCreateDate")>
        'Private _txtCreateDate As TextBox

        '<AccessedThroughProperty("Label27")>
        'Private _Label27 As Label

        '<AccessedThroughProperty("txtCreateUser")>
        'Private _txtCreateUser As TextBox

        '<AccessedThroughProperty("Label26")>
        'Private _Label26 As Label

        '<AccessedThroughProperty("txtSubId")>
        'Private _txtSubId As TextBox

        '<AccessedThroughProperty("txtBillLastName")>
        'Private _txtBillLastName As TextBox

        '<AccessedThroughProperty("Label18")>
        'Private _Label18 As Label

        '<AccessedThroughProperty("txtBillFirstName")>
        'Private _txtBillFirstName As TextBox

        '<AccessedThroughProperty("txtNotes")>
        'Private _txtNotes As TextBox

        '<AccessedThroughProperty("txtBillAPhone")>
        'Private _txtBillAPhone As TextBox

        '<AccessedThroughProperty("btnCancel")>
        'Private _btnCancel As Button

        '<AccessedThroughProperty("txtBillPPhone")>
        'Private _txtBillPPhone As TextBox

        '<AccessedThroughProperty("btnSave")>
        'Private _btnSave As Button

        '<AccessedThroughProperty("txtBillContact")>
        'Private _txtBillContact As TextBox

        '<AccessedThroughProperty("txtBillClientId")>
        'Private _txtBillClientId As TextBox

        '<AccessedThroughProperty("Label17")>
        'Private _Label17 As Label

        '<AccessedThroughProperty("Label25")>
        'Private _Label25 As Label

        '<AccessedThroughProperty("Label16")>
        'Private _Label16 As Label

        '<AccessedThroughProperty("Label24")>
        'Private _Label24 As Label

        '<AccessedThroughProperty("Label15")>
        'Private _Label15 As Label

        '<AccessedThroughProperty("Label23")>
        'Private _Label23 As Label

        '<AccessedThroughProperty("Label14")>
        'Private _Label14 As Label

        '<AccessedThroughProperty("txtOccContact")>
        'Private _txtOccContact As TextBox

        '<AccessedThroughProperty("txtOccAPhone")>
        'Private _txtOccAPhone As TextBox

        '<AccessedThroughProperty("Label13")>
        'Private _Label13 As Label

        '<AccessedThroughProperty("txtTime")>
        'Private _txtTime As TextBox

        '<AccessedThroughProperty("chkCritical")>
        'Private _chkCritical As CheckBox

        '<AccessedThroughProperty("Label3")>
        'Private _Label3 As Label

        '<AccessedThroughProperty("chkOutside")>
        'Private _chkOutside As CheckBox

        '<AccessedThroughProperty("txtSchedAmt")>
        'Private _txtSchedAmt As TextBox

        '<AccessedThroughProperty("Label4")>
        'Private _Label4 As Label

        '<AccessedThroughProperty("lstPmtMethod")>
        'Private _lstPmtMethod As DropDownList

        '<AccessedThroughProperty("lstCancelReason")>
        'Private _lstCancelReason As DropDownList

        '<AccessedThroughProperty("txtDescription")>
        'Private _txtDescription As TextBox

        '<AccessedThroughProperty("lstStatus")>
        'Private _lstStatus As DropDownList

        '<AccessedThroughProperty("lblErrorMsg")>
        'Private _lblErrorMsg As Label

        '<AccessedThroughProperty("txtBillAmt")>
        'Private _txtBillAmt As TextBox

        '<AccessedThroughProperty("Label5")>
        'Private _Label5 As Label

        '<AccessedThroughProperty("txtPayBasis")>
        'Private _txtPayBasis As TextBox

        '<AccessedThroughProperty("Label6")>
        'Private _Label6 As Label

        '<AccessedThroughProperty("txtSubPay")>
        'Private _txtSubPay As TextBox

        '<AccessedThroughProperty("Label7")>
        'Private _Label7 As Label

        '<AccessedThroughProperty("chkPriorSched")>
        'Private _chkPriorSched As CheckBox

        '<AccessedThroughProperty("Label8")>
        'Private _Label8 As Label

        '<AccessedThroughProperty("txtJobId")>
        'Private _txtJobId As TextBox

        '<AccessedThroughProperty("txtDate")>
        'Private _txtDate As TextBox

        '<AccessedThroughProperty("txtCareOf")>
        'Private _txtCareOf As TextBox

        '<AccessedThroughProperty("txtSiteId")>
        'Private _txtSiteId As TextBox

        '<AccessedThroughProperty("txtAddr1")>
        'Private _txtAddr1 As TextBox

        '<AccessedThroughProperty("txtSubName")>
        'Private _txtSubName As TextBox

        '<AccessedThroughProperty("txtBidId")>
        'Private _txtBidId As TextBox

        '<AccessedThroughProperty("txtSiteNote")>
        'Private _txtSiteNote As TextBox

        '<AccessedThroughProperty("txtCity")>
        'Private _txtCity As TextBox

        '<AccessedThroughProperty("txtSiteNoStories")>
        'Private _txtSiteNoStories As TextBox

        '<AccessedThroughProperty("Label9")>
        'Private _Label9 As Label

        '<AccessedThroughProperty("txtOccFirstName")>
        'Private _txtOccFirstName As TextBox

        '<AccessedThroughProperty("Label10")>
        'Private _Label10 As Label

        '<AccessedThroughProperty("txtOccLastName")>
        'Private _txtOccLastName As TextBox

        '<AccessedThroughProperty("Label19")>
        'Private _Label19 As Label

        '<AccessedThroughProperty("Label11")>
        'Private _Label11 As Label

        '<AccessedThroughProperty("txtOccClientId")>
        'Private _txtOccClientId As TextBox

        '<AccessedThroughProperty("Label21")>
        'Private _Label21 As Label

        '<AccessedThroughProperty("Label12")>
        'Private _Label12 As Label

        '<AccessedThroughProperty("txtOccPPhone")>
        'Private _txtOccPPhone As TextBox

        '<AccessedThroughProperty("Label20")>
        'Private _Label20 As Label

        Private rdr As SqlDataReader

        Private uccJob As UCCJob

        'Protected Overridable Property btnCancel As Button
        '    Get
        '        Return Me._btnCancel
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnCancel IsNot Nothing) Then
        '            Dim _job As job = Me
        '            Me._btnCancel.remove_Click(New EventHandler(_job, _job.btnCancel_Click))
        '        End If
        '        Me._btnCancel = value
        '        If (Me._btnCancel IsNot Nothing) Then
        '            Dim _job1 As job = Me
        '            Me._btnCancel.add_Click(New EventHandler(_job1, _job1.btnCancel_Click))
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
        '            Dim _job As job = Me
        '            Me._btnSave.remove_Click(New EventHandler(_job, _job.btnSave_Click))
        '        End If
        '        Me._btnSave = value
        '        If (Me._btnSave IsNot Nothing) Then
        '            Dim _job1 As job = Me
        '            Me._btnSave.add_Click(New EventHandler(_job1, _job1.btnSave_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property chkCritical As CheckBox
        '    Get
        '        Return Me._chkCritical
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkCritical Is Nothing
        '        Me._chkCritical = value
        '        Me._chkCritical Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkOutside As CheckBox
        '    Get
        '        Return Me._chkOutside
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkOutside Is Nothing
        '        Me._chkOutside = value
        '        Me._chkOutside Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkPriorSched As CheckBox
        '    Get
        '        Return Me._chkPriorSched
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkPriorSched Is Nothing
        '        Me._chkPriorSched = value
        '        Me._chkPriorSched Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property chkReminder As CheckBox
        '    Get
        '        Return Me._chkReminder
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CheckBox)
        '        Me._chkReminder Is Nothing
        '        Me._chkReminder = value
        '        Me._chkReminder Is Nothing
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

        'Protected Overridable Property lstBillAPhoneType As DropDownList
        '    Get
        '        Return Me._lstBillAPhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstBillAPhoneType Is Nothing
        '        Me._lstBillAPhoneType = value
        '        Me._lstBillAPhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstBillO1PhoneType As DropDownList
        '    Get
        '        Return Me._lstBillO1PhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstBillO1PhoneType Is Nothing
        '        Me._lstBillO1PhoneType = value
        '        Me._lstBillO1PhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstBillO2PhoneType As DropDownList
        '    Get
        '        Return Me._lstBillO2PhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstBillO2PhoneType Is Nothing
        '        Me._lstBillO2PhoneType = value
        '        Me._lstBillO2PhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstBillPPhoneType As DropDownList
        '    Get
        '        Return Me._lstBillPPhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstBillPPhoneType Is Nothing
        '        Me._lstBillPPhoneType = value
        '        Me._lstBillPPhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstCancelReason As DropDownList
        '    Get
        '        Return Me._lstCancelReason
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstCancelReason Is Nothing
        '        Me._lstCancelReason = value
        '        Me._lstCancelReason Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstOccAPhoneType As DropDownList
        '    Get
        '        Return Me._lstOccAPhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstOccAPhoneType Is Nothing
        '        Me._lstOccAPhoneType = value
        '        Me._lstOccAPhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstOccO1PhoneType As DropDownList
        '    Get
        '        Return Me._lstOccO1PhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstOccO1PhoneType Is Nothing
        '        Me._lstOccO1PhoneType = value
        '        Me._lstOccO1PhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstOccO2PhoneType As DropDownList
        '    Get
        '        Return Me._lstOccO2PhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstOccO2PhoneType Is Nothing
        '        Me._lstOccO2PhoneType = value
        '        Me._lstOccO2PhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstOccPPhoneType As DropDownList
        '    Get
        '        Return Me._lstOccPPhoneType
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstOccPPhoneType Is Nothing
        '        Me._lstOccPPhoneType = value
        '        Me._lstOccPPhoneType Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstPmtMethod As DropDownList
        '    Get
        '        Return Me._lstPmtMethod
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstPmtMethod Is Nothing
        '        Me._lstPmtMethod = value
        '        Me._lstPmtMethod Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstStatus As DropDownList
        '    Get
        '        Return Me._lstStatus
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstStatus Is Nothing
        '        Me._lstStatus = value
        '        Me._lstStatus Is Nothing
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

        'Protected Overridable Property txtBidId As TextBox
        '    Get
        '        Return Me._txtBidId
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBidId Is Nothing
        '        Me._txtBidId = value
        '        Me._txtBidId Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillAmt As TextBox
        '    Get
        '        Return Me._txtBillAmt
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillAmt Is Nothing
        '        Me._txtBillAmt = value
        '        Me._txtBillAmt Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillAPhone As TextBox
        '    Get
        '        Return Me._txtBillAPhone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillAPhone Is Nothing
        '        Me._txtBillAPhone = value
        '        Me._txtBillAPhone Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillClientId As TextBox
        '    Get
        '        Return Me._txtBillClientId
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillClientId Is Nothing
        '        Me._txtBillClientId = value
        '        Me._txtBillClientId Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillContact As TextBox
        '    Get
        '        Return Me._txtBillContact
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillContact Is Nothing
        '        Me._txtBillContact = value
        '        Me._txtBillContact Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillFirstName As TextBox
        '    Get
        '        Return Me._txtBillFirstName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillFirstName Is Nothing
        '        Me._txtBillFirstName = value
        '        Me._txtBillFirstName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillLastName As TextBox
        '    Get
        '        Return Me._txtBillLastName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillLastName Is Nothing
        '        Me._txtBillLastName = value
        '        Me._txtBillLastName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillO1Phone As TextBox
        '    Get
        '        Return Me._txtBillO1Phone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillO1Phone Is Nothing
        '        Me._txtBillO1Phone = value
        '        Me._txtBillO1Phone Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillO2Phone As TextBox
        '    Get
        '        Return Me._txtBillO2Phone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillO2Phone Is Nothing
        '        Me._txtBillO2Phone = value
        '        Me._txtBillO2Phone Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillPPhone As TextBox
        '    Get
        '        Return Me._txtBillPPhone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillPPhone Is Nothing
        '        Me._txtBillPPhone = value
        '        Me._txtBillPPhone Is Nothing
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

        'Protected Overridable Property txtDate As TextBox
        '    Get
        '        Return Me._txtDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtDate Is Nothing
        '        Me._txtDate = value
        '        Me._txtDate Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtDescription As TextBox
        '    Get
        '        Return Me._txtDescription
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtDescription Is Nothing
        '        Me._txtDescription = value
        '        Me._txtDescription Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtJobId As TextBox
        '    Get
        '        Return Me._txtJobId
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtJobId Is Nothing
        '        Me._txtJobId = value
        '        Me._txtJobId Is Nothing
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

        'Protected Overridable Property txtOccAPhone As TextBox
        '    Get
        '        Return Me._txtOccAPhone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccAPhone Is Nothing
        '        Me._txtOccAPhone = value
        '        Me._txtOccAPhone Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccClientId As TextBox
        '    Get
        '        Return Me._txtOccClientId
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccClientId Is Nothing
        '        Me._txtOccClientId = value
        '        Me._txtOccClientId Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccContact As TextBox
        '    Get
        '        Return Me._txtOccContact
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccContact Is Nothing
        '        Me._txtOccContact = value
        '        Me._txtOccContact Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccFirstName As TextBox
        '    Get
        '        Return Me._txtOccFirstName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccFirstName Is Nothing
        '        Me._txtOccFirstName = value
        '        Me._txtOccFirstName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccLastName As TextBox
        '    Get
        '        Return Me._txtOccLastName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccLastName Is Nothing
        '        Me._txtOccLastName = value
        '        Me._txtOccLastName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccO1Phone As TextBox
        '    Get
        '        Return Me._txtOccO1Phone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccO1Phone Is Nothing
        '        Me._txtOccO1Phone = value
        '        Me._txtOccO1Phone Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccO2Phone As TextBox
        '    Get
        '        Return Me._txtOccO2Phone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccO2Phone Is Nothing
        '        Me._txtOccO2Phone = value
        '        Me._txtOccO2Phone Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtOccPPhone As TextBox
        '    Get
        '        Return Me._txtOccPPhone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtOccPPhone Is Nothing
        '        Me._txtOccPPhone = value
        '        Me._txtOccPPhone Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtPayBasis As TextBox
        '    Get
        '        Return Me._txtPayBasis
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPayBasis Is Nothing
        '        Me._txtPayBasis = value
        '        Me._txtPayBasis Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSchedAmt As TextBox
        '    Get
        '        Return Me._txtSchedAmt
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSchedAmt Is Nothing
        '        Me._txtSchedAmt = value
        '        Me._txtSchedAmt Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSiteId As TextBox
        '    Get
        '        Return Me._txtSiteId
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSiteId Is Nothing
        '        Me._txtSiteId = value
        '        Me._txtSiteId Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSiteNoStories As TextBox
        '    Get
        '        Return Me._txtSiteNoStories
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSiteNoStories Is Nothing
        '        Me._txtSiteNoStories = value
        '        Me._txtSiteNoStories Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSiteNote As TextBox
        '    Get
        '        Return Me._txtSiteNote
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSiteNote Is Nothing
        '        Me._txtSiteNote = value
        '        Me._txtSiteNote Is Nothing
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

        'Protected Overridable Property txtSubId As TextBox
        '    Get
        '        Return Me._txtSubId
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSubId Is Nothing
        '        Me._txtSubId = value
        '        Me._txtSubId Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSubName As TextBox
        '    Get
        '        Return Me._txtSubName
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSubName Is Nothing
        '        Me._txtSubName = value
        '        Me._txtSubName Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSubPay As TextBox
        '    Get
        '        Return Me._txtSubPay
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSubPay Is Nothing
        '        Me._txtSubPay = value
        '        Me._txtSubPay Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtTime As TextBox
        '    Get
        '        Return Me._txtTime
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtTime Is Nothing
        '        Me._txtTime = value
        '        Me._txtTime Is Nothing
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

        Public Sub New()
            MyBase.New()
            Dim _job As job = Me
            'MyBase.add_Init(New EventHandler(_job, _job.Page_Init))
            Dim _job1 As job = Me
            'MyBase.add_Load(New EventHandler(_job1, _job1.Page_Load))
            Me.uccJob = New UCCJob()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Dim str As String = String.Concat("<script language=""javascript"">", "window.close();")
            str = String.Concat(str, "</script>")
            Me.Page().RegisterClientScriptBlock("", str)
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            Dim str As String = "<script language=""javascript"">"
            Dim messageHelper As SystemFramework.MessageHelper = Me.updateJobAll()
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text = (messageHelper.messageText)
            Else
                str = String.Concat(str, "window.opener.", Me.Parent().Page().GetPostBackEventReference(Me.Page()), ";window.close();")
                str = String.Concat(str, "</script>")
                Me.Page().RegisterClientScriptBlock("", str)
            End If
        End Sub

        Private Function buildPhone(ByVal phone As String) As String
            Dim str As String = Nothing
            If (phone.Length() <= 0) Then
                Return str
            End If
            Dim strArray() As String = {phone.Substring(0, 3), " ", phone.Substring(3, 3), "-", phone.Substring(6, 4)}
            Return String.Concat(strArray)
        End Function

        Private Function buildStartDate(ByVal inputDate As System.DateTime, ByVal time As Integer) As System.DateTime
            Dim dateTime As System.DateTime = New System.DateTime(inputDate.Year(), inputDate.Month(), inputDate.Day(), time, 0, 1)
            Return dateTime
        End Function

        Public Function getJob(ByVal job_id As String) As System.Data.SqlClient.SqlDataReader
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
            Dim uCCSchedule As BusinessService.UCCSchedule = New BusinessService.UCCSchedule()
            Me.rdr = uCCSchedule.getJobById(IntegerType.FromString(job_id))
            Me.rdr.Read()
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr.Item("Sub_ID")))) Then
                Me.txtSubId.Text=(StringType.FromObject(Me.rdr.Item("Sub_ID")))
                Me.setSubcontractor(IntegerType.FromString(Me.txtSubId.Text()))
            Else
                Me.txtSubId.Text=("")
            End If
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr.Item("BidHeader_ID")))) Then
                Me.txtBidId.Text=(StringType.FromObject(Me.rdr.Item("BidHeader_ID")))
            Else
                Me.txtBidId.Text=("")
            End If
            Me.txtJobId.Text = (job_id)
            Dim dateTime As System.DateTime = DateType.FromObject(Me.rdr.Item("Start_Date"))
            Me.txtDate.Text=(dateTime.ToString("MM/dd/yy"))
            Me.txtTime.Text=(dateTime.ToString("HH"))
            Me.ViewState().Item("oldHours") = dateTime.ToString("HH")
            Me.ViewState().Item("oldStatus") = RuntimeHelpers.GetObjectValue(Me.rdr.Item("Status"))
            Me.ViewState().Item("oldUser") = RuntimeHelpers.GetObjectValue(Me.rdr.Item("Modified_User"))
            Me.txtSiteId.Text=(StringType.FromObject(Me.rdr.Item("Site_ID")))
            Me.setSite(IntegerType.FromString(Me.txtSiteId.Text()))
            Me.txtSchedAmt.Text = (Strings.Format(RuntimeHelpers.GetObjectValue(Me.rdr.Item("Schedule_Amount")), "#0.00"))
            Me.txtBillAmt.Text = (Strings.Format(RuntimeHelpers.GetObjectValue(Me.rdr.Item("Bill_Amount")), "#0.00"))
            Me.txtPayBasis.Text = (Strings.Format(RuntimeHelpers.GetObjectValue(Me.rdr.Item("Pay_Basis")), "#0.00"))
            Me.txtSubPay.Text = (Strings.Format(RuntimeHelpers.GetObjectValue(Me.rdr.Item("Sub_Pay")), "#0.00"))
            Me.txtDescription.Text=(StringType.FromObject(Me.rdr.Item("Job_Description")))
            Me.txtNotes.Text=(StringType.FromObject(Me.rdr.Item("Notes")))
            dateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
            Me.txtCreateDate.Text=(dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtCreateUser.Text=(StringType.FromObject(Me.rdr.Item("Create_User")))
            dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
            Me.txtModifiedDate.Text=(dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtModifiedUser.Text=(StringType.FromObject(Me.rdr.Item("Modified_User")))
            If (BooleanType.FromObject(Me.rdr.Item("Reminder"))) Then
                Me.chkReminder.Checked=(True)
            End If
            If (BooleanType.FromObject(Me.rdr.Item("Critical"))) Then
                Me.chkCritical.Checked=(True)
            End If
            If (BooleanType.FromObject(Me.rdr.Item("Prior_Schedule"))) Then
                Me.chkPriorSched.Checked=(True)
            End If
            If (BooleanType.FromObject(Me.rdr.Item("Outside_Only"))) Then
                Me.chkOutside.Checked=(True)
            End If
            Dim listItem As System.Web.UI.WebControls.ListItem = New System.Web.UI.WebControls.ListItem("Closed", "C")
            Dim listItem1 As System.Web.UI.WebControls.ListItem = New System.Web.UI.WebControls.ListItem("Dispatched", "D")
            If (ObjectType.ObjTst(Me.rdr.Item("Status"), "O", False) = 0) Then
                Me.lstStatus.Items().Remove(listItem)
                Me.lstStatus.Items().Remove(listItem1)
            End If
            Me.setDropDown(Me.lstStatus, Strings.Trim(StringType.FromObject(Me.rdr.Item("Status"))))
            Me.setDropDown(Me.lstPmtMethod, Strings.Trim(StringType.FromObject(Me.rdr.Item("Payment_Method"))))
            If (Not Me.setDropDown(Me.lstCancelReason, Strings.Trim(StringType.FromObject(Me.rdr.Item("Cancel_Reason"))))) Then
                Me.lstCancelReason.SelectedIndex=(0)
            End If
            Me.setDisplayRules(Me.rdr)
            Return sqlDataReader
        End Function

        <DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub loadListBoxes()
            Dim activeCodesByCodeDescription As SqlDataReader = UCCCode.getActiveCodesByCodeDescription("Job Status")
            Me.lstStatus.DataSource=(activeCodesByCodeDescription)
            Me.lstStatus.DataValueField=("Element_ID")
            Me.lstStatus.DataTextField = ("Element_Description")
            Me.lstStatus.DataBind()
            activeCodesByCodeDescription = UCCCode.getActiveCodesByCodeDescription("Payment Method")
            Me.lstPmtMethod.DataSource=(activeCodesByCodeDescription)
            Me.lstPmtMethod.DataValueField=("Element_ID")
            Me.lstPmtMethod.DataTextField = ("Element_Description")
            Me.lstPmtMethod.DataBind()
            activeCodesByCodeDescription = UCCCode.getActiveCodesByCodeDescription("Cancel Reason")
            Me.lstCancelReason.DataSource=(activeCodesByCodeDescription)
            Me.lstCancelReason.DataValueField=("Element_ID")
            Me.lstCancelReason.DataTextField = ("Element_Description")
            Me.lstCancelReason.DataBind()
            Me.lstCancelReason.Items().Insert(0, New ListItem("", ""))
            Dim activeCodesByCodeDescriptionDS As DataSet = UCCCode.getActiveCodesByCodeDescriptionDS("Phone Type")
            Me.lstOccPPhoneType.DataSource=(activeCodesByCodeDescriptionDS)
            Me.lstOccPPhoneType.DataValueField=("Element_ID")
            Me.lstOccPPhoneType.DataTextField = ("Element_Description")
            Me.lstOccPPhoneType.DataBind()
            Me.lstOccPPhoneType.Items().Insert(0, New ListItem("", ""))
            Me.lstOccAPhoneType.DataSource=(activeCodesByCodeDescriptionDS)
            Me.lstOccAPhoneType.DataValueField=("Element_ID")
            Me.lstOccAPhoneType.DataTextField = ("Element_Description")
            Me.lstOccAPhoneType.DataBind()
            Me.lstOccO1PhoneType.Items().Insert(0, New ListItem("", ""))
            Me.lstOccO1PhoneType.DataSource=(activeCodesByCodeDescriptionDS)
            Me.lstOccO1PhoneType.DataValueField=("Element_ID")
            Me.lstOccO1PhoneType.DataTextField = ("Element_Description")
            Me.lstOccO1PhoneType.DataBind()
            Me.lstOccO1PhoneType.Items().Insert(0, New ListItem("", ""))
            Me.lstOccO2PhoneType.DataSource=(activeCodesByCodeDescriptionDS)
            Me.lstOccO2PhoneType.DataValueField=("Element_ID")
            Me.lstOccO2PhoneType.DataTextField = ("Element_Description")
            Me.lstOccO2PhoneType.DataBind()
            Me.lstOccO2PhoneType.Items().Insert(0, New ListItem("", ""))
            Me.lstBillPPhoneType.DataSource=(activeCodesByCodeDescriptionDS)
            Me.lstBillPPhoneType.DataValueField=("Element_ID")
            Me.lstBillPPhoneType.DataTextField = ("Element_Description")
            Me.lstBillPPhoneType.DataBind()
            Me.lstBillPPhoneType.Items().Insert(0, New ListItem("", ""))
            Me.lstBillAPhoneType.DataSource=(activeCodesByCodeDescriptionDS)
            Me.lstBillAPhoneType.DataValueField=("Element_ID")
            Me.lstBillAPhoneType.DataTextField = ("Element_Description")
            Me.lstBillAPhoneType.DataBind()
            Me.lstBillO1PhoneType.Items().Insert(0, New ListItem("", ""))
            Me.lstBillO1PhoneType.DataSource=(activeCodesByCodeDescriptionDS)
            Me.lstBillO1PhoneType.DataValueField=("Element_ID")
            Me.lstBillO1PhoneType.DataTextField = ("Element_Description")
            Me.lstBillO1PhoneType.DataBind()
            Me.lstBillO1PhoneType.Items().Insert(0, New ListItem("", ""))
            Me.lstBillO2PhoneType.DataSource=(activeCodesByCodeDescriptionDS)
            Me.lstBillO2PhoneType.DataValueField=("Element_ID")
            Me.lstBillO2PhoneType.DataTextField = ("Element_Description")
            Me.lstBillO2PhoneType.DataBind()
            Me.lstBillO2PhoneType.Items().Insert(0, New ListItem("", ""))
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
            Me.txtDescription.Attributes().Add("onkeypress", "return isMaxLength(this);")
            If (Not Me.Page().IsClientScriptBlockRegistered("lengthEdit")) Then
                Me.Page().RegisterClientScriptBlock("lengthEdit", str)
            End If
            If (Not Me.Page().IsPostBack()) Then
                Me.loadListBoxes()
                Dim item As String = Me.Parent().Page().Request().Item("Job_ID")
                Me.getJob(item)
            End If
        End Sub

        Private Sub setDisplayRules(ByVal rdr As SqlDataReader)
            Dim str As String = StringType.FromObject(rdr.Item("Status"))
            If (StringType.StrCmp(str, "C", False) = 0 Or StringType.StrCmp(str, "X", False) = 0) Then
                Me.txtTime.ReadOnly = (True)
                Me.txtSchedAmt.ReadOnly = (True)
                Me.txtBillAmt.ReadOnly = (True)
                Me.txtPayBasis.ReadOnly = (True)
                Me.txtSubPay.ReadOnly = (True)
                Me.chkCritical.Enabled=(False)
                Me.chkReminder.Enabled=(False)
                Me.chkOutside.Enabled=(False)
                Me.lstCancelReason.Enabled=(False)
                Me.lstPmtMethod.Enabled=(False)
                Me.lstStatus.Enabled=(False)
            End If
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
                        list.SelectedIndex=(num)
                        current.Selected=(True)
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

        Private Sub setSite(ByVal siteId As Integer)
            Dim siteById As SqlDataReader = (New UCCSite()).getSiteById(siteId)
            siteById.Read()
            Me.txtAddr1.Text=(StringType.FromObject(siteById.Item("Address1")))
            Me.txtCity.Text=(StringType.FromObject(siteById.Item("City")))
            Me.txtState.Text=(StringType.FromObject(siteById.Item("State")))
            Me.txtZipCode.Text=(StringType.FromObject(siteById.Item("ZipCode")))
            Me.txtSiteNote.Text=(StringType.FromObject(siteById.Item("Notes")))
            Me.txtCareOf.Text=(StringType.FromObject(siteById.Item("CareOf")))
            If (ObjectType.ObjTst(siteById.Item("Note_Type"), 1, False) = 0) Then
                Me.txtSiteNote.BackColor=(Color.LightCoral())
            End If
            Me.txtSiteNoStories.Text=(StringType.FromObject(siteById.Item("No_Stories")))
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(siteById.Item("OccClient_ID")))) Then
                Me.txtOccClientId.Text=(StringType.FromObject(siteById.Item("OccClient_ID")))
                Me.txtOccFirstName.Text=(StringType.FromObject(siteById.Item("Occ_First")))
                Me.txtOccLastName.Text=(StringType.FromObject(siteById.Item("Occ_Last")))
                Me.txtOccContact.Text=(StringType.FromObject(siteById.Item("Occ_Contact")))
                Me.txtOccPPhone.Text = (Me.buildPhone(StringType.FromObject(siteById.Item("Occ_Phone"))))
                Me.txtOccAPhone.Text = (Me.buildPhone(StringType.FromObject(siteById.Item("Occ_AltPhone"))))
                Me.txtOccO1Phone.Text = (Me.buildPhone(StringType.FromObject(siteById.Item("Occ_O1Phone"))))
                Me.txtOccO2Phone.Text = (Me.buildPhone(StringType.FromObject(siteById.Item("Occ_O2Phone"))))
                If (Not Me.setDropDown(Me.lstOccPPhoneType, Strings.Trim(StringType.FromObject(siteById.Item("Occ_Phone_Type"))))) Then
                    Me.lstOccPPhoneType.SelectedIndex=(0)
                End If
                If (Not Me.setDropDown(Me.lstOccAPhoneType, Strings.Trim(StringType.FromObject(siteById.Item("Occ_Alt_Phone_Type"))))) Then
                    Me.lstOccAPhoneType.SelectedIndex=(0)
                End If
                If (Not Me.setDropDown(Me.lstOccO1PhoneType, Strings.Trim(StringType.FromObject(siteById.Item("Occ_O1Phone_Type"))))) Then
                    Me.lstOccO1PhoneType.SelectedIndex=(0)
                End If
                If (Not Me.setDropDown(Me.lstOccO2PhoneType, Strings.Trim(StringType.FromObject(siteById.Item("Occ_O2Phone_Type"))))) Then
                    Me.lstOccO2PhoneType.SelectedIndex=(0)
                End If
            End If
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(siteById.Item("BillClient_ID")))) Then
                Me.txtBillClientId.Text=(StringType.FromObject(siteById.Item("BillClient_ID")))
                Me.txtBillFirstName.Text=(StringType.FromObject(siteById.Item("Bill_First")))
                Me.txtBillLastName.Text=(StringType.FromObject(siteById.Item("Bill_Last")))
                Me.txtBillContact.Text=(StringType.FromObject(siteById.Item("Bill_Contact")))
                Me.txtBillPPhone.Text = (Me.buildPhone(StringType.FromObject(siteById.Item("Bill_Phone"))))
                Me.txtBillAPhone.Text = (Me.buildPhone(StringType.FromObject(siteById.Item("Bill_AltPhone"))))
                Me.txtBillO1Phone.Text = (Me.buildPhone(StringType.FromObject(siteById.Item("Bill_O1Phone"))))
                Me.txtBillO2Phone.Text = (Me.buildPhone(StringType.FromObject(siteById.Item("Bill_O2Phone"))))
                If (Not Me.setDropDown(Me.lstBillPPhoneType, Strings.Trim(StringType.FromObject(siteById.Item("Bill_Phone_Type"))))) Then
                    Me.lstBillPPhoneType.SelectedIndex=(0)
                End If
                If (Not Me.setDropDown(Me.lstBillAPhoneType, Strings.Trim(StringType.FromObject(siteById.Item("Bill_Alt_Phone_Type"))))) Then
                    Me.lstBillAPhoneType.SelectedIndex=(0)
                End If
                If (Not Me.setDropDown(Me.lstBillO1PhoneType, Strings.Trim(StringType.FromObject(siteById.Item("Bill_O1Phone_Type"))))) Then
                    Me.lstBillO1PhoneType.SelectedIndex=(0)
                End If
                If (Not Me.setDropDown(Me.lstBillO2PhoneType, Strings.Trim(StringType.FromObject(siteById.Item("Bill_O2Phone_Type"))))) Then
                    Me.lstBillO2PhoneType.SelectedIndex=(0)
                End If
            End If
            siteById.Close()
        End Sub

        Private Sub setSubcontractor(ByVal subId As Integer)
            Dim subById As SqlDataReader = (New UCCSubcontractor()).getSubById(subId)
            subById.Read()
            Me.txtSubName.Text=(StringType.FromObject(subById.Item("Nick_Name")))
            subById.Close()
        End Sub

        Private Function updateJobAll() As SystemFramework.MessageHelper
            Dim num As Integer = Func.CastToInt(txtBidId.Text, 0)
            Dim num1 As Integer = IIf(chkCritical.Checked, 1, 0)
            Dim num2 As Integer = IIf(chkOutside.Checked, 1, 0)
            Dim num3 As Integer = IIf(chkPriorSched.Checked, 1, 0)
            Dim num4 As Integer = IIf(chkReminder.Checked, 1, 0)
            Dim num5 As Integer = Func.CastToInt(txtSubId.Text, 0)
            Dim flag As Boolean = False

            If Func.CastToInt(ViewState().Item("oldHours"), 0) = Func.CastToInt(txtTime.Text, 0) Then flag = True

            'If (IntegerType.FromObject(Me.ViewState().Item("oldHours")) = IntegerType.FromString(Me.txtTime.Text())) Then
            '    flag = True
            'End If

            Dim dateTime As System.DateTime = Me.buildStartDate(DateType.FromString(Me.txtDate.Text()), IntegerType.FromString(Me.txtTime.Text()))
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccJob.updateJobAll(IntegerType.FromString(Me.txtJobId.Text()), num5, num, num4, num1, num3,
                                                                                        Me.txtDescription.Text(), Me.txtNotes.Text(), flag,
                                                                                        dateTime, dateTime, num2,
                                                                                        Func.CastToDec(Request.Form(txtPayBasis.UniqueID), 0),
                                                                                        Func.CastToDec(Request.Form(txtBillAmt.UniqueID), 0),
                                                                                        Func.CastToDec(Request.Form(txtSubPay.UniqueID), 0),
                                                                                        Func.CastToDec(Request.Form(txtSchedAmt.UniqueID), 0),
                                                                                        Me.lstPmtMethod.SelectedItem().Value,
                                                                                        Me.lstStatus.SelectedItem().Value,
                                                                                        Me.lstCancelReason.SelectedItem().Value,
                                                                                        StringType.FromObject(Me.ViewState().Item("oldStatus")),
                                                                                        StringType.FromObject(Me.ViewState().Item("oldUser")),
                                                                                        Me.txtCreateUser.Text(),
                                                                                        DateType.FromString(Me.txtCreateDate.Text()),
                                                                                        MyBase.[Operator].userId,
                                                                                        DateType.FromString(Me.txtModifiedDate.Text()))


            Return messageHelper
        End Function
    End Class
End Namespace