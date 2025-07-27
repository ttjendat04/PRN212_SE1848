using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CourtRepository : ICourtRepository
    {
        private readonly SportsBookingDbContext _context;

        public CourtRepository(SportsBookingDbContext context)
        {
            _context = context;
        }

        public Court GetCourtById(int courtId)
        {
        
            return _context.Courts.FirstOrDefault(
                c => c.CourtId == courtId);
        }

        public List<Court> GetCourtsBySportId(int sportId)
        {
            return _context.Courts.Where(c => c.SportId
        == sportId).ToList();
        }
    }
}
