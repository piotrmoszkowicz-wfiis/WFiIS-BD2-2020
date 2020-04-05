using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void _4(SqlInt32 bID)
    {
        using (var mConnection = new SqlConnection("context connection=true"))
        {
            var mCmd = new SqlCommand(
                "SELECT LastName + ';' + MiddleName + ';' + FirstName + ';' + AddressLine1 FROM HumanResources.Employee e " +
                "JOIN Person.Person p ON p.BusinessEntityID = e.BusinessEntityID " +
                "JOIN Person.BusinessEntity pbe ON pbe.BusinessEntityID = p.BusinessEntityID " +
                "JOIN Person.BusinessEntityAddress pbea ON pbea.BusinessEntityID = pbe.BusinessEntityID " +
                "JOIN Person.Address pa ON pa.AddressID = pbea.AddressID " +
                "WHERE e.BusinessEntityID = @ID",
                mConnection
            );

            mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = bID;

            try
            {
                mConnection.Open();
                SqlContext.Pipe.ExecuteAndSend(mCmd);
            }
            catch (SqlException e)
            {
                SqlContext.Pipe.Send(e.Message.ToString());
            }
            finally
            {
                mConnection.Close();
            }
        }
    }
};
