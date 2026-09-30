Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class CloseOut
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createCloseOutDetail(ByRef tran As TransactionContext, ByVal pHeader As Integer, ByVal pAbove As Boolean, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pBillAmt As Decimal, ByVal pPayBasis As Decimal, ByVal pPayCode As String, ByVal pPayPer As Integer, ByVal pPayAmt As Decimal, ByVal pTip As Decimal, ByVal pARCode As String, ByVal pPayRecd As Decimal, ByVal pTax As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim closeOutDT As DataTranslation.CloseOutDT = New DataTranslation.CloseOutDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            messageHelper = CloseOut.validateAR(pARCode, pActive, Convert.ToInt32(pPayRecd), pPayCode, pAbove)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = CloseOut.validateLBSB(pARCode, pActive, Convert.ToInt32(pPayRecd), pPayCode, pAbove)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = DataTranslation.CloseOutDT.createCloseOutDetail(tran, pHeader, pDetail, pJobNbr, pBillAmt, pPayBasis, pPayCode, pPayPer, pPayAmt, pTip, pARCode, pPayRecd, pTax, pActive, pCreateUser, pModifyUser)
            If (num <= 0) Then
                messageHelper.messageId = StringType.FromInteger(4)
                messageHelper.messageText = "Creation of CloseOut Detail Failed"
                messageHelper.status = False
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Shared Function createCloseOutDetailCredit(ByRef tran As TransactionContext, ByVal pHeader As Integer, ByVal pAbove As Boolean, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim closeOutDT As DataTranslation.CloseOutDT = New DataTranslation.CloseOutDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper = CloseOut.validatePay(pPayCode, pAbove)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = DataTranslation.CloseOutDT.createCloseOutDetailCredit(tran, pHeader, pDetail, pJobNbr, pPayCode, pPayAmt, pActive, pCreateUser, pModifyUser)
            If (num <= 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Creation of CloseOut Detail Credit Failed."
                messageHelper.status = False
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Shared Function createCloseOutDetailSpec(ByRef tran As TransactionContext, ByVal pHeader As Integer, ByVal pAbove As Boolean, ByVal pDetail As Integer, ByVal pJobNbr As Integer, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim closeOutDT As DataTranslation.CloseOutDT = New DataTranslation.CloseOutDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper = CloseOut.validatePay(pPayCode, pAbove)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = DataTranslation.CloseOutDT.createCloseOutDetailSpec(tran, pHeader, pDetail, pJobNbr, pPayCode, pPayAmt, pActive, pCreateUser, pModifyUser)
            If (num <= 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Job Insert Failed"
                messageHelper.status = False
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Shared Function createCloseOutHeader(ByRef tran As TransactionContext, ByVal pHeader As Integer, ByVal pSub As String, ByVal pTotal As Decimal, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim estimateDT As DataTranslation.EstimateDT = New DataTranslation.EstimateDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Return CloseOutDT.createCloseOutHeader(tran, pHeader, pSub, pTotal, pCreateUser, pModifyUser)
        End Function

        Public Shared Function getAllChildCloseOutBySub(ByVal psub As String) As SqlDataAdapter
            Return CloseOutDT.GetAllChildCloseOutBySub(psub)
        End Function

        Public Shared Function getAllParentCloseOutBySub(ByVal psub As String) As SqlDataAdapter
            Return CloseOutDT.GetAllParentCloseOutBySub(psub)
        End Function

        Public Shared Function getARCodes(ByVal pCode As String) As SqlDataReader
            Return CloseOutDT.GetARCodes(pCode)
        End Function

        Public Shared Function getExistingChildCOBySub(ByVal pDate As Integer) As SqlDataAdapter
            Return CloseOutDT.getExistingChildCOBySub(pDate)
        End Function

        Public Shared Function getExistingParentCOBySub(ByVal pDate As Integer) As SqlDataAdapter
            Return CloseOutDT.getExistingParentCOBySub(pDate)
        End Function

        Public Shared Function getLastCloseOuts(ByVal pSub As String) As SqlDataReader
            Return CloseOutDT.getLastCloseOuts(pSub)
        End Function

        Public Shared Function getPayCodes(ByVal pCode As String) As SqlDataReader
            Return CloseOutDT.GetPayCodes(pCode)
        End Function

        Public Shared Function modifyCloseOutDetail(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pAbove As Boolean, ByVal pJobNbr As Integer, ByVal pBillAmt As Decimal, ByVal pPayBasis As Decimal, ByVal pPayCode As String, ByVal pPayPer As Integer, ByVal pPayAmt As Decimal, ByVal pTip As Decimal, ByVal pARCode As String, ByVal pPayRecd As Decimal, ByVal pTax As Decimal, ByVal pActive As Integer, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim closeOutDT As DataTranslation.CloseOutDT = New DataTranslation.CloseOutDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper = CloseOut.validateAR(pARCode, pActive, Convert.ToInt32(pPayRecd), pPayCode, pAbove)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = CloseOut.validateLBSB(pARCode, pActive, Convert.ToInt32(pPayRecd), pPayCode, pAbove)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (DataTranslation.CloseOutDT.modifyCloseOutDetail(tran, pDetail, pJobNbr, pBillAmt, pPayBasis, pPayCode, pPayPer, pPayAmt, pTip, pARCode, pPayRecd, pTax, pActive, pModifyUser) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Modify CloseOutDetail update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function modifyCloseOutDetailCredit(ByRef tran As TransactionContext, ByVal pAbove As Boolean, ByVal pDetail As Integer, ByVal pPayCode As String, ByVal pPayAmt As Decimal, ByVal pActive As Integer, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim closeOutDT As DataTranslation.CloseOutDT = New DataTranslation.CloseOutDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper = CloseOut.validatePay(pPayCode, pAbove)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (DataTranslation.CloseOutDT.modifyCloseOutDetailCredit(tran, pDetail, pPayCode, pPayAmt, pActive, pModifyUser) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Service Offering Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Private Shared Function validateAR(ByVal pARCode As String, ByVal pActive As Integer, ByVal pARAmt As Integer, ByVal pPayCode As String, ByVal pAbove As Boolean) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Strings.Len(pARCode) > 0) Then
                If (Not (StringType.StrCmp(pARCode, "CK", False) = 0 Or StringType.StrCmp(pARCode, "CA", False) = 0)) Then
                    messageHelper.status = True
                    Return messageHelper
                End If
                If (Not (Strings.Len(StringType.FromInteger(pARAmt)) = 0 Or pARAmt = 0)) Then
                    messageHelper.status = True
                    Return messageHelper
                End If
                messageHelper.messageId = StringType.FromInteger(6)
                messageHelper.messageText = "For AR Code's 'CK' and 'CA' you must have an associated Payment Amount."
                Return messageHelper
            End If
            If (pAbove) Then
                If (Not (Strings.Len(pARCode) = 0 And pActive = 1)) Then
                    messageHelper.status = True
                    Return messageHelper
                End If
                messageHelper.messageId = StringType.FromInteger(8)
                messageHelper.messageText = "For any row above other charges, you must have a AR Code."
                Return messageHelper
            End If
            If (Not (Strings.Len(pPayCode) = 0 And pActive = 1)) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(9)
            messageHelper.messageText = "For any row below other charges, you must have a Pay Code."
            Return messageHelper
        End Function

        Private Shared Function validateLBSB(ByVal pARCode As String, ByVal pActive As Integer, ByVal pARAmt As Integer, ByVal pPayCode As String, ByVal pAbove As Boolean) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Strings.Len(pARCode) > 0) Then
                If (Not (StringType.StrCmp(pARCode, "LB", False) = 0 Or StringType.StrCmp(pARCode, "SB", False) = 0)) Then
                    messageHelper.status = True
                    Return messageHelper
                End If
                If (pARAmt <= 0) Then
                    messageHelper.status = True
                    Return messageHelper
                End If
                messageHelper.messageId = StringType.FromInteger(7)
                messageHelper.messageText = "For AR Code's 'LB' and 'SB' you should have no Payment Amount."
                Return messageHelper
            End If
            If (pAbove) Then
                If (Not (Strings.Len(pARCode) = 0 And pActive = 1)) Then
                    messageHelper.status = True
                    Return messageHelper
                End If
                messageHelper.messageId = StringType.FromInteger(11)
                messageHelper.messageText = "For any row above other charges, you must have a AR Code."
                Return messageHelper
            End If
            If (Not (Strings.Len(pPayCode) = 0 And pActive = 1)) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(12)
            messageHelper.messageText = "For any row below other charges, you must have a Pay Code."
            Return messageHelper
        End Function

        Private Shared Function validatePay(ByVal pPayCode As String, ByVal pAbove As Boolean) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Strings.Len(pPayCode) <> 0) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(8)
            messageHelper.messageText = "For any row below other charges or any child row, you must have a Pay Code."
            messageHelper.status = False
            Return messageHelper
        End Function
    End Class
End Namespace