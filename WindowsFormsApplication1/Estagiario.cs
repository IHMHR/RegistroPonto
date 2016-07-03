using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Estagiario
    {
        public DateTime entrada { get; set; }
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
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(new System.Data.SqlClient.SqlCommand("SELECT * FROM vw_relatorio_estagio ORDER BY Entrada ASC", Conectar()));
                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {
                throw new Exception("obterRelatorio: " + erro);
            }
        }

        public void Inserir(bool usarEntrada, DateTime entrada, bool usarsaida, DateTime saida)
        {
            try
            {
                if (usarEntrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (entrada,saida) VALUES ('" + entrada + "','" + saida + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarEntrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (entrada) VALUES ('" + entrada + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarEntrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (saida) VALUES ('" + saida + "')", Conectar()).ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Inserir: " + erro);
            }
        }
    }
}
