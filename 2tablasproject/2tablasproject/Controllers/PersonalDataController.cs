using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tablasproject.Models;

namespace tablasproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalDataController : Controller
    {

        public TablasprojectContext _context;
        public ResponseResult response;

        public PersonalDataController(TablasprojectContext context)
        {
            _context = context;
            response = new ResponseResult();
        }
        /*
        public ResponseResult response = new ResponseResult();
        public PersonalDataController()
        {
            response = new();
        }
        */

        [HttpGet]
        public ActionResult<IEnumerable<Personaldata>> Get()
        {
            using (var context = new TablasprojectContext())
            {
                var result = context.Personaldata.ToList();
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

        [HttpGet("BankCards/{cardIndexId}")]
        public async Task<ActionResult<IEnumerable<Cardclass>>> GetBankCardsByCardIndexId(int cardIndexId)
        {
            var bankCards = await _context.Cardclass
                .Where(card => card.Personaldata.Any(pd => pd.CardIndexId == cardIndexId))
                .ToListAsync();

            if (bankCards == null || bankCards.Count == 0)
            {
                return NotFound();
            }

            return bankCards;
        }

        [HttpGet("{id}")]
        public ActionResult<Personaldata> GetById(int id)
        {
            using (var context = new TablasprojectContext())
            {
                var result = context.Personaldata.First(x => x.PersonalId == id);
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
        public ActionResult<Personaldata> Put(int id, UpdatePersonalDataDto UpdatePersonalDataDto)
        {
            using (var context = new TablasprojectContext())
            {
                var existingPersonalData = context.Personaldata.First(x => x.PersonalId == id);
                existingPersonalData.FirstName = UpdatePersonalDataDto.FirstName;
                existingPersonalData.LastName = UpdatePersonalDataDto.LastName;
                existingPersonalData.Gender = UpdatePersonalDataDto.Gender;
                existingPersonalData.Language = UpdatePersonalDataDto.Language;
                existingPersonalData.CardIndexId = UpdatePersonalDataDto.CardIndexId;
                context.Personaldata.Update(existingPersonalData);
                context.SaveChanges();
                if (existingPersonalData == null)
                {
                    response.Message = "Sikertelen módosítás";
                    return BadRequest(response);
                }
                else
                {
                    response.result = existingPersonalData;
                    response.IsSuccess = true;
                    response.Message = "Sikeres módosítás";
                    return Ok(response);
                }
            }
        }

        [HttpDelete]
        public ActionResult<Personaldata> Delete(int id)
        {
            using (var context = new TablasprojectContext())
            {
                var result = context.Personaldata.First(x => x.PersonalId == id);
                context.Personaldata.Remove(result);
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
        /*
        [HttpPost]
        public ActionResult<Personaldata> Post(CreatePersonalDataDto createPersonalDataDto)
        {
            var card = new Personaldata()
            {
                FirstName = createPersonalDataDto.FirstName,
                LastName = createPersonalDataDto.LastName,
                Gender = createPersonalDataDto.Gender,
                Language = createPersonalDataDto.Language,
                CardIndexId = createPersonalDataDto.CardIndexId,
            };
            using var result = new TablasprojectContext();
            result.Personaldata.Add(card);
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
        }*/
        [HttpPost]
        public ActionResult<Personaldata> Post(CreatePersonalDataDto createPersonalDataDto)
        {
            var card = new Personaldata()
            {
                FirstName = createPersonalDataDto.FirstName,
                LastName = createPersonalDataDto.LastName,
                Gender = createPersonalDataDto.Gender,
                Language = createPersonalDataDto.Language,
                CardIndexId = createPersonalDataDto.CardIndexId,
            };

            _context.Personaldata.Add(card);
            _context.SaveChanges();

            if (card == null)
            {
                response.Message = "Sikertelen hozzáadás";
                return BadRequest(response);
            }
            else
            {
                response.result = card;
                response.IsSuccess = true;
                response.Message = "Sikeres hozzáadás";
                return Ok(response);
            }
        }
    }
}
