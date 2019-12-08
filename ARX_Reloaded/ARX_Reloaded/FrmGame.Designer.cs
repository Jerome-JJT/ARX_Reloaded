﻿namespace ARX_Reloaded
{
    partial class FrmGame
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdGenNormal = new System.Windows.Forms.Button();
            this.picView = new System.Windows.Forms.PictureBox();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.cmdGenChaos = new System.Windows.Forms.Button();
            this.cmdUpdateView = new System.Windows.Forms.Button();
            this.chkPacmanMoves = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGenNormal
            // 
            this.cmdGenNormal.Location = new System.Drawing.Point(618, 1);
            this.cmdGenNormal.Name = "cmdGenNormal";
            this.cmdGenNormal.Size = new System.Drawing.Size(120, 23);
            this.cmdGenNormal.TabIndex = 0;
            this.cmdGenNormal.Text = "Generate normal";
            this.cmdGenNormal.UseVisualStyleBackColor = true;
            this.cmdGenNormal.Click += new System.EventHandler(this.cmdGenNormal_Click);
            // 
            // picView
            // 
            this.picView.BackColor = System.Drawing.Color.White;
            this.picView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picView.Location = new System.Drawing.Point(12, 26);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(600, 600);
            this.picView.TabIndex = 1;
            this.picView.TabStop = false;
            this.picView.Paint += new System.Windows.Forms.PaintEventHandler(this.picView_Paint);
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.Color.Black;
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.Location = new System.Drawing.Point(618, 26);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(600, 600);
            this.picMap.TabIndex = 2;
            this.picMap.TabStop = false;
            this.picMap.Paint += new System.Windows.Forms.PaintEventHandler(this.picMap_Paint);
            // 
            // cmdGenChaos
            // 
            this.cmdGenChaos.Location = new System.Drawing.Point(742, 1);
            this.cmdGenChaos.Name = "cmdGenChaos";
            this.cmdGenChaos.Size = new System.Drawing.Size(120, 23);
            this.cmdGenChaos.TabIndex = 3;
            this.cmdGenChaos.Text = "Generate chaotique";
            this.cmdGenChaos.UseVisualStyleBackColor = true;
            this.cmdGenChaos.Click += new System.EventHandler(this.cmdGenChaos_Click);
            // 
            // cmdUpdateView
            // 
            this.cmdUpdateView.Location = new System.Drawing.Point(12, 1);
            this.cmdUpdateView.Name = "cmdUpdateView";
            this.cmdUpdateView.Size = new System.Drawing.Size(120, 23);
            this.cmdUpdateView.TabIndex = 4;
            this.cmdUpdateView.Text = "Update view";
            this.cmdUpdateView.UseVisualStyleBackColor = true;
            this.cmdUpdateView.Click += new System.EventHandler(this.cmdUpdateView_Click);
            // 
            // chkPacmanMoves
            // 
            this.chkPacmanMoves.AutoSize = true;
            this.chkPacmanMoves.Location = new System.Drawing.Point(869, 5);
            this.chkPacmanMoves.Name = "chkPacmanMoves";
            this.chkPacmanMoves.Size = new System.Drawing.Size(99, 17);
            this.chkPacmanMoves.TabIndex = 5;
            this.chkPacmanMoves.Text = "Pacman moves";
            this.chkPacmanMoves.UseVisualStyleBackColor = true;
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 660);
            this.Controls.Add(this.chkPacmanMoves);
            this.Controls.Add(this.cmdUpdateView);
            this.Controls.Add(this.cmdGenChaos);
            this.Controls.Add(this.picMap);
            this.Controls.Add(this.picView);
            this.Controls.Add(this.cmdGenNormal);
            this.KeyPreview = true;
            this.Name = "FrmGame";
            this.Text = "ARX Reloaded";
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmGame_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGenNormal;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Button cmdGenChaos;
        private System.Windows.Forms.Button cmdUpdateView;
        private System.Windows.Forms.CheckBox chkPacmanMoves;
    }
}

