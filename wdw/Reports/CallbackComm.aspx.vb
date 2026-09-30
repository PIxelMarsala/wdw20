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
    Public Class CallbackComm
        Inherits PageBase

        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("HyperLink1")>
        'Private _HyperLink1 As HyperLink

        '<AccessedThroughProperty("Button1")>
        'Private _Button1 As Button

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("txtToDate")>
        'Private _txtToDate As TextBox

        '<AccessedThroughProperty("lstUser")>
        'Private _lstUser As ListBox

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("lblToDate")>
        'Private _lblToDate As Label

        '<AccessedThroughProperty("txtFromDate")>
        'Private _txtFromDate As TextBox

        '<AccessedThroughProperty("lblCommission")>
        'Private _lblCommission As Label

        '<AccessedThroughProperty("lstSub")>
        'Private _lstSub As ListBox

        '<AccessedThroughProperty("lblFromDate")>
        'Private _lblFromDate As Label

        Private crystalUtil1 As CrystalUtil

        Private crReportDocument As CallbackCommission

        Private dtFrom As DateTime

        Private dtTo As DateTime

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnLoad As Button
        '    Get
        '        Return Me._btnLoad
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim callbackComm As wdw.CallbackComm = Me
        '            Me._btnLoad.remove_Click(New EventHandler(callbackComm, callbackComm.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim callbackComm1 As wdw.CallbackComm = Me
        '            Me._btnLoad.add_Click(New EventHandler(callbackComm1, callbackComm1.btnLoad_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property Button1 As Button
        '    Get
        '        Return Me._Button1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._Button1 IsNot Nothing) Then
        '            Dim callbackComm As wdw.CallbackComm = Me
        '            Me._Button1.remove_Click(New EventHandler(callbackComm, callbackComm.Button1_Click))
        '        End If
        '        Me._Button1 = value
        '        If (Me._Button1 IsNot Nothing) Then
        '            Dim callbackComm1 As wdw.CallbackComm = Me
        '            Me._Button1.add_Click(New EventHandler(callbackComm1, callbackComm1.Button1_Click))
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

        'Protected Overridable Property lblCommission As Label
        '    Get
        '        Return Me._lblCommission
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblCommission Is Nothing
        '        Me._lblCommission = value
        '        Me._lblCommission Is Nothing
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

        'Protected Overridable Property lstUser As ListBox
        '    Get
        '        Return Me._lstUser
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As ListBox)
        '        Me._lstUser Is Nothing
        '        Me._lstUser = value
        '        Me._lstUser Is Nothing
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
            Dim callbackComm1 As CallbackComm = Me
            'MyBase.add_Init(New EventHandler(callbackComm1, callbackComm1.Page_Init))
            Dim callbackComm2 As CallbackComm = Me
            'MyBase.add_Load(New EventHandler(callbackComm2, callbackComm2.Page_Load))
            Me.crystalUtil1 = New CrystalUtil()
            Me.crReportDocument = New CallbackCommission()
            Me.FUNCTIONNAME = "CallbackCommissions"
        End Sub

        Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
            Me.Build_Report()
        End Sub

        Private Sub Build_Report()
            Dim str As String = Nothing
            Dim enumerator As IEnumerator = Nothing
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue2 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue3 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue3 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue2.Value = (DateType.FromString(Me.txtFromDate.Text()))
            Me.dtFrom = DateType.FromString(Me.txtFromDate.Text())
            parameterValue2.Add(parameterDiscreteValue2)
            parameterDiscreteValue3.Value = (DateType.FromString(Me.txtToDate.Text()))
            parameterValue3.Add(parameterDiscreteValue3)
            Me.dtTo = DateType.FromString(Me.txtToDate.Text())
            parameterDiscreteValue.Value = (IntegerType.FromString(Me.lstSub.SelectedItem().Text()))
            parameterValue.Add(parameterDiscreteValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("CreateUser").EnableAllowMultipleValue = (True)
            Try
                enumerator = Me.lstUser.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (Not current.Selected) Then
                        Continue While
                    End If
                    parameterDiscreteValue1.Value = (current.Text())
                    Dim text() As String = {str, "'", current.Text(), "'", ","}
                    str = String.Concat(text)
                    parameterValue1.Add(parameterDiscreteValue1)
                    Me.crReportDocument.DataDefinition().ParameterFields().Item("CreateUser").ApplyCurrentValues(parameterValue1)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            str = Strings.Mid(str, 1, Strings.Len(str) - 1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue2)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue3)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("CreateUser").ApplyCurrentValues(parameterValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Percentage").ApplyCurrentValues(parameterValue)

            Me.CrystalReportViewer1.ReportSource = Me.crReportDocument
            CrystalUtil.CrystalReportFormatter(Me.CrystalReportViewer1)
        End Sub

        'Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        '    Dim str As String = Nothing
        '    Dim enumerator As IEnumerator = Nothing
        '    Dim excelFormatOption As ExcelFormatOptions = New ExcelFormatOptions()
        '    Dim pdfRtfWordFormatOption As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
        '    Dim diskFileDestinationOption As DiskFileDestinationOptions = New DiskFileDestinationOptions()
        '    Dim callbackCommission As CallbackCommission = New CallbackCommission()
        '    Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
        '    Dim parameterValue As ParameterValues = New ParameterValues()
        '    Dim parameterValue1 As ParameterValues = New ParameterValues()
        '    Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
        '    Dim parameterValue2 As ParameterValues = New ParameterValues()
        '    Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
        '    Dim parameterValue3 As ParameterValues = New ParameterValues()
        '    Dim parameterDiscreteValue3 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
        '    Dim str1 As String = "WDWCallbackComm.rtf"
        '    Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
        '    parameterDiscreteValue2.Value = (DateType.FromString(Me.txtFromDate.Text()))
        '    Me.dtFrom = DateType.FromString(Me.txtFromDate.Text())
        '    parameterValue2.Add(parameterDiscreteValue2)
        '    parameterDiscreteValue3.Value = (DateType.FromString(Me.txtToDate.Text()))
        '    parameterValue3.Add(parameterDiscreteValue3)
        '    Me.dtTo = DateType.FromString(Me.txtToDate.Text())
        '    parameterDiscreteValue.Value = (IntegerType.FromString(Me.lstSub.SelectedItem().Text()))
        '    parameterValue.Add(parameterDiscreteValue)
        '    Me.crReportDocument.DataDefinition().ParameterFields().Item("CreateUser").EnableAllowMultipleValue = (True)
        '    Try
        '        enumerator = Me.lstUser.Items().GetEnumerator()
        '        While enumerator.MoveNext()
        '            Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
        '            If (Not current.Selected) Then
        '                Continue While
        '            End If
        '            parameterDiscreteValue1.Value = (current.Text())
        '            Dim text() As String = {str, "'", current.Text(), "'", ","}
        '            str = String.Concat(text)
        '            parameterValue1.Add(parameterDiscreteValue1)
        '            Me.crReportDocument.DataDefinition().ParameterFields().Item("CreateUser").ApplyCurrentValues(parameterValue1)
        '        End While
        '    Finally
        '        If (TypeOf enumerator Is IDisposable) Then
        '            DirectCast(enumerator, IDisposable).Dispose()
        '        End If
        '    End Try
        '    str = Strings.Mid(str, 1, Strings.Len(str) - 1)
        '    Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue2)
        '    Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue3)
        '    Me.crReportDocument.DataDefinition().ParameterFields().Item("CreateUser").ApplyCurrentValues(parameterValue1)
        '    Me.crReportDocument.DataDefinition().ParameterFields().Item("Percentage").ApplyCurrentValues(parameterValue)
        '    pdfRtfWordFormatOption.UsePageRange = (False)
        '    Me.crReportDocument.ExportOptions().ExportFormatType = (2)
        '    Me.crReportDocument.ExportOptions().FormatOptions = (pdfRtfWordFormatOption)
        '    Me.crReportDocument.ExportOptions().ExportDestinationType = (1)
        '    If (StringType.StrCmp(WDWConfiguration.ExecutionEnvironment, "PROD", False) <> 0) Then
        '        diskFileDestinationOption.DiskFileName = (String.Concat(WDWConfiguration.DemoPath, str1))
        '        Me.HyperLink1.NavigateUrl = (String.Concat(WDWConfiguration.DemoURL, str1))
        '    Else
        '        diskFileDestinationOption.DiskFileName = (String.Concat(WDWConfiguration.ProdPath, str1))
        '        Me.HyperLink1.NavigateUrl = (String.Concat(WDWConfiguration.ProdURL, str1))
        '    End If
        '    Me.crReportDocument.ExportOptions().DestinationOptions = (diskFileDestinationOption)
        '    Me.crReportDocument.Export()
        '    Me.HyperLink1.Visible = (True)
        'End Sub

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
                Dim allUsers As SqlDataReader = UCCParams.getAllUsers()
                Me.lstUser.DataSource = allUsers
                Me.lstUser.DataTextField = "UserID"
                Me.lstUser.DataValueField = "UserID"
                Me.lstUser.DataBind()
            Else
                Build_Report()

            End If
        End Sub
    End Class
End Namespace