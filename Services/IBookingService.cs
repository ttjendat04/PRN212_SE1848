using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingService
    {
        List<Booking> GetAllBookings();
        Booking? GetBookingById(int id);
        List<Booking> GetBookingsByUserOrCourt(string keyword);
        bool AddBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int id);
        bool ApproveBooking(int id);
    }
}
