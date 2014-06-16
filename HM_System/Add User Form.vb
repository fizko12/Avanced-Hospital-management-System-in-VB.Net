Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class Add_User_Form

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")

        If TextBox2.Text = TextBox3.Text Then

            Dim sv As String = "INSERT into logininfo(usrnm,pswd) VALUES(@nm,@pd)"
            Dim cmd As SqlCommand = New SqlCommand(sv, con)
            cmd.Parameters.Add(New SqlClient.SqlParameter("@nm", SqlDbType.NVarChar)).Value = Trim(TextBox1.Text)
            cmd.Parameters.Add(New SqlClient.SqlParameter("@pd", SqlDbType.NVarChar)).Value = Trim(TextBox3.Text)
            Try

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Record added successfully.")

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString(), "Data Error")

                Exit Sub

            End Try
        Else
            MessageBox.Show("please enter password correctly")
            TextBox2.Clear()
            TextBox3.Clear()
        End If
    End Sub
End Class