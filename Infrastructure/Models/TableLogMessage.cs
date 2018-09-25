using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.WindowsAzure.Storage.Table;

namespace Infrastructure.Models
{
    public class TableLogMessage : TableEntity
    {
	    public TableLogMessage()
	    {
		    this.PartitionKey = "TableLogMessage";
		    this.RowKey = Guid.NewGuid().ToString();
	    }

		public string Message { get; set; }

    }
}
