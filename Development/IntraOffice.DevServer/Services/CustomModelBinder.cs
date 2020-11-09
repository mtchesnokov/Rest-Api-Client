using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Tch.FakeApi.Services
{
   public class CustomModelBinder : IModelBinder
   {
      //public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
      //{
      //   var provider = new MultipartMemoryStreamProvider();

      //   var httpRequestMessage = actionContext.Request;

      //   httpRequestMessage.Content.ReadAsMultipartAsync(provider).GetAwaiter().GetResult();

      //   var httpContents = provider.Contents;

      //   var jsonContent = httpContents.First(c => c.Headers.ContentType.MediaType == "application/json");

      //   var binaryContent = httpContents.First(c => c.Headers.ContentType.MediaType != "application/json");

      //   var fileName = binaryContent.Headers.ContentDisposition.FileName;

      //   bindingContext.Model = new CreateModelWithFile
      //   {
      //      Name = JsonConvert.DeserializeObject<CreateModel>(jsonContent.ReadAsStringAsync().Result).Name,

      //      File = new ReceivedFile
      //      {
      //         FileName = fileName,
      //         ContentType = binaryContent.Headers.ContentType.MediaType,
      //         Content = binaryContent.ReadAsByteArrayAsync().Result
      //      }
      //   };

      //   return true;
      //}

      public Task BindModelAsync(ModelBindingContext bindingContext)
      {
         throw new System.NotImplementedException();
      }
   }
}