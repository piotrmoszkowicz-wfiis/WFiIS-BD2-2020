using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void _2(SqlDateTime dateTime, SqlInt32 minAge)
    {
        var rec = new SqlDataRecord(
            new SqlMetaData("LastName", SqlDbType.NVarChar, 50),
            new SqlMetaData("FirstName", SqlDbType.NVarChar, 50),
            new SqlMetaData("EmailAddress", SqlDbType.NVarChar, 50),
            new SqlMetaData("Age", SqlDbType.Int)
        );
        using (var mConnection = new SqlConnection("context connection=true"))
        {
            var mCmd = new SqlCommand(
                "SELECT LastName, FirstName, EmailAddress, DATEDIFF(year, BirthDate, @DATE) Age FROM HumanResources.Employee e " +
                "JOIN Person.Person p ON p.BusinessEntityId = e.BusinessEntityId " +
                "JOIN Person.EmailAddress ea ON ea.BusinessEntityId = p.BusinessEntityId " +
                "WHERE DATEDIFF(year, BirthDate, @DATE) > @MINAGE",
                mConnection
            );

            mCmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = dateTime;
            mCmd.Parameters.Add("@MINAGE", SqlDbType.Int).Value = minAge;

            try
            {
                mConnection.Open();
                var rdr = mCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    SqlContext.Pipe.SendResultsStart(rec);
                    while (rdr.Read())
                    {
                        rec.SetString(0, (string)rdr["LastName"]);
                        rec.SetString(1, (string)rdr["FirstName"]);
                        rec.SetString(2, (string)rdr["EmailAddress"]);
                        rec.SetInt32(3, (int)rdr["Age"]);
                        SqlContext.Pipe.SendResultsRow(rec);
                    }
                }
                SqlContext.Pipe.SendResultsEnd();
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
