Imports Common
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Web
Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace wdw
    Public Class Invoice
        Inherits PageBase
        Private crystalUtil1 As CrystalUtil
        Private crReportDocument As WDWInvoice

        Public Sub New()
            MyBase.New()
            Dim invoice1 As Invoice = Me
            Me.crystalUtil1 = New CrystalUtil()
            Me.crReportDocument = New WDWInvoice()
        End Sub

        Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
            Me.Build_Report()
        End Sub

        Private Sub Build_Report()
            Me.CrystalReportViewer1.HasPrintButton = True
            Me.CrystalReportViewer1.HasToggleParameterPanelButton = False
            Me.CrystalReportViewer1.HasZoomFactorList = False
            Me.CrystalReportViewer1.HasSearchButton = False
            Me.CrystalReportViewer1.HasExportButton = True

            Dim parameterValue As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue1 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue1 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue2 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue2 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()
            Dim parameterValue3 As ParameterValues = New ParameterValues()
            Dim parameterDiscreteValue3 As CrystalDecisions.[Shared].ParameterDiscreteValue = New CrystalDecisions.[Shared].ParameterDiscreteValue()

            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            parameterDiscreteValue.Value = (Me.txtPhone.Text())
            parameterValue.Add(parameterDiscreteValue)
            parameterDiscreteValue1.Value = (Me.txtFax.Text())
            parameterValue1.Add(parameterDiscreteValue1)
            parameterDiscreteValue2.Value = (Me.txtWDWAddrLine1.Text())
            parameterValue2.Add(parameterDiscreteValue2)
            parameterDiscreteValue3.Value = (Me.txtWDWAddrLine2.Text())
            parameterValue3.Add(parameterDiscreteValue3)

            Me.crReportDocument.DataDefinition().ParameterFields().Item("Phone").ApplyCurrentValues(parameterValue)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("Fax").ApplyCurrentValues(parameterValue1)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("WDWAddrLine1").ApplyCurrentValues(parameterValue2)
            Me.crReportDocument.DataDefinition().ParameterFields().Item("WDWAddrLine2").ApplyCurrentValues(parameterValue3)

            ' Get the selected invoices and date to include in the select
            Dim JobStr As String = Func.checkBoxListSelectedToStr_int(Me.chklstInvoices)
            Dim DateStr As String = CDate(Me.txtReleaseDate.Text).ToString("MM/dd/yyyy")
            Me.crReportDocument.RecordSelectionFormula = "{VW_WDW_WDWInv.CreateDateStr} = '" & DateStr & "' and {VW_WDW_WDWInv.Job} in [" & JobStr & "]"

            Me.CrystalReportViewer1.ReportSource = Me.crReportDocument
            CrystalUtil.CrystalReportFormatter(Me.CrystalReportViewer1)
        End Sub


        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                If CrystalReportViewer1.Visible Then Build_Report()
            Else
                ' Fill Form

                ' fill in form with defaults from database
                Dim CompanyID As Integer = MyBase.[Operator].company_ID
                Dim C As New BusinessService.Company
                Dim rdr As SqlClient.SqlDataReader = C.getCompany(CompanyID)

                rdr.Read()
                Me.txtFax.Text = rdr("InvoiceFax").ToString()
                Me.txtPhone.Text = rdr("InvoicePhone").ToString()
                Me.txtWDWAddrLine1.Text = rdr("InvoiceAddrLine1").ToString()
                Me.txtWDWAddrLine2.Text = rdr("InvoiceAddrLine2").ToString()
                rdr.Close()

                Dim sqlStr As String = "select format(max(cast(CreateDateStr as Date)), 'MM/dd/yyyy') as LastCreateDate FROM [VW_WDW_WDWInv]"

                ' Fill in the default date in the textbox to the max Invoice Release date - if none is found then use today's date (this shoudl never be the case)
                Dim r As Object = SqlHelper.ExecuteScalar(WDWConfiguration.ConnectionString, CommandType.Text, sqlStr)
                Dim MaxInvoiceDateStr As String = "n/a"
                If Not r Is Nothing Then
                    MaxInvoiceDateStr = r.ToString()
                    Me.txtReleaseDate.Text = r.ToString()
                Else
                    Me.txtReleaseDate.Text = Date.Now().ToString("MM/dd/yyyy")
                End If
                lblMaxDate.InnerText = MaxInvoiceDateStr

                FillForm()
            End If
        End Sub

        'Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
        '    Return Me.Session().Item("PageState")
        'End Function

        'Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
        '    Me.Session().Add("PageState", RuntimeHelpers.GetObjectValue(viewState))
        'End Sub

        Private Sub FillForm()
            Dim dateStr = CDate(Me.txtReleaseDate.Text).ToString("MM/dd/yyyy")
            Me.txtReleaseDate.Text = dateStr

            Dim sqlStr As String = "select Job, cast(Job as varchar(20)) + ': ' + Name + ' ($' + cast(Total as varchar(20)) + ') ' + ServiceDate + ' [' + Note + ']' as details from [VW_WDW_WDWInv] where CreateDateStr = '" & dateStr & "' order by [Name]"

            Dim r As SqlDataReader = SqlHelper.ExecuteReader(WDWConfiguration.ConnectionString, CommandType.Text, sqlStr)
            Me.chklstInvoices.DataSource = r
            Me.chklstInvoices.DataTextField = "details"
            Me.chklstInvoices.DataValueField = "Job"
            Me.chklstInvoices.DataBind()

            ' By default select them all
            For Each i As ListItem In chklstInvoices.Items
                i.Selected = True
            Next

        End Sub


        Protected Sub txtReleaseDate_TextChanged(sender As Object, e As EventArgs)
            CrystalReportViewer1.Visible = False
            FillForm()

        End Sub

        Protected Sub btnRefreshList_Click(sender As Object, e As EventArgs)
            CrystalReportViewer1.Visible = False
            FillForm()
        End Sub

        Protected Sub lnkSelectAll_Click(sender As Object, e As EventArgs)
            CrystalReportViewer1.Visible = False

            For Each i As ListItem In chklstInvoices.Items
                i.Selected = True
            Next

        End Sub

        Protected Sub lnkSelectNone_Click(sender As Object, e As EventArgs)
            CrystalReportViewer1.Visible = False

            For Each i As ListItem In chklstInvoices.Items
                i.Selected = False
            Next

        End Sub
    End Class
End Namespace