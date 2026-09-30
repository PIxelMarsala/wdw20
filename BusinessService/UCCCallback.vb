Imports DataAccess
'Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCCallback
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createCallBack(ByVal pDetail As Integer, ByVal pNotes As String, ByVal pResult As String, ByVal pNDate As DateTime, ByVal pSite As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            transactionContext.beginTransaction()
            Dim num As Integer = Callback.createCallBack(transactionContext, pDetail, pNotes, pResult, pNDate, pSite, pCreateUser, pModifyUser)
            transactionContext.commit()
            Return num
        End Function

        Public Shared Function createChildRecords(ByVal pCB As String, ByVal pFromDate As DateTime, ByVal pToDate As DateTime, ByVal pFromZip As String, ByVal pToZip As String, ByVal pLastName As String, ByVal pAddress1 As String, ByVal pCreateUser As String, ByVal pModifyUser As String, ByVal pFromStart As DateTime, ByVal pToStart As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Callback.createChildRecords(transactionContext, pCB, pFromDate, pToDate, pFromZip, pToZip, pLastName, pAddress1, pCreateUser, pModifyUser, pFromStart, pToStart)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                'ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function

        Public Shared Function getAllChildCallback(ByVal pCB As String) As SqlDataAdapter
            Return Callback.getAllchildCallback(pCB)
        End Function

        Public Shared Function getAllChildCallbackbyAddress(ByVal pAddress As String) As SqlDataAdapter
            Return Callback.getAllChildCallbackByAddress(pAddress)
        End Function

        Public Shared Function getAllChildCallbackbyClient(ByVal pClient As Integer) As SqlDataAdapter
            Return Callback.getAllChildCallbackByClient(pClient)
        End Function

        Public Shared Function getAllChildCallbackbyDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pTo As DateTime, ByVal pFromzip As Integer, ByVal pToZip As Integer) As SqlDataAdapter
            Return Callback.getAllChildCallbackByDate(pCB, pFrom, pTo, pFromzip, pToZip)
        End Function

        Public Shared Function getAllChildCallbackbyLName(ByVal pName As String) As SqlDataAdapter
            Return Callback.getAllChildCallbackByLName(pName)
        End Function

        Public Shared Function getAllChildCallbackbyStartDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pTo As DateTime) As SqlDataAdapter
            Return Callback.getAllChildCallbackByStartDate(pCB, pFrom, pTo)
        End Function

        Public Shared Function getAllParentCallback(ByVal pCB As String) As SqlDataAdapter
            Return Callback.getAllParentCallback(pCB)
        End Function

        Public Shared Function getAllParentCallbackbyAddress(ByVal pAddress As String) As SqlDataAdapter
            Return Callback.getAllParentCallbackByAddress(pAddress)
        End Function

        Public Shared Function getAllParentCallbackbyClient(ByVal pClient As Integer) As SqlDataAdapter
            Return Callback.getAllParentCallbackByClient(pClient)
        End Function

        Public Shared Function getAllParentCallbackbyDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pTo As DateTime, ByVal pFromzip As Integer, ByVal pToZip As Integer) As SqlDataAdapter
            Return Callback.getAllParentCallbackByDate(pCB, pFrom, pTo, pFromzip, pToZip)
        End Function

        Public Shared Function getAllParentCallbackbyLName(ByVal pName As String) As SqlDataAdapter
            Return Callback.getAllParentCallbackByLName(pName)
        End Function

        Public Shared Function getAllParentCallbackbyStartDate(ByVal pCB As String, ByVal pFrom As DateTime, ByVal pTo As DateTime) As SqlDataAdapter
            Return Callback.getAllParentCallbackByStartDate(pCB, pFrom, pTo)
        End Function

        Public Shared Function modifyCallBack(ByVal pDetail As Integer, ByVal pNotes As String, ByVal pResult As String, ByVal pNDate As DateTime, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Callback.modifyCallBack(transactionContext, pDetail, pNotes, pResult, pNDate, pModifyUser)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                'ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function

        Public Shared Function modifyCBMethod(ByVal pDetail As Integer, ByVal pMethod As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Callback.modifyCBMethod(transactionContext, pDetail, pMethod, pModifyUser)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                'ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function
    End Class
End Namespace