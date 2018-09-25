using System;
using System.IO;
using System.Text;

using Infrastructure.Models;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Infrastructure.Services
{
    public class AzureFileStorageLogger
    {
	    private CloudFileShare share;

	    public AzureFileStorageLogger()
	    {
		    string ConnectionString = @"DefaultEndpointsProtocol=https;AccountName=hpappteststorage;AccountKey=o8j4apRkWYs9QwGVzXxKtlNqjYDJk4oFs9dORJ3gDQ1YKidCIVWlhshWM4538UhUWCUqQHu4coKXkB9BmFUFPQ==;EndpointSuffix=core.windows.net";
		    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
		    CloudFileClient client = storageAccount.CreateCloudFileClient();

		    this.share = client.GetShareReference("hptestappfileshare1");
		    this.share.CreateIfNotExistsAsync();
	    }


	    public void InsertEntity(FileLogMessagecs logMessage)
	    {
		    try
		    {
			    // Get a reference to the root directory for the share.
			    CloudFileDirectory rootDir = this.share.GetRootDirectoryReference();

			    // Get a reference to the directory we created previously.
			    CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("Logs");
			    sampleDir.CreateIfNotExistsAsync();

			    var fileName = DateTime.Today.ToString("ddMMyyyy");

			    CloudFile file = sampleDir.GetFileReference(fileName + ".txt");

			    if (!file.ExistsAsync().Result)
			    {
				    file.UploadTextAsync(
					    string.Format("{0} - {1}{2}", logMessage.Timestamp.ToString(), logMessage.Text, Environment.NewLine));
			    }
			    else
			    {
					using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(string.Format("{0} - {1}{2}", logMessage.Timestamp.ToString(), logMessage.Text, Environment.NewLine))))
					{
						var startOffset = file.Properties.Length;
						file.WriteRangeAsync(ms, startOffset, null).Wait();

					}
				}
				
			    //if (!file.ExistsAsync().Result)
			    //{
			    // file.CreateAsync(7).Wait();
			    //}

			    //using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(string.Format("{0} - {1}{2}", logMessage.Timestamp.ToString(), logMessage.Text, Environment.NewLine))))
			    //{
			    //	var startOffset = file.Properties.Length;
			    //	file.WriteRangeAsync(ms, startOffset, null);
			    //}
		    }
			catch (Exception ExceptionObj)
			{
				throw ExceptionObj;
			}
		}
	}
}
