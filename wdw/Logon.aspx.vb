Imports BusinessService
Imports Common
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class Logon
        Inherits PageBase
        Private uccSecurity As UCCSecurity

        Private uccCompany As UCCCompany

        Public Sub New()
            MyBase.New()
            Dim logon1 As Logon = Me
            Dim logon2 As Logon = Me

            Me.uccSecurity = New UCCSecurity()
            Me.uccCompany = New UCCCompany()
        End Sub

        '<DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub LogonButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LogonButton.Click
            Me.MismatchLabel.Visible = (False)
            Me.LogonValidationSummary.Visible = (False)
            If (Not Me.Page().IsValid()) Then
                Return
            End If
            Dim messageHelper As SystemFramework.MessageHelper = Me.uccSecurity.logon(IntegerType.FromString(Me.lstCompany.SelectedItem().Value), Me.txtUserId.Text(), FormsAuthentication.HashPasswordForStoringInConfigFile(Me.txtPassword.Text(), "SHA1"))
            If (Not messageHelper.status) Then
                Me.MismatchLabel.Text = (messageHelper.messageText)
                Me.MismatchLabel.Visible = (True)
            Else
                MyBase.[Operator] = DirectCast(messageHelper.messageObject, [Operator])
                FormsAuthentication.RedirectFromLoginPage("*", False)
            End If
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            If (Not Me.Page().IsPostBack()) Then
                Dim all As SqlDataReader = Me.uccCompany.getAll()
                Me.lstCompany.DataSource = (all)
                Me.lstCompany.DataValueField = ("Company_ID")
                Me.lstCompany.DataTextField = ("Name")
                Me.lstCompany.DataBind()

                If Common.WDWConfiguration.EnvironmentFlag <> "PROD" Then
                    Me.litDevWarning.Text = "<div class=""devwarning"">Running in " & WDWConfiguration.EnvironmentFlag & " environment. (Set in wdwConfiguration)</div>"
                    Me.litDevWarning.Visible = True
                Else
                    Me.litDevWarning.Visible = False
                End If
            End If
        End Sub
    End Class
End Namespace