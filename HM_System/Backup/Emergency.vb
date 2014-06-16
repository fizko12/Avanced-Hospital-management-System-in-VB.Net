Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO

Public Class Emergency

    Private mImageFile As Image
    Private mImageFilePath As String
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            OpenFileDialog1.Filter = "Bmp files(*.bmp)|*.bmp|Gif files(*.gif)|*.gif | Jpg files(*.jpg)| *.jpg"
            OpenFileDialog1.ShowDialog()
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        mImageFilePath = OpenFileDialog1.FileName
        Dim fs As FileStream = New FileStream(mImageFilePath.ToString(), FileMode.Open, FileAccess.Read)
        Dim img As Byte() = New Byte(fs.Length) {}
        fs.Read(img, 0, fs.Length)
        fs.Close()
        mImageFile = Image.FromFile(mImageFilePath.ToString())

        Dim sv As String = "INSERT INTO emergency(pname,sex,cause,docref,photo) VALUES(@nm,@s,@c,@d,@pic)"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        Dim pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
        pic.Value = img
        cmd.Parameters.Add(pic)

        cmd.Parameters.Add(New SqlClient.SqlParameter("@nm", SqlDbType.Char)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@s", SqlDbType.NVarChar)).Value = Trim(ComboBox1.SelectedItem)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@c", SqlDbType.NVarChar)).Value = Trim(TextBox3.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@d", SqlDbType.Char, ComboBox2.Text.Length, ParameterDirection.Input)).Value = Trim(ComboBox2.Text)

        Try

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            MessageBox.Show("Query executed.")

        Catch ex As Exception

            MessageBox.Show(ex.Message.ToString(), "Data Error")

            Exit Sub

        End Try
    End Sub




    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        If Not (PictureBox1.Image Is Nothing) Then
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
        End If

    End Sub


    Private Sub Emergency_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HMDataSet.docdetails' table. You can move, or remove it, as needed.
        Me.DocdetailsTableAdapter.Fill(Me.HMDataSet.docdetails)
        TextBox1.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim con As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        comm.CommandText = "select * from emergency where id = '" & TextBox6.Text & "' or pname = '" & TextBox7.Text & "'"
        con.Open()
        comm.Connection = con
        adapter.SelectCommand = comm
        adapter.Fill(dataset, "emergency")
        Dim count As Integer = dataset.Tables("emergency").Rows.Count
        Dim dt As New DataTable

        If count > 0 Then
            dr = comm.ExecuteReader()

            While dr.Read()
                MessageBox.Show("Record Found")
                TextBox1.Text = dr.GetValue(0)
                TextBox2.Text = dr.GetValue(1)
                ComboBox1.Text = dr.GetValue(2)
                TextBox3.Text = dr.GetValue(3)
                ComboBox2.Text = dr.GetValue(4)
                Dim pic() As Byte = dataset.Tables("emergency").Rows(count - 1)("photo")
                Dim ms As New MemoryStream(pic)
                PictureBox1.Image = Image.FromStream(ms)

            End While
        Else
            MessageBox.Show("No record found,please enter the correct patient id.")
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "DELETE FROM emergency WHERE id = @no"
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "update emergency SET pname= @nm,sex=@s,cause=@c,docref=@d WHERE id = @id"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@id", SqlDbType.BigInt)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nm", SqlDbType.Char)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@c", SqlDbType.NVarChar)).Value = Trim(TextBox3.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@s", SqlDbType.Text)).Value = Trim(ComboBox1.SelectedItem)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@d", SqlDbType.Char, ComboBox2.Text.Length, ParameterDirection.Input)).Value = Trim(ComboBox2.Text)

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
End Class