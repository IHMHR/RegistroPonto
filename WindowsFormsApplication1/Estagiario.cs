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
                // WHAT THIS LINE BELOW DOES:
                // check the last time that the procedure 'usp_arrumar_estagio' ran
                // if it's equal to 1 day or more run the procedure 'usp_arrumar_estagio' again
                // else do nothing
                new System.Data.SqlClient.SqlCommand("IF(DATEDIFF(DAY, (SELECT last_execution_time FROM sys.dm_exec_procedure_stats ps WHERE lower(object_name(object_id)) = 'usp_arrumar_estagio'), GETDATE()) >= 1) BEGIN EXEC usp_arrumar_estagio END", Conectar()).ExecuteNonQuery();

                System.Data.DataTable dt = new System.Data.DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(new System.Data.SqlClient.SqlCommand("SELECT * FROM vw_relatorio_estagio ORDER BY entrada ASC", Conectar()));
                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {
                throw new Exception("obterRelatorio: " + erro);
            }
        }

        public void Inserir(bool usarentrada, bool usarsaida)
        {
            try
            {
                if (usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (entrada,saida) VALUES ('" + entrada.ToString("yyyy-MM-dd HH:mm:ss") + "','" + saida.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (usarentrada && !usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (entrada) VALUES ('" + entrada.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
                else if (!usarentrada && usarsaida)
                {
                    new System.Data.SqlClient.SqlCommand("INSERT INTO ponto_estagio (saida) VALUES ('" + saida.ToString("yyyy-MM-dd HH:mm:ss") + "')", Conectar()).ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                throw new Exception("Inserir: " + erro);
            }
        }
    }
}
