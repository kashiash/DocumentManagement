using System;
using System.IO;
using System.Threading.Tasks;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.XtraRichEdit.Model;
using DocumentManagement.Module.BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DocumentManagement.Module;
using DevExpress.CodeParser;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
      

        public DocumentsController()
        {
           
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file, string title, Guid categoryId, Guid subcategoryId)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is not selected or empty.");
            }

            XpoTypesInfoHelper.GetXpoTypeInfoSource();
            XafTypesInfo.Instance.RegisterEntity(typeof(Document));
            XafTypesInfo.Instance.RegisterEntity(typeof(Category));
            XafTypesInfo.Instance.RegisterEntity(typeof(Subcategory));
            XafTypesInfo.Instance.RegisterEntity(typeof(FileData));


            try
            {
                using var directProvider = new XPObjectSpaceProvider(ApplicationSettings.ConnectionString, null, true);
                {
                    using var objectSpace = directProvider.CreateObjectSpace();


                    var category = objectSpace.GetObjectByKey<Category>(categoryId);
                    var subcategory = objectSpace.GetObjectByKey<Subcategory>(subcategoryId);

                    if (category == null || subcategory == null)
                    {
                        return BadRequest("Invalid category or subcategory.");
                    }

                    var document = objectSpace.CreateObject<Document>();
                    document.File = objectSpace.CreateObject<FileData>();

                    document.Title = title;
                    document.Category = category;
                    document.Subcategory = subcategory;
                  //  scan.Opis = $"{myFile.FileName} - {uploadFileDto.Opis}";
                  //  document.File.LoadFromStream(file.FileName, file.OpenReadStream());


                    using var stream = file.OpenReadStream();
                  //  using var memoryStream = new MemoryStream();
                 //   stream.CopyTo(memoryStream);
                    stream.Seek(0, SeekOrigin.Begin);
                    document.File.LoadFromStream(file.FileName, stream);

                    document.File.FileName = file.FileName;
                  //  document.Image = memoryStream.ToArray();

                    objectSpace.CommitChanges();
                    return Ok(new { document.Oid });
                }
            }
            catch
            {
                return BadRequest();
            }
           
        }


    }
}
