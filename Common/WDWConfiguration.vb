Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Runtime.CompilerServices
Imports System.Xml
Imports SystemFramework

Namespace Common
    Public Class WDWConfiguration
        'Implements IConfigurationSectionHandler

        '========= Vinny's Constants ============================================

        ' LOCAL, PROD, DEV
        Private Const _ENVIRONMENT = "PROD"
        'Private Const _ENVIRONMENT = "LOCAL"
        'Private Const _ENVIRONMENT = "DEV"

        '========================================================================


        ' DATABSES
        Private Const _LOCAL_ConnectionDatabase As String = "f3434_Dev"
        Private Const _PROD_ConnectionDatabase As String = "f3434"
        Private Const _DEV_ConnectionDatabase As String = "f3434_Dev"


        Public Shared ReadOnly Property ConnectionDatabase As String
            Get
                Select Case _ENVIRONMENT
                    Case "PROD" : Return _PROD_ConnectionDatabase
                    Case "LOCAL" : Return _LOCAL_ConnectionDatabase
                    Case "DEV" : Return _DEV_ConnectionDatabase
                End Select
                Return ""
            End Get

        End Property

        Public Shared ReadOnly Property ConnectionUserID As String
            Get
                Return "3434.sql"
            End Get
        End Property

        Public Shared ReadOnly Property ConnectionPassword As String
            Get
                Return "Gr3@tGUI"
            End Get
        End Property

        Public Shared ReadOnly Property ConnectionServer As String
            Get
                Return "sql2.pixelmarsala.com"
            End Get
        End Property

        Public Shared ReadOnly Property ConnectionString As String
            Get
                Return "persist security info=False;packet size=4096;Data Source=" & ConnectionServer & ";Initial Catalog=" & ConnectionDatabase & ";User Id=" & ConnectionUserID & ";Password=" & ConnectionPassword & ";"
            End Get
        End Property
        Public Shared ReadOnly Property EnvironmentFlag As String
            Get
                Return _ENVIRONMENT
            End Get
        End Property

    End Class
End Namespace