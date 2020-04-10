using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Transactions;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void _4()
    {
        System.Transactions.CommittableTransaction oTran = new CommittableTransaction();
        using (SqlConnection oConn = new SqlConnection("context connection=true"))
        {
            try
            {
                SqlCommand oCmd = new SqlCommand();
                oConn.Open();
                //przekazujemy obiekt CommittableTransaction
                oConn.EnlistTransaction(oTran);
                oCmd.Connection = oConn;
                // insert nr 1
                oCmd.CommandText = "INSERT INTO [AdventureWorks2008].[dbo].[Konta] (name, value) VALUES ('user5', 6.66)";
                SqlContext.Pipe.ExecuteAndSend(oCmd);
                // insert nr 2
                oCmd.CommandText = "INSERT INTO [AdventureWorks2008].[dbo].[Konta] (name, value) VALUES ('user6', 6.66)";
                SqlContext.Pipe.ExecuteAndSend(oCmd);
                // insert nr 3
                oCmd.CommandText = "INSERT INTO [AdventureWorks2008].[dbo].[Konta] (name, value) VALUES ('user5', 6.66)";
                SqlContext.Pipe.ExecuteAndSend(oCmd);

                oTran.Commit();
            }
            catch (SqlException ex)
            {
                oTran.Rollback();
            }
            finally
            {
                oTran.Dispose();
            }
        }
    }
};
