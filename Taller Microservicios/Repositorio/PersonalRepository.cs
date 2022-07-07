using Capa.Dominio;
using Capa.Dominio.Sistema;
using IRepositorio;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio
{
    class PersonalRepository : IPersonalRepository
    {
        private IConfiguration _IConfiguration;
        private string cadenaConexion;
        LogErrorRepository _logErrorRepository;
        LogError error;

        public PersonalRepository(IConfiguration iConfiguration)
        {
            this._IConfiguration = iConfiguration;
            this.cadenaConexion = this._IConfiguration.GetConnectionString("cnnPGSQL");
        }

        public int deletePersonal(int id)
        {
            throw new System.NotImplementedException();
        }

        public int insertPersonal(Personal personal)
        {
            var result = 0;
            try
            {

                String procedure = @"sys.personal_insertar";
                NpgsqlConnection pgcon = new NpgsqlConnection(cadenaConexion);
                pgcon.Open();
                NpgsqlCommand pgcom = new NpgsqlCommand(procedure, pgcon);
                pgcom.CommandType = CommandType.StoredProcedure;
                pgcom.Parameters.AddWithValue(":v_paterno", personal.paterno);
                pgcom.Parameters.AddWithValue(":v_materno", personal.materno);
                pgcom.Parameters.AddWithValue(":v_nombre", personal.nombres);
                pgcom.Parameters.AddWithValue(":v_dni", personal.dni);

                NpgsqlDataReader pgreader = pgcom.ExecuteReader();
                while (pgreader.Read())
                {
                    result = pgreader.GetInt32(0);
                }
                pgcon.Close();
            }
            catch (Exception ex)
            {
                error.tabla = "personal insertar";
                error.mensaje = ex.Message.ToString();
                _logErrorRepository.insertError(error);
            }
            return result;
        }

        public Personal personalId(int id)
        {
            Personal objt = new Personal();
            try
            {

                string procedure = @"sys.personal_id";
                NpgsqlConnection pgcon = new NpgsqlConnection(cadenaConexion);
                pgcon.Open();
                NpgsqlCommand pgcom = new NpgsqlCommand(procedure, pgcon);
                pgcom.CommandType = CommandType.StoredProcedure;
                pgcom.Parameters.AddWithValue(":v_id", id);
                NpgsqlDataReader pgreader = pgcom.ExecuteReader();

                while (pgreader.Read())
                {
                    objt.id = Convert.ToInt32(pgreader["id"]);
                    objt.paterno = pgreader["paterno"].ToString();
                    objt.materno = pgreader["materno"].ToString();
                    objt.nombres = pgreader["nombres"].ToString();
                    objt.dni = pgreader["dni"].ToString();
                }
                pgcon.Close();

            }
            catch (Exception ex)
            {
                error.tabla = "personal id";
                error.mensaje = ex.Message.ToString();
                _logErrorRepository.insertError(error);
            }
            return objt;
        }

        public List<Personal> personalList()
        {
            List<Personal> objList = new List<Personal>();
            try
            {
                string procedure = @"sys.personal_listar";
                NpgsqlConnection pgcon = new NpgsqlConnection(cadenaConexion);
                pgcon.Open();
                NpgsqlCommand pgcom = new NpgsqlCommand(procedure, pgcon);
                pgcom.CommandType = CommandType.StoredProcedure;
                //pgcom.Parameters.AddWithValue(":v_id_profesional", id_profesional);
                NpgsqlDataReader pgreader = pgcom.ExecuteReader();
                while (pgreader.Read())
                {
                    Personal obj = new Personal();
                    obj.id = Convert.ToInt32(pgreader["id"]);
                    obj.paterno = pgreader["paterno"].ToString(); 
                    obj.materno = pgreader["materno"].ToString(); 
                    obj.nombres = pgreader["nombre"].ToString();
                    obj.dni = pgreader["dni"].ToString();
                    objList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                error = new LogError();
                error.tabla = "Personal Listar";
                error.mensaje = ex.Message.ToString();
                _logErrorRepository.insertError(error);
            }
            return objList;
        }

        public int updatePersonal(Personal personal)
        {
            var result = 0;
            try
            {

                String procedure = @"sys.personal_actualizar";
                NpgsqlConnection pgcon = new NpgsqlConnection(cadenaConexion);
                pgcon.Open();
                NpgsqlCommand pgcom = new NpgsqlCommand(procedure, pgcon);
                pgcom.CommandType = CommandType.StoredProcedure;
                pgcom.Parameters.AddWithValue(":v_id", personal.id);
                pgcom.Parameters.AddWithValue(":v_paterno", personal.paterno);
                pgcom.Parameters.AddWithValue(":v_materno", personal.materno);
                pgcom.Parameters.AddWithValue(":v_nombre", personal.nombres);
                pgcom.Parameters.AddWithValue(":v_dni", personal.dni);

                NpgsqlDataReader pgreader = pgcom.ExecuteReader();
                while (pgreader.Read())
                {
                    result = pgreader.GetInt32(0);
                }
                pgcon.Close();
            }
            catch (Exception ex)
            {
                error.tabla = "personal actualizar";
                error.mensaje = ex.Message.ToString();
                _logErrorRepository.insertError(error);
            }
            return result;
        }
    }
}
