Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCAR
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createAR(ByVal pDetail As Integer, ByVal pNotes As String, ByVal pNDate As DateTime, ByVal pClient As Integer, ByVal pResults As String, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            transactionContext.beginTransaction()
            Dim messageHelper1 As SystemFramework.MessageHelper = AR.createAr(transactionContext, pDetail, pNotes, pNDate, pClient, pResults, pCreateUser, pModifyUser)
            Try
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function

        Public Shared Function getAllChildAR() As SqlDataAdapter
            Return AR.getAllchildAR()
        End Function

        Public Shared Function getAllChildARByClient(ByVal pClient As Integer) As SqlDataAdapter
            Return AR.getAllChildARByClient(pClient)
        End Function

        Public Shared Function getAllParentAR() As SqlDataAdapter
            Return AR.getAllParentAR()
        End Function

        Public Shared Function getAllParentARByClient(ByVal pClient As Integer) As SqlDataAdapter
            Return AR.getAllParentARByClient(pClient)
        End Function

        Public Shared Function getResultCodes(ByVal pCode As String) As SqlDataReader
            Return AR.getResultCodes(pCode)
        End Function

        Public Shared Function modifyAR(ByVal pDetail As Integer, ByVal pNotes As String, ByVal pNDate As DateTime, ByVal pResults As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = AR.modifyAR(transactionContext, pDetail, pNotes, pNDate, pResults, pModifyUser)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function

        Public Shared Function modifyARMethod(ByVal pDetail As Integer, ByVal pDate As DateTime, ByVal pPaid As Decimal, ByVal pMethod As String, ByVal pLate As Decimal, ByVal pInt As Decimal, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = AR.modifyARMethod(transactionContext, pDetail, pDate, pPaid, pMethod, pLate, pInt, pModifyUser)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function
    End Class
End Namespace