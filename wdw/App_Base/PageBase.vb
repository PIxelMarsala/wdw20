Imports BusinessService
Imports Common
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports SystemFramework

Namespace wdw
    Public Class PageBase
        Inherits Page

        'Private Const UNHANDLED_EXCEPTION As String = "Unhandled Exception:"
        'Private Const KEY_CACHEOPERATOR As String = "Cache:Operator:"
        'Private Shared pageSecureUrlBase As String
        'Private Shared pageUrlBase As String
        'Private Shared urlSuffix As String

        Public Property [Operator] As [Operator]
            Get
                Dim item As [Operator]
                Try
                    item = DirectCast(Me.Session().Item("Cache:Operator:"), [Operator])
                Catch exception As System.Exception
                    ProjectData.SetProjectError(exception)
                    item = Nothing
                    ProjectData.ClearProjectError()
                End Try
                Return item
            End Get
            Set(ByVal value As [Operator])
                If (value IsNot Nothing) Then
                    Me.Session().Item("Cache:Operator:") = value
                Else
                    Me.Session().Remove("Cache:Operator:")
                End If
            End Set
        End Property

        'Public Shared ReadOnly Property SecureUrlBase As String
        '    Get
        '        Dim str As String = Nothing
        '        If (str Is Nothing) Then
        '            If (Not WDWConfiguration.EnableSsl) Then
        '                PageBase.pageSecureUrlBase = "http://"
        '            Else
        '                PageBase.pageSecureUrlBase = "https://"
        '            End If
        '            PageBase.pageSecureUrlBase = String.Concat(PageBase.pageSecureUrlBase, PageBase.urlSuffix)
        '        End If
        '        str = PageBase.pageSecureUrlBase
        '        Return str
        '    End Get
        'End Property

        'Public Shared ReadOnly Property UrlBase As String
        '    Get
        '        Return PageBase.pageUrlBase
        '    End Get
        'End Property

        'Public Sub New()
        '    MyBase.New()
        '    Try
        '        PageBase.urlSuffix = String.Concat(Me.Context().Request().Url().Host(), Me.Context().Request().ApplicationPath())
        '        PageBase.pageUrlBase = String.Concat("http://", PageBase.urlSuffix)
        '    Catch exception As System.Exception
        '        ProjectData.SetProjectError(exception)
        '        ProjectData.ClearProjectError()
        '    End Try
        'End Sub

        Protected Overrides Sub OnPreLoad(e As EventArgs)
            If Me.Operator Is Nothing And Request.Url.AbsolutePath <> "/Logon.aspx" Then
                Response.Redirect("/Logon.aspx")
            End If
            MyBase.OnPreLoad(e)
        End Sub

        Protected Overrides Sub OnError(ByVal e As EventArgs)
            ApplicationLog.WriteError(ApplicationLog.FormatException(Me.Server().GetLastError(), "Unhandled Exception:"))
            MyBase.OnError(e)
        End Sub
    End Class
End Namespace