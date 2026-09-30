Imports BusinessService
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Web
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class BOTax_Detail
        Inherits PageBase

        '<AccessedThroughProperty("lblToDate")>
        'Private _lblToDate As Label

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("txtFromDate")>
        'Private _txtFromDate As TextBox

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("lblFromDate")>
        'Private _lblFromDate As Label

        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("lstCity")>
        'Private _lstCity As DropDownList

        '<AccessedThroughProperty("txtToDate")>
        'Private _txtToDate As TextBox

        Private crReportDocument As BOTx11_Detail

        Private crystalUtil1 As CrystalUtil

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnLoad As Button
        '    Get
        '        Return Me._btnLoad
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim bOTax As wdw.BOTax = Me
        '            Me._btnLoad.remove_Click(New EventHandler(bOTax, bOTax.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim bOTax1 As wdw.BOTax = Me
        '            Me._btnLoad.add_Click(New EventHandler(bOTax1, bOTax1.btnLoad_Click))
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

        'Protected Overridable Property lblToDate As Label
        '    Get
        '        Return Me._lblToDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblToDate Is Nothing
        '        Me._lblToDate = value
        '        Me._lblToDate Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstCity As DropDownList
        '    Get
        '        Return Me._lstCity
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._lstCity Is Nothing
        '        Me._lstCity = value
        '        Me._lstCity Is Nothing
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

        Public Sub New()
            MyBase.New()
            Dim bOTax1 As BOTax_Detail = Me
            'MyBase.add_Init(New EventHandler(bOTax1, bOTax1.Page_Init))
            Dim bOTax2 As BOTax_Detail = Me
            'MyBase.add_Load(New EventHandler(bOTax2, bOTax2.Page_Load))
            Me.crReportDocument = New BOTx11_Detail()
            Me.crystalUtil1 = New CrystalUtil()
            Me.FUNCTIONNAME = "B&O"
        End Sub

        Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
            Me.Build_Report()
        End Sub

        Private Sub Build_Report()
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue2 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue.Value = (DateType.FromString(Me.txtFromDate.Text()))
            parameterValue.Add(parameterDiscreteValue)
            parameterDiscreteValue1.Value = (DateType.FromString(Me.txtToDate.Text()))
            parameterValue1.Add(parameterDiscreteValue1)
            parameterDiscreteValue2.Value = (Me.lstCity.SelectedItem().Text())
            parameterValue2.Add(parameterDiscreteValue2)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("City").ApplyCurrentValues(parameterValue2)

            Me.CrystalReportViewer1.ReportSource = Me.crReportDocument
            CrystalUtil.CrystalReportFormatter(Me.CrystalReportViewer1)
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("PageState")
        End Function

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
            If (Not Me.Page().IsPostBack()) Then
                Dim allCities As SqlDataReader = UCCParams.getAllCities()
                Me.lstCity.DataSource = (allCities)
                Me.lstCity.DataTextField = ("Site_City")
                Me.lstCity.DataValueField = ("Site_City")
                Me.lstCity.DataBind()
            Else
                Build_Report()
            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("PageState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub

    End Class
End Namespace