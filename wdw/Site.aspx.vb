Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI

Namespace wdw
    Public Class Site1
        Inherits PageBase
        Public Sub New()
            MyBase.New()
            Dim site11 As Site1 = Me
            'MyBase.add_Init(New EventHandler(site11, site11.Page_Init))
        End Sub

        '<DebuggerStepThrough>
        'Private Sub InitializeComponent()
        'End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("SiteState")
        End Function

        'Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        '    Me.InitializeComponent()
        'End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("SiteState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub
    End Class
End Namespace