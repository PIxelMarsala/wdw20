Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI

Namespace wdw
    Public Class Address1
        Inherits PageBase
        Public Sub New()
            MyBase.New()
            Dim address11 As Address1 = Me
            'MyBase.add_Init(New EventHandler(address11, address11.Page_Init))
        End Sub

        '<DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("AddressState")
        End Function

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("AddressState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub
    End Class
End Namespace