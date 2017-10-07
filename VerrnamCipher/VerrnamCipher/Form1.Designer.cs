namespace VerrnamCipher
{
    partial class FormMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxEncryptText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEncryptKey = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEncryptOut = new System.Windows.Forms.RichTextBox();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.richTextBoxDecryptOut = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDecryptKey = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDecryptText = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonEncrypt);
            this.groupBox1.Controls.Add(this.richTextBoxEncryptOut);
            this.groupBox1.Controls.Add(this.richTextBoxEncryptKey);
            this.groupBox1.Controls.Add(this.richTextBoxEncryptText);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 391);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Шифрование";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.buttonDecrypt);
            this.groupBox2.Controls.Add(this.richTextBoxDecryptOut);
            this.groupBox2.Controls.Add(this.richTextBoxDecryptKey);
            this.groupBox2.Controls.Add(this.richTextBoxDecryptText);
            this.groupBox2.Location = new System.Drawing.Point(368, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 391);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дешифрование";
            // 
            // richTextBoxEncryptText
            // 
            this.richTextBoxEncryptText.Location = new System.Drawing.Point(6, 33);
            this.richTextBoxEncryptText.Name = "richTextBoxEncryptText";
            this.richTextBoxEncryptText.Size = new System.Drawing.Size(333, 96);
            this.richTextBoxEncryptText.TabIndex = 0;
            this.richTextBoxEncryptText.Text = "";
            // 
            // richTextBoxEncryptKey
            // 
            this.richTextBoxEncryptKey.Location = new System.Drawing.Point(6, 147);
            this.richTextBoxEncryptKey.Name = "richTextBoxEncryptKey";
            this.richTextBoxEncryptKey.Size = new System.Drawing.Size(333, 94);
            this.richTextBoxEncryptKey.TabIndex = 1;
            this.richTextBoxEncryptKey.Text = "";
            // 
            // richTextBoxEncryptOut
            // 
            this.richTextBoxEncryptOut.Location = new System.Drawing.Point(6, 260);
            this.richTextBoxEncryptOut.Name = "richTextBoxEncryptOut";
            this.richTextBoxEncryptOut.Size = new System.Drawing.Size(333, 96);
            this.richTextBoxEncryptOut.TabIndex = 2;
            this.richTextBoxEncryptOut.Text = "";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(122, 362);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(94, 23);
            this.buttonEncrypt.TabIndex = 3;
            this.buttonEncrypt.Text = "Зашифровать";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сообщение на шифрование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ключ (должен быть равен кол-ву символов в сообщение)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Зашифрованный текст";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Дешифрованный текст";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ключ (должен быть равен кол-ву символов в сообщение)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Зашифрованное сообщение";
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(131, 362);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(97, 23);
            this.buttonDecrypt.TabIndex = 11;
            this.buttonDecrypt.Text = "Расшифровать";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // richTextBoxDecryptOut
            // 
            this.richTextBoxDecryptOut.Location = new System.Drawing.Point(9, 260);
            this.richTextBoxDecryptOut.Name = "richTextBoxDecryptOut";
            this.richTextBoxDecryptOut.Size = new System.Drawing.Size(333, 96);
            this.richTextBoxDecryptOut.TabIndex = 10;
            this.richTextBoxDecryptOut.Text = "";
            // 
            // richTextBoxDecryptKey
            // 
            this.richTextBoxDecryptKey.Location = new System.Drawing.Point(9, 145);
            this.richTextBoxDecryptKey.Name = "richTextBoxDecryptKey";
            this.richTextBoxDecryptKey.Size = new System.Drawing.Size(333, 96);
            this.richTextBoxDecryptKey.TabIndex = 9;
            this.richTextBoxDecryptKey.Text = "";
            // 
            // richTextBoxDecryptText
            // 
            this.richTextBoxDecryptText.Location = new System.Drawing.Point(9, 32);
            this.richTextBoxDecryptText.Name = "richTextBoxDecryptText";
            this.richTextBoxDecryptText.Size = new System.Drawing.Size(333, 96);
            this.richTextBoxDecryptText.TabIndex = 8;
            this.richTextBoxDecryptText.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 396);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Шифр Вернама";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.RichTextBox richTextBoxEncryptOut;
        private System.Windows.Forms.RichTextBox richTextBoxEncryptKey;
        private System.Windows.Forms.RichTextBox richTextBoxEncryptText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.RichTextBox richTextBoxDecryptOut;
        private System.Windows.Forms.RichTextBox richTextBoxDecryptKey;
        private System.Windows.Forms.RichTextBox richTextBoxDecryptText;
    }
}

