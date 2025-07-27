using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TournamentRegistrationRepository : ITournamentRegistrationRepository
    {
        TournamentRegistrationDAO dao = new TournamentRegistrationDAO();

        public bool RegisterUser(int userId, int tournamentId, string? teamName, int? numberOfMembers)
            => dao.RegisterUser(userId, tournamentId, teamName, numberOfMembers);

        public List<TournamentRegistration> GetRegistrationsByTournament(int tournamentId)
            => dao.GetRegistrationsByTournament(tournamentId);

        public List<TournamentRegistration> GetUserRegistrations(int userId)
            => dao.GetUserRegistrations(userId);

        public bool UpdateRegistrationStatus(int registrationId, string newStatus)
            => dao.UpdateRegistrationStatus(registrationId, newStatus);
        public List<TournamentRegistration> GetUserRegistrationsInTournament(int userId, int tournamentId)
            => dao.GetUserRegistrationsInTournament(userId, tournamentId);

        public int CountApprovedRegistrations(int tournamentId)
            => dao.CountApprovedRegistrations(tournamentId);

        public bool CanApproveMore(int tournamentId)
            => dao.CanApproveMore(tournamentId);
    }
}
