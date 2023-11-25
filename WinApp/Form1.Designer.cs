
namespace WinApp
{
    partial class Form1
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
            this.txtNoticia = new System.Windows.Forms.TextBox();
            this.lblNoticia = new System.Windows.Forms.Label();
            this.txtNoticiaExistente = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnLeerNoticia = new System.Windows.Forms.Button();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.btnArchivos = new System.Windows.Forms.Button();
            this.btnDirectorios = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtNoticia
            // 
            this.txtNoticia.Location = new System.Drawing.Point(125, 25);
            this.txtNoticia.Multiline = true;
            this.txtNoticia.Name = "txtNoticia";
            this.txtNoticia.Size = new System.Drawing.Size(296, 330);
            this.txtNoticia.TabIndex = 0;
            // 
            // lblNoticia
            // 
            this.lblNoticia.AutoSize = true;
            this.lblNoticia.Location = new System.Drawing.Point(12, 25);
            this.lblNoticia.Name = "lblNoticia";
            this.lblNoticia.Size = new System.Drawing.Size(93, 13);
            this.lblNoticia.TabIndex = 1;
            this.lblNoticia.Text = "Escriba su noticia:";
            // 
            // txtNoticiaExistente
            // 
            this.txtNoticiaExistente.Location = new System.Drawing.Point(477, 25);
            this.txtNoticiaExistente.Multiline = true;
            this.txtNoticiaExistente.Name = "txtNoticiaExistente";
            this.txtNoticiaExistente.Size = new System.Drawing.Size(296, 330);
            this.txtNoticiaExistente.TabIndex = 2;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(218, 361);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(108, 23);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "Grabar Noticia";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnLeerNoticia
            // 
            this.btnLeerNoticia.Location = new System.Drawing.Point(571, 361);
            this.btnLeerNoticia.Name = "btnLeerNoticia";
            this.btnLeerNoticia.Size = new System.Drawing.Size(108, 23);
            this.btnLeerNoticia.TabIndex = 4;
            this.btnLeerNoticia.Text = "Leer Noticia/s";
            this.btnLeerNoticia.UseVisualStyleBackColor = true;
            this.btnLeerNoticia.Click += new System.EventHandler(this.btnLeerNoticia_Click);
            // 
            // lblPosicion
            // 
            this.lblPosicion.AutoSize = true;
            this.lblPosicion.Location = new System.Drawing.Point(12, 385);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(50, 13);
            this.lblPosicion.TabIndex = 5;
            this.lblPosicion.Text = "Posición:";
            // 
            // btnArchivos
            // 
            this.btnArchivos.Location = new System.Drawing.Point(800, 403);
            this.btnArchivos.Name = "btnArchivos";
            this.btnArchivos.Size = new System.Drawing.Size(102, 23);
            this.btnArchivos.TabIndex = 6;
            this.btnArchivos.Text = "Leer Archivos";
            this.btnArchivos.UseVisualStyleBackColor = true;
            this.btnArchivos.Click += new System.EventHandler(this.btnArchivos_Click);
            // 
            // btnDirectorios
            // 
            this.btnDirectorios.Location = new System.Drawing.Point(927, 403);
            this.btnDirectorios.Name = "btnDirectorios";
            this.btnDirectorios.Size = new System.Drawing.Size(104, 23);
            this.btnDirectorios.TabIndex = 7;
            this.btnDirectorios.Text = "Leer Directorios";
            this.btnDirectorios.UseVisualStyleBackColor = true;
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(800, 25);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(231, 329);
            this.lstFiles.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 438);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnDirectorios);
            this.Controls.Add(this.btnArchivos);
            this.Controls.Add(this.lblPosicion);
            this.Controls.Add(this.btnLeerNoticia);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtNoticiaExistente);
            this.Controls.Add(this.lblNoticia);
            this.Controls.Add(this.txtNoticia);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escritor de noticias";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoticia;
        private System.Windows.Forms.Label lblNoticia;
        private System.Windows.Forms.TextBox txtNoticiaExistente;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnLeerNoticia;
        private System.Windows.Forms.Label lblPosicion;
        private System.Windows.Forms.Button btnArchivos;
        private System.Windows.Forms.Button btnDirectorios;
        private System.Windows.Forms.ListBox lstFiles;
    }
}

