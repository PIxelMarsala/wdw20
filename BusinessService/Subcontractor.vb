Imports DataAccess
Imports DataTranslation
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports SystemFramework

Namespace BusinessService
    Public Class Subcontractor
        Private subcontractorDT As SubcontractorDT

        Private tableName As String

        Private pkColumn As String

        Public Sub New()
            MyBase.New()
            Me.subcontractorDT = New SubcontractorDT()
            Me.tableName = "Subcontractor"
            Me.pkColumn = "Sub_ID"
        End Sub

        Private Function checkDirtyRead(ByVal sub_id As Integer, ByVal modified_date As DateTime) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            If (Not SystemDT.checkDirtyRead(Me.tableName, Me.pkColumn, sub_id, modified_date)) Then
                messageHelper.status = True
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(3)
            messageHelper.messageText = "Item Changed By Another User, Action Cancelled"
            Return messageHelper
        End Function

        Public Function createSubcontractor(ByRef tran As TransactionContext, ByVal ParentSub_ID As Integer, ByVal Company_Name As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Nick_Name As String, ByVal TID As String, ByVal UBI As String, ByVal Contact_Name As String, ByVal Phone_No As String, ByVal Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal E_Mail As String, ByVal dollarMaxAmount As Integer, ByVal Mon_AM As Integer, ByVal Mon_PM As Integer, ByVal Tue_AM As Integer, ByVal Tue_PM As Integer, ByVal Wed_AM As Integer, ByVal Wed_PM As Integer, ByVal Thu_AM As Integer, ByVal Thu_PM As Integer, ByVal Fri_AM As Integer, ByVal Fri_PM As Integer, ByVal Sat_AM As Integer, ByVal Sat_PM As Integer, ByVal Sun_AM As Integer, ByVal Sun_PM As Integer, ByVal Active As Integer, ByVal SelectedAreas As ArrayList, ByVal Create_User As String, ByVal Modified_User As String, ByVal Height As String, ByVal Gutters As Integer, ByVal PwrWash As Integer, ByVal NewConst As Integer, ByVal SpouseName As String, ByVal Notes As String, ByVal PrimaryAddressID As Integer, ByVal AlternateAddressID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            messageHelper = Me.validateSubcontractor(ParentSub_ID, Company_Name, First_Name, Last_Name, Nick_Name, TID, UBI, Contact_Name, Phone_No, Phone_Type, Alt_Phone, Alt_Phone_Type, E_Mail, dollarMaxAmount, Mon_AM, Mon_PM, Tue_AM, Tue_PM, Wed_AM, Wed_PM, Thu_AM, Thu_PM, Fri_AM, Fri_PM, Sat_AM, Sat_PM, Sun_AM, Sun_PM, Active, "", 0, SelectedAreas, Modified_User, DateType.FromString("12 / 31 / 9999"), Height, Gutters, PwrWash, NewConst, SpouseName, Notes, PrimaryAddressID, AlternateAddressID)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            Dim num As Integer = Me.subcontractorDT.isrtSubcontractor(tran, ParentSub_ID, Company_Name, First_Name, Last_Name, Nick_Name, TID, UBI, Contact_Name, Phone_No, Phone_Type, Alt_Phone, Alt_Phone_Type, E_Mail, dollarMaxAmount, Mon_AM, Mon_PM, Tue_AM, Tue_PM, Wed_AM, Wed_PM, Thu_AM, Thu_PM, Fri_AM, Fri_PM, Sat_AM, Sat_PM, Sun_AM, Sun_PM, Active, Create_User, Modified_User, Height, Gutters, PwrWash, NewConst, SpouseName, Notes, PrimaryAddressID, AlternateAddressID)
            If (Information.IsDBNull(num)) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Subcontractor Insert Failed"
            Else
                Me.createSubcontractorAreas(tran, num, SelectedAreas, Create_User, Modified_User)
                messageHelper.status = True
                messageHelper.messageObject = num
            End If
            Return messageHelper
        End Function

        Public Function createSubcontractorAreas(ByRef tran As TransactionContext, ByVal Sub_ID As Integer, ByVal SelectedAreas As ArrayList, ByVal Create_User As String, ByVal Modified_User As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Nothing
            Dim messageHelper1 As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            Dim enumerator As IEnumerator = SelectedAreas.GetEnumerator()
            While enumerator.MoveNext()
                Me.subcontractorDT.isrtSubcontractorArea(tran, Sub_ID, IntegerType.FromObject(enumerator.Current()), 1, Create_User, Modified_User)
            End While
            Return messageHelper
        End Function

        Public Function deleteSubcontractorAreas(ByRef tran As TransactionContext, ByVal Sub_ID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Nothing
            Dim messageHelper1 As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            Me.subcontractorDT.deleteSubcontractorArea(tran, Sub_ID)
            messageHelper1.status = True
            Return messageHelper
        End Function

        Public Function getActiveSubs() As SqlDataReader
            Return Me.subcontractorDT.getActiveSubs()
        End Function

        Public Function getActiveSubsByArea(ByVal area As Integer) As SqlDataReader
            Return Me.subcontractorDT.getActiveSubsByArea(area)
        End Function

        Public Function getSubById(ByVal sub_ID As Integer) As SqlDataReader
            Return subcontractorDT.getSubById(sub_ID)
        End Function

        Public Function getSubcontractorByAltPhone(ByVal altPhone As String) As SqlDataReader
            Return subcontractorDT.getSubcontractorByAltPhone(altPhone)
        End Function

        Public Function getSubcontractorByLastName(ByVal lastName As String) As SqlDataReader
            Return Me.subcontractorDT.getSubcontractorByLastName(lastName)
        End Function

        Public Function getSubcontractorByNickName(ByVal nickName As String) As SqlDataReader
            Return Me.subcontractorDT.getSubcontractorByNickName(nickName)
        End Function

        Public Function getSubcontractorByPrimaryPhone(ByVal primaryPhone As String) As SqlDataReader
            Return subcontractorDT.getSubcontractorByPrimaryPhone(primaryPhone)
        End Function

        Public Function getSubcontractorsAreas(ByVal sub_id As Integer) As SqlDataReader
            Return Me.subcontractorDT.getSubcontractorsAreas(sub_id)
        End Function

        Public Function updateSubcontractorAll(ByRef tran As TransactionContext, ByVal Sub_ID As Integer, ByVal ParentSub_ID As Integer, ByVal Company_Name As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Nick_Name As String, ByVal TID As String, ByVal UBI As String, ByVal Contact_Name As String, ByVal Phone_No As String, ByVal Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal E_Mail As String, ByVal dollarMaxAmount As Integer, ByVal Mon_AM As Integer, ByVal Mon_PM As Integer, ByVal Tue_AM As Integer, ByVal Tue_PM As Integer, ByVal Wed_AM As Integer, ByVal Wed_PM As Integer, ByVal Thu_AM As Integer, ByVal Thu_PM As Integer, ByVal Fri_AM As Integer, ByVal Fri_PM As Integer, ByVal Sat_AM As Integer, ByVal Sat_PM As Integer, ByVal Sun_AM As Integer, ByVal Sun_PM As Integer, ByVal Active As Integer, ByVal HiddenNickName As String, ByVal HiddenActive As Integer, ByVal SelectedAreas As ArrayList, ByVal Modified_User As String, ByVal Modified_Date As DateTime, ByVal Height As String, ByVal Gutters As Integer, ByVal PwrWash As Integer, ByVal NewConst As Integer, ByVal SpouseName As String, ByVal Notes As String, ByVal PrimaryAddressID As Integer, ByVal AlternateAddressID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = Me.validateSubcontractor(ParentSub_ID, Company_Name, First_Name, Last_Name, Nick_Name, TID, UBI, Contact_Name, Phone_No, Phone_Type, Alt_Phone, Alt_Phone_Type, E_Mail, dollarMaxAmount, Mon_AM, Mon_PM, Tue_AM, Tue_PM, Wed_AM, Wed_PM, Thu_AM, Thu_PM, Fri_AM, Fri_PM, Sat_AM, Sat_PM, Sun_AM, Sun_PM, Active, HiddenNickName, HiddenActive, SelectedAreas, Modified_User, Modified_Date, Height, Gutters, PwrWash, NewConst, SpouseName, Notes, PrimaryAddressID, AlternateAddressID)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateActive(Sub_ID, Active, HiddenActive)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.checkDirtyRead(Sub_ID, Modified_Date)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (Me.subcontractorDT.updtSubcontractorAll(tran, Sub_ID, ParentSub_ID, Company_Name, First_Name, Last_Name, Nick_Name, TID, UBI, Contact_Name, Phone_No, Phone_Type, Alt_Phone, Alt_Phone_Type, E_Mail, dollarMaxAmount, Mon_AM, Mon_PM, Tue_AM, Tue_PM, Wed_AM, Wed_PM, Thu_AM, Thu_PM, Fri_AM, Fri_PM, Sat_AM, Sat_PM, Sun_AM, Sun_PM, Active, Modified_User, DateTime.Now(), Height, Gutters, PwrWash, NewConst, SpouseName, Notes, PrimaryAddressID, AlternateAddressID) <> -1) Then
                messageHelper.messageId = StringType.FromInteger(3)
                messageHelper.messageText = "Subcontractor Update Failed"
            Else
                messageHelper.status = True
                Me.deleteSubcontractorAreas(tran, Sub_ID)
                Me.createSubcontractorAreas(tran, Sub_ID, SelectedAreas, Modified_User, Modified_User)
            End If
            Return messageHelper
        End Function

        Private Function validateActive(ByVal Sub_ID As Integer, ByVal Active As Integer, ByVal HiddenActive As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            If (Active = HiddenActive Or Active = 1 And HiddenActive = 0) Then
                messageHelper.status = True
                Return messageHelper
            End If
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = Me.subcontractorDT.countSubActiveJobs(Sub_ID)
            sqlDataReader.Read()
            If (IntegerType.FromObject(sqlDataReader.Item(0)) <> 0) Then
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.messageText = "Inactivation Denied - Sub has Un-Closed Jobs"
                messageHelper.status = False
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Private Function validateEMail(ByVal E_Mail As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
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

        Private Function validateFields(ByVal First_Name As String, ByVal Last_Name As String, ByVal Nick_Name As String, ByVal TID As String, ByVal UBI As String, ByVal dollarMaxAmount As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper()
            If (First_Name.Length() = 0 Or Last_Name.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(4)
                messageHelper.messageText = "First and Last Name Required"
                messageHelper.status = False
                Return messageHelper
            End If
            messageHelper.status = True
            If (Nick_Name.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(5)
                messageHelper.messageText = "Nick Name Required"
                messageHelper.status = False
                Return messageHelper
            End If
            messageHelper.status = True
            If (TID.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(6)
                messageHelper.messageText = "TID Required"
                messageHelper.status = False
                Return messageHelper
            End If
            messageHelper.status = True
            If (UBI.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(7)
                messageHelper.messageText = "UBI Required"
                messageHelper.status = False
                Return messageHelper
            End If
            messageHelper.status = True
            If (dollarMaxAmount <> 0) Then
                Return messageHelper
            End If
            messageHelper.messageId = StringType.FromInteger(9)
            messageHelper.messageText = "DollarMaxAmount Required"
            messageHelper.status = False
            Return messageHelper
        End Function

        Private Function validateNickNameUnique(ByVal Nick_Name As String, ByVal HiddenNickName As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            If (StringType.StrCmp(Nick_Name, HiddenNickName, False) = 0) Then
                messageHelper.status = True
                Return messageHelper
            End If
            Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = Me.subcontractorDT.countSubNickName(Nick_Name)
            sqlDataReader.Read()
            If (IntegerType.FromObject(sqlDataReader.Item(0)) <> 0) Then
                messageHelper.messageId = StringType.FromInteger(1)
                messageHelper.messageText = "Nick Name Must Be Unique"
                messageHelper.status = False
            Else
                messageHelper.status = True
            End If
            Return messageHelper
        End Function

        Private Function validatePhones(ByVal Phone_No As String, ByVal Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            If (Phone_No.Length() = 0) Then
                messageHelper.messageId = StringType.FromInteger(6)
                messageHelper.messageText = "Primary Phone Required"
                Return messageHelper
            End If
            If (Phone_No.Length() <> 10) Then
                messageHelper.messageId = StringType.FromInteger(7)
                messageHelper.messageText = "Primary Phone must be 10 Digits"
                Return messageHelper
            End If
            If (Not Information.IsNumeric(Phone_No)) Then
                messageHelper.messageId = StringType.FromInteger(8)
                messageHelper.messageText = "Primary Phone must Numeric"
                Return messageHelper
            End If
            If (Phone_Type.Length() = 0) Then
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
            messageHelper.status = True
            Return messageHelper
        End Function

        Public Function validateSubcontractor(ByVal ParentSub_ID As Integer, ByVal Company_Name As String, ByVal First_Name As String, ByVal Last_Name As String, ByVal Nick_Name As String, ByVal TID As String, ByVal UBI As String, ByVal Contact_Name As String, ByVal Phone_No As String, ByVal Phone_Type As String, ByVal Alt_Phone As String, ByVal Alt_Phone_Type As String, ByVal E_Mail As String, ByVal dollarMaxAmount As Integer, ByVal Mon_AM As Integer, ByVal Mon_PM As Integer, ByVal Tue_AM As Integer, ByVal Tue_PM As Integer, ByVal Wed_AM As Integer, ByVal Wed_PM As Integer, ByVal Thu_AM As Integer, ByVal Thu_PM As Integer, ByVal Fri_AM As Integer, ByVal Fri_PM As Integer, ByVal Sat_AM As Integer, ByVal Sat_PM As Integer, ByVal Sun_AM As Integer, ByVal Sun_PM As Integer, ByVal Active As Integer, ByVal HiddenNickName As String, ByVal HiddenActive As Integer, ByVal SelectedAreas As ArrayList, ByVal Modified_User As String, ByVal Modified_Date As DateTime, ByVal Height As String, ByVal Gutters As Integer, ByVal PwrWash As Integer, ByVal NewConst As Integer, ByVal SpouseName As String, ByVal Notes As String, ByVal PrimaryAddressID As Integer, ByVal AlternateAddressID As Integer) As SystemFramework.MessageHelper
            Dim messageHelper As SystemFramework.MessageHelper = New SystemFramework.MessageHelper() With
            {
                .status = False
            }
            messageHelper = Me.validateFields(First_Name, Last_Name, Nick_Name, TID, UBI, dollarMaxAmount)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validatePhones(Phone_No, Phone_Type, Alt_Phone, Alt_Phone_Type)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateEMail(E_Mail)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            messageHelper = Me.validateNickNameUnique(Nick_Name, HiddenNickName)
            If (Not messageHelper.status) Then
                Return messageHelper
            End If
            If (PrimaryAddressID = 0 And AlternateAddressID = 0) Then
                messageHelper.status = False
                messageHelper.messageText = "One Address Required"
            End If
            If (Not Information.IsNumeric(Height)) Then
                messageHelper.status = False
                messageHelper.messageText = "Invalid Height"
            End If
            Return messageHelper
        End Function

        Private Class OldArea
            Public areaName As String

            Public processed As Boolean

            Public Sub New(ByVal name As String, ByVal found As Boolean)
                MyBase.New()
                Me.areaName = name
                Me.processed = found
            End Sub
        End Class
    End Class
End Namespace