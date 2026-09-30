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
    Public Class Tasks
        Inherits PageBase
        '<AccessedThroughProperty("lblErrorMsg")>
        'Private _lblErrorMsg As Label

        '<AccessedThroughProperty("UG1")>
        'Private _UG1 As UltraWebGrid

        '<AccessedThroughProperty("ListBox1")>
        'Private _ListBox1 As ListBox

        '<AccessedThroughProperty("btnSubmit")>
        'Private _btnSubmit As Button

        Private ctr As Integer

        Private rda As SqlDataAdapter

        Private rda2 As SqlDataAdapter

        Private Primary As String

        Private Secondary As String

        Private tasksDataSet1 As DataSet

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnSubmit As Button
        '    Get
        '        Return Me._btnSubmit
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnSubmit IsNot Nothing) Then
        '            Dim task As Tasks = Me
        '            Me._btnSubmit.remove_Click(New EventHandler(task, task.btnSubmit_Click))
        '        End If
        '        Me._btnSubmit = value
        '        If (Me._btnSubmit IsNot Nothing) Then
        '            Dim task1 As Tasks = Me
        '            Me._btnSubmit.add_Click(New EventHandler(task1, task1.btnSubmit_Click))
        '        End If
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

        'Protected Overridable Property ListBox1 As ListBox
        '    Get
        '        Return Me._ListBox1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As ListBox)
        '        Me._ListBox1 Is Nothing
        '        Me._ListBox1 = value
        '        Me._ListBox1 Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property UG1 As UltraWebGrid
        '    Get
        '        Return Me._UG1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UG1 IsNot Nothing) Then
        '            Dim task As Tasks = Me
        '            RemoveHandler Me._UG1.UpdateGrid, New UpdateGridEventHandler(AddressOf task.UG1_UpdateGrid)
        '            Dim task1 As Tasks = Me
        '            RemoveHandler Me._UG1.InitializeLayout, New InitializeLayoutEventHandler(AddressOf task1.UG1_InitializeLayout)
        '            Dim task2 As Tasks = Me
        '            RemoveHandler Me._UG1.UpdateCellBatch, New UpdateCellBatchEventHandler(AddressOf task2.UG1_UpdateCellBatch)
        '        End If
        '        Me._UG1 = value
        '        If (Me._UG1 IsNot Nothing) Then
        '            Dim task3 As Tasks = Me
        '            AddHandler Me._UG1.UpdateGrid, New UpdateGridEventHandler(AddressOf task3.UG1_UpdateGrid)
        '            Dim task4 As Tasks = Me
        '            AddHandler Me._UG1.InitializeLayout, New InitializeLayoutEventHandler(AddressOf task4.UG1_InitializeLayout)
        '            Dim task5 As Tasks = Me
        '            AddHandler Me._UG1.UpdateCellBatch, New UpdateCellBatchEventHandler(AddressOf task5.UG1_UpdateCellBatch)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim task As Tasks = Me
            'MyBase.add_Load(New EventHandler(task, task.Page_Load))
            Dim task1 As Tasks = Me
            'MyBase.add_Init(New EventHandler(task1, task1.Page_Init))
            Me.ctr = 0
            Me.rda = New SqlDataAdapter()
            Me.rda2 = New SqlDataAdapter()
            Me.Primary = "Service_Offer"
            Me.Secondary = "Service_Offer"
            Me.tasksDataSet1 = New DataSet("Tasks")
            Me.FUNCTIONNAME = "Items"
        End Sub

        Private Sub AssignDataSource()
            Me.rda = UCCTask.getAllParentTasks()
            Me.rda2 = UCCTask.getAllChildTasks()
            Me.rda.Fill(Me.tasksDataSet1, "Primary")
            Me.rda2.Fill(Me.tasksDataSet1, "Secondary")
            If (Me.ctr < 1) Then
                Me.tasksDataSet1.Relations().Add("Primary", Me.tasksDataSet1.Tables().Item("Primary").Columns().Item("ServOff_ID"), Me.tasksDataSet1.Tables().Item("Secondary").Columns().Item("ParentServOff_ID"))
            End If
        End Sub

        'Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
        'End Sub

        ''<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("TaskState")
        End Function

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
            If (Not Me.IsPostBack()) Then
                Me.AssignDataSource()
                Me.UG1.DisplayLayout.AllowUpdateDefault = AllowUpdate.Yes
                Me.UG1.DataSource = (Me.tasksDataSet1.Tables().Item("Primary").DefaultView())
                Me.UG1.DataBind()
                Me.UG1.DisplayLayout.ActiveRow = Me.UG1.Rows(0)
            End If
            Me.lblErrorMsg.Text = ("")
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("TaskState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub

        Private Sub UG1_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UG1.InitializeLayout
            If (Not Me.IsPostBack()) Then
                Me.UG1.Bands(1).Columns.FromKey("ServOff_Name").HeaderText = "Items"
                Me.UG1.Bands(0).Columns.FromKey("ServOff_Name").HeaderText = "Items"
                Me.UG1.Bands(0).DataKeyField = Me.tasksDataSet1.Tables().Item("Primary").Columns().Item(0).ColumnName()
                Me.UG1.Bands(1).DataKeyField = Me.tasksDataSet1.Tables().Item("Secondary").Columns().Item(0).ColumnName()
                Me.UG1.Bands(1).Columns.FromKey("ServOff_ID").HeaderText = "ID"
                Me.UG1.Bands(1).Columns.FromKey("ServOff_ID").Hidden = True
                Me.UG1.Bands(1).Columns.FromKey("ParentServOff_ID").HeaderText = "Parent ID"
                Dim ultraGridColumn As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("ServOff_Name")
                Dim unit As System.Web.UI.WebControls.Unit = New System.Web.UI.WebControls.Unit("200px")
                ultraGridColumn.Width = unit
                Dim ultraGridColumn1 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("ServOff_Name")
                unit = New System.Web.UI.WebControls.Unit("156px")
                ultraGridColumn1.Width = unit
                Dim ultraGridColumn2 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("ServOff_ID")
                unit = New System.Web.UI.WebControls.Unit("50px")
                ultraGridColumn2.Width = unit
                Me.UG1.Bands(0).Columns.FromKey("ServOff_ID").Hidden = True
                Me.UG1.Bands(0).Columns.FromKey("ServOff_ID").HeaderText = "ID"
                Dim ultraGridColumn3 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("ServOff_ID")
                unit = New System.Web.UI.WebControls.Unit("60px")
                ultraGridColumn3.Width = unit
                Me.UG1.Bands(0).Columns.FromKey("Active").Type = ColumnType.CheckBox
                Me.UG1.Bands(1).Columns.FromKey("Active").Type = ColumnType.CheckBox
                Dim ultraGridColumn4 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Active")
                unit = New System.Web.UI.WebControls.Unit("60px")
                ultraGridColumn4.Width = unit
                Dim ultraGridColumn5 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Active")
                unit = New System.Web.UI.WebControls.Unit("60px")
                ultraGridColumn5.Width = unit
                Me.UG1.Bands(0).Columns.FromKey("Tax").Type = ColumnType.CheckBox
                Me.UG1.Bands(1).Columns.FromKey("Tax").Type = ColumnType.CheckBox
                Dim ultraGridColumn6 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Tax")
                unit = New System.Web.UI.WebControls.Unit("50px")
                ultraGridColumn6.Width = unit
                Dim ultraGridColumn7 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Tax")
                unit = New System.Web.UI.WebControls.Unit("50px")
                ultraGridColumn7.Width = unit
                Me.UG1.Bands(0).Columns.FromKey("Pricing").Type = ColumnType.CheckBox
                Me.UG1.Bands(1).Columns.FromKey("Pricing").Type = ColumnType.CheckBox
                Dim ultraGridColumn8 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Pricing")
                unit = New System.Web.UI.WebControls.Unit("70px")
                ultraGridColumn8.Width = unit
                Dim ultraGridColumn9 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Pricing")
                unit = New System.Web.UI.WebControls.Unit("70px")
                ultraGridColumn9.Width = unit
                Dim ultraGridColumn10 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(0).Columns.FromKey("Grouping")
                unit = New System.Web.UI.WebControls.Unit("90px")
                ultraGridColumn10.Width = unit
                Dim ultraGridColumn11 As Infragistics.WebUI.UltraWebGrid.UltraGridColumn = Me.UG1.Bands(1).Columns.FromKey("Grouping")
                unit = New System.Web.UI.WebControls.Unit("90px")
                ultraGridColumn11.Width = unit
                Me.UG1.Bands(1).Columns.FromKey("ParentServOff_ID").Hidden = True
                Me.UG1.Bands(1).Columns.FromKey("ServOff_Name").CellStyle.BackColor = (Color.Gainsboro())
                Me.UG1.Bands(0).Columns.FromKey("ServOff_Name").CellStyle.BackColor = (Color.Gainsboro())
                Me.UG1.Bands(0).Columns.FromKey("Pricing").CellStyle.BackColor = (Color.Gainsboro())
                Me.UG1.Bands(1).Columns.FromKey("Pricing").CellStyle.BackColor = (Color.Gainsboro())
                Me.UG1.Bands(0).Columns.FromKey("Active").CellStyle.BackColor = (Color.Gainsboro())
                Me.UG1.Bands(1).Columns.FromKey("Active").CellStyle.BackColor = (Color.Gainsboro())
                Me.UG1.Bands(0).Columns.FromKey("Grouping").Type = ColumnType.DropDownList
                Me.UG1.Bands(1).Columns.FromKey("Grouping").Type = ColumnType.DropDownList
                Dim valueList As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(0).Columns.FromKey("Grouping").ValueList
                valueList.ValueListItems.Add(New ValueListItem())
                valueList.ValueListItems.Add(New ValueListItem())
                valueList.ValueListItems.Add(New ValueListItem())
                valueList.ValueListItems.Add(New ValueListItem())
                valueList.ValueListItems(0).DisplayText = "1"
                valueList.ValueListItems(1).DisplayText = "2"
                valueList.ValueListItems(2).DisplayText = "3"
                valueList.ValueListItems(3).DisplayText = "4"
                Dim valueList1 As Infragistics.WebUI.UltraWebGrid.ValueList = Me.UG1.Bands(1).Columns.FromKey("Grouping").ValueList
                valueList1.ValueListItems.Add(New ValueListItem())
                valueList1.ValueListItems.Add(New ValueListItem())
                valueList1.ValueListItems.Add(New ValueListItem())
                valueList1.ValueListItems.Add(New ValueListItem())
                valueList1.ValueListItems(0).DisplayText = "1"
                valueList1.ValueListItems(1).DisplayText = "2"
                valueList1.ValueListItems(2).DisplayText = "3"
                valueList1.ValueListItems(3).DisplayText = "4"
            End If
        End Sub

        Private Sub UG1_PageIndexChanged(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebGrid.PageEventArgs) Handles UG1.PageIndexChanged
            Me.UG1.DataBind()
        End Sub

        Private Sub UG1_UpdateCellBatch(ByVal sender As Object, ByVal e As CellEventArgs) Handles UG1.UpdateCellBatch
            If (ObjectType.ObjTst(e.Cell.Row.DataKey, Nothing, False) <> 0) Then
                Me.lblErrorMsg.Text = ("")
                Dim num As Integer = IntegerType.FromObject(e.Cell.Row.Cells.FromKey("Pricing").Value)
                Dim num1 As Integer = IntegerType.FromObject(e.Cell.Row.Cells.FromKey("Active").Value)
                Dim num2 As Integer = IntegerType.FromObject(e.Cell.Row.Cells.FromKey("Tax").Value)
                Dim num3 As Integer = CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(e.Cell.Row.Cells.FromKey("Grouping").Value))))
                Dim num4 As Integer = CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(e.Cell.Row.Cells.FromKey("Position").Value))))
                Dim str As String = StringType.FromObject(e.Cell.Row.Cells.FromKey("ServOff_Name").Value)
                Dim num5 As Integer = IntegerType.FromObject(e.Cell.Row.Cells.FromKey("ServOff_ID").Value)
                Dim messageHelper As SystemFramework.MessageHelper = UCCTask.updateServOff(num5, str, num1, num2, num, num3, num4)
                If (Not messageHelper.status) Then
                    Me.lblErrorMsg.Text = (messageHelper.messageText)
                End If
            End If
        End Sub

        Private Sub UG1_UpdateGrid(ByVal sender As Object, ByVal e As UpdateEventArgs) Handles UG1.UpdateGrid
            Dim num As Integer
            Dim messageHelper As SystemFramework.MessageHelper
            Dim str As String = Nothing
            Dim text As String
            Dim str1 As String = Nothing
            Dim enumerator As IEnumerator = Nothing
            Dim num1 As Integer = 0
            Dim num2 As Integer = 0
            Dim num3 As Integer = 0
            Dim num4 As Integer = 0
            Dim num5 As Integer = 0
            Me.ctr = 1
            Me.AssignDataSource()
            Dim batchUpdates As Infragistics.WebUI.UltraWebGrid.UltraGridRowsEnumerator = Nothing
            Dim ultraGridRowsEnumerator As Infragistics.WebUI.UltraWebGrid.UltraGridRowsEnumerator = Nothing
            If (e.Grid.Rows.Count() > 0) Then
                Dim item As System.Data.DataTable = Me.tasksDataSet1.Tables().Item("Primary")
                batchUpdates = Me.UG1.Bands(0).GetBatchUpdates()
                Dim dataTable As System.Data.DataTable = Me.tasksDataSet1.Tables().Item("Secondary")
                ultraGridRowsEnumerator = Me.UG1.Bands(1).GetBatchUpdates()
                While batchUpdates.MoveNext()
                    Dim current As Infragistics.WebUI.UltraWebGrid.UltraGridRow = batchUpdates.Current
                    If (current.IsChild(current) OrElse current.DataChanged <> DataChanged.Added) Then
                        Continue While
                    End If
                    Me.lblErrorMsg.Text = ("")
                    item.NewRow()
                    Dim count As Integer = current.Cells.Count() - 1
                    num = 0
                    Do
                        text = current.Cells(num).GetText()
                        If (num = 1) Then
                            str1 = text
                        ElseIf (num = 2) Then
                            num5 = CInt(Math.Round(Conversion.Val(text)))
                        ElseIf (num = 3) Then
                            num4 = CInt(Math.Round(Conversion.Val(text)))
                        ElseIf (num = 4) Then
                            num2 = CInt(Math.Round(Conversion.Val(text)))
                        ElseIf (num = 5) Then
                            num3 = CInt(Math.Round(Conversion.Val(text)))
                        ElseIf (num = 6) Then
                            num1 = CInt(Math.Round(Conversion.Val(text)))
                        End If
                        num = num + 1
                    Loop While num <= count
                    If (ObjectType.ObjTst(current.DataKey, Nothing, False) <> 0) Then
                        Continue While
                    End If
                    messageHelper = UCCTask.createParentServOff(str1, num1, num5, num4, num2, num3)
                    If (messageHelper.status) Then
                        current.DataKey = RuntimeHelpers.GetObjectValue(messageHelper.messageObject)
                    Else
                        Me.lblErrorMsg.Text = (messageHelper.messageText)
                    End If
                End While
                While ultraGridRowsEnumerator.MoveNext()
                    Dim objectValue As Infragistics.WebUI.UltraWebGrid.UltraGridRow = ultraGridRowsEnumerator.Current
                    If (objectValue.DataChanged <> DataChanged.Added) Then
                        Continue While
                    End If
                    dataTable.NewRow()
                    Dim count1 As Integer = objectValue.Cells.Count() - 1
                    num = 0
                    Do
                        text = objectValue.Cells(num).GetText()
                        If (num = 2) Then
                            str1 = text
                            Dim count2 As Integer = e.Grid.Rows.Count() - 1
                            For i As Integer = 0 To count2 Step 1
                                If (e.Grid.Rows(i).HasChildRows) Then
                                    Try
                                        enumerator = e.Grid.Rows(i).Rows.GetEnumerator()
                                        While enumerator.MoveNext()
                                            Dim ultraGridRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = DirectCast(enumerator.Current(), Infragistics.WebUI.UltraWebGrid.UltraGridRow)
                                            If (StringType.StrCmp(ultraGridRow.Cells.FromKey("ServOff_Name").Value.ToString(), str1, False) <> 0) Then
                                                Continue While
                                            End If
                                            str = StringType.FromObject(ultraGridRow.ParentRow.Cells.FromKey("ServOff_Name").Value)
                                        End While
                                    Finally
                                        If (TypeOf enumerator Is IDisposable) Then
                                            DirectCast(enumerator, IDisposable).Dispose()
                                        End If
                                    End Try
                                End If
                            Next

                        ElseIf (num = 3) Then
                            num5 = CInt(Math.Round(Conversion.Val(text)))
                        ElseIf (num = 4) Then
                            num4 = CInt(Math.Round(Conversion.Val(text)))
                        ElseIf (num = 5) Then
                            num2 = CInt(Math.Round(Conversion.Val(text)))
                        ElseIf (num = 6) Then
                            num3 = CInt(Math.Round(Conversion.Val(text)))
                        ElseIf (num = 7) Then
                            num1 = CInt(Math.Round(Conversion.Val(text)))
                        End If
                        num = num + 1
                    Loop While num <= count1
                    If (ObjectType.ObjTst(objectValue.DataKey, Nothing, False) <> 0) Then
                        Continue While
                    End If
                    messageHelper = UCCTask.createChildServOff(str1, str, num1, num5, num4, num2, num3)
                    If (messageHelper.status) Then
                        objectValue.DataKey = RuntimeHelpers.GetObjectValue(messageHelper.messageObject)
                    Else
                        Me.lblErrorMsg.Text = (messageHelper.messageText)
                    End If
                End While
            End If
        End Sub
    End Class
End Namespace