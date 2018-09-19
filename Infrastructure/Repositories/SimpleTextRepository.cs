using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper;

using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class SimpleTextRepository : RepositoryBase
    {
	    public SimpleTextEntity Get(int id)
	    {
		    return _connection.Query<SimpleTextEntity>("select * from [TextValues] where [Id] = @Id", new { Id = id }).First();
	    }
    }
}
