using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SportService : ISportService
    {
        ISportRepository sportRepository;
        public SportService()
        {
            sportRepository = new SportRepository();
        }

        public List<Sport> GetAllSports()
        {
            return sportRepository.GetAllSports();
        }

        public Sport? GetSportById(int id)
        {
            return sportRepository.GetSportById(id);    
        }
    }
}
