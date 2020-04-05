using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(DataAccess=DataAccessKind.Read)]
    public static SqlInt32 _1(SqlInt32 bID)
    {
        var res = new SqlInt32();
        using (var mConnection = new SqlConnection("context connection=true")) {
            var mCmd = new SqlCommand("SELECT BirthDate FROM HumanResources.Employee WHERE BusinessEntityId = @ID", mConnection);
            mCmd.Parameters.Add("@ID", SqlDbType.Int).Value = bID;
            mConnection.Open();

            try
            {
                var rdr = mCmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        var tDiff = (DateTime.Now).Subtract((DateTime)rdr["BirthDate"]);
                        res = ((tDiff.Days) / 365);
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

