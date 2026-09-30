Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports SystemFramework

Namespace wdw
    Public Class hasher
        Inherits PageBase
        '<AccessedThroughProperty("btnEncrypt")>
        'Private _btnEncrypt As Button

        '<AccessedThroughProperty("btnDecrypt")>
        'Private _btnDecrypt As Button

        '<AccessedThroughProperty("txtHashed")>
        'Private _txtHashed As TextBox

        '<AccessedThroughProperty("txtPassword")>
        'Private _txtPassword As TextBox

        '<AccessedThroughProperty("hash")>
        'Private _hash As Button

        Private FUNCTIONNAME As String

        'Protected Overridable Property btnDecrypt As Button
        '    Get
        '        Return Me._btnDecrypt
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnDecrypt IsNot Nothing) Then
        '            Dim _hasher As hasher = Me
        '            Me._btnDecrypt.remove_Click(New EventHandler(_hasher, _hasher.btnDecrypt_Click))
        '        End If
        '        Me._btnDecrypt = value
        '        If (Me._btnDecrypt IsNot Nothing) Then
        '            Dim _hasher1 As hasher = Me
        '            Me._btnDecrypt.add_Click(New EventHandler(_hasher1, _hasher1.btnDecrypt_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property btnEncrypt As Button
        '    Get
        '        Return Me._btnEncrypt
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._btnEncrypt IsNot Nothing) Then
        '            Dim _hasher As hasher = Me
        '            Me._btnEncrypt.remove_Click(New EventHandler(_hasher, _hasher.btnEncrypt_Click))
        '        End If
        '        Me._btnEncrypt = value
        '        If (Me._btnEncrypt IsNot Nothing) Then
        '            Dim _hasher1 As hasher = Me
        '            Me._btnEncrypt.add_Click(New EventHandler(_hasher1, _hasher1.btnEncrypt_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property hash As Button
        '    Get
        '        Return Me._hash
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As Button)
        '        If (Me._hash IsNot Nothing) Then
        '            Dim _hasher As hasher = Me
        '            Me._hash.remove_Click(New EventHandler(_hasher, _hasher.hash_Click))
        '        End If
        '        Me._hash = value
        '        If (Me._hash IsNot Nothing) Then
        '            Dim _hasher1 As hasher = Me
        '            Me._hash.add_Click(New EventHandler(_hasher1, _hasher1.hash_Click))
        '        End If
        '    End Set
        'End Property

        'Protected Overridable Property txtHashed As TextBox
        '    Get
        '        Return Me._txtHashed
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtHashed Is Nothing
        '        Me._txtHashed = value
        '        Me._txtHashed Is Nothing
        '    End Set
        'End Property

        'Protected Overridable Property txtPassword As TextBox
        '    Get
        '        Return Me._txtPassword
        '    End Get
        '    <MethodImpl(32)>
        '    Set(ByVal value As TextBox)
        '        Me._txtPassword Is Nothing
        '        Me._txtPassword = value
        '        Me._txtPassword Is Nothing
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
            Dim _hasher As hasher = Me
            'MyBase.add_Init(New EventHandler(_hasher, _hasher.Page_Init))
            Dim _hasher1 As hasher = Me
            'MyBase.add_Load(New EventHandler(_hasher1, _hasher1.Page_Load))
            Me.FUNCTIONNAME = "Hasher"
        End Sub

        Private Sub btnDecrypt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDecrypt.Click
            Dim tripleDE As TripleDES = New TripleDES()
            Me.txtPassword.Text = (tripleDE.Decrypt(Strings.Trim(Me.txtHashed.Text()), "", ""))
        End Sub

        Private Sub btnEncrypt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEncrypt.Click
            Dim tripleDE As TripleDES = New TripleDES()
            Me.txtHashed.Text = (tripleDE.Encrypt(Strings.Trim(Me.txtPassword.Text()), "", ""))
        End Sub

        Private Sub hash_Click(ByVal sender As Object, ByVal e As EventArgs) Handles hash.Click
            Me.txtHashed.Text = (FormsAuthentication.HashPasswordForStoringInConfigFile(Me.txtPassword.Text(), "SHA1"))
        End Sub

        <DebuggerStepThrough>
        Private Sub InitializeComponent()
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            Me.InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim messageHelper As SystemFramework.MessageHelper = (New UISecurity()).validateSecurity(Me.FUNCTIONNAME)
        End Sub
    End Class
End Namespace