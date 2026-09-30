Imports System
Imports System.Runtime.CompilerServices

Namespace SystemFramework
    Public Class MessageHelper
        Private m_status As Boolean

        Private m_messageId As String

        Private m_messageText As String

        Private m_messageObject As Object

        Public Property messageId As String
            Get
                Return Me.m_messageId
            End Get
            Set(ByVal value As String)
                Me.m_messageId = value
            End Set
        End Property

        Public Property messageObject As Object
            Get
                Return RuntimeHelpers.GetObjectValue(Me.m_messageObject)
            End Get
            Set(ByVal value As Object)
                Me.m_messageObject = RuntimeHelpers.GetObjectValue(value)
            End Set
        End Property

        Public Property messageText As String
            Get
                Return Me.m_messageText
            End Get
            Set(ByVal value As String)
                Me.m_messageText = value
            End Set
        End Property

        Public Property status As Boolean
            Get
                Return Me.m_status
            End Get
            Set(ByVal value As Boolean)
                Me.m_status = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
        End Sub
    End Class
End Namespace