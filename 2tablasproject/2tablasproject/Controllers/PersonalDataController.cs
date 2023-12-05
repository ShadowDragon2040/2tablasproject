using tablasproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2tablasproject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalDataController : Controller
    {
        public ResponseResult response = new ResponseResult();
        public PersonalDataController()
        {
            response = new();
        }
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

        [HttpPost]
        public ActionResult<Personaldata> Post(CreatePersonalDataDto createPersonalDataDto)
        {
            var car = new Personaldata()
            {
                FirstName = createPersonalDataDto.FirstName,
                LastName = createPersonalDataDto.LastName,
                Gender = createPersonalDataDto.Gender,
                Language = createPersonalDataDto.Language,
                CardIndexId = createPersonalDataDto.CardIndexId,
            };
            using (var result = new TablasprojectContext())
            {
                result.Personaldata.Add(car);
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
