Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace wdw
    Public Class Schedule

        Inherits PageBase
        '<AccessedThroughProperty("UWGNeverSched")>
        'Private _UWGNeverSched As UltraWebGrid

        '<AccessedThroughProperty("UWGPriorSched")>
        'Private _UWGPriorSched As UltraWebGrid

        'Protected ClientSearch1 As clientSearch

        'Protected SchedGrid1 As schedGrid

        Private rdr As DataSet

        Private rdr1 As DataSet

        Private uccSchedule As UCCSchedule

        'Protected Overridable Property UWGNeverSched As UltraWebGrid
        '    Get
        '        Return Me._UWGNeverSched
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UWGNeverSched IsNot Nothing) Then
        '            Dim schedule As wdw.Schedule = Me
        '            RemoveHandler Me._UWGNeverSched.InitializeRow, New InitializeRowEventHandler(AddressOf schedule.UWGNeverSched_InitializeRow)
        '            Dim schedule1 As wdw.Schedule = Me
        '            RemoveHandler Me._UWGNeverSched.InitializeLayout, New InitializeLayoutEventHandler(AddressOf schedule1.UWGNeverSched_InitializeLayout)
        '        End If
        '        Me._UWGNeverSched = value
        '        If (Me._UWGNeverSched IsNot Nothing) Then
        '            Dim schedule2 As wdw.Schedule = Me
        '            AddHandler Me._UWGNeverSched.InitializeRow, New InitializeRowEventHandler(AddressOf schedule2.UWGNeverSched_InitializeRow)
        '            Dim schedule3 As wdw.Schedule = Me
        '            AddHandler Me._UWGNeverSched.InitializeLayout, New InitializeLayoutEventHandler(AddressOf schedule3.UWGNeverSched_InitializeLayout)
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property UWGPriorSched As UltraWebGrid
        '    Get
        '        Return Me._UWGPriorSched
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UWGPriorSched IsNot Nothing) Then
        '            Dim schedule As wdw.Schedule = Me
        '            RemoveHandler Me._UWGPriorSched.InitializeRow, New InitializeRowEventHandler(AddressOf schedule.UWGPriorSched_InitializeRow)
        '            Dim schedule1 As wdw.Schedule = Me
        '            RemoveHandler Me._UWGPriorSched.InitializeLayout, New InitializeLayoutEventHandler(AddressOf schedule1.UWGPriorSched_InitializeLayout)
        '        End If
        '        Me._UWGPriorSched = value
        '        If (Me._UWGPriorSched IsNot Nothing) Then
        '            Dim schedule2 As wdw.Schedule = Me
        '            AddHandler Me._UWGPriorSched.InitializeRow, New InitializeRowEventHandler(AddressOf schedule2.UWGPriorSched_InitializeRow)
        '            Dim schedule3 As wdw.Schedule = Me
        '            AddHandler Me._UWGPriorSched.InitializeLayout, New InitializeLayoutEventHandler(AddressOf schedule3.UWGPriorSched_InitializeLayout)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim schedule1 As Schedule = Me
            'MyBase.add_Init(New EventHandler(schedule1, schedule1.Page_Init))
            Dim schedule2 As Schedule = Me
            'MyBase.add_Load(New EventHandler(schedule2, schedule2.Page_Load))
            Me.uccSchedule = New UCCSchedule()
        End Sub

        Public Function buildFirstName(ByVal e As RowEventArgs) As String
            If (Not BooleanType.FromObject(ObjectType.BitAndObj(Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("OccClient_ID").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("OccClient_ID").Value, 0, False) > 0))) Then
                If (BooleanType.FromObject(ObjectType.BitOrObj(Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("BillClient_ID").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("BillClient_ID").Value, 0, False) = 0))) Then
                    Return ""
                End If
                Return StringType.FromObject(e.Row.Cells.FromKey("Bill_First").Value)
            End If
            If (Not BooleanType.FromObject(ObjectType.BitAndObj(Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("Occ_Last").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("OccClient_ID").Value, 0, False) > 0))) Then
                Return "DATAFIX"
            End If
            Return StringType.FromObject(e.Row.Cells.FromKey("Occ_First").Value)
        End Function

        Public Function buildLastName(ByVal e As RowEventArgs) As String
            If (Not BooleanType.FromObject(ObjectType.BitAndObj(Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("OccClient_ID").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("OccClient_ID").Value, 0, False) > 0))) Then
                If (BooleanType.FromObject(ObjectType.BitOrObj(Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("BillClient_ID").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("BillClient_ID").Value, 0, False) = 0))) Then
                    Return "Resident"
                End If
                Return StringType.FromObject(e.Row.Cells.FromKey("Bill_Last").Value)
            End If
            If (Not BooleanType.FromObject(ObjectType.BitAndObj(Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("Occ_Last").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("OccClient_ID").Value, 0, False) > 0))) Then
                Return "DATAFIX"
            End If
            Return StringType.FromObject(e.Row.Cells.FromKey("Occ_Last").Value)
        End Function

        Public Function buildPhone(ByVal e As RowEventArgs) As String
            Dim objArray As Object()
            Dim objArray1 As Object()
            Dim objArray2 As Object()
            If (Not BooleanType.FromObject(ObjectType.BitAndObj(Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("OccClient_ID").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("OccClient_ID").Value, 0, False) > 0))) Then
                If (BooleanType.FromObject(ObjectType.BitOrObj(ObjectType.BitOrObj(Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("BillClient_ID").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("BillClient_ID").Value, 0, False) = 0), ObjectType.ObjTst(e.Row.Cells.FromKey("Bill_Phone").Value, "", False) = 0))) Then
                    Return ""
                End If
                Dim value As Object = e.Row.Cells.FromKey("Bill_Phone").Value
                objArray = New Object() {0, 3}
                Dim obj As Object = ObjectType.AddObj(LateBinding.LateGet(value, Nothing, "SubString", objArray, Nothing, Nothing), " ")
                Dim value1 As Object = e.Row.Cells.FromKey("Bill_Phone").Value
                objArray1 = New Object() {3, 3}
                Dim obj1 As Object = ObjectType.AddObj(ObjectType.AddObj(obj, LateBinding.LateGet(value1, Nothing, "SubString", objArray1, Nothing, Nothing)), "-")
                Dim value2 As Object = e.Row.Cells.FromKey("Bill_Phone").Value
                objArray2 = New Object() {6, 4}
                Return StringType.FromObject(ObjectType.AddObj(obj1, LateBinding.LateGet(value2, Nothing, "SubString", objArray2, Nothing, Nothing)))
            End If
            If (Not BooleanType.FromObject(ObjectType.BitAndObj(ObjectType.BitAndObj(Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(e.Row.Cells.FromKey("Occ_Last").Value)), ObjectType.ObjTst(e.Row.Cells.FromKey("OccClient_ID").Value, 0, False) > 0), ObjectType.ObjTst(e.Row.Cells.FromKey("Occ_Phone").Value, "", False) <> 0))) Then
                Return ""
            End If
            Dim obj2 As Object = e.Row.Cells.FromKey("Occ_Phone").Value
            objArray2 = New Object() {0, 3}
            Dim obj3 As Object = ObjectType.AddObj(LateBinding.LateGet(obj2, Nothing, "SubString", objArray2, Nothing, Nothing), " ")
            Dim value3 As Object = e.Row.Cells.FromKey("Occ_Phone").Value
            objArray1 = New Object() {3, 3}
            Dim obj4 As Object = ObjectType.AddObj(ObjectType.AddObj(obj3, LateBinding.LateGet(value3, Nothing, "SubString", objArray1, Nothing, Nothing)), "-")
            Dim value4 As Object = e.Row.Cells.FromKey("Occ_Phone").Value
            objArray = New Object() {6, 4}
            Return StringType.FromObject(ObjectType.AddObj(obj4, LateBinding.LateGet(value4, Nothing, "SubString", objArray, Nothing, Nothing)))
        End Function

        '<DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("ScheduleState")
        End Function

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("ScheduleState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub

        Private Sub UWGNeverSched_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UWGNeverSched.InitializeLayout
            Dim layout As UltraGridLayout = e.Layout
            layout.Bands(0).Columns.FromKey("OccClient_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("OccClient_ID").ServerOnly = True
            layout.Bands(0).Columns.FromKey("BillClient_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("BillClient_ID").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Bill_Last").Hidden = True
            layout.Bands(0).Columns.FromKey("Bill_Last").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Bill_First").Hidden = True
            layout.Bands(0).Columns.FromKey("Bill_First").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Site_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("Site_ID").ServerOnly = True
            layout.Bands(0).Columns.FromKey("No_Stories").Hidden = True
            layout.Bands(0).Columns.FromKey("No_Stories").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Address_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("Address_ID").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Address1").Hidden = True
            layout.Bands(0).Columns.FromKey("Address1").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Job_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("critical").Hidden = True
            layout.Bands(0).Columns.FromKey("critical").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Reminder").Hidden = True
            layout.Bands(0).Columns.FromKey("Reminder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Status").Hidden = True
            layout.Bands(0).Columns.FromKey("Status").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Outside_Only").Hidden = True
            layout.Bands(0).Columns.FromKey("Outside_Only").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Job_Description").Hidden = True
            layout.Bands(0).Columns.FromKey("Job_Description").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Bill_Phone").Hidden = True
            layout.Bands(0).Columns.FromKey("Bill_Phone").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Modified_Date").Hidden = True
            layout.Bands(0).Columns.FromKey("Modified_Date").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Status").Hidden = True
            layout.Bands(0).Columns.FromKey("Status").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Cancel_Reason").Hidden = True
            layout.Bands(0).Columns.FromKey("Cancel_Reason").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Prev_Cust").Hidden = True
            layout.Bands(0).Columns.FromKey("Prev_Cust").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Note_Type").Hidden = True
            layout.Bands(0).Columns.FromKey("Note_Type").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Start_Date").Move(0)
            layout.Bands(0).Columns.FromKey("Schedule_Amount").Move(1)
            layout.Bands(0).Columns.FromKey("Occ_Last").Move(2)
            layout.Bands(0).Columns.FromKey("Occ_First").Move(3)
            layout.Bands(0).Columns.FromKey("ZipCode").Move(4)
            layout.Bands(0).Columns.FromKey("Occ_Phone").Move(5)
            layout.Bands(0).Columns.FromKey("Schedule_Amount").CellStyle.HorizontalAlign = 3
            layout.Bands(0).Columns.FromKey("Start_Date").Width = Unit.Percentage(25)
            layout.Bands(0).Columns.FromKey("Schedule_Amount").Width = Unit.Percentage(10)
            layout.Bands(0).Columns.FromKey("Occ_Last").Width = Unit.Percentage(18)
            layout.Bands(0).Columns.FromKey("Occ_First").Width = Unit.Percentage(12)
            layout.Bands(0).Columns.FromKey("ZipCode").Width = Unit.Percentage(10)
            layout.Bands(0).Columns.FromKey("Occ_Phone").Width = Unit.Percentage(25)
            layout.Bands(0).Columns.FromKey("Start_Date").Format = "MM/dd/yy HH"
            layout = Nothing
        End Sub

        Private Sub UWGNeverSched_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGNeverSched.InitializeRow
            If (ObjectType.ObjTst(e.Row.Cells.FromKey("Prev_Cust").Value, "2", False) = 0) Then
                e.Row.Style.BorderColor = (Color.LightCoral())
            End If
            e.Row.Cells.FromKey("Occ_Last").Value = Me.buildLastName(e)
            e.Row.Cells.FromKey("Occ_First").Value = Me.buildFirstName(e)
            e.Row.Cells.FromKey("Occ_Phone").Value = Me.buildPhone(e)
            Dim str As String = StringType.FromObject(e.Row.Cells.FromKey("ZipCode").Value)
            If (str.Length > 3) Then
                e.Row.Cells.FromKey("ZipCode").Value = str.Substring(2, 3)
            Else
                e.Row.Cells.FromKey("ZipCode").Value = str
            End If

            If (ObjectType.ObjTst(e.Row.Cells.FromKey("critical").Value, "1", False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.LightCoral())
            End If
            If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("Start_Date").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.LightGreen())
            ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("Start_Date").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.LightPink())
            ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("Start_Date").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.Yellow())
            ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("Start_Date").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.Orange())
            End If
            If (IntegerType.FromObject(e.Row.Cells.FromKey("No_Stories").Value) > 2) Then
                e.Row.Cells.FromKey("ZipCode").Style.BackColor = (Color.Magenta())
            End If
            e.Row.Cells.FromKey("Schedule_Amount").Value = IntegerType.FromObject(e.Row.Cells.FromKey("Schedule_Amount").Value)
            If (IntegerType.FromObject(e.Row.Cells.FromKey("Reminder").Value) = 1) Then
                e.Row.Cells.FromKey("Schedule_Amount").Style.BackColor = (Color.CornflowerBlue())
            End If
            If (IntegerType.FromObject(e.Row.Cells.FromKey("Note_Type").Value) = 1) Then
                e.Row.Cells.FromKey("Occ_Last").Style.BackColor = (Color.LightCoral())
            End If

            If (ObjectType.ObjTst(e.Row.Cells.FromKey("Job_ID").Value, Me.SchedGrid1.getNeverActiveJobId, False) = 0) Then
                e.Row.Activate()
            End If
        End Sub

        Private Sub UWGPriorSched_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UWGPriorSched.InitializeLayout
            Dim layout As UltraGridLayout = e.Layout
            layout.Bands(0).Columns.FromKey("OccClient_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("OccClient_ID").ServerOnly = True
            layout.Bands(0).Columns.FromKey("BillClient_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("BillClient_ID").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Bill_Last").Hidden = True
            layout.Bands(0).Columns.FromKey("Bill_Last").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Bill_First").Hidden = True
            layout.Bands(0).Columns.FromKey("Bill_First").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Site_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("Site_ID").ServerOnly = True
            layout.Bands(0).Columns.FromKey("No_Stories").Hidden = True
            layout.Bands(0).Columns.FromKey("No_Stories").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Address_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("Address_ID").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Address1").Hidden = True
            layout.Bands(0).Columns.FromKey("Address1").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Job_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("critical").Hidden = True
            layout.Bands(0).Columns.FromKey("critical").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Reminder").Hidden = True
            layout.Bands(0).Columns.FromKey("Reminder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Status").Hidden = True
            layout.Bands(0).Columns.FromKey("Status").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Outside_Only").Hidden = True
            layout.Bands(0).Columns.FromKey("Outside_Only").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Job_Description").Hidden = True
            layout.Bands(0).Columns.FromKey("Job_Description").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Bill_Phone").Hidden = True
            layout.Bands(0).Columns.FromKey("Bill_Phone").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Modified_Date").Hidden = True
            layout.Bands(0).Columns.FromKey("Modified_Date").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Status").Hidden = True
            layout.Bands(0).Columns.FromKey("Status").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Cancel_Reason").Hidden = True
            layout.Bands(0).Columns.FromKey("Cancel_Reason").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Prev_Cust").Hidden = True
            layout.Bands(0).Columns.FromKey("Prev_Cust").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Note_Type").Hidden = True
            layout.Bands(0).Columns.FromKey("Note_Type").ServerOnly = True
            layout.Bands(0).Columns.FromKey("Start_Date").Move(0)
            layout.Bands(0).Columns.FromKey("Schedule_Amount").Move(1)
            layout.Bands(0).Columns.FromKey("Occ_Last").Move(2)
            layout.Bands(0).Columns.FromKey("Occ_First").Move(3)
            layout.Bands(0).Columns.FromKey("ZipCode").Move(4)
            layout.Bands(0).Columns.FromKey("Occ_Phone").Move(5)
            layout.Bands(0).Columns.FromKey("Schedule_Amount").CellStyle.HorizontalAlign = 3
            layout.Bands(0).Columns.FromKey("Start_Date").Width = Unit.Percentage(25)
            layout.Bands(0).Columns.FromKey("Schedule_Amount").Width = Unit.Percentage(10)
            layout.Bands(0).Columns.FromKey("Occ_Last").Width = Unit.Percentage(18)
            layout.Bands(0).Columns.FromKey("Occ_First").Width = Unit.Percentage(12)
            layout.Bands(0).Columns.FromKey("ZipCode").Width = Unit.Percentage(10)
            layout.Bands(0).Columns.FromKey("Occ_Phone").Width = Unit.Percentage(25)
            layout.Bands(0).Columns.FromKey("Start_Date").Format = "MM/dd/yy HH"
            layout = Nothing
        End Sub

        Private Sub UWGPriorSched_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGPriorSched.InitializeRow
            If (ObjectType.ObjTst(e.Row.Cells.FromKey("Prev_Cust").Value, "2", False) = 0) Then
                e.Row.Style.BorderColor = (Color.LightCoral())
            End If
            e.Row.Cells.FromKey("Occ_Last").Value = Me.buildLastName(e)
            e.Row.Cells.FromKey("Occ_First").Value = Me.buildFirstName(e)
            e.Row.Cells.FromKey("Occ_Phone").Value = Me.buildPhone(e)
            Dim str As String = StringType.FromObject(e.Row.Cells.FromKey("ZipCode").Value)
            e.Row.Cells.FromKey("ZipCode").Value = str.Substring(2, 3)
            If (ObjectType.ObjTst(e.Row.Cells.FromKey("critical").Value, "1", False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.LightCoral())
            End If
            If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("Start_Date").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.LightGreen())
            ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("Start_Date").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.LightPink())
            ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("Start_Date").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.Yellow())
            ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("Start_Date").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                e.Row.Cells.FromKey("Start_Date").Style.BackColor = (Color.Orange())
            End If
            If (IntegerType.FromObject(e.Row.Cells.FromKey("No_Stories").Value) > 2) Then
                e.Row.Cells.FromKey("ZipCode").Style.BackColor = (Color.Magenta())
            End If
            e.Row.Cells.FromKey("Schedule_Amount").Value = IntegerType.FromObject(e.Row.Cells.FromKey("Schedule_Amount").Value)
            If (IntegerType.FromObject(e.Row.Cells.FromKey("Reminder").Value) = 1) Then
                e.Row.Cells.FromKey("Schedule_Amount").Style.BackColor = (Color.CornflowerBlue())
            End If
            If (IntegerType.FromObject(e.Row.Cells.FromKey("Note_Type").Value) = 1) Then
                e.Row.Cells.FromKey("Occ_Last").Style.BackColor = (Color.LightCoral())
            End If
            Dim schedGrid1 As Integer = Me.SchedGrid1.getPriorActiveJobId
            If (ObjectType.ObjTst(e.Row.Cells.FromKey("Job_ID").Value, schedGrid1, False) = 0) Then
                e.Row.Activate()
            End If
        End Sub
    End Class
End Namespace