namespace MSQuarto
{
    partial class FormaDijalog
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
            this.btnPrihvati = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.rbPrvi = new System.Windows.Forms.RadioButton();
            this.rbDrugi = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnPrihvati
            // 
            this.btnPrihvati.BackColor = System.Drawing.Color.Transparent;
            this.btnPrihvati.BackgroundImage = global::MSQuarto.Properties.Resources.dugmePrihvati;
            this.btnPrihvati.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrihvati.FlatAppearance.BorderSize = 0;
            this.btnPrihvati.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrihvati.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrihvati.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrihvati.Location = new System.Drawing.Point(57, 246);
            this.btnPrihvati.Name = "btnPrihvati";
            this.btnPrihvati.Size = new System.Drawing.Size(94, 32);
            this.btnPrihvati.TabIndex = 1;
            this.btnPrihvati.TabStop = false;
            this.btnPrihvati.Tag = "dugmePrihvati";
            this.btnPrihvati.UseVisualStyleBackColor = false;
            this.btnPrihvati.Click += new System.EventHandler(this.btnPrihvati_Click);
            this.btnPrihvati.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dijalogDugmiciMouseDown);
            this.btnPrihvati.MouseEnter += new System.EventHandler(this.dijalogDugmiciMouseEnter);
            this.btnPrihvati.MouseLeave += new System.EventHandler(this.dijalogDugmiciMouseLeave);
            this.btnPrihvati.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dijalogDugmiciMouseUp);
            // 
            // btnOdustani
            // 
            this.btnOdustani.BackColor = System.Drawing.Color.Transparent;
            this.btnOdustani.BackgroundImage = global::MSQuarto.Properties.Resources.dugmeOdustani;
            this.btnOdustani.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOdustani.FlatAppearance.BorderSize = 0;
            this.btnOdustani.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOdustani.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Location = new System.Drawing.Point(177, 246);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(94, 32);
            this.btnOdustani.TabIndex = 2;
            this.btnOdustani.TabStop = false;
            this.btnOdustani.Tag = "dugmeOdustani";
            this.btnOdustani.UseVisualStyleBackColor = false;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            this.btnOdustani.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dijalogDugmiciMouseDown);
            this.btnOdustani.MouseEnter += new System.EventHandler(this.dijalogDugmiciMouseEnter);
            this.btnOdustani.MouseLeave += new System.EventHandler(this.dijalogDugmiciMouseLeave);
            this.btnOdustani.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dijalogDugmiciMouseUp);
            // 
            // rbPrvi
            // 
            this.rbPrvi.BackColor = System.Drawing.Color.Transparent;
            this.rbPrvi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbPrvi.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbPrvi.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rbPrvi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rbPrvi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rbPrvi.Location = new System.Drawing.Point(90, 81);
            this.rbPrvi.Name = "rbPrvi";
            this.rbPrvi.Size = new System.Drawing.Size(30, 30);
            this.rbPrvi.TabIndex = 3;
            this.rbPrvi.UseVisualStyleBackColor = false;
            this.rbPrvi.MouseEnter += new System.EventHandler(this.radioMouseEnter);
            this.rbPrvi.MouseLeave += new System.EventHandler(this.radioMouseLeave);
            // 
            // rbDrugi
            // 
            this.rbDrugi.BackColor = System.Drawing.Color.Transparent;
            this.rbDrugi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbDrugi.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDrugi.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rbDrugi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rbDrugi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rbDrugi.Location = new System.Drawing.Point(90, 143);
            this.rbDrugi.Name = "rbDrugi";
            this.rbDrugi.Size = new System.Drawing.Size(30, 30);
            this.rbDrugi.TabIndex = 4;
            this.rbDrugi.UseVisualStyleBackColor = false;
            this.rbDrugi.MouseEnter += new System.EventHandler(this.radioMouseEnter);
            this.rbDrugi.MouseLeave += new System.EventHandler(this.radioMouseLeave);
            // 
            // FormaDijalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MSQuarto.Properties.Resources.dijalog1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.rbDrugi);
            this.Controls.Add(this.rbPrvi);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnPrihvati);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormaDijalog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS Quarto - Marko & Stevica";
            this.Load += new System.EventHandler(this.FormaDijalogLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrihvati;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.RadioButton rbPrvi;
        private System.Windows.Forms.RadioButton rbDrugi;
    }
}