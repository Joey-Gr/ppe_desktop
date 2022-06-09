
namespace PPE_Salons
{
    partial class Login
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
            this.errLogin = new System.Windows.Forms.Label();
            this.tbMdp = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.btnAnu = new System.Windows.Forms.Button();
            this.btnEnr = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.Prenom = new System.Windows.Forms.Label();
            this.labelResponse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // errLogin
            // 
            this.errLogin.AutoSize = true;
            this.errLogin.Location = new System.Drawing.Point(288, 270);
            this.errLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errLogin.Name = "errLogin";
            this.errLogin.Size = new System.Drawing.Size(183, 17);
            this.errLogin.TabIndex = 20;
            this.errLogin.Text = "Error with password or login";
            this.errLogin.Visible = false;
            // 
            // tbMdp
            // 
            this.tbMdp.Location = new System.Drawing.Point(260, 198);
            this.tbMdp.Margin = new System.Windows.Forms.Padding(4);
            this.tbMdp.Name = "tbMdp";
            this.tbMdp.PasswordChar = '*';
            this.tbMdp.Size = new System.Drawing.Size(333, 22);
            this.tbMdp.TabIndex = 18;
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(159, 198);
            this.email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(93, 17);
            this.email.TabIndex = 17;
            this.email.Text = "Mot de passe";
            // 
            // btnAnu
            // 
            this.btnAnu.Location = new System.Drawing.Point(102, 280);
            this.btnAnu.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnu.Name = "btnAnu";
            this.btnAnu.Size = new System.Drawing.Size(100, 28);
            this.btnAnu.TabIndex = 16;
            this.btnAnu.Text = "Annuler";
            this.btnAnu.UseVisualStyleBackColor = true;
            this.btnAnu.Click += new System.EventHandler(this.btnAnu_Click);
            // 
            // btnEnr
            // 
            this.btnEnr.Location = new System.Drawing.Point(534, 267);
            this.btnEnr.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnr.Name = "btnEnr";
            this.btnEnr.Size = new System.Drawing.Size(100, 28);
            this.btnEnr.TabIndex = 15;
            this.btnEnr.Text = "Enregistrer";
            this.btnEnr.UseVisualStyleBackColor = true;
            this.btnEnr.Click += new System.EventHandler(this.btnEnr_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(260, 137);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(333, 22);
            this.tbLogin.TabIndex = 14;
            // 
            // Prenom
            // 
            this.Prenom.AutoSize = true;
            this.Prenom.Location = new System.Drawing.Point(159, 137);
            this.Prenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Prenom.Name = "Prenom";
            this.Prenom.Size = new System.Drawing.Size(43, 17);
            this.Prenom.TabIndex = 12;
            this.Prenom.Text = "Login";
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(558, 336);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(0, 17);
            this.labelResponse.TabIndex = 22;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.errLogin);
            this.Controls.Add(this.tbMdp);
            this.Controls.Add(this.email);
            this.Controls.Add(this.btnAnu);
            this.Controls.Add(this.btnEnr);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.Prenom);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label errLogin;
        private System.Windows.Forms.TextBox tbMdp;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Button btnAnu;
        private System.Windows.Forms.Button btnEnr;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label Prenom;
        private System.Windows.Forms.Label labelResponse;
    }
}