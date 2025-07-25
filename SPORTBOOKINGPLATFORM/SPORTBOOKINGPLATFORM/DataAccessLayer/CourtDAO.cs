using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CourtDAO
    {
        SportsBookingDbContext _context = new SportsBookingDbContext();
        public List<Court> GetAllCourts()
        {
            return _context.Courts.ToList();
        }   
    }
}
