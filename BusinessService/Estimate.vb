Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class Estimate
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function clone(ByVal tran As TransactionContext, ByVal pHeaderID As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim num As Integer = 0
            Dim estimateDT As DataTranslation.EstimateDT = New DataTranslation.EstimateDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim flag As Boolean = False
            messageHelper.status = True
            Dim bidById As SqlDataReader = DataTranslation.EstimateDT.getBidById(pHeaderID)
            While bidById.Read() And messageHelper.status
                If (flag) Then
                    If (Estimate.cloneBidDetail(tran, estimateDT, num, bidById, pCreateUser, pModifyUser) <> 0) Then
                        Continue While
                    End If
                    messageHelper.status = False
                    messageHelper.messageText = "Bid Header Detail Clone Failed"
                Else
                    flag = True
                    num = estimateDT.isrtBidHeader(tran, Decimal.Zero, DecimalType.FromObject(bidById.Item("Override_Amt")), IntegerType.FromObject(bidById.Item("Active")), pCreateUser, pModifyUser)
                    If (num <= 0) Then
                        messageHelper.status = False
                        messageHelper.messageText = "Bid Header Clone Failed"
                    Else
                        If (Estimate.cloneBidDetail(tran, estimateDT, num, bidById, pCreateUser, pModifyUser) <> 0) Then
                            Continue While
                        End If
                        messageHelper.status = False
                        messageHelper.messageText = "Bid Header Detail Clone Failed"
                    End If
                End If
            End While
            bidById.Close()
            If (flag) Then
                messageHelper.status = True
                messageHelper.messageObject = num
            Else
                messageHelper.status = False
                messageHelper.messageText = "Estimate Clone Failed"
            End If
            Return messageHelper
        End Function

        Private Shared Function cloneBidDetail(ByVal tran As TransactionContext, ByVal estimateDT As DataTranslation.EstimateDT, ByVal newBidHeaderId As Integer, ByVal rdr As SqlDataReader, ByVal Create_User As String, ByVal Modified_User As String) As Integer
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim num As Integer = estimateDT.isrtBidDetail(tran, newBidHeaderId, IntegerType.FromObject(rdr.Item("ServOffElem_ID")), DecimalType.FromObject(rdr.Item("Qty")), DecimalType.FromObject(rdr.Item("Detail_Total")), IntegerType.FromObject(rdr.Item("Active")), Create_User, Modified_User)
            Return num
        End Function

        Public Shared Function createEstimate(ByRef tran As TransactionContext, ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pColumnName As String, ByVal pKey As Integer, ByVal pPrice As Decimal, ByVal pQty As Decimal, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim estimateDT As DataTranslation.EstimateDT = New DataTranslation.EstimateDT()
            Dim num As Integer = DataTranslation.EstimateDT.createEstimate(tran, pHeaderID, pOTotal, pColumnName, pKey, pPrice, pQty, pCreateUser, pModifyUser)
            Return num
        End Function

        Public Shared Function getAllChildEstimate() As SqlDataAdapter
            Return EstimateDT.getAllChildEstimate()
        End Function

        Public Shared Function getAllChildEstimateByBid(ByVal pHeaderId As Integer) As SqlDataAdapter
            Return EstimateDT.getAllChildEstimateByBid(pHeaderId)
        End Function

        Public Shared Function getAllParentEstimate() As SqlDataAdapter
            Return EstimateDT.getAllParentEstimate()
        End Function

        Public Shared Function getAllParentEstimateByBid(ByVal pHeaderId As Integer) As SqlDataAdapter
            Return EstimateDT.getAllParentEstimateByBid(pHeaderId)
        End Function

        Public Shared Function getBidHeaderById(ByVal tran As TransactionContext, ByVal pHeaderId As Integer) As SqlDataReader
            Return EstimateDT.getBidHeaderById(tran, pHeaderId)
        End Function

        Public Shared Function getHeaderAmts(ByVal pHeaderId As Integer) As SqlDataReader
            Return EstimateDT.getHeaderAmts(pHeaderId)
        End Function

        Public Shared Function getJobDescription(ByVal pHeader As Integer) As SqlDataReader
            Return EstimateDT.getJobDescription(pHeader)
        End Function

        Public Shared Function removeEstimate(ByRef tran As TransactionContext, ByVal pHeaderID As Integer) As SystemFramework.MessageHelper
            Dim estimateDT As DataTranslation.EstimateDT = New DataTranslation.EstimateDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DataTranslation.EstimateDT.removeEstimate(tran, pHeaderID) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Estimate Deletion Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function updateEstimate(ByRef tran As TransactionContext, ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pColumnName As String, ByVal pKey As Integer, ByVal pPrice As Decimal, ByVal pQty As Decimal, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim estimateDT As DataTranslation.EstimateDT = New DataTranslation.EstimateDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DataTranslation.EstimateDT.updateEstimate(tran, pHeaderID, pOTotal, pColumnName, pKey, pPrice, pQty, pModifyUser) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Estimate Insert Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function updateOverride(ByRef tran As TransactionContext, ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim estimateDT As DataTranslation.EstimateDT = New DataTranslation.EstimateDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DataTranslation.EstimateDT.updateOverride(tran, pHeaderID, pOTotal, pModifyUser) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Estimate Insert Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Private Function validateEstimateNotExists(ByVal total As Decimal) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Decimal.Compare(total, Decimal.Zero) = 0) Then
                messageHelper.status = True
            Else
                messageHelper.messageText = "Bid Detail total should not be 0."
                messageHelper.messageId = StringType.FromInteger(1)
            End If
            Return messageHelper
        End Function

        Private Function validateEstimateOverrideTotal(ByVal total As Decimal) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Decimal.Compare(total, Decimal.Zero) = 0) Then
                messageHelper.status = True
            Else
                messageHelper.messageId = StringType.FromInteger(4)
            End If
            Return messageHelper
        End Function

        Private Function validateEstimatePriceandQty(ByVal price As Decimal, ByVal qty As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Not (Decimal.Compare(price, Decimal.Zero) = 0 Or qty = 0)) Then
                messageHelper.status = True
            Else
                messageHelper.messageText = "You are attempting to create an estimate with no price or 0 qty in the detail, please correct."
                messageHelper.messageId = StringType.FromInteger(5)
            End If
            Return messageHelper
        End Function
    End Class
End Namespace