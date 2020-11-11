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
    public class VolunteerController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        public VolunteerController(ApplicationContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }
        [HttpGet]
        public IEnumerable<DTOVolunteer> GetAll()
        {
            var volunteers = _unitOfWork.Volunteers.GetAll();
            List<DTOVolunteer> dtoVolunteer = new List<DTOVolunteer>();
            dtoVolunteer.AddRange(
                volunteers.Select(x => new DTOVolunteer() { Id = x.Id, Name = x.Name, Soname = x.Soname, Age =x.Age })
                );
            return dtoVolunteer.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Volunteer> GetVolunteer(int id)
        {
            var volunteer = _unitOfWork.Volunteers.Get(id);

            if (volunteer == null)
            {
                return NotFound();
            }

            return volunteer;
        }

        [HttpPost]
        public ActionResult<Volunteer> PostVolunteer([FromBody] Volunteer volunteer)
        {
            _unitOfWork.Volunteers.Create(volunteer);
            _unitOfWork.SaveChanges();

            return _unitOfWork.Volunteers.GetAll().LastOrDefault();
        }
        [HttpDelete("{id}")]
        public ActionResult<Volunteer> DeleteVolunteer(int id)
        {
            var volunteer = _unitOfWork.Volunteers.Get(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            _unitOfWork.Volunteers.Delete(id);
            _unitOfWork.SaveChanges();

            return volunteer;
        }
        [HttpPut("{id}")]
        public IActionResult PutVolunteer(int id, Volunteer volunteer)
        {
            if (id != volunteer.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Volunteers.Update(volunteer);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Volunteers.Exist(id))
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
