<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class alert
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pswdbox = New System.Windows.Forms.Label
        Me.emailto = New System.Windows.Forms.TextBox
        Me.emailfrom = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.bodybox = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label4 = New System.Windows.Forms.Label
        Me.subbox = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "From"
        '
        'pswdbox
        '
        Me.pswdbox.AutoSize = True
        Me.pswdbox.Location = New System.Drawing.Point(22, 106)
        Me.pswdbox.Name = "pswdbox"
        Me.pswdbox.Size = New System.Drawing.Size(52, 13)
        Me.pswdbox.TabIndex = 2
        Me.pswdbox.Text = "password"
        '
        'emailto
        '
        Me.emailto.Location = New System.Drawing.Point(111, 24)
        Me.emailto.Name = "emailto"
        Me.emailto.Size = New System.Drawing.Size(297, 20)
        Me.emailto.TabIndex = 4
        '
        'emailfrom
        '
        Me.emailfrom.Location = New System.Drawing.Point(111, 64)
        Me.emailfrom.Name = "emailfrom"
        Me.emailfrom.Size = New System.Drawing.Size(297, 20)
        Me.emailfrom.TabIndex = 5
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(112, 101)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.TextBox3.Size = New System.Drawing.Size(297, 20)
        Me.TextBox3.TabIndex = 6
        '
        'bodybox
        '
        Me.bodybox.Location = New System.Drawing.Point(61, 201)
        Me.bodybox.Multiline = True
        Me.bodybox.Name = "bodybox"
        Me.bodybox.Size = New System.Drawing.Size(396, 155)
        Me.bodybox.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(187, 374)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 37)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Send"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Subject"
        '
        'subbox
        '
        Me.subbox.Location = New System.Drawing.Point(111, 148)
        Me.subbox.Name = "subbox"
        Me.subbox.Size = New System.Drawing.Size(297, 20)
        Me.subbox.TabIndex = 11
        '
        'alert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(553, 439)
        Me.Controls.Add(Me.subbox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bodybox)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.emailfrom)
        Me.Controls.Add(Me.emailto)
        Me.Controls.Add(Me.pswdbox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "alert"
        Me.Text = "alert"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pswdbox As System.Windows.Forms.Label
    Friend WithEvents emailto As System.Windows.Forms.TextBox
    Friend WithEvents emailfrom As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents bodybox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents subbox As System.Windows.Forms.TextBox
End Class
