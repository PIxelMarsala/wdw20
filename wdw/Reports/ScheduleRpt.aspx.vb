Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Infragistics.WebUI.WebSchedule
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Strings = Microsoft.VisualBasic.Strings

Namespace wdw
    Public Class ScheduleRpt
        Inherits PageBase
        '<AccessedThroughProperty("Label2")>
        'Private _Label2 As Label

        '<AccessedThroughProperty("WebDateChooserFrom")>
        'Private _WebDateChooserFrom As WebDateChooser

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("lblErrorMsg")>
        'Private _lblErrorMsg As Label

        '<AccessedThroughProperty("UWGScheduleRpt")>
        'Private _UWGScheduleRpt As UltraWebGrid

        '<AccessedThroughProperty("WebDateChooserTo")>
        'Private _WebDateChooserTo As WebDateChooser

        Private savRptDate As DateTime

        Private savSub As String

        Private designerPlaceholderDeclaration As Object

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

        'Protected Overridable Property Label2 As Label
        '    Get
        '        Return Me._Label2
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label2 Is Nothing
        '        Me._Label2 = value
        '        Me._Label2 Is Nothing
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

        'Protected Overridable Property UWGScheduleRpt As UltraWebGrid
        '    Get
        '        Return Me._UWGScheduleRpt
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UWGScheduleRpt IsNot Nothing) Then
        '            Dim scheduleRpt As wdw.ScheduleRpt = Me
        '            RemoveHandler Me._UWGScheduleRpt.InitializeRow, New InitializeRowEventHandler(AddressOf scheduleRpt.UWGScheduleRpt_InitializeRow)
        '            Dim scheduleRpt1 As wdw.ScheduleRpt = Me
        '            RemoveHandler Me._UWGScheduleRpt.InitializeLayout, New InitializeLayoutEventHandler(AddressOf scheduleRpt1.UWGScheduleRpt_InitializeLayout)
        '        End If
        '        Me._UWGScheduleRpt = value
        '        If (Me._UWGScheduleRpt IsNot Nothing) Then
        '            Dim scheduleRpt2 As wdw.ScheduleRpt = Me
        '            AddHandler Me._UWGScheduleRpt.InitializeRow, New InitializeRowEventHandler(AddressOf scheduleRpt2.UWGScheduleRpt_InitializeRow)
        '            Dim scheduleRpt3 As wdw.ScheduleRpt = Me
        '            AddHandler Me._UWGScheduleRpt.InitializeLayout, New InitializeLayoutEventHandler(AddressOf scheduleRpt3.UWGScheduleRpt_InitializeLayout)
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property WebDateChooserFrom As WebDateChooser
        '    Get
        '        Return Me._WebDateChooserFrom
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As WebDateChooser)
        '        Me._WebDateChooserFrom Is Nothing
        '        Me._WebDateChooserFrom = value
        '        Me._WebDateChooserFrom Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property WebDateChooserTo As WebDateChooser
        '    Get
        '        Return Me._WebDateChooserTo
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As WebDateChooser)
        '        Me._WebDateChooserTo Is Nothing
        '        Me._WebDateChooserTo = value
        '        Me._WebDateChooserTo Is Nothing
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim scheduleRpt1 As ScheduleRpt = Me
            'MyBase.add_Init(New EventHandler(scheduleRpt1, scheduleRpt1.Page_Init))
            Dim scheduleRpt2 As ScheduleRpt = Me
            'MyBase.add_Load(New EventHandler(scheduleRpt2, scheduleRpt2.Page_Load))
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Private Sub loadSchedule()
            Dim job As BusinessService.Job = New BusinessService.Job()
            Me.lblErrorMsg.Visible = (False)
            Dim dateTime As System.DateTime = DateType.FromObject(Me.WebDateChooserFrom.Value)
            Dim dateTime1 As System.DateTime = DateType.FromObject(Me.WebDateChooserTo.Value)
            If (System.DateTime.Compare(dateTime1, dateTime) < 0) Then
                Me.lblErrorMsg.Text = ("End Date Before Begin Date")
                Me.lblErrorMsg.Visible = (True)
            Else
                Dim dateTime2 As System.DateTime = New System.DateTime(dateTime.Year(), dateTime.Month(), dateTime.Day(), 0, 0, 1)
                Dim dateTime3 As System.DateTime = New System.DateTime(dateTime1.Year(), dateTime1.Month(), dateTime1.Day(), 23, 59, 59)
                Dim jobBySubByDateRange As SqlDataReader = job.getJobBySubByDateRange(dateTime2, dateTime3)
                Me.UWGScheduleRpt.DisplayLayout.ViewType = ViewType.Flat
                Me.UWGScheduleRpt.DataSource = (jobBySubByDateRange)
                Me.UWGScheduleRpt.DataBind()
                Me.UWGScheduleRpt.DisplayLayout.TableLayout = TableLayout.Fixed
                If (Me.UWGScheduleRpt.Rows.Count() = 0) Then
                    Me.lblErrorMsg.Text = ("Not Data For Selected Range")
                    Me.lblErrorMsg.Visible = (True)
                End If
                jobBySubByDateRange.Close()
            End If
        End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If (Me.Page().IsPostBack()) Then
                Me.loadSchedule()
            Else
                Me.WebDateChooserFrom.Value = DateTime.Now()
                Dim webDateChooserTo As WebDateChooser = Me.WebDateChooserTo
                Dim now As DateTime = DateTime.Now()
                webDateChooserTo.Value = now.AddDays(14)
                Me.loadSchedule()
            End If
        End Sub

        Private Sub UWGScheduleRpt_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UWGScheduleRpt.InitializeLayout
            Dim layout As UltraGridLayout = e.Layout
            layout.Bands(0).Columns.FromKey("Bill_Last").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Bill_Phone").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Outside_Only").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Bill_Phone").Hidden = True
            layout.Bands(0).Columns.FromKey("Outside_Only").Hidden = True
            layout.Bands(0).Columns.FromKey("Bill_Last").Hidden = True
            layout.Bands(0).Columns.FromKey("Year").Hidden = True
            layout.Bands(0).Columns.FromKey("Year").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Month").Hidden = True
            layout.Bands(0).Columns.FromKey("Month").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Day").Hidden = True
            layout.Bands(0).Columns.FromKey("Day").ServerOnly = True
            layout.Bands(0).Columns.Insert(7, "CT")
            layout.Bands(0).Columns.FromKey("CT").HeaderText = "  "
            layout.Bands(0).Columns.FromKey("CT").HeaderStyle.BorderStyle = (9)
            layout.Bands(0).Columns.FromKey("Hour").CellStyle.HorizontalAlign = 3
            layout.Bands(0).Columns.FromKey("No_Stories").CellStyle.HorizontalAlign = 2
            layout.Bands(0).Columns.FromKey("Schedule_Amount").CellStyle.HorizontalAlign = 3
            layout.Bands(0).Columns.FromKey("Hour").HeaderText = "Time"
            layout.Bands(0).Columns.FromKey("No_Stories").HeaderText = "Ht"
            layout.Bands(0).Columns.FromKey("RptDate").HeaderText = "Date"
            layout.Bands(0).Columns.FromKey("Schedule_Amount").HeaderText = "Amt"
            layout.Bands(0).Columns.FromKey("Address1").HeaderText = "Address"
            layout.Bands(0).Columns.FromKey("Occ_Last").HeaderText = "Name"
            layout.Bands(0).Columns.FromKey("Occ_Phone").HeaderText = "Phone"
            layout.Bands(0).Columns.FromKey("Nick_Name").HeaderText = "Sub"
            layout.Bands(0).Columns.FromKey("ZipCode").HeaderText = "Zip"
            layout.Bands(0).Columns.FromKey("RptDate").Width = Unit.Percentage(5)
            layout.Bands(0).Columns.FromKey("Nick_Name").Width = Unit.Percentage(5)
            layout.Bands(0).Columns.FromKey("CT").Width = Unit.Percentage(3)
            layout.Bands(0).Columns.FromKey("Hour").Width = Unit.Percentage(2)
            layout.Bands(0).Columns.FromKey("Schedule_Amount").Width = Unit.Percentage(4)
            layout.Bands(0).Columns.FromKey("Occ_Last").Width = Unit.Percentage(7)
            layout.Bands(0).Columns.FromKey("ZipCode").Width = Unit.Percentage(3)
            layout.Bands(0).Columns.FromKey("No_Stories").Width = Unit.Percentage(2)
            layout.Bands(0).Columns.FromKey("Occ_Phone").Width = Unit.Percentage(6)
            layout.Bands(0).Columns.FromKey("Address1").Width = Unit.Percentage(15)
            layout.Bands(0).Columns.FromKey("RptDate").Format = "ddd dd-MMM"
            layout = Nothing
        End Sub

        Private Sub UWGScheduleRpt_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGScheduleRpt.InitializeRow
            Dim dateTime As System.DateTime = New System.DateTime(IntegerType.FromObject(e.Row.Cells.FromKey("Year").Value), IntegerType.FromObject(e.Row.Cells.FromKey("Month").Value), IntegerType.FromObject(e.Row.Cells.FromKey("Day").Value), 0, 0, 1)
            e.Row.Cells.FromKey("RptDate").Value = dateTime
            If (ObjectType.ObjTst(Me.savRptDate, e.Row.Cells.FromKey("RptDate").Value, False) <> 0) Then
                Me.savRptDate = DateType.FromObject(e.Row.Cells.FromKey("RptDate").Value)
            Else
                e.Row.Cells.FromKey("RptDate").Style.ForeColor = (Color.White())
            End If
            If (ObjectType.ObjTst(e.Row.Cells.FromKey("Nick_Name").Value, "YYYYYYYY", False) = 0) Then
                e.Row.Cells.FromKey("Nick_Name").Value = "*NEVER*"
            ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("Nick_Name").Value, "ZZZZZZZZ", False) = 0) Then
                e.Row.Cells.FromKey("Nick_Name").Value = "*PRIOR*"
            End If
            If (ObjectType.ObjTst(Me.savSub, e.Row.Cells.FromKey("Nick_Name").Value, False) <> 0) Then
                Me.savSub = StringType.FromObject(e.Row.Cells.FromKey("Nick_Name").Value)
            Else
                e.Row.Cells.FromKey("Nick_Name").Style.ForeColor = (Color.White())
            End If
            If (StringType.StrCmp(Strings.Trim(StringType.FromObject(e.Row.Cells.FromKey("Occ_Last").Value)), "", False) = 0) Then
                If (StringType.StrCmp(Strings.Trim(StringType.FromObject(e.Row.Cells.FromKey("Bill_Last").Value)), "", False) = 0) Then
                    e.Row.Cells.FromKey("Occ_Last").Value = "Resident"
                    e.Row.Cells.FromKey("Occ_Phone").Value = "0000000000"
                Else
                    e.Row.Cells.FromKey("Occ_Last").Value = RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("Bill_Last").Value)
                    e.Row.Cells.FromKey("Occ_Phone").Value = RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("Bill_Phone").Value)
                End If
            End If
            e.Row.Cells.FromKey("Schedule_Amount").Value = IntegerType.FromObject(e.Row.Cells.FromKey("Schedule_Amount").Value)
            Dim objectValue As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("ZipCode")
            Dim value As Object = e.Row.Cells.FromKey("ZipCode").Value
            Dim objArray() As Object = {2, 3}
            objectValue.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(value, Nothing, "SubString", objArray, Nothing, Nothing))
            Dim ultraGridCell As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("Occ_Phone")
            Dim obj As Object = e.Row.Cells.FromKey("Occ_Phone").Value
            objArray = New Object() {0, 3}
            Dim obj1 As Object = ObjectType.AddObj(LateBinding.LateGet(obj, Nothing, "SubString", objArray, Nothing, Nothing), " ")
            Dim value1 As Object = e.Row.Cells.FromKey("Occ_Phone").Value
            Dim objArray1() As Object = {3, 3}
            Dim obj2 As Object = ObjectType.AddObj(ObjectType.AddObj(obj1, LateBinding.LateGet(value1, Nothing, "SubString", objArray1, Nothing, Nothing)), "-")
            Dim value2 As Object = e.Row.Cells.FromKey("Occ_Phone").Value
            Dim objArray2() As Object = {6, 4}
            ultraGridCell.Value = ObjectType.AddObj(obj2, LateBinding.LateGet(value2, Nothing, "SubString", objArray2, Nothing, Nothing))
        End Sub
    End Class
End Namespace