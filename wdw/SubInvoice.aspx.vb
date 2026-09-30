Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Web
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI

Namespace wdw
    Public Class SubInvoice
        Inherits PageBase
        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        Private crystalUtil1 As CrystalUtil

        Private crReportDocument As SubInvoiceRpt

        'Protected Overridable Property CrystalReportViewer1 As CrystalReportViewer
        '    Get
        '        Return Me._CrystalReportViewer1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CrystalReportViewer)
        '        Me._CrystalReportViewer1 Is Nothing
        '        Me._CrystalReportViewer1 = value
        '        Me._CrystalReportViewer1 Is Nothing
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim subInvoice1 As SubInvoice = Me
            'MyBase.add_Load(New EventHandler(subInvoice1, subInvoice1.Page_Load))
            Dim subInvoice2 As SubInvoice = Me
            'MyBase.add_Init(New EventHandler(subInvoice2, subInvoice2.Page_Init))
            Me.crystalUtil1 = New CrystalUtil()
            Me.crReportDocument = New SubInvoiceRpt()
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim item As String = Me.Page().Request().Item("CloseOut_ID")
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue.Value = (IntegerType.FromString(item))
            parameterValue.Add(parameterDiscreteValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("CloseOutNo").ApplyCurrentValues(parameterValue)

            Me.CrystalReportViewer1.ReportSource = Me.crReportDocument
            Me.CrystalReportViewer1.DisplayToolbar = True
            Me.CrystalReportViewer1.HasToggleGroupTreeButton = False
            Me.CrystalReportViewer1.HasDrilldownTabs = False
            Me.CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
            Me.CrystalReportViewer1.Visible = True

        End Sub
    End Class
End Namespace