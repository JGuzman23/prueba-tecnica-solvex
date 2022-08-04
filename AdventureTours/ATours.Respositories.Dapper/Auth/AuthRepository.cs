using ATours.Entities.Interfaces;
using ATours.Entities.POCOEntities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ATours.Respositories.Dapper.Auth
{
    public class AuthRepository: IAuthRepository
    {
        readonly IConnection _connection;
        readonly IConfiguration _configuration;

        public AuthRepository(IConnection connection, 
            IConfiguration configuration)
        {
            _connection = connection;
            _configuration = configuration;
        }


        public async Task<Cliente> Login(string email)
        {

            try
            {
                using var conn = _connection.GetConnection();
                string query = $"SELECT Id,Name,LastName,Email,CellPhone,IsActive FROM Cliente where Email ='{email}' ";
                var reader = await conn.QueryFirstOrDefaultAsync<Cliente>(query, commandType: CommandType.Text);



                return reader;
            }
            catch (Exception Ex)
            {
                Cliente user = new();
                //_logger.LogError(Ex.Message);
                return user;
            }

        }


        public async Task<string> ValidateUser(string key)
        {
            try
            {
                using var conn = _connection.GetConnection();
                string query = $"Select Password from Cliente where Email='{key}'";
                var reader = await conn.QueryFirstOrDefaultAsync<string>(query, commandType: CommandType.Text);

                return reader;
            }
            catch (Exception Ex)
            {
                //_logger.LogError(Ex.Message);
                return string.Empty;
            }

        }
     
    }
}
