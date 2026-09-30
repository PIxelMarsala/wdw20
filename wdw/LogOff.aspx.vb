Imports System
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI

Namespace wdw
    Public Class LogOff
        Inherits PageBase
        Public Sub New()
            MyBase.New()
            Dim logOff1 As LogOff = Me
            'MyBase.add_Load(New EventHandler(logOff1, logOff1.Page_Load))
            Dim logOff2 As LogOff = Me
            'MyBase.add_Init(New EventHandler(logOff2, logOff2.Page_Init))
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            FormsAuthentication.SignOut()
            Me.[Operator] = Nothing
            Me.Server().Transfer("Logon.aspx")
        End Sub
    End Class
End Namespace