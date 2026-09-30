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
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class Closeout
        Inherits PageBase

        Private dcSubBillAmt As Decimal

        Private dcSubPayBasis As Decimal

        Private dcsubpayamt As Decimal

        Private dcsubtip As Decimal

        Private dcsubtax As Decimal

        Private dcsubtotalpay As Decimal

        Private dcsubpayrecd As Decimal

        Private iNetInv As Integer

        Private iSubtotal As Integer

        Private iOtherChrg As Integer

        Private ictr As Integer

        Private rda As SqlDataAdapter

        Private rda2 As SqlDataAdapter

        Private Primary As String

        Private Secondary As String

        Private coDataSet1 As DataSet

        Private blnAdd As Boolean

        Public Sub New()
            MyBase.New()
            Dim closeout1 As Closeout = Me
            'MyBase.add_Init(New EventHandler(closeout1, closeout1.Page_Init))
            Dim closeout2 As Closeout = Me
            'MyBase.add_Load(New EventHandler(closeout2, closeout2.Page_Load))
            Me.ictr = 0
            Me.rda = New SqlDataAdapter()
            Me.rda2 = New SqlDataAdapter()
            Me.Primary = "Primary"
            Me.Secondary = "Secondary"
            Me.coDataSet1 = New DataSet("COut")
            Me.blnAdd = False
        End Sub

        Private Sub AssignDataSource()
            If (rdNew.Checked AndAlso Func.CastToInt(txtCloseOutHeader.Text, 0) = 0) Then
                Me.rda = UCCCloseOut.getAllParentCloseOutBySub(Me.lstSub.SelectedItem().Text())
                Me.rda2 = UCCCloseOut.getAllChildCloseOutBySub("June")
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (Me.ictr < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Job"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Job"))
                End If
                Me.UG1.DataSource = (Me.coDataSet1.Tables().Item("Primary").DefaultView())
                Me.UG1.DataBind()
                Me.UG1.DisplayLayout.AllowUpdateDefault = AllowUpdate.Yes
                Me.UG1.Visible = (True)
                Me.iSubtotal = Me.GetRow("SubTotal")
                Me.iOtherChrg = Me.GetRow("Other Charges(Credits)")
                Me.iNetInv = Me.GetRow("NET INVOICE AMOUNT")
                Me.UG1.Rows(Me.iSubtotal).Cells.FromKey("Job").Value = Nothing
                Me.UG1.Rows(Me.iSubtotal).Cells.FromKey("Active").Value = Nothing
                Me.UG1.Rows(Me.iOtherChrg).Cells.FromKey("Job").Value = Nothing
                Me.UG1.Rows(Me.iOtherChrg).Cells.FromKey("Active").Value = Nothing
                Me.UG1.Rows(Me.iNetInv).Cells.FromKey("Job").Value = Nothing
                Me.UG1.Rows(Me.iNetInv).Cells.FromKey("Active").Value = Nothing
                Me.dcSubBillAmt = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Bill Amount"))
                Me.dcSubPayBasis = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Pay Basis"))
                Me.dcsubpayamt = New Decimal(Me.GetSubTotals(Me.iSubtotal, "PayAmount"))
                Me.dcsubtip = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Tip"))
                Me.dcsubtotalpay = New Decimal(Me.GetSubTotals(Me.iSubtotal, "TotalPay"))
                Me.dcsubtax = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Tax"))
                Me.dcsubpayrecd = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Pay Recd"))
                Me.dcSubBillAmt = New Decimal(Me.GetNetTotals(Me.iNetInv, "Bill Amount"))
                Me.dcSubPayBasis = New Decimal(Me.GetNetTotals(Me.iNetInv, "Pay Basis"))
                Me.dcsubpayamt = New Decimal(Me.GetNetTotals(Me.iNetInv, "PayAmount"))
                Me.dcsubtip = New Decimal(Me.GetNetTotals(Me.iNetInv, "Tip"))
                Me.dcsubtotalpay = New Decimal(Me.GetNetTotals(Me.iNetInv, "TotalPay"))
                Me.dcsubtax = New Decimal(Me.GetNetTotals(Me.iNetInv, "Tax"))
                Me.dcsubpayrecd = New Decimal(Me.GetNetTotals(Me.iNetInv, "Pay Recd"))
                Me.btnSubmit.Visible = (True)
                If (ObjectType.ObjTst(Me.UG1.Rows(Me.iSubtotal).Cells.FromKey("Last Name").Value, "SubTotal", False) = 0) Then
                    Me.UG1.Rows(Me.iSubtotal).Cells.FromKey("Start Date").Value = ""
                End If
                Me.iOtherChrg = Me.GetRow("Other Charges(Credits)")
                If (ObjectType.ObjTst(Me.UG1.Rows(Me.iOtherChrg).Cells.FromKey("Last Name").Value, "Other Charges(Credits)", False) = 0) Then
                    Me.UG1.Rows(Me.iOtherChrg).Cells.FromKey("Start Date").Value = ""
                End If
                If (ObjectType.ObjTst(Me.UG1.Rows(Me.iNetInv).Cells.FromKey("Last Name").Value, "NET INVOICE AMOUNT", False) = 0) Then
                    Me.UG1.Rows(Me.iNetInv).Cells.FromKey("Start Date").Value = ""
                End If
            End If
            If (Me.rdExist.Checked) Then
                Me.rda = UCCCloseOut.getExistingParentCOBySub(IntegerType.FromString(Microsoft.VisualBasic.Strings.Mid(Me.lstSubCo.SelectedValue(), 1, Microsoft.VisualBasic.Strings.InStr(Me.lstSubCo.SelectedValue(), "-", 0) - 1)))
                Me.rda.Fill(Me.coDataSet1, "Primary")
                Me.rda2 = UCCCloseOut.getExistingChildCOBySub(IntegerType.FromString(Microsoft.VisualBasic.Strings.Mid(Me.lstSubCo.SelectedValue(), 1, Microsoft.VisualBasic.Strings.InStr(Me.lstSubCo.SelectedValue(), "-", 0) - 1)))
                Me.rda2.Fill(Me.coDataSet1, "Secondary")
                If (Me.ictr < 1) Then
                    Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Job"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Job"))
                End If
                Me.UG1.DataSource = (Me.coDataSet1.Tables().Item("Primary").DefaultView())
                Me.UG1.DataBind()
                Me.UG1.DisplayLayout.AllowUpdateDefault = AllowUpdate.Yes
                Me.UG1.Visible = (True)
                Me.iSubtotal = Me.GetRow("SubTotal")
                Me.iOtherChrg = Me.GetRow("Other Charges(Credits)")
                Me.iNetInv = Me.GetRow("NET INVOICE AMOUNT")
                Me.UG1.Rows(Me.iSubtotal).Cells.FromKey("Job").Value = Nothing
                Me.UG1.Rows(Me.iSubtotal).Cells.FromKey("Active").Value = Nothing
                Me.UG1.Rows(Me.iOtherChrg).Cells.FromKey("Job").Value = Nothing
                Me.UG1.Rows(Me.iOtherChrg).Cells.FromKey("Active").Value = Nothing
                Me.UG1.Rows(Me.iNetInv).Cells.FromKey("Job").Value = Nothing
                Me.UG1.Rows(Me.iNetInv).Cells.FromKey("Active").Value = Nothing
                Me.dcSubBillAmt = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Bill Amount"))
                Me.dcSubPayBasis = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Pay Basis"))
                Me.dcsubpayamt = New Decimal(Me.GetSubTotals(Me.iSubtotal, "PayAmount"))
                Me.dcsubtip = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Tip"))
                Me.dcsubtax = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Tax"))
                Me.dcsubtotalpay = New Decimal(Me.GetSubTotals(Me.iSubtotal, "TotalPay"))
                Me.dcsubpayrecd = New Decimal(Me.GetSubTotals(Me.iSubtotal, "Pay Recd"))
                Me.dcSubBillAmt = New Decimal(Me.GetNetTotals(Me.iNetInv, "Bill Amount"))
                Me.dcSubPayBasis = New Decimal(Me.GetNetTotals(Me.iNetInv, "Pay Basis"))
                Me.dcsubpayamt = New Decimal(Me.GetNetTotals(Me.iNetInv, "PayAmount"))
                Me.dcsubtip = New Decimal(Me.GetNetTotals(Me.iNetInv, "Tip"))
                Me.dcsubtotalpay = New Decimal(Me.GetNetTotals(Me.iNetInv, "TotalPay"))
                Me.dcsubtax = New Decimal(Me.GetNetTotals(Me.iNetInv, "Tax"))
                Me.dcsubpayrecd = New Decimal(Me.GetNetTotals(Me.iNetInv, "Pay Recd"))
                Me.btnSubmit.Visible = (True)
                Me.UG1.Bands(0).Columns.FromKey("CloseoutDetail_ID").Hidden = True
                Me.UG1.Bands(1).Columns.FromKey("CloseoutDetail_ID").Hidden = True
                If (ObjectType.ObjTst(Me.UG1.Rows(Me.iSubtotal).Cells.FromKey("Last Name").Value, "SubTotal", False) = 0) Then
                    Me.UG1.Rows(Me.iSubtotal).Cells.FromKey("Start Date").Value = ""
                End If
                Me.iOtherChrg = Me.GetRow("Other Charges(Credits)")
                If (ObjectType.ObjTst(Me.UG1.Rows(Me.iOtherChrg).Cells.FromKey("Last Name").Value, "Other Charges(Credits)", False) = 0) Then
                    Me.UG1.Rows(Me.iOtherChrg).Cells.FromKey("Start Date").Value = ""
                End If
                If (ObjectType.ObjTst(Me.UG1.Rows(Me.iNetInv).Cells.FromKey("Last Name").Value, "NET INVOICE AMOUNT", False) = 0) Then
                    Me.UG1.Rows(Me.iNetInv).Cells.FromKey("Start Date").Value = ""
                End If
            End If
        End Sub

        Private Sub BtnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnLoad.Click
            Me.AssignDataSource()
            Me.UG1.Bands(0).AllowAdd = AllowAddNew.No
            If (Me.rdExist.Checked) Then
                Me.txtCloseOutHeader.Text = (Microsoft.VisualBasic.Strings.Mid(Me.lstSubCo.SelectedItem().Text(), 1, Microsoft.VisualBasic.Strings.InStr(Me.lstSubCo.SelectedItem().Text(), "-", 0) - 1))
            End If
        End Sub

        Public Function GetNetTotals(ByVal iSRow As Integer, ByVal strColumn As String) As Integer
            Dim enumerator As IEnumerator = Nothing
            Dim zero As Decimal = Decimal.Zero
            Dim count As Object = Me.UG1.Rows.Count() - 1
            Me.iOtherChrg = Me.GetRow("SubTotal")
            If (ObjectType.ObjTst(count, iSRow, False) >= 0) Then
                count = iSRow
                Dim num As Integer = Me.iOtherChrg
                Dim num1 As Integer = iSRow - 1
                Dim num2 As Integer = num
                Do
                    If (ObjectType.ObjTst(Me.UG1.Rows(num2).Cells.FromKey(strColumn).Value, Nothing, False) <> 0) Then
                        zero = Decimal.Add(zero, DecimalType.FromString(Me.UG1.Rows(num2).Cells.FromKey(strColumn).Value.ToString()))
                    End If
                    If (Me.UG1.Rows(num2).HasChildRows And StringType.StrCmp(Me.UG1.Rows(num2).Cells.FromKey("Last Name").Value.ToString(), "SubTotal", False) <> 0 AndAlso StringType.StrCmp(strColumn, "Pay Basis", False) <> 0 And StringType.StrCmp(strColumn, "Bill Amount", False) <> 0) Then
                        Try
                            enumerator = Me.UG1.Rows(num2).Rows.GetEnumerator()
                            While enumerator.MoveNext()
                                Dim current As UltraGridRow = DirectCast(enumerator.Current(), UltraGridRow)
                                If (ObjectType.ObjTst(current.Cells.FromKey(strColumn).Value, Nothing, False) = 0) Then
                                    Continue While
                                End If
                                zero = Decimal.Add(zero, DecimalType.FromString(current.Cells.FromKey(strColumn).Value.ToString()))
                            End While
                        Finally
                            If (TypeOf enumerator Is IDisposable) Then
                                DirectCast(enumerator, IDisposable).Dispose()
                            End If
                        End Try
                    End If
                    num2 = num2 + 1
                Loop While num2 <= num1
                Me.UG1.Rows(iSRow).Cells.FromKey(strColumn).Value = Microsoft.VisualBasic.Strings.Format(zero, "#.00")
                Dim count1 As Integer = Me.UG1.Rows(iSRow).Cells.Count()
                Dim num3 As Integer = count1 - 1
                For i As Integer = 0 To num3 Step 1
                    Me.UG1.Rows(iSRow).Cells(i).AllowEditing = AllowEditing.No
                Next

            End If
            Return Convert.ToInt32(zero)
        End Function

        Public Function GetRow(ByVal strColumnHeading As String) As Integer
            Dim index As Integer = 0
            Dim enumerator As IEnumerator = Nothing
            Dim zero As Decimal = Decimal.Zero
            Try
                enumerator = Me.UG1.Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As UltraGridRow = DirectCast(enumerator.Current(), UltraGridRow)
                    If (StringType.StrCmp(current.Cells.FromKey("Last Name").Value.ToString(), strColumnHeading, False) <> 0) Then
                        Continue While
                    End If
                    index = current.Index
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Return index
        End Function

        Public Function GetSubTotals(ByVal iSRow As Integer, ByVal strColumn As String) As Integer
            Dim num As Integer = 0
            Dim enumerator As IEnumerator = Nothing
            Dim zero As Decimal = Decimal.Zero
            If (ObjectType.ObjTst(Me.UG1.Rows.Count() - 1, iSRow, False) >= 0) Then
                Dim obj As Object = iSRow
                Dim num1 As Integer = iSRow - 1
                Dim num2 As Integer = num
                Do
                    If (BooleanType.FromObject(ObjectType.NotObj(ObjectType.ObjTst(Me.UG1.Rows(num2).Cells.FromKey("Active").Value, Nothing, False) = 0))) Then
                        If (ObjectType.ObjTst(Me.UG1.Rows(num2).Cells.FromKey(strColumn).Value, Nothing, False) <> 0) Then
                            zero = Decimal.Add(zero, DecimalType.FromString(Me.UG1.Rows(num2).Cells.FromKey(strColumn).Value.ToString()))
                        End If
                        If (Me.UG1.Rows(num2).HasChildRows AndAlso StringType.StrCmp(strColumn, "Pay Basis", False) <> 0 And StringType.StrCmp(strColumn, "Bill Amount", False) <> 0) Then
                            Try
                                enumerator = Me.UG1.Rows(num2).Rows.GetEnumerator()
                                While enumerator.MoveNext()
                                    Dim current As UltraGridRow = DirectCast(enumerator.Current(), UltraGridRow)
                                    If (ObjectType.ObjTst(current.Cells.FromKey(strColumn).Value, Nothing, False) = 0) Then
                                        Continue While
                                    End If
                                    zero = Decimal.Add(zero, DecimalType.FromString(current.Cells.FromKey(strColumn).Value.ToString()))
                                End While
                            Finally
                                If (TypeOf enumerator Is IDisposable) Then
                                    DirectCast(enumerator, IDisposable).Dispose()
                                End If
                            End Try
                        End If
                    End If
                    num2 = num2 + 1
                Loop While num2 <= num1
                Me.UG1.Rows(iSRow).Cells.FromKey(strColumn).Value = Microsoft.VisualBasic.Strings.Format(zero, "#.00")
                Dim count As Integer = Me.UG1.Rows(iSRow).Cells.Count()
                Dim num3 As Integer = count - 1
                For i As Integer = 0 To num3 Step 1
                    Me.UG1.Rows(iSRow).Cells(i).AllowEditing = AllowEditing.No
                Next

            End If
            Return Convert.ToInt32(zero)
        End Function

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("COState")
        End Function

        Private Sub lstSub_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstSub.SelectedIndexChanged
            If (Me.rdExist.Checked) Then
                Dim lastCloseOuts As SqlDataReader = UCCCloseOut.getLastCloseOuts(Me.lstSub.SelectedValue())
                Me.lstSubCo.DataSource = (lastCloseOuts)
                Me.lstSubCo.DataTextField = ("CloseOutHeader_ID")
                Me.lstSubCo.DataValueField = ("CloseOutHeader_ID")
                Me.lstSubCo.DataBind()
            End If
        End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If (Not Me.IsPostBack()) Then
                Me.AssignDataSource()
                Me.UG1.DisplayLayout.AllowUpdateDefault = AllowUpdate.Yes
            End If
        End Sub

        Private Sub rdExist_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdExist.CheckedChanged
            If (Me.rdExist.Checked) Then
                Me.UG1.DataSource = (Nothing)
                Me.UG1.DataBind()
                Me.lblSub.Visible = (True)
                Me.lstSub.Visible = (True)
                Me.BtnLoad.Visible = (True)
                Me.lblCODate.Visible = (True)
                Me.lstSubCo.Visible = (True)
                Dim activeSubs As SqlDataReader = UCCParams.getActiveSubs()
                Me.lstSub.DataSource = (activeSubs)
                Me.lstSub.DataTextField = ("Nick_Name")
                Me.lstSub.DataValueField = ("Nick_Name")
                Me.lstSub.DataBind()
                activeSubs = UCCCloseOut.getLastCloseOuts(Me.lstSub.Items().Item(0).Text())
                Me.lstSubCo.DataSource = (activeSubs)
                Me.lstSubCo.DataTextField = ("CloseOutHeader_ID")
                Me.lstSubCo.DataValueField = ("CloseOutHeader_ID")
                Me.lstSubCo.DataBind()
            End If
        End Sub

        Private Sub rdNew_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdNew.CheckedChanged
            If (Me.rdNew.Checked) Then
                Me.UG1.DataSource = (Nothing)
                Me.UG1.DataBind()
                Me.lblSub.Visible = (True)
                Me.lstSub.Visible = (True)
                Me.BtnLoad.Visible = (True)
                Me.lblCODate.Visible = (False)
                Me.lstSubCo.Visible = (False)
                Me.btnSubmit.Visible = (False)
                Dim activeSubs As SqlDataReader = UCCParams.getActiveSubs()
                Me.lstSub.DataSource = (activeSubs)
                Me.lstSub.DataTextField = ("Nick_Name")
                Me.lstSub.DataValueField = ("Nick_Name")
                Me.lstSub.DataBind()
                Me.txtCloseOutHeader.Text = (StringType.FromInteger(0))
            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("COState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub

        Private Sub UG1_AddRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UG1.AddRow
            Dim key As String = e.Row.Band.Key
            Me.blnAdd = True
            Me.iOtherChrg = Me.GetRow("Other Charges(Credits)")
            Dim index As Integer = e.Row.ParentRow.Index
            If (ObjectType.ObjTst(e.Row.Cells.FromKey("Last Name").Value, "SubTotal", False) <> 0) Then
                Me.UG1.Bands(1).AllowAdd = AllowAddNew.Yes
                Me.UG1.Bands(0).AllowAdd = AllowAddNew.Yes
            Else
                Me.UG1.Bands(1).AllowAdd = AllowAddNew.No
                Me.UG1.Bands(0).AllowAdd = AllowAddNew.No
            End If
            If (ObjectType.ObjTst(e.Row.Cells.FromKey("Last Name").Value, "NET INVOICE AMOUNT", False) <> 0) Then
                Me.UG1.Bands(1).AllowAdd = AllowAddNew.Yes
                Me.UG1.Bands(0).AllowAdd = AllowAddNew.Yes
            Else
                Me.UG1.Bands(1).AllowAdd = AllowAddNew.No
                Me.UG1.Bands(0).AllowAdd = AllowAddNew.No
            End If
            If (StringType.StrCmp(key, "Secondary", False) = 0) Then
                If (index >= Me.iOtherChrg) Then
                    Dim cells As CellsCollection = e.Row.Cells
                    cells.FromKey("Bill Amount").AllowEditing = AllowEditing.No
                    cells.FromKey("Bill Amount").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Pay Basis").AllowEditing = AllowEditing.No
                    cells.FromKey("Pay Basis").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Pay Recd").AllowEditing = AllowEditing.No
                    cells.FromKey("AR Code").AllowEditing = AllowEditing.No
                    cells.FromKey("ZipCode").AllowEditing = AllowEditing.No
                    cells.FromKey("ZipCode").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Active").AllowEditing = AllowEditing.No
                    cells.FromKey("Active").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Pay%").AllowEditing = AllowEditing.No
                    cells.FromKey("Pay%").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Last Name").AllowEditing = AllowEditing.No
                    cells.FromKey("Last Name").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Start Date").AllowEditing = AllowEditing.No
                    cells.FromKey("Start Date").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Job").AllowEditing = AllowEditing.No
                    cells.FromKey("Job").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Active").AllowEditing = AllowEditing.No
                    cells.FromKey("Active").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Tip").AllowEditing = AllowEditing.No
                    cells.FromKey("Tip").Style.BackColor = (Color.LightGray())
                    cells.FromKey("Tax").AllowEditing = AllowEditing.No
                    cells.FromKey("Tax").Style.BackColor = (Color.LightGray())
                    cells = Nothing
                Else
                    Dim text As CellsCollection = e.Row.Cells
                    text.FromKey("Job").Value = e.Row.ParentRow.Cells.FromKey("Job").GetText()
                    text.FromKey("Start Date").Value = e.Row.ParentRow.Cells.FromKey("Start Date").GetText()
                    text.FromKey("ZipCode").Value = e.Row.ParentRow.Cells.FromKey("ZipCode").GetText()
                    text.FromKey("Last Name").Value = e.Row.ParentRow.Cells.FromKey("Last Name").GetText()
                    text.FromKey("Bill Amount").AllowEditing = AllowEditing.No
                    text.FromKey("Bill Amount").Style.BackColor = (Color.LightGray())
                    text.FromKey("Pay Basis").AllowEditing = AllowEditing.No
                    text.FromKey("Pay Basis").Style.BackColor = (Color.LightGray())
                    text.FromKey("Pay Recd").AllowEditing = AllowEditing.No
                    text.FromKey("AR Code").AllowEditing = AllowEditing.No
                    text.FromKey("ZipCode").AllowEditing = AllowEditing.No
                    text.FromKey("ZipCode").Style.BackColor = (Color.LightGray())
                    text.FromKey("Active").AllowEditing = AllowEditing.No
                    text.FromKey("Active").Style.BackColor = (Color.LightGray())
                    text.FromKey("Pay%").AllowEditing = AllowEditing.No
                    text.FromKey("Pay%").Style.BackColor = (Color.LightGray())
                    text.FromKey("Last Name").AllowEditing = AllowEditing.No
                    text.FromKey("Last Name").Style.BackColor = (Color.LightGray())
                    text.FromKey("Start Date").AllowEditing = AllowEditing.No
                    text.FromKey("Start Date").Style.BackColor = (Color.LightGray())
                    text.FromKey("Job").AllowEditing = AllowEditing.No
                    text.FromKey("Job").Style.BackColor = (Color.LightGray())
                    text.FromKey("Active").AllowEditing = AllowEditing.No
                    text.FromKey("Active").Style.BackColor = (Color.LightGray())
                    text.FromKey("Tip").AllowEditing = AllowEditing.No
                    text.FromKey("Tip").Style.BackColor = (Color.LightGray())
                    text.FromKey("Tax").AllowEditing = AllowEditing.No
                    text.FromKey("Tax").Style.BackColor = (Color.LightGray())
                    text = Nothing
                End If
            End If
        End Sub

        Private Sub UG1_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UG1.InitializeLayout
            Dim num As Integer = 0
            Dim headerStyle As Infragistics.WebUI.UltraWebGrid.GridItemStyle = Me.UG1.Bands(0).HeaderStyle
            Dim unit As System.Web.UI.WebControls.Unit = New System.Web.UI.WebControls.Unit("35px")
            DirectCast(headerStyle, Style).Height = (unit)
            Dim gridItemStyle As Infragistics.WebUI.UltraWebGrid.GridItemStyle = Me.UG1.Bands(1).HeaderStyle
            unit = New System.Web.UI.WebControls.Unit("35px")
            DirectCast(gridItemStyle, Style).Height = (unit)
            Me.UG1.Bands(0).Columns.FromKey("Last Name").HeaderText = "Last<br>Name"
            Me.UG1.Bands(0).Columns.FromKey("Start Date").HeaderText = "Schedule<br>Date"
            Me.UG1.Bands(0).Columns.FromKey("Bill Amount").HeaderText = "Bill<br>Amount"
            Me.UG1.Bands(0).Columns.FromKey("Pay Basis").HeaderText = "Pay<br>Basis"
            Me.UG1.Bands(0).Columns.FromKey("Pay Code").HeaderText = "Pay<br>Code"
            Me.UG1.Bands(0).Columns.FromKey("PayAmount").HeaderText = "Pay<br>Amount"
            Me.UG1.Bands(0).Columns.FromKey("TotalPay").HeaderText = "Total<br>Pay"
            Me.UG1.Bands(0).Columns.FromKey("Pay Recd").HeaderText = "Pmt"
            Me.UG1.Bands(0).Columns.FromKey("AR Code").HeaderText = "AR<br>Code"
            Me.UG1.Bands(0).Columns.FromKey("ZipCode").HeaderText = "Zip<br>Code"
            Me.UG1.Bands(1).Columns.FromKey("Last Name").HeaderText = "Last<br>Name"
            Me.UG1.Bands(1).Columns.FromKey("Start Date").HeaderText = "Schedule<br>Date"
            Me.UG1.Bands(1).Columns.FromKey("Bill Amount").HeaderText = "Bill<br>Amount"
            Me.UG1.Bands(1).Columns.FromKey("Pay Basis").HeaderText = "Pay<br>Basis"
            Me.UG1.Bands(1).Columns.FromKey("Pay Code").HeaderText = "Pay<br>Code"
            Me.UG1.Bands(1).Columns.FromKey("PayAmount").HeaderText = "Pay<br>Amount"
            Me.UG1.Bands(1).Columns.FromKey("TotalPay").HeaderText = "Total<br>Pay"
            Me.UG1.Bands(1).Columns.FromKey("Pay Recd").HeaderText = "Pmt"
            Me.UG1.Bands(1).Columns.FromKey("AR Code").HeaderText = "AR<br>Code"
            Me.UG1.Bands(1).Columns.FromKey("ZipCode").HeaderText = "Zip<br>Code"
            Dim ultraGridColumn As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Job")
            unit = New System.Web.UI.WebControls.Unit("65px")
            ultraGridColumn.Width = unit
            Dim ultraGridColumn1 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Start Date")
            unit = New System.Web.UI.WebControls.Unit("85px")
            ultraGridColumn1.Width = unit
            Dim ultraGridColumn2 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Bill Amount")
            unit = New System.Web.UI.WebControls.Unit("65px")
            ultraGridColumn2.Width = unit
            Dim ultraGridColumn3 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Pay Basis")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn3.Width = unit
            Dim ultraGridColumn4 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Pay Code")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn4.Width = unit
            Dim ultraGridColumn5 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("PayAmount")
            unit = New System.Web.UI.WebControls.Unit("60px")
            ultraGridColumn5.Width = unit
            Dim ultraGridColumn6 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("TotalPay")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn6.Width = unit
            Dim ultraGridColumn7 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Pay Recd")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn7.Width = unit
            Dim ultraGridColumn8 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("AR Code")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn8.Width = unit
            Dim ultraGridColumn9 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Tip")
            unit = New System.Web.UI.WebControls.Unit("40px")
            ultraGridColumn9.Width = unit
            Dim ultraGridColumn10 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Tax")
            unit = New System.Web.UI.WebControls.Unit("40px")
            ultraGridColumn10.Width = unit
            Dim ultraGridColumn11 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("ZipCode")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn11.Width = unit
            Dim ultraGridColumn12 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Active")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn12.Width = unit
            Dim ultraGridColumn13 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Pay%")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn13.Width = unit
            Dim ultraGridColumn14 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Last Name")
            unit = New System.Web.UI.WebControls.Unit("157px")
            ultraGridColumn14.Width = unit
            Me.UG1.Bands(0).Columns.FromKey("Bill Amount").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("Pay Basis").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("PayAmount").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("TotalPay").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("Pay Recd").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("Tip").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("Tax").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("Start Date").Format = "MM/dd/yyyy"
            Me.UG1.Bands(1).Columns.FromKey("Bill Amount").Format = "#.00"
            Me.UG1.Bands(1).Columns.FromKey("Pay Basis").Format = "#.00"
            Me.UG1.Bands(1).Columns.FromKey("PayAmount").Format = "#.00"
            Me.UG1.Bands(1).Columns.FromKey("TotalPay").Format = "#.00"
            Me.UG1.Bands(1).Columns.FromKey("Pay Recd").Format = "#.00"
            Me.UG1.Bands(1).Columns.FromKey("Tip").Format = "#.00"
            Me.UG1.Bands(1).Columns.FromKey("Tax").Format = "#.00"
            Dim ultraGridColumn15 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Job")
            unit = New System.Web.UI.WebControls.Unit("65px")
            ultraGridColumn15.Width = unit
            Dim ultraGridColumn16 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Start Date")
            unit = New System.Web.UI.WebControls.Unit("85px")
            ultraGridColumn16.Width = unit
            Dim ultraGridColumn17 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Bill Amount")
            unit = New System.Web.UI.WebControls.Unit("65px")
            ultraGridColumn17.Width = unit
            Dim ultraGridColumn18 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Pay Basis")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn18.Width = unit
            Dim ultraGridColumn19 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Pay Code")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn19.Width = unit
            Dim ultraGridColumn20 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("PayAmount")
            unit = New System.Web.UI.WebControls.Unit("60px")
            ultraGridColumn20.Width = unit
            Dim ultraGridColumn21 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("TotalPay")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn21.Width = unit
            Dim ultraGridColumn22 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Pay Recd")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn22.Width = unit
            Dim ultraGridColumn23 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("AR Code")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn23.Width = unit
            Dim ultraGridColumn24 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Tip")
            unit = New System.Web.UI.WebControls.Unit("40px")
            ultraGridColumn24.Width = unit
            Dim ultraGridColumn25 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Tax")
            unit = New System.Web.UI.WebControls.Unit("40px")
            ultraGridColumn25.Width = unit
            Dim ultraGridColumn26 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("ZipCode")
            unit = New System.Web.UI.WebControls.Unit("170px")
            ultraGridColumn26.Width = unit
            Dim ultraGridColumn27 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Active")
            unit = New System.Web.UI.WebControls.Unit("70px")
            ultraGridColumn27.Width = unit
            Dim ultraGridColumn28 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Pay%")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn28.Width = unit
            Dim ultraGridColumn29 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Last Name")
            unit = New System.Web.UI.WebControls.Unit("113px")
            ultraGridColumn29.Width = unit
            Me.UG1.Bands(0).Columns.FromKey("Active").Type = ColumnType.CheckBox
            Me.UG1.Bands(1).Columns.FromKey("Active").Type = ColumnType.CheckBox
            Me.UG1.Bands(0).Columns.FromKey("Pay Code").Type = ColumnType.DropDownList
            Me.UG1.Bands(0).Columns.FromKey("AR Code").Type = ColumnType.DropDownList
            Me.UG1.Bands(1).Columns.FromKey("Pay Code").Type = ColumnType.DropDownList
            Me.UG1.Bands(1).Columns.FromKey("AR Code").Type = ColumnType.DropDownList
            Dim valueList As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(0).Columns.FromKey("Pay Code").ValueList
            Dim payCodes As SqlDataReader = UCCCloseOut.getPayCodes("PayCode")
            num = 0
            While payCodes.Read()
                valueList.ValueListItems.Add(New ValueListItem())
                valueList.ValueListItems(num).DisplayText = StringType.FromObject(payCodes.Item("Element_ID"))
                num = num + 1
            End While
            valueList.ValueListItems.Insert(0, DBNull.Value, " ")
            Dim valueList1 As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(1).Columns.FromKey("Pay Code").ValueList
            payCodes = UCCCloseOut.getPayCodes("PayCode")
            num = 0
            While payCodes.Read()
                valueList1.ValueListItems.Add(New ValueListItem())
                valueList1.ValueListItems(num).DisplayText = StringType.FromObject(payCodes.Item("Element_ID"))
                num = num + 1
            End While
            valueList1.ValueListItems.Insert(0, DBNull.Value, " ")
            Dim valueList2 As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(0).Columns.FromKey("AR Code").ValueList
            payCodes = UCCCloseOut.getARCodes("ARCode")
            num = 0
            While payCodes.Read()
                valueList2.ValueListItems.Add(New ValueListItem())
                valueList2.ValueListItems(num).DisplayText = StringType.FromObject(payCodes.Item("Element_ID"))
                num = num + 1
            End While
            valueList2.ValueListItems.Insert(0, DBNull.Value, " ")
            Dim valueList3 As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(1).Columns.FromKey("AR Code").ValueList
            num = 0
            payCodes = UCCCloseOut.getARCodes("ARCode")
            While payCodes.Read()
                valueList3.ValueListItems.Add(New ValueListItem())
                valueList3.ValueListItems(num).DisplayText = StringType.FromObject(payCodes.Item("Element_ID"))
                num = num + 1
            End While
            valueList3.ValueListItems.Insert(0, DBNull.Value, " ")
            Me.UG1.Bands(0).Columns.FromKey("Pay Recd").CellStyle.BackColor = (Color.DarkGray())
            Me.UG1.Bands(0).Columns.FromKey("AR Code").CellStyle.BackColor = (Color.DarkGray())
            Me.UG1.Bands(1).Columns.FromKey("Pay Recd").CellStyle.BackColor = (Color.DarkGray())
            Me.UG1.Bands(1).Columns.FromKey("AR Code").CellStyle.BackColor = (Color.DarkGray())
            Me.UG1.Bands(0).Columns.FromKey("Job").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Start Date").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("ZipCode").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Last Name").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(1).Columns.FromKey("Bill Amount").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("Pay Basis").Hidden = True
        End Sub

        Private Sub UG1_PageIndexChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.PageEventArgs) Handles UG1.PageIndexChanged
            Me.UG1.DataBind()
        End Sub

        Private Sub UG1_UpdateGrid(ByVal sender As Object, ByVal e As UpdateEventArgs) Handles UG1.UpdateGrid
            Dim flag As Boolean
            Dim num As Decimal = New Decimal()
            Dim num1 As Decimal = New Decimal()
            Dim num2 As Decimal = New Decimal()
            Dim num3 As Decimal = New Decimal()
            Dim num4 As Integer = 0
            Dim num5 As Integer
            Dim num6 As Integer = 0
            Dim num7 As Integer
            Dim num8 As Integer = 0
            Dim num9 As Integer = 0
            Dim messageHelper As SystemFramework.MessageHelper
            Dim current As UltraGridRow = Nothing
            Dim str As String = Nothing
            Dim str1 As String = Nothing
            Me.lblErrorMsg.Text = ("")
            Dim row As Integer = Me.GetRow("SubTotal")
            Me.iOtherChrg = Me.GetRow("Other Charges(Credits)")
            Dim num10 As Decimal = New Decimal(Me.GetSubTotals(row, "Bill Amount"))
            Dim num11 As Decimal = New Decimal(Me.GetSubTotals(row, "Pay Basis"))
            Dim num12 As Decimal = New Decimal(Me.GetSubTotals(row, "PayAmount"))
            Dim num13 As Decimal = New Decimal(Me.GetSubTotals(row, "Tip"))
            Dim num14 As Decimal = New Decimal(Me.GetSubTotals(row, "Tax"))
            Dim num15 As Decimal = New Decimal(Me.GetSubTotals(row, "TotalPay"))
            Dim num16 As Decimal = New Decimal(Me.GetSubTotals(row, "Pay Recd"))
            Dim [operator] As String = MyBase.[Operator].userId
            Dim operator1 As String = MyBase.[Operator].userId
            Dim batchUpdates As Infragistics.WebUI.UltraWebGrid.UltraGridRowsEnumerator = Nothing
            Dim ultraGridRowsEnumerator As Infragistics.WebUI.UltraWebGrid.UltraGridRowsEnumerator = Nothing
            Dim table1 As DataTable = Me.coDataSet1.Tables().Item("Primary")
            batchUpdates = Me.UG1.Bands(0).GetBatchUpdates()
            Dim table2 As DataTable = Me.coDataSet1.Tables().Item("Secondary")
            ultraGridRowsEnumerator = Me.UG1.Bands(1).GetBatchUpdates()
            While batchUpdates.MoveNext()
                current = batchUpdates.Current
                If (current.DataChanged = DataChanged.Modified AndAlso Not current.IsChild(current)) Then
                    flag = If(current.Index >= Me.iOtherChrg, False, True)
                    num7 = IntegerType.FromObject(current.Cells.FromKey("Job").Value)
                    If (current.Cells.FromKey("Pay%").DataChanged Or current.Cells.FromKey("Pay Basis").DataChanged) Then
                        current.Cells.FromKey("PayAmount").Value = Microsoft.VisualBasic.Strings.Format(Decimal.Multiply(New Decimal(IntegerType.FromObject(current.Cells.FromKey("Pay%").Value)), Decimal.Divide(DecimalType.FromObject(current.Cells.FromKey("Pay Basis").Value), New Decimal(100L))), "#.00")
                    End If
                    If (current.Cells.FromKey("Pay%").DataChanged Or current.Cells.FromKey("Tip").DataChanged Or current.Cells.FromKey("Pay Basis").DataChanged) Then
                        current.Cells.FromKey("TotalPay").Value = Microsoft.VisualBasic.Strings.Format(Decimal.Add(DecimalType.FromObject(current.Cells.FromKey("PayAmount").Value), DecimalType.FromObject(current.Cells.FromKey("Tip").Value)), "#.00")
                    End If
                    If (current.Index > row) Then
                        num5 = IntegerType.FromObject(current.DataKey)
                        If (Me.rdExist.Checked) Then
                            num5 = IntegerType.FromObject(current.Cells.FromKey("CloseoutDetail_ID").Value)
                        End If
                        messageHelper = UCCCloseOut.modifyCloseOutDetailCredit(num5, flag, str1, num, num4, operator1)
                        Me.txtCloseOutHeader.Text = (StringType.FromInteger(num9))
                        If (Not messageHelper.status) Then
                            Me.lblErrorMsg.Text = (messageHelper.messageText)
                        End If
                    Else
                        If (StringType.StrCmp(Me.txtCloseOutHeader.Text(), "", False) = 0 Or StringType.StrCmp(Me.txtCloseOutHeader.Text(), "0", False) = 0) Then
                            num6 = 0
                        End If
                        Dim num17 As Decimal = DecimalType.FromObject(current.Cells.FromKey("Bill Amount").Value)
                        Dim num18 As Decimal = DecimalType.FromObject(current.Cells.FromKey("Pay Basis").Value)
                        str1 = StringType.FromObject(current.Cells.FromKey("Pay Code").Value)
                        num8 = IntegerType.FromObject(current.Cells.FromKey("Pay%").Value)
                        num4 = IntegerType.FromObject(current.Cells.FromKey("Active").Value)
                        num = DecimalType.FromObject(current.Cells.FromKey("PayAmount").Value)
                        num3 = DecimalType.FromObject(current.Cells.FromKey("Tip").Value)
                        str = StringType.FromObject(current.Cells.FromKey("AR Code").Value)
                        num1 = DecimalType.FromObject(current.Cells.FromKey("Pay Recd").Value)
                        num2 = DecimalType.FromObject(current.Cells.FromKey("Tax").Value)
                        If (Me.rdExist.Checked) Then
                            current.DataKey = IntegerType.FromObject(current.Cells.FromKey("CloseoutDetail_ID").Value)
                        End If
                        If (ObjectType.ObjTst(current.DataKey, Nothing, False) <> 0) Then
                            messageHelper = UCCCloseOut.modifyCloseOutDetail(IntegerType.FromObject(current.DataKey), flag, num7, num17, num18, str1, num8, num, num3, str, num1, num2, num4, operator1)
                            If (Not messageHelper.status) Then
                                Me.lblErrorMsg.Text = (messageHelper.messageText)
                            End If
                        Else
                            num5 = 0
                            If (StringType.StrCmp(Me.txtCloseOutHeader.Text(), "", False) = 0 Or StringType.StrCmp(Me.txtCloseOutHeader.Text(), "0", False) = 0) Then
                                num9 = UCCCloseOut.createCloseOutHeader(num6, Me.lstSub.SelectedValue(), Decimal.Zero, [operator], operator1)
                                Me.txtCloseOutHeader.Text = (StringType.FromInteger(num9))
                            End If
                            If (IntegerType.FromString(Me.txtCloseOutHeader.Text()) > 0) Then
                                num9 = IntegerType.FromString(Me.txtCloseOutHeader.Text())
                            End If
                            messageHelper = UCCCloseOut.createCloseOutDetail(num9, flag, num5, num7, num17, num18, str1, num8, num, num3, str, num1, num2, num4, [operator], operator1)
                            If (messageHelper.status) Then
                                current.DataKey = RuntimeHelpers.GetObjectValue(messageHelper.messageObject)
                            Else
                                Me.lblErrorMsg.Text = (messageHelper.messageText)
                            End If
                        End If
                    End If
                End If
                row = Me.GetRow("SubTotal")
                Me.iOtherChrg = Me.GetRow("Other Charges(Credits)")
                num10 = New Decimal(Me.GetSubTotals(row, "Bill Amount"))
                num11 = New Decimal(Me.GetSubTotals(row, "Pay Basis"))
                num12 = New Decimal(Me.GetSubTotals(row, "PayAmount"))
                num13 = New Decimal(Me.GetSubTotals(row, "Tip"))
                num15 = New Decimal(Me.GetSubTotals(row, "TotalPay"))
                num16 = New Decimal(Me.GetSubTotals(row, "Pay Recd"))
                Me.iNetInv = Me.GetRow("NET INVOICE AMOUNT")
                num10 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Bill Amount"))
                num11 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Pay Basis"))
                num12 = New Decimal(Me.GetNetTotals(Me.iNetInv, "PayAmount"))
                num13 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Tip"))
                num15 = New Decimal(Me.GetNetTotals(Me.iNetInv, "TotalPay"))
                num16 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Pay Recd"))
                If (Microsoft.VisualBasic.Strings.Len(Me.lblErrorMsg.Text()) <> 0) Then
                    Me.txtValid.Text = ("False")
                Else
                    Me.txtValid.Text = ("True")
                End If
            End While
            While ultraGridRowsEnumerator.MoveNext()
                Dim objectValue As UltraGridRow = ultraGridRowsEnumerator.Current
                If (Me.rdExist.Checked AndAlso objectValue.DataChanged = DataChanged.Added) Then
                    objectValue.DataKey = Nothing
                End If
                If (Not BooleanType.FromObject(ObjectType.BitOrObj(objectValue.DataChanged = DataChanged.Modified, ObjectType.ObjTst(objectValue.DataKey, Nothing, False) <> 0))) Then
                    If (objectValue.DataChanged <> DataChanged.Added) Then
                        Continue While
                    End If
                    objectValue.Cells.FromKey("TotalPay").Value = Microsoft.VisualBasic.Strings.Format(DecimalType.FromObject(objectValue.Cells.FromKey("PayAmount").Value), "")
                    If (Decimal.Compare(DecimalType.FromObject(objectValue.Cells.FromKey("PayAmount").Value), DecimalType.FromObject(objectValue.Cells.FromKey("TotalPay").Value)) = 0) Then
                        flag = If(objectValue.ParentRow.Index >= Me.iOtherChrg, False, True)
                        If (ObjectType.ObjTst(objectValue.DataKey, Nothing, False) <> 0 OrElse Me.blnAdd) Then
                            Continue While
                        End If
                        If (objectValue.ParentRow.Index >= row) Then
                            num5 = 0
                            If (StringType.StrCmp(Me.txtCloseOutHeader.Text(), "", False) = 0 Or StringType.StrCmp(Me.txtCloseOutHeader.Text(), "0", False) = 0) Then
                                num9 = UCCCloseOut.createCloseOutHeader(num6, Me.lstSub.SelectedValue(), Decimal.Zero, [operator], operator1)
                                Me.txtCloseOutHeader.Text = (StringType.FromInteger(num9))
                            End If
                            num7 = 0
                            str1 = StringType.FromObject(objectValue.Cells.FromKey("Pay Code").Value)
                            num = DecimalType.FromObject(objectValue.Cells.FromKey("PayAmount").Value)
                            num4 = IntegerType.FromObject(objectValue.Cells.FromKey("Active").Value)
                            If (IntegerType.FromString(Me.txtCloseOutHeader.Text()) > 0) Then
                                num9 = IntegerType.FromString(Me.txtCloseOutHeader.Text())
                            End If
                            If (Not flag) Then
                                num4 = 1
                            End If
                            messageHelper = UCCCloseOut.createCloseOutDetailCredit(num9, flag, num5, num7, str1, num, num4, [operator], operator1)
                            If (messageHelper.status) Then
                                objectValue.DataKey = RuntimeHelpers.GetObjectValue(messageHelper.messageObject)
                            Else
                                Me.lblErrorMsg.Text = (messageHelper.messageText)
                            End If
                        Else
                            num7 = IntegerType.FromObject(objectValue.Cells.FromKey("Job").Value)
                            str1 = StringType.FromObject(objectValue.Cells.FromKey("Pay Code").Value)
                            num = DecimalType.FromObject(objectValue.Cells.FromKey("PayAmount").Value)
                            num4 = IntegerType.FromObject(objectValue.Cells.FromKey("Active").Value)
                            num5 = 0
                            If (StringType.StrCmp(Me.txtCloseOutHeader.Text(), "", False) = 0 Or StringType.StrCmp(Me.txtCloseOutHeader.Text(), "0", False) = 0) Then
                                num9 = UCCCloseOut.createCloseOutHeader(num6, Me.lstSub.SelectedValue(), Decimal.Zero, [operator], operator1)
                                Me.txtCloseOutHeader.Text = (StringType.FromInteger(num9))
                            End If
                            If (IntegerType.FromString(Me.txtCloseOutHeader.Text()) > 0) Then
                                num9 = IntegerType.FromString(Me.txtCloseOutHeader.Text())
                            End If
                            If (Not flag) Then
                                num4 = 1
                            End If
                            messageHelper = UCCCloseOut.createCloseOutDetailSpec(num9, flag, num5, num7, str1, num, num4, [operator], operator1)
                            If (messageHelper.status) Then
                                objectValue.DataKey = RuntimeHelpers.GetObjectValue(messageHelper.messageObject)
                            Else
                                Me.lblErrorMsg.Text = (messageHelper.messageText)
                            End If
                        End If
                    Else
                        Me.lblErrorMsg.Text = ("For Child Rows the Pay Amount and the Total Pay should be equal.")
                    End If
                Else
                    If (Not objectValue.HasParent) Then
                        Continue While
                    End If
                    objectValue.Cells.FromKey("TotalPay").Value = Microsoft.VisualBasic.Strings.Format(DecimalType.FromObject(objectValue.Cells.FromKey("PayAmount").Value), "")
                    If (Decimal.Compare(DecimalType.FromObject(objectValue.Cells.FromKey("PayAmount").Value), DecimalType.FromObject(objectValue.Cells.FromKey("TotalPay").Value)) = 0) Then
                        flag = If(objectValue.ParentRow.Index >= Me.iOtherChrg, False, True)
                        num7 = IntegerType.FromObject(objectValue.Cells.FromKey("Job").Value)
                        If (objectValue.ParentRow.Index > row) Then
                            num5 = IntegerType.FromObject(objectValue.DataKey)
                            If (Me.rdExist.Checked) Then
                                num5 = IntegerType.FromObject(objectValue.Cells.FromKey("CloseoutDetail_ID").Value)
                            End If
                            str1 = StringType.FromObject(objectValue.Cells.FromKey("Pay Code").Value)
                            num = DecimalType.FromObject(objectValue.Cells.FromKey("PayAmount").Value)
                            If (Not flag) Then
                                num4 = 1
                            End If
                            messageHelper = UCCCloseOut.modifyCloseOutDetailCredit(num5, flag, str1, num, num4, operator1)
                            If (Not messageHelper.status) Then
                                Me.lblErrorMsg.Text = (messageHelper.messageText)
                            End If
                        Else
                            If (StringType.StrCmp(Me.txtCloseOutHeader.Text(), "", False) = 0 Or StringType.StrCmp(Me.txtCloseOutHeader.Text(), "0", False) = 0) Then
                                num6 = 0
                            End If
                            str1 = StringType.FromObject(objectValue.Cells.FromKey("Pay Code").Value)
                            num = DecimalType.FromObject(objectValue.Cells.FromKey("PayAmount").Value)
                            num4 = Convert.ToInt32(DecimalType.FromObject(objectValue.Cells.FromKey("Active").Value))
                            If (ObjectType.ObjTst(objectValue.DataKey, Nothing, False) <> 0) Then
                                If (Me.rdExist.Checked) Then
                                    current.DataKey = IntegerType.FromObject(current.Cells.FromKey("CloseoutDetail_ID").Value)
                                End If
                                If (Not flag) Then
                                    num4 = 1
                                End If
                                messageHelper = UCCCloseOut.modifyCloseOutDetail(IntegerType.FromObject(current.DataKey), flag, num7, Decimal.Zero, Decimal.Zero, str1, num8, num, num3, str, num1, num2, num4, operator1)
                                If (Not messageHelper.status) Then
                                    Me.lblErrorMsg.Text = (messageHelper.messageText)
                                End If
                            Else
                                num5 = 0
                                If (StringType.StrCmp(Me.txtCloseOutHeader.Text(), "", False) = 0 Or StringType.StrCmp(Me.txtCloseOutHeader.Text(), "0", False) = 0) Then
                                    num9 = UCCCloseOut.createCloseOutHeader(num6, Me.lstSub.SelectedValue(), Decimal.Zero, [operator], operator1)
                                    Me.txtCloseOutHeader.Text = (StringType.FromInteger(num9))
                                End If
                                If (IntegerType.FromString(Me.txtCloseOutHeader.Text()) > 0) Then
                                    num9 = IntegerType.FromString(Me.txtCloseOutHeader.Text())
                                End If
                                If (Not flag) Then
                                    num4 = 1
                                End If
                                messageHelper = UCCCloseOut.createCloseOutDetail(num9, flag, num5, num7, Decimal.Zero, Decimal.Zero, str1, num8, num, num3, str, num1, num2, num4, [operator], operator1)
                                If (messageHelper.status) Then
                                    objectValue.DataKey = RuntimeHelpers.GetObjectValue(messageHelper.messageObject)
                                Else
                                    Me.lblErrorMsg.Text = (messageHelper.messageText)
                                End If
                            End If
                        End If
                    Else
                        Me.lblErrorMsg.Text = ("For Child Rows the Pay Amount and the Total Pay should be equal.")
                    End If
                End If
            End While
            row = Me.GetRow("SubTotal")
            Me.iOtherChrg = Me.GetRow("Other Charges(Credits)")
            num10 = New Decimal(Me.GetSubTotals(row, "Bill Amount"))
            num11 = New Decimal(Me.GetSubTotals(row, "Pay Basis"))
            num12 = New Decimal(Me.GetSubTotals(row, "PayAmount"))
            num13 = New Decimal(Me.GetSubTotals(row, "Tip"))
            num15 = New Decimal(Me.GetSubTotals(row, "TotalPay"))
            num14 = New Decimal(Me.GetSubTotals(row, "Tax"))
            num16 = New Decimal(Me.GetSubTotals(row, "Pay Recd"))
            Me.iNetInv = Me.GetRow("NET INVOICE AMOUNT")
            num10 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Bill Amount"))
            num11 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Pay Basis"))
            num12 = New Decimal(Me.GetNetTotals(Me.iNetInv, "PayAmount"))
            num13 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Tip"))
            num15 = New Decimal(Me.GetNetTotals(Me.iNetInv, "TotalPay"))
            num14 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Tax"))
            num16 = New Decimal(Me.GetNetTotals(Me.iNetInv, "Pay Recd"))
            If (Microsoft.VisualBasic.Strings.Len(Me.lblErrorMsg.Text()) <> 0) Then
                Me.txtValid.Text = ("False")
            Else
                Me.txtValid.Text = ("True")
            End If
        End Sub

    End Class
End Namespace