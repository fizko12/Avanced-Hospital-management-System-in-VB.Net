Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Form3

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "INSERT INTO wdetails(wno,wname,tbeds,bedleft) VALUES(@no, @nme, @tbed, @bedl)"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@no", SqlDbType.BigInt)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nme", SqlDbType.NVarChar)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@tbed", SqlDbType.BigInt)).Value = Trim(TextBox3.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@bedl", SqlDbType.NVarChar)).Value = Trim(TextBox4.Text)
        
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
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")

        Dim sv As String = "UPDATE wdetails SET wno = @no,wname = @nme, tbeds = @tbed , bedleft=@bedl WHERE wno = @no"

        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@no", SqlDbType.BigInt)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nme", SqlDbType.NVarChar)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@tbed", SqlDbType.BigInt)).Value = Trim(TextBox3.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@bedl", SqlDbType.NVarChar)).Value = Trim(TextBox4.Text)

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

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "DELETE FROM wdetails WHERE wno = @no"
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

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WdetailsTableAdapter.Fill(Me.HMDataSet.wdetails)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim con As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        comm.CommandText = "select * from wdetails where wno = '" & TextBox5.Text & "';"
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
                TextBox4.Text = dr.GetValue(3)
            End While
        Else
            MessageBox.Show("No record found,please enter the correct ward id.")
        End If
    End Sub

   End Class