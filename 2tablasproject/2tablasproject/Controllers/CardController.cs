using tablasproject.Models;
using Microsoft.AspNetCore.Mvc;
using tablasproject.Models;

namespace tablasproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        public ResponseResult response = new ResponseResult();
        public CardController()
        {
            response = new();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Cardclass>> Get()
        {
            using (var context = new TablasprojectContext())
            {
                var result = context.Cardclass.ToList();
                if (result == null)
                {
                    response.Message = "Sikertelen lekérdezés";
                    return BadRequest(response);
                }
                else
                {
                    response.result = result;
                    response.IsSuccess = true;
                    response.Message = "Sikeres lekérdezés";
                    return Ok(response);
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Cardclass> GetById(int id)
        {
            using (var context = new TablasprojectContext())
            {
                var result = context.Cardclass.First(x => x.CardId == id);
                if (result == null)
                {
                    response.Message = "Sikertelen lekérdezés";
                    return BadRequest(response);
                }
                else
                {
                    response.result = result;
                    response.IsSuccess = true;
                    response.Message = "Sikeres lekérdezés";
                    return Ok(response);
                }
            }
        }

        [HttpPut]
        public ActionResult<Cardclass> Put(int id, UpdateCardDto UpdateCardclassDto)
        {
            using (var context = new TablasprojectContext())
            {
                var existingCardclass = context.Cardclass.First(x => x.CardId == id);
                existingCardclass.CardNumber = UpdateCardclassDto.CardNumber;
                existingCardclass.CardTypeName = UpdateCardclassDto.CardTypeName;
                existingCardclass.CurrencyName = UpdateCardclassDto.CurrencyName;
                context.Cardclass.Update(existingCardclass);
                context.SaveChanges();
                if (existingCardclass == null)
                {
                    response.Message = "Sikertelen módosítás";
                    return BadRequest(response);
                }
                else
                {
                    response.result = existingCardclass;
                    response.IsSuccess = true;
                    response.Message = "Sikeres módosítás";
                    return Ok(response);
                }
            }
        }

        [HttpDelete]
        public ActionResult<Cardclass> Delete(int id)
        {
            using (var context = new TablasprojectContext())
            {
                var result = context.Cardclass.First(x => x.CardId == id);
                context.Cardclass.Remove(result);
                context.SaveChanges();
                if (result == null)
                {
                    response.Message = "Sikertelen törlés";
                    return BadRequest(response);
                }
                else
                {
                    response.result = result;
                    response.IsSuccess = true;
                    response.Message = "Sikeres törlés";
                    return Ok(response);
                }
            }
        }

        [HttpPost]
        public ActionResult<Cardclass> Post(CreateCardDto createCardclassDto)
        {
            var car = new Cardclass()
            {
                CardNumber = createCardclassDto.CardNumber,
                CardTypeName = createCardclassDto.CardTypeName,
                CurrencyName = createCardclassDto.CurrencyName,
                CurrencyAmmount = createCardclassDto.CurrencyAmmount,
            };
            using (var result = new TablasprojectContext())
            {
                result.Cardclass.Add(car);
                result.SaveChanges();
                if (result == null)
                {
                    response.Message = "Sikertelen hozzáadás";
                    return BadRequest(response);
                }
                else
                {
                    response.result = result;
                    response.IsSuccess = true;
                    response.Message = "Sikeres hozzáadás";
                    return Ok(response);
                }
            }
        }
    }
}
