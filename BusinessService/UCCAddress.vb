Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCAddress
        Private address As Address

        Public Sub New()
            MyBase.New()
            Me.address = New Address()
        End Sub

        Public Function createAddress(ByVal CareOF As String, ByVal Address1 As String, ByVal Address2 As String, ByVal Address3 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal ZipCode As String, ByVal Country As String, ByVal Active As Integer, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.address.createAddress(transactionContext, CareOF, Address1, Address2, Address3, City, County, State, ZipCode, Country, Active, Create_User, Modified_User)
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

        Public Function getAddressByAddressLine1(ByVal addr1 As String) As SqlDataReader
            Return Me.address.getAddressByAddressLine1(addr1)
        End Function

        Public Function getAddressByAddressLine2(ByVal addr2 As String) As SqlDataReader
            Return Me.address.getAddressByAddressLine2(addr2)
        End Function

        Public Function getAddressByCareOf(ByVal CareOf As String) As SqlDataReader
            Return Me.address.getAddressByCareOf(CareOf)
        End Function

        Public Function getAddressById(ByVal Address_id As Integer) As SqlDataReader
            Return Me.address.getAddressById(Address_id)
        End Function

        Public Function getAreaZip() As SqlDataReader
            Return Address.getAreaZip()
        End Function

        Public Function updateAddressAll(ByVal Address_ID As Integer, ByVal CareOF As String, ByVal Address1 As String, ByVal Address2 As String, ByVal Address3 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal ZipCode As String, ByVal Country As String, ByVal Active As Integer, ByVal Modified_User As String, ByVal Modified_Date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.address.updateAddressAll(transactionContext, Address_ID, CareOF, Address1, Address2, Address3, City, County, State, ZipCode, Country, Active, Modified_User, Modified_Date)
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