Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Microsoft.VisualBasic.CompilerServices
Imports System
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

Namespace wdw
    Public Class Pricing
        Inherits PageBase
        '<AccessedThroughProperty("btnSubmit")>
        'Private _btnSubmit As Button

        '<AccessedThroughProperty("UG1")>
        'Private _UG1 As UltraWebGrid

        Private pricingDataSet1 As DataSet

        Private rda As SqlDataAdapter

        Private rda2 As SqlDataAdapter

        Private ctr As Integer

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnSubmit As Button
        '    Get
        '        Return Me._btnSubmit
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        Me._btnSubmit Is Nothing
        '        Me._btnSubmit = value
        '        Me._btnSubmit Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property UG1 As UltraWebGrid
        '    Get
        '        Return Me._UG1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UG1 IsNot Nothing) Then
        '            Dim pricing As wdw.Pricing = Me
        '            RemoveHandler Me._UG1.InitializeLayout, New InitializeLayoutEventHandler(AddressOf pricing.UG1_InitializeLayout)
        '            Dim pricing1 As wdw.Pricing = Me
        '            RemoveHandler Me._UG1.UpdateCellBatch, New UpdateCellBatchEventHandler(AddressOf pricing1.UG1_UpdateCellBatch)
        '        End If
        '        Me._UG1 = value
        '        If (Me._UG1 IsNot Nothing) Then
        '            Dim pricing2 As wdw.Pricing = Me
        '            AddHandler Me._UG1.InitializeLayout, New InitializeLayoutEventHandler(AddressOf pricing2.UG1_InitializeLayout)
        '            Dim pricing3 As wdw.Pricing = Me
        '            AddHandler Me._UG1.UpdateCellBatch, New UpdateCellBatchEventHandler(AddressOf pricing3.UG1_UpdateCellBatch)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim pricing1 As Pricing = Me
            'MyBase.add_Init(New EventHandler(pricing1, pricing1.Page_Init))
            Dim pricing2 As Pricing = Me
            'MyBase.add_Load(New EventHandler(pricing2, pricing2.Page_Load))
            Me.pricingDataSet1 = New DataSet("Pricing")
            Me.rda = New SqlDataAdapter()
            Me.rda2 = New SqlDataAdapter()
            Me.ctr = 0
            Me.FUNCTIONNAME = "Pricing"
        End Sub

        Private Sub AssignDataSource()
            Me.rda = UCCPricing.getAllParentPricing()
            Me.rda2 = UCCPricing.getAllChildPricing()
            Me.rda.Fill(Me.pricingDataSet1, "Primary")
            Me.rda2.Fill(Me.pricingDataSet1, "Secondary")
            If (Me.ctr < 1) Then
                Me.pricingDataSet1.Relations().Add("Primary", Me.pricingDataSet1.Tables().Item("Primary").Columns().Item("ServOff_ID"), Me.pricingDataSet1.Tables().Item("Secondary").Columns().Item("ParentServOff_ID"))
            End If
            Me.UG1.DataSource = (Me.pricingDataSet1.Tables().Item("Primary").DefaultView())
            Me.UG1.DataBind()
        End Sub

        ''<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("PriceState")
        End Function

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
            If (Not Me.IsPostBack()) Then
                Me.AssignDataSource()
                Me.UG1.DisplayLayout.ActiveRow = Me.UG1.Rows(0)
            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("PriceState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub

        Private Sub UG1_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UG1.InitializeLayout
            Me.UG1.Bands(1).Columns.FromKey("servoff_id").HeaderText = "ID"
            Me.UG1.Bands(0).Columns.FromKey("servoff_id").HeaderText = "ID"
            Me.UG1.Bands(0).DataKeyField = Me.pricingDataSet1.Tables().Item("Primary").Columns().Item(0).ColumnName()
            Me.UG1.Bands(1).DataKeyField = Me.pricingDataSet1.Tables().Item("Secondary").Columns().Item(0).ColumnName()
            Me.UG1.Bands(0).Columns.FromKey("servOff_Name").HeaderText = "Name"
            Dim ultraGridColumn As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("servOff_Name")
            Dim unit As System.Web.UI.WebControls.Unit = New System.Web.UI.WebControls.Unit("200px")
            ultraGridColumn.Width = unit
            Dim ultraGridColumn1 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("ServOff_Name")
            unit = New System.Web.UI.WebControls.Unit("156px")
            ultraGridColumn1.Width = unit
            Me.UG1.Bands(1).Columns.FromKey("ServOff_Name").HeaderText = "Name"
            Dim ultraGridColumn2 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("servoff_id")
            unit = New System.Web.UI.WebControls.Unit("60px")
            ultraGridColumn2.Width = unit
            Dim ultraGridColumn3 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("servoff_id")
            unit = New System.Web.UI.WebControls.Unit("60px")
            ultraGridColumn3.Width = unit
            Dim ultraGridColumn4 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("InOut")
            unit = New System.Web.UI.WebControls.Unit("80px")
            ultraGridColumn4.Width = unit
            Dim ultraGridColumn5 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("InOut")
            unit = New System.Web.UI.WebControls.Unit("80px")
            ultraGridColumn5.Width = unit
            Dim ultraGridColumn6 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("OutOnly")
            unit = New System.Web.UI.WebControls.Unit("80px")
            ultraGridColumn6.Width = unit
            Dim ultraGridColumn7 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("OutOnly")
            unit = New System.Web.UI.WebControls.Unit("80px")
            ultraGridColumn7.Width = unit
            Dim ultraGridColumn8 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("InOnly")
            unit = New System.Web.UI.WebControls.Unit("80px")
            ultraGridColumn8.Width = unit
            Dim ultraGridColumn9 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("InOnly")
            unit = New System.Web.UI.WebControls.Unit("80px")
            ultraGridColumn9.Width = unit
            Dim ultraGridColumn10 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnSameSide")
            unit = New System.Web.UI.WebControls.Unit("130px")
            ultraGridColumn10.Width = unit
            Dim ultraGridColumn11 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnSameSide")
            unit = New System.Web.UI.WebControls.Unit("130px")
            ultraGridColumn11.Width = unit
            Dim ultraGridColumn12 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnBothSides")
            unit = New System.Web.UI.WebControls.Unit("130px")
            ultraGridColumn12.Width = unit
            Dim ultraGridColumn13 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnBothSides")
            unit = New System.Web.UI.WebControls.Unit("130px")
            ultraGridColumn13.Width = unit
            Dim ultraGridColumn14 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Scrape2SidesClnBothSides")
            unit = New System.Web.UI.WebControls.Unit("130px")
            ultraGridColumn14.Width = unit
            Dim ultraGridColumn15 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Scrape2SidesClnBothSides")
            unit = New System.Web.UI.WebControls.Unit("130px")
            ultraGridColumn15.Width = unit
            Me.UG1.Bands(1).Columns.FromKey("ParentServOff_Id").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("servoff_id").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("servoff_id").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("grouping").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("grouping").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("position").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("position").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("ServOff_Name").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(0).Columns.FromKey("servOff_Name").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(0).Columns.FromKey("OutOnly").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("OutOnly").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnSameSide").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnSameSide").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(0).Columns.FromKey("Scrape2SidesClnBothSides").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("Scrape2SidesClnBothSides").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnSameSide").HeaderText = "Scrp 1 Sd<br>Cln Same Sd"
            Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnSameSide").HeaderText = "Scrp 1 Sd<br>Cln Same Sd"
            Me.UG1.Bands(1).Columns.FromKey("Scrape2SidesClnBothSides").HeaderText = "Scrp 2 Sds<br>Cln Both Sds"
            Me.UG1.Bands(0).Columns.FromKey("Scrape2SidesClnBothSides").HeaderText = "Scrp 2 Sds<br>Cln Both Sds"
            Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnBothSides").HeaderText = "Scrp 1 Sd<br>Cln Both Sds"
            Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnBothSides").HeaderText = "Scrp 1 Sd<br>Cln Both Sds"
        End Sub

        Private Sub UG1_PageIndexChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.PageEventArgs) Handles UG1.PageIndexChanged
            Me.AssignDataSource()
        End Sub

        Private Sub UG1_UpdateCellBatch(ByVal sender As Object, ByVal e As CellEventArgs) Handles UG1.UpdateCellBatch
            If (ObjectType.ObjTst(e.Cell.Row.DataKey, Nothing, False) <> 0) Then
                Dim num As Decimal = DecimalType.FromObject(e.Cell.Value)
                Dim num1 As Integer = IntegerType.FromObject(e.Cell.Row.DataKey)
                Dim baseColumnName As String = e.Cell.Column.BaseColumnName
                UCCPricing.updatePricing(num1, baseColumnName, num)
            End If
        End Sub
    End Class
End Namespace