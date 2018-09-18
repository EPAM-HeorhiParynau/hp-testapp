using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Infrastructure.Repositories
{
    public class RepositoryBase
    {
	    protected static readonly IDbConnection _connection =
		    new SqlConnection("Server=tcp:hp-testapp-sqlserver.database.windows.net,1433;Initial Catalog=hp-testapp-sqldatabase;Persist Security Info=False;User ID=hp;Password=FullMoon124;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}
