Public Class Reception

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start("C:\WINDOWS\System32\notepad.exe")
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Application.Exit()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Process.Start("C:\WINDOWS\System32\calc.exe")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Process.Start("C:\Program Files\Microsoft Office\Office12\winword.exe")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Process.Start("C:\Program Files\Microsoft Office\Office12\excel.exe")
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If RadioButton1.Checked = True Then
            OPD.Show()
            Me.Hide()
        ElseIf RadioButton2.Checked = True Then
            IPD.Show()
            Me.Hide()
        End If
    End Sub


End Class