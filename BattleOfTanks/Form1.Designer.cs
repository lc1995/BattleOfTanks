namespace BattleOfTanks
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameScene = new System.Windows.Forms.PictureBox();
            this.missileTimer = new System.Windows.Forms.Timer(this.components);
            this.tankTimer = new System.Windows.Forms.Timer(this.components);
            this.tankMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.tankFireTimer = new System.Windows.Forms.Timer(this.components);
            this.gameOverPanel = new System.Windows.Forms.Panel();
            this.exitGame = new System.Windows.Forms.Button();
            this.restartGame = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.gameStartPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.battleOfTanks = new System.Windows.Forms.Label();
            this.tipMessageBox = new System.Windows.Forms.TextBox();
            this.frameTimer = new System.Windows.Forms.Timer(this.components);
            this.keyTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameScene)).BeginInit();
            this.gameOverPanel.SuspendLayout();
            this.gameStartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameScene
            // 
            this.gameScene.BackColor = System.Drawing.Color.Black;
            this.gameScene.Location = new System.Drawing.Point(13, 13);
            this.gameScene.Name = "gameScene";
            this.gameScene.Size = new System.Drawing.Size(600, 600);
            this.gameScene.TabIndex = 0;
            this.gameScene.TabStop = false;
            this.gameScene.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // missileTimer
            // 
            this.missileTimer.Interval = 50;
            this.missileTimer.Tick += new System.EventHandler(this.missileTimer_Tick);
            // 
            // tankTimer
            // 
            this.tankTimer.Interval = 3000;
            this.tankTimer.Tick += new System.EventHandler(this.tankTimer_Tick);
            // 
            // tankMoveTimer
            // 
            this.tankMoveTimer.Tick += new System.EventHandler(this.tankMoveTimer_Tick);
            // 
            // tankFireTimer
            // 
            this.tankFireTimer.Interval = 1500;
            this.tankFireTimer.Tick += new System.EventHandler(this.tankFireTimer_Tick);
            // 
            // gameOverPanel
            // 
            this.gameOverPanel.Controls.Add(this.exitGame);
            this.gameOverPanel.Controls.Add(this.restartGame);
            this.gameOverPanel.Controls.Add(this.scoreLabel);
            this.gameOverPanel.Controls.Add(this.gameOverLabel);
            this.gameOverPanel.Location = new System.Drawing.Point(113, 176);
            this.gameOverPanel.Name = "gameOverPanel";
            this.gameOverPanel.Size = new System.Drawing.Size(400, 300);
            this.gameOverPanel.TabIndex = 1;
            this.gameOverPanel.Visible = false;
            // 
            // exitGame
            // 
            this.exitGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitGame.Location = new System.Drawing.Point(215, 196);
            this.exitGame.Name = "exitGame";
            this.exitGame.Size = new System.Drawing.Size(160, 80);
            this.exitGame.TabIndex = 3;
            this.exitGame.Text = "退出游戏";
            this.exitGame.UseVisualStyleBackColor = true;
            this.exitGame.Click += new System.EventHandler(this.exitGame_Click);
            // 
            // restartGame
            // 
            this.restartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.restartGame.Location = new System.Drawing.Point(28, 196);
            this.restartGame.Name = "restartGame";
            this.restartGame.Size = new System.Drawing.Size(160, 80);
            this.restartGame.TabIndex = 2;
            this.restartGame.Text = "重新开始";
            this.restartGame.UseVisualStyleBackColor = true;
            this.restartGame.Click += new System.EventHandler(this.restartGame_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scoreLabel.Location = new System.Drawing.Point(80, 127);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(180, 27);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "你的得分是：";
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Crimson;
            this.gameOverLabel.Location = new System.Drawing.Point(116, 44);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(181, 40);
            this.gameOverLabel.TabIndex = 0;
            this.gameOverLabel.Text = "游戏结束";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gameStartPanel
            // 
            this.gameStartPanel.Controls.Add(this.button3);
            this.gameStartPanel.Controls.Add(this.button2);
            this.gameStartPanel.Controls.Add(this.button1);
            this.gameStartPanel.Controls.Add(this.battleOfTanks);
            this.gameStartPanel.Location = new System.Drawing.Point(121, 92);
            this.gameStartPanel.Name = "gameStartPanel";
            this.gameStartPanel.Size = new System.Drawing.Size(383, 443);
            this.gameStartPanel.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(109, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 70);
            this.button3.TabIndex = 3;
            this.button3.Text = "退出游戏";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 70);
            this.button2.TabIndex = 2;
            this.button2.Text = "双人游戏";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "单人游戏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // battleOfTanks
            // 
            this.battleOfTanks.AutoSize = true;
            this.battleOfTanks.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.battleOfTanks.Location = new System.Drawing.Point(65, 67);
            this.battleOfTanks.Name = "battleOfTanks";
            this.battleOfTanks.Size = new System.Drawing.Size(264, 40);
            this.battleOfTanks.TabIndex = 0;
            this.battleOfTanks.Text = "坦克大战C#版";
            // 
            // tipMessageBox
            // 
            this.tipMessageBox.BackColor = System.Drawing.Color.DarkGray;
            this.tipMessageBox.Enabled = false;
            this.tipMessageBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipMessageBox.ForeColor = System.Drawing.Color.Purple;
            this.tipMessageBox.Location = new System.Drawing.Point(620, 13);
            this.tipMessageBox.Multiline = true;
            this.tipMessageBox.Name = "tipMessageBox";
            this.tipMessageBox.ReadOnly = true;
            this.tipMessageBox.Size = new System.Drawing.Size(189, 600);
            this.tipMessageBox.TabIndex = 3;
            this.tipMessageBox.Text = "按键提示：\r\n玩家1：\r\n方向键控制移动，Num2发射子弹\r\n玩家2：\r\nWSAD控制移动，J键发射子弹";
            // 
            // frameTimer
            // 
            this.frameTimer.Enabled = true;
            this.frameTimer.Interval = 200;
            this.frameTimer.Tick += new System.EventHandler(this.frameTimer_Tick);
            // 
            // keyTimer
            // 
            this.keyTimer.Interval = 50;
            this.keyTimer.Tick += new System.EventHandler(this.keyTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 625);
            this.Controls.Add(this.tipMessageBox);
            this.Controls.Add(this.gameStartPanel);
            this.Controls.Add(this.gameOverPanel);
            this.Controls.Add(this.gameScene);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameScene)).EndInit();
            this.gameOverPanel.ResumeLayout(false);
            this.gameOverPanel.PerformLayout();
            this.gameStartPanel.ResumeLayout(false);
            this.gameStartPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameScene;
        private System.Windows.Forms.Timer missileTimer;
        private System.Windows.Forms.Timer tankTimer;
        private System.Windows.Forms.Timer tankMoveTimer;
        private System.Windows.Forms.Timer tankFireTimer;
        private System.Windows.Forms.Panel gameOverPanel;
        private System.Windows.Forms.Button exitGame;
        private System.Windows.Forms.Button restartGame;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Panel gameStartPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label battleOfTanks;
        private System.Windows.Forms.TextBox tipMessageBox;
        private System.Windows.Forms.Timer frameTimer;
        private System.Windows.Forms.Timer keyTimer;
    }
}

