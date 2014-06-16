Public Class OPD

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Admission.Show()
            Me.Hide()
        ElseIf RadioButton2.Checked = True Then
            Patient_Invoice.Show()
            Me.Hide()
        End If
    End Sub

End Class