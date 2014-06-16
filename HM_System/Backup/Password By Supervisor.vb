Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Password_By_Supervisor

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim con As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        comm.CommandText = "select * from logininfo where usrnm = '" & TextBox4.Text & "';"
        con.Open()
        comm.Connection = con
        adapter.SelectCommand = comm
        adapter.Fill(dataset, "0")
        Dim count = dataset.Tables(0).Rows.Count

        If count > 0 Then
            dr = comm.ExecuteReader()
            While dr.Read()
                MessageBox.Show("ok")
                TextBox1.Text = dr.GetValue(1)
                TextBox2.Text = dr.GetValue(2)
            End While
        Else
            MessageBox.Show("No record found,please enter the correct username.")
        End If
    End Sub

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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")

        If TextBox2.Text = TextBox3.Text Then

            Dim sv As String = "DELETE * from logininfo WHERE usrnm = '" & TextBox1.Text & "'"
            Dim cmd As SqlCommand = New SqlCommand(sv, con)

            Try

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Record deleted successfully.")

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