Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Doctor
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
   

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        ComboBox1.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        comm.CommandText = "select * from docdetails where docid = '" & TextBox9.Text & "';"
        con.Open()
        comm.Connection = con
        adapter.SelectCommand = comm
        adapter.Fill(dataset, "0")
        Dim count = dataset.Tables(0).Rows.Count

        If count > 0 Then
            dr = comm.ExecuteReader()
            While dr.Read()
                MessageBox.Show("Record Found")
                TextBox1.Text = dr.GetValue(0)
                TextBox2.Text = dr.GetValue(1)
                TextBox3.Text = dr.GetValue(2)
                ComboBox1.Text = dr.GetValue(3)
                TextBox4.Text = dr.GetValue(4)
                TextBox5.Text = dr.GetValue(5)
                TextBox6.Text = dr.GetValue(6)
                TextBox7.Text = dr.GetValue(7)
                TextBox8.Text = dr.GetValue(8)


            End While
        Else
            MessageBox.Show("No record found,please enter the correct Doctor id.")
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")

        Dim sv As String = "INSERT INTO docdetails(docid,docname,deptname,sex,age,qual,phno,mobno,docadd) VALUES(@id, @nme,@d,@s, @a,@q,@ph,@mo,@add)"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@id", SqlDbType.Int)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nme", SqlDbType.NVarChar)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@d", SqlDbType.NVarChar)).Value = Trim(TextBox3.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@s", SqlDbType.Text)).Value = Trim(ComboBox1.SelectedItem)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@a", SqlDbType.BigInt)).Value = Trim(TextBox4.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@q", SqlDbType.NVarChar)).Value = Trim(TextBox5.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@ph", SqlDbType.BigInt)).Value = Trim(TextBox6.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@mo", SqlDbType.BigInt)).Value = Trim(TextBox7.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@add", SqlDbType.NVarChar)).Value = Trim(TextBox8.Text)

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

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "UPDATE  docdetails SET docid = @id,docname= @nme, deptname = @d , sex=@s,age=@a,qual=@q,phno=@ph,mobno=@mo,docadd=@add WHERE docid = @id"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@id", SqlDbType.Int)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nme", SqlDbType.NVarChar)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@d", SqlDbType.NVarChar)).Value = Trim(TextBox3.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@s", SqlDbType.Text)).Value = Trim(ComboBox1.SelectedItem)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@a", SqlDbType.BigInt)).Value = Trim(TextBox4.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@q", SqlDbType.NVarChar)).Value = Trim(TextBox5.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@ph", SqlDbType.BigInt)).Value = Trim(TextBox6.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@mo", SqlDbType.BigInt)).Value = Trim(TextBox7.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@add", SqlDbType.NVarChar)).Value = Trim(TextBox8.Text)

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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "DELETE FROM docdetails WHERE docid = @no"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@no", SqlDbType.Int)).Value = Trim(TextBox1.Text)

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