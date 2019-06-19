using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace S.P_Laba2_Zavdanna_
{
    public partial class Form2 : Form
    {
        Form1 old;
        string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Art_DataBase;Integrated Security=True";
        public Form2(Form1 oldForm)
        {
            InitializeComponent();
            old = oldForm;
            button1.Enabled = false;
            textBox2.Enabled = !textBox2.Enabled;
            textBox3.Enabled = !textBox3.Enabled;
            textBox1.Enabled = !textBox1.Enabled;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {


            try
            {
                using (SqlConnection c = new SqlConnection(connect))
                {
                    c.Open();
                    SqlDataAdapter d = new SqlDataAdapter(@"select * from dbo.Picture", c);
                    DataSet data = new DataSet();
                    d.Fill(data);
                    if (data.Tables[0].Rows.Count == 0)
                    {
                        d = new SqlDataAdapter(@"INSERT INTO dbo.Jenre ([Name_Jenre],[Description]) VALUES (N'Пейзаж', N'Жанр опису природи')", c);
                        d.Fill(data);
                    }
                    d = new SqlDataAdapter(@"select * from dbo.Jenre where Name_Jenre = N'Історичний жанр'", c);
                    data.Reset();
                    d.Fill(data);
                    if (data.Tables[0].Rows.Count == 0)
                    {
                        d = new SqlDataAdapter(@"INSERT INTO dbo.Jenre ([Name_Jenre],[Description]) VALUES (N'Історичний жанр',N'Картини пов*язані з історією')", c);
                        d.Fill(data);
                    }
                    c.Close();
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); };


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = !textBox1.Enabled;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a;
            int b;
            bool bil1 = true;
            bool bil = true;
            bool bil2 = true;
            bool bill3 = true;
            string query = "";
            string res = "";
            if (radioButton1.Checked)
            {
                res = "row(s) selected";
                if (textBox1.Text == ""&& int.TryParse(textBox1.Text, out a))
                {
                    query = "select * from Jenre";
                }else if(int.TryParse(textBox1.Text, out a))
                {
                    query = "select * from Jenre where ID_Jenre=" + textBox1.Text;
                }
                else
                {
                    bil1 = false;
                }
            }
            if (radioButton2.Checked && textBox2.Text != "" && textBox3.Text != "" && int.TryParse(textBox3.Text, out a))
            {
                res = "1 row(s) inserted";
                query = "INSERT INTO dbo.Jenre ([Description],[Name_Jenre]) VALUES (N'" + textBox2.Text + "',N'" + textBox3.Text + "')";
            }
            else
            {
                bil = false;
            }
            if (radioButton3.Checked && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && int.TryParse(textBox1.Text, out a) && int.TryParse(textBox1.Text, out b))
            {
                res = "1 row(s) updated";
                query = "UPDATE dbo.Jenre SET ID_Jenre'" + textBox1.Text + "', Description = N'" + textBox2.Text + "', Name_Jenre = N'" + textBox3.Text + "'";
            } else
            {
                bil2 = false;
            }
            if (radioButton4.Checked && textBox1.Text != "" && int.TryParse(textBox1.Text, out a))
            {
                res = "1 row(s) deleted";
                query = "Delete from dbo.Jenre where ID_Jenre =" + textBox1.Text;
            } else
            {
                bill3 = false;
            }
            if (bil ||bil1|| bil2 || bill3)
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
                    DataSet data = new DataSet();
                    adapt.Fill(data);
                    dataGridView1.Visible = true;
                    if (radioButton1.Checked)
                    {
                        dataGridView1.DataSource = data.Tables[0];
                        res = res.Insert(0, data.Tables[0].Rows.Count.ToString());
                    }
                    else
                    {
                        adapt = new SqlDataAdapter("select * from Jenre", connect);
                        data = new DataSet();
                        adapt.Fill(data);
                        dataGridView1.DataSource = data.Tables[0];
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    conn.Close();
                }
            }else
            {
                MessageBox.Show("Помилка при вводі тексту");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            old.Categ();
            old.Show();
        }
    }
}
