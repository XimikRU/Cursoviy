namespace Rifma
{
    partial class Form1
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
            this.numericLetters = new System.Windows.Forms.NumericUpDown();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.checkBoxSyw = new System.Windows.Forms.CheckBox();
            this.checkBoxPril = new System.Windows.Forms.CheckBox();
            this.checkBoxGl = new System.Windows.Forms.CheckBox();
            this.checkBoxNa = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericLetters)).BeginInit();
            this.SuspendLayout();
            // 
            // numericLetters
            // 
            this.numericLetters.Location = new System.Drawing.Point(225, 12);
            this.numericLetters.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericLetters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericLetters.Name = "numericLetters";
            this.numericLetters.Size = new System.Drawing.Size(63, 20);
            this.numericLetters.TabIndex = 0;
            this.numericLetters.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 12);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(207, 20);
            this.textBoxInput.TabIndex = 1;
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(12, 64);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(383, 471);
            this.richTextBoxOutput.TabIndex = 2;
            this.richTextBoxOutput.Text = "";
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(294, 11);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(101, 22);
            this.buttonFind.TabIndex = 3;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // checkBoxSyw
            // 
            this.checkBoxSyw.AutoSize = true;
            this.checkBoxSyw.Checked = true;
            this.checkBoxSyw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSyw.Location = new System.Drawing.Point(12, 38);
            this.checkBoxSyw.Name = "checkBoxSyw";
            this.checkBoxSyw.Size = new System.Drawing.Size(119, 17);
            this.checkBoxSyw.TabIndex = 4;
            this.checkBoxSyw.Text = "Существительные";
            this.checkBoxSyw.UseVisualStyleBackColor = true;
            // 
            // checkBoxPril
            // 
            this.checkBoxPril.AutoSize = true;
            this.checkBoxPril.Checked = true;
            this.checkBoxPril.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPril.Location = new System.Drawing.Point(128, 38);
            this.checkBoxPril.Name = "checkBoxPril";
            this.checkBoxPril.Size = new System.Drawing.Size(112, 17);
            this.checkBoxPril.TabIndex = 5;
            this.checkBoxPril.Text = "Прилагательные";
            this.checkBoxPril.UseVisualStyleBackColor = true;
            // 
            // checkBoxGl
            // 
            this.checkBoxGl.AutoSize = true;
            this.checkBoxGl.Checked = true;
            this.checkBoxGl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGl.Location = new System.Drawing.Point(246, 38);
            this.checkBoxGl.Name = "checkBoxGl";
            this.checkBoxGl.Size = new System.Drawing.Size(69, 17);
            this.checkBoxGl.TabIndex = 6;
            this.checkBoxGl.Text = "Глаголы";
            this.checkBoxGl.UseVisualStyleBackColor = true;
            // 
            // checkBoxNa
            // 
            this.checkBoxNa.AutoSize = true;
            this.checkBoxNa.Checked = true;
            this.checkBoxNa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNa.Location = new System.Drawing.Point(321, 38);
            this.checkBoxNa.Name = "checkBoxNa";
            this.checkBoxNa.Size = new System.Drawing.Size(69, 17);
            this.checkBoxNa.TabIndex = 7;
            this.checkBoxNa.Text = "Наречия";
            this.checkBoxNa.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 556);
            this.Controls.Add(this.checkBoxNa);
            this.Controls.Add(this.checkBoxGl);
            this.Controls.Add(this.checkBoxPril);
            this.Controls.Add(this.checkBoxSyw);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.numericLetters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рифма";
            ((System.ComponentModel.ISupportInitialize)(this.numericLetters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericLetters;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.CheckBox checkBoxSyw;
        private System.Windows.Forms.CheckBox checkBoxPril;
        private System.Windows.Forms.CheckBox checkBoxGl;
        private System.Windows.Forms.CheckBox checkBoxNa;
    }
}

