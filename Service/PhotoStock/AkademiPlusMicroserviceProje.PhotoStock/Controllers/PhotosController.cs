using AkademiPlusMicroserviceProje.PhotoStock.Dtos;
using AkademiPlusMicroserviceProje.Shared.ControllerBases;
using AkademiPlusMicroserviceProje.Shared.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null & photo.Length>0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/photos",photo.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);
                var returnPath = photo.FileName;
                PhotoDto photoDto = new PhotoDto() { Url= returnPath };
                return CreateActionResultInstance(Response<PhotoDto>.Success(200, photoDto));
            }
            else
            {
                return CreateActionResultInstance(Response<PhotoDto>.Fail("Fotoğraf bulunamadı.", 400));
            }
        }
    }
}
