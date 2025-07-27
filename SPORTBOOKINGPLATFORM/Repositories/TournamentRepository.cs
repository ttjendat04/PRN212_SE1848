using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        TournamentDAO dao = new TournamentDAO();

        public List<Tournament> GetAllTournaments()
        {
            return dao.GetAllTournaments();
        }

        public Tournament GetTournamentById(int id)
        {
            return dao.GetTournamentById(id);
        }

        public bool AddTournament(Tournament tournament)
        {
            return dao.AddTournament(tournament);
        }

        public bool UpdateTournament(Tournament tournament)
        {
            return dao.UpdateTournament(tournament);
        }

        public bool DeleteTournament(int id)
        {
            return dao.DeleteTournament(id);
        }
    }
}
