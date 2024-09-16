using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Data.DBContext;
using TagosysWeb.Data.Repositories;
using TagosysWeb.Data.Repositories.Interfaces;

namespace TagosysWeb.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly tagosyswebContext _dbContext;
        private IDbContextTransaction _objTran;
        private bool disposed = false;


        //public IAboutRepositories About { get; }
        public IProjectRepositorie Project { get; }
        public ITeamRepositorie Team { get; }
        public IContactRepositories Contact { get; }
        public IUserRepositorie User { get; }

        public IImagekitfileRepositorie Imagekitfile { get; }
        public ISystemsettingRepositorie Systemsetting { get; }
        public IClientRepositorie Client { get; }
        public IPageRepositorie Page { get; }
        public IPostRepositorie Post { get; }
        public IPostdescriptionRepositorie Postdescription { get; }

        public UnitOfWork(tagosyswebContext DbContext)
        {
            _dbContext = DbContext;

            Project = new ProjectRepositorie(_dbContext);
            Team = new TeamRepositorie(_dbContext);
            Contact = new ContactRepositorie(_dbContext);
            User = new UserRepositorie(_dbContext);
            Imagekitfile = new ImagekitfileRepositorie(_dbContext);
            Systemsetting = new SystemsettingRepositorie(_dbContext);
            Client = new ClientRepositorie(_dbContext);
            Page = new PageRepositorie(_dbContext);
            Post = new PostRepositorie(_dbContext);
            Postdescription = new PostdescriptionRepositorie(_dbContext);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public bool HasChanges()
        {
            return _dbContext.ChangeTracker.HasChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public async Task DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    await _dbContext.DisposeAsync();
                }
            }
            disposed = true;
        }

        public async Task CreateTransactionAsync()
        {
            _objTran = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _objTran.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _objTran.RollbackAsync();
            await _objTran.DisposeAsync();
        }

        public IExecutionStrategy GetExecutionStrategy()
        {
            return _dbContext.Database.CreateExecutionStrategy();
        }
    }
}
