using System.Data.SqlClient;
using Domain.TrainingDate;
using Infrastructure.SqlServer.TrainingDate;

namespace Infrastructure.SqlServer.Factories
{
    public class TrainingDatesFactory : IInstanceFromReaderFactory<ITrainingDate>
    {
        //crée une trainingDate depuis le reader
        public ITrainingDate CreateFromReader(SqlDataReader reader)
        {
            return new Domain.TrainingDate.TrainingDate
            {
                Id = reader.GetInt32(reader.GetOrdinal(TrainingDateSqlServer.ColId)),
                Date = reader.GetDateTime(reader.GetOrdinal(TrainingDateSqlServer.ColDate))
            };
        }
    }
}