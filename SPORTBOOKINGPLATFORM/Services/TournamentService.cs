﻿using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TournamentService : ITournamentService
    {
        ITournamentRepository tournamentRepository;

        public TournamentService()
        {
            tournamentRepository = new TournamentRepository(); 
        }

        public List<BusinessObjects.Tournament> GetAllTournaments()
        {
            return tournamentRepository.GetAllTournaments();
        }
        public BusinessObjects.Tournament GetTournamentById(int id)
        {
            return tournamentRepository.GetTournamentById(id);
        }
        public bool AddTournament(BusinessObjects.Tournament tournament)
        {
            return tournamentRepository.AddTournament(tournament);
        }
        public bool UpdateTournament(BusinessObjects.Tournament tournament)
        {
            return tournamentRepository.UpdateTournament(tournament);
        }
        public bool DeleteTournament(int id)
        {
            return tournamentRepository.DeleteTournament(id);
        }
    }
}
