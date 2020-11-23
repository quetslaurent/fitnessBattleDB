namespace Infrastructure.SqlServer.Category
{
    public class CategorySqlServer
    {
        public static readonly string TableName = "category";
        public static readonly string ColId = "id";
        public static readonly string ColName = "categoryName";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName})
        ";

        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";

        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColName} = @{ColName},
            WHERE {ColId} = @{ColId}
        ";

    }
}