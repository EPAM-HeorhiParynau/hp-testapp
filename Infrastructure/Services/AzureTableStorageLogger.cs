using System;
using System.Collections.Generic;
using System.Text;

using Infrastructure.Models;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Infrastructure.Services
{
    public class AzureTableStorageLogger
    {
	    // private property  
	    private CloudTable table;

	    public AzureTableStorageLogger()
	    {
			string ConnectionString = @"DefaultEndpointsProtocol=https;AccountName=hpappteststorage;AccountKey=o8j4apRkWYs9QwGVzXxKtlNqjYDJk4oFs9dORJ3gDQ1YKidCIVWlhshWM4538UhUWCUqQHu4coKXkB9BmFUFPQ==;EndpointSuffix=core.windows.net";
		    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
		    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

		    table = tableClient.GetTableReference("hpapptestlogs");
		    table.CreateIfNotExistsAsync().Wait();
		}


	    public void InsertEntity(TableLogMessage logMessage, bool forInsert = true)
	    {
		    try
		    {
			    if (forInsert)
			    {
				    var insertOperation = TableOperation.Insert(logMessage);
				    table.ExecuteAsync(insertOperation).Wait();
			    }
			    else
			    {
				    var insertOrMergeOperation = TableOperation.InsertOrReplace(logMessage);
				    table.ExecuteAsync(insertOrMergeOperation).Wait();
			    }
		    }
		    catch (Exception ExceptionObj)
		    {
			    throw ExceptionObj;
		    }
	    }

	}
}
