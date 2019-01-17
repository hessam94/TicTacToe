namespace TicToc
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
            this.components = new System.ComponentModel.Container();
            this.bt_status = new System.Windows.Forms.Button();
            this.bt_deploy = new System.Windows.Forms.Button();
            this.SetBet = new System.Windows.Forms.Button();
            this.tx_bet = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.combo_Contract = new System.Windows.Forms.ComboBox();
            this.bt_address = new System.Windows.Forms.Button();
            this.bt_addplayer = new System.Windows.Forms.Button();
            this.dg_file = new System.Windows.Forms.OpenFileDialog();
            this.bt_accfile = new System.Windows.Forms.Button();
            this.pnl_Board = new System.Windows.Forms.TableLayoutPanel();
            this.bt_22 = new System.Windows.Forms.Button();
            this.bt_21 = new System.Windows.Forms.Button();
            this.bt_20 = new System.Windows.Forms.Button();
            this.bt_12 = new System.Windows.Forms.Button();
            this.bt_11 = new System.Windows.Forms.Button();
            this.bt_10 = new System.Windows.Forms.Button();
            this.bt_02 = new System.Windows.Forms.Button();
            this.bt_01 = new System.Windows.Forms.Button();
            this.bt_00 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bt_init = new System.Windows.Forms.Button();
            this.pn_contract = new System.Windows.Forms.Panel();
            this.pn_player = new System.Windows.Forms.Panel();
            this.pn_bet = new System.Windows.Forms.Panel();
            this.pn_info = new System.Windows.Forms.Panel();
            this.bt_balance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tx_bet)).BeginInit();
            this.pnl_Board.SuspendLayout();
            this.pn_contract.SuspendLayout();
            this.pn_player.SuspendLayout();
            this.pn_bet.SuspendLayout();
            this.pn_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_status
            // 
            this.bt_status.Location = new System.Drawing.Point(261, 12);
            this.bt_status.Name = "bt_status";
            this.bt_status.Size = new System.Drawing.Size(115, 52);
            this.bt_status.TabIndex = 0;
            this.bt_status.Text = "GameStatus";
            this.bt_status.UseVisualStyleBackColor = true;
            this.bt_status.Click += new System.EventHandler(this.bt_status_Click);
            // 
            // bt_deploy
            // 
            this.bt_deploy.Location = new System.Drawing.Point(24, 533);
            this.bt_deploy.Name = "bt_deploy";
            this.bt_deploy.Size = new System.Drawing.Size(182, 25);
            this.bt_deploy.TabIndex = 1;
            this.bt_deploy.Text = "Deploy";
            this.bt_deploy.UseVisualStyleBackColor = true;
            this.bt_deploy.Visible = false;
            this.bt_deploy.Click += new System.EventHandler(this.bt_deploy_Click);
            // 
            // SetBet
            // 
            this.SetBet.Location = new System.Drawing.Point(16, 16);
            this.SetBet.Name = "SetBet";
            this.SetBet.Size = new System.Drawing.Size(182, 70);
            this.SetBet.TabIndex = 2;
            this.SetBet.Text = "SetBet";
            this.SetBet.UseVisualStyleBackColor = true;
            this.SetBet.Click += new System.EventHandler(this.SetBet_Click);
            // 
            // tx_bet
            // 
            this.tx_bet.Location = new System.Drawing.Point(235, 16);
            this.tx_bet.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tx_bet.Name = "tx_bet";
            this.tx_bet.Size = new System.Drawing.Size(131, 26);
            this.tx_bet.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "GetBetAmount";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // combo_Contract
            // 
            this.combo_Contract.FormattingEnabled = true;
            this.combo_Contract.Location = new System.Drawing.Point(12, 13);
            this.combo_Contract.Name = "combo_Contract";
            this.combo_Contract.Size = new System.Drawing.Size(486, 28);
            this.combo_Contract.TabIndex = 6;
            this.combo_Contract.Text = "Choose Contract Address";
            this.combo_Contract.SelectedIndexChanged += new System.EventHandler(this.combo_Contract_SelectedIndexChanged);
            // 
            // bt_address
            // 
            this.bt_address.Location = new System.Drawing.Point(16, 12);
            this.bt_address.Name = "bt_address";
            this.bt_address.Size = new System.Drawing.Size(109, 52);
            this.bt_address.TabIndex = 7;
            this.bt_address.Text = "GetAddress";
            this.bt_address.UseVisualStyleBackColor = true;
            this.bt_address.Click += new System.EventHandler(this.bt_address_Click);
            // 
            // bt_addplayer
            // 
            this.bt_addplayer.Location = new System.Drawing.Point(14, 15);
            this.bt_addplayer.Name = "bt_addplayer";
            this.bt_addplayer.Size = new System.Drawing.Size(486, 70);
            this.bt_addplayer.TabIndex = 8;
            this.bt_addplayer.Text = "AddPlayer";
            this.bt_addplayer.UseVisualStyleBackColor = true;
            this.bt_addplayer.Click += new System.EventHandler(this.bt_addplayer_Click);
            // 
            // dg_file
            // 
            this.dg_file.FileName = "openFileDialog1";
            // 
            // bt_accfile
            // 
            this.bt_accfile.Enabled = false;
            this.bt_accfile.Location = new System.Drawing.Point(12, 47);
            this.bt_accfile.Name = "bt_accfile";
            this.bt_accfile.Size = new System.Drawing.Size(486, 34);
            this.bt_accfile.TabIndex = 10;
            this.bt_accfile.Text = "ChooseAccount";
            this.bt_accfile.UseVisualStyleBackColor = true;
            this.bt_accfile.Click += new System.EventHandler(this.bt_accfile_Click);
            // 
            // pnl_Board
            // 
            this.pnl_Board.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_Board.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.pnl_Board.ColumnCount = 3;
            this.pnl_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnl_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.pnl_Board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.pnl_Board.Controls.Add(this.bt_22, 2, 2);
            this.pnl_Board.Controls.Add(this.bt_21, 1, 2);
            this.pnl_Board.Controls.Add(this.bt_20, 0, 2);
            this.pnl_Board.Controls.Add(this.bt_12, 2, 1);
            this.pnl_Board.Controls.Add(this.bt_11, 1, 1);
            this.pnl_Board.Controls.Add(this.bt_10, 0, 1);
            this.pnl_Board.Controls.Add(this.bt_02, 2, 0);
            this.pnl_Board.Controls.Add(this.bt_01, 1, 0);
            this.pnl_Board.Controls.Add(this.bt_00, 0, 0);
            this.pnl_Board.Enabled = false;
            this.pnl_Board.Location = new System.Drawing.Point(832, 158);
            this.pnl_Board.Name = "pnl_Board";
            this.pnl_Board.RowCount = 3;
            this.pnl_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnl_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnl_Board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnl_Board.Size = new System.Drawing.Size(400, 400);
            this.pnl_Board.TabIndex = 11;
            // 
            // bt_22
            // 
            this.bt_22.Location = new System.Drawing.Point(270, 270);
            this.bt_22.Name = "bt_22";
            this.bt_22.Size = new System.Drawing.Size(124, 121);
            this.bt_22.TabIndex = 8;
            this.bt_22.Tag = "2_2";
            this.bt_22.UseVisualStyleBackColor = true;
            this.bt_22.Click += new System.EventHandler(this.bt_22_Click);
            // 
            // bt_21
            // 
            this.bt_21.Location = new System.Drawing.Point(138, 270);
            this.bt_21.Name = "bt_21";
            this.bt_21.Size = new System.Drawing.Size(123, 121);
            this.bt_21.TabIndex = 7;
            this.bt_21.Tag = "2_1";
            this.bt_21.UseVisualStyleBackColor = true;
            this.bt_21.Click += new System.EventHandler(this.bt_21_Click);
            // 
            // bt_20
            // 
            this.bt_20.Location = new System.Drawing.Point(6, 270);
            this.bt_20.Name = "bt_20";
            this.bt_20.Size = new System.Drawing.Size(123, 121);
            this.bt_20.TabIndex = 6;
            this.bt_20.Tag = "2_0";
            this.bt_20.UseVisualStyleBackColor = true;
            this.bt_20.Click += new System.EventHandler(this.bt_20_Click);
            // 
            // bt_12
            // 
            this.bt_12.Location = new System.Drawing.Point(270, 138);
            this.bt_12.Name = "bt_12";
            this.bt_12.Size = new System.Drawing.Size(124, 123);
            this.bt_12.TabIndex = 5;
            this.bt_12.Tag = "1_2";
            this.bt_12.UseVisualStyleBackColor = true;
            this.bt_12.Click += new System.EventHandler(this.bt_12_Click);
            // 
            // bt_11
            // 
            this.bt_11.Location = new System.Drawing.Point(138, 138);
            this.bt_11.Name = "bt_11";
            this.bt_11.Size = new System.Drawing.Size(123, 123);
            this.bt_11.TabIndex = 4;
            this.bt_11.Tag = "1_1";
            this.bt_11.UseVisualStyleBackColor = true;
            this.bt_11.Click += new System.EventHandler(this.bt_11_Click);
            // 
            // bt_10
            // 
            this.bt_10.Location = new System.Drawing.Point(6, 138);
            this.bt_10.Name = "bt_10";
            this.bt_10.Size = new System.Drawing.Size(123, 123);
            this.bt_10.TabIndex = 3;
            this.bt_10.Tag = "1_0";
            this.bt_10.UseVisualStyleBackColor = true;
            this.bt_10.Click += new System.EventHandler(this.bt_10_Click);
            // 
            // bt_02
            // 
            this.bt_02.Location = new System.Drawing.Point(270, 6);
            this.bt_02.Name = "bt_02";
            this.bt_02.Size = new System.Drawing.Size(124, 123);
            this.bt_02.TabIndex = 2;
            this.bt_02.Tag = "0_2";
            this.bt_02.UseVisualStyleBackColor = true;
            this.bt_02.Click += new System.EventHandler(this.bt_02_Click);
            // 
            // bt_01
            // 
            this.bt_01.Location = new System.Drawing.Point(138, 6);
            this.bt_01.Name = "bt_01";
            this.bt_01.Size = new System.Drawing.Size(123, 123);
            this.bt_01.TabIndex = 1;
            this.bt_01.Tag = "0_1";
            this.bt_01.UseVisualStyleBackColor = true;
            this.bt_01.Click += new System.EventHandler(this.bt_01_Click);
            // 
            // bt_00
            // 
            this.bt_00.Location = new System.Drawing.Point(6, 6);
            this.bt_00.Name = "bt_00";
            this.bt_00.Size = new System.Drawing.Size(123, 123);
            this.bt_00.TabIndex = 0;
            this.bt_00.Tag = "0_0";
            this.bt_00.UseVisualStyleBackColor = true;
            this.bt_00.Click += new System.EventHandler(this.bt_00_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bt_init
            // 
            this.bt_init.Location = new System.Drawing.Point(832, 40);
            this.bt_init.Name = "bt_init";
            this.bt_init.Size = new System.Drawing.Size(394, 52);
            this.bt_init.TabIndex = 12;
            this.bt_init.Text = "Init";
            this.bt_init.UseVisualStyleBackColor = true;
            this.bt_init.Click += new System.EventHandler(this.bt_init_Click);
            // 
            // pn_contract
            // 
            this.pn_contract.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_contract.Controls.Add(this.combo_Contract);
            this.pn_contract.Controls.Add(this.bt_accfile);
            this.pn_contract.Location = new System.Drawing.Point(24, 38);
            this.pn_contract.Name = "pn_contract";
            this.pn_contract.Size = new System.Drawing.Size(518, 100);
            this.pn_contract.TabIndex = 13;
            // 
            // pn_player
            // 
            this.pn_player.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_player.Controls.Add(this.bt_addplayer);
            this.pn_player.Enabled = false;
            this.pn_player.Location = new System.Drawing.Point(24, 158);
            this.pn_player.Name = "pn_player";
            this.pn_player.Size = new System.Drawing.Size(518, 103);
            this.pn_player.TabIndex = 14;
            // 
            // pn_bet
            // 
            this.pn_bet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_bet.Controls.Add(this.SetBet);
            this.pn_bet.Controls.Add(this.tx_bet);
            this.pn_bet.Enabled = false;
            this.pn_bet.Location = new System.Drawing.Point(24, 296);
            this.pn_bet.Name = "pn_bet";
            this.pn_bet.Size = new System.Drawing.Size(518, 100);
            this.pn_bet.TabIndex = 15;
            // 
            // pn_info
            // 
            this.pn_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pn_info.Controls.Add(this.bt_balance);
            this.pn_info.Controls.Add(this.bt_address);
            this.pn_info.Controls.Add(this.button1);
            this.pn_info.Controls.Add(this.bt_status);
            this.pn_info.Location = new System.Drawing.Point(24, 428);
            this.pn_info.Name = "pn_info";
            this.pn_info.Size = new System.Drawing.Size(518, 97);
            this.pn_info.TabIndex = 16;
            // 
            // bt_balance
            // 
            this.bt_balance.Location = new System.Drawing.Point(391, 12);
            this.bt_balance.Name = "bt_balance";
            this.bt_balance.Size = new System.Drawing.Size(109, 52);
            this.bt_balance.TabIndex = 8;
            this.bt_balance.Text = "GetBalance";
            this.bt_balance.UseVisualStyleBackColor = true;
            this.bt_balance.Click += new System.EventHandler(this.bt_balance_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 580);
            this.Controls.Add(this.pn_info);
            this.Controls.Add(this.pn_bet);
            this.Controls.Add(this.pn_player);
            this.Controls.Add(this.pn_contract);
            this.Controls.Add(this.bt_init);
            this.Controls.Add(this.pnl_Board);
            this.Controls.Add(this.bt_deploy);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tx_bet)).EndInit();
            this.pnl_Board.ResumeLayout(false);
            this.pn_contract.ResumeLayout(false);
            this.pn_player.ResumeLayout(false);
            this.pn_bet.ResumeLayout(false);
            this.pn_info.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_status;
        private System.Windows.Forms.Button bt_deploy;
        private System.Windows.Forms.Button SetBet;
        private System.Windows.Forms.NumericUpDown tx_bet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combo_Contract;
        private System.Windows.Forms.Button bt_address;
        private System.Windows.Forms.Button bt_addplayer;
        private System.Windows.Forms.OpenFileDialog dg_file;
        private System.Windows.Forms.Button bt_accfile;
        private System.Windows.Forms.TableLayoutPanel pnl_Board;
        private System.Windows.Forms.Button bt_22;
        private System.Windows.Forms.Button bt_21;
        private System.Windows.Forms.Button bt_20;
        private System.Windows.Forms.Button bt_12;
        private System.Windows.Forms.Button bt_11;
        private System.Windows.Forms.Button bt_10;
        private System.Windows.Forms.Button bt_02;
        private System.Windows.Forms.Button bt_01;
        private System.Windows.Forms.Button bt_00;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_init;
        private System.Windows.Forms.Panel pn_contract;
        private System.Windows.Forms.Panel pn_player;
        private System.Windows.Forms.Panel pn_bet;
        private System.Windows.Forms.Panel pn_info;
        private System.Windows.Forms.Button bt_balance;
    }
}

