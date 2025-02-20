namespace CrudNotebook.Data
{
    public class Connection
    {
        private string _connectionString = String.Empty;

        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            _connectionString = builder.GetSection("ConnectionStrings:SQLConnection").Value;
        }

        public string getConnectionString()
        {
            return _connectionString;
        }
    }
}
