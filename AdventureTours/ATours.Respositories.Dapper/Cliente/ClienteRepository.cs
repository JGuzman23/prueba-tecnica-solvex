using ATours.Entities.Exceptions;
using ATours.Entities.Interfaces;
using ATours.Entities.Interfaces.User;
using ATours.Entities.POCOEntities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATours.Respositories.Dapper.Users
{
    public class ClienteRepository : IClienteRepository
    {
        readonly IConnection _connection;
        
        public ClienteRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            using var con = _connection.GetConnection();
            try
            {
                var query = $"SELECT Name,LastName,Email,CellPhone,IsActive FROM  CLIENTE";
                var reader = await con.QueryAsync<Cliente>(query);
                return reader.AsList();
            }
            catch (Exception Ex) { throw new GeneralException("Error al obtener el usuario", Ex.Message); }
        }


        public async Task CreateClienteAsyc(Cliente model)
        {
            using var con = _connection.GetConnection();
            try
            {
                var query = "INSERT INTO CLIENTE (Name,LastName,Email,CellPhone,IsActive,Password) VALUES(@Name,@LastName,@Email,@CellPhone,@IsActive,@Password)";
                await con.ExecuteAsync(query, model);
            }
            catch (Exception Ex)
            {
                throw new GeneralException("Error al crear el usuario", Ex.Message);
            }

        }

        public async Task<Cliente> GetClienteById (int id)
        {using var con = _connection.GetConnection();
            try
            {
                var query = $"SELECT Id,Name,LastName,Email,CellPhone,IsActive FROM  CLIENTE WHERE ID={id}";
                var reader = await con.QueryFirstOrDefaultAsync<Cliente>(query);
                return reader;
            }
            catch (Exception Ex) { throw new GeneralException("Error al obtener el usuario", Ex.Message); }
        }


        public async Task<Cliente> GetClienteByEmail(string email)
        {
            using var con = _connection.GetConnection();
            try
            {
                var query = $"SELECT 1 FROM  CLIENTE WHERE Email={email}";
                var reader = await con.QueryFirstAsync<Cliente>(query);
                return reader;
            }
            catch (Exception e)
            {
                throw new GeneralException("Error al obtener el usuario", e.Message);
            }
        }

        public async Task UpdateCliente(Cliente model)
        {
            using var con = _connection.GetConnection();
            try
            {
                var querry = $"UPDATE Cliente Set Name='{model.Name}', LastName='{model.LastName}', Email='{model.Email}', CellPhone='{model.CellPhone}' WHERE Id={model.Id}";
                await con.ExecuteAsync(querry, model);

            }
            catch (Exception e)
            {
                throw new GeneralException("Error al actualizar el cliente", e.Message);
            }

        }

       
    }
}
