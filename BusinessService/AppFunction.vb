Imports DataTranslation
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class AppFunction
        Private m_appFunctionId As Integer

        Private m_functionTarget As String

        Private m_functionName As String

        Public Property appFunctionId As Integer
            Get
                Return Me.m_appFunctionId
            End Get
            Set(ByVal value As Integer)
                Me.m_appFunctionId = value
            End Set
        End Property

        Public Property function_Name As String
            Get
                Return Me.m_functionName
            End Get
            Set(ByVal value As String)
                Me.m_functionName = value
            End Set
        End Property

        Public Property functionTarget As String
            Get
                Return Me.m_functionTarget
            End Get
            Set(ByVal value As String)
                Me.m_functionTarget = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getAppFunctionById(ByVal appFunctionID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As New SystemFramework.MessageHelper()
            Dim appFunctionById As SqlDataReader = (New AppFunctionDT()).getAppFunctionById(appFunctionID)
            messageHelper.status = False
            messageHelper.messageObject = Nothing
            If (Not appFunctionById.Read()) Then
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.messageText = "No function found"
            Else
                Me.unpack(appFunctionById)
                messageHelper.messageObject = Me
                messageHelper.status = True
            End If
            appFunctionById.Close()
            Return messageHelper
        End Function

        Private Sub unpack(ByVal rdr As SqlDataReader)
            Me.functionTarget = StringType.FromObject(rdr.Item("FunctionTarget"))
            Me.appFunctionId = IntegerType.FromObject(rdr.Item("App_Function_ID"))
            Me.function_Name = StringType.FromObject(rdr.Item("Function_Name"))
        End Sub
    End Class
End Namespace