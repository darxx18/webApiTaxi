using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


namespace webApiTaxi
{
    public class LicenseRepository: ILicenseRepository
    {
        private readonly string _connectionString;
        public LicenseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<License>> GetAllLicenseAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<License>("SELECT * FROM License");
        }
        public async Task<License?> GetLicenseByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<License>("SELECT * FROM License WHERE ID = @ID", new { ID });
        }

        public async Task AddLicenseAsync(License license)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO License (id_driv, license_issue_date, license_expiry_date, issued_by, license_code, residence, category) " +
                "VALUES (@id_driv, @license_issue_date, @license_expiry_date, @issued_by, @license_code, @residence, @category)", license);
        }

        public async Task UpdateLicenseAsync(License license)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE License SET id_driv = @id_driv, license_issue_date = @license_issue_date, license_expiry_date = @license_expiry_date, issued_by = @issued_by, license_code = @license_code, residence = @residence, category = @category WHERE ID = @ID", license);
        }

        public async Task DeleteLicenseAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM License WHERE ID = @ID", new { ID });
        }
    }
}
