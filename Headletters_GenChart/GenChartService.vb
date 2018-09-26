Imports System.IO

Public Class GenChartService
    Dim timer As Timers.Timer
    Protected Overrides Sub OnStart(ByVal args() As String)
        System.Diagnostics.Debugger.Launch()
        timer = New Timers.Timer()
        timer.Interval = 60000
        AddHandler timer.Elapsed, AddressOf TriggerGenChart
        timer.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        timer.Enabled = False
    End Sub

    Private Sub TriggerGenChart(obj As Object, e As EventArgs)
        Try
            GenChart.Main()
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\inetpub\wwwroot\ServiceLogs\ErrorLog_{0}.txt", DateTime.Today.ToString("dd-MMM-yyyy"))
            File.AppendAllText(strFile, String.Format("Error Occured at-- {0}{1}{2}", DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        End Try
    End Sub

End Class
