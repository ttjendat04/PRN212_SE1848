using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDAO bookingdao = new BookingDAO();
        
        public bool AddBooking(Booking booking)
        {
            return bookingdao.AddBooking(booking);
        }

        public bool ApproveBooking(int id)
        {
            return bookingdao.ApproveBooking(id);
        }

        public bool DeleteBooking(int id)
        {
            return bookingdao.DeteleBooking(id);
        }

        public List<Booking> GetAllBookings()
        {
            return bookingdao.GetAllBookings();
        }

        public Booking? GetBookingById(int id)
        {
            return bookingdao.GetBookingById(id);
        }

        public List<Booking> GetBookingsByUserOrCourt(string keyword)
        {
            return bookingdao.GetBookingsByUserOrCourt(keyword);
        }

        public bool UpdateBooking(Booking booking)
        {
            return bookingdao.UpdateBooking(booking);
        }
    }
}
