Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.SqlTypes
Imports System.Drawing.Imaging
Public Class Admission
    Private mImageFile As Image
    Private mImageFilePath As String
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            OpenFileDialog1.Filter = "Bmp files(*.bmp)|*.bmp|Gif files(*.gif)|*.gif | Jpg files(*.jpg)| *.jpg"
            OpenFileDialog1.ShowDialog()
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            OpenFileDialog1.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

        End Try



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        mImageFilePath = OpenFileDialog1.FileName
        Dim fs As FileStream = New FileStream(mImageFilePath.ToString(), FileMode.Open, FileAccess.Read)
        Dim img As Byte() = New Byte(fs.Length) {}
        fs.Read(img, 0, fs.Length)
        fs.Close()
        mImageFile = Image.FromFile(mImageFilePath.ToString())

        Dim sv As String = "INSERT INTO admission(name,age,sex,fee,address,department,doctor,photo) VALUES(@nm, @age,@s, @f, @addr, @dept,@doc,@pic)"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        Dim pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
        pic.Value = img
        cmd.Parameters.Add(pic)

        cmd.Parameters.Add(New SqlClient.SqlParameter("@nm", SqlDbType.Char)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@age", SqlDbType.Int)).Value = Trim(TextBox3.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@s", SqlDbType.NVarChar)).Value = Trim(ComboBox1.SelectedItem)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@f", SqlDbType.Int)).Value = Trim(TextBox4.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@addr", SqlDbType.NVarChar)).Value = Trim(TextBox5.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@dept", SqlDbType.Char, ComboBox2.Text.Length, ParameterDirection.Input)).Value = Trim(ComboBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@doc", SqlDbType.Char, ComboBox3.Text.Length, ParameterDirection.Input)).Value = Trim(ComboBox3.Text)

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



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "update admission SET name= @nm,age=@a,sex=@s,fee=@f,address=@ad,department=@de,doctor=@do WHERE id = @id"
        Dim cmd As SqlCommand = New SqlCommand(sv, con)
        
        cmd.Parameters.Add(New SqlClient.SqlParameter("@id", SqlDbType.BigInt)).Value = Trim(TextBox1.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@nm", SqlDbType.Char)).Value = Trim(TextBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@a", SqlDbType.Int)).Value = Trim(TextBox3.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@s", SqlDbType.NVarChar)).Value = Trim(ComboBox1.SelectedItem)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@f", SqlDbType.Int)).Value = Trim(TextBox4.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@ad", SqlDbType.NVarChar)).Value = Trim(TextBox5.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@de", SqlDbType.Char, ComboBox2.Text.Length, ParameterDirection.Input)).Value = Trim(ComboBox2.Text)
        cmd.Parameters.Add(New SqlClient.SqlParameter("@do", SqlDbType.Char, ComboBox3.Text.Length, ParameterDirection.Input)).Value = Trim(ComboBox3.Text)
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

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        If Not (PictureBox1.Image Is Nothing) Then
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
        End If

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim con As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        comm.CommandText = "select * from admission where id = '" & TextBox6.Text & "' or name = '" & TextBox7.Text & "'"
        con.Open()
        comm.Connection = con
        adapter.SelectCommand = comm
        adapter.Fill(dataset, "admission")
        Dim count As Integer = dataset.Tables("admission").Rows.Count
        Dim dt As New DataTable

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
                ComboBox2.Text = dr.GetValue(6)
                ComboBox3.Text = dr.GetValue(7)
                Dim pic() As Byte = dataset.Tables("admission").Rows(count - 1)("photo")
                Dim ms As New MemoryStream(pic)
                PictureBox1.Image = Image.FromStream(ms)

            End While
        Else
            MessageBox.Show("No record found,please enter the correct patient id.")
        End If


    End Sub


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter
        TextBox1.Enabled = False
        'Dim con As New SqlConnection
        'Dim comm As New SqlCommand
        'Dim adapter As New SqlDataAdapter
        'Dim dataset As New DataSet
        'Dim dr As SqlDataReader

        'con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        'comm.CommandText = "select * from admission"
        'con.Open()
        'comm.Connection = con
        'adapter.SelectCommand = comm
        'adapter.Fill(dataset, "admission")
        'Dim count As Integer = dataset.Tables("admission").Rows.Count
        'Dim dt As New DataTable

        'If count > 0 Then
        '    dr = comm.ExecuteReader()

        '    While dr.NextResult
        '        TextBox1.Text = dr.GetValue(0)

        '    End While
        'End If
    End Sub

    Private Sub Admission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HMDataSet.deptdetails' table. You can move, or remove it, as needed.
        Me.DeptdetailsTableAdapter.Fill(Me.HMDataSet.deptdetails)
        'TODO: This line of code loads data into the 'HMDataSet.docdetails' table. You can move, or remove it, as needed.
        Me.DocdetailsTableAdapter.Fill(Me.HMDataSet.docdetails)

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim con = New SqlConnection("Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True")
        Dim sv As String = "DELETE FROM admission WHERE id = @no"
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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim con As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dataset As New DataSet
        Dim dr As SqlDataReader

        con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        comm.CommandText = "select * from emergency where id = '" & TextBox8.Text & "' or pname = '" & TextBox9.Text & "'"
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
                ComboBox3.Text = dr.GetValue(4)
                Dim pic() As Byte = dataset.Tables("emergency").Rows(count - 1)("photo")
                Dim ms As New MemoryStream(pic)
                PictureBox1.Image = Image.FromStream(ms)

            End While
        Else
            MessageBox.Show("No record found,please enter the correct patient id.")
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Patient_Invoice.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        consultancy.Show()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Bed_Allocation.Show()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

    End Sub
End Class