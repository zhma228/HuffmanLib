namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Loadbutton1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Savebutton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Loadbutton1
            // 
            this.Loadbutton1.Location = new System.Drawing.Point(12, 12);
            this.Loadbutton1.Name = "Loadbutton1";
            this.Loadbutton1.Size = new System.Drawing.Size(75, 23);
            this.Loadbutton1.TabIndex = 0;
            this.Loadbutton1.Text = "Load";
            this.Loadbutton1.UseVisualStyleBackColor = true;
            this.Loadbutton1.Click += new System.EventHandler(this.Loadbutton1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(439, 328);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // Savebutton1
            // 
            this.Savebutton1.Location = new System.Drawing.Point(102, 12);
            this.Savebutton1.Name = "Savebutton1";
            this.Savebutton1.Size = new System.Drawing.Size(75, 23);
            this.Savebutton1.TabIndex = 2;
            this.Savebutton1.Text = "Save";
            this.Savebutton1.UseVisualStyleBackColor = true;
            this.Savebutton1.Click += new System.EventHandler(this.Savebutton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Savebutton1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Loadbutton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Loadbutton1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Savebutton1;
    }
}

