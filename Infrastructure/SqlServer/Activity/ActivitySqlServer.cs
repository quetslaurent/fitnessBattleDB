﻿using System.Collections.Generic;
using System.Data;
using Infrastructure.SqlServer.Category;
using Infrastructure.SqlServer.Unit;

namespace Infrastructure.SqlServer.Activity
{
    public class ActivitySqlServer
    {
        
        public static readonly string TableName = "activity";
        public static readonly string ColId = "activityId";
        public static readonly string ColName = "name";
        public static readonly string ColRepetitions = "repetitionsNeeded";
        public static readonly string ColIdUnit = "aUnitId";
        public static readonly string ColIdCategory = "aCategoryId";

        //requête de création
        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName}, {ColRepetitions}, {ColIdUnit}, {ColIdCategory})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName}, @{ColRepetitions}, @{ColIdUnit}, @{ColIdCategory})
        ";

        //renvoie la liste
        public static readonly string ReqQuery = $@"
            SELECT * FROM {TableName}
            INNER JOIN {UnitSqlServer.TableName} unit on {ColIdUnit} = unit.{UnitSqlServer.ColId} 
            INNER JOIN {CategorySqlServer.TableName} category on {ColIdCategory} = category.{CategorySqlServer.ColId}";
        
        //renvoie en fonction de l'id
        public static readonly string ReqGetById = ReqQuery + $@"
            WHERE {ColId} = @{ColId}";

        //requête de mofication
        public static readonly string ReqPut = $@"
            UPDATE {TableName} SET
            {ColName} = @{ColName},
            {ColRepetitions} = @{ColRepetitions},
            {ColIdUnit} = @{ColIdUnit},
            {ColIdCategory} = @{ColIdCategory} 
            WHERE {ColId} = @{ColId}
        ";

        //renvoie en fonction de la categorie
        public static readonly string ReqGetByCategoryId = ReqQuery + $@"
            WHERE {ColIdCategory} = @{ColIdCategory}";
        
        //requête de suppression
        public static readonly string ReqDeleteById = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId} 
        ";
        
    }
}