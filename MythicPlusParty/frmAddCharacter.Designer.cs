
namespace MythicPlusParty
{
    partial class frmAddCharacter
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
            this.cmbPlayer = new System.Windows.Forms.ComboBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkTank = new System.Windows.Forms.CheckBox();
            this.chkHealer = new System.Windows.Forms.CheckBox();
            this.chkDPS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbPlayer
            // 
            this.cmbPlayer.FormattingEnabled = true;
            this.cmbPlayer.Location = new System.Drawing.Point(12, 63);
            this.cmbPlayer.Name = "cmbPlayer";
            this.cmbPlayer.Size = new System.Drawing.Size(121, 21);
            this.cmbPlayer.TabIndex = 0;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(49, 44);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(36, 13);
            this.lblPlayer.TabIndex = 4;
            this.lblPlayer.Text = "Player";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(140, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(158, 20);
            this.txtName.TabIndex = 8;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(206, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(373, 63);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(183, 134);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkTank
            // 
            this.chkTank.AutoSize = true;
            this.chkTank.Location = new System.Drawing.Point(310, 39);
            this.chkTank.Name = "chkTank";
            this.chkTank.Size = new System.Drawing.Size(51, 17);
            this.chkTank.TabIndex = 12;
            this.chkTank.Text = "Tank";
            this.chkTank.UseVisualStyleBackColor = true;
            // 
            // chkHealer
            // 
            this.chkHealer.AutoSize = true;
            this.chkHealer.Location = new System.Drawing.Point(310, 63);
            this.chkHealer.Name = "chkHealer";
            this.chkHealer.Size = new System.Drawing.Size(57, 17);
            this.chkHealer.TabIndex = 13;
            this.chkHealer.Text = "Healer";
            this.chkHealer.UseVisualStyleBackColor = true;
            // 
            // chkDPS
            // 
            this.chkDPS.AutoSize = true;
            this.chkDPS.Location = new System.Drawing.Point(310, 87);
            this.chkDPS.Name = "chkDPS";
            this.chkDPS.Size = new System.Drawing.Size(48, 17);
            this.chkDPS.TabIndex = 14;
            this.chkDPS.Text = "DPS";
            this.chkDPS.UseVisualStyleBackColor = true;
            // 
            // frmAddCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 183);
            this.Controls.Add(this.chkDPS);
            this.Controls.Add(this.chkHealer);
            this.Controls.Add(this.chkTank);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.cmbPlayer);
            this.Name = "frmAddCharacter";
            this.Text = "Add Character";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPlayer;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkTank;
        private System.Windows.Forms.CheckBox chkHealer;
        private System.Windows.Forms.CheckBox chkDPS;
    }
}