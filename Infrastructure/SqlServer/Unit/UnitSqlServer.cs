namespace Infrastructure.SqlServer.Unit
{
    public class UnitSqlServer
    {
        public static readonly string TableName = "unit";
        public static readonly string ColId = "unitId";
        public static readonly string ColType = "type";

        //requête de création
        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColType})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColType})
        ";

        //requête qui renvoie la liste
        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        //renvoie l'unit correspondant à l'id
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";

        //requête de modification
        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColType} = @{ColType},
            WHERE {ColId} = @{ColId}
        ";
    }
}