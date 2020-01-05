namespace ARX_Reloaded
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
            this.picView = new System.Windows.Forms.PictureBox();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.cmdShowView = new System.Windows.Forms.Button();
            this.chkPacmanMoves = new System.Windows.Forms.CheckBox();
            this.lblStageScore = new System.Windows.Forms.Label();
            this.lblCoinScore = new System.Windows.Forms.Label();
            this.cmdReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // picView
            // 
            this.picView.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.picMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picMap.BackColor = System.Drawing.Color.Black;
            this.picMap.Location = new System.Drawing.Point(618, 26);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(600, 600);
            this.picMap.TabIndex = 2;
            this.picMap.TabStop = false;
            this.picMap.Paint += new System.Windows.Forms.PaintEventHandler(this.picMap_Paint);
            // 
            // cmdShowView
            // 
            this.cmdShowView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdShowView.Location = new System.Drawing.Point(969, 1);
            this.cmdShowView.Name = "cmdShowView";
            this.cmdShowView.Size = new System.Drawing.Size(120, 23);
            this.cmdShowView.TabIndex = 7;
            this.cmdShowView.Text = "Afficher map";
            this.cmdShowView.UseVisualStyleBackColor = true;
            this.cmdShowView.Click += new System.EventHandler(this.cmdUpdateView_Click);
            // 
            // chkPacmanMoves
            // 
            this.chkPacmanMoves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPacmanMoves.AutoSize = true;
            this.chkPacmanMoves.Checked = true;
            this.chkPacmanMoves.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPacmanMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPacmanMoves.Location = new System.Drawing.Point(840, 2);
            this.chkPacmanMoves.Name = "chkPacmanMoves";
            this.chkPacmanMoves.Size = new System.Drawing.Size(123, 21);
            this.chkPacmanMoves.TabIndex = 6;
            this.chkPacmanMoves.Text = "Pacman moves";
            this.chkPacmanMoves.UseVisualStyleBackColor = true;
            // 
            // lblStageScore
            // 
            this.lblStageScore.AutoSize = true;
            this.lblStageScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStageScore.Location = new System.Drawing.Point(23, 5);
            this.lblStageScore.Name = "lblStageScore";
            this.lblStageScore.Size = new System.Drawing.Size(65, 17);
            this.lblStageScore.TabIndex = 8;
            this.lblStageScore.Text = "Étage : 0";
            // 
            // lblCoinScore
            // 
            this.lblCoinScore.AutoSize = true;
            this.lblCoinScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinScore.Location = new System.Drawing.Point(112, 5);
            this.lblCoinScore.Name = "lblCoinScore";
            this.lblCoinScore.Size = new System.Drawing.Size(67, 17);
            this.lblCoinScore.TabIndex = 9;
            this.lblCoinScore.Text = "Points : 0";
            // 
            // cmdReset
            // 
            this.cmdReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReset.Location = new System.Drawing.Point(1095, 2);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(120, 23);
            this.cmdReset.TabIndex = 10;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 660);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.lblCoinScore);
            this.Controls.Add(this.lblStageScore);
            this.Controls.Add(this.chkPacmanMoves);
            this.Controls.Add(this.cmdShowView);
            this.Controls.Add(this.picMap);
            this.Controls.Add(this.picView);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(730, 440);
            this.Name = "FrmGame";
            this.Text = "ARX Reloaded";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGame_FormClosing);
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.SizeChanged += new System.EventHandler(this.FrmGame_SizeChanged);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmGame_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.Button cmdShowView;
        private System.Windows.Forms.CheckBox chkPacmanMoves;
        private System.Windows.Forms.Label lblStageScore;
        private System.Windows.Forms.Label lblCoinScore;
        private System.Windows.Forms.Button cmdReset;
    }
}

