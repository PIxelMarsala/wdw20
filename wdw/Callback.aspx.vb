Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework
Imports Strings = Microsoft.VisualBasic.Strings

Namespace wdw
    Public Class Callback
        Inherits PageBase
        '<AccessedThroughProperty("txtLastName")>
        'Private _txtLastName As TextBox

        '<AccessedThroughProperty("txtToZip")>
        'Private _txtToZip As TextBox

        '<AccessedThroughProperty("UG1")>
        'Private _UG1 As UltraWebGrid

        '<AccessedThroughProperty("txtClient")>
        'Private _txtClient As TextBox

        '<AccessedThroughProperty("lblFromDate")>
        'Private _lblFromDate As Label

        '<AccessedThroughProperty("txtFromDate")>
        'Private _txtFromDate As TextBox

        '<AccessedThroughProperty("BtnPrinf")>
        'Private _BtnPrinf As Button

        '<AccessedThroughProperty("Label4")>
        'Private _Label4 As Label

        '<AccessedThroughProperty("Label6")>
        'Private _Label6 As Label

        '<AccessedThroughProperty("Label5")>
        'Private _Label5 As Label

        '<AccessedThroughProperty("txtFromZip")>
        'Private _txtFromZip As TextBox

        '<AccessedThroughProperty("txtToDate")>
        'Private _txtToDate As TextBox

        '<AccessedThroughProperty("lblErrorMsg")>
        'Private _lblErrorMsg As Label

        '<AccessedThroughProperty("lblToZip")>
        'Private _lblToZip As Label

        '<AccessedThroughProperty("Label3")>
        'Private _Label3 As Label

        '<AccessedThroughProperty("txtFromStart")>
        'Private _txtFromStart As TextBox

        '<AccessedThroughProperty("btnClear")>
        'Private _btnClear As Button

        '<AccessedThroughProperty("btnSave")>
        'Private _btnSave As Button

        '<AccessedThroughProperty("txtToStart")>
        'Private _txtToStart As TextBox

        '<AccessedThroughProperty("ddlCB")>
        'Private _ddlCB As DropDownList

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("txtSiteAddr")>
        'Private _txtSiteAddr As TextBox

        '<AccessedThroughProperty("Label2")>
        'Private _Label2 As Label

        '<AccessedThroughProperty("btnExpand")>
        'Private _btnExpand As Button

        '<AccessedThroughProperty("lblLast")>
        'Private _lblLast As Label

        '<AccessedThroughProperty("BtnLoad")>
        'Private _BtnLoad As Button

        '<AccessedThroughProperty("btnCollapse")>
        'Private _btnCollapse As Button

        '<AccessedThroughProperty("lblClient")>
        'Private _lblClient As Label

        Private iCtr As Integer

        Private rda As SqlDataAdapter

        Private rda2 As SqlDataAdapter

        Private Primary As String

        Private Secondary As String

        Private coDataSet1 As DataSet

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnClear As Button
        '    Get
        '        Return Me._btnClear
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnClear IsNot Nothing) Then
        '            Dim callback As wdw.Callback = Me
        '            Me._btnClear.remove_Click(New EventHandler(callback, callback.btnClear_Click))
        '        End If
        '        Me._btnClear = value
        '        If (Me._btnClear IsNot Nothing) Then
        '            Dim callback1 As wdw.Callback = Me
        '            Me._btnClear.add_Click(New EventHandler(callback1, callback1.btnClear_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnCollapse As Button
        '    Get
        '        Return Me._btnCollapse
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnCollapse IsNot Nothing) Then
        '            Dim callback As wdw.Callback = Me
        '            Me._btnCollapse.remove_Click(New EventHandler(callback, callback.btnCollapse_Click))
        '        End If
        '        Me._btnCollapse = value
        '        If (Me._btnCollapse IsNot Nothing) Then
        '            Dim callback1 As wdw.Callback = Me
        '            Me._btnCollapse.add_Click(New EventHandler(callback1, callback1.btnCollapse_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnExpand As Button
        '    Get
        '        Return Me._btnExpand
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnExpand IsNot Nothing) Then
        '            Dim callback As wdw.Callback = Me
        '            Me._btnExpand.remove_Click(New EventHandler(callback, callback.btnExpand_Click))
        '        End If
        '        Me._btnExpand = value
        '        If (Me._btnExpand IsNot Nothing) Then
        '            Dim callback1 As wdw.Callback = Me
        '            Me._btnExpand.add_Click(New EventHandler(callback1, callback1.btnExpand_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property BtnLoad As Button
        '    Get
        '        Return Me._BtnLoad
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._BtnLoad IsNot Nothing) Then
        '            Dim callback As wdw.Callback = Me
        '            Me._BtnLoad.remove_Click(New EventHandler(callback, callback.BtnLoad_Click))
        '        End If
        '        Me._BtnLoad = value
        '        If (Me._BtnLoad IsNot Nothing) Then
        '            Dim callback1 As wdw.Callback = Me
        '            Me._BtnLoad.add_Click(New EventHandler(callback1, callback1.BtnLoad_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property BtnPrinf As Button
        '    Get
        '        Return Me._BtnPrinf
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        Me._BtnPrinf Is Nothing
        '        Me._BtnPrinf = value
        '        Me._BtnPrinf Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property btnSave As Button
        '    Get
        '        Return Me._btnSave
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        Me._btnSave Is Nothing
        '        Me._btnSave = value
        '        Me._btnSave Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property ddlCB As DropDownList
        '    Get
        '        Return Me._ddlCB
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._ddlCB Is Nothing
        '        Me._ddlCB = value
        '        Me._ddlCB Is Nothing
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

        'Protected Overridable Property lblClient As Label
        '    Get
        '        Return Me._lblClient
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblClient Is Nothing
        '        Me._lblClient = value
        '        Me._lblClient Is Nothing
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

        'Protected Overridable Property lblFromDate As Label
        '    Get
        '        Return Me._lblFromDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblFromDate Is Nothing
        '        Me._lblFromDate = value
        '        Me._lblFromDate Is Nothing
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

        'Protected Overridable Property lblToZip As Label
        '    Get
        '        Return Me._lblToZip
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblToZip Is Nothing
        '        Me._lblToZip = value
        '        Me._lblToZip Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtClient As TextBox
        '    Get
        '        Return Me._txtClient
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtClient Is Nothing
        '        Me._txtClient = value
        '        Me._txtClient Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtFromDate As TextBox
        '    Get
        '        Return Me._txtFromDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtFromDate Is Nothing
        '        Me._txtFromDate = value
        '        Me._txtFromDate Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtFromStart As TextBox
        '    Get
        '        Return Me._txtFromStart
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtFromStart Is Nothing
        '        Me._txtFromStart = value
        '        Me._txtFromStart Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtFromZip As TextBox
        '    Get
        '        Return Me._txtFromZip
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtFromZip Is Nothing
        '        Me._txtFromZip = value
        '        Me._txtFromZip Is Nothing
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

        'Protected Overridable Property txtToDate As TextBox
        '    Get
        '        Return Me._txtToDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtToDate Is Nothing
        '        Me._txtToDate = value
        '        Me._txtToDate Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtToStart As TextBox
        '    Get
        '        Return Me._txtToStart
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtToStart Is Nothing
        '        Me._txtToStart = value
        '        Me._txtToStart Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtToZip As TextBox
        '    Get
        '        Return Me._txtToZip
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtToZip Is Nothing
        '        Me._txtToZip = value
        '        Me._txtToZip Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property UG1 As UltraWebGrid
        '    Get
        '        Return Me._UG1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UG1 IsNot Nothing) Then
        '            Dim callback As wdw.Callback = Me
        '            RemoveHandler Me._UG1.InitializeRow, New InitializeRowEventHandler(AddressOf callback.UG1_InitializeRow)
        '            Dim callback1 As wdw.Callback = Me
        '            RemoveHandler Me._UG1.UpdateGrid, New UpdateGridEventHandler(AddressOf callback1.UG1_UpdateGrid)
        '            Dim callback2 As wdw.Callback = Me
        '            RemoveHandler Me._UG1.InitializeLayout, New InitializeLayoutEventHandler(AddressOf callback2.UG1_InitializeLayout)
        '        End If
        '        Me._UG1 = value
        '        If (Me._UG1 IsNot Nothing) Then
        '            Dim callback3 As wdw.Callback = Me
        '            AddHandler Me._UG1.InitializeRow, New InitializeRowEventHandler(AddressOf callback3.UG1_InitializeRow)
        '            Dim callback4 As wdw.Callback = Me
        '            AddHandler Me._UG1.UpdateGrid, New UpdateGridEventHandler(AddressOf callback4.UG1_UpdateGrid)
        '            Dim callback5 As wdw.Callback = Me
        '            AddHandler Me._UG1.InitializeLayout, New InitializeLayoutEventHandler(AddressOf callback5.UG1_InitializeLayout)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim callback1 As Callback = Me
            'MyBase.add_Init(New EventHandler(callback1, callback1.Page_Init))
            Dim callback2 As Callback = Me
            'MyBase.add_Load(New EventHandler(callback2, callback2.Page_Load))
            Me.rda = New SqlDataAdapter()
            Me.rda2 = New SqlDataAdapter()
            Me.Primary = "Primary"
            Me.Secondary = "Secondary"
            Me.coDataSet1 = New DataSet("Callback")
            Me.FUNCTIONNAME = "Callback"
        End Sub

        Private Sub AssignDataSource()
            Dim num As Integer = 0
            If (Strings.Len(Me.txtFromDate.Text()) > 0 And Strings.Len(Me.txtToDate.Text()) > 0 And Strings.Len(Me.txtFromZip.Text()) = 0 And Strings.Len(Me.txtToZip.Text()) = 0) Then
                Me.rda = UCCCallback.getAllParentCallbackbyDate(Me.ddlCB.SelectedValue(), DateType.FromString(Me.txtFromDate.Text()), DateType.FromString(Me.txtToDate.Text()), 0, 0)
                Me.rda2 = UCCCallback.getAllChildCallbackbyDate(Me.ddlCB.SelectedValue(), DateType.FromString(Me.txtFromDate.Text()), DateType.FromString(Me.txtToDate.Text()), 0, 0)
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (num < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Site_ID"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Site_ID"))
                End If
            ElseIf (Strings.Len(Me.txtFromDate.Text()) > 0 And Strings.Len(Me.txtToDate.Text()) > 0 And Strings.Len(Me.txtFromZip.Text()) > 0 And Strings.Len(Me.txtToZip.Text()) > 0) Then
                Me.rda = UCCCallback.getAllParentCallbackbyDate(Me.ddlCB.SelectedValue(), DateType.FromString(Me.txtFromDate.Text()), DateType.FromString(Me.txtToDate.Text()), IntegerType.FromString(Me.txtFromZip.Text()), IntegerType.FromString(Me.txtToZip.Text()))
                Me.rda2 = UCCCallback.getAllChildCallbackbyDate(Me.ddlCB.SelectedValue(), DateType.FromString(Me.txtFromDate.Text()), DateType.FromString(Me.txtToDate.Text()), IntegerType.FromString(Me.txtFromZip.Text()), IntegerType.FromString(Me.txtToZip.Text()))
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (num < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Site_ID"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Site_ID"))
                End If
            ElseIf (Strings.Len(Me.txtFromDate.Text()) = 0 And Strings.Len(Me.txtToDate.Text()) = 0 And Strings.Len(Me.txtFromZip.Text()) > 0 And Strings.Len(Me.txtToZip.Text()) > 0) Then
                Me.rda = UCCCallback.getAllParentCallbackbyDate(Me.ddlCB.SelectedValue(), DateType.FromString("01/01/1900"), DateType.FromString("01/01/1900"), IntegerType.FromString(Me.txtFromZip.Text()), IntegerType.FromString(Me.txtToZip.Text()))
                Me.rda2 = UCCCallback.getAllChildCallbackbyDate(Me.ddlCB.SelectedValue(), DateType.FromString("01/01/1900"), DateType.FromString("01/01/1900"), IntegerType.FromString(Me.txtFromZip.Text()), IntegerType.FromString(Me.txtToZip.Text()))
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (num < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Site_ID"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Site_ID"))
                End If
            ElseIf (Strings.Len(Me.txtClient.Text()) > 0) Then
                Me.rda = UCCCallback.getAllParentCallbackbyClient(IntegerType.FromString(Me.txtClient.Text()))
                Me.rda2 = UCCCallback.getAllChildCallbackbyClient(IntegerType.FromString(Me.txtClient.Text()))
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (num < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Site_ID"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Site_ID"))
                End If
            ElseIf (Strings.Len(Me.txtLastName.Text()) > 0) Then
                Dim str As String = Me.txtLastName.Text().Replace("..", "%")
                Me.rda = UCCCallback.getAllParentCallbackbyLName(str)
                Me.rda2 = UCCCallback.getAllChildCallbackbyLName(str)
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (num < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Site_ID"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Site_ID"))
                End If
            ElseIf (Strings.Len(Me.txtSiteAddr.Text()) > 0) Then
                Dim str1 As String = Me.txtSiteAddr.Text().Replace("..", "%")
                Me.rda = UCCCallback.getAllParentCallbackbyAddress(str1)
                Me.rda2 = UCCCallback.getAllChildCallbackbyAddress(str1)
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (num < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Site_ID"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Site_ID"))
                End If
            ElseIf (Not (Strings.Len(Me.txtFromStart.Text()) > 0 And Strings.Len(Me.txtToStart.Text()) > 0)) Then
                Me.lblErrorMsg.Text = ("Please Enter a Search Criteria.")
            Else
                Me.rda = UCCCallback.getAllParentCallbackbyStartDate(Me.ddlCB.SelectedValue(), DateType.FromString(Me.txtFromStart.Text()), DateType.FromString(Me.txtToStart.Text()))
                Me.rda2 = UCCCallback.getAllChildCallbackbyStartDate(Me.ddlCB.SelectedValue(), DateType.FromString(Me.txtFromStart.Text()), DateType.FromString(Me.txtToStart.Text()))
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (num < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Site_ID"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Site_ID"))
                End If
            End If
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
            Me.txtClient.Text = ("")
            Me.txtFromDate.Text = ("")
            Me.txtToDate.Text = ("")
            Me.txtFromZip.Text = ("")
            Me.txtToZip.Text = ("")
            Me.txtSiteAddr.Text = ("")
            Me.txtLastName.Text = ("")
            Me.txtFromStart.Text = ("")
            Me.txtToStart.Text = ("")
            Me.UG1.DataSource = (Nothing)
            Me.UG1.DataBind()
        End Sub

        Private Sub btnCollapse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCollapse.Click
            Me.UG1.ExpandAll(False)
            Me.btnCollapse.Enabled = (False)
            Me.btnExpand.Enabled = (True)
        End Sub

        Private Sub btnExpand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExpand.Click
            Me.UG1.ExpandAll(True)
            Me.btnExpand.Enabled = (False)
            Me.btnCollapse.Enabled = (True)
        End Sub

        Private Sub BtnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnLoad.Click
            Me.lblErrorMsg.Text = ("")
            Me.AssignDataSource()
            If (Strings.Len(Me.lblErrorMsg.Text()) = 0) Then
                Me.UG1.Bands(0).AllowAdd = AllowAddNew.No
                Me.UG1.DataSource = (Me.coDataSet1.Tables().Item("Primary").DefaultView())
                Me.UG1.DataBind()
                Me.UG1.DisplayLayout.ActiveRow = Me.UG1.Rows(0)
                Me.UG1.Visible = (True)
            End If
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("CBState")
        End Function

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
            If (Not Me.IsPostBack()) Then
                Dim activeCodesByCodeDescription As SqlDataReader = UCCCode.getActiveCodesByCodeDescription("CallBack Method")
                Me.ddlCB.DataSource = (activeCodesByCodeDescription)
                Me.ddlCB.DataTextField = ("Element_ID")
                Me.ddlCB.DataValueField = ("Element_ID")
                Me.ddlCB.DataBind()
                Me.setDropDown(Me.ddlCB, "NC120")  ' Changed from NC90 [vin]
            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("CBState", RuntimeHelpers.GetObjectValue(viewState))
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

        Private Sub UG1_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UG1.InitializeLayout
            Dim headerStyle As Infragistics.WebUI.UltraWebGrid.GridItemStyle = Me.UG1.Bands(0).HeaderStyle
            Dim unit As System.Web.UI.WebControls.Unit = New System.Web.UI.WebControls.Unit("35px")
            DirectCast(headerStyle, Style).Height = (unit)
            Dim gridItemStyle As Infragistics.WebUI.UltraWebGrid.GridItemStyle = Me.UG1.Bands(1).HeaderStyle
            unit = New System.Web.UI.WebControls.Unit("35px")
            DirectCast(gridItemStyle, Style).Height = (unit)
            Me.UG1.Bands(0).Columns.FromKey("First Name").HeaderText = "First<br>Name"
            Me.UG1.Bands(0).Columns.FromKey("Last Name").HeaderText = "Last<br>Name"
            Me.UG1.Bands(0).Columns.FromKey("Primary Phone").HeaderText = "Primary<br>Phone"
            Me.UG1.Bands(0).Columns.FromKey("CallBack Method").HeaderText = "CallBack<br>Method"
            Me.UG1.Bands(0).Columns.FromKey("Client_ID").HeaderText = "Client#"
            Me.UG1.Bands(0).Columns.FromKey("O/O").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("BillAmt").CellStyle.HorizontalAlign = 3
            Me.UG1.Bands(0).Columns.FromKey("StartDate").CellStyle.HorizontalAlign = 3
            Me.UG1.Bands(0).Columns.FromKey("StartDate").HeaderText = "Start<br>Date"
            Me.UG1.Bands(0).Columns.FromKey("Site_ID").HeaderText = "Site#"
            Me.UG1.Bands(0).Columns.FromKey("BillAmt").HeaderText = "Bill<br>Amt"
            Me.UG1.Bands(0).Columns.FromKey("OnCallDate").HeaderText = "OnCall<br>Date"
            Me.UG1.Bands(1).Columns.FromKey("CallBack Date").HeaderText = "CallBack<br>Date"
            Me.UG1.Bands(1).Columns.FromKey("NextCallBack").HeaderText = "Next<br>CallBack"
            Me.UG1.Bands(1).Columns.FromKey("ResultCode").HeaderText = "Result<br>Code"
            Dim ultraGridColumn As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("StartDate")
            unit = New System.Web.UI.WebControls.Unit("60px")
            ultraGridColumn.Width = unit
            Dim ultraGridColumn1 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("First Name")
            unit = New System.Web.UI.WebControls.Unit("75px")
            ultraGridColumn1.Width = unit
            Dim ultraGridColumn2 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Last Name")
            unit = New System.Web.UI.WebControls.Unit("95px")
            ultraGridColumn2.Width = unit
            Dim ultraGridColumn3 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Primary Phone")
            unit = New System.Web.UI.WebControls.Unit("100px")
            ultraGridColumn3.Width = unit
            Dim ultraGridColumn4 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("CallBack Method")
            unit = New System.Web.UI.WebControls.Unit("75px")
            ultraGridColumn4.Width = unit
            Dim ultraGridColumn5 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Client_ID")
            unit = New System.Web.UI.WebControls.Unit("85px")
            ultraGridColumn5.Width = unit
            Dim ultraGridColumn6 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Site_ID")
            unit = New System.Web.UI.WebControls.Unit("57px")
            ultraGridColumn6.Width = unit
            Dim ultraGridColumn7 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Zip")
            unit = New System.Web.UI.WebControls.Unit("40px")
            ultraGridColumn7.Width = unit
            Dim ultraGridColumn8 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Address1")
            unit = New System.Web.UI.WebControls.Unit("125px")
            ultraGridColumn8.Width = unit
            Dim ultraGridColumn9 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("BillAmt")
            unit = New System.Web.UI.WebControls.Unit("60px")
            ultraGridColumn9.Width = unit
            Dim ultraGridColumn10 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Job")
            unit = New System.Web.UI.WebControls.Unit("55px")
            ultraGridColumn10.Width = unit
            Dim ultraGridColumn11 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("NextCallBack")
            unit = New System.Web.UI.WebControls.Unit("130px")
            ultraGridColumn11.Width = unit
            Dim ultraGridColumn12 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Notes")
            unit = New System.Web.UI.WebControls.Unit("605px")
            ultraGridColumn12.Width = unit
            Dim ultraGridColumn13 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("CallBack Date")
            unit = New System.Web.UI.WebControls.Unit("90px")
            ultraGridColumn13.Width = unit
            Dim ultraGridColumn14 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("ResultCode")
            unit = New System.Web.UI.WebControls.Unit("80px")
            ultraGridColumn14.Width = unit
            Me.UG1.Bands(0).Columns.FromKey("Primary Phone").Format = "@@@ @@@-@@@@"
            Me.UG1.Bands(0).Columns.FromKey("CallBack Method").Type = ColumnType.DropDownList
            Me.UG1.Bands(1).Columns.FromKey("CallBack Date").Format = "MM/dd/yyyy"
            Me.UG1.Bands(1).Columns.FromKey("ResultCode").Type = ColumnType.DropDownList
            Me.UG1.Bands(0).Columns.FromKey("OnCallDate").Format = "MM/dd/yyyy"
            Dim valueList As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(0).Columns.FromKey("CallBack Method").ValueList
            Dim activeCodesByCodeDescription As SqlDataReader = UCCCode.getActiveCodesByCodeDescription("CallBack Method")
            Me.iCtr = 0
            While activeCodesByCodeDescription.Read()
                valueList.ValueListItems.Add(New ValueListItem())
                valueList.ValueListItems(Me.iCtr).DisplayText = StringType.FromObject(activeCodesByCodeDescription.Item("Element_ID"))
                Me.iCtr = Me.iCtr + 1
            End While
            valueList.ValueListItems.Insert(0, DBNull.Value, " ")
            Dim valueList1 As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(1).Columns.FromKey("ResultCode").ValueList
            activeCodesByCodeDescription = UCCCode.getActiveCodesByCodeDescription("ResultCode")
            Me.iCtr = 0
            While activeCodesByCodeDescription.Read()
                valueList1.ValueListItems.Add(New ValueListItem())
                valueList1.ValueListItems(Me.iCtr).DisplayText = StringType.FromObject(activeCodesByCodeDescription.Item("Element_ID"))
                Me.iCtr = Me.iCtr + 1
            End While
            valueList1.ValueListItems.Insert(0, DBNull.Value, " ")
            Me.UG1.Bands(1).Columns.FromKey("CallBack Date").CellStyle.BackColor = (Color.DarkGray())
            Me.UG1.Bands(0).Columns.FromKey("First Name").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("Last Name").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("Primary Phone").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("Zip").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("First Name").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Last Name").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Primary Phone").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Zip").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Address1").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("BillAmt").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Job").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Client_ID").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("OnCallDate").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("OnCallDate").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("OnCallDate").Format = "MM/dd/yyyy"
            Me.UG1.Bands(1).Columns.FromKey("CallBack Date").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(1).Columns.FromKey("Site_ID").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("callback_id").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("BillAmt").Format = "#.00"
        End Sub

        Private Sub UG1_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UG1.InitializeRow
            If (e.Row.Band.Index = 0 AndAlso Not BooleanType.FromObject(ObjectType.BitOrObj(Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("Primary Phone").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("Primary Phone").Value, "", False) = 0))) Then
                StringType.FromObject(e.Row.Cells.FromKey("Primary Phone").Value)
                Dim length As Integer = e.Row.Cells.FromKey("Primary Phone").Text.Length()
                If (length >= 4) Then
                    Dim ultraGridCell As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("Primary Phone")
                    Dim value As Object = e.Row.Cells.FromKey("Primary Phone").Value
                    Dim objArray() As Object = {0, 3}
                    Dim obj As Object = ObjectType.AddObj(LateBinding.LateGet(value, Nothing, "SubString", objArray, Nothing, Nothing), " ")
                    Dim value1 As Object = e.Row.Cells.FromKey("Primary Phone").Value
                    Dim objArray1() As Object = {3, 3}
                    Dim obj1 As Object = ObjectType.AddObj(ObjectType.AddObj(obj, LateBinding.LateGet(value1, Nothing, "SubString", objArray1, Nothing, Nothing)), "-")
                    Dim value2 As Object = e.Row.Cells.FromKey("Primary Phone").Value
                    Dim objArray2() As Object = {6, 4}
                    ultraGridCell.Value = ObjectType.AddObj(obj1, LateBinding.LateGet(value2, Nothing, "SubString", objArray2, Nothing, Nothing))
                End If
            End If
        End Sub

        Private Sub UG1_PageIndexChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.PageEventArgs) Handles UG1.PageIndexChanged
            Me.UG1.DataBind()
        End Sub

        Private Sub UG1_UpdateGrid(ByVal sender As Object, ByVal e As UpdateEventArgs) Handles UG1.UpdateGrid
            Dim dateTime As System.DateTime
            Dim num As Integer
            Dim num1 As Integer = 0
            Dim num2 As Integer
            Dim messageHelper As SystemFramework.MessageHelper
            Dim str As String
            Dim str1 As String
            Dim str2 As String
            Me.iCtr = 1
            Me.AssignDataSource()
            Me.lblErrorMsg.Text = ("")
            Dim [operator] As String = MyBase.[Operator].userId
            Dim operator1 As String = MyBase.[Operator].userId
            Dim batchUpdates As Infragistics.WebUI.UltraWebGrid.UltraGridRowsEnumerator = Nothing
            Dim ultraGridRowsEnumerator As Infragistics.WebUI.UltraWebGrid.UltraGridRowsEnumerator = Nothing
            Dim Table1 As DataTable = Me.coDataSet1.Tables().Item("Primary")
            batchUpdates = Me.UG1.Bands(0).GetBatchUpdates()
            Dim Table2 As DataTable = Me.coDataSet1.Tables().Item("Secondary")
            ultraGridRowsEnumerator = Me.UG1.Bands(1).GetBatchUpdates()
            While batchUpdates.MoveNext()
                Dim current As Infragistics.WebUI.UltraWebGrid.UltraGridRow = batchUpdates.Current
                If (current.DataChanged <> DataChanged.Modified OrElse current.IsChild(current)) Then
                    Continue While
                End If
                Dim objectValue As Object = RuntimeHelpers.GetObjectValue(current.Cells.FromKey("CallBack Method").Value)
                num = IntegerType.FromObject(current.Cells.FromKey("Site_ID").Value)
                messageHelper = UCCCallback.modifyCBMethod(num, StringType.FromObject(objectValue), operator1)
                If (messageHelper.status) Then
                    Continue While
                End If
                Me.lblErrorMsg.Text = (messageHelper.messageText)
            End While
            While ultraGridRowsEnumerator.MoveNext()
                Dim ultraGridRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = ultraGridRowsEnumerator.Current
                If (Not BooleanType.FromObject(ObjectType.BitOrObj(ultraGridRow.DataChanged = DataChanged.Modified, ObjectType.ObjTst(ultraGridRow.DataKey, Nothing, False) <> 0))) Then
                    If (ultraGridRow.DataChanged <> DataChanged.Added OrElse Strings.Len(RuntimeHelpers.GetObjectValue(ultraGridRow.Cells.FromKey("ResultCode").Value)) <= 0 OrElse ObjectType.ObjTst(ultraGridRow.DataKey, Nothing, False) <> 0) Then
                        Continue While
                    End If
                    num = 0
                    str1 = StringType.FromObject(ultraGridRow.Cells.FromKey("Notes").Value)
                    str2 = StringType.FromObject(ultraGridRow.Cells.FromKey("ResultCode").Value)
                    dateTime = DateType.FromObject(ultraGridRow.Cells.FromKey("NextCallBack").Value)
                    If (Strings.Len(RuntimeHelpers.GetObjectValue(ultraGridRow.Cells.FromKey("NextCallBack").Value)) = 0) Then
                        str = StringType.FromObject(ultraGridRow.ParentRow.Cells.FromKey("CallBack Method").Value)
                        Dim now As System.DateTime = System.DateTime.Now()
                        dateTime = DateType.FromString(Microsoft.VisualBasic.Strings.Format(now.AddDays(CDbl(IntegerType.FromString(str.Substring(2)))), "MM/dd/yyyy"))
                        ultraGridRow.Cells.FromKey("NextCallBack").Value = Strings.Format(dateTime, "MM/dd/yyyy")
                    End If
                    num2 = IntegerType.FromObject(ultraGridRow.ParentRow.Cells.FromKey("Site_ID").Value)
                    If (Strings.Len(str2) <= 0) Then
                        Me.lblErrorMsg.Text = ("Please select a result code.")
                    Else
                        num1 = UCCCallback.createCallBack(num1, str1, str2, dateTime, num2, [operator], operator1)
                        Dim dateTime1 As System.DateTime = DateType.FromString(Microsoft.VisualBasic.Strings.Format(System.DateTime.Now(), "MM/dd/yyyy"))
                        ultraGridRow.Cells.FromKey("CallBack Date").AllowEditing = AllowEditing.Yes
                        ultraGridRow.Cells.FromKey("CallBack Date").Value = dateTime1
                        ultraGridRow.Cells.FromKey("CallBack Date").AllowEditing = AllowEditing.No
                        ultraGridRow.DataKey = num1
                    End If
                Else
                    If (Not ultraGridRow.HasParent) Then
                        Continue While
                    End If
                    str1 = StringType.FromObject(ultraGridRow.Cells.FromKey("Notes").Value)
                    str2 = StringType.FromObject(ultraGridRow.Cells.FromKey("ResultCode").Value)
                    dateTime = DateType.FromObject(ultraGridRow.Cells.FromKey("NextCallBack").Value)
                    If (Strings.Len(RuntimeHelpers.GetObjectValue(ultraGridRow.Cells.FromKey("NextCallBack").Value)) = 0) Then
                        str = StringType.FromObject(ultraGridRow.ParentRow.Cells.FromKey("CallBack Method").Value)
                        Dim now1 As System.DateTime = System.DateTime.Now()
                        dateTime = DateType.FromString(Microsoft.VisualBasic.Strings.Format(now1.AddDays(CDbl(IntegerType.FromString(str.Substring(2)))), "MM/dd/yyyy"))
                        ultraGridRow.Cells.FromKey("NextCallBack").Value = Strings.Format(dateTime, "MM/dd/yyyy")
                    End If
                    num2 = IntegerType.FromObject(ultraGridRow.ParentRow.Cells.FromKey("Site_ID").Value)
                    num = IntegerType.FromObject(ultraGridRow.Cells.FromKey("callback_id").Value)
                    messageHelper = UCCCallback.modifyCallBack(num, str1, str2, dateTime, operator1)
                    If (Not messageHelper.status) Then
                        Me.lblErrorMsg.Text = (messageHelper.messageText)
                    End If
                End If
            End While
        End Sub
    End Class
End Namespace