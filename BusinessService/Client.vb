Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class Client
        Private tableName As String

        Private pkColumn As String

        Public Sub New()
            MyBase.New()
            Me.tableName = "Client"
            Me.pkColumn = "Client_ID"
        End Sub

        Private Function checkDirtyRead(ByVal client_id As Integer, ByVal modified_date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Not SystemDT.checkDirtyRead(Me.tableName, Me.pkColumn, client_id, modified_date)) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(3)
            messageHelper.messageText = "Item Changed By Another User, Action Cancelled"
            Return messageHelper
        End Function

        Public Function createClient(ByRef tran As TransactionContext, ByVal BillAddress_ID As Integer, ByVal First_Name As String, ByVal Last_Name As String, ByVal Discount As String, ByVal Client_Type As String, ByVal COD As Integer, ByVal Spouse_Name As String, ByVal Contact_Name As String, ByVal Primary_Phone As String, ByVal Prm_Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal Acct_Type As String, ByVal Notes As String, ByVal Other1_Phone As String, ByVal Other1_Phone_Type As String, ByVal Other2_Phone As String, ByVal Other2_Phone_Type As String, ByVal E_Mail As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim clientDT As DataTranslation.ClientDT = New DataTranslation.ClientDT()
            messageHelper.status = False
            messageHelper = Me.validateClient(0, BillAddress_ID, First_Name, Last_Name, Discount, Client_Type, COD, Spouse_Name, Contact_Name, Primary_Phone, Prm_Phone_Type, Alt_Phone, Alt_Phone_Type, Acct_Type, Notes, Other1_Phone, Other1_Phone_Type, Other2_Phone, Other2_Phone_Type, E_Mail, Active, Modified_User, DateType.FromString("12 / 31 / 9999"))
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = clientDT.isrtClient(tran, BillAddress_ID, First_Name, Last_Name, Discount, Client_Type, COD, Spouse_Name, Contact_Name, Primary_Phone, Prm_Phone_Type, Alt_Phone, Alt_Phone_Type, Acct_Type, Notes, Other1_Phone, Other1_Phone_Type, Other2_Phone, Other2_Phone_Type, E_Mail, Active, Create_User, Modified_User)
            If (Information.IsDBNull(num)) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Client Insert Failed"
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Function getClientByAltPhone(ByVal alt_phone As String) As SqlDataReader
            Dim clientDT As DataTranslation.ClientDT = New DataTranslation.ClientDT()
            Return DataTranslation.ClientDT.getClientByAltPhone(alt_phone)
        End Function

        Public Function getClientByContactName(ByVal contact_name As String) As SqlDataReader
            Dim clientDT As DataTranslation.ClientDT = New DataTranslation.ClientDT()
            Return DataTranslation.ClientDT.getClientByContactName(contact_name)
        End Function

        Public Function getClientById(ByVal client_ID As Integer) As SqlDataReader
            Dim clientDT As DataTranslation.ClientDT = New DataTranslation.ClientDT()
            Return DataTranslation.ClientDT.getClientById(client_ID)
        End Function

        Public Function getClientByLastName(ByVal last_name As String) As SqlDataReader
            Dim clientDT As DataTranslation.ClientDT = New DataTranslation.ClientDT()
            Return DataTranslation.ClientDT.getClientByLastName(last_name)
        End Function

        Public Function getClientByPrimaryPhone(ByVal primary_phone As String) As SqlDataReader
            Dim clientDT As DataTranslation.ClientDT = New DataTranslation.ClientDT()
            Return DataTranslation.ClientDT.getClientByPrimaryPhone(primary_phone)
        End Function

        Public Function updateClientAll(ByRef tran As TransactionContext, ByVal Client_Id As Integer, ByVal BillAddress_ID As Integer, ByVal First_Name As String, ByVal Last_Name As String, ByVal Discount As String, ByVal Client_Type As String, ByVal COD As Integer, ByVal Spouse_Name As String, ByVal Contact_Name As String, ByVal Primary_Phone As String, ByVal Prm_Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal Acct_Type As String, ByVal Notes As String, ByVal Other1_Phone As String, ByVal Other1_Phone_Type As String, ByVal Other2_Phone As String, ByVal Other2_Phone_Type As String, ByVal E_Mail As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim clientDT As DataTranslation.ClientDT = New DataTranslation.ClientDT()
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateClient(Client_Id, BillAddress_ID, First_Name, Last_Name, Discount, Client_Type, COD, Spouse_Name, Contact_Name, Primary_Phone, Prm_Phone_Type, Alt_Phone, Alt_Phone_Type, Acct_Type, Notes, Other1_Phone, Other1_Phone_Type, Other2_Phone, Other2_Phone_Type, E_Mail, Active, Modified_User, Modified_Date)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.checkDirtyRead(Client_Id, Modified_Date)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (clientDT.updtClientAll(tran, Client_Id, BillAddress_ID, First_Name, Last_Name, Discount, Client_Type, COD, Spouse_Name, Contact_Name, Primary_Phone, Prm_Phone_Type, Alt_Phone, Alt_Phone_Type, Acct_Type, Notes, Other1_Phone, Other1_Phone_Type, Other2_Phone, Other2_Phone_Type, E_Mail, Active, Modified_User, DateTime.Now()) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Client Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Function validateClient(ByVal client_id As Integer, ByVal BillAddress_ID As Integer, ByVal First_Name As String, ByVal Last_Name As String, ByVal Discount As String, ByVal Client_Type As String, ByVal COD As Integer, ByVal Spouse_Name As String, ByVal Contact_Name As String, ByVal Primary_Phone As String, ByVal Prm_Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal Acct_Type As String, ByVal Notes As String, ByVal Other1_Phone As String, ByVal Other1_Phone_Type As String, ByVal Other2_Phone As String, ByVal Other2_Phone_Type As String, ByVal E_Mail As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            messageHelper = Me.validateNames(First_Name, Last_Name, Client_Type)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validatePhones(Primary_Phone, Prm_Phone_Type, Alt_Phone, Alt_Phone_Type, Other1_Phone, Other1_Phone_Type, Other2_Phone, Other2_Phone_Type)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateEMail(E_Mail)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Return messageHelper
        End Function

        Private Function validateEMail(ByVal E_Mail As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            Dim num As Integer = E_Mail.IndexOf("@")
            If (E_Mail.Length() <= 0) Then
                messageHelper.status = True
            ElseIf (num <= 0) Then
                messageHelper.messageId = StringType.FromInteger(4)
                messageHelper.messageText = "Invalid E-Mail"
            ElseIf (E_Mail.IndexOf("@") <= E_Mail.IndexOf(".", num)) Then
                messageHelper.status = True
            Else
                messageHelper.messageId = StringType.FromInteger(4)
                messageHelper.messageText = "Invalid E-Mail"
            End If
            Return messageHelper
        End Function

        Private Function validateNames(ByVal First_Name As String, ByVal Last_Name As String, ByVal Client_Type As String) As SystemFramework.MessageHelper
            'Dim messageHelper As SystemFramework.MessageHelper = Nothing
            Dim messageHelper1 As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper1.status = False

            If (StringType.StrCmp(Client_Type, "I", False) = 0) Then
                If (Not (First_Name.Length() = 0 Or Last_Name.Length() = 0)) Then
                    messageHelper1.status = True
                    Return messageHelper1
                End If
                messageHelper1.messageId = StringType.FromInteger(4)
                messageHelper1.messageText = "Individual Clients must have First and Last Name"
                Return messageHelper1
            End If
            If (StringType.StrCmp(Client_Type, "C", False) <> 0) Then
                Return messageHelper1
            End If
            If (First_Name.Length() > 0) Then
                messageHelper1.messageId = StringType.FromInteger(5)
                messageHelper1.messageText = "Commercial Clients may not have First Name"
                Return messageHelper1
            End If
            If (Last_Name.Length() <> 0) Then
                messageHelper1.status = True
                Return messageHelper1
            End If
            messageHelper1.messageId = StringType.FromInteger(6)
            messageHelper1.messageText = "Commercial Clients must have a Last Name"
            Return messageHelper1
        End Function

        Private Function validatePhones(ByVal Primary_Phone As String, ByVal Prm_Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal Other1_Phone As String, ByVal Other1_Phone_Type As String, ByVal Other2_Phone As String, ByVal Other2_Phone_Type As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Primary_Phone.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(6)
                messageHelper.messageText = "Primary Phone Required"
                Return messageHelper
            End If
            If (Primary_Phone.Length() <> 10) Then
                messageHelper.messageId = StringType.FromInteger(7)
                messageHelper.messageText = "Primary Phone must be 10 Digits"
                Return messageHelper
            End If
            If (Not Information.IsNumeric(Primary_Phone)) Then
                messageHelper.messageId = StringType.FromInteger(8)
                messageHelper.messageText = "Primary Phone must Numeric"
                Return messageHelper
            End If
            If (Prm_Phone_Type.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(14)
                messageHelper.messageText = "Prm Phone Type Required"
                Return messageHelper
            End If
            If (Alt_Phone.Length() > 0) Then
                If (Alt_Phone.Length() <> 10) Then
                    messageHelper.messageId = StringType.FromInteger(9)
                    messageHelper.messageText = "Alt Phone must be 10 Digits"
                    Return messageHelper
                End If
                If (Not Information.IsNumeric(Alt_Phone)) Then
                    messageHelper.messageId = StringType.FromInteger(10)
                    messageHelper.messageText = "Alt Phone must Numeric"
                    Return messageHelper
                End If
                If (Alt_Phone_Type.Length() = 0) Then
                    messageHelper.messageId = StringType.FromInteger(14)
                    messageHelper.messageText = "Alt Phone Type Required"
                    Return messageHelper
                End If
            End If
            If (Other1_Phone.Length() > 0) Then
                If (Other1_Phone.Length() <> 10) Then
                    messageHelper.messageId = StringType.FromInteger(9)
                    messageHelper.messageText = "Oth1 Phone must be 10 Digits"
                    Return messageHelper
                End If
                If (Not Information.IsNumeric(Other1_Phone)) Then
                    messageHelper.messageId = StringType.FromInteger(10)
                    messageHelper.messageText = "Oth1 Phone must Numeric"
                    Return messageHelper
                End If
                If (Other1_Phone_Type.Length() = 0) Then
                    messageHelper.messageId = StringType.FromInteger(14)
                    messageHelper.messageText = "Oth1 Phone Type Required"
                    Return messageHelper
                End If
            End If
            If (Other2_Phone.Length() > 0) Then
                If (Other2_Phone.Length() <> 10) Then
                    messageHelper.messageId = StringType.FromInteger(9)
                    messageHelper.messageText = "Oth2 Phone must be 10 Digits"
                    Return messageHelper
                End If
                If (Not Information.IsNumeric(Other2_Phone)) Then
                    messageHelper.messageId = StringType.FromInteger(10)
                    messageHelper.messageText = "Oth2 Phone must Numeric"
                    Return messageHelper
                End If
                If (Other2_Phone_Type.Length() = 0) Then
                    messageHelper.messageId = StringType.FromInteger(14)
                    messageHelper.messageText = "Oth2 Phone Type Required"
                    Return messageHelper
                End If
            End If
            messageHelper.status = True
            Return messageHelper
        End Function
    End Class
End Namespace