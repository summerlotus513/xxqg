using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace XXQGAns
{
    public partial class main : Form
    {
        MySqlConnection SQLCon;
        MySqlCommand SQLCmd;
        string ques = "null", ans = "null", op = "null";
        private void daanuptable_refresh() 
        {
            string nowid;
            string searchStr = "select max(id) from daanup";   //xxqgup表中最大
            SQLCmd = new MySqlCommand(searchStr, SQLCon);
            nowid = SQLCmd.ExecuteScalar().ToString();
            label7.Text = nowid;
        }
        private void daanup_refresh()
        {
            string searchStr = "select * from daan";   //xxqg表中数据
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchStr, SQLCon);
            DataTable a = new DataTable();
            adapter.Fill(a);
            this.dataGridView1.DataSource = a;
            dataGridView1.Columns[0].HeaderText = "题号";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "题目";
            dataGridView1.Columns[1].Width = 355;
            dataGridView1.Columns[2].HeaderText = "答案";
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor= System.Drawing.Color.Red;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "选项";
            dataGridView1.Columns[3].Width = 350;
            dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            string nowid;
            string nowidStr = "select max(id) from daan";   //xxqgup表中最大
            SQLCmd = new MySqlCommand(nowidStr, SQLCon);
            nowid = SQLCmd.ExecuteScalar().ToString();
            daannum.Text = nowid;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (newques.Text != string.Empty && newans.Text != string.Empty && newop.Text != string.Empty)
            {
                ques = newques.Text;
                ans = newans.Text;
                op = newop.Text;
                
                //MySqlDataAdapter adapter = new MySqlDataAdapter(searchStr, SQLCon);
                try
                {
                    string insertStr = "insert into daanup(ques,ans,op) values('" + ques + "','" + ans + "','" + op + "')";
                    SQLCmd = new MySqlCommand(insertStr, SQLCon);
                    SQLCmd.ExecuteNonQuery();
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
                    daanuptable_refresh();
                    //button1_Click(sender,e);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
                }
            }
            else { 
                MessageBox.Show("问题/答案/选项均不能为空", "提示", MessageBoxButtons.OK); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            daanup_refresh();
        }
        
        public main()
        {
            InitializeComponent();
            inputtext.AutoSize = false;
            inputtext.Height = 50;
            newques.AutoSize = false;
            newques.Height = 50;
            newop.AutoSize = false;
            newop.Height = 50;
            newans.AutoSize = false;
            newans.Height = 50;
            string connetStr = "server=IP;user=user;password=passwd;database=xxqg;sslMode=none;";
            SQLCon = new MySqlConnection(connetStr);
            try
            {
                SQLCon.Open(); //连接数据库
                state.Text = "已连接";
                state.ForeColor = Color.FromArgb(0, 255, 0);
                daanup_refresh();
                daanuptable_refresh();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);     //显示错误信息
            }
            this.inputtext.KeyDown += new KeyEventHandler(inputtext_KeyDown);
            
        }
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出?", "提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)   //如果单击“是”按钮
            {
                e.Cancel = false;                 //关闭窗体
                SQLCon.Close();
                System.Environment.Exit(0);
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;                  //不执行操作
            }
        }
        private void inputtext_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter)//判断回
            {
                //MessageBox.Show("123", "提示", MessageBoxButtons.OK);
                this.search_Click(sender, e);//触发按钮事件
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            string str = "";
            if (inputtext.Text != "")
            {
                str = "where ques like '%" + inputtext.Text+ "%'";
                //daannum.Text = str;
            }
                
            try
            {
                string searchStr = ("select * from daan " + str);
                MySqlDataAdapter adapter = new MySqlDataAdapter(searchStr, SQLCon);
                DataTable a = new DataTable();
                adapter.Fill(a);
                this.dataGridView1.DataSource = a;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }
        }
    }
}
