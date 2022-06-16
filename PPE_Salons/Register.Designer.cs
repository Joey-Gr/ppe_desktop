
namespace PPE_Salons
{
    partial class Register
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
            this.portChoix = new System.Windows.Forms.ComboBox();
            this.tbMdp = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.btnEnr = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.Prenom = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // portChoix
            // 
            this.portChoix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portChoix.FormattingEnabled = true;
            this.portChoix.Items.AddRange(new object[] {
            "Distant",
            "Locale"});
            this.portChoix.Location = new System.Drawing.Point(466, 280);
            this.portChoix.Name = "portChoix";
            this.portChoix.Size = new System.Drawing.Size(121, 24);
            this.portChoix.TabIndex = 30;
            // 
            // tbMdp
            // 
            this.tbMdp.Location = new System.Drawing.Point(212, 196);
            this.tbMdp.Margin = new System.Windows.Forms.Padding(4);
            this.tbMdp.Name = "tbMdp";
            this.tbMdp.PasswordChar = '*';
            this.tbMdp.Size = new System.Drawing.Size(333, 22);
            this.tbMdp.TabIndex = 29;
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(111, 196);
            this.email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(93, 17);
            this.email.TabIndex = 28;
            this.email.Text = "Mot de passe";
            // 
            // btnEnr
            // 
            this.btnEnr.Location = new System.Drawing.Point(466, 245);
            this.btnEnr.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnr.Name = "btnEnr";
            this.btnEnr.Size = new System.Drawing.Size(100, 28);
            this.btnEnr.TabIndex = 26;
            this.btnEnr.Text = "Enregistrer";
            this.btnEnr.UseVisualStyleBackColor = true;
            this.btnEnr.Click += new System.EventHandler(this.btnEnr_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(212, 135);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(333, 22);
            this.tbName.TabIndex = 25;
            // 
            // Prenom
            // 
            this.Prenom.AutoSize = true;
            this.Prenom.Location = new System.Drawing.Point(157, 138);
            this.Prenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Prenom.Name = "Prenom";
            this.Prenom.Size = new System.Drawing.Size(37, 17);
            this.Prenom.TabIndex = 24;
            this.Prenom.Text = "Nom";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(160, 276);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(123, 28);
            this.btnLogin.TabIndex = 31;
            this.btnLogin.Text = "Connectez-vous";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Déjà un compte?";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.portChoix);
            this.Controls.Add(this.tbMdp);
            this.Controls.Add(this.email);
            this.Controls.Add(this.btnEnr);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.Prenom);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portChoix;
        private System.Windows.Forms.TextBox tbMdp;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Button btnEnr;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label Prenom;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
    }
}