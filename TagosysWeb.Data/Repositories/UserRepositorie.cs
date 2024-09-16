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
    public class UserRepositorie:GenericRepositories<User>,IUserRepositorie
    {
        private readonly tagosyswebContext _dbContext;

        public UserRepositorie(tagosyswebContext DBContext):base(DBContext)
        {
            _dbContext = DBContext;
        }
    }
}
