namespace Infrastructure.SqlServer.User
{
    public class UserSqlServer
    {
        public static readonly string TableName = "userFitness";
        public static readonly string ColId = "userId";
        public static readonly string ColName = "name";
        public static readonly string ColPassword = "password";
        public static readonly string ColEmail = "email";
        public static readonly string ColRole = "role";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName}, {ColPassword}, {ColEmail}, {ColRole})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName}, @{ColPassword}, @{ColEmail}, @{ColRole})
        ";

        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";

        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColName} = @{ColName},
            {ColPassword} = @{ColPassword},
            {ColEmail} = @{ColEmail},
            {ColRole} = @{ColRole}
            WHERE {ColId} = @{ColId}
        ";

        public static readonly string ReqDeleteById = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId} 
        ";
    }
}