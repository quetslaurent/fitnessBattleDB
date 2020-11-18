using System.Data.SqlClient;
using Domain.TrainingDate;

namespace Infrastructure.SqlServer.Factories
{
    public class TrainingDatesFactory
    {
        public ITrainingDate CreateFromReader(SqlDataReader reader)
        {
            return new Domain.TrainingDate.TrainingDate
            {
                Id = reader.GetInt32(reader.GetOrdinal(TrackingDateSqlServer.ColId)),
                Date = reader.GetDateTime(reader.GetOrdinal(TrackingDateSqlServer.ColDate))
            };
        }
    }
}