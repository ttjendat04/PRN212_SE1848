using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void CreateBooking(Booking booking)
        {
            var duration = booking.EndTime - booking.StartTime;
            if (duration.TotalHours <= 0)
                throw new ArgumentException("Thời lượng đặt sân không hợp lệ");

            _bookingRepository.AddBooking(booking);
        }


        public IEnumerable<Booking> GetBookings(bool includeUser = false)
        {
            return _bookingRepository.GetAllBookings(includeUser: true);
        }

        Booking IBookingService.GetBookingById(int id)
        {
            return _bookingRepository.GetBookingById(id);
        }

        public List<Booking> GetBookingsByCourtAndDate(int courtId, DateOnly date)
        {
            return _bookingRepository.GetAllBookings()
                .Where(b => b.CourtId == courtId
                && b.BookingDate == date 
                && b.Status != "Cancelled")
                .ToList();
        }


    }
}
