namespace XXQGAns
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ocrbtn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.ocrout = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.stopCastButton = new System.Windows.Forms.Button();
            this.startCastButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.daannum = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.state = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.inputtext = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.newans = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.newop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.newques = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.heartTimer = new System.Windows.Forms.Timer(this.components);
            this.screenBox = new System.Windows.Forms.Panel();
            this.nosigalLabel = new System.Windows.Forms.Label();
            this.startCastSingleButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.screenBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(911, 677);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.ocrbtn);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.ocrout);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.stopCastButton);
            this.tabPage1.Controls.Add(this.startCastButton);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.daannum);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.search);
            this.tabPage1.Controls.Add(this.inputtext);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(903, 651);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "挑战答题题库";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(234, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(392, 34);
            this.label15.TabIndex = 18;
            this.label15.Text = "识别结果已经复制到剪贴板！\r\n请尽量选择无标点及特殊符号的关键词进行识别！否则容易无法匹配题库";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(715, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "message";
            // 
            // ocrbtn
            // 
            this.ocrbtn.Location = new System.Drawing.Point(706, 63);
            this.ocrbtn.Name = "ocrbtn";
            this.ocrbtn.Size = new System.Drawing.Size(62, 88);
            this.ocrbtn.TabIndex = 16;
            this.ocrbtn.Text = "截取屏幕\r\nAlt + A\r\n";
            this.ocrbtn.UseVisualStyleBackColor = true;
            this.ocrbtn.Click += new System.EventHandler(this.ocrbtn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(101, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "OCR结果：";
            // 
            // ocrout
            // 
            this.ocrout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ocrout.Location = new System.Drawing.Point(173, 69);
            this.ocrout.Name = "ocrout";
            this.ocrout.Size = new System.Drawing.Size(504, 29);
            this.ocrout.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(885, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "->";
            // 
            // stopCastButton
            // 
            this.stopCastButton.Location = new System.Drawing.Point(775, 111);
            this.stopCastButton.Name = "stopCastButton";
            this.stopCastButton.Size = new System.Drawing.Size(112, 40);
            this.stopCastButton.TabIndex = 13;
            this.stopCastButton.Text = "结束投屏";
            this.stopCastButton.UseVisualStyleBackColor = true;
            this.stopCastButton.Click += new System.EventHandler(this.stopCastButton_Click);
            // 
            // startCastButton
            // 
            this.startCastButton.Location = new System.Drawing.Point(775, 63);
            this.startCastButton.Name = "startCastButton";
            this.startCastButton.Size = new System.Drawing.Size(111, 40);
            this.startCastButton.TabIndex = 11;
            this.startCastButton.Text = "连接投屏";
            this.startCastButton.UseVisualStyleBackColor = true;
            this.startCastButton.Click += new System.EventHandler(this.startCastButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 36);
            this.button2.TabIndex = 10;
            this.button2.Text = "刷新题库";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // daannum
            // 
            this.daannum.AutoSize = true;
            this.daannum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.daannum.Location = new System.Drawing.Point(113, 150);
            this.daannum.Name = "daannum";
            this.daannum.Size = new System.Drawing.Size(11, 12);
            this.daannum.TabIndex = 9;
            this.daannum.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "当前题库题目数：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.state);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接状态";
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.state.ForeColor = System.Drawing.Color.Red;
            this.state.Location = new System.Drawing.Point(20, 20);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(56, 16);
            this.state.TabIndex = 7;
            this.state.Text = "未连接";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 10);
            this.label2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(6, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowTemplate.Height = 42;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(891, 470);
            this.dataGridView1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(103, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入问题：";
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.search.Location = new System.Drawing.Point(775, 6);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(112, 47);
            this.search.TabIndex = 2;
            this.search.Text = "搜索";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // inputtext
            // 
            this.inputtext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputtext.Location = new System.Drawing.Point(173, 6);
            this.inputtext.Name = "inputtext";
            this.inputtext.Size = new System.Drawing.Size(598, 29);
            this.inputtext.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.newans);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.newop);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.newques);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(903, 651);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "提交问题";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(92, 364);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(278, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "请勿随意提交无谓的数据！！！";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Tomato;
            this.label8.Location = new System.Drawing.Point(4, 437);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 10);
            this.label8.TabIndex = 9;
            this.label8.Text = "当前待处理题目数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Fuchsia;
            this.label7.Location = new System.Drawing.Point(100, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(93, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(376, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "可在此页面提交数据库未收录的题目及答案至数据库\r\n作者审核题目后添加题目至正式数据库";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(765, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "提交至数据库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(29, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "答案";
            // 
            // newans
            // 
            this.newans.Location = new System.Drawing.Point(96, 232);
            this.newans.Name = "newans";
            this.newans.Size = new System.Drawing.Size(775, 21);
            this.newans.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(29, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "选项";
            // 
            // newop
            // 
            this.newop.Location = new System.Drawing.Point(96, 118);
            this.newop.Name = "newop";
            this.newop.Size = new System.Drawing.Size(775, 21);
            this.newop.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "问题";
            // 
            // newques
            // 
            this.newques.Location = new System.Drawing.Point(96, 18);
            this.newques.Name = "newques";
            this.newques.Size = new System.Drawing.Size(775, 21);
            this.newques.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(903, 651);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "说明";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(26, 213);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(665, 105);
            this.label16.TabIndex = 1;
            this.label16.Text = "打开手机，开发者选项，打开USB调试，数据线连接，弹窗提示调试设备允许，方可连接手机\r\n如无法连接，尝试打开USB调试（安全设置）或联系作者反馈\r\n苹果手机使用i" +
    "Tools连接投屏一样可以使用软件内置截屏OCR\r\n\r\n测试机型：Redmi K20 Pro/Oneplus 3/荣耀8X/Redmi Note8 Pro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label10.Location = new System.Drawing.Point(28, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(334, 126);
            this.label10.TabIndex = 0;
            this.label10.Text = "软件名称：学习强国挑战答题神器\r\n程序版本：2.0\r\n构建日期：2020.03.28\r\n作者;SummerLotus（吾爱ID：君莫笑WXH）\r\n官网：https" +
    "://qg.zyqq.top/(单击即可访问)\r\n题库来源：互联网+不定时更新\r\n";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // heartTimer
            // 
            this.heartTimer.Interval = 1000;
            this.heartTimer.Tick += new System.EventHandler(this.HeartTimer_Tick);
            // 
            // screenBox
            // 
            this.screenBox.BackColor = System.Drawing.Color.Black;
            this.screenBox.Controls.Add(this.nosigalLabel);
            this.screenBox.Location = new System.Drawing.Point(914, 23);
            this.screenBox.Name = "screenBox";
            this.screenBox.Size = new System.Drawing.Size(348, 655);
            this.screenBox.TabIndex = 14;
            // 
            // nosigalLabel
            // 
            this.nosigalLabel.BackColor = System.Drawing.Color.Transparent;
            this.nosigalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nosigalLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nosigalLabel.ForeColor = System.Drawing.Color.White;
            this.nosigalLabel.Location = new System.Drawing.Point(0, 0);
            this.nosigalLabel.Name = "nosigalLabel";
            this.nosigalLabel.Size = new System.Drawing.Size(348, 655);
            this.nosigalLabel.TabIndex = 1;
            this.nosigalLabel.Text = "请打开开发者选项-USB调试\r\n并使用数据线连接手机\r\n如投屏出现问题请尝试独立窗口投屏\r\n或者联系作者";
            this.nosigalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startCastSingleButton
            // 
            this.startCastSingleButton.Location = new System.Drawing.Point(1031, 1);
            this.startCastSingleButton.Name = "startCastSingleButton";
            this.startCastSingleButton.Size = new System.Drawing.Size(115, 20);
            this.startCastSingleButton.TabIndex = 15;
            this.startCastSingleButton.Text = "独立窗口投屏";
            this.startCastSingleButton.UseVisualStyleBackColor = true;
            this.startCastSingleButton.Click += new System.EventHandler(this.startCastSingleButton_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 681);
            this.Controls.Add(this.startCastSingleButton);
            this.Controls.Add(this.screenBox);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学习强国挑战答题搜索神器V2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.screenBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox inputtext;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newans;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox newop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newques;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label daannum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Timer heartTimer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button startCastButton;
        private System.Windows.Forms.Button stopCastButton;
        private System.Windows.Forms.Panel screenBox;
        private System.Windows.Forms.Label nosigalLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ocrout;
        private System.Windows.Forms.Button ocrbtn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button startCastSingleButton;
    }
}

