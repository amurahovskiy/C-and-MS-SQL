using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace S.P_Laba2_Zavdanna_
{
    public partial class Form1 : Form
    {
        Form old;
        public ComboBox combo;
        Form newForm;
        string connect = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Art_DataBase;Integrated Security=True";
        public Form1()
        {
            combo = comboBox1;
            InitializeComponent();
            button1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;


        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void Ref()
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
            Categ();
        }

        private void Form1_Load_1(object sender, EventArgs e)
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
            Categ();
        }
        public void Categ()
        {
            DataSet dataset = new DataSet();
            using (SqlConnection sql = new SqlConnection(connect))
            {
                sql.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(@"Select Name_Jenre from dbo.Jenre", sql);
                adapter.Fill(dataset);
                sql.Close();
            }
            comboBox1.Items.Clear();
            for(int i=0;i<dataset.Tables[0].Rows.Count;i++)
            {
                comboBox1.Items.Add(dataset.Tables[0].Rows[i][0]);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox1.Enabled = false;
            CheckStatus();
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = !checkBox2.Enabled;
            checkBox1.Enabled = !checkBox1.Enabled;
            textBox1.Enabled = !textBox1.Enabled;
            textBox5.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox1.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            CheckStatus();
            comboBox1.Enabled = true;
         
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = !checkBox2.Enabled;
            checkBox1.Enabled = !checkBox1.Enabled;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            CheckStatus();
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            textBox5.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = !textBox2.Enabled;
            textBox3.Enabled = !textBox3.Enabled;
            textBox4.Enabled = !textBox4.Enabled;
            textBox5.Enabled = !textBox5.Enabled;
            checkBox2.Enabled = !checkBox2.Enabled;
            checkBox1.Enabled = !checkBox1.Enabled;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            CheckStatus();
            textBox1.Enabled = true;
            comboBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int be;
            bool bil;
            bool bil1;
            bool bil2;
            bool bil3;
            int count = 0;
            Regex Sample = new Regex("^.*[^A-zА-яiЁё].*$");
            Regex Sample_1 = new Regex("^[0-9]+$");
            Match res1 = Sample.Match(textBox2.Text);
            Match res2 = Sample.Match(textBox3.Text);
            Match res3 = Sample.Match(textBox4.Text);
            Match res4 = Sample_1.Match(textBox5.Text);
            Match res5 = Sample_1.Match(textBox1.Text);
          
                int a;
                int b;
                string query = "";
                string res = "";
            if (radioButton1.Checked)
            {
                
                    
                        res = "row(s) selected";
                        query = "select Picture.IDPicture, Picture.Place,Picture.Money,Picture.Author,Picture.Name,Name_Jenre from dbo.Picture join dbo.Jenre On ID_Jenre=ID_J";
                        if (checkBox1.Checked && int.TryParse(textBox1.Text, out a))
                        {
                            query += " where Picture.IDPicture = " + textBox1.Text;
                    
                        }

                        else if (checkBox2.Checked && comboBox1.Text != "")
                        {

                            query += " where Name_Jenre=N'" + comboBox1.Text + "'";
                        }
                    
               
            }
            if (radioButton2.Checked && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "" && int.TryParse(textBox3.Text, out a))
            {

                res = "1 row(s) inserted";
                query = "INSERT INTO dbo.Picture ([Place],[Money],[Author],[Name],[ID_J]) VALUES (N'" + textBox2.Text + "',N'" + textBox3.Text + "',N'" + textBox4.Text + "',N'" + textBox5.Text + "',(select ID_Jenre from dbo.Jenre where Name_Jenre = N'" + comboBox1.Text + "'))";
                bil = true;
            }
            else
            {

                bil = false;
            }
            if (radioButton3.Checked && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "" && int.TryParse(textBox3.Text, out a) && int.TryParse(textBox1.Text, out be))
            {
                bil1 = true;
                res = "1 row(s) updated";
                query = "UPDATE dbo.Picture SET Place = N'" + textBox2.Text + "',ID_J = (select ID_Jenre from dbo.Jenre where Name_Jenre = N'" + comboBox1.Text + "'), Money = N'" + textBox3.Text + "',Author = N'" + textBox4.Text + "',Name = N'" + textBox5.Text + "' WHERE IDPicture =" + textBox1.Text;

            }
            else
            { bil1 = false; }
            if (radioButton4.Checked && textBox1.Text != "" && int.TryParse(textBox1.Text, out a))
            {
                bil2 = true;
                res = "1 row(s) deleted";
                query = "Delete from dbo.Picture where IDPicture =" + textBox1.Text;
            }
            else
            { bil2 = false; }
                if (bil||bil1||bil2)
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
                            textBox6.Text = res;
                        }
                        else
                        {
                            adapt = new SqlDataAdapter("select Picture.IDPicture, Picture.Place, Picture.Money, Picture.Author, Picture.Name, Name_Jenre from dbo.Picture join dbo.Jenre On ID_Jenre = ID_J;", connect);
                            data = new DataSet();
                            adapt.Fill(data);
                            dataGridView1.DataSource = data.Tables[0];
                            textBox6.Text = res;
                        }
                        conn.Close();
                    }
                    Categ();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox1.Text = "";
                }else
                {
                    MessageBox.Show("Помилка");
                }
            
        }
        int count1 = 3;
        int count2 = 3;
        public bool Check() => new Regex(@"^*[^A-zА-яЁё]*$").IsMatch(textBox2.Text) && new Regex(@"^.*[^A-zА-яЁё].*$").IsMatch(textBox4.Text) && new Regex(@"^.*[^A-zА-яЁё].*$").IsMatch(textBox5.Text);
        //{
        //    Regex Sample = new Regex("^.*[^A-zА-яЁё].*$");
        //    Match res1 = Sample.Match(textBox2.Text);
        //    Match res2 = Sample.Match(textBox4.Text);
        //    Match res3 = Sample.Match(textBox5.Text);
        //    return res1.Success && res2.Success && res3.Success;
        //}
        public bool Check_1()
        {
            Regex Sample = new Regex("^[0-9]+$");
            Match res1 = Sample.Match(textBox3.Text);
            Match res2 = Sample.Match(textBox1.Text);
            return res1.Success && res2.Success;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckStatus();
            Categ();


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckStatus();
            Categ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            newForm = new Form2(this);
            newForm.Show();
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        public void CheckStatus()
        {
            textBox1.Clear();
            comboBox1.Text = "";
            if (checkBox1.Checked && checkBox2.Checked)
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = false;

            }
            if (!checkBox1.Checked && checkBox2.Checked)
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = true;
            }
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                textBox1.Enabled = true;
                comboBox1.Enabled = false;
            }
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
            }
            if (!radioButton2.Checked && !radioButton3.Checked && !radioButton1.Checked && !radioButton4.Checked)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
