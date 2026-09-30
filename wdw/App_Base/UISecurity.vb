Imports BusinessService
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports SystemFramework

Namespace wdw
    Public Class UISecurity
        Inherits PageBase
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function validateSecurity(ByVal functionName As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Nothing
            Dim uCCSecurity As BusinessService.UCCSecurity = New BusinessService.UCCSecurity()
            Dim messageHelper1 As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper1 = uCCSecurity.authorizeAppFunction(Me.[Operator].operatorId, functionName)
            If (Information.IsNothing(RuntimeHelpers.GetObjectValue(messageHelper1.messageObject))) Then
                Me.Server().Transfer("~/SecurityViolation.aspx")
            Else
                If (BooleanType.FromObject(ObjectType.BitOrObj(ObjectType.BitOrObj(ObjectType.BitOrObj(LateBinding.LateGet(messageHelper1.messageObject, Nothing, "canCreate", New Object(-1) {}, Nothing, Nothing), LateBinding.LateGet(messageHelper1.messageObject, Nothing, "canUpdate", New Object(-1) {}, Nothing, Nothing)), LateBinding.LateGet(messageHelper1.messageObject, Nothing, "canDelete", New Object(-1) {}, Nothing, Nothing)), LateBinding.LateGet(messageHelper1.messageObject, Nothing, "canView", New Object(-1) {}, Nothing, Nothing)))) Then
                    messageHelper1.status = True
                    Return messageHelper1
                End If
                Me.Server().Transfer("~/SecurityViolation.aspx")
            End If
            Return messageHelper
        End Function
    End Class
End Namespace