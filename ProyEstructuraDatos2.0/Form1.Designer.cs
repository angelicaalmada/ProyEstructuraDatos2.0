namespace Proy_EstructuraDatos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            btnColas = new Button();
            btnPilas = new Button();
            btnLista = new Button();
            btnMatrices = new Button();
            panelLogo = new Panel();
            pcLogo = new PictureBox();
            panel1 = new Panel();
            Pilas = new Label();
            label1 = new Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcLogo).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ScrollBar;
            panelMenu.Controls.Add(btnColas);
            panelMenu.Controls.Add(btnPilas);
            panelMenu.Controls.Add(btnLista);
            panelMenu.Controls.Add(btnMatrices);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(311, 656);
            panelMenu.TabIndex = 0;
            // 
            // btnColas
            // 
            btnColas.FlatAppearance.BorderSize = 0;
            btnColas.FlatStyle = FlatStyle.Flat;
            btnColas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnColas.ForeColor = SystemColors.HotTrack;
            btnColas.Location = new Point(37, 295);
            btnColas.Name = "btnColas";
            btnColas.Size = new Size(202, 45);
            btnColas.TabIndex = 4;
            btnColas.Text = "Colas";
            btnColas.UseVisualStyleBackColor = true;
            btnColas.Click += btnColas_Click;
            // 
            // btnPilas
            // 
            btnPilas.FlatAppearance.BorderSize = 0;
            btnPilas.FlatStyle = FlatStyle.Flat;
            btnPilas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPilas.ForeColor = SystemColors.HotTrack;
            btnPilas.Location = new Point(37, 244);
            btnPilas.Name = "btnPilas";
            btnPilas.Size = new Size(202, 45);
            btnPilas.TabIndex = 3;
            btnPilas.Text = "Pilas";
            btnPilas.UseVisualStyleBackColor = true;
            btnPilas.Click += btnPilas_Click;
            // 
            // btnLista
            // 
            btnLista.FlatAppearance.BorderSize = 0;
            btnLista.FlatStyle = FlatStyle.Flat;
            btnLista.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLista.ForeColor = SystemColors.HotTrack;
            btnLista.Location = new Point(37, 193);
            btnLista.Name = "btnLista";
            btnLista.Size = new Size(202, 45);
            btnLista.TabIndex = 2;
            btnLista.Text = "Lista Simplemente Enlazada";
            btnLista.UseVisualStyleBackColor = true;
            btnLista.Click += button2_Click;
            // 
            // btnMatrices
            // 
            btnMatrices.FlatAppearance.BorderSize = 0;
            btnMatrices.FlatStyle = FlatStyle.Flat;
            btnMatrices.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMatrices.ForeColor = SystemColors.HotTrack;
            btnMatrices.Location = new Point(37, 142);
            btnMatrices.Name = "btnMatrices";
            btnMatrices.Size = new Size(202, 45);
            btnMatrices.TabIndex = 1;
            btnMatrices.Text = "Matrices";
            btnMatrices.UseVisualStyleBackColor = true;
            btnMatrices.Click += button1_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(pcLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(311, 124);
            panelLogo.TabIndex = 0;
            // 
            // pcLogo
            // 
            pcLogo.Location = new Point(0, 0);
            pcLogo.Name = "pcLogo";
            pcLogo.Size = new Size(100, 50);
            pcLogo.TabIndex = 0;
            pcLogo.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(Pilas);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(311, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1043, 656);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // Pilas
            // 
            Pilas.AutoSize = true;
            Pilas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Pilas.ForeColor = SystemColors.ActiveCaptionText;
            Pilas.Location = new Point(422, 225);
            Pilas.Name = "Pilas";
            Pilas.Size = new Size(312, 32);
            Pilas.TabIndex = 2;
            Pilas.Text = "Elija una opcion en el menu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(432, 70);
            label1.Name = "label1";
            label1.Size = new Size(293, 54);
            label1.TabIndex = 0;
            label1.Text = "BIENVENIDO/A";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1354, 656);
            Controls.Add(panel1);
            Controls.Add(panelMenu);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panel1;
        private Panel panelLogo;
        private PictureBox pcLogo;
        private Button btnMatrices;
        private Button btnColas;
        private Button btnPilas;
        private Button btnLista;
        private Label label1;
        private Label Pilas;
    }
}