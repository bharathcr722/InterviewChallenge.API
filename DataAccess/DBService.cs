using LiteDB;

namespace InterviewChallenge.API.DataAccess
{
    public class DBService
    {
        private readonly string _connectionString;

        public DBService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionString:LiteDbConnectionString");
        }
        public LiteDatabase GetDatabase()
        {
            return new LiteDatabase(_connectionString);
        }
    }
}
