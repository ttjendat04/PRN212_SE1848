using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class CourtService : ICourtService
    {
        private readonly ICourtRepository _courtRepository;

        public CourtService(ICourtRepository courtRepository)
        {
            _courtRepository = courtRepository;
        }
        public Court GetCourtById(int courtId)
        {
           return _courtRepository.GetCourtById(courtId);
        }

        public List<Court> GetCourtsBySportId(int sportId)
        {
           return _courtRepository.GetCourtsBySportId(sportId);
        }
    }
}
