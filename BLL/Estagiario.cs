using System;

namespace BLL
{
    sealed public class Estagiario : Funcionario
    {
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

        public override System.Data.DataTable obterRelatorio()
        {
            try
            {
                // WHAT THIS LINE BELOW DOES:
                // check the last time that the procedure 'usp_arrumar_estagio' ran
                // if it's equal to 1 day or more run the procedure 'usp_arrumar_estagio' again
                // else do nothing
                new System.Data.SqlClient.SqlCommand("IF(DATEDIFF(DAY, (SELECT TOP 1 last_execution_time FROM sys.dm_exec_procedure_stats ps WHERE lower(object_name(object_id)) = 'usp_arrumar_estagio'), GETDATE()) >= 1) BEGIN EXEC usp_arrumar_estagio END", Conectar()).ExecuteNonQuery();

                System.Data.DataTable dt = new System.Data.DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(new System.Data.SqlClient.SqlCommand("SELECT [Dia],[Entrada],[Saida],[Minutos Trabalhados],[Horas Trabalhadas],[Tempo na Casa],[Tempo exato] FROM vw_relatorio_estagio ORDER BY [old_entrada] ASC", Conectar()));
                da.Fill(dt);

                return dt;
            }
            catch (Exception erro)
            {
                throw new Exception("obterRelatorio: " + erro);
            }
        }

        public string obterHoraExtra()
        {
            try
            {
                string ret = new System.Data.SqlClient.SqlCommand("SELECT SUM(DATEDIFF(MINUTE, entrada, saida) - 360) / 60 AS 'Hora Extra' FROM dbo.ponto_estagio", Conectar()).ExecuteScalar().ToString();
                return ret;
            }
            catch (Exception erro)
            {
                throw new Exception("Inserir: " + erro);
            }
        }
    }
}
