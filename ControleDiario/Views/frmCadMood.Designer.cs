namespace ControleDiario.Views
{
    partial class frmCadMood
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
            this.button2 = new System.Windows.Forms.Button();
            this.cbIntensity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lb2 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.cbFeeling = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpAddMood = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbIntensity
            // 
            this.cbIntensity.FormattingEnabled = true;
            this.cbIntensity.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbIntensity.Location = new System.Drawing.Point(12, 132);
            this.cbIntensity.Name = "cbIntensity";
            this.cbIntensity.Size = new System.Drawing.Size(121, 21);
            this.cbIntensity.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Note:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Location = new System.Drawing.Point(9, 116);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(49, 13);
            this.lb2.TabIndex = 14;
            this.lb2.Text = "Intensity:";
            // 
            // tbNote
            // 
            this.tbNote.Location = new System.Drawing.Point(9, 189);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(237, 103);
            this.tbNote.TabIndex = 13;
            // 
            // cbFeeling
            // 
            this.cbFeeling.FormattingEnabled = true;
            this.cbFeeling.Items.AddRange(new object[] {
            "Hope",
            "Anxiety",
            "Sadness",
            "Hapiness",
            "Focus",
            "Angry",
            "Boredom"});
            this.cbFeeling.Location = new System.Drawing.Point(12, 76);
            this.cbFeeling.Name = "cbFeeling";
            this.cbFeeling.Size = new System.Drawing.Size(121, 21);
            this.cbFeeling.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Feeling:";
            // 
            // dtpAddMood
            // 
            this.dtpAddMood.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAddMood.Location = new System.Drawing.Point(12, 21);
            this.dtpAddMood.Name = "dtpAddMood";
            this.dtpAddMood.Size = new System.Drawing.Size(113, 20);
            this.dtpAddMood.TabIndex = 10;
            this.dtpAddMood.Value = new System.DateTime(2023, 1, 12, 0, 0, 0, 0);
            // 
            // frmCadMood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 353);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbIntensity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.cbFeeling);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpAddMood);
            this.Name = "frmCadMood";
            this.Text = "frmCadMood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbIntensity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.ComboBox cbFeeling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAddMood;
    }
}