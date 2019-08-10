using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;


namespace sqlite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection.CreateFile("Database.sqlite");
            //创建连接字符串
            SQLiteConnection conn = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
            //这是数据库登录密码
          //  conn.SetPassword("1234");
            //打开数据库
            conn.Open();
            string query = "create table table1 (id INTEGER, name VARCHAR)";
            query += ";insert into table1 (id, name) values(1, '小明')";
            query += ";insert into table1 (id, name) values(2, '小li')";


            //创建命令
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            //执行命令
            cmd.ExecuteNonQuery();
            //释放资源
            conn.Close();

            //cmd.Dispose();

            conn.Open();
            string query1 = "select * from table1";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd1);
            DataTable dt = new DataTable();
           // dt.Columns.Add("id");
           // dt.Columns.Add("name");
            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
          //  dt.Rows.Add("");
          //  dt.Rows.Add("");
            conn.Close();

            cmd.Dispose();
        }

    }
}
