
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
            this.tbMdp = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.btnAnu = new System.Windows.Forms.Button();
            this.btnEnr = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.Prenom = new System.Windows.Forms.Label();
            this.labelResponse = new System.Windows.Forms.Label();
            this.portChoix = new System.Windows.Forms.ComboBox();
            this.btnInscr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbMdp
            // 
            this.tbMdp.Location = new System.Drawing.Point(187, 186);
            this.tbMdp.Margin = new System.Windows.Forms.Padding(4);
            this.tbMdp.Name = "tbMdp";
            this.tbMdp.PasswordChar = '*';
            this.tbMdp.Size = new System.Drawing.Size(333, 22);
            this.tbMdp.TabIndex = 18;
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(86, 186);
            this.email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(93, 17);
            this.email.TabIndex = 17;
            this.email.Text = "Mot de passe";
            // 
            // btnAnu
            // 
            this.btnAnu.Location = new System.Drawing.Point(79, 247);
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
            this.btnEnr.Location = new System.Drawing.Point(441, 235);
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
            this.tbLogin.Location = new System.Drawing.Point(187, 125);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(333, 22);
            this.tbLogin.TabIndex = 14;
            // 
            // Prenom
            // 
            this.Prenom.AutoSize = true;
            this.Prenom.Location = new System.Drawing.Point(86, 125);
            this.Prenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Prenom.Name = "Prenom";
            this.Prenom.Size = new System.Drawing.Size(43, 17);
            this.Prenom.TabIndex = 12;
            this.Prenom.Text = "Login";
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(438, 340);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(14, 17);
            this.labelResponse.TabIndex = 22;
            this.labelResponse.Text = "x";
            this.labelResponse.Visible = false;
            // 
            // portChoix
            // 
            this.portChoix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portChoix.FormattingEnabled = true;
            this.portChoix.Items.AddRange(new object[] {
            "Distant",
            "Locale"});
            this.portChoix.Location = new System.Drawing.Point(441, 270);
            this.portChoix.Name = "portChoix";
            this.portChoix.Size = new System.Drawing.Size(121, 24);
            this.portChoix.TabIndex = 23;
            this.portChoix.SelectedIndexChanged += new System.EventHandler(this.portChoix_SelectedIndexChanged);
            // 
            // btnInscr
            // 
            this.btnInscr.Location = new System.Drawing.Point(135, 340);
            this.btnInscr.Name = "btnInscr";
            this.btnInscr.Size = new System.Drawing.Size(113, 33);
            this.btnInscr.TabIndex = 24;
            this.btnInscr.Text = "Inscrivez-vous";
            this.btnInscr.UseVisualStyleBackColor = true;
            this.btnInscr.Click += new System.EventHandler(this.btnInscr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Pas de compte?";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInscr);
            this.Controls.Add(this.portChoix);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.tbMdp);
            this.Controls.Add(this.email);
            this.Controls.Add(this.btnAnu);
            this.Controls.Add(this.btnEnr);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.Prenom);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbMdp;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Button btnAnu;
        private System.Windows.Forms.Button btnEnr;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label Prenom;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.ComboBox portChoix;
        private System.Windows.Forms.Button btnInscr;
        private System.Windows.Forms.Label label1;
    }
}