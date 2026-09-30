Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class Params
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function getActiveSubs() As SqlDataReader
            Return ParamsDT.getActiveSubs()
        End Function

        Public Shared Function getAllCities() As SqlDataReader
            Return ParamsDT.getAllCities()
        End Function

        Public Shared Function getAllSubs() As SqlDataReader
            Return ParamsDT.getAllSubs()
        End Function

        Public Shared Function getAllUsers() As SqlDataReader
            Return ParamsDT.getAllUsers()
        End Function

        Public Shared Function getAllZips() As SqlDataReader
            Return ParamsDT.getAllZips()
        End Function

        Public Shared Function getMinMaxMonthDay() As SqlDataReader
            Return ParamsDT.getMinMaxMonthDay()
        End Function

        Public Shared Function updateDepositStatus(ByRef tran As TransactionContext) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim paramsDT As DataTranslation.ParamsDT = New DataTranslation.ParamsDT()
            If (DataTranslation.ParamsDT.updateDepositStatus(tran) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Deposit Status Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function updateJobStatus(ByRef tran As TransactionContext, ByVal pFrom As DateTime, ByVal pTo As DateTime, ByVal pSub As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim paramsDT As DataTranslation.ParamsDT = New DataTranslation.ParamsDT()
            If (DataTranslation.ParamsDT.updateJobStatus(tran, pFrom, pTo, pSub) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Job Status Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function
    End Class
End Namespace