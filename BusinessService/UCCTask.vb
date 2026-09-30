Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCTask
        Private trans As TransactionContext

        Public Sub New()
            MyBase.New()
            Me.trans = New TransactionContext()
        End Sub

        Public Shared Function createChildServOff(ByVal pServName As String, ByVal pPServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Task.createChildServOff(transactionContext, pServName, pPServName, pActive, pTax, pPricing, pGrouping, pPosition)
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

        Public Shared Function createParentServOff(ByVal pServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Task.createParentServOff(transactionContext, pServName, pActive, pTax, pPricing, pGrouping, pPosition)
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

        Public Shared Function getAllChildTasks() As SqlDataAdapter
            Return Task.getAllChildTasks()
        End Function

        Public Shared Function getAllParentTasks() As SqlDataAdapter
            Return Task.getAllParentTasks()
        End Function

        Public Shared Function getMaxServOffID() As SqlDataReader
            Return Task.getMaxServOffID()
        End Function

        Public Shared Function removeChildServOff(ByVal pServOffID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Task.removeChildServOff(transactionContext, pServOffID)
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

        Public Shared Function removeParentandChildrentServOff(ByVal pServOffID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Task.removeParentandChildrentServOff(transactionContext, pServOffID)
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

        Public Shared Function updateServOff(ByVal pServOffID As Integer, ByVal pServName As String, ByVal pActive As Integer, ByVal pTax As Integer, ByVal pPricing As Integer, ByVal pGrouping As Integer, ByVal pPosition As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Task.updateServOff(transactionContext, pServOffID, pServName, pActive, pTax, pPricing, pGrouping, pPosition)
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