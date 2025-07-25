using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        private readonly SportsBookingDbContext _context = new SportsBookingDbContext();
        
        public List<Booking> GetAllBookings()
        {
            return _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Court)
                .ToList();
        }
        public Booking? GetBookingById(int id)
        {
            return _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Court)
                .FirstOrDefault(b => b.BookingId == id);
        }
        public List<Booking> GetBookingsByUserOrCourt(string keyword)
        {
            return _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Court)
                .Where(b => b.User.FullName.Contains(keyword) || b.Court.CourtName.Contains(keyword))
                .ToList();
        }
        public bool AddBooking(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                return _context.SaveChanges() >0;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        public bool UpdateBooking(Booking booking)
        {
            try
            {
                _context.Bookings.Update(booking);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool DeteleBooking(int id)
        {
            try
            {
                var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == id);
                if (booking != null)
                {
                    booking.Status = "Cancelled"; 
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ApproveBooking(int id)
        {
            try
            {
                var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == id);
                if (booking != null)
                {
                    booking.Status = "Confirmed"; 
                    return _context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
