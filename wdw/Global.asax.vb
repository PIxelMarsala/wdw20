Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.Remoting
Imports System.Web
Imports SystemFramework

Public Class Global_asax
    Inherits HttpApplication
    'Private components As IContainer

    'Public Sub New()
    '    MyBase.New()
    '    Me.InitializeComponent()
    'End Sub

    Sub Application_Start(sender As Object, e As EventArgs)
        'ApplicationConfiguration.OnApplicationStart(Me.Context().Server().MapPath(Me.Context().Request().ApplicationPath()))
        'Dim str As String = Path.Combine(Me.Context().Server().MapPath(Me.Context().Request().ApplicationPath()), "remotingclient.cfg")
        'If (File.Exists(str)) Then
        '    RemotingConfiguration.Configure(str)
        'End If
    End Sub

    'Private Sub InitializeComponent()
    '    Me.components = New Container()
    'End Sub
End Class