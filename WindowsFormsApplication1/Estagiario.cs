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

        public void Inserir(bool usarEntrada, DateTime entrada, bool usarSaida, DateTime saida)
        {
            try
            {
                string ent = string.Empty;
                string sai = string.Empty;
                if (usarEntrada && usarSaida)
                {
                    ent = entrada.ToString();
                    sai = saida.ToString();
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (entrada,saida) VALUES ('" + ent + "','" + sai + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarEntrada && !usarSaida)
                {
                    ent = entrada.ToString();
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (entrada) VALUES ('" + ent + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarEntrada && usarSaida)
                {
                    sai = saida.ToString();
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (saida) VALUES ('" + sai + "')", Conectar()).ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                throw new Exception("obterRelatorio: " + erro);
            }
        }
    }
}
