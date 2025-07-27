using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TournamentDAO
    {
        SportsBookingDbContext context = new SportsBookingDbContext();

        public List<Tournament> GetAllTournaments()
        {
            return context.Tournaments
                        .Include(t => t.Sport)
                        .Include(t => t.Organizer)
                        .ToList();
        }


        public Tournament GetTournamentById(int id)
        {
            return context.Tournaments.FirstOrDefault(t => t.TournamentId == id);
        }

        public bool AddTournament(Tournament tournament)
        {
            try
            {
                context.Tournaments.Add(tournament);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cập nhật giải đấu
        public bool UpdateTournament(Tournament tournament)
        {
            try
            {
                var existing = context.Tournaments.FirstOrDefault(t => t.TournamentId == tournament.TournamentId);
                if (existing != null)
                {
                    context.Entry(existing).CurrentValues.SetValues(tournament);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Xoá giải đấu
        public bool DeleteTournament(int id)
        {
            try
            {
                var tournament = context.Tournaments.FirstOrDefault(t => t.TournamentId == id);
                if (tournament != null)
                {
                    context.Tournaments.Remove(tournament);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateTournamentStatuses()
        {
            var tournaments = GetAllTournaments();
            var today = DateOnly.FromDateTime(DateTime.Today);
            bool hasChanges = false;

            foreach (var t in tournaments)
            {
                var newStatus = GetTournamentStatus(t, today);
                if (t.Status != newStatus)
                {
                    t.Status = newStatus;
                    UpdateTournament(t); // Cập nhật vào DB
                    hasChanges = true;
                }
            }

            return hasChanges;
        }
        private string GetTournamentStatus(BusinessObjects.Tournament t, DateOnly today)
        {
            if (t.RegistrationDeadline > today)
                return "Mở đăng ký";
            else if (t.StartDate > today)
                return "Đóng đăng ký";
            else if (t.StartDate <= today && t.EndDate >= today)
                return "Đang diễn ra";
            else if (t.EndDate < today)
                return "Hoàn thành";
            else
                return "Không rõ";
        }
    }
}

