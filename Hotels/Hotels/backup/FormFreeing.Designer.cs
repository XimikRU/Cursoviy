namespace Hotels
{
    partial class FormFreeing
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
            this.buttonFree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFree
            // 
            this.buttonFree.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonFree.Location = new System.Drawing.Point(31, 12);
            this.buttonFree.Name = "buttonFree";
            this.buttonFree.Size = new System.Drawing.Size(75, 23);
            this.buttonFree.TabIndex = 0;
            this.buttonFree.Text = "Free";
            this.buttonFree.UseVisualStyleBackColor = true;
            // 
            // FormFreeing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(137, 47);
            this.Controls.Add(this.buttonFree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFreeing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Free this room?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFree;
    }
}