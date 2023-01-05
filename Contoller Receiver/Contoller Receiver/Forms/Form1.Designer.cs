namespace Contoller_Receiver
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
            this.statusEntry = new System.Windows.Forms.TextBox();
            this.adressLabel = new System.Windows.Forms.Label();
            this.addressEntry = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordEntry = new System.Windows.Forms.TextBox();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.connectionType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Connection status:";
            // 
            // statusEntry
            // 
            this.statusEntry.Location = new System.Drawing.Point(171, 79);
            this.statusEntry.Name = "statusEntry";
            this.statusEntry.Size = new System.Drawing.Size(122, 23);
            this.statusEntry.TabIndex = 9;
            // 
            // adressLabel
            // 
            this.adressLabel.AutoSize = true;
            this.adressLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.adressLabel.Location = new System.Drawing.Point(96, 40);
            this.adressLabel.Name = "adressLabel";
            this.adressLabel.Size = new System.Drawing.Size(65, 20);
            this.adressLabel.TabIndex = 8;
            this.adressLabel.Text = "Address:";
            // 
            // addressEntry
            // 
            this.addressEntry.Location = new System.Drawing.Point(171, 40);
            this.addressEntry.Name = "addressEntry";
            this.addressEntry.Size = new System.Drawing.Size(122, 23);
            this.addressEntry.TabIndex = 7;
            this.addressEntry.TextChanged += new System.EventHandler(this.addressEntry_TextChanged);
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectButton.Location = new System.Drawing.Point(346, 147);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(115, 49);
            this.connectButton.TabIndex = 11;
            this.connectButton.Text = "Create";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.Location = new System.Drawing.Point(346, 41);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(73, 20);
            this.passwordLabel.TabIndex = 13;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordEntry
            // 
            this.passwordEntry.Enabled = false;
            this.passwordEntry.Location = new System.Drawing.Point(426, 41);
            this.passwordEntry.Name = "passwordEntry";
            this.passwordEntry.Size = new System.Drawing.Size(122, 23);
            this.passwordEntry.TabIndex = 12;
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.AutoSize = true;
            this.passwordCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordCheckBox.Location = new System.Drawing.Point(352, 81);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(98, 19);
            this.passwordCheckBox.TabIndex = 14;
            this.passwordCheckBox.Text = "Use Password";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            this.passwordCheckBox.CheckedChanged += new System.EventHandler(this.passwordCheckBox_CheckedChanged);
            // 
            // connectionType
            // 
            this.connectionType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionType.FormattingEnabled = true;
            this.connectionType.Location = new System.Drawing.Point(152, 162);
            this.connectionType.Name = "connectionType";
            this.connectionType.Size = new System.Drawing.Size(160, 23);
            this.connectionType.TabIndex = 15;
            this.connectionType.Text = "Receiver";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 246);
            this.Controls.Add(this.connectionType);
            this.Controls.Add(this.passwordCheckBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordEntry);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusEntry);
            this.Controls.Add(this.adressLabel);
            this.Controls.Add(this.addressEntry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label adressLabel;
        private TextBox addressEntry;
        private Button connectButton;
        private Label passwordLabel;
        private TextBox passwordEntry;
        private CheckBox passwordCheckBox;
        private ComboBox connectionType;
        private TextBox statusEntry;
    }
}