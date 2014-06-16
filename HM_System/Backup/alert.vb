Imports System.Net.Mail
Public Class alert

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If String.IsNullOrEmpty(emailfrom.Text) Or String.IsNullOrEmpty(TextBox3.Text) Then
            MsgBox("username or password cannot be blank", Title:="Error")

        Else
            Dim mail As New MailMessage
            mail.From = New MailAddress(emailto.Text)
            mail.To.Add(emailto.Text)
            mail.Subject = subbox.Text
            mail.Body = bodybox.Text


            Dim SmtpServer As New SmtpClient()
            SmtpServer.Credentials = New Net.NetworkCredential(emailfrom.Text, TextBox3.Text)
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            SmtpServer.EnableSsl = True
            SmtpServer.Send(mail)

            MsgBox("mail sent", MsgBoxStyle.Information)

        End If


        'mail = New MailMessage()
        '    Dim addr() As String = emailto.Text.Split(",")
        '    Try
        '        mail.From = New MailAddress("ourhospital@gmail.com", "Web Developers", System.Text.Encoding.UTF8)

        '        Dim i As Byte
        '        For i = 0 To addr.Length - 1
        '            mail.To.Add(addr(i))
        '        Next
        '        mail.Subject = TextBox3.Text
        '        mail.Body = TextBox5.Text
        '        If ListBox1.Items.Count <> 0 Then
        '            For i = 0 To ListBox1.Items.Count - 1
        '                mail.Attachments.Add(New Attachment(ListBox1.Items.Item(i)))
        '            Next
        '        End If
        '        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        '        mail.ReplyTo = New MailAddress(emailto.Text)
        '        SmtpServer.Send(mail)
        '    Catch ex As Exception
        '        MsgBox(ex.ToString())
        '    End Try
        'End Sub

        'Private Sub Button2_Click(ByVal sender As System.Object, _
        '        ByVal e As System.EventArgs)
        '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '        ListBox1.Items.Add(OpenFileDialog1.FileName)
        '    End If
        'End Sub


    End Sub
End Class