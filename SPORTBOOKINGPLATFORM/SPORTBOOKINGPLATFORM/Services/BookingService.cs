using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo = new BookingRepository();
        

        public bool AddBooking(Booking booking)
        {
            return _repo.AddBooking(booking);
        }

        public bool ApproveBooking(int id)
        {
            return _repo.ApproveBooking(id);
        }

        public bool DeleteBooking(int id)
        {
            return _repo.DeleteBooking(id);
        }

        public List<Booking> GetAllBookings()
        {
            return _repo.GetAllBookings();
        }

        public Booking? GetBookingById(int id)
        {
            return _repo.GetBookingById(id);
        }

        public List<Booking> GetBookingsByUserOrCourt(string keyword)
        {
            return _repo.GetBookingsByUserOrCourt(keyword);
        }

        public bool UpdateBooking(Booking booking)
        {
            return _repo.UpdateBooking(booking);
        }
    }
}
