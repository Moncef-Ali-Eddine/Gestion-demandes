namespace Test
{
    partial class Demandeurs
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_demandes = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(187, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(517, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "Veuillez saisir l\'article(s) a demander:  ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_demandes
            // 
            this.txt_demandes.Location = new System.Drawing.Point(256, 90);
            this.txt_demandes.Name = "txt_demandes";
            this.txt_demandes.Size = new System.Drawing.Size(332, 129);
            this.txt_demandes.TabIndex = 9;
            this.txt_demandes.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "Retour";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "Confirmer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Demandeurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_demandes);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Demandeurs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demandeurs";
            this.Load += new System.EventHandler(this.Demandeurs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txt_demandes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}