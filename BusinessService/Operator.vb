Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Web.Security
Imports SystemFramework

Namespace BusinessService
    Public Class [Operator]
        Private tableName As String

        Private pkColumn As String

        Private m_operatorId As Integer

        Private m_userId As String

        Private m_password As String

        Private m_firstName As String

        Private m_lastName As String

        Private m_defaultScheduleArea As Integer

        Private m_defaultTelephoneArea As Integer

        Private m_role As Integer

        Private m_DefaultApp_Function_ID As Integer

        Private m_company_ID As Integer

        Private newPassword As String

        Private isUpdate As Boolean

        Private isCreate As Boolean

        Public Property company_ID As Integer
            Get
                Return Me.m_company_ID
            End Get
            Set(ByVal value As Integer)
                Me.m_company_ID = value
            End Set
        End Property

        Public Property defaultApp_Function_ID As Integer
            Get
                Return Me.m_DefaultApp_Function_ID
            End Get
            Set(ByVal value As Integer)
                Me.m_DefaultApp_Function_ID = value
            End Set
        End Property

        Public Property defaultScheduleArea As Integer
            Get
                Return Me.m_defaultScheduleArea
            End Get
            Set(ByVal value As Integer)
                Me.m_defaultScheduleArea = value
            End Set
        End Property

        Public ReadOnly Property defaultTarget As String
            Get
                Dim str As String
                Dim messageHelper As New SystemFramework.MessageHelper()
                Dim appFunction As New BusinessService.AppFunction()
                If (Me.defaultApp_Function_ID <> 0) Then
                    messageHelper = appFunction.getAppFunctionById(Me.defaultApp_Function_ID)
                    str = StringType.FromObject(LateBinding.LateGet(messageHelper.messageObject, Nothing, "functionTarget", New Object(-1) {}, Nothing, Nothing))
                Else
                    str = ""
                End If
                Return str
            End Get
        End Property

        Public Property defaultTelephoneArea As Integer
            Get
                Return Me.m_defaultTelephoneArea
            End Get
            Set(ByVal value As Integer)
                Me.m_defaultTelephoneArea = value
            End Set
        End Property

        Public Property firstName As String
            Get
                Return Me.m_firstName
            End Get
            Set(ByVal value As String)
                Me.m_firstName = value
            End Set
        End Property

        Public Property lastName As String
            Get
                Return Me.m_lastName
            End Get
            Set(ByVal value As String)
                Me.m_lastName = value
            End Set
        End Property

        Public Property operatorId As Integer
            Get
                Return Me.m_operatorId
            End Get
            Set(ByVal value As Integer)
                Me.m_operatorId = value
            End Set
        End Property

        Public Property password As String
            Get
                Return Me.m_password
            End Get
            Set(ByVal value As String)
                Me.m_password = value
            End Set
        End Property

        Public Property role As Integer
            Get
                Return Me.m_role
            End Get
            Set(ByVal value As Integer)
                Me.m_role = value
            End Set
        End Property

        Public Property userId As String
            Get
                Return Me.m_userId
            End Get
            Set(ByVal value As String)
                Me.m_userId = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
            Me.tableName = "Operator"
            Me.pkColumn = "Operator_ID"
            Me.newPassword = ""
            Me.isUpdate = False
            Me.isCreate = False
        End Sub

        Public Function authorize(ByVal companyId As Integer, ByVal UserId As String, ByVal password As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim operatorDT As DataTranslation.OperatorDT = New DataTranslation.OperatorDT()
            Dim operatorByCompanyUserId As SqlDataReader = Me.getOperatorByCompanyUserId(companyId, UserId)
            messageHelper.status = False
            messageHelper.messageObject = Nothing
            If (Not operatorByCompanyUserId.Read()) Then
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.messageText = "Invalid User Id"
            ElseIf (ObjectType.ObjTst(operatorByCompanyUserId.Item("Active"), 1, False) <> 0) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "User Is Not Active"
            ElseIf (ObjectType.ObjTst(password, operatorByCompanyUserId.Item("password"), False) <> 0) Then
                messageHelper.messageId = StringType.FromInteger(2)
                messageHelper.messageText = "Invalid Password"
            Else
                Me.unpack(operatorByCompanyUserId)
                messageHelper.status = True
                messageHelper.messageObject = Me
            End If
            operatorByCompanyUserId.Close()
            operatorDT = Nothing
            Return messageHelper
        End Function

        Public Function authorizeAppFunction(ByVal operatorId As Integer, ByVal appFunction As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Return (New AppFunctionRole()).getAppFunctionRoleByOperatorId(operatorId, appFunction)
        End Function

        Private Function checkDirtyRead(ByVal operator_id As Integer, ByVal modified_date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Not SystemDT.checkDirtyRead(Me.tableName, Me.pkColumn, operator_id, modified_date)) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(3)
            messageHelper.messageText = "Item Changed By Another User, Action Cancelled"
            Return messageHelper
        End Function

        Public Function createOperator(ByVal tran As TransactionContext, ByVal isAdmin As Boolean, ByVal AdminPswrd As String, ByVal User_ID As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Password As String, ByVal PswrdRpt As String, ByVal NewPswrd As String, ByVal NewPswrdRpt As String, ByVal DefaultScheduleArea_ID As Integer, ByVal DefaultRole_ID As Integer, ByVal DefaultApp_Function_ID As Integer, ByVal Active As Integer, ByVal Company_ID As Integer, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim operatorDT As DataTranslation.OperatorDT = New DataTranslation.OperatorDT()
            Me.isCreate = True
            messageHelper.status = False
            messageHelper = Me.validateOperator(isAdmin, AdminPswrd, User_ID, First_Name, Last_Name, Password, PswrdRpt, NewPswrd, NewPswrdRpt)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = operatorDT.isrtOperator(tran, User_ID, First_Name, Last_Name, Me.newPassword, DefaultScheduleArea_ID, DefaultRole_ID, DefaultApp_Function_ID, Company_ID, Active, Create_User, Modified_User)
            If (Information.IsDBNull(num)) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Operator Insert Failed"
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Function getOperatorByCompanyUserId(ByVal companyId As Integer, ByVal UserId As String) As SqlDataReader
            Return (New OperatorDT()).getOperatorByCompanyUserId(companyId, UserId)
        End Function

        Public Function getOperatorByLastName(ByVal lastname As String) As SqlDataReader
            Return (New OperatorDT()).getOperatorByLastName(lastname)
        End Function

        Public Function getOperatorByOperatorId(ByVal operatorId As Integer) As SqlDataReader
            Return (New OperatorDT()).getOperatorByOperatorId(operatorId)
        End Function

        Public Function getOperatorByUserId(ByVal userid As String) As SqlDataReader
            Return (New OperatorDT()).getOperatorByUserId(userid)
        End Function

        Private Sub unpack(ByVal rdr As SqlDataReader)
            Me.operatorId = IntegerType.FromObject(rdr.Item("Operator_ID"))
            Me.userId = StringType.FromObject(rdr.Item("userId"))
            Me.password = StringType.FromObject(rdr.Item("password"))
            Me.firstName = StringType.FromObject(rdr.Item("First_Name"))
            Me.lastName = StringType.FromObject(rdr.Item("Last_Name"))
            Me.defaultScheduleArea = IntegerType.FromObject(rdr.Item("defaultScheduleArea"))
            Me.defaultTelephoneArea = IntegerType.FromObject(rdr.Item("defaultTelephoneArea"))
            Me.company_ID = IntegerType.FromObject(rdr.Item("Company_ID"))
            Me.role = IntegerType.FromObject(rdr.Item("Role_ID"))
            If (Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(rdr.Item("DefaultApp_Function_ID")))) Then
                Me.defaultApp_Function_ID = IntegerType.FromObject(rdr.Item("DefaultApp_Function_ID"))
            Else
                Me.defaultApp_Function_ID = 0
            End If
        End Sub

        Public Function updateOperatorAll(ByVal tran As TransactionContext, ByVal isAdmin As Boolean, ByVal AdminPswrd As String, ByVal Operator_ID As Integer, ByVal User_ID As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Password As String, ByVal PswrdRpt As String, ByVal NewPswrd As String, ByVal NewPswrdRpt As String, ByVal DefaultScheduleArea_ID As Integer, ByVal DefaultRole_ID As Integer, ByVal DefaultApp_Function_ID As Integer, ByVal Company_ID As Integer, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim operatorDT As DataTranslation.OperatorDT = New DataTranslation.OperatorDT()
            Me.isUpdate = True
            messageHelper.status = False
            messageHelper = Me.validateOperator(isAdmin, AdminPswrd, User_ID, First_Name, Last_Name, Password, PswrdRpt, NewPswrd, NewPswrdRpt)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.checkDirtyRead(Operator_ID, Modified_Date)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (operatorDT.updtOperatorAll(tran, Operator_ID, User_ID, First_Name, Last_Name, Me.newPassword, DefaultScheduleArea_ID, DefaultRole_ID, DefaultApp_Function_ID, Company_ID, Active, Modified_User, DateTime.Now()) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Operator Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Function validateOperator(ByVal isAdmin As Boolean, ByVal AdminPswrd As String, ByVal User_ID As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Password As String, ByVal PswrdRpt As String, ByVal NewPswrd As String, ByVal NewPswrdRpt As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (First_Name.Length() = 0 Or Last_Name.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.messageText = "First and Last Name Required"
                Return messageHelper
            End If
            If (User_ID.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.messageText = "UserId Required"
                Return messageHelper
            End If
            If (Me.isCreate) Then
                If (Not (Password.Length() > 0 And PswrdRpt.Length() > 0)) Then
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.messageText = "Both Password and Confirmation of Password Required"
                ElseIf (Password.Length() >= 5) Then
                    If (StringType.StrCmp(Password, PswrdRpt, False) = 0) Then
                        Me.newPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1")
                        messageHelper.status = True
                        Return messageHelper
                    End If
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.messageText = "Password and Confirmed Password Not Equal"
                Else
                    messageHelper.messageId = StringType.FromInteger(1)
                    messageHelper.messageText = "Password Must Be at Least a Length of 4"
                End If
            End If
            If (Me.isUpdate) Then
                If (PswrdRpt.Length() > 0) Then
                    Dim str As String = FormsAuthentication.HashPasswordForStoringInConfigFile(PswrdRpt, "SHA1")
                    If (Not (StringType.StrCmp(str, Password, False) = 0 Or StringType.StrCmp(str, AdminPswrd, False) = 0 And isAdmin)) Then
                        If (Not isAdmin) Then
                            messageHelper.messageId = StringType.FromInteger(5)
                            messageHelper.messageText = "Confirmation of Existing Password Doesn't Match Password"
                        Else
                            messageHelper.messageId = StringType.FromInteger(4)
                            messageHelper.messageText = "Your Admin Password is Invalid"
                        End If
                    ElseIf (NewPswrd.Length() <= 0) Then
                        If (NewPswrdRpt.Length() > 0) Then
                            messageHelper.messageId = StringType.FromInteger(3)
                            messageHelper.messageText = "A New Password is Required When Entering a Confirmation Password"
                        End If
                    ElseIf (NewPswrd.Length() < 5) Then
                        messageHelper.messageId = StringType.FromInteger(1)
                        messageHelper.messageText = "Password Must Be at Least a Length of 4"
                    ElseIf (NewPswrdRpt.Length() <= 0) Then
                        messageHelper.messageId = StringType.FromInteger(2)
                        messageHelper.messageText = "Confirmation of New Password Required"
                    ElseIf (StringType.StrCmp(NewPswrd, NewPswrdRpt, False) <> 0) Then
                        messageHelper.messageId = StringType.FromInteger(1)
                        messageHelper.messageText = "New Password and Confirmation Don't Match"
                    Else
                        Me.newPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPswrd, "SHA1")
                        messageHelper.status = True
                    End If
                ElseIf (Not (NewPswrd.Length() > 0 Or NewPswrdRpt.Length() > 0)) Then
                    messageHelper.status = True
                Else
                    messageHelper.messageId = StringType.FromInteger(4)
                    messageHelper.messageText = "Confirmation of Existing Password Required to Change Password"
                End If
            End If
            If (Me.newPassword.Length() = 0) Then
                Me.newPassword = Password
            End If
            Return messageHelper
        End Function
    End Class
End Namespace