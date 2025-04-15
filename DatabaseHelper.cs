using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Execute a SELECT query and return a list of results (for ComboBox or other lists)
    public async Task<List<Dictionary<string, object>>> ExecuteSelectQueryAsync(string query, Dictionary<string, object> parameters = null)
    {
        var results = new List<Dictionary<string, object>>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var command = new SqlCommand(query, connection))
            {
                // Add parameters if provided
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }
                        results.Add(row);
                    }
                }
            }
        }

        return results;
    }

    // Execute a non-query (INSERT, UPDATE, DELETE)
    public async Task<int> ExecuteNonQueryAsync(string query, Dictionary<string, object> parameters = null)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var command = new SqlCommand(query, connection))
            {
                // Add parameters if provided
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}

