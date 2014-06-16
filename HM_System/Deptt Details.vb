Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class dept



    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")

        Dim sv As String = "INSERT INTO deptdetails(deptcode,deptname,deptdetails) VALUES(@no, @nme, @dt)"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@no", SqlDbType.BigInt)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nme", SqlDbType.NVarChar)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@dt", SqlDbType.NVarChar)).Value = Trim(TextBox3.Text)


        Try

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("one record successfully added.")

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Data Error")
            Exit Sub

        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        comm.CommandText = "select * from deptdetails where deptcode = '" & TextBox4.Text & "';"
        con.Open()
        comm.Connection = con
        adapter.SelectCommand = comm
        adapter.Fill(dataset, "0")
        Dim count = dataset.Tables(0).Rows.Count

        If count > 0 Then
            dr = comm.ExecuteReader()
            While dr.Read()
                MessageBox.Show("ok")
                TextBox1.Text = dr.GetValue(0)
                TextBox2.Text = dr.GetValue(1)
                TextBox3.Text = dr.GetValue(2)

            End While
        Else
            MessageBox.Show("No record found,please enter the correct Department code.")
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "UPDATE deptdetails SET deptcode = @no,deptname = @nme, deptdetails=@dep WHERE deptcode = @no"

        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@no", SqlDbType.BigInt)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nme", SqlDbType.NVarChar)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@dep", SqlDbType.NVarChar)).Value = Trim(TextBox3.Text)

        Try

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Record updated successfully.")

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Data Error")

            Exit Sub

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "DELETE FROM deptdetails WHERE deptcode = @no"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@no", SqlDbType.BigInt)).Value = Trim(TextBox1.Text)

        Try

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Record DELETED successfully.")

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Data Error")
            Exit Sub

        End Try
    End Sub
End Class