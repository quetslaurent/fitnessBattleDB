namespace Infrastructure.SqlServer.Training
{
    public class TrainingSqlServer
    {
        public static readonly string TableName = "training";
        public static readonly string ColId = "id";
        public static readonly string ColRepetitions = "repetitions";
        public static readonly string ColIdActivity = "activityId";
        public static readonly string ColIdUser = "userId";
        public static readonly string ColIdTrainingDate = "trainingDateId";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColIdActivity}, {ColIdUser}, {ColIdTrainingDate}, {ColRepetitions})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColIdActivity}, @{ColIdUser}, @{ColIdTrainingDate}, @{ColRepetitions})
        ";

        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";
        public static readonly string ReqDeleteById = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId} 
        ";
        
        public static readonly string ReqGetByTrainingId = $@"
            SELECT * FROM {TableName} WHERE {ColIdTrainingDate} = @{ColIdTrainingDate} 
        ";

    }
}