Imports DataAccess
'Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCClient
        Private client As Client

        Public Sub New()
            MyBase.New()
            Me.client = New Client()
        End Sub

        Public Function createClient(ByVal BillAddress_ID As Integer, ByVal First_Name As String, ByVal Last_Name As String, ByVal Discount As String, ByVal Client_Type As String, ByVal COD As Integer, ByVal Spouse_Name As String, ByVal Contact_Name As String, ByVal Primary_Phone As String, ByVal Prm_Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal Acct_Type As String, ByVal Notes As String, ByVal Other1_Phone As String, ByVal Other1_Phone_Type As String, ByVal Other2_Phone As String, ByVal Other2_Phone_Type As String, ByVal E_Mail As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.client.createClient(transactionContext, BillAddress_ID, First_Name, Last_Name, Discount, Client_Type, COD, Spouse_Name, Contact_Name, Primary_Phone, Prm_Phone_Type, Alt_Phone, Alt_Phone_Type, Acct_Type, Notes, Other1_Phone, Other1_Phone_Type, Other2_Phone, Other2_Phone_Type, E_Mail, Active, Create_User, Modified_User)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                'ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function

        Public Function getClientByAltPhone(ByVal alt_phone As String) As SqlDataReader
            Return Me.client.getClientByAltPhone(alt_phone)
        End Function

        Public Function getClientByContactName(ByVal contact_name As String) As SqlDataReader
            Return Me.client.getClientByContactName(contact_name)
        End Function

        Public Function getClientById(ByVal client_id As Integer) As SqlDataReader
            Return Me.client.getClientById(client_id)
        End Function

        Public Function getClientByLastName(ByVal last_name As String) As SqlDataReader
            Return Me.client.getClientByLastName(last_name)
        End Function

        Public Function getClientByPrimaryPhone(ByVal primary_phone As String) As SqlDataReader
            Return Me.client.getClientByPrimaryPhone(primary_phone)
        End Function

        Public Function updateClientAll(ByVal Client_Id As Integer, ByVal BillAddress_ID As Integer, ByVal First_Name As String, ByVal Last_Name As String, ByVal Discount As String, ByVal Client_Type As String, ByVal COD As Integer, ByVal Spouse_Name As String, ByVal Contact_Name As String, ByVal Primary_Phone As String, ByVal Prm_Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal Acct_Type As String, ByVal Notes As String, ByVal Other1_Phone As String, ByVal Other1_Phone_Type As String, ByVal Other2_Phone As String, ByVal Other2_Phone_Type As String, ByVal E_Mail As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.client.updateClientAll(transactionContext, Client_Id, BillAddress_ID, First_Name, Last_Name, Discount, Client_Type, COD, Spouse_Name, Contact_Name, Primary_Phone, Prm_Phone_Type, Alt_Phone, Alt_Phone_Type, Acct_Type, Notes, Other1_Phone, Other1_Phone_Type, Other2_Phone, Other2_Phone_Type, E_Mail, Active, Modified_User, Modified_Date)
                If (Not messageHelper1.status) Then
                    transactionContext.rollback()
                    messageHelper = messageHelper1
                Else
                    transactionContext.commit()
                    messageHelper = messageHelper1
                End If
            Catch exception As System.Exception
                'ProjectData.SetProjectError(exception)
                Throw exception
            End Try
            Return messageHelper
        End Function
    End Class
End Namespace