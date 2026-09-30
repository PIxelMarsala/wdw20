Imports BusinessService
Imports Microsoft.VisualBasic.CompilerServices

Namespace wdw
    Public Class ControlBase
        Inherits UserControl
        Private Const UNHANDLED_EXCEPTION As String = "Unhandled Exception:"

        Private Const KEY_CACHEOPERATOR As String = "Cache:Operator:"

        Private basePathPrefix As String

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

        'Public Property PathPrefix As String
        '    Get
        '        If (Me.basePathPrefix Is Nothing) Then
        '            Me.basePathPrefix = PageBase.UrlBase
        '        End If
        '        Return Me.basePathPrefix
        '    End Get
        '    Set(ByVal value As String)
        '        Me.basePathPrefix = value
        '    End Set
        'End Property

        'Public Sub New()
        '    MyBase.New()
        'End Sub
    End Class
End Namespace