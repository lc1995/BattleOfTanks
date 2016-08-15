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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.battleOfTanks = new System.Windows.Forms.Label();
            this.tipMessageBox = new System.Windows.Forms.TextBox();
            this.frameTimer = new System.Windows.Forms.Timer(this.components);
            this.keyTimer = new System.Windows.Forms.Timer(this.components);
            this.itemTimer = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selectWall_0 = new System.Windows.Forms.PictureBox();
            this.selectWall_1 = new System.Windows.Forms.PictureBox();
            this.selectWall_2 = new System.Windows.Forms.PictureBox();
            this.selectWall_3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameScene)).BeginInit();
            this.gameOverPanel.SuspendLayout();
            this.gameStartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectWall_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectWall_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectWall_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectWall_3)).BeginInit();
            this.SuspendLayout();
            // 
            // gameScene
            // 
            this.gameScene.BackColor = System.Drawing.Color.Black;
            this.gameScene.Location = new System.Drawing.Point(13, 13);
            this.gameScene.Name = "gameScene";
            this.gameScene.Size = new System.Drawing.Size(780, 780);
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
            this.gameOverPanel.Location = new System.Drawing.Point(124, 243);
            this.gameOverPanel.Name = "gameOverPanel";
            this.gameOverPanel.Size = new System.Drawing.Size(555, 300);
            this.gameOverPanel.TabIndex = 1;
            this.gameOverPanel.Visible = false;
            // 
            // exitGame
            // 
            this.exitGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitGame.Location = new System.Drawing.Point(370, 196);
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
            this.restartGame.Text = "返回菜单";
            this.restartGame.UseVisualStyleBackColor = true;
            this.restartGame.Click += new System.EventHandler(this.restartGame_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scoreLabel.Location = new System.Drawing.Point(157, 127);
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
            this.gameOverLabel.Location = new System.Drawing.Point(193, 44);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(181, 40);
            this.gameOverLabel.TabIndex = 0;
            this.gameOverLabel.Text = "游戏结束";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gameStartPanel
            // 
            this.gameStartPanel.Controls.Add(this.button4);
            this.gameStartPanel.Controls.Add(this.button3);
            this.gameStartPanel.Controls.Add(this.button2);
            this.gameStartPanel.Controls.Add(this.button1);
            this.gameStartPanel.Controls.Add(this.battleOfTanks);
            this.gameStartPanel.Location = new System.Drawing.Point(218, 194);
            this.gameStartPanel.Name = "gameStartPanel";
            this.gameStartPanel.Size = new System.Drawing.Size(383, 494);
            this.gameStartPanel.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(109, 293);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 70);
            this.button4.TabIndex = 4;
            this.button4.Text = "新建地图";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(109, 369);
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
            this.button2.Click += new System.EventHandler(this.GameBegin);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "单人游戏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GameBegin);
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
            this.tipMessageBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tipMessageBox.ForeColor = System.Drawing.Color.Purple;
            this.tipMessageBox.Location = new System.Drawing.Point(810, 13);
            this.tipMessageBox.Multiline = true;
            this.tipMessageBox.Name = "tipMessageBox";
            this.tipMessageBox.ReadOnly = true;
            this.tipMessageBox.Size = new System.Drawing.Size(353, 761);
            this.tipMessageBox.TabIndex = 3;
            this.tipMessageBox.Text = "按键提示：\r\n玩家1：\r\n方向键控制移动，Num2发射子弹\r\n玩家2：\r\nWSAD控制移动，J键发射子弹\r\n\r\n道具效果：\r\n炸弹 -- 清除所有地方坦克\r\n星星" +
    " -- 升级炮弹，超过3个可以破坏刚墙\r\n定时器 -- 暂停3秒";
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
            // itemTimer
            // 
            this.itemTimer.Interval = 15000;
            this.itemTimer.Tick += new System.EventHandler(this.itemTimer_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(845, 291);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(173, 70);
            this.button5.TabIndex = 4;
            this.button5.Text = "单人游戏";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.GameBeginInMode);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(845, 385);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(173, 70);
            this.button6.TabIndex = 5;
            this.button6.Text = "双人游戏";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.GameBeginInMode);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-23, -46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // selectWall_0
            // 
            this.selectWall_0.Image = global::BattleOfTanks.Properties.Resources.walls;
            this.selectWall_0.Location = new System.Drawing.Point(845, 480);
            this.selectWall_0.Name = "selectWall_0";
            this.selectWall_0.Size = new System.Drawing.Size(60, 60);
            this.selectWall_0.TabIndex = 7;
            this.selectWall_0.TabStop = false;
            this.selectWall_0.Tag = "0";
            this.selectWall_0.Visible = false;
            this.selectWall_0.Click += new System.EventHandler(this.SelectWall);
            // 
            // selectWall_1
            // 
            this.selectWall_1.Image = global::BattleOfTanks.Properties.Resources.steels;
            this.selectWall_1.Location = new System.Drawing.Point(921, 480);
            this.selectWall_1.Name = "selectWall_1";
            this.selectWall_1.Size = new System.Drawing.Size(60, 60);
            this.selectWall_1.TabIndex = 8;
            this.selectWall_1.TabStop = false;
            this.selectWall_1.Tag = "1";
            this.selectWall_1.Visible = false;
            this.selectWall_1.Click += new System.EventHandler(this.SelectWall);
            // 
            // selectWall_2
            // 
            this.selectWall_2.Image = global::BattleOfTanks.Properties.Resources.water;
            this.selectWall_2.Location = new System.Drawing.Point(998, 480);
            this.selectWall_2.Name = "selectWall_2";
            this.selectWall_2.Size = new System.Drawing.Size(60, 60);
            this.selectWall_2.TabIndex = 9;
            this.selectWall_2.TabStop = false;
            this.selectWall_2.Tag = "2";
            this.selectWall_2.Visible = false;
            this.selectWall_2.Click += new System.EventHandler(this.SelectWall);
            // 
            // selectWall_3
            // 
            this.selectWall_3.Image = global::BattleOfTanks.Properties.Resources.grass;
            this.selectWall_3.Location = new System.Drawing.Point(1073, 480);
            this.selectWall_3.Name = "selectWall_3";
            this.selectWall_3.Size = new System.Drawing.Size(60, 60);
            this.selectWall_3.TabIndex = 10;
            this.selectWall_3.TabStop = false;
            this.selectWall_3.Tag = "3";
            this.selectWall_3.Visible = false;
            this.selectWall_3.Click += new System.EventHandler(this.SelectWall);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 800);
            this.Controls.Add(this.gameOverPanel);
            this.Controls.Add(this.selectWall_3);
            this.Controls.Add(this.selectWall_2);
            this.Controls.Add(this.selectWall_1);
            this.Controls.Add(this.selectWall_0);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tipMessageBox);
            this.Controls.Add(this.gameStartPanel);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectWall_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectWall_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectWall_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectWall_3)).EndInit();
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
        private System.Windows.Forms.Timer itemTimer;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox selectWall_0;
        private System.Windows.Forms.PictureBox selectWall_1;
        private System.Windows.Forms.PictureBox selectWall_2;
        private System.Windows.Forms.PictureBox selectWall_3;
    }
}

