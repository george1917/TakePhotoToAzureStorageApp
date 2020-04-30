using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TakePhotoToAzureStorageApp.Controllers
{
    //WindowsAzure.Storage

    public class HomeController : Controller
    {
        public async Task<JsonResult> AttachFile(string imageData)
        {
            byte[] myByteArray = Convert.FromBase64String(imageData);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("Azure Storage Connection String");

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("");
            await container.CreateIfNotExistsAsync();

            // Retrieve reference to blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("");

            // Upload the file
            await blockBlob.UploadFromByteArrayAsync(myByteArray, 0, myByteArray.Length);

            return Json(new { status = "Success" });
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}