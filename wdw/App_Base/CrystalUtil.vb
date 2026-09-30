Imports Common
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportAppServer.ReportDefModel
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Web


Namespace wdw
    Public Class CrystalUtil
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Sub CrystalReportFormatter(ByRef ReportViewer As Global.CrystalDecisions.Web.CrystalReportViewer)

            ReportViewer.DisplayToolbar = True
            ReportViewer.HasToggleGroupTreeButton = False
            ReportViewer.HasDrilldownTabs = False
            ReportViewer.ToolPanelView = ToolPanelViewType.None
            ReportViewer.Visible = True
            ReportViewer.HasCrystalLogo = False
            ReportViewer.SeparatePages = False

        End Sub

        Public Sub ChangeDataSource(ByVal crReportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument)
            Dim current As Table = Nothing
            Dim enumerator As IEnumerator = Nothing
            Dim connectionInfo As CrystalDecisions.[Shared].ConnectionInfo = New CrystalDecisions.[Shared].ConnectionInfo()
            Me.SetConnection(connectionInfo)
            Dim tables As CrystalDecisions.CrystalReports.Engine.Tables = crReportDocument.Database().Tables()
            Try
                enumerator = tables.GetEnumerator()
                While enumerator.MoveNext()
                    current = DirectCast(enumerator.Current(), Table)
                    Dim logOnInfo As TableLogOnInfo = current.LogOnInfo()
                    logOnInfo.ConnectionInfo = (connectionInfo)
                    current.ApplyLogOnInfo(logOnInfo)
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            current.Location = (current.Location().Substring(current.Location().LastIndexOf(".") + 1))
        End Sub

        Private Sub SetConnection(ByVal crConnectionInfo As CrystalDecisions.[Shared].ConnectionInfo)
            Dim connectionInfo As CrystalDecisions.[Shared].ConnectionInfo = crConnectionInfo
            connectionInfo.DatabaseName = (WDWConfiguration.ConnectionDatabase)
            connectionInfo.ServerName = (WDWConfiguration.ConnectionServer)
            connectionInfo.Password = (WDWConfiguration.ConnectionPassword)
            connectionInfo.UserID = (WDWConfiguration.ConnectionUserID)
            connectionInfo = Nothing
        End Sub
    End Class
End Namespace