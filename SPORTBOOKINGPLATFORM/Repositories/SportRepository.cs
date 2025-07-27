using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SportRepository : ISportRepository
    {
        SportDAO sportDAO = new SportDAO();
        public List<Sport> GetAllSports()
        {
            return sportDAO.GetAllSports();
        }
        public Sport? GetSportById(int id)
        {
            return sportDAO.GetSportById(id);
        }

    }
}
