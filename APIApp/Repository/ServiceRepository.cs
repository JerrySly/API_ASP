using APIApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Repository
{
    public class ServiceRepository : IRepository<Service>
    {
        private ApplicationContext _context;
        public ServiceRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(Service item)
        {
            _context.Services.Add(item);
        }

        public void Delete(int id)
        {
            Service v = _context.Services.Find(id);
            if (v != null) ;
            _context.Services.Remove(v);
        }

        public bool Exist(int id)
        {
            return _context.Services.Find(id) != null;
        }
        public Service Get(int id)
        {
            return _context.Services.Find(id);
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Service item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
