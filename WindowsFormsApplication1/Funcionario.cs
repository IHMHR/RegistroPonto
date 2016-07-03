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
        public DateTime said_almoco { get; set; }
        public DateTime said { get; set; }
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

        public void Inserir(bool usarentrada, DateTime entrada, bool usarentradaAlm, DateTime entradaAlm, bool usarsaidaAlm, DateTime saidaAlm, bool usarsaida, DateTime saida)
        {
            try
            {


                if (usarentrada && usarsaida && !usarentradaAlm && !usarsaidaAlm)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,saida) VALUES ('" + entrada + "','" + saida + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada && !usarsaida && !usarentradaAlm && !usarsaidaAlm)
                {
                     new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada) VALUES ('" + entrada + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarentrada && usarsaida && !usarentradaAlm && !usarsaidaAlm)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (saida) VALUES ('" + saida + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentradaAlm && !usarentrada && !usarsaidaAlm && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada_almoco) VALUES ('" + entradaAlm + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarsaidaAlm && !usarentradaAlm && !usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (saida_almoco) VALUES ('" + saidaAlm + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentradaAlm && usarsaidaAlm && !usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida_almoco) VALUES ('" + entradaAlm + "','" + saidaAlm + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada && usarentradaAlm && !usarsaidaAlm && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco) VALUES ('" + entrada + "','" + entradaAlm + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentradaAlm && usarsaidaAlm && usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco,saida_almoco) VALUES ('" + entrada + "','" + entradaAlm + "','" + saidaAlm + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarentradaAlm && usarsaidaAlm && usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,saida_almoco) VALUES ('" + entrada + "','" + saidaAlm + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentradaAlm && usarsaidaAlm && usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada,entrada_almoco,saida_almoco,saida) VALUES ('" + entrada + "','" + entradaAlm + "','" + saidaAlm + "','" + saida + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentradaAlm && usarsaidaAlm && !usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida_almoco,saida) VALUES ('" + entradaAlm + "','" + saidaAlm + "','" + saida + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentradaAlm && !usarsaidaAlm && !usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (entrada_almoco,saida) VALUES ('" + entradaAlm + "','" + saida + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarentradaAlm && usarsaidaAlm && !usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_clt (saida_almoco,saida) VALUES ('" + said_almoco + "','" + saida + "')", Conectar()).ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Inserir: " + erro);
            }
        }
    }
}
