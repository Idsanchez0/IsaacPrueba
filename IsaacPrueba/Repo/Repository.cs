
using IsaacPrueba.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacPrueba.Repo
{
    public class Repository
    {
        private readonly string _connectionString;


        public Repository(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("StringConnection");
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var listEmployee = new List<Employee>();

            try {
                using (OracleConnection objConn = new OracleConnection(_connectionString))
                {

                    using (OracleCommand orcmd = new OracleCommand("SELECT * FROM MAEFUNC WHERE FEC_DESV_MF IS NULL", objConn))
                    {

                        orcmd.Connection = objConn;
                        orcmd.InitialLOBFetchSize = 1000;
                        orcmd.CommandType = CommandType.Text;

                        //orcmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objConn.Open();
                        OracleDataReader dr = orcmd.ExecuteReader();
                        while (dr.Read())
                        {
                            var list = new Employee();

                            list.CodMf = Convert.ToInt32(dr["COD_MF"].ToString());

                            list.Cedide_Mf =dr["CEDIDE_MF"].ToString();

                            list.NomFav_mf = dr["NOMFAV_MF"].ToString();

                            list.Sjh_Mf = dr["SJH_MF"].ToString();

                            listEmployee.Add(list);
                        }
                        objConn.Close();


                        return listEmployee;
                    }
                }

            }
            catch (Exception ex)
            {
                return listEmployee;
            }

           
        }



        public async Task<List<Employee>> GetIngresoAportables()
        {
            var listEmployee = new List<Employee>();
            string cod = "11304";
            try
            {
                using (OracleConnection objConn = new OracleConnection(_connectionString))
                {

                    using (OracleCommand orcmd = new OracleCommand("SELECT IMPTOT_HD FROM MOVHD WHERE COD_MF= "+ cod + " AND COD_MV=1000 AND FEC_VAL_HD BETWEEN '01/05/2021' AND '31/05/2021' and cod_lq<>0", objConn))
                    {

                        orcmd.Parameters.Add("@cod", OracleDbType.NChar).Value = "11304";

                        orcmd.Connection = objConn;
                        orcmd.InitialLOBFetchSize = 1000;
                        orcmd.CommandType = CommandType.Text;

                        //orcmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //orcmd.Parameters.Add("CODIGO", OracleDbType.NChar).Value = "11304";

                        objConn.Open();
                        OracleDataReader dr = orcmd.ExecuteReader();
                        while (dr.Read())
                        {
                            var list = new Employee();

                        

                            list.Imptot = dr["IMPTOT_HD"].ToString();

                           

                            listEmployee.Add(list);
                        }
                        objConn.Close();


                        return listEmployee;
                    }
                }

            }
            catch (Exception ex)
            {
                return listEmployee;
            }


        }



        public Employee MapToEmployee(OracleDataReader reader)
        {

            return new Employee()
            {
                CodMf = (int) reader["COD_MF"],
                //Cedide_Mf = reader["CEDIDE_MF"].ToString(),
                //NomFav_mf = reader["NOMFAV_MF"].ToString(),
                //Sjh_Mf = reader["SJH_MF"].ToString(),

            };

        }


    }
}
