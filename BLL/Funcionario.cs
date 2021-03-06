﻿using System;

namespace BLL
{
    public class Funcionario
    {
        public DateTime entrada { get; set; }
        public DateTime entrada_almoco { get; set; }
        public DateTime saida_almoco { get; set; }
        public DateTime saida { get; set; }
        protected System.Data.SqlClient.SqlConnection Conectar()
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
        public virtual System.Data.DataTable obterRelatorio()
        {
            try
            {
                // WHAT THIS LINE BELOW DOES:
                // check the last time that the procedure 'usp_arrumar_estagio' ran
                // if it's equal to 1 day or more run the procedure 'usp_arrumar_estagio' again
                // else do nothing
                new System.Data.SqlClient.SqlCommand("IF(DATEDIFF(DAY, (SELECT TOP 1 last_execution_time FROM sys.dm_exec_procedure_stats ps WHERE lower(object_name(object_id)) = 'usp_arrumar_clt'), GETDATE()) >= 1) BEGIN EXEC usp_arrumar_clt END", Conectar()).ExecuteNonQuery();

                System.Data.DataTable dt = new System.Data.DataTable();
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(new System.Data.SqlClient.SqlCommand("SELECT [old_entrada_almoco],[old_saida_almoco],[Dia],[Entrada],[Foi Almoçar],[Voltou do Almoço],[Saida],[Minutos Trabalhados],[Horas Trabalhadas],[Tempo na Casa],[Tempo exato] FROM vw_relatorio_clt ORDER BY old_entrada ASC", Conectar()));
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

        public string obterHoraExtra()
        {
            try
            {
                string ret = new System.Data.SqlClient.SqlCommand("SELECT SUM(CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) / 60 AS 'Hora Extra' FROM dbo.ponto_clt", Conectar()).ExecuteScalar().ToString();
                return ret;
            }
            catch (Exception erro)
            {
                throw new Exception("Inserir: " + erro);
            }
        }
    }
}
