using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using WcfService2.objetos;

namespace WcfService2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {



        public Service1()
        {
            ConnectToDb();
        }
        SqlConnection conn;
        SqlCommand comm;

        SqlConnectionStringBuilder connStringBuilder;

        void ConnectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "172.30.20.172";
            connStringBuilder.InitialCatalog = "RRJ200";
            connStringBuilder.UserID = "sa";
            connStringBuilder.Password = "Ads720510.";

            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();

        }




        //public int InsertPerson(articulos p)
        //{
        //    try
        //    {
        //        comm.CommandText = "INSERT INTO TPerson VALUES(@Id, @Name, @Age)";
        //        comm.Parameters.AddWithValue("Id", p.Id);
        //        comm.Parameters.AddWithValue("Name", p.Name);
        //        comm.Parameters.AddWithValue("Age", p.Age);

        //        comm.CommandType = System.Data.CommandType.Text;
        //        conn.Open();

        //        return comm.ExecuteNonQuery();

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn != null)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}



        //public int UpdatePerson(articulos p)
        //{
        //    try
        //    {
        //        comm.CommandText = "UPDATE TPerson SET Name=@Name, Age=@Age WHERE Id=@Id ";
        //        comm.Parameters.AddWithValue("Id", p.Id);
        //        comm.Parameters.AddWithValue("Name", p.Name);
        //        comm.Parameters.AddWithValue("Age", p.Age);
        //        comm.CommandType = System.Data.CommandType.Text;
        //        conn.Open();

        //        return comm.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn != null)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}

        //public int DeletePerson(articulos p)
        //{
        //    try
        //    {
        //        comm.CommandText = "DELETE TPerson WHERE Id=@Id";
        //        comm.Parameters.AddWithValue("Id", p.Id);
        //        comm.CommandType = System.Data.CommandType.Text;
        //        conn.Open();

        //        return comm.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn != null)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        
        public List<articulos> GetAlliTEMS()
        {
            
            List<articulos> personL = new List<articulos>();
            try
            {
                comm.CommandText = "select * from articulosApp order by 1";
                comm.CommandType = System.Data.CommandType.Text;
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    articulos articulo = new articulos()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString(),
                        Foto = reader[2].ToString(),
                        Marca = reader[3].ToString()

                    };
                    personL.Add(articulo);
                }
                return personL;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }



    }
}
