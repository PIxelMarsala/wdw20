Imports BusinessService
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Web
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class DetRevBySubCont
        Inherits PageBase

        '<AccessedThroughProperty("lblFromDate")>
        'Private _lblFromDate As Label

        '<AccessedThroughProperty("lblSub")>
        'Private _lblSub As Label

        '<AccessedThroughProperty("txtToDate")>
        'Private _txtToDate As TextBox

        '<AccessedThroughProperty("lblToDate")>
        'Private _lblToDate As Label

        '<AccessedThroughProperty("lstSub")>
        'Private _lstSub As ListBox

        '<AccessedThroughProperty("txtFromDate")>
        'Private _txtFromDate As TextBox

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("CrystalReportViewer2")>
        'Private _CrystalReportViewer2 As CrystalReportViewer

        Private crReportDocument As DetRevBySub

        Private crystalUtil1 As CrystalUtil

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnLoad As Button
        '    Get
        '        Return Me._btnLoad
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim detRevBySubCont As wdw.DetRevBySubCont = Me
        '            Me._btnLoad.remove_Click(New EventHandler(detRevBySubCont, detRevBySubCont.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim detRevBySubCont1 As wdw.DetRevBySubCont = Me
        '            Me._btnLoad.add_Click(New EventHandler(detRevBySubCont1, detRevBySubCont1.btnLoad_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property CrystalReportViewer2 As CrystalReportViewer
        '    Get
        '        Return Me._CrystalReportViewer2
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As CrystalReportViewer)
        '        Me._CrystalReportViewer2 Is Nothing
        '        Me._CrystalReportViewer2 = value
        '        Me._CrystalReportViewer2 Is Nothing
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

        'Protected Overridable Property lblSub As Label
        '    Get
        '        Return Me._lblSub
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblSub Is Nothing
        '        Me._lblSub = value
        '        Me._lblSub Is Nothing
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

        'Protected Overridable Property lstSub As ListBox
        '    Get
        '        Return Me._lstSub
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As ListBox)
        '        Me._lstSub Is Nothing
        '        Me._lstSub = value
        '        Me._lstSub Is Nothing
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
            Dim detRevBySubCont1 As DetRevBySubCont = Me
            'MyBase.add_Init(New EventHandler(detRevBySubCont1, detRevBySubCont1.Page_Init))
            Dim detRevBySubCont2 As DetRevBySubCont = Me
            'MyBase.add_Load(New EventHandler(detRevBySubCont2, detRevBySubCont2.Page_Load))
            Me.crReportDocument = New DetRevBySub()
            Me.crystalUtil1 = New CrystalUtil()
            Me.FUNCTIONNAME = "MarginDetail"
        End Sub

        Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
            Me.Build_Report()
        End Sub

        Private Sub Build_Report()
            Dim enumerator As IEnumerator = Nothing
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue2 As ParameterValues = New ParameterValues()
            Dim str As String = ""
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue.Value = (DateType.FromString(Me.txtFromDate.Text()))
            parameterValue.Add(parameterDiscreteValue)
            parameterDiscreteValue1.Value = (DateType.FromString(Me.txtToDate.Text()))
            parameterValue1.Add(parameterDiscreteValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Subcontractor").EnableAllowMultipleValue = (True)
            Try
                enumerator = Me.lstSub.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (Not current.Selected) Then
                        Continue While
                    End If
                    Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
                    parameterDiscreteValue2.Value = (current.Text())
                    Dim text() As String = {str, "'", current.Text(), "'", ","}
                    str = String.Concat(text)
                    parameterValue2.Add(parameterDiscreteValue2)
                    Me.crReportDocument.DataDefinition().ParameterFields().Item("Subcontractor").ApplyCurrentValues(parameterValue2)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            str = Strings.Mid(str, 1, Strings.Len(str) - 1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue1)

            Me.CrystalReportViewer2.ReportSource = Me.crReportDocument
            CrystalUtil.CrystalReportFormatter(Me.CrystalReportViewer2)
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Private Sub lstSub_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.Build_Report()
        End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
            If (Not Me.Page().IsPostBack()) Then
                Dim allSubs As SqlDataReader = UCCParams.getAllSubs()
                Me.lstSub.DataSource = allSubs
                Me.lstSub.DataTextField = "Nick_Name"
                Me.lstSub.DataValueField = "Nick_Name"
                Me.lstSub.DataBind()
            Else
                Build_Report()

            End If
        End Sub
    End Class
End Namespace