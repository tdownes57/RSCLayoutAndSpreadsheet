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
        Me.ButtonNaive = New System.Windows.Forms.Button()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.TextBoxHelloWorld = New System.Windows.Forms.TextBox()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.ButtonImproved = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonNaive
        '
        Me.ButtonNaive.Location = New System.Drawing.Point(191, 285)
        Me.ButtonNaive.Name = "ButtonNaive"
        Me.ButtonNaive.Size = New System.Drawing.Size(227, 82)
        Me.ButtonNaive.TabIndex = 0
        Me.ButtonNaive.Text = "Open 2nd form (Naive)"
        Me.ButtonNaive.UseVisualStyleBackColor = True
        '
        'TextBoxHelloWorld
        '
        Me.TextBoxHelloWorld.Font = New System.Drawing.Font("Segoe UI", 90.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TextBoxHelloWorld.Location = New System.Drawing.Point(22, 100)
        Me.TextBoxHelloWorld.Name = "TextBoxHelloWorld"
        Me.TextBoxHelloWorld.Size = New System.Drawing.Size(667, 167)
        Me.TextBoxHelloWorld.TabIndex = 1
        Me.TextBoxHelloWorld.Text = "Hello World"
        '
        'LabelHeader
        '
        Me.LabelHeader.AutoSize = True
        Me.LabelHeader.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LabelHeader.Location = New System.Drawing.Point(12, 21)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(643, 51)
        Me.LabelHeader.TabIndex = 2
        Me.LabelHeader.Text = "Can controls be shared across forms?"
        '
        'ButtonImproved
        '
        Me.ButtonImproved.Location = New System.Drawing.Point(448, 285)
        Me.ButtonImproved.Name = "ButtonImproved"
        Me.ButtonImproved.Size = New System.Drawing.Size(227, 82)
        Me.ButtonImproved.TabIndex = 3
        Me.ButtonImproved.Text = "Open 2nd form (Improved)"
        Me.ButtonImproved.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 379)
        Me.Controls.Add(Me.ButtonImproved)
        Me.Controls.Add(Me.LabelHeader)
        Me.Controls.Add(Me.TextBoxHelloWorld)
        Me.Controls.Add(Me.ButtonNaive)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonNaive As Button
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents TextBoxHelloWorld As TextBox
    Friend WithEvents LabelHeader As Label
    Friend WithEvents ButtonImproved As Button
End Class
