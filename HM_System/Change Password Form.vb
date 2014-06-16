Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Change_Password_Form

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")

        If TextBox2.Text = TextBox3.Text Then

            Dim sv As String = "UPDATE logininfo SET pswd = @pd WHERE usrnm = '" & TextBox1.Text & "'"
            Dim cmd As SqlCommand = New SqlCommand(sv, con)
            cmd.Parameters.Add(New SqlClient.SqlParameter("@pd", SqlDbType.NVarChar)).Value = Trim(TextBox3.Text)
            Try

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Record updated successfully.")

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Data Error")

                Exit Sub

            End Try
            MessageBox.Show("password changed successfully")
        Else
            MessageBox.Show("please enter password correctly")
            TextBox2.Clear()
            TextBox3.Clear()
        End If
    End Sub
End Class