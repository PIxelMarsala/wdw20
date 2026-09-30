Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace wdw
    Public Class SecurityViolation
        Inherits PageBase
        '<AccessedThroughProperty("Label3")>
        'Private _Label3 As Label

        '<AccessedThroughProperty("Label1")>
        'Private _Label1 As Label

        '<AccessedThroughProperty("Label2")>
        'Private _Label2 As Label

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

        'Protected Overridable Property Label3 As Label
        '    Get
        '        Return Me._Label3
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Label)
        '        Me._Label3 Is Nothing
        '        Me._Label3 = value
        '        Me._Label3 Is Nothing
        '    End Set
        'End Property

        'Public Sub New()
        '    MyBase.New()
        '    Dim securityViolation1 As SecurityViolation = Me
        '    'MyBase.add_Init(New EventHandler(securityViolation1, securityViolation1.Page_Init))
        '    Dim securityViolation2 As SecurityViolation = Me
        '    'MyBase.add_Load(New EventHandler(securityViolation2, securityViolation2.Page_Load))
        'End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        'Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        'End Sub
    End Class
End Namespace