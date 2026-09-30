Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI

Namespace wdw
    Public Class Subcontractor
        Inherits PageBase
        Public Sub New()
            MyBase.New()
            Dim subcontractor1 As Subcontractor = Me
            'MyBase.add_Init(New EventHandler(subcontractor1, subcontractor1.Page_Init))
            Dim subcontractor2 As Subcontractor = Me
            'MyBase.add_Load(New EventHandler(subcontractor2, subcontractor2.Page_Load))
        End Sub

        '<DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
            Return Me.Session().Item("SubcontractorState")
        End Function

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        End Sub

        Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
            Me.Session().Add("SubcontractorState", RuntimeHelpers.GetObjectValue(viewState))
        End Sub
    End Class
End Namespace