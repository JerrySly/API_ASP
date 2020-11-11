using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIApp.Models;
using APIApp.Models.DOTModels;
using APIApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomelessController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        public HomelessController(ApplicationContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }
        [HttpGet]
        public  IEnumerable<DTOHomeless> GetAll()
        {
            var homeless = _unitOfWork.Homelesses.GetAll();
            List<DTOHomeless> dtoHomeless = new List<DTOHomeless>();
            dtoHomeless.AddRange(
                homeless.Select(x => new DTOHomeless() { Id = x.Id, Age = x.Age, Name = x.Name, Soname = x.Soname })
                );
            return dtoHomeless.ToArray();
        }

        [HttpGet("{id}")]
        public  ActionResult<Homeless> GetHomeless(int id)
        {
            var homeless = _unitOfWork.Homelesses.Get(id);

            if (homeless == null)
            {
                return NotFound();
            }

            return homeless;
        }

        [HttpPost]
        public  ActionResult<Homeless> PostHomeless([FromBody] Homeless homeless)
        {
            _unitOfWork.Homelesses.Create(homeless);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetHomeless", new { id = homeless.Id }, homeless);
        }
        [HttpDelete("{id}")]
        public ActionResult<Homeless> DeleteHomeless(int id)
        {
            var homeless = _unitOfWork.Homelesses.Get(id);
            if (homeless == null)
            {
                return NotFound();
            }

            _unitOfWork.Homelesses.Delete(id);
            _unitOfWork.SaveChanges();

            return homeless;
        }
        [HttpPut("{id}")]
        public IActionResult PutHomeless (int id, Homeless homeless)
        {
            if (id != homeless.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Homelesses.Update(homeless);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Homelesses.Exist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    }
}
