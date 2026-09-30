Imports Infragistics.WebUI.UltraWebNavigator
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.UI

Namespace wdw
    Public MustInherit Class topmenu
        Inherits ControlBase

        '<AccessedThroughProperty("UltraWebMenu1")>
        'Private _UltraWebMenu1 As UltraWebMenu

        'Protected Overridable Property UltraWebMenu1 As UltraWebMenu
        '    Get
        '        Return Me._UltraWebMenu1
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As UltraWebMenu)
        '        If (Me._UltraWebMenu1 IsNot Nothing) Then
        '            Dim _topmenu As topmenu = Me
        '            RemoveHandler Me._UltraWebMenu1.MenuItemClicked, New MenuItemClickedEventHandler(AddressOf _topmenu.UltraWebMenu1_MenuItemClicked)
        '        End If
        '        Me._UltraWebMenu1 = value
        '        If (Me._UltraWebMenu1 IsNot Nothing) Then
        '            Dim _topmenu1 As topmenu = Me
        '            AddHandler Me._UltraWebMenu1.MenuItemClicked, New MenuItemClickedEventHandler(AddressOf _topmenu1.UltraWebMenu1_MenuItemClicked)
        '        End If
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim _topmenu As topmenu = Me
            'MyBase.add_Init(New EventHandler(_topmenu, _topmenu.Page_Init))
            Dim _topmenu1 As topmenu = Me
            'MyBase.add_Load(New EventHandler(_topmenu1, _topmenu1.Page_Load))
        End Sub

        '<DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        End Sub

        'Private Sub UltraWebMenu1_MenuItemClicked(ByVal sender As Object, ByVal e As WebMenuItemEventArgs)
        'End Sub
    End Class
End Namespace