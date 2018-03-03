namespace MSQuarto
{
    partial class FormPocetna
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
            this.btnNovaIgra = new System.Windows.Forms.Button();
            this.btnUputstva = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNovaIgra
            // 
            this.btnNovaIgra.BackColor = System.Drawing.Color.Transparent;
            this.btnNovaIgra.BackgroundImage = global::MSQuarto.Properties.Resources.dugmeNovaIgra;
            this.btnNovaIgra.FlatAppearance.BorderSize = 0;
            this.btnNovaIgra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNovaIgra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNovaIgra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaIgra.Location = new System.Drawing.Point(74, 458);
            this.btnNovaIgra.Name = "btnNovaIgra";
            this.btnNovaIgra.Size = new System.Drawing.Size(120, 42);
            this.btnNovaIgra.TabIndex = 0;
            this.btnNovaIgra.TabStop = false;
            this.btnNovaIgra.Tag = "dugmeNovaIgra";
            this.btnNovaIgra.UseVisualStyleBackColor = false;
            this.btnNovaIgra.Click += new System.EventHandler(this.btnNovaIgra_Click);
            this.btnNovaIgra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.meniDugme_MouseDown);
            this.btnNovaIgra.MouseEnter += new System.EventHandler(this.meniDugme_MouseEnter);
            this.btnNovaIgra.MouseLeave += new System.EventHandler(this.meniDugme_MouseLeave);
            this.btnNovaIgra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.meniDugme_MouseUp);
            // 
            // btnUputstva
            // 
            this.btnUputstva.BackColor = System.Drawing.Color.Transparent;
            this.btnUputstva.BackgroundImage = global::MSQuarto.Properties.Resources.dugmeUputstva;
            this.btnUputstva.FlatAppearance.BorderSize = 0;
            this.btnUputstva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUputstva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUputstva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUputstva.Location = new System.Drawing.Point(239, 458);
            this.btnUputstva.Name = "btnUputstva";
            this.btnUputstva.Size = new System.Drawing.Size(120, 42);
            this.btnUputstva.TabIndex = 1;
            this.btnUputstva.TabStop = false;
            this.btnUputstva.Tag = "dugmeUputstva";
            this.btnUputstva.UseVisualStyleBackColor = false;
            this.btnUputstva.Click += new System.EventHandler(this.btnUputstva_Click);
            this.btnUputstva.MouseDown += new System.Windows.Forms.MouseEventHandler(this.meniDugme_MouseDown);
            this.btnUputstva.MouseEnter += new System.EventHandler(this.meniDugme_MouseEnter);
            this.btnUputstva.MouseLeave += new System.EventHandler(this.meniDugme_MouseLeave);
            this.btnUputstva.MouseUp += new System.Windows.Forms.MouseEventHandler(this.meniDugme_MouseUp);
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.BackColor = System.Drawing.Color.Transparent;
            this.btnIzlaz.BackgroundImage = global::MSQuarto.Properties.Resources.dugmeIzlaz;
            this.btnIzlaz.FlatAppearance.BorderSize = 0;
            this.btnIzlaz.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIzlaz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIzlaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzlaz.Location = new System.Drawing.Point(404, 458);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(120, 42);
            this.btnIzlaz.TabIndex = 2;
            this.btnIzlaz.TabStop = false;
            this.btnIzlaz.Tag = "dugmeIzlaz";
            this.btnIzlaz.UseVisualStyleBackColor = false;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            this.btnIzlaz.MouseDown += new System.Windows.Forms.MouseEventHandler(this.meniDugme_MouseDown);
            this.btnIzlaz.MouseEnter += new System.EventHandler(this.meniDugme_MouseEnter);
            this.btnIzlaz.MouseLeave += new System.EventHandler(this.meniDugme_MouseLeave);
            this.btnIzlaz.MouseUp += new System.Windows.Forms.MouseEventHandler(this.meniDugme_MouseUp);
            // 
            // FormPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MSQuarto.Properties.Resources.glavna;
            this.ClientSize = new System.Drawing.Size(599, 599);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnUputstva);
            this.Controls.Add(this.btnNovaIgra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPocetna";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quarto - Marko & Stevica";
            this.Load += new System.EventHandler(this.FormPocetna_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNovaIgra;
        private System.Windows.Forms.Button btnUputstva;
        private System.Windows.Forms.Button btnIzlaz;
    }
}

