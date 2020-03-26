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
    public partial class login : Form
    {
        MySqlConnection SQLCon;
        public login()
        {
            InitializeComponent();
            string connetStr = "server=IP;user=user;password=passwd;database=xxqg;sslMode=none;";
            //MySqlConnection conn = new MySqlConnection(connetStr);
            SQLCon = new MySqlConnection(connetStr);
            try
            {
                SQLCon.Open();//打开通道，建立连接
                string version = "select * from version where version ='1.0.326.1'";
                MySqlCommand commm = new MySqlCommand(version, SQLCon);
                MySqlDataReader versiondr = commm.ExecuteReader();
                if (versiondr.Read())
                {
                }
                else { MessageBox.Show("软件有新版本更新!\n请前往官网下载最新版本！\n当前版本可正常使用！");
                    SQLCon.Close();
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                SQLCon.Close();
            }
            this.passwd.KeyDown += new KeyEventHandler(passwd_KeyDown);
        }
        private void passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回
            {
                //MessageBox.Show("123", "提示", MessageBoxButtons.OK);
                this.button1_Click(sender, e);//触发按钮事件
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connetStr = "server=IP;user=user;password=passwd;database=xxqg;sslMode=none;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();
                string strSql = "select * from login where user = '" + this.user.Text.Trim().ToString() + "'and passwd = '" +
                this.passwd.Text.Trim().ToString() + "'";
                //this.textBox1.Text.Trim().ToString()获取文本框的值，往数据库里查询
                MySqlCommand comm = new MySqlCommand(strSql, conn);
                MySqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    this.Hide();  //登录成功后，隐藏该页面
                    main m = new main(); //new到另一个面板
                    m.ShowDialog();  //展示登录后的面板
                }
                else
                {
                    MessageBox.Show("登陆失败！");
                }

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }   
 }
