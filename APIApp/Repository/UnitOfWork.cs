using APIApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Repository
{
    public class UnitOfWork
    {
        private ApplicationContext _context;
        private VolunteerRepository _volunteerRepository;
        private HomelessRepository _homelessRepository;
        private ServiceRepository _serviceRepository;

        public VolunteerRepository  Volunteers {
            get
            {
                if (_volunteerRepository == null)
                    _volunteerRepository = new VolunteerRepository(_context);
                return _volunteerRepository;
            }
        }
        public HomelessRepository Homelesses
        {
            get
            {
                if (_homelessRepository == null)
                    _homelessRepository = new HomelessRepository(_context);
                return _homelessRepository;
            }
        }
        public ServiceRepository Services
        {
            get
            {
                if (_serviceRepository == null)
                    _serviceRepository = new ServiceRepository(_context);
                return _serviceRepository;
            }
        }
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
