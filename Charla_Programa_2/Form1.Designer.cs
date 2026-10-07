namespace Charla_Programa_2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnInsegura = new System.Windows.Forms.Button();
            this.btnSegura = new System.Windows.Forms.Button();
            this.btnAtaque = new System.Windows.Forms.Button();
            this.lblConsulta = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.lblResultadoTitulo = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(318, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(191, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Demostracion de SQL Injection";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(36, 78);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(126, 16);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Entrada del Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(39, 110);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(223, 22);
            this.txtUsuario.TabIndex = 2;
            // 
            // btnInsegura
            // 
            this.btnInsegura.Location = new System.Drawing.Point(39, 170);
            this.btnInsegura.Name = "btnInsegura";
            this.btnInsegura.Size = new System.Drawing.Size(140, 23);
            this.btnInsegura.TabIndex = 3;
            this.btnInsegura.Text = "Consulta Insegura";
            this.btnInsegura.UseVisualStyleBackColor = true;
            this.btnInsegura.Click += new System.EventHandler(this.btnInsegura_Click);
            // 
            // btnSegura
            // 
            this.btnSegura.Location = new System.Drawing.Point(185, 170);
            this.btnSegura.Name = "btnSegura";
            this.btnSegura.Size = new System.Drawing.Size(142, 23);
            this.btnSegura.TabIndex = 4;
            this.btnSegura.Text = "Consulta segura";
            this.btnSegura.UseVisualStyleBackColor = true;
            this.btnSegura.Click += new System.EventHandler(this.btnSegura_Click);
            // 
            // btnAtaque
            // 
            this.btnAtaque.Location = new System.Drawing.Point(77, 208);
            this.btnAtaque.Name = "btnAtaque";
            this.btnAtaque.Size = new System.Drawing.Size(195, 23);
            this.btnAtaque.TabIndex = 5;
            this.btnAtaque.Text = "Cargar Ataque de Ejemplo";
            this.btnAtaque.UseVisualStyleBackColor = true;
            this.btnAtaque.Click += new System.EventHandler(this.btnAtaque_Click);
            // 
            // lblConsulta
            // 
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Location = new System.Drawing.Point(36, 294);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(124, 16);
            this.lblConsulta.TabIndex = 6;
            this.lblConsulta.Text = "Consulta generada:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(39, 324);
            this.txtConsulta.Multiline = true;
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.ReadOnly = true;
            this.txtConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsulta.Size = new System.Drawing.Size(312, 89);
            this.txtConsulta.TabIndex = 8;
            // 
            // lblResultadoTitulo
            // 
            this.lblResultadoTitulo.AutoSize = true;
            this.lblResultadoTitulo.Location = new System.Drawing.Point(487, 294);
            this.lblResultadoTitulo.Name = "lblResultadoTitulo";
            this.lblResultadoTitulo.Size = new System.Drawing.Size(75, 16);
            this.lblResultadoTitulo.TabIndex = 9;
            this.lblResultadoTitulo.Text = "Resultado: ";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(487, 324);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(185, 16);
            this.lblResultado.TabIndex = 10;
            this.lblResultado.Text = "Aqui aparecera la explicacion";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblResultadoTitulo);
            this.Controls.Add(this.txtConsulta);
            this.Controls.Add(this.lblConsulta);
            this.Controls.Add(this.btnAtaque);
            this.Controls.Add(this.btnSegura);
            this.Controls.Add(this.btnInsegura);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnInsegura;
        private System.Windows.Forms.Button btnSegura;
        private System.Windows.Forms.Button btnAtaque;
        private System.Windows.Forms.Label lblConsulta;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Label lblResultadoTitulo;
        private System.Windows.Forms.Label lblResultado;
    }
}

