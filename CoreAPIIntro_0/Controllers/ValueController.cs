using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPIIntro_0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        static List<string> sehirler = new List<string>
        {
            "Istanbul","İzmir","Eskişehir","Ankara"
        };

        #region HTTPStatusCodes
        //100 ile baslayan kodlar  => Information (Bilgilendirme)
        //200 ile baslayan kodlar => Success(Basarılı)
        //300 ile baslayan kodlar => Redirection (Yeniden yönlendirme)
        //400 ile baslayan kodlar => Client Errors (İstemci hataları)
        //500 ile baslayan kodlar => Server Errors (Sunucu hataları) 
        #endregion

        /*
        Get = kullanıcının yeni bir istegi (Request, mevcut durumda alınan bir response varsa ondan beğımsız bir şekilde taze bir haldedir.)

        Post = Gelen Response'un tekrar server'a geri gönderilmesidir.. API'da sadece Creation islemleri icin kullanılması sağlıklı olan HTTP requst tipidir..

        Put = API'da Update işlemleri için kullanacağımız HTTP Request tipidir..

        Delete = API'da Delete işlemleri için kullanacağımız HTTP Request tipidir..

        MVC'de bir action'ın bşına Request tipi yazılmadığında otomatik olarak o action Get tipinde algılanırçç Lakin API'da durum böyle degğildir.. API'da request tipi belirtilmeyen bir action direkt hata verecektir Dolayısıyla API'daki Controller içerisindeki Action'ların request tiplerinin belirtilmesi gerekir..
        

         */
        [HttpGet]
        public IActionResult GetCityInfo()
        {
            return Ok(sehirler);
        }

        [HttpGet("Indexer")]
        public IActionResult GetCity(int id)
        {
            return Ok(sehirler[id]);
        }

        [HttpPost]
        public IActionResult AddCity(string item)
        {
            sehirler.Add(item);
            return Ok(sehirler);
        }

        [HttpPut]
        public IActionResult UpdateCity(int id, string newValue)
        {
            sehirler[id] = newValue;
            return Ok(sehirler);
        }

        [HttpDelete]
        public IActionResult DeleteCity(int id)
        {
            sehirler.Remove(sehirler[id]);
            return Ok(sehirler);
        }
    }
}
