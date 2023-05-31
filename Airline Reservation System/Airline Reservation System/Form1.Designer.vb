<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TextBox3 = New TextBox()
        Label4 = New Label()
        TextBox4 = New TextBox()
        Panel1 = New Panel()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(37, 67)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(125, 27)
        TextBox1.TabIndex = 0
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(37, 113)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(125, 27)
        TextBox2.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(31, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(149, 28)
        Label1.TabIndex = 2
        Label1.Text = "Reserve a seat"' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(182, 67)
        Label2.Name = "Label2"
        Label2.Size = New Size(49, 20)
        Label2.TabIndex = 3
        Label2.Text = "Name"' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(182, 113)
        Label3.Name = "Label3"
        Label3.Size = New Size(67, 20)
        Label3.TabIndex = 4
        Label3.Text = "Surname"' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(1191, -84)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(125, 27)
        TextBox3.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(37, 190)
        Label4.Name = "Label4"
        Label4.Size = New Size(85, 20)
        Label4.TabIndex = 7
        Label4.Text = "Testing box"' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(37, 232)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(300, 27)
        TextBox4.TabIndex = 8
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(TextBox4)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(864, 52)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(365, 333)
        Panel1.TabIndex = 9
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(1232, 878)
        Controls.Add(Panel1)
        Controls.Add(TextBox3)
        Name = "Form1"
        Text = "Form1"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Panel1 As Panel
End Class
