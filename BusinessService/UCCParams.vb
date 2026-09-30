Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCParams
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getActiveSubs() As SqlDataReader
            Return Params.getActiveSubs()
        End Function

        Public Shared Function getAllCities() As SqlDataReader
            Return Params.getAllCities()
        End Function

        Public Shared Function getAllSubs() As SqlDataReader
            Return Params.getAllSubs()
        End Function

        Public Shared Function getAllUsers() As SqlDataReader
            Return Params.getAllUsers()
        End Function

        Public Shared Function getAllZips() As SqlDataReader
            Return Params.getAllZips()
        End Function

        Public Shared Function getMinMaxMonthDay() As SqlDataReader
            Return Params.getMinMaxMonthDay()
        End Function

        Public Shared Function updateDepositStatus() As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Params.updateDepositStatus(transactionContext)
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

        Public Shared Function updateJobStatus(ByVal pFrom As DateTime, ByVal pTo As DateTime, ByVal pSub As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Params.updateJobStatus(transactionContext, pFrom, pTo, pSub)
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