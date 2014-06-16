Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Bed_Allocation
    Dim con As SqlConnection
    Dim connectionString As String
    Dim sql As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "INSERT INTO bedallocation(pid,pname,wname,bedn) VALUES(@id, @nm, @wn, @bedn)"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@id", SqlDbType.Int)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nm", SqlDbType.NVarChar)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@wn", SqlDbType.Char, ComboBox1.Text.Length, ParameterDirection.Input)).Value = Trim(ComboBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@bedn", SqlDbType.Int)).Value = Trim(TextBox3.Text)


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
End Class