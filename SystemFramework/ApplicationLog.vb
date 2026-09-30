Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System.Threading

Namespace SystemFramework
    Public Class ApplicationLog
        Private Shared debugSwitch As TraceSwitch

        Private Shared debugWriter As StreamWriter

        Private Shared eventLogTraceLevel As TraceLevel

        Shared Sub New()
            Dim type As System.Type = GetType(ApplicationLog)
            Try
                If (Monitor.TryEnter(type)) Then
                    Dim flag As Boolean = True
                    Try
                        If (ApplicationConfiguration.TracingEnabled) Then
                            Dim tracingTraceFile As String = ApplicationConfiguration.TracingTraceFile
                            If (Strings.Len(tracingTraceFile) <> 0) Then
                                Dim tracingSwitchName As String = ApplicationConfiguration.TracingSwitchName
                                If (Strings.Len(tracingSwitchName) <> 0) Then
                                    Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(tracingTraceFile)
                                    ApplicationLog.debugWriter = New StreamWriter(fileInfo.Open(6, 2, 3))
                                    Debug.Listeners().Add(New TextWriterTraceListener(ApplicationLog.debugWriter))
                                    fileInfo = Nothing
                                    ApplicationLog.debugSwitch = New TraceSwitch(tracingSwitchName, ApplicationConfiguration.TracingSwitchDescription)
                                    ApplicationLog.debugSwitch.Level = (ApplicationConfiguration.TracingTraceLevel)
                                End If
                                flag = False
                            End If
                        End If
                    Catch exception As System.Exception
                        ProjectData.SetProjectError(exception)
                        ProjectData.ClearProjectError()
                    End Try
                    If (flag) Then
                        ApplicationLog.debugSwitch = Nothing
                        ApplicationLog.debugWriter = Nothing
                    End If
                    If (Not ApplicationConfiguration.EventLogEnabled) Then
                        ApplicationLog.eventLogTraceLevel = 0
                    Else
                        ApplicationLog.eventLogTraceLevel = ApplicationConfiguration.EventLogTraceLevel
                    End If
                Else
                    Monitor.Enter(type)
                End If
            Finally
                Monitor.[Exit](type)
            End Try
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function FormatException(ByVal ex As Exception, Optional ByVal catchInfo As String = "") As String
            Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
            If (Strings.Len(catchInfo) <> 0) Then
                stringBuilder.Append(catchInfo).Append("" & vbCrLf & "")
            End If
            Dim str As String = stringBuilder.Append(ex.Message()).Append("" & vbCrLf & "").Append(ex.StackTrace()).ToString()
            stringBuilder = Nothing
            Return str
        End Function

        Public Shared Sub WriteError(ByVal message As String)
            ApplicationLog.WriteLog(1, message)
        End Sub

        Public Shared Sub WriteInfo(ByVal message As String)
            ApplicationLog.WriteLog(3, message)
        End Sub

        Private Shared Sub WriteLog(ByVal level As TraceLevel, ByVal messageText As String)
            Dim eventLogEntryType As System.Diagnostics.EventLogEntryType = New System.Diagnostics.EventLogEntryType()
            Try
                If (ApplicationLog.debugWriter IsNot Nothing AndAlso level <= ApplicationLog.debugSwitch.Level()) Then
                    Dim streamWriter As System.IO.StreamWriter = ApplicationLog.debugWriter
                    Monitor.Enter(streamWriter)
                    Try
                        ApplicationLog.debugWriter.Flush()
                    Finally
                        Monitor.[Exit](streamWriter)
                    End Try
                End If
                If (level <= ApplicationLog.eventLogTraceLevel) Then
                    Select Case level
                        Case 1
                            eventLogEntryType = 1
                            Exit Select
                        Case 2
                            eventLogEntryType = 2
                            Exit Select
                        Case 3
                            eventLogEntryType = 4
                            Exit Select
                        Case 4
                            eventLogEntryType = 8
                            Exit Select
                    End Select
                    Dim eventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog("Application", ApplicationConfiguration.EventLogMachineName, ApplicationConfiguration.EventLogSourceName)
                    eventLog.WriteEntry(messageText, eventLogEntryType)
                End If
            Catch exception As System.Exception
                ProjectData.SetProjectError(exception)
                ProjectData.ClearProjectError()
            End Try
        End Sub

        Public Shared Sub WriteTrace(ByVal message As String)
            ApplicationLog.WriteLog(4, message)
        End Sub

        Public Shared Sub WriteWarning(ByVal message As String)
            ApplicationLog.WriteLog(2, message)
        End Sub
    End Class
End Namespace