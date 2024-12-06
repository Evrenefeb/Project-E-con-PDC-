namespace Client {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn_Connect = new System.Windows.Forms.Button();
            this.tbx_AddressField = new System.Windows.Forms.TextBox();
            this.btn_UnmuteFF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(28, 72);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // tbx_AddressField
            // 
            this.tbx_AddressField.Location = new System.Drawing.Point(13, 32);
            this.tbx_AddressField.Name = "tbx_AddressField";
            this.tbx_AddressField.Size = new System.Drawing.Size(100, 20);
            this.tbx_AddressField.TabIndex = 1;
            // 
            // btn_UnmuteFF
            // 
            this.btn_UnmuteFF.Location = new System.Drawing.Point(28, 101);
            this.btn_UnmuteFF.Name = "btn_UnmuteFF";
            this.btn_UnmuteFF.Size = new System.Drawing.Size(75, 23);
            this.btn_UnmuteFF.TabIndex = 2;
            this.btn_UnmuteFF.Text = "Unmute";
            this.btn_UnmuteFF.UseVisualStyleBackColor = true;
            this.btn_UnmuteFF.Click += new System.EventHandler(this.btn_UnmuteFF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_UnmuteFF);
            this.Controls.Add(this.tbx_AddressField);
            this.Controls.Add(this.btn_Connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox tbx_AddressField;
        private System.Windows.Forms.Button btn_UnmuteFF;
    }
}

