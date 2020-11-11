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
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        public ServiceController(ApplicationContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }
        [HttpGet]
        public IEnumerable<DTOService> GetAll()
        {
            var service = _unitOfWork.Services.GetAll();
            List<DTOService> dtoService = new List<DTOService>();
            dtoService.AddRange(
                service.Select(x => new DTOService() { Id = x.Id, DurationInMinutes= x.DurationInMinutes, NameOfService=x.NameOfService})
                );
            return dtoService.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Service> GetService(int id)
        {
            var service = _unitOfWork.Services.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        [HttpPost]
        public ActionResult<Service> PostService(Service service)
        {
            _unitOfWork.Services.Create(service);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }
        [HttpDelete("{id}")]
        public ActionResult<Service> DeleteService(int id)
        {
            var service = _unitOfWork.Services.Get(id);
            if (service == null)
            {
                return NotFound();
            }

            _unitOfWork.Services.Delete(id);
            _unitOfWork.SaveChanges();

            return service;
        }
        [HttpPut("{id}")]
        public IActionResult PutService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Services.Update(service);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Services.Exist(id))
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
