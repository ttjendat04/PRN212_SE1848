using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CourtRepository : ICourtRepository
    {
        CourtDAO _courtDAO = new CourtDAO();
        public List<Court> GetAllCourts()
        {
            return _courtDAO.GetAllCourts();    
        }
    }
}
