using Dapper;
using infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Repository
{
    public class SubjectRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public SubjectRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public string insert(SubjectModel subject)
        {
            try
            {
                connection.Execute("insert into subject(name, lastname, age, email, telephone) " +
                    " values(@name, @lastname, @age, @email, @telephone)", subject);
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modify(SubjectModel subject, int id)
        {
            try
            {
                connection.Execute($"UPDATE subject SET " +
                    "name = @name, " +
                    "lastname = @lastname, " +
                    "age = @age, " +
                    "email = @email, " +
                    "telephone = @telephone " +
                    $"WHERE id = {id}");
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string delete(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM subject WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SubjectModel getById(int id)
        {
            try
            {
                return connection.QueryFirst<SubjectModel>($"SELECT * FROM subject WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SubjectModel> read()
        {
            try
            {
                return connection.Query<SubjectModel>($"SELECT * FROM subject order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
