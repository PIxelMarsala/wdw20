Imports DataTranslation
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class AppFunctionRole
        Private m_roleId As Integer

        Private m_appFunctionId As Integer

        Private m_canView As Integer

        Private m_canUpdate As Integer

        Private m_canDelete As Integer

        Private m_canCreate As Integer

        Public Property appFunctionId As Integer
            Get
                Return Me.m_appFunctionId
            End Get
            Set(ByVal value As Integer)
                Me.m_appFunctionId = value
            End Set
        End Property

        Public Property canCreate As Boolean
            Get
                Return If(Me.m_canCreate <> 1, False, True)
            End Get
            Set(ByVal value As Boolean)
                If (Not value) Then
                    Me.m_canCreate = 0
                Else
                    Me.m_canCreate = 1
                End If
            End Set
        End Property

        Public Property canDelete As Boolean
            Get
                Return If(Me.m_canDelete <> 1, False, True)
            End Get
            Set(ByVal value As Boolean)
                If (Not value) Then
                    Me.m_canDelete = 0
                Else
                    Me.m_canDelete = 1
                End If
            End Set
        End Property

        Public Property canUpdate As Boolean
            Get
                Return If(Me.m_canUpdate <> 1, False, True)
            End Get
            Set(ByVal value As Boolean)
                If (Not value) Then
                    Me.m_canUpdate = 0
                Else
                    Me.m_canUpdate = 1
                End If
            End Set
        End Property

        Public Property canView As Boolean
            Get
                Return If(Me.m_canView <> 1, False, True)
            End Get
            Set(ByVal value As Boolean)
                If (Not value) Then
                    Me.m_canView = 0
                Else
                    Me.m_canView = 1
                End If
            End Set
        End Property

        Public Property roleId As Integer
            Get
                Return Me.m_roleId
            End Get
            Set(ByVal value As Integer)
                Me.m_roleId = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getAppFunctionRoleByOperatorId(ByVal operatorId As Integer, ByVal functionName As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim appFunctionRoleByOperatorId As SqlDataReader = (New AppFunctionRoleDT()).getAppFunctionRoleByOperatorId(operatorId, functionName)
            messageHelper.status = False
            messageHelper.messageObject = Nothing
            If (Not appFunctionRoleByOperatorId.Read()) Then
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.messageText = "No Role/Function for Operator"
            Else
                Me.unpack(appFunctionRoleByOperatorId)
                messageHelper.messageObject = Me
                messageHelper.status = True
            End If
            appFunctionRoleByOperatorId.Close()
            Return messageHelper
        End Function

        Private Sub unpack(ByVal rdr As SqlDataReader)
            Me.roleId = IntegerType.FromObject(rdr.Item("Role_ID"))
            Me.appFunctionId = IntegerType.FromObject(rdr.Item("App_Function_ID"))
            Me.canView = BooleanType.FromObject(rdr.Item("Can_View"))
            Me.canUpdate = BooleanType.FromObject(rdr.Item("Can_Update"))
            Me.canDelete = BooleanType.FromObject(rdr.Item("Can_Delete"))
            Me.canCreate = BooleanType.FromObject(rdr.Item("Can_Create"))
        End Sub
    End Class
End Namespace