using System.Collections.Generic;
using System.Linq;
using WeChatPortal.Models;

namespace WeChatPortal.Services
{
    public class AppointmentService
    {
        private readonly InsuranceDb _db = new InsuranceDb();

        public int Add(Appointment entity)
        {
            _db.Appointments.Add(entity);
            _db.SaveChanges();
            return entity.ID;
        }

        public Appointment GetEntity(int id)
        {
            var entity = _db.Appointments.Include("User").Where(m => !m.IsDelete).FirstOrDefault(m => m.ID == id);
            return entity;
        }

        public IEnumerable<Appointment> GetList()
        {
            var list = _db.Appointments.Where(m => !m.IsDelete);
            return list.ToList();
        }
    }
}