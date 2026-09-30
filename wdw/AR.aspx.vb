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
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class AR
        Inherits PageBase

        Private dcTotal As Decimal

        Private iCtr As Integer

        Private rda As SqlDataAdapter

        Private rda2 As SqlDataAdapter

        Private Primary As String

        Private Secondary As String

        Private coDataSet1 As DataSet

        Private FUNCTIONNAME As String

        Public Sub New()
            MyBase.New()
            Dim aR1 As AR = Me
            'MyBase.add_Init(New EventHandler(aR1, aR1.Page_Init))
            Dim aR2 As AR = Me
            'MyBase.add_Load(New EventHandler(aR2, aR2.Page_Load))
            Me.rda = New SqlDataAdapter()
            Me.rda2 = New SqlDataAdapter()
            Me.Primary = "Primary"
            Me.Secondary = "Secondary"
            Me.coDataSet1 = New DataSet("COut")
            Me.FUNCTIONNAME = "AccountsReceivable"
        End Sub

        Private Sub AssignDataSource()
            'Dim num As Integer = 0
            Me.rda = New SqlDataAdapter()
            Me.rda2 = New SqlDataAdapter()
            Me.coDataSet1 = New DataSet("COut")

            If (Microsoft.VisualBasic.Strings.Len(Me.txtClient.Text()) <= 0) Then
                Me.rda = UCCAR.getAllParentAR()
                Me.rda2 = UCCAR.getAllChildAR()
            Else
                Me.rda = UCCAR.getAllParentARByClient(IntegerType.FromString(Me.txtClient.Text()))
                Me.rda2 = UCCAR.getAllChildARByClient(IntegerType.FromString(Me.txtClient.Text()))
            End If
            Me.rda.Fill(Me.coDataSet1, "Primary")
            Me.rda2.Fill(Me.coDataSet1, "Secondary")

            'If (num < 1) Then
            Me.coDataSet1.Relations().Add("Primary", Me.coDataSet1.Tables().Item("Primary").Columns().Item("Job_ID"), Me.coDataSet1.Tables().Item("Secondary").Columns().Item("Job_ID"))
            'End If

        End Sub

        Private Sub BtnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            Me.AssignDataSource()
            Me.UG1.Bands(0).AllowAdd = AllowAddNew.No
        End Sub

        'Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
        'End Sub

        Private Function CalculateTotal(ByVal iRow As Object) As Decimal
            Dim num As Decimal = New Decimal()
            Dim count As Object = Me.UG1.Rows.Count() - 1
            Dim num1 As Integer = IntegerType.FromObject(count)
            Dim num2 As Integer = 0
            Do
                num = Decimal.Add(num, DecimalType.FromString(Me.UG1.Rows(num2).Cells.FromKey("Balance").Value.ToString()))
                num2 = num2 + 1
            Loop While num2 <= num1
            Me.txtTotal.Text = (Microsoft.VisualBasic.Strings.Format(num, "#.00"))
            Return DecimalType.FromString(Microsoft.VisualBasic.Strings.Format(num, "#.00"))
        End Function

        '<DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("ARState")
        End Function

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
            If (Not Me.IsPostBack()) Then
                Dim num As Integer = 0
                Me.AssignDataSource()
                Me.UG1.DataSource = (Me.coDataSet1.Tables().Item("Primary").DefaultView())
                Me.UG1.DataBind()
                Me.dcTotal = Me.CalculateTotal(num)
                Me.UG1.DisplayLayout.AllowUpdateDefault = AllowUpdate.Yes
                Me.UG1.Bands(0).AllowAdd = AllowAddNew.No
                Me.UG1.DisplayLayout.ActiveRow = Me.UG1.Rows(0)
                Me.UG1.Visible = (True)
            End If
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("ARState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub

        Private Sub txtClient_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtClient.TextChanged
            Dim num As Integer = 0
            Me.AssignDataSource()
            Me.UG1.DataSource = (Me.coDataSet1.Tables().Item("Primary").DefaultView())
            Me.UG1.DataBind()
            Me.dcTotal = Me.CalculateTotal(num)
            Me.UG1.DisplayLayout.AllowUpdateDefault = AllowUpdate.Yes
            Me.UG1.Bands(0).AllowAdd = AllowAddNew.No
            Me.UG1.DisplayLayout.ActiveRow = Me.UG1.Rows(0)
            Me.UG1.Visible = (True)
        End Sub

        Private Sub UG1_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UG1.InitializeLayout
            Dim headerStyle As Infragistics.WebUI.UltraWebGrid.GridItemStyle = Me.UG1.Bands(0).HeaderStyle
            Dim unit As System.Web.UI.WebControls.Unit = New System.Web.UI.WebControls.Unit("35px")
            DirectCast(headerStyle, Style).Height = (unit)
            Dim gridItemStyle As Infragistics.WebUI.UltraWebGrid.GridItemStyle = Me.UG1.Bands(1).HeaderStyle
            unit = New System.Web.UI.WebControls.Unit("35px")
            DirectCast(gridItemStyle, Style).Height = (unit)
            Me.UG1.Bands(0).Columns.FromKey("Job_ID").HeaderText = "Job"
            Me.UG1.Bands(0).Columns.FromKey("BillAmt").HeaderText = "Bill<br>Amt"
            Me.UG1.Bands(0).Columns.FromKey("Schedule Date").HeaderText = "Schedule<br>Date"
            Dim ultraGridColumn As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Name")
            unit = New System.Web.UI.WebControls.Unit("150px")
            ultraGridColumn.Width = unit
            Dim ultraGridColumn1 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("BillAmt")
            unit = New System.Web.UI.WebControls.Unit("75px")
            ultraGridColumn1.Width = unit
            Dim ultraGridColumn2 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Job_ID")
            unit = New System.Web.UI.WebControls.Unit("65px")
            ultraGridColumn2.Width = unit
            Dim ultraGridColumn3 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Client #")
            unit = New System.Web.UI.WebControls.Unit("85px")
            ultraGridColumn3.Width = unit
            Dim ultraGridColumn4 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Pmt")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn4.Width = unit
            Dim ultraGridColumn5 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Paid")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn5.Width = unit
            Dim ultraGridColumn6 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Int")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn6.Width = unit
            Dim ultraGridColumn7 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Late")
            unit = New System.Web.UI.WebControls.Unit("50px")
            ultraGridColumn7.Width = unit
            Dim ultraGridColumn8 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Sub")
            unit = New System.Web.UI.WebControls.Unit("65px")
            ultraGridColumn8.Width = unit
            Me.UG1.Bands(0).Columns.FromKey("Balance").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("BillAmt").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("Paid").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("Late").Format = "#.00"
            Me.UG1.Bands(0).Columns.FromKey("Int").Format = "#.00"
            Me.UG1.Bands(1).Columns.FromKey("Contact Date").Format = "MM/dd/yy"
            Me.UG1.Bands(0).Columns.FromKey("Paid Date").Format = "MM/dd/yy"
            Dim ultraGridColumn9 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Notes")
            unit = New System.Web.UI.WebControls.Unit("696px")
            ultraGridColumn9.Width = unit
            Me.UG1.Bands(1).Columns.FromKey("AR_ID").Hidden = True
            Me.UG1.Bands(1).Columns.FromKey("Job_ID").Hidden = True
            Me.UG1.Bands(0).Columns.FromKey("Pmt").Type = ColumnType.DropDownList
            Me.UG1.Bands(0).Columns.FromKey("Sub").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Sub").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("BillAmt").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("BillAmt").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("Schedule Date").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Schedule Date").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("Job_ID").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Job_ID").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("Name").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Name").CellStyle.BackColor = (Color.LightGray())
            Me.UG1.Bands(0).Columns.FromKey("Client #").AllowUpdate = AllowUpdate.No
            Me.UG1.Bands(0).Columns.FromKey("Client #").CellStyle.BackColor = (Color.LightGray())
            Dim valueList As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(0).Columns.FromKey("Pmt").ValueList
            Dim aRCodes As SqlDataReader = UCCCloseOut.getARCodes("ARCode")
            Me.iCtr = 0
            While aRCodes.Read()
                valueList.ValueListItems.Add(New ValueListItem())
                valueList.ValueListItems(Me.iCtr).DisplayText = StringType.FromObject(aRCodes.Item("Element_ID"))
                Me.iCtr = Me.iCtr + 1
            End While
            valueList.ValueListItems.Insert(0, DBNull.Value, " ")
            Me.UG1.Bands(1).Columns.FromKey("Result Code").Type = ColumnType.DropDownList
            Dim valueList1 As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(1).Columns.FromKey("Result Code").ValueList
            aRCodes = UCCAR.getResultCodes("FollowupCode")
            Me.iCtr = 0
            While aRCodes.Read()
                valueList1.ValueListItems.Add(New ValueListItem())
                valueList1.ValueListItems(Me.iCtr).DisplayText = StringType.FromObject(aRCodes.Item("Element_ID"))
                Me.iCtr = Me.iCtr + 1
            End While
            valueList1.ValueListItems.Insert(0, DBNull.Value, " ")
        End Sub

        Private Sub UG1_PageIndexChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.PageEventArgs) Handles UG1.PageIndexChanged
            Me.UG1.DataBind()
        End Sub

        Private Sub UG1_UpdateGrid(ByVal sender As Object, ByVal e As UpdateEventArgs) Handles UG1.UpdateGrid
            Dim num As Decimal = New Decimal()
            Dim num1 As Decimal = New Decimal()
            Dim dateTime As System.DateTime
            Dim num2 As Integer
            Dim num3 As Integer
            Dim num4 As Integer = 0
            Dim messageHelper As SystemFramework.MessageHelper
            Dim str As String
            Dim objectValue As Object
            Me.iCtr = 1
            Me.AssignDataSource()
            Me.lblErrorMsg.Text = ("")
            Dim [operator] As String = MyBase.[Operator].userId
            Dim operator1 As String = MyBase.[Operator].userId
            Dim batchUpdates As Infragistics.WebUI.UltraWebGrid.UltraGridRowsEnumerator = Nothing
            Dim ultraGridRowsEnumerator As Infragistics.WebUI.UltraWebGrid.UltraGridRowsEnumerator = Nothing
            Dim Table1 As DataTable = Me.coDataSet1.Tables().Item("Primary")
            batchUpdates = Me.UG1.Bands(0).GetBatchUpdates()
            Dim Table2 As DataTable = Me.coDataSet1.Tables().Item("Secondary")
            ultraGridRowsEnumerator = Me.UG1.Bands(1).GetBatchUpdates()
            While batchUpdates.MoveNext()
                Dim current As Infragistics.WebUI.UltraWebGrid.UltraGridRow = batchUpdates.Current
                If (current.DataChanged <> DataChanged.Modified OrElse current.IsChild(current)) Then
                    Continue While
                End If
                Dim dateTime1 As System.DateTime = DateType.FromObject(current.Cells.FromKey("Paid Date").Value)
                Dim num5 As Decimal = DecimalType.FromObject(current.Cells.FromKey("Paid").Value)
                Dim obj As Object = RuntimeHelpers.GetObjectValue(current.Cells.FromKey("Pmt").Value)
                num3 = IntegerType.FromObject(current.Cells.FromKey("Job_ID").Value)
                num1 = IIf(Microsoft.VisualBasic.Strings.Len(num1) <> 0, DecimalType.FromObject(current.Cells.FromKey("Late").Value), Decimal.Zero)
                num = IIf(Microsoft.VisualBasic.Strings.Len(num) <> 0, DecimalType.FromObject(current.Cells.FromKey("Int").Value), Decimal.Zero)
                messageHelper = UCCAR.modifyARMethod(num3, dateTime1, num5, StringType.FromObject(obj), num1, num, operator1)
                If (messageHelper.status) Then
                    current.Cells.FromKey("Balance").Value = StringType.FromDecimal(Decimal.Subtract(Decimal.Add(Decimal.Add(DecimalType.FromObject(current.Cells.FromKey("BillAmt").Value), num1), num), num5))
                Else
                    Me.lblErrorMsg.Text = (messageHelper.messageText)
                End If
            End While
            While ultraGridRowsEnumerator.MoveNext()
                Dim ultraGridRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = ultraGridRowsEnumerator.Current
                If (Not BooleanType.FromObject(ObjectType.BitOrObj(ultraGridRow.DataChanged = DataChanged.Modified, ObjectType.ObjTst(ultraGridRow.DataKey, Nothing, False) <> 0))) Then
                    If (ultraGridRow.DataChanged <> DataChanged.Added OrElse ObjectType.ObjTst(ultraGridRow.DataKey, Nothing, False) <> 0) Then
                        Continue While
                    End If
                    num3 = 0
                    str = StringType.FromObject(ultraGridRow.Cells.FromKey("Notes").Value)
                    If (Microsoft.VisualBasic.Strings.Len(RuntimeHelpers.GetObjectValue(ultraGridRow.Cells.FromKey("Contact Date").Value)) <= 0) Then
                        dateTime = DateType.FromString(Microsoft.VisualBasic.Strings.Format(System.DateTime.Now(), "MM/dd/yyyy"))
                        ultraGridRow.Cells.FromKey("Contact Date").Value = Microsoft.VisualBasic.Strings.Format(dateTime, "MM/dd/yyyy")
                    Else
                        dateTime = DateType.FromObject(ultraGridRow.Cells.FromKey("Contact Date").Value)
                    End If
                    num2 = IntegerType.FromObject(ultraGridRow.ParentRow.Cells.FromKey("Job_ID").Value)
                    objectValue = RuntimeHelpers.GetObjectValue(ultraGridRow.Cells.FromKey("Result Code").Value)
                    messageHelper = UCCAR.createAR(num4, str, dateTime, num2, StringType.FromObject(objectValue), [operator], operator1)
                    If (messageHelper.status) Then
                        ultraGridRow.DataKey = RuntimeHelpers.GetObjectValue(messageHelper.messageObject)
                    Else
                        Me.lblErrorMsg.Text = (messageHelper.messageText)
                    End If
                Else
                    If (Not ultraGridRow.HasParent) Then
                        Continue While
                    End If
                    str = StringType.FromObject(ultraGridRow.Cells.FromKey("Notes").Value)
                    dateTime = DateType.FromObject(ultraGridRow.Cells.FromKey("Contact Date").Value)
                    num2 = IntegerType.FromObject(ultraGridRow.ParentRow.Cells.FromKey("Job_ID").Value)
                    num3 = IntegerType.FromObject(ultraGridRow.Cells.FromKey("AR_ID").Value)
                    objectValue = RuntimeHelpers.GetObjectValue(ultraGridRow.Cells.FromKey("Result Code").Value)
                    messageHelper = UCCAR.modifyAR(num3, str, dateTime, StringType.FromObject(objectValue), operator1)
                    If (Not messageHelper.status) Then
                        Me.lblErrorMsg.Text = (messageHelper.messageText)
                    End If
                End If
            End While
        End Sub
    End Class
End Namespace