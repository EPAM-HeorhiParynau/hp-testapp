using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Infrastructure.Models;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;

namespace Infrastructure.Services
{
    public class AzureBlobStorageLogger
    {
		private CloudBlobContainer blob;

		public AzureBlobStorageLogger()
		{
			string ConnectionString = @"DefaultEndpointsProtocol=https;AccountName=hpappteststorage;AccountKey=o8j4apRkWYs9QwGVzXxKtlNqjYDJk4oFs9dORJ3gDQ1YKidCIVWlhshWM4538UhUWCUqQHu4coKXkB9BmFUFPQ==;EndpointSuffix=core.windows.net";
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
			CloudBlobClient client = storageAccount.CreateCloudBlobClient();

			this.blob = client.GetContainerReference("hptestappblob1");
			this.blob.CreateIfNotExistsAsync();
		}


		public void InsertEntity(FileLogMessagecs logMessage)
		{
			try
			{
				
			}
			catch (Exception ExceptionObj)
			{
				throw ExceptionObj;
			}
		}
	}
}
