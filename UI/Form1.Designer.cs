namespace UI
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
            this.PAN_Cyphers = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BTN_DecryptAll = new System.Windows.Forms.Button();
            this.BTN_DecypherAll = new System.Windows.Forms.Button();
            this.LBL_CypherText = new System.Windows.Forms.Label();
            this.LBL_Key = new System.Windows.Forms.Label();
            this.LBL_Key2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PAN_Cyphers
            // 
            this.PAN_Cyphers.AutoScroll = true;
            this.PAN_Cyphers.Location = new System.Drawing.Point(12, 68);
            this.PAN_Cyphers.Name = "PAN_Cyphers";
            this.PAN_Cyphers.Size = new System.Drawing.Size(776, 370);
            this.PAN_Cyphers.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(535, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 47);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 6);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(370, 53);
            this.textBox2.TabIndex = 5;
            // 
            // BTN_DecryptAll
            // 
            this.BTN_DecryptAll.Location = new System.Drawing.Point(713, 9);
            this.BTN_DecryptAll.Name = "BTN_DecryptAll";
            this.BTN_DecryptAll.Size = new System.Drawing.Size(75, 23);
            this.BTN_DecryptAll.TabIndex = 6;
            this.BTN_DecryptAll.Text = "Decrypt All";
            this.BTN_DecryptAll.UseVisualStyleBackColor = true;
            // 
            // BTN_DecypherAll
            // 
            this.BTN_DecypherAll.Location = new System.Drawing.Point(713, 39);
            this.BTN_DecypherAll.Name = "BTN_DecypherAll";
            this.BTN_DecypherAll.Size = new System.Drawing.Size(75, 23);
            this.BTN_DecypherAll.TabIndex = 7;
            this.BTN_DecypherAll.Text = "Decypher All";
            this.BTN_DecypherAll.UseVisualStyleBackColor = true;
            // 
            // LBL_CypherText
            // 
            this.LBL_CypherText.AutoSize = true;
            this.LBL_CypherText.Location = new System.Drawing.Point(12, 9);
            this.LBL_CypherText.Name = "LBL_CypherText";
            this.LBL_CypherText.Size = new System.Drawing.Size(64, 13);
            this.LBL_CypherText.TabIndex = 8;
            this.LBL_CypherText.Text = "Cypher Text";
            // 
            // LBL_Key
            // 
            this.LBL_Key.AutoSize = true;
            this.LBL_Key.Location = new System.Drawing.Point(468, 12);
            this.LBL_Key.Name = "LBL_Key";
            this.LBL_Key.Size = new System.Drawing.Size(25, 13);
            this.LBL_Key.TabIndex = 9;
            this.LBL_Key.Text = "Key";
            // 
            // LBL_Key2
            // 
            this.LBL_Key2.AutoSize = true;
            this.LBL_Key2.Location = new System.Drawing.Point(458, 25);
            this.LBL_Key2.Name = "LBL_Key2";
            this.LBL_Key2.Size = new System.Drawing.Size(77, 13);
            this.LBL_Key2.TabIndex = 10;
            this.LBL_Key2.Text = "(For Decypher)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LBL_Key2);
            this.Controls.Add(this.LBL_Key);
            this.Controls.Add(this.LBL_CypherText);
            this.Controls.Add(this.BTN_DecypherAll);
            this.Controls.Add(this.BTN_DecryptAll);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PAN_Cyphers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Cryptorophy solver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PAN_Cyphers;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BTN_DecryptAll;
        private System.Windows.Forms.Button BTN_DecypherAll;
        private System.Windows.Forms.Label LBL_CypherText;
        private System.Windows.Forms.Label LBL_Key;
        private System.Windows.Forms.Label LBL_Key2;
    }
}

