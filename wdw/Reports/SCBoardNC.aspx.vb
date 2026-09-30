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
    Public Class SCBoardNC
        Inherits PageBase
        '<AccessedThroughProperty("lblFromDate")>
        'Private _lblFromDate As Label

        '<AccessedThroughProperty("ddlMonth")>
        'Private _ddlMonth As DropDownList

        '<AccessedThroughProperty("lblToDate")>
        'Private _lblToDate As Label

        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("ddlYear")>
        'Private _ddlYear As DropDownList

        Private crReportDocument As ScoreNC

        Private crystalUtil1 As CrystalUtil

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnLoad As Button
        '    Get
        '        Return Me._btnLoad
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim sCBoardNC As wdw.SCBoardNC = Me
        '            Me._btnLoad.remove_Click(New EventHandler(sCBoardNC, sCBoardNC.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim sCBoardNC1 As wdw.SCBoardNC = Me
        '            Me._btnLoad.add_Click(New EventHandler(sCBoardNC1, sCBoardNC1.btnLoad_Click))
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
            Dim sCBoardNC1 As SCBoardNC = Me
            'MyBase.add_Init(New EventHandler(sCBoardNC1, sCBoardNC1.Page_Init))
            Dim sCBoardNC2 As SCBoardNC = Me
            'MyBase.add_Load(New EventHandler(sCBoardNC2, sCBoardNC2.Page_Load))
            Me.crReportDocument = New ScoreNC()
            Me.crystalUtil1 = New CrystalUtil()
            Me.FUNCTIONNAME = "ScoreBoardNC"
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

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
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
                Me.Build_Report()
            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("PageState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub
    End Class
End Namespace