using APIApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Repository
{
    public class HomelessRepository : IRepository<Homeless>
    {
        private ApplicationContext _context;
        public HomelessRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(Homeless item)
        {
            _context.Homelesses.Add(item);
        }

        public void Delete(int id)
        {
            Homeless v = _context.Homelesses.Find(id);
            if (v != null) ;
            _context.Homelesses.Remove(v);
        }

        public bool Exist(int id)
        {
            return _context.Homelesses.Find(id) != null;
        }

        public Homeless Get(int id)
        {
            return _context.Homelesses.Find(id);
        }

        public IEnumerable<Homeless> GetAll()
        {
            return _context.Homelesses;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Homeless item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
