namespace Infrastructure.SqlServer.Unit
{
    public class UnitSqlServer
    {
        public static readonly string TableName = "unit";
        public static readonly string ColId = "id";
        public static readonly string ColType = "type";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColType})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColType})
        ";

        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";

        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColType} = @{ColType},
            WHERE {ColId} = @{ColId}
        ";
    }
}