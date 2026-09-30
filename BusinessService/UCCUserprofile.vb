Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCUserprofile
        Private ooperator As [Operator]

        Public Sub New()
            MyBase.New()
            Me.ooperator = New [Operator]()
        End Sub

        Public Function createUserprofile(ByVal isAdmin As Boolean, ByVal AdminPswrd As String, ByVal User_ID As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Password As String, ByVal PswrdRpt As String, ByVal NewPswrd As String, ByVal NewPswrdRpt As String, ByVal DefaultScheduleArea_ID As Integer, ByVal DefaultRole_ID As Integer, ByVal DefaultApp_Function_ID As Integer, ByVal Company_ID As Integer, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.ooperator.createOperator(transactionContext, isAdmin, AdminPswrd, User_ID, First_Name, Last_Name, Password, PswrdRpt, NewPswrd, NewPswrdRpt, DefaultScheduleArea_ID, DefaultRole_ID, DefaultApp_Function_ID, Company_ID, Active, Create_User, Modified_User)
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

        Public Function getOperatorByCompanyUserId(ByVal company_id As Integer, ByVal user_id As String) As SqlDataReader
            Return Me.ooperator.getOperatorByCompanyUserId(company_id, user_id)
        End Function

        Public Function getOperatorByLastName(ByVal last_name As String) As SqlDataReader
            Return Me.ooperator.getOperatorByLastName(last_name)
        End Function

        Public Function getOperatorByUserId(ByVal user_id As String) As SqlDataReader
            Return Me.ooperator.getOperatorByUserId(user_id)
        End Function

        Public Function getUserprofileById(ByVal operator_id As Integer) As SqlDataReader
            Return Me.ooperator.getOperatorByOperatorId(operator_id)
        End Function

        Public Function updateOperatorAll(ByVal isAdmin As Boolean, ByVal AdminPswrd As String, ByVal Operator_ID As Integer, ByVal User_ID As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Password As String, ByVal PswrdRpt As String, ByVal NewPswrd As String, ByVal NewPswrdRpt As String, ByVal DefaultScheduleArea_ID As Integer, ByVal DefaultRole_ID As Integer, ByVal DefaultApp_Function_ID As Integer, ByVal Company_ID As Integer, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.ooperator.updateOperatorAll(transactionContext, isAdmin, AdminPswrd, Operator_ID, User_ID, First_Name, Last_Name, Password, PswrdRpt, NewPswrd, NewPswrdRpt, DefaultScheduleArea_ID, DefaultRole_ID, DefaultApp_Function_ID, Company_ID, Active, Modified_User, Modified_Date)
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