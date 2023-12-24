namespace CourseworkReal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFiltered = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuarantine = new System.Windows.Forms.TextBox();
            this.txtMentions = new System.Windows.Forms.TextBox();
            this.txtSir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnTrends = new System.Windows.Forms.Button();
            this.txtTrends = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(500, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Napier Bank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(174, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(23, 148);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(420, 379);
            this.txtMessage.TabIndex = 7;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilter.Location = new System.Drawing.Point(500, 143);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(265, 68);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFiltered
            // 
            this.txtFiltered.Location = new System.Drawing.Point(833, 143);
            this.txtFiltered.Multiline = true;
            this.txtFiltered.Name = "txtFiltered";
            this.txtFiltered.Size = new System.Drawing.Size(478, 384);
            this.txtFiltered.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(990, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filtered Message";
            // 
            // txtQuarantine
            // 
            this.txtQuarantine.Location = new System.Drawing.Point(22, 554);
            this.txtQuarantine.Multiline = true;
            this.txtQuarantine.Name = "txtQuarantine";
            this.txtQuarantine.Size = new System.Drawing.Size(265, 251);
            this.txtQuarantine.TabIndex = 12;
            // 
            // txtMentions
            // 
            this.txtMentions.Location = new System.Drawing.Point(351, 554);
            this.txtMentions.Multiline = true;
            this.txtMentions.Name = "txtMentions";
            this.txtMentions.Size = new System.Drawing.Size(265, 251);
            this.txtMentions.TabIndex = 12;
            // 
            // txtSir
            // 
            this.txtSir.Location = new System.Drawing.Point(1046, 558);
            this.txtSir.Multiline = true;
            this.txtSir.Name = "txtSir";
            this.txtSir.Size = new System.Drawing.Size(265, 251);
            this.txtSir.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1166, 535);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "SIR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mentions";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 535);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Quarantined links";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(35, 110);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(375, 27);
            this.txtId.TabIndex = 14;
            // 
            // btnTrends
            // 
            this.btnTrends.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTrends.Location = new System.Drawing.Point(500, 459);
            this.btnTrends.Name = "btnTrends";
            this.btnTrends.Size = new System.Drawing.Size(265, 68);
            this.btnTrends.TabIndex = 15;
            this.btnTrends.Text = "End Session";
            this.btnTrends.UseVisualStyleBackColor = true;
            this.btnTrends.Click += new System.EventHandler(this.btnTrends_Click);
            // 
            // txtTrends
            // 
            this.txtTrends.Location = new System.Drawing.Point(707, 561);
            this.txtTrends.Multiline = true;
            this.txtTrends.Name = "txtTrends";
            this.txtTrends.Size = new System.Drawing.Size(291, 248);
            this.txtTrends.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(815, 535);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Trend list";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 817);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrends);
            this.Controls.Add(this.btnTrends);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSir);
            this.Controls.Add(this.txtMentions);
            this.Controls.Add(this.txtQuarantine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFiltered);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox txtMessage;
        private Button btnFilter;
        private TextBox txtFiltered;
        private Label label2;
        private TextBox txtQuarantine;
        private TextBox txtMentions;
        private TextBox txtSir;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtId;
        private Button btnTrends;
        private TextBox txtTrends;
        private Label label4;
    }
}