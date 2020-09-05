using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pogged
{
    public class Sql
    {
        public static string CreateTables = 
                "CREATE TABLE IF NOT EXISTS `Channel` (" +
                    "`Id` INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY," +
                    "`Url` VARCHAR(45) NOT NULL UNIQUE" +
                ") " +
            "; " +
                "CREATE TABLE IF NOT EXISTS `Episodes` (" +
                    "`Id` INT(11) NOT NULL AUTO_INCREMENT UNIQUE PRIMARY KEY," +
                   	"`Channel` INT(11) NOT NULL," +
	                "`Title` TINYTEXT NOT NULL DEFAULT ''," +
	                "`Description` LONGTEXT NULL DEFAULT NULL" +
                ") " +
            ";";
    }
}
