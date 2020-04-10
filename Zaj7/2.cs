using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Transactions;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void _2()
    {
        using (TransactionScope oTran = new TransactionScope())
        {
            using (SqlConnection oConn = new SqlConnection("context connection=true;"))
            {
                oConn.Open();
                SqlCommand oCmd = new SqlCommand("INSERT INTO [AdventureWorks2008].[dbo].[Konta] (name, value) VALUES ('user1', 6.66)", oConn);
                oCmd.ExecuteNonQuery();
                SqlCommand oCmd2 = new SqlCommand("INSERT INTO [AdventureWorks2008].[dbo].[Konta] (name, value) VALUES ('user2', 6.66)", oConn);
                oCmd2.ExecuteNonQuery();
                SqlCommand oCmd3 = new SqlCommand("INSERT INTO [AdventureWorks2008].[dbo].[Konta] (name, value) VALUES ('user1', 6.66)", oConn);
                oCmd3.ExecuteNonQuery();
                oTran.Complete();
            }
        }
    }
};
