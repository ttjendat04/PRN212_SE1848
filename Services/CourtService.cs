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
        private readonly ICourtRepository _repo;

        public CourtService()
        {
            _repo = new CourtRepository(); // hoặc inject từ bên ngoài
        }

        public List<Court> GetAllCourts()
        {
            return _repo.GetAllCourts();
        }

        public List<CourtStatus> GetStatuses()
        {
            return _repo.GetStatuses();
        }

        public void AddCourt(Court court)
        {
            _repo.AddCourt(court);
        }

        public void UpdateCourt(Court court)
        {
            _repo.UpdateCourt(court);
        }

        public void DeleteCourt(int courtId)
        {
            _repo.DeleteCourt(courtId);
        }
    }
}
