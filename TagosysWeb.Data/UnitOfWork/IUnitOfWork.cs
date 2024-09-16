using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Data.Repositories.Interfaces;

namespace TagosysWeb.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
       
        IProjectRepositorie Project { get; }
        ITeamRepositorie Team { get; }
        IContactRepositories Contact { get; }
        IUserRepositorie User { get; }
        IImagekitfileRepositorie Imagekitfile { get; }
        ISystemsettingRepositorie Systemsetting { get; }
        IClientRepositorie Client { get; }
        IPageRepositorie Page { get; }
        IPostRepositorie Post { get; }
        IPostdescriptionRepositorie Postdescription { get; }


        int Save();
        Task<int> SaveAsync();

        Task DisposeAsync();
        bool HasChanges();

        Task CreateTransactionAsync();

        Task RollbackAsync();
        Task CommitTransactionAsync();
        IExecutionStrategy GetExecutionStrategy();
    }
}
