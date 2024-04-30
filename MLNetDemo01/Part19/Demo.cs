using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part19
{
    public class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext();

            var databaseLoader = context.Data.CreateDatabaseLoader<InputModel>();

            string connectionString = "Data Source=HOFS2406101750A\\SQLEXPRESS;Initial Catalog=DefaultConnection;Integrated Security=True;";
            string commandText = "Select sd.YearsOfExperience, sd.Salary from SalaryData sd";

            var databaseSource = new DatabaseSource(SqlClientFactory.Instance, connectionString, commandText);
            IDataView dataView = databaseLoader.Load(databaseSource);

            var preview = dataView.Preview();
        }
    }
}
