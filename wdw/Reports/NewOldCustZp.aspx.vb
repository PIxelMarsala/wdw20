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
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class NewOldCustZp
        Inherits PageBase
        '<AccessedThroughProperty("txtToDate")>
        'Private _txtToDate As TextBox

        '<AccessedThroughProperty("lblToDate")>
        'Private _lblToDate As Label

        '<AccessedThroughProperty("lblzip")>
        'Private _lblzip As Label

        '<AccessedThroughProperty("txtFromDate")>
        'Private _txtFromDate As TextBox

        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("lblFromDate")>
        'Private _lblFromDate As Label

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("HyperLink1")>
        'Private _HyperLink1 As HyperLink

        '<AccessedThroughProperty("Button1")>
        'Private _Button1 As Button

        '<AccessedThroughProperty("lstZip")>
        'Private _lstZip As ListBox

        Private crReportDocument As NOCustZip

        Private crystalUtil1 As CrystalUtil

        Private strZip As String

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnLoad As Button
        '    Get
        '        Return Me._btnLoad
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim newOldCustZp As wdw.NewOldCustZp = Me
        '            Me._btnLoad.remove_Click(New EventHandler(newOldCustZp, newOldCustZp.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim newOldCustZp1 As wdw.NewOldCustZp = Me
        '            Me._btnLoad.add_Click(New EventHandler(newOldCustZp1, newOldCustZp1.btnLoad_Click))
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
        '            Dim newOldCustZp As wdw.NewOldCustZp = Me
        '            Me._Button1.remove_Click(New EventHandler(newOldCustZp, newOldCustZp.Button1_Click))
        '        End If
        '        Me._Button1 = value
        '        If (Me._Button1 IsNot Nothing) Then
        '            Dim newOldCustZp1 As wdw.NewOldCustZp = Me
        '            Me._Button1.add_Click(New EventHandler(newOldCustZp1, newOldCustZp1.Button1_Click))
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

        'Protected Overridable Property lblzip As Label
        '    Get
        '        Return Me._lblzip
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblzip Is Nothing
        '        Me._lblzip = value
        '        Me._lblzip Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstZip As ListBox
        '    Get
        '        Return Me._lstZip
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As ListBox)
        '        Me._lstZip Is Nothing
        '        Me._lstZip = value
        '        Me._lstZip Is Nothing
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
            Dim newOldCustZp1 As NewOldCustZp = Me
            'MyBase.add_Load(New EventHandler(newOldCustZp1, newOldCustZp1.Page_Load))
            Dim newOldCustZp2 As NewOldCustZp = Me
            'MyBase.add_Init(New EventHandler(newOldCustZp2, newOldCustZp2.Page_Init))
            Me.crReportDocument = New NOCustZip()
            Me.crystalUtil1 = New CrystalUtil()
            Me.strZip = ""
            Me.FUNCTIONNAME = "NewClientsByZipCode"
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
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue.Value = (DateType.FromString(Me.txtFromDate.Text()))
            parameterValue.Add(parameterDiscreteValue)
            parameterDiscreteValue1.Value = (DateType.FromString(Me.txtToDate.Text()))
            parameterValue1.Add(parameterDiscreteValue1)
            Try
                enumerator = Me.lstZip.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (Not current.Selected) Then
                        Continue While
                    End If
                    Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
                    parameterDiscreteValue2.Value = (current.Text())
                    Dim text() As String = {Me.strZip, "'", current.Text(), "'", ","}
                    Me.strZip = String.Concat(text)
                    parameterValue2.Add(parameterDiscreteValue2)
                    Me.crReportDocument.DataDefinition().ParameterFields().Item("ZipCode").ApplyCurrentValues(parameterValue2)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Me.strZip = Strings.Mid(Me.strZip, 1, Strings.Len(Me.strZip) - 1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue1)

            Me.CrystalReportViewer1.ReportSource = Me.crReportDocument
            CrystalUtil.CrystalReportFormatter(Me.CrystalReportViewer1)
        End Sub

        'Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        '    Dim enumerator As IEnumerator = Nothing
        '    Dim excelFormatOption As ExcelFormatOptions = New ExcelFormatOptions()
        '    Dim pdfRtfWordFormatOption As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
        '    Dim diskFileDestinationOption As DiskFileDestinationOptions = New DiskFileDestinationOptions()
        '    Dim nOCustZip As NOCustZip = New NOCustZip()
        '    Dim str As String = "WDWCustZip.xls"
        '    Dim parameterValue As ParameterValues = New ParameterValues()
        '    Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
        '    Dim parameterValue1 As ParameterValues = New ParameterValues()
        '    Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
        '    Dim parameterValue2 As ParameterValues = New ParameterValues()
        '    Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
        '    parameterDiscreteValue.Value = (DateType.FromString(Me.txtFromDate.Text()))
        '    parameterValue.Add(parameterDiscreteValue)
        '    parameterDiscreteValue1.Value = (DateType.FromString(Me.txtToDate.Text()))
        '    parameterValue1.Add(parameterDiscreteValue1)
        '    Try
        '        enumerator = Me.lstZip.Items().GetEnumerator()
        '        While enumerator.MoveNext()
        '            Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
        '            If (Not current.Selected) Then
        '                Continue While
        '            End If
        '            Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
        '            parameterDiscreteValue2.Value = (current.Text())
        '            Dim text() As String = {Me.strZip, "'", current.Text(), "'", ","}
        '            Me.strZip = String.Concat(text)
        '            parameterValue2.Add(parameterDiscreteValue2)
        '            Me.crReportDocument.DataDefinition().ParameterFields().Item("ZipCode").ApplyCurrentValues(parameterValue2)
        '        End While
        '    Finally
        '        If (TypeOf enumerator Is IDisposable) Then
        '            DirectCast(enumerator, IDisposable).Dispose()
        '        End If
        '    End Try
        '    Me.strZip = Strings.Mid(Me.strZip, 1, Strings.Len(Me.strZip) - 1)
        '    Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue)
        '    Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue1)
        '    Me.crReportDocument.ExportOptions().ExportFormatType = (4)
        '    Me.crReportDocument.ExportOptions().FormatOptions = (excelFormatOption)
        '    Me.crReportDocument.ExportOptions().ExportDestinationType = (1)
        '    If (StringType.StrCmp(WDWConfiguration.ExecutionEnvironment, "PROD", False) <> 0) Then
        '        diskFileDestinationOption.DiskFileName = (String.Concat(WDWConfiguration.DemoPath, str))
        '        Me.HyperLink1.NavigateUrl = (String.Concat(WDWConfiguration.DemoURL, str))
        '    Else
        '        diskFileDestinationOption.DiskFileName = (String.Concat(WDWConfiguration.ProdPath, str))
        '        Me.HyperLink1.NavigateUrl = (String.Concat(WDWConfiguration.ProdURL, str))
        '    End If
        '    Me.crReportDocument.ExportOptions().DestinationOptions = (diskFileDestinationOption)
        '    Me.crReportDocument.Export()
        'End Sub

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
                Dim allZips As SqlDataReader = UCCParams.getAllZips()
                Me.lstZip.DataSource = (allZips)
                Me.lstZip.DataTextField = ("ZipCode")
                Me.lstZip.DataValueField = ("ZipCode")
                Me.lstZip.DataBind()
            Else
                Build_Report()

            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("PageState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub
    End Class
End Namespace