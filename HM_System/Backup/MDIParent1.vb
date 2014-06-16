Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim ChildForm As New Admission()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim ChildForm As New Emergency()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        Dim ChildForm As New Doctor()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        Dim ChildForm As New dept()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub


    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub


    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SAPI
        SAPI = CreateObject("sapi.spvoice")
        SAPI.speak("hello Admin")
        SAPI.Speak("welcome the new and advanced hospital management system")
        Timer1.Start()
        login.Hide()


    End Sub


    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Try
            If MessageBox.Show("Are you sure you want to exit the system", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                Exit Sub
            ElseIf (Windows.Forms.DialogResult.Yes) Then
                End
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Declare Function SetKeyboardState Lib "user32" (ByVal lppbKeyState As Byte) As Long
    Private Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Int32) As Int16

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel4.Text = Date.UtcNow
        If GetKeyState(System.Windows.Forms.Keys.CapsLock) = 1 Then
            ToolStripStatusLabel5.Enabled = True
        Else
            ToolStripStatusLabel5.Enabled = False
        End If
        If GetKeyState(System.Windows.Forms.Keys.Insert) = 1 Then
            ToolStripStatusLabel3.Enabled = True
        Else
            ToolStripStatusLabel3.Enabled = False
        End If
        If GetKeyState(System.Windows.Forms.Keys.NumLock) = 1 Then
            ToolStripStatusLabel6.Enabled = True
        Else
            ToolStripStatusLabel6.Enabled = False
        End If
    End Sub


    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Process.Start("C:\Program Files\CyberLink\YouCam\YouCam.exe")
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ChildForm As New Tests
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        Dim ChildForm As New Form3
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ChildForm As New Change_Password_Form()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim ChildForm As New Add_User_Form()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ChildForm As New Inventory()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Try
            If MessageBox.Show("Are you sure you want to exit the system", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                Exit Sub
            ElseIf (Windows.Forms.DialogResult.Yes) Then
                End
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AboutHMSystemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutHMSystemToolStripMenuItem.Click
        Dim ChildForm As New AboutBox1()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Dim ChildForm As New Reception()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub



    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim ChildForm As New alert()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim ChildForm As New chatserver()
        ChildForm.MdiParent = Me
        ChildForm.Show()

    End Sub


    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim ChildForm As New Emergency()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim ChildForm As New Doctor()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim ChildForm As New Password_By_Supervisor()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ChildForm As New Patient_Invoice()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim ChildForm As New Admission()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub UpdateAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateAccountToolStripMenuItem.Click
        Dim ChildForm As New Password_By_Supervisor()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

   
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim ChildForm As New chatclient()
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub
End Class
