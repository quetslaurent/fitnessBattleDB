namespace Infrastructure.SqlServer.Category
{
    public class CategorySqlServer
    {
        public static readonly string TableName = "category";
        public static readonly string ColId = "categoryId";
        public static readonly string ColName = "categoryName";

        //requête de creation
        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName})
        ";

        //requête renvoyant la liste
        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        //renvoie si l'id corresponds
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";

        //requête de modification
        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColName} = @{ColName},
            WHERE {ColId} = @{ColId}
        ";

    }
}