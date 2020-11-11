using APIApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Repository
{
    public class VolunteerRepository : IRepository<Volunteer>
    {
        private ApplicationContext _context;
        public VolunteerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(Volunteer item)
        {
            _context.Volunteers.Add(item);
        }

        public void Delete(int id)
        {
            Volunteer v = _context.Volunteers.Find(id);
            if (v != null) ;
                _context.Volunteers.Remove(v);
        }

        public bool Exist(int id)
        {
            return _context.Volunteers.Find(id) != null;
        }
        public Volunteer Get(int id)
        {
            return _context.Volunteers.Find(id);
        }

        public IEnumerable<Volunteer> GetAll()
        {
            return _context.Volunteers;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Volunteer item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
