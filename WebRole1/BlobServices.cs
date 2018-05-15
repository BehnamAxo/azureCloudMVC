using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Configuration;

namespace WebRole1
{
	public class BlobServices
	{
		public CloudBlobContainer GetCloudBlobContainer()
		{
			string connString = "DefaultEndpointsProtocol=https;xxxxx";
			string destContainer = "xxxx";

			// Get a reference to the storage account  
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connString);
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
			CloudBlobContainer blobContainer = blobClient.GetContainerReference(destContainer);

			if (blobContainer.CreateIfNotExists())
			{
				blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
			}
			return blobContainer;
		}

	}
}