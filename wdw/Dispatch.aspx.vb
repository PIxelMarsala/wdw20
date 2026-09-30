Imports BusinessService
Imports Common
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
    Public Class Dispatch
        Inherits PageBase

        '<AccessedThroughProperty("lstSub")>
        'Private _lstSub As ListBox

        '<AccessedThroughProperty("btnDone")>
        'Private _btnDone As Button

        '<AccessedThroughProperty("lblSub")>
        'Private _lblSub As Label

        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("lblFromDate")>
        'Private _lblFromDate As Label

        '<AccessedThroughProperty("btnExport")>
        'Private _btnExport As Button

        '<AccessedThroughProperty("CrystalReportViewer2")>
        'Private _CrystalReportViewer2 As CrystalReportViewer

        '<AccessedThroughProperty("txtFromDate")>
        'Private _txtFromDate As TextBox

        '<AccessedThroughProperty("txtToDate")>
        'Private _txtToDate As TextBox

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("lblToDate")>
        'Private _lblToDate As Label

        '<AccessedThroughProperty("HyperLink1")>
        'Private _HyperLink1 As HyperLink

        Private crReportDocument As DispatchRpt

        Private crystalUtil1 As CrystalUtil

        Private dtFrom As DateTime

        Private dtTo As DateTime

        Private strSub As String

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnDone As Button
        '    Get
        '        Return Me._btnDone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnDone IsNot Nothing) Then
        '            Dim dispatch As wdw.Dispatch = Me
        '            Me._btnDone.remove_Click(New EventHandler(dispatch, dispatch.btnDone_Click))
        '        End If
        '        Me._btnDone = value
        '        If (Me._btnDone IsNot Nothing) Then
        '            Dim dispatch1 As wdw.Dispatch = Me
        '            Me._btnDone.add_Click(New EventHandler(dispatch1, dispatch1.btnDone_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnExport As Button
        '    Get
        '        Return Me._btnExport
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnExport IsNot Nothing) Then
        '            Dim dispatch As wdw.Dispatch = Me
        '            Me._btnExport.remove_Click(New EventHandler(dispatch, dispatch.btnExport_Click))
        '        End If
        '        Me._btnExport = value
        '        If (Me._btnExport IsNot Nothing) Then
        '            Dim dispatch1 As wdw.Dispatch = Me
        '            Me._btnExport.add_Click(New EventHandler(dispatch1, dispatch1.btnExport_Click))
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
        '            Dim dispatch As wdw.Dispatch = Me
        '            Me._btnLoad.remove_Click(New EventHandler(dispatch, dispatch.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim dispatch1 As wdw.Dispatch = Me
        '            Me._btnLoad.add_Click(New EventHandler(dispatch1, dispatch1.btnLoad_Click))
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

        'Protected Overridable Property HyperLink1 As HyperLink
        '    Get
        '        Return Me._HyperLink1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As HyperLink)
        '        Me._HyperLink1 Is Nothing
        '        Me._HyperLink1 = value
        '        Me._HyperLink1 Is Nothing
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
            Dim dispatch1 As Dispatch = Me
            'MyBase.add_Init(New EventHandler(dispatch1, dispatch1.Page_Init))
            Dim dispatch2 As Dispatch = Me
            'MyBase.add_Load(New EventHandler(dispatch2, dispatch2.Page_Load))
            Me.crReportDocument = New DispatchRpt()
            Me.crystalUtil1 = New CrystalUtil()
            Me.strSub = ""
            Me.FUNCTIONNAME = "Dispatch"
        End Sub

        'Private Sub btnDone_Click(ByVal sender As Object, ByVal e As EventArgs)
        'End Sub

        Private Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
            Dim enumerator As IEnumerator = Nothing
            Dim excelFormatOption As ExcelFormatOptions = New ExcelFormatOptions()
            Dim pdfRtfWordFormatOption As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
            Dim diskFileDestinationOption As DiskFileDestinationOptions = New DiskFileDestinationOptions()
            Dim dispatchRpt As DispatchRpt = New DispatchRpt()
            Dim str As String = "WDWDispatch.rtf"
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue2 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue3 As ParameterValues = New ParameterValues()
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue1.Value = (Me.txtFromDate.Text())
            Me.dtFrom = DateType.FromString(Me.txtFromDate.Text())
            parameterValue1.Add(parameterDiscreteValue1)
            parameterDiscreteValue2.Value = (Me.txtToDate.Text())
            parameterValue2.Add(parameterDiscreteValue2)
            Me.dtTo = DateType.FromString(Me.txtToDate.Text())
            parameterDiscreteValue.Value = (MyBase.[Operator].userId)
            parameterValue.Add(parameterDiscreteValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Subcontractor").EnableAllowMultipleValue = (True)
            Try
                enumerator = Me.lstSub.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (Not current.Selected) Then
                        Continue While
                    End If
                    Dim parameterDiscreteValue3 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
                    parameterDiscreteValue3.Value = (current.Text())
                    Dim text() As String = {Me.strSub, "'", current.Text(), "'", ","}
                    Me.strSub = String.Concat(text)
                    parameterValue3.Add(parameterDiscreteValue3)
                    Me.crReportDocument.DataDefinition().ParameterFields().Item("Subcontractor").ApplyCurrentValues(parameterValue3)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Me.strSub = Strings.Mid(Me.strSub, 1, Strings.Len(Me.strSub) - 1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue2)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Operator").ApplyCurrentValues(parameterValue)
            pdfRtfWordFormatOption.UsePageRange = (False)
            Me.crReportDocument.ExportOptions().ExportFormatType = (2)
            Me.crReportDocument.ExportOptions().FormatOptions = (pdfRtfWordFormatOption)
            Me.crReportDocument.ExportOptions().ExportDestinationType = (1)
            If (StringType.StrCmp(WDWConfiguration.ExecutionEnvironment, "PROD", False) <> 0) Then
                diskFileDestinationOption.DiskFileName = WDWConfiguration.DemoPath & str
                HyperLink1.NavigateUrl = WDWConfiguration.DemoURL & str
            Else
                diskFileDestinationOption.DiskFileName = WDWConfiguration.ProdPath & str
                HyperLink1.NavigateUrl = WDWConfiguration.ProdURL & str
            End If
            Me.crReportDocument.ExportOptions().DestinationOptions = (diskFileDestinationOption)
            Me.crReportDocument.Export()
            HyperLink1.Visible = True
        End Sub

        Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
            Dim enumerator As IEnumerator = Nothing
            Me.Build_Report()
            Try
                enumerator = Me.lstSub.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (Not current.Selected) Then
                        Continue While
                    End If
                    UCCParams.updateJobStatus(Me.dtFrom, Me.dtTo, current.Text())
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End Sub

        Private Sub Build_Report()
            Dim enumerator As IEnumerator = Nothing
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue2 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue3 As ParameterValues = New ParameterValues()
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue1.Value=(Me.txtFromDate.Text())
            Me.dtFrom = DateType.FromString(Me.txtFromDate.Text())
            parameterValue1.Add(parameterDiscreteValue1)
            parameterDiscreteValue2.Value=(Me.txtToDate.Text())
            parameterValue2.Add(parameterDiscreteValue2)
            Me.dtTo = DateType.FromString(Me.txtToDate.Text())
            parameterDiscreteValue.Value=(MyBase.[Operator].userId)
            parameterValue.Add(parameterDiscreteValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Subcontractor").EnableAllowMultipleValue = (True)
            Try
                enumerator = Me.lstSub.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (Not current.Selected) Then
                        Continue While
                    End If
                    Dim parameterDiscreteValue3 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
                    parameterDiscreteValue3.Value=(current.Text())
                    Dim text() As String = {Me.strSub, "'", current.Text(), "'", ","}
                    Me.strSub = String.Concat(text)
                    parameterValue3.Add(parameterDiscreteValue3)
                    Me.crReportDocument.DataDefinition().ParameterFields().Item("Subcontractor").ApplyCurrentValues(parameterValue3)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Me.strSub = Strings.Mid(Me.strSub, 1, Strings.Len(Me.strSub) - 1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue2)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Operator").ApplyCurrentValues(parameterValue)
            Me.CrystalReportViewer1.ReportSource = (Me.crReportDocument)
            Me.CrystalReportViewer1.Visible=(True)
            Me.btnExport.Visible = (True)
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Private Sub lstSub_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstSub.SelectedIndexChanged
            Me.Build_Report()
        End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
            If (Not Me.Page().IsPostBack()) Then
                Dim allSubs As SqlDataReader = UCCParams.getAllSubs()
                Me.lstSub.DataSource = (allSubs)
                Me.lstSub.DataTextField = ("Nick_Name")
                Me.lstSub.DataValueField = ("Nick_Name")
                Me.lstSub.DataBind()
            End If
        End Sub
    End Class
End Namespace