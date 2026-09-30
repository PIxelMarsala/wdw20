Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class AR
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function createAr(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pNotes As String, ByVal pNDate As DateTime, ByVal pClient As Integer, ByVal pResults As String, ByVal pCreateUser As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim aRDT As DataTranslation.ARDT = New DataTranslation.ARDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            messageHelper = AR.validateResultCode(pResults, pNotes)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = DataTranslation.ARDT.createAR(tran, pDetail, pNotes, pNDate, pClient, pResults, pCreateUser, pModifyUser)
            If (num <= 0) Then
                messageHelper.messageId = StringType.FromInteger(4)
                messageHelper.messageText = "Creation of AR Record Failed"
                messageHelper.status = False
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Shared Function getAllchildAR() As SqlDataAdapter
            Return ARDT.GetAllChildAR()
        End Function

        Public Shared Function getAllChildARByClient(ByVal pClient As Integer) As SqlDataAdapter
            Return ARDT.GetAllChildARByClient(pClient)
        End Function

        Public Shared Function getAllParentAR() As SqlDataAdapter
            Return ARDT.GetAllParentAR()
        End Function

        Public Shared Function getAllParentARByClient(ByVal pClient As Integer) As SqlDataAdapter
            Return ARDT.GetAllParentARByClient(pClient)
        End Function

        Public Shared Function getResultCodes(ByVal pCode As String) As SqlDataReader
            Return ARDT.GetResultCodes(pCode)
        End Function

        Public Shared Function modifyAR(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pNotes As String, ByVal pNDate As DateTime, ByVal pResults As String, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim aRDT As DataTranslation.ARDT = New DataTranslation.ARDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DataTranslation.ARDT.modifyAR(tran, pDetail, pNotes, pNDate, pResults, pModifyUser) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "AR Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Shared Function modifyARMethod(ByRef tran As TransactionContext, ByVal pDetail As Integer, ByVal pDate As DateTime, ByVal dPaid As Decimal, ByVal pMethod As String, ByVal pLate As Decimal, ByVal pInt As Decimal, ByVal pModifyUser As String) As SystemFramework.MessageHelper
            Dim aRDT As DataTranslation.ARDT = New DataTranslation.ARDT()
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (DataTranslation.ARDT.modifyARMethod(tran, pDetail, pDate, dPaid, pMethod, pLate, pInt, pModifyUser) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "AR Update Payment Method Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Private Shared Function validateResultCode(ByVal pResults As String, ByVal pNotes As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Strings.Len(pResults) <> 0) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(8)
            messageHelper.messageText = "For any child rows there must be a result code."
            messageHelper.status = False
            Return messageHelper
        End Function
    End Class
End Namespace