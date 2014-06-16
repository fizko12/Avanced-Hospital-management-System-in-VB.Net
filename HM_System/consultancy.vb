Public Class consultancy

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If MessageBox.Show("Please save the record before generating invoice.Do you still want to continue", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                MessageBox.Show("then please save the record.")
            ElseIf (Windows.Forms.DialogResult.Yes) Then
                Patient_Invoice.Show()
                Me.Hide()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub consultancy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox1.Text = Admission.TextBox1.Text
    End Sub
End Class