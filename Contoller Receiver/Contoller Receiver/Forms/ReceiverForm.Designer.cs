namespace Contoller_Receiver
{
    partial class ReceiverForm
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
            this.components = new System.ComponentModel.Container();
            this.receiveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusEntry = new System.Windows.Forms.TextBox();
            this.adressLabel = new System.Windows.Forms.Label();
            this.addressEntry = new System.Windows.Forms.TextBox();
            this.receiveTimer = new System.Windows.Forms.Timer(this.components);
            this.axeLabel = new System.Windows.Forms.Label();
            this.axeEntry = new System.Windows.Forms.TextBox();
            this.commandLabel = new System.Windows.Forms.Label();
            this.commandEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // receiveButton
            // 
            this.receiveButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.receiveButton.Location = new System.Drawing.Point(346, 147);
            this.receiveButton.Name = "receiveButton";
            this.receiveButton.Size = new System.Drawing.Size(115, 49);
            this.receiveButton.TabIndex = 28;
            this.receiveButton.Text = "Start";
            this.receiveButton.UseVisualStyleBackColor = true;
            this.receiveButton.Click += new System.EventHandler(this.receiveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(301, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Connection status:";
            // 
            // statusEntry
            // 
            this.statusEntry.Location = new System.Drawing.Point(447, 47);
            this.statusEntry.Name = "statusEntry";
            this.statusEntry.Size = new System.Drawing.Size(122, 23);
            this.statusEntry.TabIndex = 26;
            // 
            // adressLabel
            // 
            this.adressLabel.AutoSize = true;
            this.adressLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.adressLabel.Location = new System.Drawing.Point(54, 47);
            this.adressLabel.Name = "adressLabel";
            this.adressLabel.Size = new System.Drawing.Size(65, 20);
            this.adressLabel.TabIndex = 25;
            this.adressLabel.Text = "Address:";
            // 
            // addressEntry
            // 
            this.addressEntry.Location = new System.Drawing.Point(129, 47);
            this.addressEntry.Name = "addressEntry";
            this.addressEntry.Size = new System.Drawing.Size(122, 23);
            this.addressEntry.TabIndex = 24;
            // 
            // receiveTimer
            // 
            this.receiveTimer.Interval = 1;
            this.receiveTimer.Tick += new System.EventHandler(this.receiveTimer_Tick);
            // 
            // axeLabel
            // 
            this.axeLabel.AutoSize = true;
            this.axeLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.axeLabel.Location = new System.Drawing.Point(54, 88);
            this.axeLabel.Name = "axeLabel";
            this.axeLabel.Size = new System.Drawing.Size(67, 20);
            this.axeLabel.TabIndex = 30;
            this.axeLabel.Text = "Last Axe:";
            // 
            // axeEntry
            // 
            this.axeEntry.Location = new System.Drawing.Point(129, 88);
            this.axeEntry.Name = "axeEntry";
            this.axeEntry.Size = new System.Drawing.Size(122, 23);
            this.axeEntry.TabIndex = 29;
            // 
            // commandLabel
            // 
            this.commandLabel.AutoSize = true;
            this.commandLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commandLabel.Location = new System.Drawing.Point(319, 88);
            this.commandLabel.Name = "commandLabel";
            this.commandLabel.Size = new System.Drawing.Size(111, 20);
            this.commandLabel.TabIndex = 32;
            this.commandLabel.Text = "Last Command:";
            // 
            // commandEntry
            // 
            this.commandEntry.Location = new System.Drawing.Point(447, 88);
            this.commandEntry.Name = "commandEntry";
            this.commandEntry.Size = new System.Drawing.Size(122, 23);
            this.commandEntry.TabIndex = 31;
            // 
            // ReceiverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 246);
            this.Controls.Add(this.commandLabel);
            this.Controls.Add(this.commandEntry);
            this.Controls.Add(this.axeLabel);
            this.Controls.Add(this.axeEntry);
            this.Controls.Add(this.receiveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusEntry);
            this.Controls.Add(this.adressLabel);
            this.Controls.Add(this.addressEntry);
            this.Name = "ReceiverForm";
            this.Text = "ReceiverForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReceiverForm_FormClosed);
            this.Load += new System.EventHandler(this.ReceiverForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button receiveButton;
        private Label label1;
        private Label adressLabel;
        private TextBox addressEntry;
        private TextBox statusEntry;
        private System.Windows.Forms.Timer receiveTimer;
        private Label axeLabel;
        private TextBox axeEntry;
        private Label commandLabel;
        private TextBox commandEntry;
    }
}