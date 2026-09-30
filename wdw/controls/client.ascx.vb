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
Imports Strings = Microsoft.VisualBasic.Strings

Namespace wdw
    Public MustInherit Class client1
        Inherits ControlBase

        Private uccClient As UCCClient

        Private rdr As SqlDataReader

        Private isChild As Boolean

        Private parentRequestor As String

        Public Sub New()
            MyBase.New()
            Dim _client1 As client1 = Me
            Dim _client11 As client1 = Me

            Me.uccClient = New UCCClient()
            Me.isChild = False
            Me.parentRequestor = ""
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Dim str As String = String.Concat("<script language=""javascript"">", "window.close();")
            str = String.Concat(str, "</script>")
            Me.Page().RegisterClientScriptBlock("", str)
        End Sub

        Private Sub btnNewClient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewClient.Click
            Me.setDefaultValues()
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            If (Me.txtClientID.Text().Length() <> 0) Then
                Me.updateClient()
            Else
                Me.createClient()
            End If
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            Me.setDefaultValues()
            Dim str As String = String.Concat(Me.txtSrchPrimaryArea.Text(), Me.txtSrchPrimaryExch.Text(), Me.txtSrchPrimaryNumber.Text())
            Dim str1 As String = String.Concat(Me.txtSrchAlternateArea.Text(), Me.txtSrchAlternateExch.Text(), Me.txtSrchAlternateNumber.Text())
            messageHelper = Me.searchClient(Strings.Trim(Me.txtSrchLastName.Text()), Strings.Trim(Me.txtSrchClientID.Text()), Strings.Trim(Me.txtSrchContact.Text()), str, str1)
            If (messageHelper.status) Then
                Me.UWGClient.DisplayLayout.ViewType = ViewType.Flat
                Me.UWGClient.DataSource = (RuntimeHelpers.GetObjectValue(messageHelper.messageObject))
                Me.UWGClient.DataBind()
                If (Me.UWGClient.Rows.Count() = 0) Then
                    messageHelper.messageText = "No Records Found for Search Criteria"
                End If
            End If
            Me.lblErrorMsg.Text = (messageHelper.messageText)
        End Sub

        Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelect.Click
            Dim str As String = "<script language=""javascript"">"
            If (Me.isChild) Then
                str = IIf(StringType.StrCmp(Me.parentRequestor, "1", False) <> 0, String.Concat(str, "window.opener.setBClient("), String.Concat(str, "window.opener.setOClient("))
                str = String.Concat(str, Me.txtClientID.Text(), ", ")
                str = String.Concat(String.Concat(str, """", Me.txtFirstName.Text()), """, ")
                str = String.Concat(str, """", Me.txtLastName.Text(), """")
                str = String.Concat(str, ");window.close();")
                str = String.Concat(str, "</script>")
                Me.Page().RegisterClientScriptBlock("", str)
            End If
        End Sub

        Private Sub createClient()
            Dim str As String = "<script language=""javascript"">"
            Dim messageHelper As SystemFramework.MessageHelper = Me.createClientAll()
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text=(messageHelper.messageText)
            Else
                Me.getClient(StringType.FromObject(messageHelper.messageObject))
                If (Me.isChild) Then
                    str = If(StringType.StrCmp(Me.parentRequestor, "1", False) <> 0, String.Concat(str, "window.opener.setBClient("), String.Concat(str, "window.opener.setOClient("))
                    str = String.Concat(str, Me.txtClientID.Text(), ", ")
                    str = String.Concat(String.Concat(str, """", Me.txtFirstName.Text()), """, ")
                    str = String.Concat(str, """", Me.txtLastName.Text(), """")
                    str = String.Concat(str, ");window.close();")
                    str = String.Concat(str, "</script>")
                    Me.Page().RegisterClientScriptBlock("", str)
                End If
            End If
        End Sub

        Private Function createClientAll() As SystemFramework.MessageHelper
            Dim num As Integer
            Dim num1 As Integer = Func.CastToInt(Me.txtBillingAddressID.Text, 0)
            Dim num2 As Integer
            'num1 = IIf(Microsoft.VisualBasic.Strings.Trim(Me.txtBillingAddressID.Text()).Length() <> 0, IntegerType.FromString(Me.txtBillingAddressID.Text()), 0)
            num2 = IIf(Not Me.chkCOD.Checked, 0, 1)
            num = IIf(Not Me.chkActive.Checked, 0, 1)
            Dim str As String = String.Concat(Me.txtPrimaryArea.Text(), Me.txtPrimaryExch.Text(), Me.txtPrimaryNumber.Text())
            Dim str1 As String = String.Concat(Me.txtAlternateArea.Text(), Me.txtAlternateExch.Text(), Me.txtAlternateNumber.Text())
            Dim str2 As String = String.Concat(Me.txtOther1Area.Text(), Me.txtOther1Exch.Text(), Me.txtOther1Number.Text())
            Dim str3 As String = String.Concat(Me.txtOther2Area.Text(), Me.txtOther2Exch.Text(), Me.txtOther2Number.Text())
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccClient.createClient(num1, Strings.Trim(Me.txtFirstName.Text()), Strings.Trim(Me.txtLastName.Text()), Me.lstDiscount.SelectedItem().Value, Me.lstClientType.SelectedItem().Value, num2, Strings.Trim(Me.txtSpouseName.Text()), Strings.Trim(Me.txtContactName.Text()), str, Me.lstPrimaryPhoneType.SelectedItem().Value, str1, Me.lstAltPhoneType.SelectedItem().Value, Me.lstAccountType.SelectedItem().Value, Strings.Trim(Me.txtNotes.Text()), str2, Me.lstOther1PhoneType.SelectedItem().Value, str3, Me.lstOther2PhoneType.SelectedItem().Value, Strings.Trim(Me.txtEmail.Text()), num, MyBase.[Operator].userId, MyBase.[Operator].userId)
            Return messageHelper
        End Function

        Public Sub getClient(ByVal client_id As String)
            Dim uCCClient As BusinessService.UCCClient = New BusinessService.UCCClient()
            Me.rdr = uCCClient.getClientById(IntegerType.FromString(client_id))
            Me.rdr.Read()
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr.Item("BillAddress_ID")))) Then
                Me.txtBillingAddressID.Text=(StringType.FromObject(Me.rdr.Item("BillAddress_ID")))
                Me.setAddress(IntegerType.FromString(Me.txtBillingAddressID.Text()))
            Else
                Me.txtBillingAddressID.Text=("")
            End If
            Me.txtFirstName.Text=(StringType.FromObject(Me.rdr.Item("First_Name")))
            Me.txtLastName.Text=(StringType.FromObject(Me.rdr.Item("Last_Name")))
            Me.txtClientID.Text = (client_id)
            Me.txtSpouseName.Text=(StringType.FromObject(Me.rdr.Item("Spouse_Name")))
            Me.txtContactName.Text=(StringType.FromObject(Me.rdr.Item("Contact_Name")))
            If (Not BooleanType.FromObject(Me.rdr.Item("COD"))) Then
                Me.chkCOD.Checked=(False)
            Else
                Me.chkCOD.Checked=(True)
            End If
            If (Not BooleanType.FromObject(Me.rdr.Item("Active"))) Then
                Me.chkActive.Checked=(False)
            Else
                Me.chkActive.Checked=(True)
            End If
            Me.txtNotes.Text=(StringType.FromObject(Me.rdr.Item("Notes")))
            Dim str As String = StringType.FromObject(Me.rdr.Item("Primary_Phone"))
            If (Strings.Trim(str).Length() > 0) Then
                Me.txtPrimaryArea.Text = (str.Substring(0, 3))
                Me.txtPrimaryExch.Text = (str.Substring(3, 3))
                Me.txtPrimaryNumber.Text = (str.Substring(6, 4))
            End If
            str = StringType.FromObject(Me.rdr.Item("Alt_Phone"))
            If (Strings.Trim(str).Length() > 0) Then
                Me.txtAlternateArea.Text = (str.Substring(0, 3))
                Me.txtAlternateExch.Text = (str.Substring(3, 3))
                Me.txtAlternateNumber.Text = (str.Substring(6, 4))
            End If
            str = StringType.FromObject(Me.rdr.Item("Other1_Phone"))
            If (Strings.Trim(str).Length() > 0) Then
                Me.txtOther1Area.Text = (str.Substring(0, 3))
                Me.txtOther1Exch.Text = (str.Substring(3, 3))
                Me.txtOther1Number.Text = (str.Substring(6, 4))
            End If
            str = StringType.FromObject(Me.rdr.Item("Other2_Phone"))
            If (Strings.Trim(str).Length() > 0) Then
                Me.txtOther2Area.Text = (str.Substring(0, 3))
                Me.txtOther2Exch.Text = (str.Substring(3, 3))
                Me.txtOther2Number.Text = (str.Substring(6, 4))
            End If
            Me.txtEmail.Text=(StringType.FromObject(Me.rdr.Item("E_Mail")))
            Dim dateTime As System.DateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
            Me.txtCreateDate.Text=(dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtCreateUser.Text=(StringType.FromObject(Me.rdr.Item("Create_User")))
            dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
            Me.txtModifiedDate.Text=(dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"))
            Me.txtModifiedUser.Text=(StringType.FromObject(Me.rdr.Item("Modified_User")))
            Me.setDropDown(Me.lstClientType, Strings.Trim(StringType.FromObject(Me.rdr.Item("Client_Type"))))
            If (Not Me.setDropDown(Me.lstPrimaryPhoneType, Strings.Trim(StringType.FromObject(Me.rdr.Item("Prm_Phone_Type"))))) Then
                Me.lstPrimaryPhoneType.SelectedIndex=(0)
            End If
            If (Not Me.setDropDown(Me.lstAltPhoneType, Strings.Trim(StringType.FromObject(Me.rdr.Item("Alt_Phone_Type"))))) Then
                Me.lstAltPhoneType.SelectedIndex=(0)
            End If
            If (Not Me.setDropDown(Me.lstOther1PhoneType, Strings.Trim(StringType.FromObject(Me.rdr.Item("Other1_Phone_Type"))))) Then
                Me.lstOther1PhoneType.SelectedIndex=(0)
            End If
            If (Not Me.setDropDown(Me.lstOther2PhoneType, Strings.Trim(StringType.FromObject(Me.rdr.Item("Other2_Phone_Type"))))) Then
                Me.lstOther2PhoneType.SelectedIndex=(0)
            End If
            If (Not Me.setDropDown(Me.lstAccountType, Strings.Trim(StringType.FromObject(Me.rdr.Item("Acct_Type"))))) Then
                Me.lstAccountType.SelectedIndex=(0)
            End If
            If (Not Me.setDropDown(Me.lstDiscount, Strings.Trim(StringType.FromObject(Me.rdr.Item("Discount"))))) Then
                Me.lstDiscount.SelectedIndex=(0)
            End If
        End Sub

        <DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub loadListBoxes()
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Phone Type")
            Me.lstPrimaryPhoneType.DataSource=(Me.rdr)
            Me.lstPrimaryPhoneType.DataValueField=("Element_ID")
            Me.lstPrimaryPhoneType.DataTextField = ("Element_Description")
            Me.lstPrimaryPhoneType.DataBind()
            Me.lstPrimaryPhoneType.Items().Insert(0, New ListItem("", ""))
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Phone Type")
            Me.lstAltPhoneType.DataSource=(Me.rdr)
            Me.lstAltPhoneType.DataValueField=("Element_ID")
            Me.lstAltPhoneType.DataTextField = ("Element_Description")
            Me.lstAltPhoneType.DataBind()
            Me.lstAltPhoneType.Items().Insert(0, New ListItem("", ""))
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Phone Type")
            Me.lstOther1PhoneType.DataSource=(Me.rdr)
            Me.lstOther1PhoneType.DataValueField=("Element_ID")
            Me.lstOther1PhoneType.DataTextField = ("Element_Description")
            Me.lstOther1PhoneType.DataBind()
            Me.lstOther1PhoneType.Items().Insert(0, New ListItem("", ""))
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Phone Type")
            Me.lstOther2PhoneType.DataSource=(Me.rdr)
            Me.lstOther2PhoneType.DataValueField=("Element_ID")
            Me.lstOther2PhoneType.DataTextField = ("Element_Description")
            Me.lstOther2PhoneType.DataBind()
            Me.lstOther2PhoneType.Items().Insert(0, New ListItem("", ""))
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Client Type")
            Me.lstClientType.DataSource=(Me.rdr)
            Me.lstClientType.DataValueField=("Element_ID")
            Me.lstClientType.DataTextField = ("Element_Description")
            Me.lstClientType.DataBind()
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Account Type")
            Me.lstAccountType.DataSource=(Me.rdr)
            Me.lstAccountType.DataValueField=("Element_ID")
            Me.lstAccountType.DataTextField = ("Element_Description")
            Me.lstAccountType.DataBind()
            Me.lstAccountType.Items().Insert(0, New ListItem("", ""))
            Me.rdr = UCCCode.getActiveCodesByCodeDescription("Discount")
            Me.lstDiscount.DataSource=(Me.rdr)
            Me.lstDiscount.DataValueField=("Element_ID")
            Me.lstDiscount.DataTextField = ("Element_Description")
            Me.lstDiscount.DataBind()
            Me.lstDiscount.Items().Insert(0, New ListItem("", ""))
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
                Me.parentRequestor = StringType.FromObject(Me.ViewState().Item("parentRequestor"))
                If (Me.isChild) Then
                    Me.btnSelect.Visible = (True)
                End If
            Else
                Me.loadListBoxes()
                Me.setDefaultValues()
                Me.txtClientID.Text = ("")
                Dim item As String = Me.Parent().Page().Request().Item("From_Parent")
                Me.parentRequestor = item
                If (item IsNot Nothing) Then
                    Me.isChild = True
                    Me.btnSelect.Visible = (True)
                    Dim item1 As String = Me.Parent().Page().Request().Item("Client_ID")
                    If (item1.Length() > 0) Then
                        Me.getClient(item1)
                    End If
                    Me.ViewState().Item("isChild") = Me.isChild
                    Me.ViewState().Item("parentRequestor") = Me.parentRequestor
                End If
            End If
            Me.lblErrorMsg.Text = ("")
        End Sub

        Public Function searchClient(ByVal lastName As String, ByVal client_id As String, ByVal contactName As String, ByVal primaryPhone As String, ByVal altPhone As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateCriteria(lastName, client_id, contactName, primaryPhone, altPhone)
            If (messageHelper.status) Then
                Dim str As String = messageHelper.messageId
                If (StringType.StrCmp(str, "L", False) = 0) Then
                    Me.rdr = Me.uccClient.getClientByLastName(lastName)
                ElseIf (StringType.StrCmp(str, "P", False) = 0) Then
                    Me.rdr = Me.uccClient.getClientByPrimaryPhone(primaryPhone)
                ElseIf (StringType.StrCmp(str, "A", False) = 0) Then
                    Me.rdr = Me.uccClient.getClientByAltPhone(altPhone)
                ElseIf (StringType.StrCmp(str, "N", False) = 0) Then
                    Me.rdr = Me.uccClient.getClientByContactName(contactName)
                ElseIf (StringType.StrCmp(str, "C", False) = 0) Then
                    Me.rdr = Me.uccClient.getClientById(IntegerType.FromString(client_id))
                End If
                messageHelper.status = True
                messageHelper.messageObject = Me.rdr
            End If
            Return messageHelper
        End Function

        Private Sub setAddress(ByVal addressId As Integer)
            Dim addressById As SqlDataReader = (New UCCAddress()).getAddressById(addressId)
            addressById.Read()
            Me.txtAddr1.Text=(StringType.FromObject(addressById.Item("Address1")))
            Me.txtCity.Text=(StringType.FromObject(addressById.Item("City")))
            Me.txtState.Text=(StringType.FromObject(addressById.Item("State")))
            Me.txtZipCode.Text=(StringType.FromObject(addressById.Item("ZipCode")))
            addressById.Close()
        End Sub

        Private Sub setDefaultValues()
            Me.chkCOD.Checked=(False)
            Me.chkActive.Checked=(True)
            Me.txtClientID.Text=("")
            Me.txtAddr1.Text=("")
            Me.txtCity.Text=("")
            Me.txtState.Text=("")
            Me.txtZipCode.Text=("")
            Me.txtFirstName.Text=("")
            Me.txtLastName.Text=("")
            Me.txtSpouseName.Text=("")
            Me.txtContactName.Text=("")
            Me.txtPrimaryArea.Text=("")
            Me.txtPrimaryExch.Text=("")
            Me.txtPrimaryNumber.Text=("")
            Me.txtAlternateArea.Text=("")
            Me.txtAlternateExch.Text=("")
            Me.txtAlternateNumber.Text=("")
            Me.txtOther1Area.Text=("")
            Me.txtOther1Exch.Text=("")
            Me.txtOther1Number.Text=("")
            Me.txtOther2Area.Text=("")
            Me.txtOther2Exch.Text=("")
            Me.txtOther2Number.Text=("")
            Me.txtEmail.Text=("")
            Me.txtNotes.Text=("")
            Me.txtModifiedUser.Text=("")
            Me.txtModifiedDate.Text=("")
            Me.txtCreateUser.Text=("")
            Me.txtCreateDate.Text=("")
            Me.txtBillingAddressID.Text=("")
            Me.setDropDown(Me.lstAccountType, "H")
            Me.setDropDown(Me.lstPrimaryPhoneType, "R")
            Me.setDropDown(Me.lstAltPhoneType, "B")
            Me.setDropDown(Me.lstOther1PhoneType, "")
            Me.setDropDown(Me.lstOther2PhoneType, "")
            Me.setDropDown(Me.lstClientType, "I")
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

        Private Sub updateClient()
            Dim str As String = "<script language=""javascript"">"
            Dim messageHelper As SystemFramework.MessageHelper = Me.updateClientAll()
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text=(messageHelper.messageText)
            Else
                Me.getClient(Me.txtClientID.Text())
                If (Me.isChild) Then
                    If (Not (StringType.StrCmp(Me.parentRequestor, "1", False) = 0 Or StringType.StrCmp(Me.parentRequestor, "2", False) = 0)) Then
                        str = String.Concat(str, "window.close();")
                    Else
                        If (StringType.StrCmp(Me.parentRequestor, "1", False) = 0) Then
                            str = String.Concat(str, "window.opener.setOClient(")
                        ElseIf (StringType.StrCmp(Me.parentRequestor, "2", False) = 0) Then
                            str = String.Concat(str, "window.opener.setBClient(")
                        End If
                        str = String.Concat(str, Me.txtClientID.Text(), ", ")
                        str = String.Concat(String.Concat(str, """", Me.txtFirstName.Text()), """, ")
                        str = String.Concat(String.Concat(str, """", Me.txtLastName.Text()), """, ")
                        Dim text() As String = {str, """", Me.txtPrimaryArea.Text(), " ", Me.txtPrimaryExch.Text(), "-", Me.txtPrimaryNumber.Text()}
                        str = String.Concat(String.Concat(text), """, ")
                        str = String.Concat(String.Concat(str, """", Me.lstPrimaryPhoneType.SelectedItem().Value), """, ")
                        text = New String() {str, """", Me.txtAlternateArea.Text(), " ", Me.txtAlternateExch.Text(), "-", Me.txtAlternateNumber.Text()}
                        str = String.Concat(String.Concat(text), """, ")
                        str = String.Concat(String.Concat(str, """", Me.lstAltPhoneType.SelectedItem().Value), """, ")
                        text = New String() {str, """", Me.txtOther1Area.Text(), " ", Me.txtOther1Exch.Text(), "-", Me.txtOther1Number.Text()}
                        str = String.Concat(String.Concat(text), """, ")
                        str = String.Concat(String.Concat(str, """", Me.lstOther1PhoneType.SelectedItem().Value), """, ")
                        text = New String() {str, """", Me.txtOther2Area.Text(), " ", Me.txtOther2Exch.Text(), "-", Me.txtOther2Number.Text()}
                        str = String.Concat(String.Concat(text), """, ")
                        str = String.Concat(String.Concat(str, """", Me.lstOther2PhoneType.SelectedItem().Value), """, ")
                        str = String.Concat(str, """", Me.txtContactName.Text(), """")
                        str = String.Concat(str, ");window.close();")
                    End If
                    str = String.Concat(str, "</script>")
                    Me.Page().RegisterClientScriptBlock("", str)
                End If
            End If
        End Sub

        Private Function updateClientAll() As SystemFramework.MessageHelper
            Dim num As Integer = IIf(chkActive.Checked, 1, 0)
            Dim num1 As Integer = Func.CastToInt(txtBillingAddressID.Text, 0)
            Dim num2 As Integer = IIf(chkCOD.Checked, 1, 0)

            Dim str As String = String.Concat(Me.txtPrimaryArea.Text(), Me.txtPrimaryExch.Text(), Me.txtPrimaryNumber.Text())
            Dim str1 As String = String.Concat(Me.txtAlternateArea.Text(), Me.txtAlternateExch.Text(), Me.txtAlternateNumber.Text())
            Dim str2 As String = String.Concat(Me.txtOther1Area.Text(), Me.txtOther1Exch.Text(), Me.txtOther1Number.Text())
            Dim str3 As String = String.Concat(Me.txtOther2Area.Text(), Me.txtOther2Exch.Text(), Me.txtOther2Number.Text())
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccClient.updateClientAll(IntegerType.FromString(Me.txtClientID.Text()), num1, Strings.Trim(Me.txtFirstName.Text()), Strings.Trim(Me.txtLastName.Text()), Me.lstDiscount.SelectedItem().Value, Me.lstClientType.SelectedItem().Value, num2, Strings.Trim(Me.txtSpouseName.Text()), Strings.Trim(Me.txtContactName.Text()), str, Me.lstPrimaryPhoneType.SelectedItem().Value, str1, Me.lstAltPhoneType.SelectedItem().Value, Me.lstAccountType.SelectedItem().Value, Strings.Trim(Me.txtNotes.Text()), str2, Me.lstOther1PhoneType.SelectedItem().Value, str3, Me.lstOther2PhoneType.SelectedItem().Value, Strings.Trim(Me.txtEmail.Text()), num, MyBase.[Operator].userId, DateType.FromString(Me.txtModifiedDate.Text()))
            Return messageHelper
        End Function

        Private Sub UWGClient_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGClient.InitializeRow
            Dim dateTime As System.DateTime = New System.DateTime()
            dateTime = DateType.FromObject(Me.rdr.Item("Create_Date"))
            e.Row.Cells.FromKey("Create_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
            dateTime = DateType.FromObject(Me.rdr.Item("Modified_Date"))
            e.Row.Cells.FromKey("Modified_Date").Value = dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff")
        End Sub

        Private Function validateCriteria(ByVal lastName As String, ByVal client_id As String, ByVal contactName As String, ByVal primaryPhone As String, ByVal altPhone As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (lastName.Length() > 0) Then
                If (Not (client_id.Length() > 0 Or primaryPhone.Length() > 0 Or altPhone.Length() > 0 Or contactName.Length() > 0)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "L"
                Else
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.messageText = "Last/Com. Name is mutually exclusive with others"
                End If
            ElseIf (client_id.Length() > 0) Then
                If (lastName.Length() > 0 Or primaryPhone.Length() > 0 Or altPhone.Length() > 0 Or contactName.Length() > 0) Then
                    messageHelper.messageId = StringType.FromInteger(2)
                    messageHelper.messageText = "Client ID is mutually exclusive with others"
                ElseIf (Information.IsNumeric(client_id)) Then
                    messageHelper.status = True
                    messageHelper.messageId = "C"
                Else
                    messageHelper.messageId = StringType.FromInteger(12)
                    messageHelper.messageText = "Invalid Client ID"
                End If
            ElseIf (primaryPhone.Length() > 0) Then
                If (client_id.Length() > 0 Or lastName.Length() > 0 Or altPhone.Length() > 0 Or contactName.Length() > 0) Then
                    messageHelper.messageId = StringType.FromInteger(3)
                    messageHelper.messageText = "Primary Phone is mutually exclusive with others"
                ElseIf (primaryPhone.Length() = 10) Then
                    messageHelper.status = True
                    messageHelper.messageId = "P"
                Else
                    messageHelper.messageId = StringType.FromInteger(8)
                    messageHelper.messageText = "Primary Phone Invalid"
                End If
            ElseIf (altPhone.Length() <= 0) Then
                If (contactName.Length() > 0) Then
                    If (Not (client_id.Length() > 0 Or primaryPhone.Length() > 0 Or altPhone.Length() > 0 Or lastName.Length() > 0)) Then
                        messageHelper.status = True
                        messageHelper.messageId = "N"
                    Else
                        messageHelper.messageId = StringType.FromInteger(1)
                        messageHelper.messageText = "Contact Name is mutually exclusive with others"
                    End If
                End If
            ElseIf (client_id.Length() > 0 Or lastName.Length() > 0 Or primaryPhone.Length() > 0 Or contactName.Length() > 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Alternate Phone is mutually exclusive with others"
            ElseIf (altPhone.Length() = 10) Then
                messageHelper.status = True
                messageHelper.messageId = "A"
            Else
                messageHelper.messageId = StringType.FromInteger(8)
                messageHelper.messageText = "Alternate Phone Invalid"
            End If
            Return messageHelper
        End Function
    End Class
End Namespace