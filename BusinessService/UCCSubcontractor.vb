Imports DataAccess
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class UCCSubcontractor
        Private subcontractor As Subcontractor

        Public Sub New()
            MyBase.New()
            Me.subcontractor = New Subcontractor()
        End Sub

        Public Function createSubcontractor(ByVal ParentSub_ID As Integer, ByVal Company_Name As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Nick_Name As String, ByVal TID As String, ByVal UBI As String, ByVal Contact_Name As String, ByVal Phone_No As String, ByVal Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal E_Mail As String, ByVal dollarMaxAmount As Integer, ByVal Mon_AM As Integer, ByVal Mon_PM As Integer, ByVal Tue_AM As Integer, ByVal Tue_PM As Integer, ByVal Wed_AM As Integer, ByVal Wed_PM As Integer, ByVal Thu_AM As Integer, ByVal Thu_PM As Integer, ByVal Fri_AM As Integer, ByVal Fri_PM As Integer, ByVal Sat_AM As Integer, ByVal Sat_PM As Integer, ByVal Sun_AM As Integer, ByVal Sun_PM As Integer, ByVal Active As Integer, ByVal SelectedAreas As ArrayList, ByVal Create_User As String, ByVal Modified_User As String, ByVal Height As String, ByVal Gutters As Integer, ByVal PwrWash As Integer, ByVal NewConst As Integer, ByVal SpouseName As String, ByVal Notes As String, ByVal PrimaryAddressID As Integer, ByVal AlternateAddressID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.subcontractor.createSubcontractor(transactionContext, ParentSub_ID, Company_Name, First_Name, Last_Name, Nick_Name, TID, UBI, Contact_Name, Phone_No, Phone_Type, Alt_Phone, Alt_Phone_Type, E_Mail, dollarMaxAmount, Mon_AM, Mon_PM, Tue_AM, Tue_PM, Wed_AM, Wed_PM, Thu_AM, Thu_PM, Fri_AM, Fri_PM, Sat_AM, Sat_PM, Sun_AM, Sun_PM, Active, SelectedAreas, Create_User, Modified_User, Height, Gutters, PwrWash, NewConst, SpouseName, Notes, PrimaryAddressID, AlternateAddressID)
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

        Public Function getActiveSubs() As SqlDataReader
            Return Me.subcontractor.getActiveSubs()
        End Function

        Public Function getSubById(ByVal sub_id As Integer) As SqlDataReader
            Return Me.subcontractor.getSubById(sub_id)
        End Function

        Public Function getsubcontractorByAltPhone(ByVal altPhone As String) As SqlDataReader
            Return Me.subcontractor.getSubcontractorByAltPhone(altPhone)
        End Function

        Public Function getSubcontractorByLastName(ByVal lastName As String) As SqlDataReader
            Return Me.subcontractor.getSubcontractorByLastName(lastName)
        End Function

        Public Function getsubcontractorByNickName(ByVal nickName As String) As SqlDataReader
            Return Me.subcontractor.getSubcontractorByNickName(nickName)
        End Function

        Public Function getsubcontractorByPrimaryPhone(ByVal primaryPhone As String) As SqlDataReader
            Return Me.subcontractor.getSubcontractorByPrimaryPhone(primaryPhone)
        End Function

        Public Function getSubcontractorsAreas(ByVal sub_id As Integer) As SqlDataReader
            Return Me.subcontractor.getSubcontractorsAreas(sub_id)
        End Function

        Public Function updateSubcontractorAll(ByVal subcontractor_ID As Integer, ByVal ParentSub_ID As Integer, ByVal Company_Name As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Nick_Name As String, ByVal TID As String, ByVal UBI As String, ByVal Contact_Name As String, ByVal Phone_No As String, ByVal Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal E_Mail As String, ByVal dollarMaxAmount As Integer, ByVal Mon_AM As Integer, ByVal Mon_PM As Integer, ByVal Tue_AM As Integer, ByVal Tue_PM As Integer, ByVal Wed_AM As Integer, ByVal Wed_PM As Integer, ByVal Thu_AM As Integer, ByVal Thu_PM As Integer, ByVal Fri_AM As Integer, ByVal Fri_PM As Integer, ByVal Sat_AM As Integer, ByVal Sat_PM As Integer, ByVal Sun_AM As Integer, ByVal Sun_PM As Integer, ByVal Active As Integer, ByVal HiddenNickName As String, ByVal HiddenActive As Integer, ByVal SelectedAreas As ArrayList, ByVal Modified_User As String, ByVal Modified_Date As DateTime, ByVal Height As String, ByVal Gutters As Integer, ByVal PwrWash As Integer, ByVal NewConst As Integer, ByVal SpouseName As String, ByVal Notes As String, ByVal PrimaryAddressID As Integer, ByVal AlternateAddressID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper
            Dim transactionContext As DataAccess.TransactionContext = New DataAccess.TransactionContext()
            Try
                transactionContext.beginTransaction()
                Dim messageHelper1 As SystemFramework.MessageHelper = Me.subcontractor.updateSubcontractorAll(transactionContext, subcontractor_ID, ParentSub_ID, Company_Name, First_Name, Last_Name, Nick_Name, TID, UBI, Contact_Name, Phone_No, Phone_Type, Alt_Phone, Alt_Phone_Type, E_Mail, dollarMaxAmount, Mon_AM, Mon_PM, Tue_AM, Tue_PM, Wed_AM, Wed_PM, Thu_AM, Thu_PM, Fri_AM, Fri_PM, Sat_AM, Sat_PM, Sun_AM, Sun_PM, Active, HiddenNickName, HiddenActive, SelectedAreas, Modified_User, Modified_Date, Height, Gutters, PwrWash, NewConst, SpouseName, Notes, PrimaryAddressID, AlternateAddressID)
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