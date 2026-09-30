Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports System.Xml

Namespace SystemFramework
    Public Class ApplicationConfiguration
        Implements IConfigurationSectionHandler

        Private Const TRACING_ENABLED As String = "SystemFramework.Tracing.Enabled"

        Private Const TRACING_TRACEFILE As String = "SystemFramework.Tracing.TraceFile"

        Private Const TRACING_TRACELEVEL As String = "SystemFramework.Tracing.TraceLevel"

        Private Const TRACING_SWITCHNAME As String = "SystemFramework.Tracing.SwitchName"

        Private Const TRACING_SWITCHDESCRIPTION As String = "SystemFramework.Tracing.SwitchDescription"

        Private Const EVENTLOG_ENABLED As String = "SystemFramework.EventLog.Enabled"

        Private Const EVENTLOG_MACHINENAME As String = "SystemFramework.EventLog.Machine"

        Private Const EVENTLOG_SOURCENAME As String = "SystemFramework.EventLog.SourceName"

        Private Const EVENTLOG_TRACELEVEL As String = "SystemFramework.EventLog.LogLevel"

        Private Shared fieldTracingEnabled As Boolean

        Private Shared fieldTracingTraceFile As String

        Private Shared fieldTracingTraceLevel As TraceLevel

        Private Shared fieldTracingSettingsFile As String

        Private Shared fieldTracingSwitchName As String

        Private Shared fieldTracingSwitchDescription As String

        Private Shared fieldEventLogEnabled As Boolean

        Private Shared fieldEventLogMachineName As String

        Private Shared fieldEventLogSourceName As String

        Private Shared fieldEventLogTraceLevel As TraceLevel

        Private Shared fieldAppRoot As String

        Private Const TRACING_ENABLED_DEFAULT As Boolean = False

        Private Const TRACING_TRACEFILE_DEFAULT As String = "ApplicationTrace.txt"

        Private Const TRACING_TRACELEVEL_DEFAULT As TraceLevel = 4

        Private Const TRACING_SWITCHNAME_DEFAULT As String = "ApplicationTraceSwitch"

        Private Const TRACING_SWITCHDESCRIPTION_DEFAULT As String = "Application error and tracing information"

        Private Const EVENTLOG_ENABLED_DEFAULT As Boolean = True

        Private Const EVENTLOG_MACHINENAME_DEFAULT As String = "."

        Private Const EVENTLOG_SOURCENAME_DEFAULT As String = "WDWApplication"

        Private Const EVENTLOG_TRACELEVEL_DEFAULT As TraceLevel = 1

        Public Shared ReadOnly Property AppRoot As String
            Get
                Return ApplicationConfiguration.fieldAppRoot
            End Get
        End Property

        Public Shared ReadOnly Property EventLogEnabled As Boolean
            Get
                Return ApplicationConfiguration.fieldEventLogEnabled
            End Get
        End Property

        Public Shared ReadOnly Property EventLogMachineName As String
            Get
                Return ApplicationConfiguration.fieldEventLogMachineName
            End Get
        End Property

        Public Shared ReadOnly Property EventLogSourceName As String
            Get
                Return ApplicationConfiguration.fieldEventLogSourceName
            End Get
        End Property

        Public Shared ReadOnly Property EventLogTraceLevel As TraceLevel
            Get
                Return ApplicationConfiguration.fieldEventLogTraceLevel
            End Get
        End Property

        Public Shared ReadOnly Property TracingEnabled As Boolean
            Get
                Return False
                'Return ApplicationConfiguration.fieldTracingEnabled
            End Get
        End Property

        Public Shared ReadOnly Property TracingSwitchDescription As String
            Get
                Return ApplicationConfiguration.fieldTracingSwitchDescription
            End Get
        End Property

        Public Shared ReadOnly Property TracingSwitchName As String
            Get
                Return ApplicationConfiguration.fieldTracingSwitchName
            End Get
        End Property

        Public Shared ReadOnly Property TracingTraceFile As String
            Get
                Return String.Concat(ApplicationConfiguration.fieldAppRoot, "\", ApplicationConfiguration.fieldTracingTraceFile)
            End Get
        End Property

        Public Shared ReadOnly Property TracingTraceLevel As TraceLevel
            Get
                Return ApplicationConfiguration.fieldTracingTraceLevel
            End Get
        End Property

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal section As XmlNode) As Object
            Dim obj As Object = Nothing
            Dim nameValueCollection As System.Collections.Specialized.NameValueCollection = Nothing
            Try
                Dim nameValueSectionHandler As System.Configuration.NameValueSectionHandler = New System.Configuration.NameValueSectionHandler()
                nameValueCollection = DirectCast(nameValueSectionHandler.Create(RuntimeHelpers.GetObjectValue(parent), RuntimeHelpers.GetObjectValue(configContext), section), System.Collections.Specialized.NameValueCollection)
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                ProjectData.ClearProjectError()
            End Try
            If (nameValueCollection IsNot Nothing) Then
                ApplicationConfiguration.fieldTracingEnabled = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.Tracing.Enabled", False)
                ApplicationConfiguration.fieldTracingTraceFile = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.Tracing.TraceFile", "ApplicationTrace.txt")
                ApplicationConfiguration.fieldTracingTraceLevel = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.Tracing.TraceLevel", DirectCast(4, TraceLevel))
                ApplicationConfiguration.fieldTracingSwitchName = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.Tracing.SwitchName", "ApplicationTraceSwitch")
                ApplicationConfiguration.fieldTracingSwitchDescription = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.Tracing.SwitchDescription", "Application error and tracing information")
                ApplicationConfiguration.fieldEventLogEnabled = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.EventLog.Enabled", True)
                ApplicationConfiguration.fieldEventLogMachineName = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.EventLog.Machine", ".")
                ApplicationConfiguration.fieldEventLogSourceName = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.EventLog.SourceName", "WDWApplication")
                ApplicationConfiguration.fieldEventLogTraceLevel = ApplicationConfiguration.ReadSetting(nameValueCollection, "SystemFramework.EventLog.LogLevel", DirectCast(1, TraceLevel))
            Else
                ApplicationConfiguration.fieldTracingEnabled = False
                ApplicationConfiguration.fieldTracingTraceFile = "ApplicationTrace.txt"
                ApplicationConfiguration.fieldTracingTraceLevel = 4
                ApplicationConfiguration.fieldTracingSwitchName = "ApplicationTraceSwitch"
                ApplicationConfiguration.fieldTracingSwitchDescription = "Application error and tracing information"
                ApplicationConfiguration.fieldEventLogEnabled = True
                ApplicationConfiguration.fieldEventLogMachineName = "."
                ApplicationConfiguration.fieldEventLogSourceName = "WDWApplication"
                ApplicationConfiguration.fieldEventLogTraceLevel = 1
            End If
            Return obj
        End Function

        Public Shared Sub OnApplicationStart(ByVal AppRoot As String)
            ApplicationConfiguration.fieldAppRoot = AppRoot
            ConfigurationSettings.GetConfig("ApplicationConfiguration")
            ConfigurationSettings.GetConfig("WDWConfiguration")
        End Sub

        Public Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As String) As String
            Dim str As String
            Try
                Dim item As Object = settings.Item(key)
                str = If(item IsNot Nothing, StringType.FromObject(item), defaultValue)
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                str = defaultValue
                ProjectData.ClearProjectError()
            End Try
            Return str
        End Function

        Public Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As Boolean) As Boolean
            Dim flag As Boolean
            Try
                Dim item As Object = settings.Item(key)
                flag = If(item IsNot Nothing, BooleanType.FromObject(item), defaultValue)
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                flag = defaultValue
                ProjectData.ClearProjectError()
            End Try
            Return flag
        End Function

        Public Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As Integer) As Integer
            Dim num As Integer
            Try
                Dim item As Object = settings.Item(key)
                num = If(item IsNot Nothing, IntegerType.FromObject(item), defaultValue)
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                num = defaultValue
                ProjectData.ClearProjectError()
            End Try
            Return num
        End Function

        Public Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As System.Diagnostics.TraceLevel) As System.Diagnostics.TraceLevel
            Dim traceLevel As System.Diagnostics.TraceLevel
            Try
                Dim item As Object = settings.Item(key)
                If (item IsNot Nothing) Then
                    traceLevel = IntegerType.FromObject(item)
                Else
                    traceLevel = defaultValue
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                traceLevel = defaultValue
                ProjectData.ClearProjectError()
            End Try
            Return traceLevel
        End Function

        Private Function IConfigurationSectionHandler_Create(parent As Object, configContext As Object, section As XmlNode) As Object Implements IConfigurationSectionHandler.Create
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace