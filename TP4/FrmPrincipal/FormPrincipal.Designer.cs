
namespace FrmPrincipal
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Quitar = new System.Windows.Forms.Button();
            this.btn_txt = new System.Windows.Forms.Button();
            this.btn_xml = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btn_LeerArchivoXml = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(172, 31);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(195, 39);
            this.btn_Agregar.TabIndex = 0;
            this.btn_Agregar.Text = "Agregar Producto a Fabrica";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Quitar
            // 
            this.btn_Quitar.Location = new System.Drawing.Point(172, 90);
            this.btn_Quitar.Name = "btn_Quitar";
            this.btn_Quitar.Size = new System.Drawing.Size(195, 39);
            this.btn_Quitar.TabIndex = 1;
            this.btn_Quitar.Text = "Quitar Producto a Fabrica";
            this.btn_Quitar.UseVisualStyleBackColor = true;
            this.btn_Quitar.Click += new System.EventHandler(this.btn_Quitar_Click);
            // 
            // btn_txt
            // 
            this.btn_txt.Location = new System.Drawing.Point(172, 154);
            this.btn_txt.Name = "btn_txt";
            this.btn_txt.Size = new System.Drawing.Size(195, 39);
            this.btn_txt.TabIndex = 2;
            this.btn_txt.Text = "Generar Archivo TXT";
            this.btn_txt.UseVisualStyleBackColor = true;
            this.btn_txt.Click += new System.EventHandler(this.btn_txt_Click);
            // 
            // btn_xml
            // 
            this.btn_xml.Location = new System.Drawing.Point(172, 210);
            this.btn_xml.Name = "btn_xml";
            this.btn_xml.Size = new System.Drawing.Size(195, 39);
            this.btn_xml.TabIndex = 3;
            this.btn_xml.Text = "Generar Archivo XML";
            this.btn_xml.UseVisualStyleBackColor = true;
            this.btn_xml.Click += new System.EventHandler(this.btn_xml_Click);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(172, 327);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(195, 39);
            this.btnStock.TabIndex = 4;
            this.btnStock.Text = "Ver stock ";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btn_LeerArchivoXml
            // 
            this.btn_LeerArchivoXml.Location = new System.Drawing.Point(172, 265);
            this.btn_LeerArchivoXml.Name = "btn_LeerArchivoXml";
            this.btn_LeerArchivoXml.Size = new System.Drawing.Size(195, 39);
            this.btn_LeerArchivoXml.TabIndex = 5;
            this.btn_LeerArchivoXml.Text = "Leer archivo XML";
            this.btn_LeerArchivoXml.UseVisualStyleBackColor = true;
            this.btn_LeerArchivoXml.Click += new System.EventHandler(this.btn_LeerArchivoXml_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(563, 428);
            this.Controls.Add(this.btn_LeerArchivoXml);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btn_xml);
            this.Controls.Add(this.btn_txt);
            this.Controls.Add(this.btn_Quitar);
            this.Controls.Add(this.btn_Agregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgustinFernandezTP3";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Quitar;
        private System.Windows.Forms.Button btn_txt;
        private System.Windows.Forms.Button btn_xml;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btn_LeerArchivoXml;
    }
}

