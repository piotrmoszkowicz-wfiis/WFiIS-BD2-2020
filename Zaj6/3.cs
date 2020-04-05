using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(DataAccess=DataAccessKind.Read)]
    public static SqlString _3(SqlInt32 bID)
    {
        var res = new SqlString("NULL");

        using (var mConnection = new SqlConnection("context connection=true"))
        {
            var mCmd = new SqlCommand(
                "SELECT LastName + ';' + FirstName + ';' + CONVERT(VARCHAR, DATEDIFF(year, BirthDate, GETDATE())) Result FROM HumanResources.Employee e " +
                "JOIN Person.Person p ON p.BusinessEntityID = e.BusinessEntityID " +
                "WHERE e.BusinessEntityID = @ID;",
                mConnection
            );

            mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = bID;

            mConnection.Open();

            try
            {
                var rdr = mCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        res = (string)rdr["Result"];
                    }
                }
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

        return res;
    }
};

