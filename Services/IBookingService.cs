using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public interface IBookingService
    {
        void CreateBooking(Booking booking);
        IEnumerable<Booking> GetBookings(bool includeUser = false);
        Booking GetBookingById(int id);

        List<Booking> GetBookingsByCourtAndDate(int courtId, DateOnly bookingDate);

    }
}
