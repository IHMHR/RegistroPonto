using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Funcionario
    {
        public DateTime entrada { get; set; }
        public DateTime entrada_almoco { get; set; }
        public DateTime saida_almoco { get; set; }
        public DateTime saida { get; set; }
        private System.Data.SqlClient.SqlConnection Conectar()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.conString);
                con.Open();
                return con;
            }
            catch (Exception er)
            {
                throw new Exception("Conectar: " + er.Message.ToString());
            }
        }
        public System.Data.DataTable obterRelatorio()
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(new System.Data.SqlClient.SqlCommand("SELECT * FROM vw_relatorio_clt ORDER BY entrada ASC", Conectar()));
                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {
                throw new Exception("obterRelatorio: " + erro);
            }
        }

        public void Inserir(bool usarentrada, bool usarentrada_almoco, bool usarsaida_almoco, bool usarsaida)
        {
            try
            {
                if (usarentrada && usarsaida && !usarentrada_almoco && !usarsaida_almoco)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,saida) VALUES ('" + entrada.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada && !usarsaida && !usarentrada_almoco && !usarsaida_almoco)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada) VALUES ('" + entrada.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarentrada && usarsaida && !usarentrada_almoco && !usarsaida_almoco)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (saida) VALUES ('" + saida.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada_almoco && !usarentrada && !usarsaida_almoco && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada_almoco) VALUES ('" + entrada_almoco + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarsaida_almoco && !usarentrada_almoco && !usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (saida_almoco) VALUES ('" + saida_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada_almoco && usarsaida_almoco && !usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida_almoco) VALUES ('" + entrada_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada && usarentrada_almoco && !usarsaida_almoco && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco) VALUES ('" + entrada.ToString("yyyy-MM-dd HH:mm:ss") + "','" + entrada_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada_almoco && usarsaida_almoco && usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco,saida_almoco) VALUES ('" + entrada.ToString("yyyy-MM-dd HH:mm:ss") + "','" + entrada_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarentrada_almoco && usarsaida_almoco && usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,saida_almoco) VALUES ('" + entrada.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada_almoco && usarsaida_almoco && usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco,saida_almoco,saida) VALUES ('" + entrada.ToString("yyyy-MM-dd HH:mm:ss") + "','" + entrada_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada_almoco && usarsaida_almoco && !usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida_almoco,saida) VALUES ('" + entrada_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada_almoco && !usarsaida_almoco && !usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida) VALUES ('" + entrada_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarentrada_almoco && usarsaida_almoco && !usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (saida_almoco,saida) VALUES ('" + saida_almoco.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Inserir: " + erro);
            }
        }
    }
}
