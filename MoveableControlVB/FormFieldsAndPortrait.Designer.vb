<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFieldsAndPortrait
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
        Me.LabelHeader1 = New System.Windows.Forms.Label()
        Me.pictureBackgroundFront = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RadioEventHandlersHookedThruForm = New System.Windows.Forms.RadioButton()
        Me.RadioButtonEventHandlersByMonem = New System.Windows.Forms.RadioButton()
        Me.ButtonRefreshTheForm = New System.Windows.Forms.Button()
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelHeader1
        '
        Me.LabelHeader1.AutoSize = True
        Me.LabelHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader1.ForeColor = System.Drawing.Color.Gray
        Me.LabelHeader1.Location = New System.Drawing.Point(12, 9)
        Me.LabelHeader1.Name = "LabelHeader1"
        Me.LabelHeader1.Size = New System.Drawing.Size(1050, 54)
        Me.LabelHeader1.TabIndex = 1
        Me.LabelHeader1.Text = "Run the application to test the Elements && Portrait"
        Me.LabelHeader1.Visible = False
        '
        'pictureBackgroundFront
        '
        Me.pictureBackgroundFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBackgroundFront.Location = New System.Drawing.Point(41, 99)
        Me.pictureBackgroundFront.Name = "pictureBackgroundFront"
        Me.pictureBackgroundFront.Size = New System.Drawing.Size(673, 278)
        Me.pictureBackgroundFront.TabIndex = 2
        Me.pictureBackgroundFront.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(67, 422)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(393, 135)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'RadioEventHandlersHookedThruForm
        '
        Me.RadioEventHandlersHookedThruForm.AutoSize = True
        Me.RadioEventHandlersHookedThruForm.Checked = True
        Me.RadioEventHandlersHookedThruForm.Location = New System.Drawing.Point(90, 435)
        Me.RadioEventHandlersHookedThruForm.Name = "RadioEventHandlersHookedThruForm"
        Me.RadioEventHandlersHookedThruForm.Size = New System.Drawing.Size(291, 21)
        Me.RadioEventHandlersHookedThruForm.TabIndex = 4
        Me.RadioEventHandlersHookedThruForm.TabStop = True
        Me.RadioEventHandlersHookedThruForm.Text = "Event Handlers hooked Through the form"
        Me.RadioEventHandlersHookedThruForm.UseVisualStyleBackColor = True
        '
        'RadioButtonEventHandlersByMonem
        '
        Me.RadioButtonEventHandlersByMonem.AutoSize = True
        Me.RadioButtonEventHandlersByMonem.Location = New System.Drawing.Point(85, 470)
        Me.RadioButtonEventHandlersByMonem.Name = "RadioButtonEventHandlersByMonem"
        Me.RadioButtonEventHandlersByMonem.Size = New System.Drawing.Size(270, 21)
        Me.RadioButtonEventHandlersByMonem.TabIndex = 5
        Me.RadioButtonEventHandlersByMonem.TabStop = True
        Me.RadioButtonEventHandlersByMonem.Text = "Event Handlers Hooked Up by Monem"
        Me.RadioButtonEventHandlersByMonem.UseVisualStyleBackColor = True
        '
        'ButtonRefreshTheForm
        '
        Me.ButtonRefreshTheForm.Location = New System.Drawing.Point(166, 510)
        Me.ButtonRefreshTheForm.Name = "ButtonRefreshTheForm"
        Me.ButtonRefreshTheForm.Size = New System.Drawing.Size(214, 36)
        Me.ButtonRefreshTheForm.TabIndex = 6
        Me.ButtonRefreshTheForm.Text = "Refresh The Form"
        Me.ButtonRefreshTheForm.UseVisualStyleBackColor = True
        '
        'FormFieldsAndPortrait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 623)
        Me.Controls.Add(Me.ButtonRefreshTheForm)
        Me.Controls.Add(Me.RadioButtonEventHandlersByMonem)
        Me.Controls.Add(Me.RadioEventHandlersHookedThruForm)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pictureBackgroundFront)
        Me.Controls.Add(Me.LabelHeader1)
        Me.Name = "FormFieldsAndPortrait"
        Me.Text = "FormFieldsAndPortait"
        CType(Me.pictureBackgroundFront, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelHeader1 As Label
    Friend WithEvents pictureBackgroundFront As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RadioEventHandlersHookedThruForm As RadioButton
    Friend WithEvents RadioButtonEventHandlersByMonem As RadioButton
    Friend WithEvents ButtonRefreshTheForm As Button
End Class
