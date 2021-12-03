
namespace MoveAndResizeControls_Monem
{
    partial class FormContainerVsPicture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContainerVsPicture));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonContainer = new System.Windows.Forms.Button();
            this.buttonControl = new System.Windows.Forms.Button();
            this.labelHeading1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 90);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(671, 189);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonContainer
            // 
            this.buttonContainer.Location = new System.Drawing.Point(48, 301);
            this.buttonContainer.Name = "buttonContainer";
            this.buttonContainer.Size = new System.Drawing.Size(396, 43);
            this.buttonContainer.TabIndex = 1;
            this.buttonContainer.Text = "Element Container   ( => MoveControl(par_container, e) )";
            this.buttonContainer.UseVisualStyleBackColor = true;
            this.buttonContainer.Click += new System.EventHandler(this.buttonContainer_Click);
            // 
            // buttonControl
            // 
            this.buttonControl.Location = new System.Drawing.Point(48, 361);
            this.buttonControl.Name = "buttonControl";
            this.buttonControl.Size = new System.Drawing.Size(396, 40);
            this.buttonControl.TabIndex = 2;
            this.buttonControl.Text = "Picture Control  (=> MoveControl(par_control, e) )";
            this.buttonControl.UseVisualStyleBackColor = true;
            this.buttonControl.Click += new System.EventHandler(this.buttonControl_Click);
            // 
            // labelHeading1
            // 
            this.labelHeading1.AutoSize = true;
            this.labelHeading1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeading1.Location = new System.Drawing.Point(27, 19);
            this.labelHeading1.Name = "labelHeading1";
            this.labelHeading1.Size = new System.Drawing.Size(472, 36);
            this.labelHeading1.TabIndex = 3;
            this.labelHeading1.Text = "Hooking up the MouseMove Event";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(450, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Works well";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(450, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "Can\'t move QR nor Signature";
            // 
            // FormContainerVsPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 444);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHeading1);
            this.Controls.Add(this.buttonControl);
            this.Controls.Add(this.buttonContainer);
            this.Controls.Add(this.textBox1);
            this.Name = "FormContainerVsPicture";
            this.Text = "FormContainerVsPicture";
            this.Load += new System.EventHandler(this.FormContainerVsPicture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonContainer;
        private System.Windows.Forms.Button buttonControl;
        private System.Windows.Forms.Label labelHeading1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}