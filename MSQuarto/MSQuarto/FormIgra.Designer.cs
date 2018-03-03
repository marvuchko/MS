namespace MSQuarto
{
    partial class FormIgra
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
            this.lblPoruka = new System.Windows.Forms.Label();
            this.lblPrviIgrac = new System.Windows.Forms.Label();
            this.lblDrugiIgrac = new System.Windows.Forms.Label();
            this.btnGlavniMeni = new System.Windows.Forms.Button();
            this.btnIgrajOpet = new System.Windows.Forms.Button();
            this.lblBiraFiguru = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPoruka
            // 
            this.lblPoruka.AutoSize = true;
            this.lblPoruka.BackColor = System.Drawing.Color.Transparent;
            this.lblPoruka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoruka.Location = new System.Drawing.Point(143, 385);
            this.lblPoruka.Name = "lblPoruka";
            this.lblPoruka.Size = new System.Drawing.Size(106, 20);
            this.lblPoruka.TabIndex = 2;
            this.lblPoruka.Text = "Na potezu je: ";
            this.lblPoruka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrviIgrac
            // 
            this.lblPrviIgrac.AutoSize = true;
            this.lblPrviIgrac.BackColor = System.Drawing.Color.Transparent;
            this.lblPrviIgrac.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrviIgrac.Location = new System.Drawing.Point(511, 39);
            this.lblPrviIgrac.Name = "lblPrviIgrac";
            this.lblPrviIgrac.Size = new System.Drawing.Size(36, 39);
            this.lblPrviIgrac.TabIndex = 3;
            this.lblPrviIgrac.Text = "0";
            this.lblPrviIgrac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDrugiIgrac
            // 
            this.lblDrugiIgrac.AutoSize = true;
            this.lblDrugiIgrac.BackColor = System.Drawing.Color.Transparent;
            this.lblDrugiIgrac.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrugiIgrac.Location = new System.Drawing.Point(512, 156);
            this.lblDrugiIgrac.Name = "lblDrugiIgrac";
            this.lblDrugiIgrac.Size = new System.Drawing.Size(36, 39);
            this.lblDrugiIgrac.TabIndex = 4;
            this.lblDrugiIgrac.Text = "0";
            this.lblDrugiIgrac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGlavniMeni
            // 
            this.btnGlavniMeni.BackColor = System.Drawing.Color.Transparent;
            this.btnGlavniMeni.BackgroundImage = global::MSQuarto.Properties.Resources.dugme2;
            this.btnGlavniMeni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGlavniMeni.FlatAppearance.BorderSize = 0;
            this.btnGlavniMeni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGlavniMeni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGlavniMeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGlavniMeni.Location = new System.Drawing.Point(467, 304);
            this.btnGlavniMeni.Name = "btnGlavniMeni";
            this.btnGlavniMeni.Size = new System.Drawing.Size(120, 42);
            this.btnGlavniMeni.TabIndex = 1;
            this.btnGlavniMeni.Tag = "permanent";
            this.btnGlavniMeni.UseVisualStyleBackColor = false;
            this.btnGlavniMeni.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGlavniMeni_MouseDown);
            this.btnGlavniMeni.MouseEnter += new System.EventHandler(this.meniDugme_MouseEnter);
            this.btnGlavniMeni.MouseLeave += new System.EventHandler(this.meniDugme_MouseLeave);
            this.btnGlavniMeni.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnGlavniMeni_MouseUp);
            // 
            // btnIgrajOpet
            // 
            this.btnIgrajOpet.BackColor = System.Drawing.Color.Transparent;
            this.btnIgrajOpet.BackgroundImage = global::MSQuarto.Properties.Resources.dugme1;
            this.btnIgrajOpet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIgrajOpet.FlatAppearance.BorderSize = 0;
            this.btnIgrajOpet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIgrajOpet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIgrajOpet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgrajOpet.Location = new System.Drawing.Point(469, 251);
            this.btnIgrajOpet.Name = "btnIgrajOpet";
            this.btnIgrajOpet.Size = new System.Drawing.Size(120, 42);
            this.btnIgrajOpet.TabIndex = 0;
            this.btnIgrajOpet.Tag = "permanent";
            this.btnIgrajOpet.UseVisualStyleBackColor = false;
            this.btnIgrajOpet.Click += new System.EventHandler(this.btnIgrajOpet_Click);
            this.btnIgrajOpet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnIgrajOpet_MouseDown);
            this.btnIgrajOpet.MouseEnter += new System.EventHandler(this.meniDugme_MouseEnter);
            this.btnIgrajOpet.MouseLeave += new System.EventHandler(this.meniDugme_MouseLeave);
            this.btnIgrajOpet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnIgrajOpet_MouseUp);
            // 
            // lblBiraFiguru
            // 
            this.lblBiraFiguru.AutoSize = true;
            this.lblBiraFiguru.BackColor = System.Drawing.Color.Transparent;
            this.lblBiraFiguru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiraFiguru.Location = new System.Drawing.Point(145, 406);
            this.lblBiraFiguru.Name = "lblBiraFiguru";
            this.lblBiraFiguru.Size = new System.Drawing.Size(88, 20);
            this.lblBiraFiguru.TabIndex = 5;
            this.lblBiraFiguru.Text = "Figuru bira:";
            this.lblBiraFiguru.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormIgra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MSQuarto.Properties.Resources.tabla;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(599, 599);
            this.Controls.Add(this.lblBiraFiguru);
            this.Controls.Add(this.lblDrugiIgrac);
            this.Controls.Add(this.lblPrviIgrac);
            this.Controls.Add(this.lblPoruka);
            this.Controls.Add(this.btnGlavniMeni);
            this.Controls.Add(this.btnIgrajOpet);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIgra";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quarto - Marko & Stevica";
            this.Load += new System.EventHandler(this.FormIgra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIgrajOpet;
        private System.Windows.Forms.Button btnGlavniMeni;
        private System.Windows.Forms.Label lblPoruka;
        private System.Windows.Forms.Label lblPrviIgrac;
        private System.Windows.Forms.Label lblDrugiIgrac;
        private System.Windows.Forms.Label lblBiraFiguru;
    }
}