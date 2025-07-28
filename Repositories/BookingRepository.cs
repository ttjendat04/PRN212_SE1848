using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public List<CourtBookingStatistic> GetBookingStatisticsByCourt()
        {
            using var context = new SportsBookingDbContext();
            var data = context.Bookings
                .Include(b => b.Court)
                .GroupBy(b => b.Court.CourtName)
                .Select(g => new CourtBookingStatistic
                {
                    CourtName = g.Key,
                    BookingCount = g.Count()
                })
                .ToList();
            return data;
        }
    }
}
