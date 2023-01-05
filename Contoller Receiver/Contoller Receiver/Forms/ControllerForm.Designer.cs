namespace Contoller_Receiver
{
    partial class ControllerForm
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
            this.sendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusEntry = new System.Windows.Forms.TextBox();
            this.adressLabel = new System.Windows.Forms.Label();
            this.addressEntry = new System.Windows.Forms.TextBox();
            this.keyUp = new System.Windows.Forms.Button();
            this.keyDown = new System.Windows.Forms.Button();
            this.keyLeft = new System.Windows.Forms.Button();
            this.keyRight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendButton.Location = new System.Drawing.Point(35, 93);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(115, 49);
            this.sendButton.TabIndex = 20;
            this.sendButton.Text = "Start";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(303, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Connection status:";
            // 
            // statusEntry
            // 
            this.statusEntry.Location = new System.Drawing.Point(449, 41);
            this.statusEntry.Name = "statusEntry";
            this.statusEntry.Size = new System.Drawing.Size(122, 23);
            this.statusEntry.TabIndex = 18;
            // 
            // adressLabel
            // 
            this.adressLabel.AutoSize = true;
            this.adressLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.adressLabel.Location = new System.Drawing.Point(56, 41);
            this.adressLabel.Name = "adressLabel";
            this.adressLabel.Size = new System.Drawing.Size(65, 20);
            this.adressLabel.TabIndex = 17;
            this.adressLabel.Text = "Address:";
            // 
            // addressEntry
            // 
            this.addressEntry.Location = new System.Drawing.Point(131, 41);
            this.addressEntry.Name = "addressEntry";
            this.addressEntry.Size = new System.Drawing.Size(122, 23);
            this.addressEntry.TabIndex = 16;
            // 
            // keyUp
            // 
            this.keyUp.Location = new System.Drawing.Point(278, 112);
            this.keyUp.Name = "keyUp";
            this.keyUp.Size = new System.Drawing.Size(35, 35);
            this.keyUp.TabIndex = 21;
            this.keyUp.Text = "W";
            this.keyUp.UseVisualStyleBackColor = true;
            // 
            // keyDown
            // 
            this.keyDown.Location = new System.Drawing.Point(278, 145);
            this.keyDown.Name = "keyDown";
            this.keyDown.Size = new System.Drawing.Size(35, 35);
            this.keyDown.TabIndex = 21;
            this.keyDown.Text = "S";
            this.keyDown.UseVisualStyleBackColor = true;
            // 
            // keyLeft
            // 
            this.keyLeft.Location = new System.Drawing.Point(245, 145);
            this.keyLeft.Name = "keyLeft";
            this.keyLeft.Size = new System.Drawing.Size(35, 35);
            this.keyLeft.TabIndex = 22;
            this.keyLeft.Text = "A";
            this.keyLeft.UseVisualStyleBackColor = true;
            // 
            // keyRight
            // 
            this.keyRight.Location = new System.Drawing.Point(311, 145);
            this.keyRight.Name = "keyRight";
            this.keyRight.Size = new System.Drawing.Size(35, 35);
            this.keyRight.TabIndex = 23;
            this.keyRight.Text = "D";
            this.keyRight.UseVisualStyleBackColor = true;
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 246);
            this.Controls.Add(this.keyRight);
            this.Controls.Add(this.keyLeft);
            this.Controls.Add(this.keyDown);
            this.Controls.Add(this.keyUp);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusEntry);
            this.Controls.Add(this.adressLabel);
            this.Controls.Add(this.addressEntry);
            this.KeyPreview = true;
            this.Name = "ControllerForm";
            this.Text = "ControllerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControllerForm_FormClosed);
            this.Load += new System.EventHandler(this.ControllerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button sendButton;
        private Label label1;
        private Label adressLabel;
        private TextBox addressEntry;
        private Button keyUp;
        private Button keyDown;
        private Button keyLeft;
        private Button keyRight;
        private TextBox statusEntry;
    }
}