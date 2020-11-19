using System.Collections.Generic;
using System.Data;

namespace Infrastructure.SqlServer.Activity
{
    public class ActivitySqlServer
    {
        
        public static readonly string TableName = "activity";
        public static readonly string ColId = "id";
        public static readonly string ColName = "name";
        public static readonly string ColRepetitions = "repetitions";
        public static readonly string ColIdUnit = "unitId";
        public static readonly string ColIdCategory = "categoryId";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName}, {ColRepetitions}, {ColIdUnit}, {ColIdCategory})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName}, @{ColRepetitions}, @{ColIdUnit}, @{ColIdCategory})
        ";

        public static readonly string ReqQuery = $"SELECT * FROM {TableName}";
        public static readonly string ReqGetById = ReqQuery + $" WHERE {ColId} = @{ColId}";

        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColName} = @{ColName},
            {ColRepetitions} = @{ColRepetitions},
            {ColIdUnit} = @{ColIdUnit},
            {ColIdCategory} = @{ColIdCategory},
            WHERE {ColId} = @{ColId}
        ";
        
        public static readonly string ReqGetByCategoryId = $@"
            SELECT * FROM {TableName} WHERE {ColIdCategory} = @{ColIdCategory} 
        ";
        
        public static readonly string ReqDeleteById = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId} 
        ";
        
    }
}