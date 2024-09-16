using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Data.DBContext;
using TagosysWeb.Data.Entities;
using TagosysWeb.Data.Repositories.Interfaces;

namespace TagosysWeb.Data.Repositories
{
    public class TeamRepositorie:GenericRepositories<Team>,ITeamRepositorie
    {
        private readonly tagosyswebContext _dbContext;

        public TeamRepositorie(tagosyswebContext DBContext):base(DBContext)
        {
            _dbContext = DBContext;
        }

    }
}
