Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class Callback
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createCallBack(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pNotes As String, ByVal pResult As String, ByVal pNDate As DateTime, ByVal pSite As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim callbackDT As DataTranslation.CallbackDT = New DataTranslation.CallbackDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim num As Integer = DataTranslation.CallbackDT.createCallback(tran, pDetail, pNotes, pResult, pNDate, pSite, pCreateUser, pModifyUser)
            Return num
        End Function

        Public Shared Function createChildRecords(ByRef tran As TransactionContext, ByVal pCB As String, ByVal pFromDate As DateTime, ByVal pToDate As DateTime, ByVal pFromZip As String, ByVal pToZip As String, ByVal pLastName As String, ByVal pAddress1 As String, ByVal pCreateUser As String, ByVal pModifyuser As String, ByVal pFromStart As DateTime, ByVal pToStart As DateTime) As SystemFramework.MessageHelper
            Dim callbackDT As DataTranslation.CallbackDT = New DataTranslation.CallbackDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DataTranslation.CallbackDT.createChildrecords(tran, pCB, pFromDate, pToDate, pFromZip, pToZip, pLastName, pAddress1, pCreateUser, pModifyuser, pFromStart, pToStart) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "CallBack Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function getAllchildCallback(ByVal pCB As String) As SqlDataAdapter
            Return CallbackDT.GetAllChildCallBack(pCB)
        End Function

        Public Shared Function getAllChildCallbackByAddress(ByVal pAddress As String) As SqlDataAdapter
            Return CallbackDT.GetAllChildCallBackByAddress(pAddress)
        End Function

        Public Shared Function getAllChildCallbackByClient(ByVal pClient As Integer) As SqlDataAdapter
            Return CallbackDT.GetAllChildCallBackByClient(pClient)
        End Function

        Public Shared Function getAllChildCallbackByDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pto As DateTime, ByVal pFromZip As Integer, ByVal pToZip As Integer) As SqlDataAdapter
            Return CallbackDT.GetAllChildCallBackByDate(pCB, pFrom, pto, pFromZip, pToZip)
        End Function

        Public Shared Function getAllChildCallbackByLName(ByVal pName As String) As SqlDataAdapter
            Return CallbackDT.GetAllChildCallBackByLName(pName)
        End Function

        Public Shared Function getAllChildCallbackByStartDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pto As DateTime) As SqlDataAdapter
            Return CallbackDT.GetAllChildCallBackByStartDate(pCB, pFrom, pto)
        End Function

        Public Shared Function getAllParentCallback(ByVal pCB As String) As SqlDataAdapter
            Return CallbackDT.GetAllParentCallBack(pCB)
        End Function

        Public Shared Function getAllParentCallbackByAddress(ByVal pAddress As String) As SqlDataAdapter
            Return CallbackDT.GetAllParentCallBackByAddress(pAddress)
        End Function

        Public Shared Function getAllParentCallbackByClient(ByVal pClient As Integer) As SqlDataAdapter
            Return CallbackDT.GetAllParentCallBackByClient(pClient)
        End Function

        Public Shared Function getAllParentCallbackByDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pto As DateTime, ByVal pFromZip As Integer, ByVal pToZip As Integer) As SqlDataAdapter
            Return CallbackDT.GetAllParentCallBackByDate(pCB, pFrom, pto, pFromZip, pToZip)
        End Function

        Public Shared Function getAllParentCallbackByLName(ByVal pName As String) As SqlDataAdapter
            Return CallbackDT.GetAllParentCallBackByLName(pName)
        End Function

        Public Shared Function getAllParentCallbackByStartDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pto As DateTime) As SqlDataAdapter
            Return CallbackDT.GetAllParentCallBackByStartDate(pCB, pFrom, pto)
        End Function

        Public Shared Function modifyCallBack(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pNotes As String, ByVal pResult As String, ByVal pNDate As DateTime, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim callbackDT As DataTranslation.CallbackDT = New DataTranslation.CallbackDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DataTranslation.CallbackDT.modifyCallBack(tran, pDetail, pNotes, pResult, pNDate, pModifyUser) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Callback Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function modifyCBMethod(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pMethod As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim callbackDT As DataTranslation.CallbackDT = New DataTranslation.CallbackDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DataTranslation.CallbackDT.modifyCBMethod(tran, pDetail, pMethod, pModifyUser) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "CallBack Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function
    End Class
End Namespace