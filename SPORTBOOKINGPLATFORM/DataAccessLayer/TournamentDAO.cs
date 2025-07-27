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
    }
}

