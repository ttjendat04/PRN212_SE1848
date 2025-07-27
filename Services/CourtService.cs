using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CourtService : ICourtService
    {
        ICourtRepository _repo;
        public CourtService()
        {
            _repo = new CourtRepository();
        }
        public List<Court> GetAllCourts()
        {
            return _repo.GetAllCourts();
        }
    }
}
