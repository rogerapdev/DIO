using Azure.Data.Tables;

namespace DIO.AzureHRSystem.Repositories
{
    public class TableClientRepository
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public TableClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionStrings:SAConnectionString");
            _tableName = configuration.GetValue<string>("ConnectionStrings:AzureTableName");
        }

        public TableClient GetTableClient()
        {
            var serviceClient = new TableServiceClient(_connectionString);
            var tableClient = serviceClient.GetTableClient(_tableName);

            tableClient.CreateIfNotExists();
            
            return tableClient;
        }
    }
}