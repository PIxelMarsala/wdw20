Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class Address
        Private tableName As String

        Private pkColumn As String

        Public Sub New()
            MyBase.New()
            Me.tableName = "Address"
            Me.pkColumn = "Address_ID"
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

        Public Function createAddress(ByRef tran As TransactionContext, ByVal CareOF As String, ByVal Address1 As String, ByVal Address2 As String, ByVal Address3 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal ZipCode As String, ByVal Country As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Dim addressDT As DataTranslation.AddressDT = New DataTranslation.AddressDT()
            messageHelper.status = False
            messageHelper = Me.validateAddress(CareOF, Address1, Address2, Address3, City, County, State, ZipCode, Country, Active, Modified_User)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = addressDT.isrtAddress(tran, CareOF, Address1, Address2, Address3, City, County, State, ZipCode, Country, Active, Create_User, Modified_User)
            If (Information.IsDBNull(num)) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Address Insert Failed"
            Else
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Function getAddressByAddressLine1(ByVal addr1 As String) As SqlDataReader
            Return (New AddressDT()).getAddressByAddressLine1(addr1)
        End Function

        Public Function getAddressByAddressLine2(ByVal addr2 As String) As SqlDataReader
            Return (New AddressDT()).getAddressByAddressLine2(addr2)
        End Function

        Public Function getAddressByCareOf(ByVal CareOf As String) As SqlDataReader
            Return (New AddressDT()).getAddressByCareOf(CareOf)
        End Function

        Public Function getAddressById(ByVal Address_id As Integer) As SqlDataReader
            Return (New AddressDT()).getAddressById(Address_id)
        End Function

        Public Shared Function getAreaZip() As SqlDataReader
            Return AddressDT.getAreaZip()
        End Function

        Public Shared Function getBillingAddressByAddressLine1(ByVal searchCriteria As String) As SqlDataReader
            Return AddressDT.getBillingAddressByAddressLine1(searchCriteria)
        End Function

        Public Shared Function getJobByAddressLine1(ByVal searchCriteria As String) As SqlDataReader
            Return AddressDT.getJobByAddressLine1(searchCriteria)
        End Function

        Public Function updateAddressAll(ByRef tran As TransactionContext, ByVal Address_ID As Integer, ByVal CareOF As String, ByVal Address1 As String, ByVal Address2 As String, ByVal Address3 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal ZipCode As String, ByVal Country As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim addressDT As DataTranslation.AddressDT = New DataTranslation.AddressDT()
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateAddress(CareOF, Address1, Address2, Address3, City, County, State, ZipCode, Country, Active, Modified_User)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.checkDirtyRead(Address_ID, Modified_Date)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (addressDT.updtAddressAll(tran, Address_ID, CareOF, Address1, Address2, Address3, City, County, State, ZipCode, Country, Active, Modified_User, DateTime.Now()) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Address Update Failed"
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Public Function validateAddress(ByVal CareOF As String, ByVal Address1 As String, ByVal Address2 As String, ByVal Address3 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal ZipCode As String, ByVal Country As String, ByVal Active As Integer, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            messageHelper = Me.validateRequiredFields(Address1, City, State, ZipCode)
            Return messageHelper
        End Function

        Private Function validateRequiredFields(ByVal Address1 As String, ByVal City As String, ByVal State As String, ByVal ZipCode As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            messageHelper.status = False

            If (Not (Address1.Length() = 0 Or City.Length() = 0 Or State.Length() = 0 Or ZipCode.Length() = 0)) Then
                messageHelper.status = True
            Else
                messageHelper.messageId = StringType.FromInteger(4)
                messageHelper.messageText = "Address1, City, State, Zip are Required"
            End If
            Return messageHelper
        End Function
    End Class
End Namespace