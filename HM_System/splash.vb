Public Class splash

    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(2)
        Label2.Text = ProgressBar1.Value
        If ProgressBar1.Value = 100 Then
            Me.Hide()
            login.Show()
        End If
    End Sub
End Class