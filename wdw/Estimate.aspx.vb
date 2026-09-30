Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework
Imports Strings = Microsoft.VisualBasic.Strings

Namespace wdw
    Public Class Estimate
        Inherits PageBase

        Private estimateDataSet1 As DataSet

        Private rda As SqlDataAdapter

        Private rda2 As SqlDataAdapter

        Private blnDeleteAll As Object

        Private iHeader As Integer

        Private dcTotal As Decimal

        Private ctr As Integer

        Public Sub New()
            MyBase.New()
            Dim estimate1 As Estimate = Me
            Dim estimate2 As Estimate = Me

            Me.estimateDataSet1 = New DataSet("Estimate")
            Me.rda = New SqlDataAdapter()
            Me.rda2 = New SqlDataAdapter()
            Me.blnDeleteAll = False
            Me.ctr = 0
        End Sub

        Private Sub AssignDataSource()
            Dim num As Integer = 0
            If (StringType.StrCmp(Me.txtBidHeader.Text(), "", False) <> 0) Then
                Me.iHeader = IntegerType.FromString(Me.txtBidHeader.Text())
            Else
                Me.iHeader = 0
            End If
            If (Me.iHeader <> 0) Then
                Me.rda = UCCEstimate.getAllParentEstimateByBid(Me.iHeader)
                Me.rda2 = UCCEstimate.getAllChildEstimateByBid(Me.iHeader)
            Else
                Me.rda = UCCEstimate.getAllParentEstimate()
                Me.rda2 = UCCEstimate.getAllChildEstimate()
            End If
            Me.rda.Fill(Me.estimateDataSet1, "Primary")
            Me.rda2.Fill(Me.estimateDataSet1, "Secondary")
            If (Me.ctr < 1) Then
                Me.estimateDataSet1.Relations().Add("Primary", Me.estimateDataSet1.Tables().Item("Primary").Columns().Item("ServOff_ID"), Me.estimateDataSet1.Tables().Item("Secondary").Columns().Item("ParentServOff_ID"))
            End If
            Me.UG1.DataSource = (Me.estimateDataSet1.Tables().Item("Primary").DefaultView())
            Me.UG1.DataBind()
            If (StringType.StrCmp(Me.txtBidHeader.Text(), "", False) <> 0) Then
                If (StringType.StrCmp(Me.txtBidHeader.Text(), "0", False) = 0) Then
                    Me.dcTotal = Decimal.Zero
                    Me.ViewState().Item("dcTotal") = Me.dcTotal
                Else
                    num = Me.CalculateTotalBeforeDisc(Me.CalculateSubtotal())
                    Dim headerAmts As SqlDataReader = UCCEstimate.getHeaderAmts(Convert.ToInt32(DecimalType.FromString(Me.txtBidHeader.Text())))
                    headerAmts.Read()
                    Dim num1 As Decimal = DecimalType.FromObject(headerAmts.Item("Tax_Amt"))
                    num1 = DecimalType.FromString(Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(headerAmts.Item("Tax_Amt")), "#.00"))
                    Me.txtOverride.Text = (StringType.FromObject(headerAmts.Item("Override_Amt")))
                    Me.SetTax(num1)
                    Me.dcTotal = Me.CalculateTotal(num)
                    Me.ViewState().Item("dcTotal") = Me.dcTotal
                End If
            End If
            Me.DisableOtherRow()
            Me.DisableTotals()
            If (Not (StringType.StrCmp(Me.txtBidHeader.Text(), "", False) = 0 Or StringType.StrCmp(Me.txtBidHeader.Text(), "0", False) = 0)) Then
                Me.btnSelect.Enabled = (True)
                Me.BtnDelete.Enabled = (True)
            Else
                Me.btnSelect.Enabled = (False)
                Me.BtnDelete.Enabled = (False)
            End If
        End Sub

        Private Sub btnCollapse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCollapse.Click
            Me.UG1.ExpandAll(False)
            Me.btnCollapse.Enabled = (False)
            Me.btnExpand.Enabled = (True)
        End Sub

        Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDelete.Click
            If (StringType.StrCmp(Me.txtBidHeader.Text(), "0", False) <> 0 And StringType.StrCmp(Me.txtBidHeader.Text(), "", False) <> 0) Then
                Me.blnDeleteAll = True
                Me.txtOverride.Text = ("")
                Dim messageHelper As SystemFramework.MessageHelper = UCCEstimate.removeEstimate(IntegerType.FromString(Me.txtBidHeader.Text()))
                If (Not messageHelper.status) Then
                    Me.lblErrorMsg.Text = (messageHelper.messageText)
                End If
                Me.txtBidHeader.Text = (StringType.FromInteger(0))
                Me.AssignDataSource()
                Me.txttotal.Text = ("0")
            End If
        End Sub

        Private Sub btnExpand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExpand.Click
            Me.UG1.ExpandAll(True)
            Me.btnExpand.Enabled = (False)
            Me.btnCollapse.Enabled = (True)
        End Sub

        Private Sub btnSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelect.Click
            If (Not (StringType.StrCmp(Me.txtBidHeader.Text(), "0", False) <> 0 And StringType.StrCmp(Me.txtBidHeader.Text(), "", False) <> 0)) Then
                Me.lblErrorMsg.Text = ("You cannot have a zero estimate amt associated with a job.")
            Else
                Dim jobDescription As SqlDataReader = UCCEstimate.getJobDescription(IntegerType.FromString(Me.txtBidHeader.Text()))
                jobDescription.Read()
                Dim str1 As String = StringType.FromObject(jobDescription.Item("Description"))
                If CDec(Func.CastToStr(txtOverride.Text, "0")) > 0 Then
                    'If (StringType.StrCmp(Me.txtOverride.Text(), "", False) <> 0 And StringType.StrCmp(Me.txtOverride.Text(), "0", False) <> 0) Then
                    Me.dcTotal = DecimalType.FromString(Me.txtOverride.Text())
                End If
                Me.txttotal.Text = Func.CastToStr(Me.dcTotal)

                Dim str As String = "<script language=""javascript""> window.opener.setEstimate(" & Me.txtBidHeader.Text & ", " & Func.CastToStr(Me.dcTotal) & ", '" & str1 & "');window.close(); </script>"

                Me.Page().RegisterClientScriptBlock("", str)
            End If
        End Sub

        Private Function CalculateSubtotal() As Integer
            Dim current As Infragistics.WebUI.UltraWebGrid.UltraGridRow
            Dim index As Integer = 0
            Dim num As Decimal = New Decimal()
            Dim enumerator As IEnumerator = Nothing
            Dim enumerator1 As IEnumerator = Nothing
            Dim enumerator2 As IEnumerator = Nothing
            Dim count As Object = Me.UG1.Columns.Count() - 1
            Try
                enumerator2 = Me.UG1.Rows.GetEnumerator()
                While enumerator2.MoveNext()
                    current = DirectCast(enumerator2.Current(), Infragistics.WebUI.UltraWebGrid.UltraGridRow)
                    If (StringType.StrCmp(current.Cells.FromKey("servOff_Name").Value.ToString(), "***Total Windows", False) <> 0) Then
                        Continue While
                    End If
                    index = current.Index
                End While
            Finally
                If (TypeOf enumerator2 Is IDisposable) Then
                    DirectCast(enumerator2, IDisposable).Dispose()
                End If
            End Try
            Try
                enumerator1 = Me.UG1.Rows.GetEnumerator()
                While enumerator1.MoveNext()
                    current = DirectCast(enumerator1.Current(), Infragistics.WebUI.UltraWebGrid.UltraGridRow)
                    If (current.Index < index) Then
                        num = Decimal.Add(num, DecimalType.FromString(current.Cells.FromKey("Total").Value.ToString()))
                        If (current.HasChildRows) Then
                            Try
                                enumerator = current.Rows.GetEnumerator()
                                While enumerator.MoveNext()
                                    Dim ultraGridRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = DirectCast(enumerator.Current(), Infragistics.WebUI.UltraWebGrid.UltraGridRow)
                                    num = Decimal.Add(num, DecimalType.FromString(ultraGridRow.Cells.FromKey("Total").Value.ToString()))
                                End While
                            Finally
                                If (TypeOf enumerator Is IDisposable) Then
                                    DirectCast(enumerator, IDisposable).Dispose()
                                End If
                            End Try
                        End If
                    End If
                    If (current.Index <> index) Then
                        Continue While
                    End If
                    current.Cells.FromKey("Total").Value = StringType.FromDecimal(num)
                    Dim count1 As Integer = current.Cells.Count() - 1
                    For i As Integer = 0 To count1 Step 1
                        current.Cells(i).AllowEditing = AllowEditing.No
                    Next

                End While
            Finally
                If (TypeOf enumerator1 Is IDisposable) Then
                    DirectCast(enumerator1, IDisposable).Dispose()
                End If
            End Try
            Return index
        End Function

        Private Function CalculateTotal(ByVal iRow As Object) As Decimal
            Dim num As Decimal = New Decimal()
            Dim index As Integer = 0
            Dim enumerator As IEnumerator = Nothing
            Dim count As Object = Me.UG1.Columns.Count() - 1
            Try
                enumerator = Me.UG1.Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As UltraGridRow = DirectCast(enumerator.Current(), UltraGridRow)
                    If (StringType.StrCmp(current.Cells.FromKey("servOff_Name").Value.ToString(), "***Total Cost", False) <> 0) Then
                        Continue While
                    End If
                    index = current.Index
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            If (ObjectType.ObjTst(Me.UG1.Rows.Count() - 1, index, False) >= 0) Then
                Dim obj As Object = index
                Dim num1 As Integer = index
                Dim num2 As Integer = IntegerType.FromObject(iRow)
                Do
                    num = Decimal.Add(num, DecimalType.FromString(Me.UG1.Rows(num2).Cells.FromKey("Total").Value.ToString()))
                    num2 = num2 + 1
                Loop While num2 <= num1
                Me.UG1.Rows(index).Cells.FromKey("Total").Value = StringType.FromDecimal(num)
                Dim count1 As Integer = Me.UG1.Rows(index).Cells.Count()
                Dim num3 As Integer = count1 - 1
                For i As Integer = 0 To num3 Step 1
                    Me.UG1.Rows(index).Cells(i).AllowEditing = AllowEditing.No
                Next

            End If
            Return num
        End Function

        Private Function CalculateTotalBeforeDisc(ByVal iRow As Object) As Integer
            Dim index As Integer = 0
            Dim num As Decimal = New Decimal()
            Dim enumerator As IEnumerator = Nothing
            Dim enumerator1 As IEnumerator = Nothing
            Dim count As Object = Me.UG1.Columns.Count() - 1
            Try
                enumerator1 = Me.UG1.Rows.GetEnumerator()
                While enumerator1.MoveNext()
                    Dim current As Infragistics.WebUI.UltraWebGrid.UltraGridRow = DirectCast(enumerator1.Current(), Infragistics.WebUI.UltraWebGrid.UltraGridRow)
                    If (StringType.StrCmp(current.Cells.FromKey("servOff_Name").Value.ToString(), "***Total Before any Disc.", False) <> 0) Then
                        Continue While
                    End If
                    index = current.Index
                End While
            Finally
                If (TypeOf enumerator1 Is IDisposable) Then
                    DirectCast(enumerator1, IDisposable).Dispose()
                End If
            End Try
            If (ObjectType.ObjTst(Me.UG1.Rows.Count() - 1, index, False) > 0) Then
                Dim obj As Object = index
                Dim num1 As Integer = index
                Dim num2 As Integer = IntegerType.FromObject(iRow)
                Do
                    num = Decimal.Add(num, DecimalType.FromString(Me.UG1.Rows(num2).Cells.FromKey("Total").Value.ToString()))
                    If (Me.UG1.Rows(num2).HasChildRows) Then
                        Try
                            enumerator = Me.UG1.Rows(num2).Rows.GetEnumerator()
                            While enumerator.MoveNext()
                                Dim ultraGridRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = DirectCast(enumerator.Current(), Infragistics.WebUI.UltraWebGrid.UltraGridRow)
                                num = Decimal.Add(num, DecimalType.FromString(ultraGridRow.Cells.FromKey("Total").Value.ToString()))
                            End While
                        Finally
                            If (TypeOf enumerator Is IDisposable) Then
                                DirectCast(enumerator, IDisposable).Dispose()
                            End If
                        End Try
                    End If
                    num2 = num2 + 1
                Loop While num2 <= num1
                Me.UG1.Rows(index).Cells.FromKey("Total").Value = StringType.FromDecimal(num)
                Dim count1 As Integer = Me.UG1.Rows(index).Cells.Count() - 1
                Dim num3 As Integer = count1
                For i As Integer = 0 To num3 Step 1
                    Me.UG1.Rows(index).Cells(i).AllowEditing = AllowEditing.No
                Next

            End If
            Return index
        End Function

        Private Sub DisableOtherRow()
            Dim enumerator As IEnumerator = Nothing
            Try
                enumerator = Me.UG1.Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As UltraGridRow = DirectCast(enumerator.Current(), UltraGridRow)
                    If (IntegerType.FromString(current.Cells.FromKey("Other").Value.ToString()) <= 0) Then
                        Continue While
                    End If
                    Dim index As Integer = current.Cells.FromKey("Other").Column.Index
                    Dim num As Integer = index - 2
                    For i As Integer = 0 To num Step 1
                        current.Cells(i).AllowEditing = AllowEditing.No
                    Next

                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End Sub

        Private Sub DisableTotals()
            Me.UG1.Columns.FromKey("Total").AllowUpdate = AllowUpdate.No
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("EstimateState")
        End Function

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim uCCClient As BusinessService.UCCClient = New BusinessService.UCCClient()
            If (Me.IsPostBack()) Then
                Me.dcTotal = DecimalType.FromObject(Me.ViewState().Item("dcTotal"))
                Me.txttotal.Text = (StringType.FromDecimal(Me.dcTotal))
            Else
                Dim item As String = Me.Page().Request().Item("Job_ID")
                Dim str As String = Me.Page().Request().Item("Bid_ID")
                Me.txtJob.Text = (item)
                If (str.Length() <> 0) Then
                    Me.txtBidHeader.Text = (str)
                Else
                    Me.txtBidHeader.Text = ("")
                End If
                Me.AssignDataSource()
                Me.UG1.DisplayLayout.ActiveRow = Me.UG1.Rows(0)
                Me.txttotal.Text = ("0")
            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("EstimateState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub

        Private Sub SetTax(ByVal dTax As Decimal)
            Dim enumerator As IEnumerator = Nothing
            Try
                enumerator = Me.UG1.Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As UltraGridRow = DirectCast(enumerator.Current(), UltraGridRow)
                    If (StringType.StrCmp(current.Cells.FromKey("servOff_Name").Value.ToString(), "***Tax", False) <> 0) Then
                        Continue While
                    End If
                    Dim index As Integer = current.Index
                    Me.UG1.Rows(index).Cells.FromKey("Total").Value = StringType.FromDecimal(dTax)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
        End Sub

        Private Sub txtOverride_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOverride.TextChanged
            If (Microsoft.VisualBasic.Strings.Len(Me.txtOverride.Text()) = 0) Then
                Me.txtOverride.Text = ("0")
            End If
            If (IntegerType.FromString(Me.txtBidHeader.Text()) > 0) Then
                UCCEstimate.updateOverride(IntegerType.FromString(Me.txtBidHeader.Text()), DecimalType.FromString(Me.txtOverride.Text()), MyBase.[Operator].userId)
            End If
            Me.txttotal.Text = (Me.txtOverride.Text())
        End Sub

        Private Sub UG1_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UG1.InitializeLayout
            Me.UG1.Bands(1).Columns.FromKey("servoff_id").HeaderText = "ID"
            Me.UG1.Bands(0).Columns.FromKey("servoff_id").HeaderText = "ID"
            Me.UG1.Bands(0).DataKeyField = Me.estimateDataSet1.Tables().Item("Primary").Columns().Item(0).ColumnName()
            Me.UG1.Bands(1).DataKeyField = Me.estimateDataSet1.Tables().Item("Secondary").Columns().Item(1).ColumnName()
            Me.UG1.Bands(0).Columns.FromKey("servOff_Name").HeaderText = "Name"
            Me.UG1.Bands(1).Columns.FromKey("servOff_Name").HeaderText = "Name"
            Dim ultraGridColumn As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("servOff_Name")
            Dim unit As System.Web.UI.WebControls.Unit = New System.Web.UI.WebControls.Unit("200px")
            ultraGridColumn.Width = unit
            Dim ultraGridColumn1 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("servOff_Name")
            unit = New System.Web.UI.WebControls.Unit("156px")
            ultraGridColumn1.Width = unit
            Dim ultraGridColumn2 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("servoff_id")
            unit = New System.Web.UI.WebControls.Unit("60px")
            ultraGridColumn2.Width = unit
            Dim ultraGridColumn3 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("servoff_id")
            unit = New System.Web.UI.WebControls.Unit("60px")
            ultraGridColumn3.Width = unit
            Dim ultraGridColumn4 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("InOut")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn4.Width = unit
            Dim ultraGridColumn5 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("InOut")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn5.Width = unit
            Dim ultraGridColumn6 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("OutOnly")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn6.Width = unit
            Dim ultraGridColumn7 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("OutOnly")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn7.Width = unit
            Dim ultraGridColumn8 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("InOnly")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn8.Width = unit
            Dim ultraGridColumn9 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("InOnly")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn9.Width = unit
            Dim ultraGridColumn10 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnSameSide")
            unit = New System.Web.UI.WebControls.Unit("115px")
            ultraGridColumn10.Width = unit
            Dim ultraGridColumn11 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnSameSide")
            unit = New System.Web.UI.WebControls.Unit("115px")
            ultraGridColumn11.Width = unit
            Dim ultraGridColumn12 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnBothSides")
            unit = New System.Web.UI.WebControls.Unit("115px")
            ultraGridColumn12.Width = unit
            Dim ultraGridColumn13 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnBothSides")
            unit = New System.Web.UI.WebControls.Unit("115px")
            ultraGridColumn13.Width = unit
            Dim ultraGridColumn14 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Scrape2SidesClnBothSides")
            unit = New System.Web.UI.WebControls.Unit("115px")
            ultraGridColumn14.Width = unit
            Dim ultraGridColumn15 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Scrape2SidesClnBothSides")
            unit = New System.Web.UI.WebControls.Unit("115px")
            ultraGridColumn15.Width = unit
            Dim ultraGridColumn16 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Other")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn16.Width = unit
            Dim ultraGridColumn17 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Other")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn17.Width = unit
            Me.UG1.Bands(1).Columns.FromKey("parentservoff_id").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("servoff_id").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("servoff_id").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("grouping").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("grouping").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("position").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("position").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("Total").Format = "#.00"
            Me.UG1.Bands(1).Columns.FromKey("Total").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("servOff_Name").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(0).Columns.FromKey("OutOnly").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("OutOnly").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnSameSide").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnSameSide").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(0).Columns.FromKey("Scrape2SidesClnBothSides").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("Scrape2SidesClnBothSides").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(0).Columns.FromKey("Total").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("Total").CellStyle.BackColor = (Color.Gainsboro())
            Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnSameSide").HeaderText = "Scrp 1 Sd<br>Cln Same Sd"
            Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnSameSide").HeaderText = "Scrp 1 Sd<br>Cln Same Sd"
            Me.UG1.Bands(1).Columns.FromKey("Scrape2SidesClnBothSides").HeaderText = "Scrp 2 Sds<br>Cln Both Sds"
            Me.UG1.Bands(0).Columns.FromKey("Scrape2SidesClnBothSides").HeaderText = "Scrp 2 Sds<br>Cln Both Sds"
            Me.UG1.Bands(1).Columns.FromKey("Scrape1SideClnBothSides").HeaderText = "Scrp 1 Sd<br>Cln Both Sds"
            Me.UG1.Bands(0).Columns.FromKey("Scrape1SideClnBothSides").HeaderText = "Scrp 1 Sd<br>Cln Both Sds"
            Me.UG1.Bands(0).Columns.FromKey("P1").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("P1").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("P2").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("P2").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("P3").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("P3").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("P4").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("P4").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("P5").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("P5").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("P6").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("P6").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("P7").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("P7").Hidden = True
            Me.UG1.Bands(1).ColHeadersVisible = ShowMarginInfo.No
        End Sub

        Private Sub UG1_PageIndexChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.PageEventArgs) Handles UG1.PageIndexChanged
            Me.AssignDataSource()
        End Sub

        Private Sub UG1_UpdateCellBatch(ByVal sender As Object, ByVal e As CellEventArgs) Handles UG1.UpdateCellBatch
            Dim num As Integer
            Me.lblErrorMsg.Text = ("")
            If (ObjectType.ObjTst(Me.blnDeleteAll, False, False) = 0) Then
                Dim dateTime As System.DateTime = New System.DateTime()
                If (StringType.StrCmp(Me.txtBidHeader.Text(), "", False) <> 0) Then
                    Me.iHeader = IntegerType.FromString(Me.txtBidHeader.Text())
                Else
                    Me.iHeader = 0
                End If
                Dim str As String = StringType.FromObject(e.Cell.Row.Cells.FromKey("servOff_Name").Value)
                Dim baseColumnName As String = e.Cell.Column.BaseColumnName
                num = If(Not e.Cell.Row.HasParent, IntegerType.FromObject(e.Cell.Row.DataKey), IntegerType.FromObject(e.Cell.Row.DataKey))
                Dim num1 As Decimal = DecimalType.FromObject(e.Cell.Row.Cells(e.Cell.Column.Index - 1).Value)
                Dim num2 As Decimal = DecimalType.FromObject(e.Cell.Value)
                Dim index As Integer = e.Cell.Column.Index
                IntegerType.FromString(Me.txtJob.Text())
                Dim index1 As Integer = e.Cell.Row.Index
                If (Decimal.Compare(num1, Decimal.Zero) <> 0) Then
                    If (ObjectType.ObjTst(num2, e.Data, False) <> 0) Then
                        If (StringType.StrCmp(Me.txtBidHeader.Text(), "", False) = 0) Then
                            Me.txtBidHeader.Text = ("0")
                        End If
                        If (Strings.Len(Me.txtOverride.Text()) = 0) Then
                            Me.txtOverride.Text = ("0")
                        End If
                        If (IntegerType.FromString(Me.txtBidHeader.Text()) <> 0) Then
                            Dim messageHelper As SystemFramework.MessageHelper = UCCEstimate.updateEstimate(Me.iHeader, DecimalType.FromString(Me.txtOverride.Text()), baseColumnName, num, num1, num2, MyBase.[Operator].userId)
                            If (Not messageHelper.status) Then
                                Me.lblErrorMsg.Text = (messageHelper.messageText)
                            End If
                        Else
                            Dim num3 As Integer = UCCEstimate.createEstimate(Me.iHeader, DecimalType.FromString(Me.txtOverride.Text()), baseColumnName, num, num1, num2, MyBase.[Operator].userId, MyBase.[Operator].userId)
                            Me.txtBidHeader.Text = (StringType.FromInteger(num3))
                        End If
                    End If
                    Me.ctr = 0
                    If (Not (StringType.StrCmp(Me.txtBidHeader.Text(), "", False) = 0 Or StringType.StrCmp(Me.txtBidHeader.Text(), "0", False) = 0)) Then
                        Me.btnSelect.Enabled = (True)
                        Me.BtnDelete.Enabled = (True)
                    Else
                        Me.btnSelect.Enabled = (False)
                        Me.BtnDelete.Enabled = (False)
                    End If
                Else
                    Me.lblErrorMsg.Text = (String.Concat("There is no associated price for the following service ", str, "!"))
                End If
            End If
        End Sub

        Private Sub UG1_UpdateGrid(ByVal sender As Object, ByVal e As UpdateEventArgs) Handles UG1.UpdateGrid
            Me.AssignDataSource()
        End Sub
    End Class
End Namespace