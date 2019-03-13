namespace ArkaServices
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
            this.btnRecive = new System.Windows.Forms.Button();
            this.richtxtRecive = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnRecive
            // 
            this.btnRecive.Location = new System.Drawing.Point(61, 40);
            this.btnRecive.Name = "btnRecive";
            this.btnRecive.Size = new System.Drawing.Size(115, 64);
            this.btnRecive.TabIndex = 0;
            this.btnRecive.Text = "Start";
            this.btnRecive.UseVisualStyleBackColor = true;
            this.btnRecive.Click += new System.EventHandler(this.btnRecive_Click);
            // 
            // richtxtRecive
            // 
            this.richtxtRecive.Location = new System.Drawing.Point(212, 29);
            this.richtxtRecive.Name = "richtxtRecive";
            this.richtxtRecive.Size = new System.Drawing.Size(523, 373);
            this.richtxtRecive.TabIndex = 1;
            this.richtxtRecive.Text = "";
            this.richtxtRecive.TextChanged += new System.EventHandler(this.richtxtRecive_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richtxtRecive);
            this.Controls.Add(this.btnRecive);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRecive;
        private System.Windows.Forms.RichTextBox richtxtRecive;
    }
}

