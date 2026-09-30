Imports BusinessService
Imports CrystalDecisions.Web
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class Deposit
        Inherits PageBase
        '<AccessedThroughProperty("CrystalReportViewer1")>
        'Private _CrystalReportViewer1 As CrystalReportViewer

        '<AccessedThroughProperty("btnDone")>
        'Private _btnDone As Button

        Private crystalUtil1 As CrystalUtil

        Private crReportDocument As Dep

        Private designerPlaceholderDeclaration As Object

        'Protected Overridable Property btnDone As Button
        '    Get
        '        Return Me._btnDone
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnDone IsNot Nothing) Then
        '            Dim deposit As wdw.Deposit = Me
        '            Me._btnDone.remove_Click(New EventHandler(deposit, deposit.btnDone_Click))
        '        End If
        '        Me._btnDone = value
        '        If (Me._btnDone IsNot Nothing) Then
        '            Dim deposit1 As wdw.Deposit = Me
        '            Me._btnDone.add_Click(New EventHandler(deposit1, deposit1.btnDone_Click))
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

        Public Sub New()
            MyBase.New()
            Dim deposit1 As Deposit = Me
            'MyBase.add_Init(New EventHandler(deposit1, deposit1.Page_Init))
            Dim deposit2 As Deposit = Me
            'MyBase.add_Load(New EventHandler(deposit2, deposit2.Page_Load))
            Me.crystalUtil1 = New CrystalUtil()
            Me.crReportDocument = New Dep()
        End Sub

        Private Sub btnDone_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDone.Click
            UCCParams.updateDepositStatus()
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Me.crystalUtil1.ChangeDataSource(Me.crReportDocument)
            CrystalUtil.CrystalReportFormatter(Me.CrystalReportViewer1)
        End Sub
    End Class
End Namespace