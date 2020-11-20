namespace Infrastructure.SqlServer.User
{
    public class UserSqlServer
    {
        public static readonly string TableName = "userFitness";
        public static readonly string ColId = "id";
        public static readonly string ColName = "name";
        public static readonly string ColPassword = "password";
        public static readonly string ColEmail = "email";
        public static readonly string ColAdmin = "admin";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName}, {ColPassword}, {ColEmail}, {ColAdmin})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName}, @{ColPassword}, @{ColEmail}, @{ColAdmin})
        ";

        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";

        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColName} = @{ColName},
            {ColPassword} = @{ColPassword},
            {ColEmail} = @{ColEmail},
            {ColAdmin} = @{ColAdmin},
            WHERE {ColId} = @{ColId}
        ";
    }
}