using Capa.Dominio.Sistema;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace IRepositorio
{
    public class LogErrorRepository: ILogErrorRepository
    {
        private IConfiguration _IConfiguration;
        private string cadenaConexion;

        public LogErrorRepository(IConfiguration iConfiguration)
        {
            this._IConfiguration = iConfiguration;
            this.cadenaConexion = this._IConfiguration.GetConnectionString("cnnPGSQL");
        }

        public bool insertError(LogError error)
        {
            var result = false;
            try
            {
                var procedure = @"sys.insert_error";
                NpgsqlConnection pgcon = new NpgsqlConnection(cadenaConexion);
                pgcon.Open();
                NpgsqlCommand pgcom = new NpgsqlCommand(procedure, pgcon);
                pgcom.CommandType = CommandType.StoredProcedure;
                pgcom.Parameters.AddWithValue(":v_mensaje", error.mensaje);
                pgcom.Parameters.AddWithValue(":v_tabla", error.tabla);

                NpgsqlDataReader pgreader = pgcom.ExecuteReader();
                while (pgreader.Read())
                {
                    result = Convert.ToBoolean(pgreader.GetInt32(0));
                }
                pgcon.Close();
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
