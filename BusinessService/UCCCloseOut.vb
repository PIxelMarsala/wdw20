Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCCloseOut
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createCloseOutDetail(ByVal pHeader As Integer, ByVal pAbove As Boolean, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pBillAmt As Decimal, ByVal pPayBasis As Decimal, ByVal pPayCode As String, ByVal pPayPer As Integer, ByVal pPayAmt As Decimal, ByVal pTip As Decimal, ByVal pARCode As String, ByVal pPayRecd As Decimal, ByVal pTax As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = CloseOut.createCloseOutDetail(transactionContext, pHeader, pAbove, pDetail, pJobNbr, pBillAmt, pPayBasis, pPayCode, pPayPer, pPayAmt, pTip, pARCode, pPayRecd, pTax, pActive, pCreateUser, pModifyUser)
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

        Public Shared Function createCloseOutDetailCredit(ByVal pHeader As Integer, ByVal pAbove As Boolean, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            transactionContext.beginTransaction()
            Dim messageHelper1 As SystemFramework.MessageHelper = CloseOut.createCloseOutDetailCredit(transactionContext, pHeader, pAbove, pDetail, pJobNbr, pPayCode, pPayAmt, pActive, pCreateUser, pModifyUser)
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

        Public Shared Function createCloseOutDetailSpec(ByVal pHeader As Integer, ByVal pAbove As Boolean, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            transactionContext.beginTransaction()
            Dim messageHelper1 As SystemFramework.MessageHelper = CloseOut.createCloseOutDetailSpec(transactionContext, pHeader, pAbove, pDetail, pJobNbr, pPayCode, pPayAmt, pActive, pCreateUser, pModifyUser)
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

        Public Shared Function createCloseOutHeader(ByVal pHeader As Integer, ByVal pSub As String, ByVal pTotal As Decimal, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            transactionContext.beginTransaction()
            Dim num As Integer = CloseOut.createCloseOutHeader(transactionContext, pHeader, pSub, pTotal, pCreateUser, pModifyUser)
            transactionContext.commit()
            Return num
        End Function

        Public Shared Function getAllChildCloseOutBySub(ByVal psub As String) As SqlDataAdapter
            Return CloseOut.getAllChildCloseOutBySub(psub)
        End Function

        Public Shared Function getAllParentCloseOutBySub(ByVal psub As String) As SqlDataAdapter
            Return CloseOut.getAllParentCloseOutBySub(psub)
        End Function

        Public Shared Function getARCodes(ByVal pCode As String) As SqlDataReader
            Return CloseOut.getARCodes(pCode)
        End Function

        Public Shared Function getExistingChildCOBySub(ByVal pDate As Integer) As SqlDataAdapter
            Return CloseOut.getExistingChildCOBySub(pDate)
        End Function

        Public Shared Function getExistingParentCOBySub(ByVal pDate As Integer) As SqlDataAdapter
            Return CloseOut.getExistingParentCOBySub(pDate)
        End Function

        Public Shared Function getLastCloseOuts(ByVal psub As String) As SqlDataReader
            Return CloseOut.getLastCloseOuts(psub)
        End Function

        Public Shared Function getPayCodes(ByVal pCode As String) As SqlDataReader
            Return CloseOut.getPayCodes(pCode)
        End Function

        Public Shared Function modifyCloseOutDetail(ByVal pDetail As Integer, ByVal pAbove As Boolean, ByVal pJobNbr As Integer, ByVal pBillAmt As Decimal, ByVal pPayBasis As Decimal, ByVal pPayCode As String, ByVal pPayPer As Integer, ByVal pPayAmt As Decimal, ByVal pTip As Decimal, ByVal pARCode As String, ByVal pPayRecd As Decimal, ByVal pTax As Decimal, ByVal pActive As Integer, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = CloseOut.modifyCloseOutDetail(transactionContext, pDetail, pAbove, pJobNbr, pBillAmt, pPayBasis, pPayCode, pPayPer, pPayAmt, pTip, pARCode, pPayRecd, pTax, pActive, pModifyUser)
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

        Public Shared Function modifyCloseOutDetailCredit(ByVal pDetail As Integer, ByVal pAbove As Boolean, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = CloseOut.modifyCloseOutDetailCredit(transactionContext, pAbove, pDetail, pPayCode, pPayAmt, pActive, pModifyUser)
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