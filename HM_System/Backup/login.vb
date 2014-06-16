Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class login

    
    Private Sub txtpswd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpswd.GotFocus
        Dim SAPI
        SAPI = CreateObject("sapi.spvoice")
        SAPI.speak("Enter Your Password")
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpswd.TextChanged
        Admin.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Admin.Click

        Dim con As New SqlConnection
        Dim comm As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dataset As New DataSet

        con.ConnectionString = "Data Source=SHIV-PC\SQLEXPRESS;Initial Catalog=HM;Integrated Security=True"

        comm.CommandText = "select * from logininfo where usrnm = '" & txtusr.Text & "' And pswd = '" & txtpswd.Text & "';"
        con.Open()
        comm.Connection = con
        adapter.SelectCommand = comm
        adapter.Fill(dataset, "0")
        Dim count = dataset.Tables(0).Rows.Count

        If count > 0 Then

            If txtusr.Text = "admin" Then
                MDIParent1.Show()
                Me.Hide()
                Me.Opacity = 0
                con.Close()
            Else
                MDIParent2.Show()
                Me.Hide()
                Me.Opacity = 0
                con.Close()
            End If

        Else
            MsgBox("login failed,please enter again", MsgBoxStyle.Critical)
            txtusr.Clear()
            txtpswd.Clear()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

   
    Private Sub txtusr_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtusr.MouseClick
        Dim SAPI
        SAPI = CreateObject("sapi.spvoice")
        SAPI.speak("Enter Your Username")
    End Sub

    Private Sub txtusr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtusr.TextChanged
        Admin.Enabled = True
    End Sub

    

    
End Class
