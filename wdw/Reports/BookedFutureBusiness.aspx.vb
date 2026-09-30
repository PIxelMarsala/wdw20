Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Web
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class BookedFutureBusiness
        Inherits PageBase

        '<AccessedThroughProperty("txtCurrDate")>
        'Private _txtCurrDate As TextBox

        '<AccessedThroughProperty("lblCurrDate")>
        'Private _lblCurrDate As Label

        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("brnPrint")>
        'Private _brnPrint As Button

        Private FUNCTIONNAME As String

        'Protected Overridable Property brnPrint As Button
        '    Get
        '        Return Me._brnPrint
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._brnPrint IsNot Nothing) Then
        '            Dim bookedFutureBusiness As wdw.BookedFutureBusiness = Me
        '            Me._brnPrint.remove_Click(New EventHandler(bookedFutureBusiness, bookedFutureBusiness.brnPrint_Click))
        '        End If
        '        Me._brnPrint = value
        '        If (Me._brnPrint IsNot Nothing) Then
        '            Dim bookedFutureBusiness1 As wdw.BookedFutureBusiness = Me
        '            Me._brnPrint.add_Click(New EventHandler(bookedFutureBusiness1, bookedFutureBusiness1.brnPrint_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnLoad As Button
        '    Get
        '        Return Me._btnLoad
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim bookedFutureBusiness As wdw.BookedFutureBusiness = Me
        '            Me._btnLoad.remove_Click(New EventHandler(bookedFutureBusiness, bookedFutureBusiness.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim bookedFutureBusiness1 As wdw.BookedFutureBusiness = Me
        '            Me._btnLoad.add_Click(New EventHandler(bookedFutureBusiness1, bookedFutureBusiness1.btnLoad_Click))
        '        End If
        '    End Set
        'End Property

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

        'Protected Overridable Property lblCurrDate As Label
        '    Get
        '        Return Me._lblCurrDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblCurrDate Is Nothing
        '        Me._lblCurrDate = value
        '        Me._lblCurrDate Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtCurrDate As TextBox
        '    Get
        '        Return Me._txtCurrDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtCurrDate Is Nothing
        '        Me._txtCurrDate = value
        '        Me._txtCurrDate Is Nothing
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim bookedFutureBusiness1 As BookedFutureBusiness = Me
            'MyBase.add_Init(New EventHandler(bookedFutureBusiness1, bookedFutureBusiness1.Page_Init))
            Dim bookedFutureBusiness2 As BookedFutureBusiness = Me
            'MyBase.add_Load(New EventHandler(bookedFutureBusiness2, bookedFutureBusiness2.Page_Load))
            Me.FUNCTIONNAME = "FutureMonthsBusiness"
        End Sub

        'Private Sub brnPrint_Click(ByVal sender As Object, ByVal e As EventArgs)
        'End Sub

        Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
            BuildReport()
        End Sub

        Public Sub BuildReport()

            If Me.txtCurrDate.Text = "" Then Exit Sub

            Dim crystalUtil As wdw.CrystalUtil = New wdw.CrystalUtil()
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim bookedFutureBu As BookedFutureBus = New BookedFutureBus()
            Me.CrystalReportViewer1.Visible = True
            crystalUtil.ChangeDataSource(bookedFutureBu)
            parameterDiscreteValue.Value = DateType.FromString(Me.txtCurrDate.Text())
            parameterValue.Add(parameterDiscreteValue)
            bookedFutureBu.DataDefinition().ParameterFields().Reset()
            bookedFutureBu.DataDefinition().ParameterFields().Item("CurrentDate").ApplyCurrentValues(parameterValue)
            Me.CrystalReportViewer1.ReportSource = bookedFutureBu
            CrystalUtil.CrystalReportFormatter(Me.CrystalReportViewer1)

        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
            If IsPostBack() Then
                BuildReport()
            End If
        End Sub
    End Class
End Namespace