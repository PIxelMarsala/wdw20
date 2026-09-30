Imports BusinessService
Imports Common
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Web
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class CBLbl
        Inherits PageBase
        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("HyperLink1")>
        'Private _HyperLink1 As HyperLink

        '<AccessedThroughProperty("Form1")>
        'Private _Form1 As HtmlForm

        '<AccessedThroughProperty("HyperLink2")>
        'Private _HyperLink2 As HyperLink

        '<AccessedThroughProperty("lblErrorMsg")>
        'Private _lblErrorMsg As Label

        '<AccessedThroughProperty("btnLoad")>
        'Private _btnLoad As Button

        '<AccessedThroughProperty("btnDone")>
        'Private _btnDone As Button

        '<AccessedThroughProperty("Button2")>
        'Private _Button2 As Button

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        Private crystalUtil1 As CrystalUtil

        Private crReportDocument As lblCB

        Private designerPlaceholderDeclaration As Object

        'Protected Overridable Property btnDone As Button
        '    Get
        '        Return Me._btnDone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnDone IsNot Nothing) Then
        '            Dim cBLbl As wdw.CBLbl = Me
        '            Me._btnDone.remove_Click(New EventHandler(cBLbl, cBLbl.btnDone_Click))
        '        End If
        '        Me._btnDone = value
        '        If (Me._btnDone IsNot Nothing) Then
        '            Dim cBLbl1 As wdw.CBLbl = Me
        '            Me._btnDone.add_Click(New EventHandler(cBLbl1, cBLbl1.btnDone_Click))
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
        '            Dim cBLbl As wdw.CBLbl = Me
        '            Me._btnLoad.remove_Click(New EventHandler(cBLbl, cBLbl.btnLoad_Click))
        '        End If
        '        Me._btnLoad = value
        '        If (Me._btnLoad IsNot Nothing) Then
        '            Dim cBLbl1 As wdw.CBLbl = Me
        '            Me._btnLoad.add_Click(New EventHandler(cBLbl1, cBLbl1.btnLoad_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property Button2 As Button
        '    Get
        '        Return Me._Button2
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        Me._Button2 Is Nothing
        '        Me._Button2 = value
        '        Me._Button2 Is Nothing
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

        'Protected Overridable Property Form1 As HtmlForm
        '    Get
        '        Return Me._Form1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As HtmlForm)
        '        Me._Form1 Is Nothing
        '        Me._Form1 = value
        '        Me._Form1 Is Nothing
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

        'Protected Overridable Property HyperLink2 As HyperLink
        '    Get
        '        Return Me._HyperLink2
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As HyperLink)
        '        Me._HyperLink2 Is Nothing
        '        Me._HyperLink2 = value
        '        Me._HyperLink2 Is Nothing
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

        'Protected Overridable Property lblErrorMsg As Label
        '    Get
        '        Return Me._lblErrorMsg
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblErrorMsg Is Nothing
        '        Me._lblErrorMsg = value
        '        Me._lblErrorMsg Is Nothing
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim cBLbl1 As CBLbl = Me
            'MyBase.add_Init(New EventHandler(cBLbl1, cBLbl1.Page_Init))
            Dim cBLbl2 As CBLbl = Me
            'MyBase.add_Load(New EventHandler(cBLbl2, cBLbl2.Page_Load))
            Me.crystalUtil1 = New CrystalUtil()
            Me.crReportDocument = New lblCB()
        End Sub

        Private Sub btnDone_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDone.Click
            Dim item As String
            Dim dateTime As System.DateTime
            Dim dateTime1 As System.DateTime
            Dim num As Integer
            Dim str As String
            Dim dateTime2 As System.DateTime
            Dim dateTime3 As System.DateTime
            Dim num1 As Integer
            Dim str1 As String = "<script language=""javascript"">"
            Dim [operator] As String = MyBase.[Operator].userId
            Dim operator1 As String = MyBase.[Operator].userId
            Dim item1 As String = Me.Page().Request().Item("CB_Method")
            If (StringType.StrCmp(item1.Substring(0, 2), "PC", False) <> 0) Then
                str1 = String.Concat(str1, "window.opener.", Me.Page().GetPostBackEventReference(Me.Page()), ";window.close();")
                str1 = String.Concat(str1, "</script>")
                Me.Page().RegisterClientScriptBlock("", str1)
                Return
            End If
            dateTime = IIf(Strings.Len(Me.Page().Request().Item("From_Date")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("From_Date")))
            dateTime2 = IIf(Strings.Len(Me.Page().Request().Item("To_Date")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("To_Date")))
            num = IIf(Strings.Len(Me.Page().Request().Item("From_Zip")) <= 0, IntegerType.FromString("0"), IntegerType.FromString(Me.Page().Request().Item("From_Zip")))
            num1 = IIf(Strings.Len(Me.Page().Request().Item("To_Zip")) = 0, IntegerType.FromString("0"), IntegerType.FromString(Me.Page().Request().Item("To_Zip")))
            If (Strings.Len(Me.Page().Request().Item("Last_Name")) <= 0) Then
                str = ""
            Else
                str = Me.Page().Request().Item("Last_Name")
                str = str.Replace("..", "%")
            End If
            If (Strings.Len(Me.Page().Request().Item("Addr1")) <= 0) Then
                item = ""
            Else
                item = Me.Page().Request().Item("Addr1")
                item = item.Replace("..", "%")
            End If
            dateTime1 = If(Strings.Len(Me.Page().Request().Item("From_Start")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("From_Start")))
            dateTime3 = If(Strings.Len(Me.Page().Request().Item("To_Start")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("To_Start")))
            Dim messageHelper As SystemFramework.MessageHelper = UCCCallback.createChildRecords(item1, dateTime, dateTime2, StringType.FromInteger(num), StringType.FromInteger(num1), str, item, [operator], operator1, dateTime1, dateTime3)
            If (Not messageHelper.status) Then
                Me.lblErrorMsg.Text = (messageHelper.messageText)
            Else
                str1 = String.Concat(str1, "window.opener.", Me.Page().GetPostBackEventReference(Me.Page()), ";window.close();")
                str1 = String.Concat(str1, "</script>")
                Me.Page().RegisterClientScriptBlock("", str1)
            End If
        End Sub

        Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
            Dim str As String
            Dim dateTime As System.DateTime
            Dim num As Integer
            Dim str1 As String
            Dim dateTime1 As System.DateTime
            Dim num1 As Integer
            Dim excelFormatOption As ExcelFormatOptions = New ExcelFormatOptions()
            Dim pdfRtfWordFormatOption As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
            Dim callbackCommission As CallbackCommission = New CallbackCommission()
            Dim str2 As String = "Label.rtf"
            Dim item As String = Me.Page().Request().Item("CB_Method")
            dateTime = If(Strings.Len(Me.Page().Request().Item("From_Date")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("From_Date")))
            dateTime1 = If(Strings.Len(Me.Page().Request().Item("To_Date")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("To_Date")))
            num = If(Strings.Len(Me.Page().Request().Item("From_Zip")) <= 0, IntegerType.FromString("0"), IntegerType.FromString(Me.Page().Request().Item("From_Zip")))
            num1 = If(Strings.Len(Me.Page().Request().Item("To_Zip")) = 0, IntegerType.FromString("0"), IntegerType.FromString(Me.Page().Request().Item("To_Zip")))
            str1 = If(Strings.Len(Me.Page().Request().Item("Last_Name")) <= 0, "", Me.Page().Request().Item("Last_Name"))
            str = If(Strings.Len(Me.Page().Request().Item("Addr1")) <= 0, "", Me.Page().Request().Item("Addr1"))
            Dim dateTime2 As System.DateTime = If(Strings.Len(Me.Page().Request().Item("From_Start")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("From_Start")))
            Dim dateTime3 As System.DateTime = If(Strings.Len(Me.Page().Request().Item("To_Start")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("To_Start")))
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue2 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue3 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue3 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue4 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue4 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue5 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue5 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue6 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue6 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue7 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue7 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue8 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue8 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue2.Value = (item)
            parameterDiscreteValue1.Value = (dateTime1)
            parameterDiscreteValue.Value = (dateTime)
            parameterDiscreteValue3.Value = (num)
            parameterDiscreteValue4.Value = (num1)
            parameterDiscreteValue5.Value = (str1.Replace("..", "*"))
            parameterDiscreteValue6.Value = (str.Replace("..", "*"))
            parameterValue1.Add(parameterDiscreteValue1)
            parameterValue2.Add(parameterDiscreteValue2)
            parameterValue.Add(parameterDiscreteValue)
            parameterValue4.Add(parameterDiscreteValue4)
            parameterValue3.Add(parameterDiscreteValue3)
            parameterValue4.Add(parameterDiscreteValue4)
            parameterValue3.Add(parameterDiscreteValue3)
            parameterValue5.Add(parameterDiscreteValue5)
            parameterValue6.Add(parameterDiscreteValue6)
            parameterValue7.Add(parameterDiscreteValue7)
            parameterValue8.Add(parameterDiscreteValue8)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("CBMethod").ApplyCurrentValues(parameterValue2)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToZip").ApplyCurrentValues(parameterValue4)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromZip").ApplyCurrentValues(parameterValue3)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("LName").ApplyCurrentValues(parameterValue5)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Addr1").ApplyCurrentValues(parameterValue6)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromStart").ApplyCurrentValues(parameterValue7)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToStart").ApplyCurrentValues(parameterValue8)
            pdfRtfWordFormatOption.UsePageRange = False
            Me.crReportDocument.ExportOptions().ExportFormatType = 2
            Me.crReportDocument.ExportOptions().FormatOptions = pdfRtfWordFormatOption
            Me.crReportDocument.ExportOptions().ExportDestinationType = 1

            'If (StringType.StrCmp(WDWConfiguration.ExecutionEnvironment, "PROD", False) <> 0) Then
            '    diskFileDestinationOption.DiskFileName = (String.Concat(WDWConfiguration.DemoPath, str2))
            '    Me.HyperLink2.NavigateUrl = (String.Concat(WDWConfiguration.DemoURL, str2))
            'Else
            '    diskFileDestinationOption.DiskFileName = (String.Concat(WDWConfiguration.ProdPath, str2))
            '    Me.HyperLink2.NavigateUrl = (String.Concat(WDWConfiguration.ProdURL, str2))
            'End If

            'Me.HyperLink2.Target = ("_blank")
            'Dim diskFileDestinationOption As DiskFileDestinationOptions = New DiskFileDestinationOptions()
            'Me.crReportDocument.ExportOptions().DestinationOptions = diskFileDestinationOption
            'Me.crReportDocument.Export()
            'Me.HyperLink2.Visible = (True)
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim str As String
            Dim dateTime As System.DateTime
            Dim num As Integer
            Dim str1 As String
            Dim dateTime1 As System.DateTime
            Dim num1 As Integer
            Dim item As String = Me.Page().Request().Item("CB_Method")
            Me.lblErrorMsg.Text = ("")
            dateTime = If(Strings.Len(Me.Page().Request().Item("From_Date")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("From_Date")))
            dateTime1 = If(Strings.Len(Me.Page().Request().Item("To_Date")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("To_Date")))
            num = If(Strings.Len(Me.Page().Request().Item("From_Zip")) <= 0, IntegerType.FromString("0"), IntegerType.FromString(Me.Page().Request().Item("From_Zip")))
            num1 = If(Strings.Len(Me.Page().Request().Item("To_Zip")) = 0, IntegerType.FromString("0"), IntegerType.FromString(Me.Page().Request().Item("To_Zip")))
            str1 = If(Strings.Len(Me.Page().Request().Item("Last_Name")) <= 0, "", Me.Page().Request().Item("Last_Name"))
            str = If(Strings.Len(Me.Page().Request().Item("Addr1")) <= 0, "", Me.Page().Request().Item("Addr1"))
            Dim dateTime2 As System.DateTime = If(Strings.Len(Me.Page().Request().Item("From_Start")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("From_Start")))
            Dim dateTime3 As System.DateTime = If(Strings.Len(Me.Page().Request().Item("To_Start")) <= 0, DateType.FromString("01/01/1900"), DateType.FromString(Me.Page().Request().Item("To_Start")))
            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue2 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue3 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue3 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue4 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue4 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue5 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue5 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue6 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue6 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue7 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue7 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue8 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue8 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue2.Value = (item)
            parameterDiscreteValue1.Value = (dateTime1)
            parameterDiscreteValue.Value = (dateTime)
            parameterDiscreteValue3.Value = (num)
            parameterDiscreteValue4.Value = (num1)
            parameterDiscreteValue5.Value = (str1.Replace("..", "*"))
            parameterDiscreteValue6.Value = (str.Replace("..", "*"))
            parameterValue1.Add(parameterDiscreteValue1)
            parameterValue2.Add(parameterDiscreteValue2)
            parameterValue.Add(parameterDiscreteValue)
            parameterValue4.Add(parameterDiscreteValue4)
            parameterValue3.Add(parameterDiscreteValue3)
            parameterValue4.Add(parameterDiscreteValue4)
            parameterValue3.Add(parameterDiscreteValue3)
            parameterValue5.Add(parameterDiscreteValue5)
            parameterValue6.Add(parameterDiscreteValue6)
            parameterValue7.Add(parameterDiscreteValue7)
            parameterValue8.Add(parameterDiscreteValue8)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("CBMethod").ApplyCurrentValues(parameterValue2)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToDate").ApplyCurrentValues(parameterValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromDate").ApplyCurrentValues(parameterValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToZip").ApplyCurrentValues(parameterValue4)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromZip").ApplyCurrentValues(parameterValue3)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("LName").ApplyCurrentValues(parameterValue5)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Addr1").ApplyCurrentValues(parameterValue6)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("FromStart").ApplyCurrentValues(parameterValue7)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("ToStart").ApplyCurrentValues(parameterValue8)
            Me.CrystalReportViewer1.ReportSource = (Me.crReportDocument)
            Me.CrystalReportViewer1.Visible = (True)
        End Sub
    End Class
End Namespace