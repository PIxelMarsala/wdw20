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

Namespace wdw
    Public Class SCBoard2
        Inherits PageBase
        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("ddlYear")>
        'Private _ddlYear As DropDownList

        '<AccessedThroughProperty("ddlMonth")>
        'Private _ddlMonth As DropDownList

        '<AccessedThroughProperty("lblToDate")>
        'Private _lblToDate As Label

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("lblFromDate")>
        'Private _lblFromDate As Label

        Private crReportDocument As ScoreCount

        Private crystalUtil1 As CrystalUtil

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnLoad As Button
        '    Get
        '        Return Me._btnLoad
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim sCBoard2 As wdw.SCBoard2 = Me
        '            Me._btnLoad.remove_Click(New EventHandler(sCBoard2, sCBoard2.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim sCBoard21 As wdw.SCBoard2 = Me
        '            Me._btnLoad.add_Click(New EventHandler(sCBoard21, sCBoard21.btnLoad_Click))
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

        'Protected Overridable Property ddlMonth As DropDownList
        '    Get
        '        Return Me._ddlMonth
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._ddlMonth Is Nothing
        '        Me._ddlMonth = value
        '        Me._ddlMonth Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property ddlYear As DropDownList
        '    Get
        '        Return Me._ddlYear
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        Me._ddlYear Is Nothing
        '        Me._ddlYear = value
        '        Me._ddlYear Is Nothing
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

        Public Sub New()
            MyBase.New()
            Dim sCBoard21 As SCBoard2 = Me
            'MyBase.add_Init(New EventHandler(sCBoard21, sCBoard21.Page_Init))
            Dim sCBoard22 As SCBoard2 = Me
            'MyBase.add_Load(New EventHandler(sCBoard22, sCBoard22.Page_Load))
            Me.crReportDocument = New ScoreCount()
            Me.crystalUtil1 = New CrystalUtil()
            Me.FUNCTIONNAME = "ScoreBoardCount"
        End Sub

        Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
            Me.Build_Report()
        End Sub

        Private Sub Build_Report()
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue.Value = (Me.ddlMonth.SelectedValue())
            parameterValue.Add(parameterDiscreteValue)
            parameterDiscreteValue1.Value = (Me.ddlYear.SelectedValue())
            parameterValue1.Add(parameterDiscreteValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Month").ApplyCurrentValues(parameterValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Year").ApplyCurrentValues(parameterValue1)

            Me.CrystalReportViewer1.ReportSource = Me.crReportDocument
            CrystalUtil.CrystalReportFormatter(Me.CrystalReportViewer1)
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("PageState")
        End Function

        Private Sub lstCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.Build_Report()
        End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If (Not Me.Page().IsPostBack()) Then
                Dim minMaxMonthDay As SqlDataReader = UCCParams.getMinMaxMonthDay()
                minMaxMonthDay.Read()
                Dim num As Integer = IntegerType.FromObject(minMaxMonthDay.Item(0))
                minMaxMonthDay.Read()
                Dim num1 As Integer = IntegerType.FromObject(minMaxMonthDay.Item(0))
                Dim num2 As Integer = num
                For i As Integer = num1 To num2 Step -1
                    Me.ddlYear.Items().Add(StringType.FromInteger(i))
                Next
            Else
                Build_Report()
            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("PageState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub
    End Class
End Namespace