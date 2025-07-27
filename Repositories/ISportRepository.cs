using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISportRepository
    {
        public List<Sport> GetAllSports();
        public Sport? GetSportById(int id);
    }
}
