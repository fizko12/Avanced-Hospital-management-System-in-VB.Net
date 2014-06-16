Imports System.Windows.Forms




Public Class MDIParent2

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)

        Dim ChildForm As New Admission()


        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim ChildForm As New Emergency()


        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1

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
        m_ChildFormNumber += 1
        ChildForm.Show()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        Dim ChildForm As New dept()
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Show()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub FileMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MDIParent2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SAPI
        Label3.Text = login.txtusr.Text
        SAPI = CreateObject("sapi.spvoice")
        SAPI.speak(Label4.Text)
        SAPI.speak(Label3.Text)
        SAPI.Speak("welcome to the new and advanced hospital management system")
        Timer1.Start()
        login.Hide()


    End Sub

    Private Sub WindowsMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub HelpMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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


    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub ToolStripStatusLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel3.Click

    End Sub

    Private Sub ToolStripStatusLabel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel5.Click

    End Sub

    Private Sub EditMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMenu.Click

    End Sub

    Private Sub ToolStripStatusLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel2.Click

    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Process.Start("C:\Program Files\CyberLink\YouCam\YouCam.exe")
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ChildForm As New Tests

        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1

        ChildForm.Show()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        Dim ChildForm As New Form3
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ChildForm As New Change_Password_Form()

        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1

        ChildForm.Show()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ChildForm As New Add_User_Form()

        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1

        ChildForm.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New Inventory()

        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1

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

        m_ChildFormNumber += 1

        ChildForm.Show()
    End Sub

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub StatusStrip1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles StatusStrip1.KeyPress

    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim ChildForm As New alert()
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Show()
    End Sub

    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim ChildForm As New chatclient()
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Show()

    End Sub


    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim ChildForm As New Doctor()
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Show()

    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim ChildForm As New Admission()
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Show()
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim ChildForm As New Change_Password_Form()
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Show()
    End Sub
End Class
