Imports BusinessService
Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Web
Imports System.Web.UI

Namespace wdw
    Public Class _Default
        Inherits PageBase

        Public Sub New()
            MyBase.New()
            Dim __Default As _Default = Me
            'MyBase.add_Load(New EventHandler(__Default, __Default.Page_Load))
            Dim __Default1 As _Default = Me
            'MyBase.add_Init(New EventHandler(__Default1, __Default1.Page_Init))
        End Sub

        '<DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then

                If Not Me.[Operator] Is Nothing Then
                    If Me.[Operator].defaultTarget <> "" Then
                        Me.Response().Redirect(Me.[Operator].defaultTarget)
                    End If
                End If

                Response.Redirect("Logon.aspx")
            End If

            ' Original
            'If (Not Me.Page().IsPostBack() AndAlso StringType.StrCmp(Strings.Trim(Me.[Operator].defaultTarget), "", False) <> 0) Then
            '    Me.Response().Redirect(Me.[Operator].defaultTarget)
            'End If

        End Sub
    End Class
End Namespace