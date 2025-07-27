using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICourtRepository
    {
        List<Court> GetAllCourts();
        List<CourtStatus> GetStatuses();
        void AddCourt(Court court);
        void UpdateCourt(Court court);
        void DeleteCourt(int courtId);
    }
}
