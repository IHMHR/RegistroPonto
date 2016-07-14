using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool clt = false;
        SqlCommand comando;
        System.Windows.Forms.DateTimePicker DpIdaDia;
        System.Windows.Forms.DateTimePicker DpIdaHora;
        System.Windows.Forms.DateTimePicker DpVoltaDia;
        System.Windows.Forms.DateTimePicker DpVoltaHora;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region Estruturado
                /*string ent = string.Empty;
                string sai = string.Empty;
                string entAlm = string.Empty;
                string saoAlm = string.Empty;

                if (!clt)
                {

                    if (dateTimePicker1.Visible && dateTimePicker2.Visible)
                    {
                        ent = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text;
                        sai = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text;
                        comando = new SqlCommand("INSERT INTO ponto_estagio (entrada,saida) VALUES ('" + ent + "','" + sai + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (dateTimePicker1.Visible && !dateTimePicker2.Visible)
                    {
                        ent = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text;
                        comando = new SqlCommand("INSERT INTO ponto_estagio (entrada) VALUES ('" + ent + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (!dateTimePicker1.Visible && dateTimePicker2.Visible)
                    {
                        sai = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text;
                        comando = new SqlCommand("INSERT INTO ponto_estagio (saida) VALUES ('" + sai + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Você tem que registrar alguma ação.", "Qual o registro ?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //CLT
                    if (dateTimePicker1.Visible && dateTimePicker3.Visible && !DpIdaDia.Visible && !DpIdaHora.Visible && !DpVoltaDia.Visible && !DpVoltaHora.Visible)
                    {
                        ent = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text;
                        sai = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada,saida) VALUES ('" + ent + "','" + sai + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (dateTimePicker1.Visible && !dateTimePicker2.Visible && !DpIdaDia.Visible && !DpIdaHora.Visible && !DpVoltaDia.Visible && !DpVoltaHora.Visible)
                    {
                        ent = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada) VALUES ('" + ent + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (!dateTimePicker1.Visible && dateTimePicker2.Visible && !DpIdaDia.Visible && !DpIdaHora.Visible && !DpVoltaDia.Visible && !DpVoltaHora.Visible)
                    {
                        sai = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (saida) VALUES ('" + sai + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (DpIdaDia.Visible && DpIdaHora.Visible && !dateTimePicker1.Visible && !DpVoltaDia.Visible)
                    {
                        entAlm = DpIdaDia.Value.ToString("yyyy-MM-dd") + " " + DpIdaHora.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada_almoco) VALUES ('" + entAlm + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (DpVoltaDia.Visible && !DpIdaDia.Visible && !dateTimePicker1.Visible && !dateTimePicker2.Visible)
                    {
                        saoAlm = DpVoltaDia.Value.ToString("yyyy-MM-dd") + " " + DpVoltaHora.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (saida_almoco) VALUES ('" + saoAlm + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (DpIdaDia.Visible && DpVoltaDia.Visible && !dateTimePicker1.Visible && !dateTimePicker2.Visible)
                    {
                        entAlm = DpIdaDia.Value.ToString("yyyy-MM-dd") + " " + DpIdaHora.Text;
                        saoAlm = DpVoltaDia.Value.ToString("yyyy-MM-dd") + " " + DpVoltaHora.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida_almoco) VALUES ('" + entAlm + "','" + saoAlm + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (dateTimePicker1.Visible && DpIdaDia.Visible && !DpVoltaDia.Visible && !dateTimePicker2.Visible)
                    {
                        ent = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text;
                        entAlm = DpIdaDia.Value.ToString("yyyy-MM-dd") + " " + DpIdaHora.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco) VALUES ('" + ent + "','" + entAlm + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (DpIdaDia.Visible && DpVoltaDia.Visible && dateTimePicker1.Visible && !dateTimePicker2.Visible)
                    {
                        ent = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text;
                        entAlm = DpIdaDia.Value.ToString("yyyy-MM-dd") + " " + DpIdaHora.Text;
                        saoAlm = DpVoltaDia.Value.ToString("yyyy-MM-dd") + " " + DpVoltaHora.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco,saida_almoco) VALUES ('" + ent + "','" + entAlm + "','" + saoAlm + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (!DpIdaDia.Visible && DpVoltaDia.Visible && dateTimePicker1.Visible && !dateTimePicker2.Visible)
                    {
                        ent = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text;
                        saoAlm = DpVoltaDia.Value.ToString("yyyy-MM-dd") + " " + DpVoltaHora.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada,saida_almoco) VALUES ('" + ent + "','" + saoAlm + "')", Conectar()); ;
                        comando.ExecuteNonQuery();
                    }
                    else if (DpIdaDia.Visible && DpVoltaDia.Visible && dateTimePicker1.Visible && dateTimePicker2.Visible)
                    {
                        ent = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text;
                        entAlm = DpIdaDia.Value.ToString("yyyy-MM-dd") + " " + DpIdaHora.Text;
                        saoAlm = DpVoltaDia.Value.ToString("yyyy-MM-dd") + " " + DpVoltaHora.Text;
                        sai = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco,saida_almoco,saida) VALUES ('" + ent + "','" + entAlm + "','" + saoAlm + "','" + sai + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (DpIdaDia.Visible && DpVoltaDia.Visible && !dateTimePicker1.Visible && dateTimePicker2.Visible)
                    {
                        entAlm = DpIdaDia.Value.ToString("yyyy-MM-dd") + " " + DpIdaHora.Text;
                        saoAlm = DpVoltaDia.Value.ToString("yyyy-MM-dd") + " " + DpVoltaHora.Text;
                        sai = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida_almoco,saida) VALUES ('" + entAlm + "','" + saoAlm + "','" + sai + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (DpIdaDia.Visible && !DpVoltaDia.Visible && !dateTimePicker1.Visible && dateTimePicker2.Visible)
                    {
                        entAlm = DpIdaDia.Value.ToString("yyyy-MM-dd") + " " + DpIdaHora.Text;
                        sai = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida) VALUES ('" + entAlm + "','" + sai + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }
                    else if (!DpIdaDia.Visible && DpVoltaDia.Visible && !dateTimePicker1.Visible && dateTimePicker2.Visible)
                    {
                        saoAlm = DpVoltaDia.Value.ToString("yyyy-MM-dd") + " " + DpVoltaHora.Text;
                        sai = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text;
                        comando = new SqlCommand("INSERT INTO ponto_clt (saida_almoco,saida) VALUES ('" + saoAlm + "','" + sai + "')", Conectar());
                        comando.ExecuteNonQuery();
                    }                   
                    else
                    {
                        MessageBox.Show("Você tem que registrar alguma ação.", "Qual o registro ?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }*/
                #endregion
                if (!clt)
                {
                    var est = new Estagiario();
                    est.entrada = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text);
                    est.saida = Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text);
                    est.Inserir(dateTimePicker1.Visible, dateTimePicker2.Visible);
                }
                else
                {
                    var fun = new Funcionario();
                    fun.entrada = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker3.Text);
                    fun.saida = Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-MM-dd") + " " + dateTimePicker4.Text);
                    fun.entrada_almoco = Convert.ToDateTime(DpIdaDia.Value.ToString("yyyy-MM-dd") + " " + DpIdaHora.Text);
                    fun.saida_almoco = Convert.ToDateTime(DpVoltaDia.Value.ToString("yyyy-MM-dd") + " " + DpVoltaHora.Text);
                    fun.Inserir(dateTimePicker1.Visible, DpIdaDia.Visible, DpVoltaDia.Visible, dateTimePicker2.Visible);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
            finally
            {
                dateTimePicker1.Visible = false;
                dateTimePicker3.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker4.Visible = false;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker3.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker4.Value = DateTime.Now;
                if (clt)
                {
                    DpIdaDia.Visible = false;
                    DpIdaHora.Visible = false;
                    DpVoltaDia.Visible = false;
                    DpVoltaHora.Visible = false;
                    DpIdaDia.Value = DateTime.Now;
                    DpIdaHora.Value = DateTime.Now;
                    DpVoltaDia.Value = DateTime.Now;
                    DpVoltaHora.Value = DateTime.Now;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            panel2.Visible = true;
            panel1.Visible = false;
            groupBox1.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker3.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker4.Visible = false;

            panel2.Location = new Point(18, 45);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = !dateTimePicker1.Visible;
            dateTimePicker3.Visible = !dateTimePicker3.Visible;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = !dateTimePicker2.Visible;
            dateTimePicker4.Visible = !dateTimePicker4.Visible;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((int)tabControl1.SelectedIndex == 1)
                {
                    // ABA RELATORIOS
                    label3.Visible = !label3.Visible;
                    label3.Text = string.Empty;
                    this.Width += 500;
                    this.Height += 80;
                    button1.Visible = !button1.Visible;
                    tabControl1.Width += 500;
                    tabControl1.Height += 80;
                    if (clt)
                    {
                        dataGridView1.DataSource = new Funcionario().obterRelatorio();
                        label3.Text = "Hora(s) extra(s): ";
                        label3.Text += new Funcionario().obterHoraExtra() + ".";
                        if(int.Parse(new Funcionario().obterHoraExtra()) < 0 )
                        {
                            label3.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = new Estagiario().obterRelatorio();
                        label3.Text = "Hora(s) extra(s): ";
                        label3.Text += new Estagiario().obterHoraExtra() + ".";
                        if (int.Parse(new Estagiario().obterHoraExtra()) < 0)
                        {
                            label3.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    label3.Visible = !label3.Visible;
                    this.Width -= 500;
                    this.Height -= 80;
                    button1.Visible = !button1.Visible;
                    tabControl1.Width -= 500;
                    tabControl1.Height -= 80;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            groupBox1.Visible = true;
            panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clt = true;
            panel1.Visible = true;
            groupBox1.Visible = true;
            panel2.Visible = false;

            label2.Location = new Point(20,130);
            this.Width += 100;
            this.Height += 50;
            tabControl1.Width += 100;
            tabControl1.Height += 50;
            tabPage1.Width += 100;
            tabPage1.Height += 100;
            groupBox1.Width += 100;
            groupBox1.Height += 50;
            button1.Location = new Point(155, 5);
            dateTimePicker2.Location = new Point(65, 130);
            dateTimePicker4.Location = new Point(170, 130);


            //ALMOÇO IDA E VOLTA
            this.SuspendLayout();
            //
            // LabelIda
            //
            var LabelIda = new System.Windows.Forms.Label();
            LabelIda.Name = "LabelIda";
            LabelIda.Text = "Ida Almoço";
            LabelIda.Location = new Point(15, 65);
            LabelIda.AutoSize = true;
            LabelIda.Click += LabelIda_Click;
            //
            // LabelVolta
            //
            var LabelVolta = new System.Windows.Forms.Label();
            LabelVolta.Name = "LabelVolta";
            LabelVolta.Text = "Volta Almoço";
            LabelVolta.Location = new Point(15, 98);
            LabelVolta.AutoSize = true;
            LabelVolta.Click += LabelVolta_Click;
            //
            // DpIdaDia
            //
            DpIdaDia = new System.Windows.Forms.DateTimePicker();
            DpIdaDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            DpIdaDia.Location = new System.Drawing.Point(90, 62);
            DpIdaDia.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            DpIdaDia.MinDate = new System.DateTime(2016, 6, 6, 0, 0, 0, 0);
            DpIdaDia.Name = "DpIdaDia";
            DpIdaDia.Size = new System.Drawing.Size(96, 20);
            DpIdaDia.Visible = false;
            //
            // DpIdaHora
            //
            DpIdaHora = new System.Windows.Forms.DateTimePicker();
            DpIdaHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            DpIdaHora.Location = new System.Drawing.Point(200, 62);
            DpIdaHora.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            DpIdaHora.MinDate = new System.DateTime(2016, 6, 6, 0, 0, 0, 0);
            DpIdaHora.Name = "DpIdaDia";
            DpIdaHora.Size = new System.Drawing.Size(64, 20);
            DpIdaHora.Visible = false;
            //
            // DpVoltaDia
            //
            DpVoltaDia = new System.Windows.Forms.DateTimePicker();
            DpVoltaDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            DpVoltaDia.Location = new System.Drawing.Point(97,95);
            DpVoltaDia.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            DpVoltaDia.MinDate = new System.DateTime(2016, 6, 6, 0, 0, 0, 0);
            DpVoltaDia.Name = "DpIdaDia";
            DpVoltaDia.Size = new System.Drawing.Size(96, 20);
            DpVoltaDia.Visible = false;
            //
            // DpVoltaHora
            //
            DpVoltaHora = new System.Windows.Forms.DateTimePicker();
            DpVoltaHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            DpVoltaHora.Location = new System.Drawing.Point(200,95);
            DpVoltaHora.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            DpVoltaHora.MinDate = new System.DateTime(2016, 6, 6, 0, 0, 0, 0);
            DpVoltaHora.Name = "DpIdaDia";
            DpVoltaHora.Size = new System.Drawing.Size(64, 20);
            DpVoltaHora.Visible = false;

            this.groupBox1.Controls.Add(DpVoltaHora);
            this.groupBox1.Controls.Add(DpVoltaDia);
            this.groupBox1.Controls.Add(DpIdaHora);
            this.groupBox1.Controls.Add(DpIdaDia);
            this.groupBox1.Controls.Add(LabelVolta);
            this.groupBox1.Controls.Add(LabelIda);

            this.ResumeLayout(false);
        }

        void LabelVolta_Click(object sender, EventArgs e)
        {
            DpVoltaDia.Visible = !DpVoltaDia.Visible;
            DpVoltaHora.Visible = !DpVoltaHora.Visible;
        }

        void LabelIda_Click(object sender, EventArgs e)
        {
            DpIdaDia.Visible = !DpIdaDia.Visible;
            DpIdaHora.Visible = !DpIdaHora.Visible;
        }
    }
}
