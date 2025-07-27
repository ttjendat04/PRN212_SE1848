using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SportDAO
    {
        SportsBookingDbContext context = new SportsBookingDbContext();
        public List<Sport> GetAllSports()
        {
            return context.Sports.ToList();
        }

        public Sport? GetSportById(int id)
        {
            return context.Sports.FirstOrDefault(s => s.SportId == id);
        }
    }
}
