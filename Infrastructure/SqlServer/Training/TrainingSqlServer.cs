using Infrastructure.SqlServer.Activity;
using Infrastructure.SqlServer.Category;
using Infrastructure.SqlServer.TrainingDate;
using Infrastructure.SqlServer.Unit;
using Infrastructure.SqlServer.User;

namespace Infrastructure.SqlServer.Training
{
    public class TrainingSqlServer
    {
        public static readonly string TableName = "training";
        public static readonly string ColId = "trainingId";
        public static readonly string ColRepetitions = "repetitionsNeeded";
        public static readonly string ColIdActivity = "tActivityId";
        public static readonly string ColIdUser = "tUserId";
        public static readonly string ColIdTrainingDate = "tTrainingDateId";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColIdActivity}, {ColIdUser}, {ColIdTrainingDate}, {ColRepetitions})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColIdActivity}, @{ColIdUser}, @{ColIdTrainingDate}, @{ColRepetitions})
        ";

        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        
        public static readonly string ReqGetById = ReqQuery + $@" 
            INNER JOIN {ActivitySqlServer.TableName} activity on {ColIdActivity} = activity.{ActivitySqlServer.ColId} 
            INNER JOIN {CategorySqlServer.TableName} category on activity.{ActivitySqlServer.ColIdCategory}  = category.{CategorySqlServer.ColId} 
            INNER JOIN {UnitSqlServer.TableName} unit on activity.{ActivitySqlServer.ColIdUnit}  = unit.{UnitSqlServer.ColId} 
            INNER JOIN {UserSqlServer.TableName} userFitness on {ColIdUser} = userFitness.{UserSqlServer.ColId} 
            INNER JOIN {TrainingDateSqlServer.TableName} trainingDate on {ColIdTrainingDate} = trainingDate.{TrainingDateSqlServer.ColId} 
            WHERE {ColIdTrainingDate} = @{ColIdTrainingDate}";
       
        public static readonly string ReqDeleteById = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId} 
        ";
        
        public static readonly string ReqGetByTrainingId = $@"
            SELECT * FROM {TableName} WHERE {ColIdTrainingDate} = @{ColIdTrainingDate} 
        ";

    }
}