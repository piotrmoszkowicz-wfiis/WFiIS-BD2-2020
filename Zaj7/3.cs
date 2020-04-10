using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Transactions;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void _3()
    {
        int returnValue;
        using (TransactionScope oTran = new TransactionScope())
        {
            using (SqlConnection oConn = new SqlConnection("context connection=true;"))
            {
                oConn.Open();
                SqlCommand update = new SqlCommand("UPDATE [AdventureWorks2008].[dbo].[Konta] SET value = value + 66.6 WHERE name = 'KonradAleInny'", oConn);
                returnValue = update.ExecuteNonQuery();
                using (SqlConnection remConn = new SqlConnection("Data Source=MSSQLSERVER64;Initial Catalog=AdventureWorks2008;User Id=labuser;Password=Passw0rd;"))
                {
                    returnValue = 0;
                    remConn.Open();
                    SqlCommand updateRemote = new SqlCommand("UPDATE [AdventureWorks2008].[dbo].[Konta] SET value = value - 66.6 WHERE name = 'KonradAleInny'", remConn);
                    returnValue = updateRemote.ExecuteNonQuery();
                    oTran.Complete();
                }
            }
        }
    }
};
