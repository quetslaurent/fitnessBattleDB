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
        public static readonly string ColRepetitions = "repetitions";
        public static readonly string ColIdActivity = "tActivityId";
        public static readonly string ColIdUser = "tUserId";
        public static readonly string ColIdTrainingDate = "tTrainingDateId";
        public static readonly string ColPoints = "points";

        //requête de création
        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColIdActivity}, {ColIdUser}, {ColIdTrainingDate}, {ColRepetitions})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColIdActivity}, @{ColIdUser}, @{ColIdTrainingDate}, @{ColRepetitions})
        ";

        //requête renvoyant la liste
        public static readonly string ReqQuery = $@"
            SELECT *, {ColRepetitions}/activity.{ActivitySqlServer.ColRepetitions} as '{ColPoints}' FROM {TableName}
            INNER JOIN {ActivitySqlServer.TableName} activity on {ColIdActivity} = activity.{ActivitySqlServer.ColId}";
        
        //renvoie les entrainements en fonction de la date
        public static readonly string ReqGetByDateId = ReqQuery + $@" 
            INNER JOIN {CategorySqlServer.TableName} category on activity.{ActivitySqlServer.ColIdCategory}  = category.{CategorySqlServer.ColId} 
            INNER JOIN {UnitSqlServer.TableName} unit on activity.{ActivitySqlServer.ColIdUnit}  = unit.{UnitSqlServer.ColId} 
            INNER JOIN {UserSqlServer.TableName} userFitness on {ColIdUser} = userFitness.{UserSqlServer.ColId} 
            INNER JOIN {TrainingDateSqlServer.TableName} trainingDate on {ColIdTrainingDate} = trainingDate.{TrainingDateSqlServer.ColId} 
            WHERE {ColIdTrainingDate} = @{ColIdTrainingDate}";
        
        //renvoie les entrainements en fonction du user
        public static readonly string ReqGetByUserId = ReqQuery + $@" 
            INNER JOIN {CategorySqlServer.TableName} category on activity.{ActivitySqlServer.ColIdCategory}  = category.{CategorySqlServer.ColId} 
            INNER JOIN {UnitSqlServer.TableName} unit on activity.{ActivitySqlServer.ColIdUnit}  = unit.{UnitSqlServer.ColId} 
            INNER JOIN {UserSqlServer.TableName} userFitness on {ColIdUser} = userFitness.{UserSqlServer.ColId} 
            INNER JOIN {TrainingDateSqlServer.TableName} trainingDate on {ColIdTrainingDate} = trainingDate.{TrainingDateSqlServer.ColId} 
            WHERE {ColIdUser} = @{ColIdUser}";
       
        //requête de suppression
        public static readonly string ReqDeleteById = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId} 
        ";
        
        //requête qui renvoie et calcul les points d'un user
        public static readonly string ReqGetPointsByUserId = $@"
            SELECT ISNULL(SUM({ColRepetitions}/activity.{ActivitySqlServer.ColRepetitions}),0) as '{ColPoints}' FROM {TableName} 
            INNER JOIN {ActivitySqlServer.TableName} activity on  activity.{ActivitySqlServer.ColId}  = {ColIdActivity}
            WHERE {ColIdUser} = @{ColIdUser}
        ";
    }
}