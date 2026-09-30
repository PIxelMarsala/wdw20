Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCEstimate
        Private trans As TransactionContext

        Public Sub New()
            MyBase.New()
            Me.trans = New TransactionContext()
        End Sub

        Public Shared Function cloneEstimate(ByVal tran As TransactionContext, ByVal pHeaderID As Integer, ByVal pCreateUser As String, ByVal pModifyUser As String) As MessageHelper
            Return Estimate.clone(tran, pHeaderID, pCreateUser, pModifyUser)
        End Function

        Public Shared Function createEstimate(ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pColumnName As String, ByVal pKey As Integer, ByVal pPrice As Decimal, ByVal pQty As Decimal, ByVal pCreateUser As String, ByVal pModifyUser As String) As Integer
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            transactionContext.beginTransaction()
            Dim num As Integer = Estimate.createEstimate(transactionContext, pHeaderID, pOTotal, pColumnName, pKey, pPrice, pQty, pCreateUser, pModifyUser)
            transactionContext.commit()
            Return num
        End Function

        Public Shared Function getAllChildEstimate() As SqlDataAdapter
            Return Estimate.getAllChildEstimate()
        End Function

        Public Shared Function getAllChildEstimateByBid(ByVal pHeaderId As Integer) As SqlDataAdapter
            Return Estimate.getAllChildEstimateByBid(pHeaderId)
        End Function

        Public Shared Function getAllParentEstimate() As SqlDataAdapter
            Return Estimate.getAllParentEstimate()
        End Function

        Public Shared Function getAllParentEstimateByBid(ByVal pHeaderId As Integer) As SqlDataAdapter
            Return Estimate.getAllParentEstimateByBid(pHeaderId)
        End Function

        Public Shared Function getBidHeaderById(ByVal tran As TransactionContext, ByVal pHeaderId As Integer) As SqlDataReader
            Return Estimate.getBidHeaderById(tran, pHeaderId)
        End Function

        Public Shared Function getHeaderAmts(ByVal pHeaderId As Integer) As SqlDataReader
            Return Estimate.getHeaderAmts(pHeaderId)
        End Function

        Public Shared Function getJobDescription(ByVal pHeader As Integer) As SqlDataReader
            Return Estimate.getJobDescription(pHeader)
        End Function

        Public Shared Function removeEstimate(ByVal pHeaderID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Estimate.removeEstimate(transactionContext, pHeaderID)
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

        Public Shared Function updateEstimate(ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pColumnName As String, ByVal pKey As Integer, ByVal pPrice As Decimal, ByVal pQty As Decimal, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Estimate.updateEstimate(transactionContext, pHeaderID, pOTotal, pColumnName, pKey, pPrice, pQty, pModifyUser)
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

        Public Shared Function updateOverride(ByVal pHeaderID As Integer, ByVal pOTotal As Decimal, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Estimate.updateOverride(transactionContext, pHeaderID, pOTotal, pModifyUser)
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