Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class Task
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createChildServOff(ByRef tran As TransactionContext, ByVal pServName As String, ByVal pPServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim taskDT As DataTranslation.TaskDT = New DataTranslation.TaskDT()
            messageHelper.status = False
            messageHelper = Task.validateTask(pServName, pPosition, StringType.FromInteger(pGrouping))
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = DataTranslation.TaskDT.createChildServOff(tran, pServName, pPServName, pActive, pTax, pPricing, pGrouping, pPosition)
            If (Information.IsDBNull(num)) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Parent Service Offering Insert Failed"
                messageHelper.status = False
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Shared Function createParentServOff(ByRef tran As TransactionContext, ByVal pServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim taskDT As DataTranslation.TaskDT = New DataTranslation.TaskDT()
            messageHelper.status = False
            messageHelper = Task.validateTask(pServName, pPosition, StringType.FromInteger(pGrouping))
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = DataTranslation.TaskDT.createParentServOff(tran, pServName, pActive, pTax, pPricing, pGrouping, pPosition)
            If (num <= 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Parent Service Offering Insert Failed"
                messageHelper.status = False
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Shared Function getAllChildTasks() As SqlDataAdapter
            Return TaskDT.getAllChildTasks()
        End Function

        Public Shared Function getAllParentTasks() As SqlDataAdapter
            Return TaskDT.getAllParentTasks()
        End Function

        Public Shared Function getMaxServOffID() As SqlDataReader
            Return TaskDT.getMaxServOffID()
        End Function

        Public Shared Function removeChildServOff(ByRef tran As TransactionContext, ByVal pServOffID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim taskDT As DataTranslation.TaskDT = New DataTranslation.TaskDT()
            If (DataTranslation.TaskDT.removeChildServOff(tran, pServOffID) <= 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Child Service Offering Delete Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function removeParentandChildrentServOff(ByRef tran As TransactionContext, ByVal pServOffID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim taskDT As DataTranslation.TaskDT = New DataTranslation.TaskDT()
            If (DataTranslation.TaskDT.removeParentandChildrentServOff(tran, pServOffID) <= 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Parent and Child Service Offering Delete Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function updateServOff(ByRef tran As TransactionContext, ByVal pServOffID As Integer, ByVal pServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim taskDT As DataTranslation.TaskDT = New DataTranslation.TaskDT()
            messageHelper = Task.validateTask(pServName, pPosition, StringType.FromInteger(pGrouping))
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (DataTranslation.TaskDT.updateServOff(tran, pServOffID, pServName, pActive, pTax, pPricing, pGrouping, pPosition) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Service Offering Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Private Shared Function validateGrouping(ByVal pGrouping As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            If (pGrouping <> 0) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(7)
            messageHelper.messageText = "Service Offerings must have a position."
            Return messageHelper
        End Function

        Private Shared Function validatePosition(ByVal pPosition As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            If (pPosition <> 0) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(6)
            messageHelper.messageText = "Service Offerings must have a position."
            Return messageHelper
        End Function

        Private Shared Function validateServName(ByVal pServName As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            If (StringType.StrCmp(pServName, Nothing, False) <> 0) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(4)
            messageHelper.messageText = "Service Offerings must have a name."
            Return messageHelper
        End Function

        Public Shared Function validateTask(ByVal pServName As String, ByVal pPosition As Integer, ByVal pGrouping As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            messageHelper = Task.validateServName(pServName)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Task.validatePosition(pPosition)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Task.validateGrouping(IntegerType.FromString(pGrouping))
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Return messageHelper
        End Function
    End Class
End Namespace