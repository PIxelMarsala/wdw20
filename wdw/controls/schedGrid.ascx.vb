Imports BusinessService
Imports Infragistics.WebUI.UltraWebGrid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework
Imports Strings = Microsoft.VisualBasic.Strings

Namespace wdw
    Public MustInherit Class schedGrid
        Inherits ControlBase

        '<AccessedThroughProperty("txtHiddenNewJobId")>
        'Private _txtHiddenNewJobId As TextBox

        '<AccessedThroughProperty("lstArea")>
        'Private _lstArea As DropDownList

        '<AccessedThroughProperty("btnPrevWeek")>
        'Private _btnPrevWeek As Button

        '<AccessedThroughProperty("UWGSched")>
        'Private _UWGSched As UltraWebGrid

        '<AccessedThroughProperty("btnPrevMo")>
        'Private _btnPrevMo As Button

        '<AccessedThroughProperty("btnNextWeek")>
        'Private _btnNextWeek As Button

        '<AccessedThroughProperty("btnToday")>
        'Private _btnToday As Button

        '<AccessedThroughProperty("lblS")>
        'Private _lblS As Label

        '<AccessedThroughProperty("btnUnSchdJob")>
        'Private _btnUnSchdJob As Button

        '<AccessedThroughProperty("btnNextMo")>
        'Private _btnNextMo As Button

        '<AccessedThroughProperty("UWGDates")>
        'Private _UWGDates As UltraWebGrid

        '<AccessedThroughProperty("txtTime")>
        'Private _txtTime As TextBox

        '<AccessedThroughProperty("btnNewJob")>
        'Private _btnNewJob As Button

        '<AccessedThroughProperty("txtBeginDate")>
        'Private _txtBeginDate As TextBox

        '<AccessedThroughProperty("btnSchedJob")>
        'Private _btnSchedJob As Button

        '<AccessedThroughProperty("lblTime")>
        'Private _lblTime As Label

        Private FUNCTIONNAME As String

        Private UCCSchedule As UCCSchedule

        Private today As DateTime

        Private controlHandled As Boolean

        Private beginDate As DateTime

        Private endDate As DateTime

        Private newJobId As Integer

        Private activeNeverSchedId As Integer

        Private activePriorSchedId As Integer

        Private suDate As DateTime

        Private moDate As DateTime

        Private tuDate As DateTime

        Private weDate As DateTime

        Private thDate As DateTime

        Private frDate As DateTime

        Private saDate As DateTime

        'Protected Overridable Property btnNewJob As Button
        '    Get
        '        Return Me._btnNewJob
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnNewJob IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._btnNewJob.remove_Click(New EventHandler(_schedGrid, _schedGrid.btnNewJob_Click))
        '        End If
        '        Me._btnNewJob = value
        '        If (Me._btnNewJob IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._btnNewJob.add_Click(New EventHandler(_schedGrid1, _schedGrid1.btnNewJob_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnNextMo As Button
        '    Get
        '        Return Me._btnNextMo
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnNextMo IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._btnNextMo.remove_Click(New EventHandler(_schedGrid, _schedGrid.btnNextMo_Click))
        '        End If
        '        Me._btnNextMo = value
        '        If (Me._btnNextMo IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._btnNextMo.add_Click(New EventHandler(_schedGrid1, _schedGrid1.btnNextMo_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnNextWeek As Button
        '    Get
        '        Return Me._btnNextWeek
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnNextWeek IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._btnNextWeek.remove_Click(New EventHandler(_schedGrid, _schedGrid.btnNextWeek_Click))
        '        End If
        '        Me._btnNextWeek = value
        '        If (Me._btnNextWeek IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._btnNextWeek.add_Click(New EventHandler(_schedGrid1, _schedGrid1.btnNextWeek_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnPrevMo As Button
        '    Get
        '        Return Me._btnPrevMo
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnPrevMo IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._btnPrevMo.remove_Click(New EventHandler(_schedGrid, _schedGrid.btnPrevMo_Click))
        '        End If
        '        Me._btnPrevMo = value
        '        If (Me._btnPrevMo IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._btnPrevMo.add_Click(New EventHandler(_schedGrid1, _schedGrid1.btnPrevMo_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnPrevWeek As Button
        '    Get
        '        Return Me._btnPrevWeek
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnPrevWeek IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._btnPrevWeek.remove_Click(New EventHandler(_schedGrid, _schedGrid.btnPrevWeek_Click))
        '        End If
        '        Me._btnPrevWeek = value
        '        If (Me._btnPrevWeek IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._btnPrevWeek.add_Click(New EventHandler(_schedGrid1, _schedGrid1.btnPrevWeek_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnSchedJob As Button
        '    Get
        '        Return Me._btnSchedJob
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnSchedJob IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._btnSchedJob.remove_Click(New EventHandler(_schedGrid, _schedGrid.btnSchedJob_Click))
        '        End If
        '        Me._btnSchedJob = value
        '        If (Me._btnSchedJob IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._btnSchedJob.add_Click(New EventHandler(_schedGrid1, _schedGrid1.btnSchedJob_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnToday As Button
        '    Get
        '        Return Me._btnToday
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnToday IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._btnToday.remove_Click(New EventHandler(_schedGrid, _schedGrid.btnToday_Click))
        '        End If
        '        Me._btnToday = value
        '        If (Me._btnToday IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._btnToday.add_Click(New EventHandler(_schedGrid1, _schedGrid1.btnToday_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnUnSchdJob As Button
        '    Get
        '        Return Me._btnUnSchdJob
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnUnSchdJob IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._btnUnSchdJob.remove_Click(New EventHandler(_schedGrid, _schedGrid.btnUnSchdJob_Click))
        '        End If
        '        Me._btnUnSchdJob = value
        '        If (Me._btnUnSchdJob IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._btnUnSchdJob.add_Click(New EventHandler(_schedGrid1, _schedGrid1.btnUnSchdJob_Click))
        '        End If
        '    End Set
        'End Property

        Public ReadOnly Property getNeverActiveJobId As Integer
            Get
                Return Me.activeNeverSchedId
            End Get
        End Property

        Public ReadOnly Property getPriorActiveJobId As Integer
            Get
                Return Me.activePriorSchedId
            End Get
        End Property

        'Protected Overridable Property lblS As Label
        '    Get
        '        Return Me._lblS
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblS Is Nothing
        '        Me._lblS = value
        '        Me._lblS Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lblTime As Label
        '    Get
        '        Return Me._lblTime
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._lblTime Is Nothing
        '        Me._lblTime = value
        '        Me._lblTime Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property lstArea As DropDownList
        '    Get
        '        Return Me._lstArea
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As DropDownList)
        '        If (Me._lstArea IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._lstArea.remove_SelectedIndexChanged(New EventHandler(_schedGrid, _schedGrid.lstArea_SelectedIndexChanged))
        '        End If
        '        Me._lstArea = value
        '        If (Me._lstArea IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._lstArea.add_SelectedIndexChanged(New EventHandler(_schedGrid1, _schedGrid1.lstArea_SelectedIndexChanged))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property txtBeginDate As TextBox
        '    Get
        '        Return Me._txtBeginDate
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtBeginDate Is Nothing
        '        Me._txtBeginDate = value
        '        Me._txtBeginDate Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtHiddenNewJobId As TextBox
        '    Get
        '        Return Me._txtHiddenNewJobId
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtHiddenNewJobId Is Nothing
        '        Me._txtHiddenNewJobId = value
        '        Me._txtHiddenNewJobId Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtTime As TextBox
        '    Get
        '        Return Me._txtTime
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        If (Me._txtTime IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            Me._txtTime.remove_TextChanged(New EventHandler(_schedGrid, _schedGrid.txtTime_TextChanged))
        '        End If
        '        Me._txtTime = value
        '        If (Me._txtTime IsNot Nothing) Then
        '            Dim _schedGrid1 As schedGrid = Me
        '            Me._txtTime.add_TextChanged(New EventHandler(_schedGrid1, _schedGrid1.txtTime_TextChanged))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property UWGDates As UltraWebGrid
        '    Get
        '        Return Me._UWGDates
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        Me._UWGDates Is Nothing
        '        Me._UWGDates = value
        '        Me._UWGDates Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property UWGSched As UltraWebGrid
        '    Get
        '        Return Me._UWGSched
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebGrid)
        '        If (Me._UWGSched IsNot Nothing) Then
        '            Dim _schedGrid As schedGrid = Me
        '            RemoveHandler Me._UWGSched.InitializeRow, New InitializeRowEventHandler(AddressOf _schedGrid.UWGSched_InitializeRow)
        '            Dim _schedGrid1 As schedGrid = Me
        '            RemoveHandler Me._UWGSched.InitializeLayout, New InitializeLayoutEventHandler(AddressOf _schedGrid1.UWGSched_InitializeLayout)
        '        End If
        '        Me._UWGSched = value
        '        If (Me._UWGSched IsNot Nothing) Then
        '            Dim _schedGrid2 As schedGrid = Me
        '            AddHandler Me._UWGSched.InitializeRow, New InitializeRowEventHandler(AddressOf _schedGrid2.UWGSched_InitializeRow)
        '            Dim _schedGrid3 As schedGrid = Me
        '            AddHandler Me._UWGSched.InitializeLayout, New InitializeLayoutEventHandler(AddressOf _schedGrid3.UWGSched_InitializeLayout)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim _schedGrid As schedGrid = Me
            'MyBase.add_PreRender(New EventHandler(_schedGrid, _schedGrid.Page_PreRender))
            Dim _schedGrid1 As schedGrid = Me
            'MyBase.add_Init(New EventHandler(_schedGrid1, _schedGrid1.Page_Init))
            Dim _schedGrid2 As schedGrid = Me
            'MyBase.add_Load(New EventHandler(_schedGrid2, _schedGrid2.Page_Load))
            Me.FUNCTIONNAME = "Schedule"
            Me.UCCSchedule = New UCCSchedule()
            Me.controlHandled = False
        End Sub

        Private Sub bindGrid(ByVal scheduleView As BusinessService.ScheduleView)
            Me.UWGSched.DisplayLayout.ViewType = ViewType.Hierarchical
            Me.UWGSched.DataSource = (scheduleView.subcontractors)
            Me.UWGSched.DataBind()
            Me.UWGSched.DisplayLayout.TableLayout = TableLayout.Fixed
            Me.UWGSched.ExpandAll(True)
        End Sub

        Private Sub btnNewJob_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewJob.Click
            Dim flag As Boolean = False
            Me.controlHandled = True
            Dim activeCell As Infragistics.WebUI.UltraWebGrid.UltraGridCell = Me.UWGSched.DisplayLayout.ActiveCell
            Dim ultraGridCell As Infragistics.WebUI.UltraWebGrid.UltraGridCell = Me.UWGDates.DisplayLayout.ActiveCell
            Dim dateTime As System.DateTime = New System.DateTime()
            Dim dateTime1 As System.DateTime = New System.DateTime()
            If (ultraGridCell IsNot Nothing) Then
                flag = True
                dateTime1 = DateType.FromObject(ultraGridCell.Value)
            End If
            dateTime = DateType.FromString(Me.txtBeginDate.Text())
            Me.setupDates(dateTime)
            Dim control As Control = Me.Parent().FindControl("ClientSearch1")
            Dim ultraGridRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = DirectCast(control, clientSearch).getGridRowFocus
            If (ultraGridRow Is Nothing) Then
                DirectCast(control, clientSearch).errorText = " New Invalid without Job/Site Selected in Search Grid"
                Return
            End If
            Dim activeRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = Me.UWGSched.DisplayLayout.ActiveRow
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateTime(Strings.Trim(Me.txtTime.Text()))
            If (Not messageHelper.status) Then
                DirectCast(control, clientSearch).errorText = messageHelper.messageText
                Return
            End If
            Dim num As Integer = IntegerType.FromObject(messageHelper.messageObject)
            If (StringType.StrCmp(ultraGridRow.Band.Key, "Band 0", False) = 0) Then
                DirectCast(control, clientSearch).errorText = "No Job/Site Selected in Search Grid"
                Return
            End If
            If (StringType.StrCmp(ultraGridRow.Band.Key, "Band 2", False) = 0) Then
                If (activeRow Is Nothing) Then
                    messageHelper = If(Not flag, Me.createNewJob(ultraGridRow, 0, 0, Me.buildStartDate(Me.today, num)), Me.createNewJob(ultraGridRow, 0, 0, Me.buildStartDate(dateTime1, num)))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "moDef", False) = 0) Then
                    messageHelper = Me.createNewJob(ultraGridRow, IntegerType.FromObject(activeRow.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.moDate, num))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "tuDef", False) = 0) Then
                    messageHelper = Me.createNewJob(ultraGridRow, IntegerType.FromObject(activeRow.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.tuDate, num))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "weDef", False) = 0) Then
                    messageHelper = Me.createNewJob(ultraGridRow, IntegerType.FromObject(activeRow.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.weDate, num))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "thDef", False) = 0) Then
                    messageHelper = Me.createNewJob(ultraGridRow, IntegerType.FromObject(activeRow.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.thDate, num))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "frDef", False) = 0) Then
                    messageHelper = Me.createNewJob(ultraGridRow, IntegerType.FromObject(activeRow.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.frDate, num))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "saDef", False) <> 0) Then
                    If (StringType.StrCmp(activeCell.Column.Key, "suDef", False) <> 0) Then
                        DirectCast(control, clientSearch).errorText = "Subcontractor's Day Not Selected"
                        Return
                    End If
                    messageHelper = Me.createNewJob(ultraGridRow, IntegerType.FromObject(activeRow.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.suDate, num))
                Else
                    messageHelper = Me.createNewJob(ultraGridRow, IntegerType.FromObject(activeRow.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.saDate, num))
                End If
            End If
            If (StringType.StrCmp(ultraGridRow.Band.Key, "Band 1", False) = 0) Then
                messageHelper = If(Not flag, Me.createNewJobFromSite(ultraGridRow, Me.buildStartDate(Me.today, num)), Me.createNewJobFromSite(ultraGridRow, Me.buildStartDate(dateTime1, num)))
            End If
            If (Not messageHelper.status Or StringType.StrCmp(messageHelper.messageText, "", False) > 0) Then
                DirectCast(control, clientSearch).errorText = messageHelper.messageText
            End If
        End Sub

        Private Sub btnNextMo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNextMo.Click
            Dim dateTime As System.DateTime = New System.DateTime()
            Me.controlHandled = True
            dateTime = DateType.FromString(Me.txtBeginDate.Text())
            Me.setupDates(dateTime.AddMonths(1))
            Me.buildSchedule()
        End Sub

        Private Sub btnNextWeek_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNextWeek.Click
            Dim dateTime As System.DateTime = New System.DateTime()
            Me.controlHandled = True
            dateTime = DateType.FromString(Me.txtBeginDate.Text())
            Me.getActiveNeverSchedRow()
            Me.setupDates(dateTime.AddDays(7))
            Me.buildSchedule()
        End Sub

        Private Sub btnPrevMo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrevMo.Click
            Dim dateTime As System.DateTime = New System.DateTime()
            Me.controlHandled = True
            dateTime = DateType.FromString(Me.txtBeginDate.Text())
            Me.setupDates(dateTime.AddMonths(-1))
            Me.buildSchedule()
        End Sub

        Private Sub btnPrevWeek_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrevWeek.Click
            Dim dateTime As System.DateTime = New System.DateTime()
            Me.controlHandled = True
            dateTime = DateType.FromString(Me.txtBeginDate.Text())
            Me.setupDates(dateTime.AddDays(-7))
            Me.buildSchedule()
        End Sub

        Private Sub btnSchedJob_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSchedJob.Click
            Dim messageHelper As SystemFramework.MessageHelper
            Dim ultraGridRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow
            Dim num As Integer
            Dim activeCell As UltraGridCell = Me.UWGSched.DisplayLayout.ActiveCell
            Dim control As System.Web.UI.Control = Me.Parent().FindControl("ClientSearch1")
            Dim dateTime As System.DateTime = New System.DateTime()
            Dim ultraWebGrid As Infragistics.WebUI.UltraWebGrid.UltraWebGrid = DirectCast(Me.Parent().FindControl("UWGNeverSched"), Infragistics.WebUI.UltraWebGrid.UltraWebGrid)
            Dim activeRow As Infragistics.WebUI.UltraWebGrid.UltraGridRow = ultraWebGrid.DisplayLayout.ActiveRow
            Dim ultraWebGrid1 As Infragistics.WebUI.UltraWebGrid.UltraWebGrid = DirectCast(Me.Parent().FindControl("UWGPriorSched"), Infragistics.WebUI.UltraWebGrid.UltraWebGrid)
            Dim activeRow1 As Infragistics.WebUI.UltraWebGrid.UltraGridRow = ultraWebGrid1.DisplayLayout.ActiveRow
            Dim ultraGridRow1 As Infragistics.WebUI.UltraWebGrid.UltraGridRow = Me.UWGSched.DisplayLayout.ActiveRow
            Me.controlHandled = True
            If (activeRow Is Nothing) Then
                If (activeRow1 Is Nothing) Then
                    DirectCast(control, clientSearch).errorText = "No Orphan Job Selected"
                    Return
                End If
                ultraGridRow = activeRow1
            Else
                ultraGridRow = activeRow
            End If
            dateTime = DateType.FromString(Me.txtBeginDate.Text())
            Me.setupDates(dateTime)
            If (ultraGridRow1 Is Nothing) Then
                DirectCast(control, clientSearch).errorText = "Subcontractor Not Selected"
                Return
            End If
            If (StringType.StrCmp(Me.txtTime.Text(), "", False) = 0) Then
                num = IntegerType.FromObject(LateBinding.LateGet(ultraGridRow.Cells.FromKey("Start_Date").Value, Nothing, "Hour", New Object(-1) {}, Nothing, Nothing))
            Else
                If (Not Information.IsNumeric(Me.txtTime.Text())) Then
                    DirectCast(control, clientSearch).errorText = "Invalid Time"
                    Return
                End If
                If (IntegerType.FromString(Me.txtTime.Text()) >= 24) Then
                    DirectCast(control, clientSearch).errorText = "Invalid Time"
                    Return
                End If
                num = IntegerType.FromString(Me.txtTime.Text())
            End If
            If (StringType.StrCmp(activeCell.Column.Key, "moDef", False) = 0) Then
                messageHelper = Me.updateJob(IntegerType.FromObject(ultraGridRow.Cells.FromKey("Job_ID").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Site_ID").Value), IntegerType.FromObject(ultraGridRow1.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.moDate, num), StringType.FromObject(ultraGridRow.Cells.FromKey("Status").Value), StringType.FromObject(ultraGridRow.Cells.FromKey("Cancel_Reason").Value), DateType.FromObject(ultraGridRow.Cells.FromKey("Modified_Date").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Schedule_Amount").Value))
            ElseIf (StringType.StrCmp(activeCell.Column.Key, "tuDef", False) = 0) Then
                messageHelper = Me.updateJob(IntegerType.FromObject(ultraGridRow.Cells.FromKey("Job_ID").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Site_ID").Value), IntegerType.FromObject(ultraGridRow1.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.tuDate, num), StringType.FromObject(ultraGridRow.Cells.FromKey("Status").Value), StringType.FromObject(ultraGridRow.Cells.FromKey("Cancel_Reason").Value), DateType.FromObject(ultraGridRow.Cells.FromKey("Modified_Date").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Schedule_Amount").Value))
            ElseIf (StringType.StrCmp(activeCell.Column.Key, "weDef", False) = 0) Then
                messageHelper = Me.updateJob(IntegerType.FromObject(ultraGridRow.Cells.FromKey("Job_ID").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Site_ID").Value), IntegerType.FromObject(ultraGridRow1.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.weDate, num), StringType.FromObject(ultraGridRow.Cells.FromKey("Status").Value), StringType.FromObject(ultraGridRow.Cells.FromKey("Cancel_Reason").Value), DateType.FromObject(ultraGridRow.Cells.FromKey("Modified_Date").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Schedule_Amount").Value))
            ElseIf (StringType.StrCmp(activeCell.Column.Key, "thDef", False) = 0) Then
                messageHelper = Me.updateJob(IntegerType.FromObject(ultraGridRow.Cells.FromKey("Job_ID").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Site_ID").Value), IntegerType.FromObject(ultraGridRow1.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.thDate, num), StringType.FromObject(ultraGridRow.Cells.FromKey("Status").Value), StringType.FromObject(ultraGridRow.Cells.FromKey("Cancel_Reason").Value), DateType.FromObject(ultraGridRow.Cells.FromKey("Modified_Date").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Schedule_Amount").Value))
            ElseIf (StringType.StrCmp(activeCell.Column.Key, "frDef", False) = 0) Then
                messageHelper = Me.updateJob(IntegerType.FromObject(ultraGridRow.Cells.FromKey("Job_ID").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Site_ID").Value), IntegerType.FromObject(ultraGridRow1.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.frDate, num), StringType.FromObject(ultraGridRow.Cells.FromKey("Status").Value), StringType.FromObject(ultraGridRow.Cells.FromKey("Cancel_Reason").Value), DateType.FromObject(ultraGridRow.Cells.FromKey("Modified_Date").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Schedule_Amount").Value))
            ElseIf (StringType.StrCmp(activeCell.Column.Key, "saDef", False) <> 0) Then
                If (StringType.StrCmp(activeCell.Column.Key, "suDef", False) <> 0) Then
                    DirectCast(control, clientSearch).errorText = "Subcontractor's Day Not Selected"
                    Return
                End If
                messageHelper = Me.updateJob(IntegerType.FromObject(ultraGridRow.Cells.FromKey("Job_ID").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Site_ID").Value), IntegerType.FromObject(ultraGridRow1.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.suDate, num), StringType.FromObject(ultraGridRow.Cells.FromKey("Status").Value), StringType.FromObject(ultraGridRow.Cells.FromKey("Cancel_Reason").Value), DateType.FromObject(ultraGridRow.Cells.FromKey("Modified_Date").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Schedule_Amount").Value))
            Else
                messageHelper = Me.updateJob(IntegerType.FromObject(ultraGridRow.Cells.FromKey("Job_ID").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Site_ID").Value), IntegerType.FromObject(ultraGridRow1.Cells.FromKey("sub_ID").Value), 1, Me.buildStartDate(Me.saDate, num), StringType.FromObject(ultraGridRow.Cells.FromKey("Status").Value), StringType.FromObject(ultraGridRow.Cells.FromKey("Cancel_Reason").Value), DateType.FromObject(ultraGridRow.Cells.FromKey("Modified_Date").Value), IntegerType.FromObject(ultraGridRow.Cells.FromKey("Schedule_Amount").Value))
            End If
            If (Not messageHelper.status Or StringType.StrCmp(messageHelper.messageText, "", False) > 0) Then
                DirectCast(control, clientSearch).errorText = messageHelper.messageText
            End If
        End Sub

        Private Sub btnToday_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnToday.Click
            Me.controlHandled = True
            Me.setupDates(Me.today)
            Me.buildSchedule()
        End Sub

        Private Sub btnUnSchdJob_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUnSchdJob.Click
            Dim messageHelper As SystemFramework.MessageHelper = Nothing
            Dim activeCell As UltraGridCell = Me.UWGSched.DisplayLayout.ActiveCell
            Dim activeRow As UltraGridRow = Me.UWGSched.DisplayLayout.ActiveRow
            Dim control As System.Web.UI.Control = Me.Parent().FindControl("ClientSearch1")
            Dim dateTime As System.DateTime = New System.DateTime()
            Me.controlHandled = True
            dateTime = DateType.FromString(Me.txtBeginDate.Text())
            Me.setupDates(dateTime)
            If (activeRow Is Nothing) Then
                DirectCast(control, clientSearch).errorText = "No Job Selected to Unschedule"
                Return
            End If
            If (activeRow IsNot Nothing) Then
                If (StringType.StrCmp(activeCell.Column.Key, "moZipCode", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "moStartDate", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "moLastName", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "moSchdAmtInt", False) = 0) Then
                    messageHelper = Me.updateJob(IntegerType.FromObject(activeRow.Cells.FromKey("moJob_Id").Value), IntegerType.FromObject(activeRow.Cells.FromKey("moSite_Id").Value), 0, 1, DateType.FromObject(activeRow.Cells.FromKey("moStartDate").Value), StringType.FromObject(activeRow.Cells.FromKey("moStatus").Value), StringType.FromObject(activeRow.Cells.FromKey("moCancelReason").Value), DateType.FromObject(activeRow.Cells.FromKey("moModifiedDate").Value), IntegerType.FromObject(activeRow.Cells.FromKey("moSchdAmtInt").Value))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "tuZipCode", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "tuStartDate", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "tuLastName", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "tuSchdAmtInt", False) = 0) Then
                    messageHelper = Me.updateJob(IntegerType.FromObject(activeRow.Cells.FromKey("tuJob_Id").Value), IntegerType.FromObject(activeRow.Cells.FromKey("tuSite_Id").Value), 0, 1, DateType.FromObject(activeRow.Cells.FromKey("tuStartDate").Value), StringType.FromObject(activeRow.Cells.FromKey("tuStatus").Value), StringType.FromObject(activeRow.Cells.FromKey("tuCancelReason").Value), DateType.FromObject(activeRow.Cells.FromKey("tuModifiedDate").Value), IntegerType.FromObject(activeRow.Cells.FromKey("tuSchdAmtInt").Value))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "weZipCode", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "weStartDate", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "weLastName", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "weSchdAmtInt", False) = 0) Then
                    messageHelper = Me.updateJob(IntegerType.FromObject(activeRow.Cells.FromKey("weJob_Id").Value), IntegerType.FromObject(activeRow.Cells.FromKey("weSite_Id").Value), 0, 1, DateType.FromObject(activeRow.Cells.FromKey("weStartDate").Value), StringType.FromObject(activeRow.Cells.FromKey("weStatus").Value), StringType.FromObject(activeRow.Cells.FromKey("weCancelReason").Value), DateType.FromObject(activeRow.Cells.FromKey("weModifiedDate").Value), IntegerType.FromObject(activeRow.Cells.FromKey("weSchdAmtInt").Value))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "thZipCode", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "thStartDate", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "thLastName", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "thSchdAmtInt", False) = 0) Then
                    messageHelper = Me.updateJob(IntegerType.FromObject(activeRow.Cells.FromKey("thJob_Id").Value), IntegerType.FromObject(activeRow.Cells.FromKey("thSite_Id").Value), 0, 1, DateType.FromObject(activeRow.Cells.FromKey("thStartDate").Value), StringType.FromObject(activeRow.Cells.FromKey("thStatus").Value), StringType.FromObject(activeRow.Cells.FromKey("thCancelReason").Value), DateType.FromObject(activeRow.Cells.FromKey("thModifiedDate").Value), IntegerType.FromObject(activeRow.Cells.FromKey("thSchdAmtInt").Value))
                ElseIf (StringType.StrCmp(activeCell.Column.Key, "frZipCode", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "frStartDate", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "frLastName", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "frSchdAmtInt", False) = 0) Then
                    messageHelper = Me.updateJob(IntegerType.FromObject(activeRow.Cells.FromKey("frJob_Id").Value), IntegerType.FromObject(activeRow.Cells.FromKey("frSite_Id").Value), 0, 1, DateType.FromObject(activeRow.Cells.FromKey("frStartDate").Value), StringType.FromObject(activeRow.Cells.FromKey("frStatus").Value), StringType.FromObject(activeRow.Cells.FromKey("frCancelReason").Value), DateType.FromObject(activeRow.Cells.FromKey("frModifiedDate").Value), IntegerType.FromObject(activeRow.Cells.FromKey("frSchdAmtInt").Value))
                ElseIf (Not (StringType.StrCmp(activeCell.Column.Key, "saZipCode", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "saStartDate", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "saLastName", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "saSchdAmtInt", False) = 0)) Then
                    If (Not (StringType.StrCmp(activeCell.Column.Key, "suZipCode", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "suStartDate", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "suLastName", False) = 0 Or StringType.StrCmp(activeCell.Column.Key, "suSchdAmtInt", False) = 0)) Then
                        DirectCast(control, clientSearch).errorText = "No Job Information Selected"
                        Return
                    End If
                    messageHelper = Me.updateJob(IntegerType.FromObject(activeRow.Cells.FromKey("suJob_Id").Value), IntegerType.FromObject(activeRow.Cells.FromKey("suSite_Id").Value), 0, 1, DateType.FromObject(activeRow.Cells.FromKey("suStartDate").Value), StringType.FromObject(activeRow.Cells.FromKey("suStatus").Value), StringType.FromObject(activeRow.Cells.FromKey("suCancelReason").Value), DateType.FromObject(activeRow.Cells.FromKey("suModifiedDate").Value), IntegerType.FromObject(activeRow.Cells.FromKey("suSchdAmtInt").Value))
                Else
                    messageHelper = Me.updateJob(IntegerType.FromObject(activeRow.Cells.FromKey("saJob_Id").Value), IntegerType.FromObject(activeRow.Cells.FromKey("saSite_Id").Value), 0, 1, DateType.FromObject(activeRow.Cells.FromKey("saStartDate").Value), StringType.FromObject(activeRow.Cells.FromKey("saStatus").Value), StringType.FromObject(activeRow.Cells.FromKey("saCancelReason").Value), DateType.FromObject(activeRow.Cells.FromKey("saModifiedDate").Value), IntegerType.FromObject(activeRow.Cells.FromKey("saSchdAmtInt").Value))
                End If
            End If
            If (Not messageHelper.status Or StringType.StrCmp(messageHelper.messageText, "", False) > 0) Then
                DirectCast(control, clientSearch).errorText = messageHelper.messageText
            End If
        End Sub

        Private Sub buildSchedule()
            Me.setActiveOrphanRows()
            Dim subcontractorSchedule As ScheduleView = Me.UCCSchedule.getSubcontractorSchedule(IntegerType.FromString(Me.lstArea.SelectedItem().Value), Me.lstArea.SelectedItem().Text(), Me.beginDate, Me.endDate, Me.suDate, Me.moDate, Me.tuDate, Me.weDate, Me.thDate, Me.frDate, Me.saDate)
            Me.bindGrid(subcontractorSchedule)
            Dim ultraWebGrid As Infragistics.WebUI.UltraWebGrid.UltraWebGrid = DirectCast(Me.Parent().FindControl("UWGNeverSched"), Infragistics.WebUI.UltraWebGrid.UltraWebGrid)
            Dim ultraWebGrid1 As Infragistics.WebUI.UltraWebGrid.UltraWebGrid = DirectCast(Me.Parent().FindControl("UWGPriorSched"), Infragistics.WebUI.UltraWebGrid.UltraWebGrid)
            ultraWebGrid.DisplayLayout.ViewType = ViewType.Flat
            Dim jobOrphans As DataSet = Me.UCCSchedule.getJobOrphans(0)
            ultraWebGrid.DataSource = (jobOrphans)
            ultraWebGrid.DataBind()
            ultraWebGrid.DisplayLayout.TableLayout = TableLayout.Fixed
            jobOrphans.Clear()
            ultraWebGrid1.DisplayLayout.ViewType = ViewType.Flat
            jobOrphans = Me.UCCSchedule.getJobOrphans(1)
            ultraWebGrid1.DataSource = (jobOrphans)
            ultraWebGrid1.DataBind()
            ultraWebGrid1.DisplayLayout.TableLayout = TableLayout.Fixed
            jobOrphans = Nothing
            Me.txtTime.Text = ("")
        End Sub

        Private Function buildStartDate(ByVal inputDate As System.DateTime, ByVal time As Integer) As System.DateTime
            Dim dateTime As System.DateTime = New System.DateTime(inputDate.Year(), inputDate.Month(), inputDate.Day(), time, 0, 1)
            Return dateTime
        End Function

        Private Function createNewJob(ByVal searchGridRow As UltraGridRow, ByVal sub_id As Integer, ByVal priorSchedule As Integer, ByVal dateTime As System.DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.UCCSchedule.createJob(sub_id, IntegerType.FromObject(searchGridRow.Cells.FromKey("site_ID").Value), IntegerType.FromObject(searchGridRow.Cells.FromKey("bidHeader_ID").Value), priorSchedule, StringType.FromObject(searchGridRow.Cells.FromKey("job_Description").Value), "", dateTime, dateTime, DecimalType.FromObject(searchGridRow.Cells.FromKey("bill_Amount").Value), DecimalType.FromObject(searchGridRow.Cells.FromKey("bill_Amount").Value), Decimal.Zero, DecimalType.FromObject(searchGridRow.Cells.FromKey("bill_Amount").Value), "O", "", MyBase.[Operator].userId, MyBase.[Operator].userId)
            If (messageHelper.status) Then
                Me.buildSchedule()
            End If
            Return messageHelper
        End Function

        Private Function createNewJobFromSite(ByVal searchGridRow As UltraGridRow, ByVal dateTime As System.DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.UCCSchedule.createJob(0, IntegerType.FromObject(searchGridRow.Cells.FromKey("site_ID").Value), 0, 0, "", "", dateTime, dateTime, Decimal.Zero, Decimal.Zero, Decimal.Zero, Decimal.Zero, "O", "", MyBase.[Operator].userId, MyBase.[Operator].userId)
            If (messageHelper.status) Then
                Me.buildSchedule()
            End If
            Return messageHelper
        End Function

        Private Function getActiveNeverSchedRow() As Integer
            Dim num As Integer
            Dim ultraWebGrid As Infragistics.WebUI.UltraWebGrid.UltraWebGrid = DirectCast(Me.Parent().FindControl("UWGNeverSched"), Infragistics.WebUI.UltraWebGrid.UltraWebGrid)
            Dim activeRow As UltraGridRow = ultraWebGrid.DisplayLayout.ActiveRow
            num = If(activeRow Is Nothing, 0, IntegerType.FromObject(activeRow.Cells.FromKey("Job_ID").Value))
            Return num
        End Function

        Private Function getActivePriorSchedRow() As Integer
            Dim num As Integer
            Dim ultraWebGrid As Infragistics.WebUI.UltraWebGrid.UltraWebGrid = DirectCast(Me.Parent().FindControl("UWGPriorSched"), Infragistics.WebUI.UltraWebGrid.UltraWebGrid)
            Dim activeRow As UltraGridRow = ultraWebGrid.DisplayLayout.ActiveRow
            num = If(activeRow Is Nothing, 0, IntegerType.FromObject(activeRow.Cells.FromKey("Job_ID").Value))
            Return num
        End Function

        <DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub loadArea()
            Dim num As Integer = 0
            Dim enumerator As IEnumerator = Nothing
            Dim flag As Boolean = False
            Dim allActiveAreas As SqlDataReader = Me.UCCSchedule.getAllActiveAreas()
            Me.lstArea.DataSource = allActiveAreas
            Me.lstArea.DataValueField = "Area_ID"
            Me.lstArea.DataTextField = "Area_Name"
            Me.lstArea.DataBind()
            Me.lstArea.Items().Insert(0, New ListItem("ALL", "0"))
            Dim defaultScheduleArea As Integer = MyBase.Operator.defaultScheduleArea
            Try
                enumerator = Me.lstArea.Items().GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As ListItem = DirectCast(enumerator.Current(), ListItem)
                    If (DoubleType.FromString(current.Value) <> CDbl(defaultScheduleArea)) Then
                        num = num + 1
                    Else
                        Me.lstArea.SelectedIndex = (num)
                        current.Selected = (True)
                        flag = True
                        If (Not flag) Then
                            Me.lstArea.SelectedIndex = (1)
                        End If
                        Return
                    End If
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            If (Not flag) Then
                Me.lstArea.SelectedIndex = (1)
            End If
        End Sub

        Private Sub loadDateLabels(ByVal startDate As DateTime)
            Me.UWGDates.Bands(0).Columns(0).DataType = "System.DateTime"
            Me.UWGDates.Bands(0).Columns(1).DataType = "System.DateTime"
            Me.UWGDates.Bands(0).Columns(2).DataType = "System.DateTime"
            Me.UWGDates.Bands(0).Columns(3).DataType = "System.DateTime"
            Me.UWGDates.Bands(0).Columns(4).DataType = "System.DateTime"
            Me.UWGDates.Bands(0).Columns(5).DataType = "System.DateTime"
            Me.UWGDates.Bands(0).Columns(6).DataType = "System.DateTime"
            Me.UWGDates.Bands(0).Columns.FromKey("lblSunday").Format = "ddd dd-MMM"
            Me.UWGDates.Bands(0).Columns.FromKey("lblMonday").Format = "ddd dd-MMM"
            Me.UWGDates.Bands(0).Columns.FromKey("lblTuesday").Format = "ddd dd-MMM"
            Me.UWGDates.Bands(0).Columns.FromKey("lblWednesday").Format = "ddd dd-MMM"
            Me.UWGDates.Bands(0).Columns.FromKey("lblThursday").Format = "ddd dd-MMM"
            Me.UWGDates.Bands(0).Columns.FromKey("lblFriday").Format = "ddd dd-MMM"
            Me.UWGDates.Bands(0).Columns.FromKey("lblSaturday").Format = "ddd dd-MMM yyyy"
            Me.suDate = Me.parseDateLabel(startDate, 1, Me.UWGDates.Rows(0).Cells.FromKey("lblSunday"))
            Me.moDate = Me.parseDateLabel(startDate, 2, Me.UWGDates.Rows(0).Cells.FromKey("lblMonday"))
            Me.tuDate = Me.parseDateLabel(startDate, 3, Me.UWGDates.Rows(0).Cells.FromKey("lblTuesday"))
            Me.weDate = Me.parseDateLabel(startDate, 4, Me.UWGDates.Rows(0).Cells.FromKey("lblWednesday"))
            Me.thDate = Me.parseDateLabel(startDate, 5, Me.UWGDates.Rows(0).Cells.FromKey("lblThursday"))
            Me.frDate = Me.parseDateLabel(startDate, 6, Me.UWGDates.Rows(0).Cells.FromKey("lblFriday"))
            Me.saDate = Me.parseDateLabel(startDate, 7, Me.UWGDates.Rows(0).Cells.FromKey("lblSaturday"))
            Me.txtBeginDate.Text = (startDate.ToString())
        End Sub

        Private Sub lstArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstArea.SelectedIndexChanged
            Dim dateTime As System.DateTime = New System.DateTime()
            Me.controlHandled = True
            dateTime = DateType.FromString(Me.txtBeginDate.Text())
            Me.setupDates(dateTime)
            Me.buildSchedule()
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If (Me.Page().IsPostBack()) Then
                Me.today = DateTime.Now()
            Else
                Me.controlHandled = True
                Me.loadArea()
                Me.today = DateTime.Now()
                Me.setupDates(Me.today)
                Me.buildSchedule()
            End If
        End Sub

        Private Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
            If (Not Me.controlHandled) Then
                Dim dateTime As System.DateTime = DateType.FromString(Me.txtBeginDate.Text())
                Me.setupDates(dateTime)
                Me.buildSchedule()
            End If
        End Sub

        Private Function parseDateLabel(ByVal startDate As System.DateTime, ByVal daysToAdd As Integer, ByVal gridControl As UltraGridCell) As System.DateTime
            Dim dateTime As System.DateTime = startDate.AddDays(CDbl((daysToAdd - 1)))
            Dim [date] As System.DateTime = dateTime.Date()
            gridControl.Value = [date]
            If (System.DateTime.Compare(startDate.AddDays(CDbl((daysToAdd - 1))).Date(), Me.today.Date()) <> 0) Then
                gridControl.Style.BackColor = (Color.Gainsboro())
                gridControl.Style.ForeColor = (Color.Black())
            Else
                gridControl.Style.BackColor = (Color.DarkMagenta())
                gridControl.Style.ForeColor = (Color.White())
            End If
            Return [date]
        End Function

        Private Sub setActiveOrphanRows()
            If (Me.txtHiddenNewJobId.Text().Length() <= 0) Then
                Me.newJobId = 0
            Else
                Me.newJobId = IntegerType.FromString(Me.txtHiddenNewJobId.Text())
            End If
            If (Me.newJobId <= 0) Then
                Me.newJobId = 0
                Me.activeNeverSchedId = Me.getActiveNeverSchedRow()
                Me.activePriorSchedId = Me.getActivePriorSchedRow()
            Else
                Me.activeNeverSchedId = Me.newJobId
                Me.activePriorSchedId = 0
            End If
        End Sub

        Private Sub setupDates(ByVal inputDate As System.DateTime)
            Dim dateTime As System.DateTime
            dateTime = If(inputDate.DayOfWeek() = 0, inputDate, inputDate.AddDays(CDbl((inputDate.DayOfWeek() * -1))))
            Dim dateTime1 As System.DateTime = dateTime.AddDays(6)
            Dim dateTime2 As System.DateTime = New System.DateTime(dateTime.Year(), dateTime.Month(), dateTime.Day(), 0, 0, 1)
            Me.beginDate = dateTime2
            dateTime2 = New System.DateTime(dateTime1.Year(), dateTime1.Month(), dateTime1.Day(), 23, 59, 59)
            Me.endDate = dateTime2
            Me.loadDateLabels(dateTime)
        End Sub

        Private Sub txtTime_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTime.TextChanged
        End Sub

        Private Function updateJob(ByVal job_id As Integer, ByVal site_id As Integer, ByVal sub_id As Integer, ByVal priorSchedule As Integer, ByVal startDate As DateTime, ByVal status As String, ByVal cancel_reason As String, ByVal modified_date As DateTime, ByVal schedule_amount As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.UCCSchedule.updateJob(job_id, site_id, sub_id, priorSchedule, startDate, startDate, MyBase.[Operator].userId, modified_date, status, cancel_reason, New Decimal(schedule_amount))
            Me.buildSchedule()
            Return messageHelper
        End Function

        Private Sub UWGSched_InitializeLayout(ByVal sender As Object, ByVal e As LayoutEventArgs) Handles UWGSched.InitializeLayout
            Dim layout As UltraGridLayout = e.Layout
            layout.Bands(0).Columns.FromKey("sub_ID").Hidden = True
            layout.Bands(0).Columns.FromKey("dollarMaxAmount").Hidden = True
            layout.Bands(0).Columns.FromKey("suAM").Hidden = True
            layout.Bands(0).Columns.FromKey("suAM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("suPM").Hidden = True
            layout.Bands(0).Columns.FromKey("suPM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("moAM").Hidden = True
            layout.Bands(0).Columns.FromKey("moAM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("moPM").Hidden = True
            layout.Bands(0).Columns.FromKey("moPM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("tuAM").Hidden = True
            layout.Bands(0).Columns.FromKey("tuAM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("tuPM").Hidden = True
            layout.Bands(0).Columns.FromKey("tuPM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("weAM").Hidden = True
            layout.Bands(0).Columns.FromKey("weAM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("wePM").Hidden = True
            layout.Bands(0).Columns.FromKey("wePM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("thAM").Hidden = True
            layout.Bands(0).Columns.FromKey("thAM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("thPM").Hidden = True
            layout.Bands(0).Columns.FromKey("thPM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("frAM").Hidden = True
            layout.Bands(0).Columns.FromKey("frAM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("frPM").Hidden = True
            layout.Bands(0).Columns.FromKey("frPM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("saAM").Hidden = True
            layout.Bands(0).Columns.FromKey("saAM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("saPM").Hidden = True
            layout.Bands(0).Columns.FromKey("saPM").ServerOnly = True
            layout.Bands(0).Columns.FromKey("suRemainder").Hidden = True
            layout.Bands(0).Columns.FromKey("suRemainder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("moRemainder").Hidden = True
            layout.Bands(0).Columns.FromKey("moRemainder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("tuRemainder").Hidden = True
            layout.Bands(0).Columns.FromKey("tuRemainder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("weRemainder").Hidden = True
            layout.Bands(0).Columns.FromKey("weRemainder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("thRemainder").Hidden = True
            layout.Bands(0).Columns.FromKey("thRemainder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("frRemainder").Hidden = True
            layout.Bands(0).Columns.FromKey("frRemainder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("saRemainder").Hidden = True
            layout.Bands(0).Columns.FromKey("saRemainder").ServerOnly = True
            layout.Bands(0).Columns.FromKey("height").Hidden = True
            layout.Bands(0).Columns.FromKey("height").ServerOnly = True
            layout.Bands(0).Columns.FromKey("nick_Name").Move(0)
            layout.Bands(0).Columns.FromKey("suDef").Move(1)
            layout.Bands(0).Columns.FromKey("moDef").Move(2)
            layout.Bands(0).Columns.FromKey("tuDef").Move(3)
            layout.Bands(0).Columns.FromKey("weDef").Move(4)
            layout.Bands(0).Columns.FromKey("thDef").Move(5)
            layout.Bands(0).Columns.FromKey("frDef").Move(6)
            layout.Bands(0).Columns.FromKey("saDef").Move(7)
            layout.Bands(0).Columns.FromKey("nick_Name").Width = Unit.Pixel(40)
            layout.Bands(0).Columns.FromKey("suDef").Width = Unit.Pixel(134)
            layout.Bands(0).Columns.FromKey("moDef").Width = Unit.Pixel(134)
            layout.Bands(0).Columns.FromKey("tuDef").Width = Unit.Pixel(134)
            layout.Bands(0).Columns.FromKey("weDef").Width = Unit.Pixel(134)
            layout.Bands(0).Columns.FromKey("thDef").Width = Unit.Pixel(134)
            layout.Bands(0).Columns.FromKey("frDef").Width = Unit.Pixel(134)
            layout.Bands(0).Columns.FromKey("saDef").Width = Unit.Pixel(134)
            layout.Bands(0).RowStyle.BorderColor = (Color.Navy())
            layout.Bands(0).RowStyle.BorderWidth = (Unit.Pixel(2))
            layout.Bands(0).RowStyle.BackColor = (Color.PapayaWhip())
            layout.Bands(1).Indentation = 38
            layout.Bands(1).Columns.FromKey("suJob_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("suSite_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("suSite_Id").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suReminder").Hidden = True
            layout.Bands(1).Columns.FromKey("suReminder").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suCritical").Hidden = True
            layout.Bands(1).Columns.FromKey("suCritical").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suNoStories").Hidden = True
            layout.Bands(1).Columns.FromKey("suNoStories").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suNoteType").Hidden = True
            layout.Bands(1).Columns.FromKey("suNoteType").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suModifiedDate").Hidden = True
            layout.Bands(1).Columns.FromKey("suModifiedDate").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suStatus").Hidden = True
            layout.Bands(1).Columns.FromKey("suStatus").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suCancelReason").Hidden = True
            layout.Bands(1).Columns.FromKey("suCancelReason").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suSchdAmt").Hidden = True
            layout.Bands(1).Columns.FromKey("suSchdAmt").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moJob_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("moSite_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("moSite_Id").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moReminder").Hidden = True
            layout.Bands(1).Columns.FromKey("moReminder").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moCritical").Hidden = True
            layout.Bands(1).Columns.FromKey("moCritical").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moNoStories").Hidden = True
            layout.Bands(1).Columns.FromKey("moNoStories").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moNoteType").Hidden = True
            layout.Bands(1).Columns.FromKey("moNoteType").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moModifiedDate").Hidden = True
            layout.Bands(1).Columns.FromKey("moModifiedDate").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moStatus").Hidden = True
            layout.Bands(1).Columns.FromKey("moStatus").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moCancelReason").Hidden = True
            layout.Bands(1).Columns.FromKey("moCancelReason").ServerOnly = True
            layout.Bands(1).Columns.FromKey("moSchdAmt").Hidden = True
            layout.Bands(1).Columns.FromKey("moSchdAmt").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuJob_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("tuSite_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("tuSite_Id").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuReminder").Hidden = True
            layout.Bands(1).Columns.FromKey("tuReminder").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuCritical").Hidden = True
            layout.Bands(1).Columns.FromKey("tuCritical").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuNoStories").Hidden = True
            layout.Bands(1).Columns.FromKey("tuNoStories").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuNoteType").Hidden = True
            layout.Bands(1).Columns.FromKey("tuNoteType").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuModifiedDate").Hidden = True
            layout.Bands(1).Columns.FromKey("tuModifiedDate").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuStatus").Hidden = True
            layout.Bands(1).Columns.FromKey("tuStatus").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuCancelReason").Hidden = True
            layout.Bands(1).Columns.FromKey("tuCancelReason").ServerOnly = True
            layout.Bands(1).Columns.FromKey("tuSchdAmt").Hidden = True
            layout.Bands(1).Columns.FromKey("tuSchdAmt").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weJob_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("weSite_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("weSite_Id").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weReminder").Hidden = True
            layout.Bands(1).Columns.FromKey("weReminder").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weCritical").Hidden = True
            layout.Bands(1).Columns.FromKey("weCritical").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weNoStories").Hidden = True
            layout.Bands(1).Columns.FromKey("weNoStories").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weNoteType").Hidden = True
            layout.Bands(1).Columns.FromKey("weNoteType").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weModifiedDate").Hidden = True
            layout.Bands(1).Columns.FromKey("weModifiedDate").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weStatus").Hidden = True
            layout.Bands(1).Columns.FromKey("weStatus").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weCancelReason").Hidden = True
            layout.Bands(1).Columns.FromKey("weCancelReason").ServerOnly = True
            layout.Bands(1).Columns.FromKey("weSchdAmt").Hidden = True
            layout.Bands(1).Columns.FromKey("weSchdAmt").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thJob_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("thSite_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("thSite_Id").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thReminder").Hidden = True
            layout.Bands(1).Columns.FromKey("thReminder").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thCritical").Hidden = True
            layout.Bands(1).Columns.FromKey("thCritical").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thNoStories").Hidden = True
            layout.Bands(1).Columns.FromKey("thNoStories").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thNoteType").Hidden = True
            layout.Bands(1).Columns.FromKey("thNoteType").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thModifiedDate").Hidden = True
            layout.Bands(1).Columns.FromKey("thModifiedDate").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thStatus").Hidden = True
            layout.Bands(1).Columns.FromKey("thStatus").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thCancelReason").Hidden = True
            layout.Bands(1).Columns.FromKey("thCancelReason").ServerOnly = True
            layout.Bands(1).Columns.FromKey("thSchdAmt").Hidden = True
            layout.Bands(1).Columns.FromKey("thSchdAmt").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frJob_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("frSite_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("frSite_Id").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frReminder").Hidden = True
            layout.Bands(1).Columns.FromKey("frReminder").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frCritical").Hidden = True
            layout.Bands(1).Columns.FromKey("frCritical").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frNoStories").Hidden = True
            layout.Bands(1).Columns.FromKey("frNoStories").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frNoteType").Hidden = True
            layout.Bands(1).Columns.FromKey("frNoteType").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frModifiedDate").Hidden = True
            layout.Bands(1).Columns.FromKey("frModifiedDate").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frStatus").Hidden = True
            layout.Bands(1).Columns.FromKey("frStatus").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frCancelReason").Hidden = True
            layout.Bands(1).Columns.FromKey("frCancelReason").ServerOnly = True
            layout.Bands(1).Columns.FromKey("frSchdAmt").Hidden = True
            layout.Bands(1).Columns.FromKey("frSchdAmt").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saJob_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("saSite_Id").Hidden = True
            layout.Bands(1).Columns.FromKey("saSite_Id").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saReminder").Hidden = True
            layout.Bands(1).Columns.FromKey("saReminder").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saCritical").Hidden = True
            layout.Bands(1).Columns.FromKey("saCritical").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saNoStories").Hidden = True
            layout.Bands(1).Columns.FromKey("saNoStories").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saNoteType").Hidden = True
            layout.Bands(1).Columns.FromKey("saNoteType").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saModifiedDate").Hidden = True
            layout.Bands(1).Columns.FromKey("saModifiedDate").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saStatus").Hidden = True
            layout.Bands(1).Columns.FromKey("saStatus").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saCancelReason").Hidden = True
            layout.Bands(1).Columns.FromKey("saCancelReason").ServerOnly = True
            layout.Bands(1).Columns.FromKey("saSchdAmt").Hidden = True
            layout.Bands(1).Columns.FromKey("saSchdAmt").ServerOnly = True
            layout.Bands(1).Columns.FromKey("suStartDate").Move(0)
            layout.Bands(1).Columns.FromKey("suSchdAmtInt").Move(1)
            layout.Bands(1).Columns.FromKey("suLastName").Move(2)
            layout.Bands(1).Columns.FromKey("suZipCode").Move(3)
            layout.Bands(1).Columns.FromKey("moStartDate").Move(4)
            layout.Bands(1).Columns.FromKey("moSchdAmtInt").Move(5)
            layout.Bands(1).Columns.FromKey("moLastName").Move(6)
            layout.Bands(1).Columns.FromKey("moZipCode").Move(7)
            layout.Bands(1).Columns.FromKey("tuStartDate").Move(8)
            layout.Bands(1).Columns.FromKey("tuSchdAmtInt").Move(9)
            layout.Bands(1).Columns.FromKey("tuLastName").Move(10)
            layout.Bands(1).Columns.FromKey("tuZipCode").Move(11)
            layout.Bands(1).Columns.FromKey("weStartDate").Move(12)
            layout.Bands(1).Columns.FromKey("weSchdAmtInt").Move(13)
            layout.Bands(1).Columns.FromKey("weLastName").Move(14)
            layout.Bands(1).Columns.FromKey("weZipCode").Move(15)
            layout.Bands(1).Columns.FromKey("thStartDate").Move(16)
            layout.Bands(1).Columns.FromKey("thSchdAmtInt").Move(17)
            layout.Bands(1).Columns.FromKey("thLastName").Move(18)
            layout.Bands(1).Columns.FromKey("thZipCode").Move(19)
            layout.Bands(1).Columns.FromKey("frStartDate").Move(20)
            layout.Bands(1).Columns.FromKey("frSchdAmtInt").Move(21)
            layout.Bands(1).Columns.FromKey("frLastName").Move(22)
            layout.Bands(1).Columns.FromKey("frZipCode").Move(23)
            layout.Bands(1).Columns.FromKey("saStartDate").Move(24)
            layout.Bands(1).Columns.FromKey("saSchdAmtInt").Move(25)
            layout.Bands(1).Columns.FromKey("saLastName").Move(26)
            layout.Bands(1).Columns.FromKey("saZipCode").Move(27)
            layout.Bands(1).Columns.FromKey("suStartDate").Width = Unit.Pixel(20)
            layout.Bands(1).Columns.FromKey("suSchdAmtInt").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("suLastName").Width = Unit.Pixel(54)
            layout.Bands(1).Columns.FromKey("suZipCode").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("moStartDate").Width = Unit.Pixel(20)
            layout.Bands(1).Columns.FromKey("moSchdAmtInt").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("moLastName").Width = Unit.Pixel(54)
            layout.Bands(1).Columns.FromKey("moZipCode").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("tuStartDate").Width = Unit.Pixel(20)
            layout.Bands(1).Columns.FromKey("tuSchdAmtInt").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("tuLastName").Width = Unit.Pixel(54)
            layout.Bands(1).Columns.FromKey("tuZipCode").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("weStartDate").Width = Unit.Pixel(20)
            layout.Bands(1).Columns.FromKey("weSchdAmtInt").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("weLastName").Width = Unit.Pixel(54)
            layout.Bands(1).Columns.FromKey("weZipCode").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("thStartDate").Width = Unit.Pixel(20)
            layout.Bands(1).Columns.FromKey("thSchdAmtInt").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("thLastName").Width = Unit.Pixel(54)
            layout.Bands(1).Columns.FromKey("thZipCode").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("frStartDate").Width = Unit.Pixel(20)
            layout.Bands(1).Columns.FromKey("frSchdAmtInt").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("frLastName").Width = Unit.Pixel(54)
            layout.Bands(1).Columns.FromKey("frZipCode").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("saStartDate").Width = Unit.Pixel(20)
            layout.Bands(1).Columns.FromKey("saSchdAmtInt").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("saLastName").Width = Unit.Pixel(54)
            layout.Bands(1).Columns.FromKey("saZipCode").Width = Unit.Pixel(30)
            layout.Bands(1).Columns.FromKey("suSchdAmtInt").CellStyle.HorizontalAlign = 3
            layout.Bands(1).Columns.FromKey("moSchdAmtInt").CellStyle.HorizontalAlign = 3
            layout.Bands(1).Columns.FromKey("tuSchdAmtInt").CellStyle.HorizontalAlign = 3
            layout.Bands(1).Columns.FromKey("weSchdAmtInt").CellStyle.HorizontalAlign = 3
            layout.Bands(1).Columns.FromKey("thSchdAmtInt").CellStyle.HorizontalAlign = 3
            layout.Bands(1).Columns.FromKey("frSchdAmtInt").CellStyle.HorizontalAlign = 3
            layout.Bands(1).Columns.FromKey("saSchdAmtInt").CellStyle.HorizontalAlign = 3
            layout.Bands(1).Columns.FromKey("suStartDate").Format = "HH"
            layout.Bands(1).Columns.FromKey("moStartDate").Format = "HH"
            layout.Bands(1).Columns.FromKey("tuStartDate").Format = "HH"
            layout.Bands(1).Columns.FromKey("weStartDate").Format = "HH"
            layout.Bands(1).Columns.FromKey("thStartDate").Format = "HH"
            layout.Bands(1).Columns.FromKey("frStartDate").Format = "HH"
            layout.Bands(1).Columns.FromKey("saStartDate").Format = "HH"
            layout.Bands(1).Columns.FromKey("suStartDate").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("suSchdAmtInt").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("suLastName").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("suZipCode").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("tuStartDate").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("tuSchdAmtInt").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("tuLastName").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("tuZipCode").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("thStartDate").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("thSchdAmtInt").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("thLastName").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("thZipCode").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("saStartDate").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("saSchdAmtInt").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("saLastName").CellStyle.BackColor = (Color.Gainsboro())
            layout.Bands(1).Columns.FromKey("saZipCode").CellStyle.BackColor = (Color.Gainsboro())
            layout = Nothing
        End Sub

        Private Sub UWGSched_InitializeRow(ByVal sender As Object, ByVal e As RowEventArgs) Handles UWGSched.InitializeRow
            Dim objArray As Object()
            If (e.Row.Band.Index = 0) Then
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("height").Value, 2, False) > 0) Then
                    e.Row.Cells.FromKey("nick_Name").Style.BackColor = (Color.Magenta())
                End If
                e.Row.Cells.FromKey("suDef").Value = String.Concat(e.Row.Cells.FromKey("dollarMaxAmount").Value.ToString(), "/", e.Row.Cells.FromKey("suRemainder").Value.ToString(), " ")
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("suAM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("suDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("suDef").Value, "AM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("suPM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("suDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("suDef").Value, "PM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("suRemainder").Value, 0, False) < 0) Then
                    e.Row.Cells.FromKey("suDef").Style.BackColor = (Color.LightCoral())
                End If
                e.Row.Cells.FromKey("moDef").Value = String.Concat(e.Row.Cells.FromKey("dollarMaxAmount").Value.ToString(), "/", e.Row.Cells.FromKey("moRemainder").ToString(), " ")
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("moAM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("moDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("moDef").Value, "AM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("moPM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("moDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("moDef").Value, "PM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("moRemainder").Value, 0, False) < 0) Then
                    e.Row.Cells.FromKey("moDef").Style.BackColor = (Color.LightCoral())
                End If
                e.Row.Cells.FromKey("tuDef").Value = String.Concat(e.Row.Cells.FromKey("dollarMaxAmount").Value.ToString(), "/", e.Row.Cells.FromKey("tuRemainder").ToString(), " ")
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("tuAM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("tuDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("tuDef").Value, "AM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("tuPM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("tuDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("tuDef").Value, "PM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("tuRemainder").Value, 0, False) < 0) Then
                    e.Row.Cells.FromKey("tuDef").Style.BackColor = (Color.LightCoral())
                End If
                e.Row.Cells.FromKey("weDef").Value = String.Concat(e.Row.Cells.FromKey("dollarMaxAmount").Value.ToString(), "/", e.Row.Cells.FromKey("weRemainder").ToString(), " ")
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("weAM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("weDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("weDef").Value, "AM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("wePM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("weDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("weDef").Value, "PM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("weRemainder").Value, 0, False) < 0) Then
                    e.Row.Cells.FromKey("weDef").Style.BackColor = (Color.LightCoral())
                End If
                e.Row.Cells.FromKey("thDef").Value = String.Concat(e.Row.Cells.FromKey("dollarMaxAmount").Value.ToString(), "/", e.Row.Cells.FromKey("thRemainder").ToString(), " ")
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("thAM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("thDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("thDef").Value, "AM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("thPM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("thDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("thDef").Value, "PM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("thRemainder").Value, 0, False) < 0) Then
                    e.Row.Cells.FromKey("thDef").Style.BackColor = (Color.LightCoral())
                End If
                e.Row.Cells.FromKey("frDef").Value = String.Concat(e.Row.Cells.FromKey("dollarMaxAmount").Value.ToString(), "/", e.Row.Cells.FromKey("frRemainder").ToString(), " ")
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("frAM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("frDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("frDef").Value, "AM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("frPM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("frDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("frDef").Value, "PM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("frRemainder").Value, 0, False) < 0) Then
                    e.Row.Cells.FromKey("frDef").Style.BackColor = (Color.LightCoral())
                End If
                e.Row.Cells.FromKey("saDef").Value = String.Concat(e.Row.Cells.FromKey("dollarMaxAmount").Value.ToString(), "/", e.Row.Cells.FromKey("saRemainder").ToString(), " ")
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("saAM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("saDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("saDef").Value, "AM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("saPM").Value, "0", False) = 0) Then
                    e.Row.Cells.FromKey("saDef").Value = ObjectType.AddObj(e.Row.Cells.FromKey("saDef").Value, "PM")
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("saRemainder").Value, 0, False) < 0) Then
                    e.Row.Cells.FromKey("saDef").Style.BackColor = (Color.LightCoral())
                End If
            End If
            If (e.Row.Band.Index = 1) Then
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("suZipCode").Value, Nothing, False) <> 0) Then
                    Dim objectValue As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("suZipCode")
                    Dim value As Object = e.Row.Cells.FromKey("suZipCode").Value
                    objArray = New Object() {2, 3}
                    objectValue.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(value, Nothing, "SubString", objArray, Nothing, Nothing))
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("suCritical").Value, "1", False) = 0) Then
                        e.Row.Cells.FromKey("suStartDate").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("suStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                        e.Row.Cells.FromKey("suStartDate").Style.BackColor = (Color.LightGreen())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("suStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                        e.Row.Cells.FromKey("suStartDate").Style.BackColor = (Color.LightPink())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("suStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                        e.Row.Cells.FromKey("suStartDate").Style.BackColor = (Color.Yellow())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("suStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                        e.Row.Cells.FromKey("suStartDate").Style.BackColor = (Color.Orange())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("suReminder").Value) = 1) Then
                        e.Row.Cells.FromKey("suSchdAmtInt").Style.BackColor = (Color.CornflowerBlue())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("suNoStories").Value) > 2) Then
                        e.Row.Cells.FromKey("suZipCode").Style.BackColor = (Color.Magenta())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("suNoteType").Value) = 1) Then
                        e.Row.Cells.FromKey("suLastName").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("suStatus").Value, "D", False) = 0) Then
                        e.Row.Cells.FromKey("suZipCode").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("suStartDate").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("suLastName").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("suSchdAmtInt").Style.ForeColor = (Color.Green())
                    ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("suStatus").Value, "C", False) = 0) Then
                        e.Row.Cells.FromKey("suZipCode").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("suStartDate").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("suLastName").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("suSchdAmtInt").Style.ForeColor = (Color.Blue())
                    End If
                Else
                    e.Row.Cells.FromKey("suZipCode").Value = ""
                    e.Row.Cells.FromKey("suStartDate").Value = ""
                    e.Row.Cells.FromKey("suLastName").Value = ""
                    e.Row.Cells.FromKey("suSchdAmtInt").Value = ""
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("moZipCode").Value, Nothing, False) <> 0) Then
                    Dim ultraGridCell As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("moZipCode")
                    Dim obj As Object = e.Row.Cells.FromKey("moZipCode").Value
                    objArray = New Object() {2, 3}
                    ultraGridCell.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(obj, Nothing, "SubString", objArray, Nothing, Nothing))
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("moCritical").Value, "1", False) = 0) Then
                        e.Row.Cells.FromKey("moStartDate").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("moStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                        e.Row.Cells.FromKey("moStartDate").Style.BackColor = (Color.LightGreen())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("moStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                        e.Row.Cells.FromKey("moStartDate").Style.BackColor = (Color.LightPink())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("moStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                        e.Row.Cells.FromKey("moStartDate").Style.BackColor = (Color.Yellow())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("moStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                        e.Row.Cells.FromKey("moStartDate").Style.BackColor = (Color.Orange())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("moReminder").Value) = 1) Then
                        e.Row.Cells.FromKey("moSchdAmtInt").Style.BackColor = (Color.CornflowerBlue())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("moNoStories").Value) > 2) Then
                        e.Row.Cells.FromKey("moZipCode").Style.BackColor = (Color.Magenta())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("moNoteType").Value) = 1) Then
                        e.Row.Cells.FromKey("moLastName").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("moStatus").Value, "D", False) = 0) Then
                        e.Row.Cells.FromKey("moZipCode").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("moStartDate").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("moLastName").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("moSchdAmtInt").Style.ForeColor = (Color.Green())
                    ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("moStatus").Value, "C", False) = 0) Then
                        e.Row.Cells.FromKey("moZipCode").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("moStartDate").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("moLastName").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("moSchdAmtInt").Style.ForeColor = (Color.Blue())
                    End If
                Else
                    e.Row.Cells.FromKey("moZipCode").Value = ""
                    e.Row.Cells.FromKey("moStartDate").Value = ""
                    e.Row.Cells.FromKey("moLastName").Value = ""
                    e.Row.Cells.FromKey("moSchdAmtInt").Value = ""
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("tuZipCode").Value, Nothing, False) <> 0) Then
                    Dim objectValue1 As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("tuZipCode")
                    Dim value1 As Object = e.Row.Cells.FromKey("tuZipCode").Value
                    'objArray = New Object() {2, 3}
                    objectValue1.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(value1, Nothing, "SubString", New Object() {2, 3}, Nothing, Nothing))
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("tuCritical").Value, "1", False) = 0) Then
                        e.Row.Cells.FromKey("tuStartDate").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("tuStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                        e.Row.Cells.FromKey("tuStartDate").Style.BackColor = (Color.LightGreen())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("tuStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                        e.Row.Cells.FromKey("tuStartDate").Style.BackColor = (Color.LightPink())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("tuStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                        e.Row.Cells.FromKey("tuStartDate").Style.BackColor = (Color.Yellow())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("tuStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                        e.Row.Cells.FromKey("tuStartDate").Style.BackColor = (Color.Orange())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("tuReminder").Value) = 1) Then
                        e.Row.Cells.FromKey("tuSchdAmtInt").Style.BackColor = (Color.CornflowerBlue())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("tuNoStories").Value) > 2) Then
                        e.Row.Cells.FromKey("tuZipCode").Style.BackColor = (Color.Magenta())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("tuNoteType").Value) = 1) Then
                        e.Row.Cells.FromKey("tuLastName").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("tuStatus").Value, "D", False) = 0) Then
                        e.Row.Cells.FromKey("tuZipCode").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("tuStartDate").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("tuLastName").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("tuSchdAmtInt").Style.ForeColor = (Color.Green())
                    ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("tuStatus").Value, "C", False) = 0) Then
                        e.Row.Cells.FromKey("tuZipCode").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("tuStartDate").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("tuLastName").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("tuSchdAmtInt").Style.ForeColor = (Color.Blue())
                    End If
                Else
                    e.Row.Cells.FromKey("tuZipCode").Value = ""
                    e.Row.Cells.FromKey("tuStartDate").Value = ""
                    e.Row.Cells.FromKey("tuLastName").Value = ""
                    e.Row.Cells.FromKey("tuSchdAmtInt").Value = ""
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("weZipCode").Value, Nothing, False) <> 0) Then
                    Dim ultraGridCell1 As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("weZipCode")
                    Dim obj1 As Object = e.Row.Cells.FromKey("weZipCode").Value
                    objArray = New Object() {2, 3}
                    ultraGridCell1.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(obj1, Nothing, "SubString", objArray, Nothing, Nothing))
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("weCritical").Value, "1", False) = 0) Then
                        e.Row.Cells.FromKey("weStartDate").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("weStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                        e.Row.Cells.FromKey("weStartDate").Style.BackColor = (Color.LightGreen())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("weStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                        e.Row.Cells.FromKey("weStartDate").Style.BackColor = (Color.LightPink())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("weStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                        e.Row.Cells.FromKey("weStartDate").Style.BackColor = (Color.Yellow())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("weStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                        e.Row.Cells.FromKey("weStartDate").Style.BackColor = (Color.Orange())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("weReminder").Value) = 1) Then
                        e.Row.Cells.FromKey("weSchdAmtInt").Style.BackColor = (Color.CornflowerBlue())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("weNoStories").Value) > 2) Then
                        e.Row.Cells.FromKey("weZipCode").Style.BackColor = (Color.Magenta())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("weNoteType").Value) = 1) Then
                        e.Row.Cells.FromKey("weLastName").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("weStatus").Value, "D", False) = 0) Then
                        e.Row.Cells.FromKey("weZipCode").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("weStartDate").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("weLastName").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("weSchdAmtInt").Style.ForeColor = (Color.Green())
                    ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("weStatus").Value, "C", False) = 0) Then
                        e.Row.Cells.FromKey("weZipCode").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("weStartDate").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("weLastName").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("weSchdAmtInt").Style.ForeColor = (Color.Blue())
                    End If
                Else
                    e.Row.Cells.FromKey("weZipCode").Value = ""
                    e.Row.Cells.FromKey("weStartDate").Value = ""
                    e.Row.Cells.FromKey("weLastName").Value = ""
                    e.Row.Cells.FromKey("weSchdAmtInt").Value = ""
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("thZipCode").Value, Nothing, False) <> 0) Then
                    Dim objectValue2 As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("thZipCode")
                    Dim value2 As Object = e.Row.Cells.FromKey("thZipCode").Value
                    objArray = New Object() {2, 3}
                    objectValue2.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(value2, Nothing, "SubString", objArray, Nothing, Nothing))
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("thCritical").Value, "1", False) = 0) Then
                        e.Row.Cells.FromKey("thStartDate").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("thStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                        e.Row.Cells.FromKey("thStartDate").Style.BackColor = (Color.LightGreen())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("thStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                        e.Row.Cells.FromKey("thStartDate").Style.BackColor = (Color.LightPink())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("thStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                        e.Row.Cells.FromKey("thStartDate").Style.BackColor = (Color.Yellow())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("thStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                        e.Row.Cells.FromKey("thStartDate").Style.BackColor = (Color.Orange())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("thReminder").Value) = 1) Then
                        e.Row.Cells.FromKey("thSchdAmtInt").Style.BackColor = (Color.CornflowerBlue())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("thNoStories").Value) > 2) Then
                        e.Row.Cells.FromKey("thZipCode").Style.BackColor = (Color.Magenta())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("thNoteType").Value) = 1) Then
                        e.Row.Cells.FromKey("thLastName").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("thStatus").Value, "D", False) = 0) Then
                        e.Row.Cells.FromKey("thZipCode").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("thStartDate").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("thLastName").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("thSchdAmtInt").Style.ForeColor = (Color.Green())
                    ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("thStatus").Value, "C", False) = 0) Then
                        e.Row.Cells.FromKey("thZipCode").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("thStartDate").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("thLastName").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("thSchdAmtInt").Style.ForeColor = (Color.Blue())
                    End If
                Else
                    e.Row.Cells.FromKey("thZipCode").Value = ""
                    e.Row.Cells.FromKey("thStartDate").Value = ""
                    e.Row.Cells.FromKey("thLastName").Value = ""
                    e.Row.Cells.FromKey("thSchdAmtInt").Value = ""
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("frZipCode").Value, Nothing, False) <> 0) Then
                    Dim ultraGridCell2 As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("frZipCode")
                    Dim obj2 As Object = e.Row.Cells.FromKey("frZipCode").Value
                    objArray = New Object() {2, 3}
                    ultraGridCell2.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(obj2, Nothing, "SubString", objArray, Nothing, Nothing))
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("frCritical").Value, "1", False) = 0) Then
                        e.Row.Cells.FromKey("frStartDate").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("frStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                        e.Row.Cells.FromKey("frStartDate").Style.BackColor = (Color.LightGreen())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("frStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                        e.Row.Cells.FromKey("frStartDate").Style.BackColor = (Color.LightPink())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("frStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                        e.Row.Cells.FromKey("frStartDate").Style.BackColor = (Color.Yellow())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("frStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                        e.Row.Cells.FromKey("frStartDate").Style.BackColor = (Color.Orange())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("frReminder").Value) = 1) Then
                        e.Row.Cells.FromKey("frSchdAmtInt").Style.BackColor = (Color.CornflowerBlue())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("frNoStories").Value) > 2) Then
                        e.Row.Cells.FromKey("frZipCode").Style.BackColor = (Color.Magenta())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("frNoteType").Value) = 1) Then
                        e.Row.Cells.FromKey("frLastName").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("frStatus").Value, "D", False) = 0) Then
                        e.Row.Cells.FromKey("frZipCode").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("frStartDate").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("frLastName").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("frSchdAmtInt").Style.ForeColor = (Color.Green())
                    ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("frStatus").Value, "C", False) = 0) Then
                        e.Row.Cells.FromKey("frZipCode").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("frStartDate").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("frLastName").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("frSchdAmtInt").Style.ForeColor = (Color.Blue())
                    End If
                Else
                    e.Row.Cells.FromKey("frZipCode").Value = ""
                    e.Row.Cells.FromKey("frStartDate").Value = ""
                    e.Row.Cells.FromKey("frLastName").Value = ""
                    e.Row.Cells.FromKey("frSchdAmtInt").Value = ""
                End If
                If (ObjectType.ObjTst(e.Row.Cells.FromKey("saZipCode").Value, Nothing, False) <> 0) Then
                    Dim objectValue3 As Infragistics.WebUI.UltraWebGrid.UltraGridCell = e.Row.Cells.FromKey("saZipCode")
                    Dim value3 As Object = e.Row.Cells.FromKey("saZipCode").Value
                    objArray = New Object() {2, 3}
                    objectValue3.Value = RuntimeHelpers.GetObjectValue(LateBinding.LateGet(value3, Nothing, "SubString", objArray, Nothing, Nothing))
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("saCritical").Value, "1", False) = 0) Then
                        e.Row.Cells.FromKey("saStartDate").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("saStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 0, False) = 0) Then
                        e.Row.Cells.FromKey("saStartDate").Style.BackColor = (Color.LightGreen())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("saStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 23, False) = 0) Then
                        e.Row.Cells.FromKey("saStartDate").Style.BackColor = (Color.LightPink())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("saStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 1, False) = 0) Then
                        e.Row.Cells.FromKey("saStartDate").Style.BackColor = (Color.Yellow())
                    ElseIf (ObjectType.ObjTst(LateBinding.LateGet(e.Row.Cells.FromKey("saStartDate").Value, Nothing, "hour", New Object(-1) {}, Nothing, Nothing), 22, False) = 0) Then
                        e.Row.Cells.FromKey("saStartDate").Style.BackColor = (Color.Orange())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("saReminder").Value) = 1) Then
                        e.Row.Cells.FromKey("saSchdAmtInt").Style.BackColor = (Color.CornflowerBlue())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("saNoStories").Value) > 2) Then
                        e.Row.Cells.FromKey("saZipCode").Style.BackColor = (Color.Magenta())
                    End If
                    If (IntegerType.FromObject(e.Row.Cells.FromKey("saNoteType").Value) = 1) Then
                        e.Row.Cells.FromKey("saLastName").Style.BackColor = (Color.LightCoral())
                    End If
                    If (ObjectType.ObjTst(e.Row.Cells.FromKey("saStatus").Value, "D", False) = 0) Then
                        e.Row.Cells.FromKey("saZipCode").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("saStartDate").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("saLastName").Style.ForeColor = (Color.Green())
                        e.Row.Cells.FromKey("saSchdAmtInt").Style.ForeColor = (Color.Green())
                    ElseIf (ObjectType.ObjTst(e.Row.Cells.FromKey("saStatus").Value, "C", False) = 0) Then
                        e.Row.Cells.FromKey("saZipCode").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("saStartDate").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("saLastName").Style.ForeColor = (Color.Blue())
                        e.Row.Cells.FromKey("saSchdAmtInt").Style.ForeColor = (Color.Blue())
                    End If
                Else
                    e.Row.Cells.FromKey("saZipCode").Value = ""
                    e.Row.Cells.FromKey("saStartDate").Value = ""
                    e.Row.Cells.FromKey("saLastName").Value = ""
                    e.Row.Cells.FromKey("saSchdAmtInt").Value = ""
                End If
            End If
        End Sub

        Private Function validateTime(ByVal time As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (time.Length() <= 0) Then
                messageHelper.status = True
                messageHelper.messageObject = 0
            ElseIf (Not Information.IsNumeric(time)) Then
                messageHelper.messageText = "Invalid Time"
            ElseIf (DoubleType.FromString(time) >= 24) Then
                messageHelper.messageText = "Invalid Time"
            Else
                messageHelper.status = True
                messageHelper.messageObject = time
            End If
            Return messageHelper
        End Function
    End Class
End Namespace