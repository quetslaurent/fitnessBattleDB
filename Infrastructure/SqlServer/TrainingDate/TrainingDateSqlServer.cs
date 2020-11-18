namespace Infrastructure.SqlServer.TrainingDate
{
    public class TrainingDateSqlServer
    {
        public static readonly string TableName = "category";
        public static readonly string ColId = "id";
        public static readonly string ColDate = "date";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColDate})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColDate})
        ";

        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";

        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColDate} = @{ColDate},
            WHERE {ColId} = @{ColId}
        ";
    }
}