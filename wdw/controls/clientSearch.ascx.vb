Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework
Imports Strings = Microsoft.VisualBasic.Strings

Namespace wdw
    Public MustInherit Class clientSearch
        Inherits ControlBase

        '<AccessedThroughProperty("Label2")>
        'Private _Label2 As Label

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("txtAltArea")>
        'Private _txtAltArea As TextBox

        '<AccessedThroughProperty("txtArea")>
        'Private _txtArea As TextBox

        '<AccessedThroughProperty("Label4")>
        'Private _Label4 As Label

        '<AccessedThroughProperty("btnSearch")>
        'Private _btnSearch As Button

        '<AccessedThroughProperty("UWGClient")>
        'Private _UWGClient As UltraWebGrid

        '<AccessedThroughProperty("Label3")>
        'Private _Label3 As Label

        '<AccessedThroughProperty("lblLast")>
        'Private _lblLast As Label

        '<AccessedThroughProperty("lblClientSearchError")>
        'Private _lblClientSearchError As Label

        '<AccessedThroughProperty("txtAltPhoneNumber")>
        'Private _txtAltPhoneNumber As TextBox

        '<AccessedThroughProperty("Label5")>
        'Private _Label5 As Label

        '<AccessedThroughProperty("txtAltExchange")>
        'Private _txtAltExchange As TextBox

        '<AccessedThroughProperty("txtClientID")>
        'Private _txtClientID As TextBox

        '<AccessedThroughProperty("txtSiteAddr")>
        'Private _txtSiteAddr As TextBox

        '<AccessedThroughProperty("txtBillAddr")>
        'Private _txtBillAddr As TextBox

        '<AccessedThroughProperty("txtExchange")>
        'Private _txtExchange As TextBox

        '<AccessedThroughProperty("txtLastName")>
        'Private _txtLastName As TextBox

        '<AccessedThroughProperty("txtPhoneNumber")>
        'Private _txtPhoneNumber As TextBox

        Private isChild As Boolean

        Private beginARDate As DateTime

        'Protected Overridable Property btnSearch As Button
        '    Get
        '        Return Me._btnSearch
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnSearch IsNot Nothing) Then
        '            Dim _clientSearch As clientSearch = Me
        '            Me._btnSearch.remove_Click(New EventHandler(_clientSearch, _clientSearch.btnSearch_Click))
        '        End If
        '        Me._btnSearch = value
        '        If (Me._btnSearch IsNot Nothing) Then
        '            Dim _clientSearch1 As clientSearch = Me
        '            Me._btnSearch.add_Click(New EventHandler(_clientSearch1, _clientSearch1.btnSearch_Click))
        '        End If
        '    End Set
        'End Property

        Public WriteOnly Property errorText As String
            Set(ByVal value As String)
                Me.lblClientSearchError.Text = (value)
                If (StringType.StrCmp(value, "", False) = 0) Then
                    Me.lblClientSearchError.Visible = (False)
                Else
                    Me.lblClientSearchError.Visible = (True)
                End If
            End Set
        End Property

        Public ReadOnly Property getGridCellFocus As UltraGridCell
            Get
                Return Me.UWGClient.DisplayLayout.ActiveCell
            End Get
        End Property

        Public ReadOnly Property getGridRowFocus As UltraGridRow
            Get
                Return Me.UWGClient.DisplayLayout.ActiveRow
            End Get
        End Property

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

        'Public WriteOnly Property lastNameVisible As Boolean
        '    Set(ByVal value As Boolean)
        '        Me.txtLastName.Visible(value)
        '        Me.lblLast.Visible(value)
        '    End Set
        'End Property

        'Protected Overridable Property lblClientSearchError As Label
        '    Get
        '        Return Me._lblClientSearchError
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblClientSearchError Is Nothing
        '        Me._lblClientSearchError = value
        '        Me._lblClientSearchError Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lblLast As Label
        '    Get
        '        Return Me._lblLast
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblLast Is Nothing
        '        Me._lblLast = value
        '        Me._lblLast Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtAltArea As TextBox
        '    Get
        '        Return Me._txtAltArea
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtAltArea Is Nothing
        '        Me._txtAltArea = value
        '        Me._txtAltArea Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtAltExchange As TextBox
        '    Get
        '        Return Me._txtAltExchange
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtAltExchange Is Nothing
        '        Me._txtAltExchange = value
        '        Me._txtAltExchange Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtAltPhoneNumber As TextBox
        '    Get
        '        Return Me._txtAltPhoneNumber
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtAltPhoneNumber Is Nothing
        '        Me._txtAltPhoneNumber = value
        '        Me._txtAltPhoneNumber Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtArea As TextBox
        '    Get
        '        Return Me._txtArea
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtArea Is Nothing
        '        Me._txtArea = value
        '        Me._txtArea Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtBillAddr As TextBox
        '    Get
        '        Return Me._txtBillAddr
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBillAddr Is Nothing
        '        Me._txtBillAddr = value
        '        Me._txtBillAddr Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtClientID As TextBox
        '    Get
        '        Return Me._txtClientID
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtClientID Is Nothing
        '        Me._txtClientID = value
        '        Me._txtClientID Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtExchange As TextBox
        '    Get
        '        Return Me._txtExchange
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtExchange Is Nothing
        '        Me._txtExchange = value
        '        Me._txtExchange Is Nothing
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

        'Protected Overridable Property txtPhoneNumber As TextBox
        '    Get
        '        Return Me._txtPhoneNumber
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPhoneNumber Is Nothing
        '        Me._txtPhoneNumber = value
        '        Me._txtPhoneNumber Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtSiteAddr As TextBox
        '    Get
        '        Return Me._txtSiteAddr
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtSiteAddr Is Nothing
        '        Me._txtSiteAddr = value
        '        Me._txtSiteAddr Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property UWGClient As UltraWebGrid
        '    Get
        '        Return Me._UWGClient
        '    End Get
        '    '<MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UWGClient IsNot Nothing) Then
        '            Dim _clientSearch As clientSearch = Me
        '            RemoveHandler Me._UWGClient.InitializeRow, New InitializeRowEventHandler(AddressOf _clientSearch.UWGClient_InitializeRow)
        '            Dim _clientSearch1 As clientSearch = Me
        '            RemoveHandler Me._UWGClient.InitializeLayout, New InitializeLayoutEventHandler(AddressOf _clientSearch1.UWGClient_InitializeLayout)
        '        End If
        '        Me._UWGClient = value
        '        If (Me._UWGClient IsNot Nothing) Then
        '            Dim _clientSearch2 As clientSearch = Me
        '            AddHandler Me._UWGClient.InitializeRow, New InitializeRowEventHandler(AddressOf _clientSearch2.UWGClient_InitializeRow)
        '            Dim _clientSearch3 As clientSearch = Me
        '            AddHandler Me._UWGClient.InitializeLayout, New InitializeLayoutEventHandler(AddressOf _clientSearch3.UWGClient_InitializeLayout)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim _clientSearch As clientSearch = Me
            'MyBase.add_Init(New EventHandler(_clientSearch, _clientSearch.Page_Init))
            Dim _clientSearch1 As clientSearch = Me
            'MyBase.add_Load(New EventHandler(_clientSearch1, _clientSearch1.Page_Load))
            Me.isChild = False
            Dim dateTime As System.DateTime = New System.DateTime(2003, 12, 31, 0, 0, 1)
            Me.beginARDate = dateTime
        End Sub

        Private Sub bindGrid(ByVal siteSearchView As BusinessService.SiteSearchView)
            Me.UWGClient.DisplayLayout.ViewType = ViewType.Hierarchical
            Me.UWGClient.DataSource = (siteSearchView.clients)
            Me.UWGClient.DataBind()
            Me.UWGClient.DisplayLayout.TableLayout = TableLayout.Fixed
        End Sub

        'Private Sub btnNewClient_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewClient.Click
        '    Dim key As String = Me.getGridCellFocus.Column.Key
        'End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
            Dim uCCSearch As BusinessService.UCCSearch = New BusinessService.UCCSearch()
            Dim messageHelper As SystemFramework.MessageHelper = uCCSearch.searchClient(Strings.Trim(Me.txtSiteAddr.Text()), Strings.Trim(Me.txtBillAddr.Text()), Strings.Trim(Me.txtArea.Text()), Strings.Trim(Me.txtExchange.Text()), Strings.Trim(Me.txtPhoneNumber.Text()), Strings.Trim(Me.txtAltArea.Text()), Strings.Trim(Me.txtAltExchange.Text()), Strings.Trim(Me.txtAltPhoneNumber.Text()), Strings.Trim(Me.txtClientID.Text()), Strings.Trim(Me.txtLastName.Text()))
            If (Not messageHelper.status) Then
                Me.UWGClient.Rows.Clear()
                Me.lblClientSearchError.Visible = (True)
                Me.lblClientSearchError.Text = (messageHelper.messageText)
            Else
                Me.lblClientSearchError.Visible = (False)
                Me.lblClientSearchError.Text = ("")
                Me.bindGrid(DirectCast(messageHelper.messageObject, SiteSearchView))
            End If
        End Sub

        <DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim str As String = ""
            If (Not Me.Page().IsPostBack()) Then
                Dim item As String = Me.Parent().Page().Request().Item("From_Parent")
                str = item
                If (item IsNot Nothing) Then
                    Me.isChild = True
                    Dim item1 As String = Me.Parent().Page().Request().Item("Client_ID")
                    If (item1.Length() > 0) Then
                        Me.txtClientID.Text = (item1)
                        Me.btnSearch_Click(RuntimeHelpers.GetObjectValue(sender), e)
                    End If
                End If
            End If
            Me.lblClientSearchError.Visible = (False)
        End Sub

        Private Sub UWGClient_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UWGClient.InitializeLayout
            Dim layout As UltraGridLayout = e.Layout
            layout.Bands(0).Columns.FromKey("client_ID").HeaderText = "Client"
            layout.Bands(0).Columns.FromKey("last_Name").HeaderText = "Last Name"
            layout.Bands(0).Columns.FromKey("first_Name").HeaderText = "First Name"
            layout.Bands(0).Columns.FromKey("phone_Number").HeaderText = "Phone"
            layout.Bands(0).Columns.FromKey("last_Name").Move(0)
            layout.Bands(0).Columns.FromKey("first_Name").Move(1)
            layout.Bands(0).Columns.FromKey("phone_Number").Move(2)
            layout.Bands(0).Columns.FromKey("client_ID").Move(3)
            layout.Bands(0).Columns.FromKey("last_Name").Width = Unit.Percentage(30)
            layout.Bands(0).Columns.FromKey("first_Name").Width = Unit.Percentage(20)
            layout.Bands(0).Columns.FromKey("phone_Number").Width = Unit.Percentage(25)
            layout.Bands(0).Columns.FromKey("client_ID").Width = Unit.Percentage(20)
            layout.Bands(1).Columns.Insert(1, "CT")
            layout.Bands(1).Columns.FromKey("CT").HeaderText = "T"
            layout.Bands(1).Columns.FromKey("zip_Code").HeaderText = "Zip"
            layout.Bands(1).Columns.FromKey("address1").HeaderText = "Address"
            layout.Bands(1).Columns.FromKey("notes").HeaderText = "Notes"
            layout.Bands(1).Columns.FromKey("address1").Move(0)
            layout.Bands(1).Columns.FromKey("zip_Code").Move(1)
            layout.Bands(1).Columns.FromKey("notes").Move(2)
            layout.Bands(1).Columns.FromKey("CT").Move(3)
            layout.Bands(1).Columns.FromKey("address1").Width = Unit.Pixel(330)
            layout.Bands(1).Columns.FromKey("zip_Code").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("notes").Width = Unit.Pixel(100)
            layout.Bands(1).Columns.FromKey("CT").Width = Unit.Pixel(20)
            layout.Bands(1).Columns.FromKey("no_Stories").Hidden = True
            layout.Bands(1).Columns.FromKey("no_Stories").ServerOnly = True
            layout.Bands(1).Columns.FromKey("noteType").Hidden = True
            layout.Bands(1).Columns.FromKey("noteType").ServerOnly = True
            layout.Bands(1).Columns.FromKey("occ_ClientID").Hidden = True
            layout.Bands(1).Columns.FromKey("occ_ClientID").ServerOnly = True
            layout.Bands(1).Columns.FromKey("bill_ClientID").Hidden = True
            layout.Bands(1).Columns.FromKey("bill_ClientID").ServerOnly = True
            layout.Bands(1).Columns.FromKey("site_ID").Hidden = True
            If (Me.UWGClient.Bands.Count() = 3) Then
                layout.Bands(2).Columns.FromKey("start_Date").Move(0)
                layout.Bands(2).Columns.FromKey("job_Description").Move(1)
                layout.Bands(2).Columns.FromKey("bill_Amount_Integer").Move(2)
                layout.Bands(2).Columns.FromKey("status").Move(3)
                layout.Bands(2).Columns.FromKey("outsideOnly").Move(4)
                layout.Bands(2).Columns.FromKey("start_Date").HeaderText = "Job Date"
                layout.Bands(2).Columns.FromKey("job_Description").HeaderText = "Job Description"
                layout.Bands(2).Columns.FromKey("bill_Amount_Integer").HeaderText = " $ "
                layout.Bands(2).Columns.FromKey("outsideOnly").HeaderText = "E"
                layout.Bands(2).Columns.FromKey("status").HeaderText = "S"
                layout.Bands(2).Columns.FromKey("start_Date").Width = Unit.Pixel(65)
                layout.Bands(2).Columns.FromKey("job_Description").Width = Unit.Pixel(300)
                layout.Bands(2).Columns.FromKey("status").Width = Unit.Pixel(20)
                layout.Bands(2).Columns.FromKey("bill_Amount_Integer").Width = Unit.Pixel(30)
                layout.Bands(2).Columns.FromKey("outsideOnly").Width = Unit.Pixel(20)
                layout.Bands(2).Columns.FromKey("bill_Amount_Integer").CellStyle.HorizontalAlign = 3
                layout.Bands(2).Columns.FromKey("start_Date").Format = "MM/dd/yy"
                layout.Bands(2).Columns.FromKey("critical").Hidden = True
                layout.Bands(2).Columns.FromKey("critical").ServerOnly = True
                layout.Bands(2).Columns.FromKey("bill_Amount").Hidden = True
                layout.Bands(2).Columns.FromKey("bill_Amount").ServerOnly = True
                layout.Bands(2).Columns.FromKey("job_ID").Hidden = True
                layout.Bands(2).Columns.FromKey("site_ID").Hidden = True
                layout.Bands(2).Columns.FromKey("site_ID").ServerOnly = True
                layout.Bands(2).Columns.FromKey("bidHeader_ID").Hidden = True
                layout.Bands(2).Columns.FromKey("bidHeader_ID").ServerOnly = True
                layout.Bands(2).Columns.FromKey("notes").Hidden = True
                layout.Bands(2).Columns.FromKey("notes").ServerOnly = True
                layout.Bands(2).Columns.FromKey("arBalance").Hidden = True
                layout.Bands(2).Columns.FromKey("arBalance").ServerOnly = True
            End If
            layout = Nothing
        End Sub

        Private Sub UWGClient_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGClient.InitializeRow
            Dim objArray As Object()
            If (e.Row.Band.Index = 0) Then
                If (Not Me.isChild) Then
                    e.Row.Expand(False)
                Else
                    e.Row.Expand(True)
                End If
                If (Not BooleanType.FromObject(ObjectType.BitOrObj(Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("phone_Number").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("phone_Number").Value, "", False) = 0))) Then
                    StringType.FromObject(e.Row.Cells.FromKey("phone_Number").Value)

                    If (e.Row.Cells.FromKey("phone_Number").Text.Length() >= 4) Then
                        Dim ultraGridCell As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("phone_Number")
                        Dim value As Object = e.Row.Cells.FromKey("phone_Number").Value
                        Dim objArray1() As Object = {0, 3}
                        Dim obj As Object = ObjectType.AddObj(LateBinding.LateGet(value, Nothing, "SubString", objArray1, Nothing, Nothing), " ")
                        Dim value1 As Object = e.Row.Cells.FromKey("phone_Number").Value
                        Dim objArray2() As Object = {3, 3}
                        Dim obj1 As Object = ObjectType.AddObj(ObjectType.AddObj(obj, LateBinding.LateGet(value1, Nothing, "SubString", objArray2, Nothing, Nothing)), "-")
                        Dim value2 As Object = e.Row.Cells.FromKey("phone_Number").Value
                        objArray = New Object() {6, 4}
                        ultraGridCell.Value = ObjectType.AddObj(obj1, LateBinding.LateGet(value2, Nothing, "SubString", objArray, Nothing, Nothing))
                    End If
                End If
            ElseIf (e.Row.Band.Index <> 1) Then
                If (BooleanType.FromObject(ObjectType.BitAndObj(ObjectType.ObjTst(e.Row.Cells.FromKey("status").Value, "C", False) = 0, ObjectType.ObjTst(e.Row.Cells.FromKey("start_Date").Value, Me.beginARDate, False) > 0)) AndAlso ObjectType.ObjTst(e.Row.Cells.FromKey("arBalance").Value, 0, False) > 0) Then
                    e.Row.Cells.FromKey("bill_Amount_Integer").Style.BackColor = (Color.LightCoral())
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("job_ID").Value, 0, False) = 0) Then
                    e.Row.Delete()
                ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("outsideOnly").Value, "0", False) <> 0) Then
                    e.Row.Cells.FromKey("outsideOnly").Value = "Y"
                Else
                    e.Row.Cells.FromKey("outsideOnly").Value = "N"
                End If
            ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("site_ID").Value, 0, False) <> 0) Then
                Dim objectValue As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("zip_Code")
                Dim obj2 As Object = e.Row.Cells.FromKey("zip_Code").Value
                objArray = New Object() {2, 3}
                objectValue.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(obj2, Nothing, "SubString", objArray, Nothing, Nothing))
                If (IntegerType.FromObject(e.Row.Cells.FromKey("no_Stories").Value) > 2) Then
                    e.Row.Cells.FromKey("zip_Code").Style.BackColor = (Color.Magenta())
                End If
                If (IntegerType.FromObject(e.Row.Cells.FromKey("noteType").Value) = 1) Then
                    e.Row.Cells.FromKey("notes").Style.BackColor = (Color.LightCoral())
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("occ_ClientID").Value, 0, False) = 0) Then
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("bill_ClientID").Value, 0, False) <> 0) Then
                        e.Row.Cells.FromKey("CT").Value = "B"
                    Else
                        e.Row.Cells.FromKey("CT").Value = "N"
                    End If
                ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("bill_ClientID").Value, 0, False) <> 0) Then
                    e.Row.Cells.FromKey("CT").Value = "2"
                Else
                    e.Row.Cells.FromKey("CT").Value = "O"
                End If
            ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("zip_Code").Value, "", False) <> 0) Then
                Dim objectValue1 As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("zip_Code")
                Dim value3 As Object = e.Row.Cells.FromKey("zip_Code").Value
                objArray = New Object() {2, 3}
                objectValue1.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(value3, Nothing, "SubString", objArray, Nothing, Nothing))
            End If
        End Sub
    End Class
End Namespace