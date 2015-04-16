using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

using TaskTracker.Common.Entities;

namespace TaskTracker.Common.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _context;

        private GenericRepository<Issue> issueRepository;
        private GenericRepository<IssueStatus> issueStatusRepository;
        private GenericRepository<Release> releaseRepository;

        public UnitOfWork(DbContext context)
        {
            this._context = context;
        }

        public GenericRepository<Issue> IssueRepository
        {
            get
            {
                if (this.issueRepository == null)
                {
                    this.issueRepository = new GenericRepository<Issue>(_context);
                }
                return issueRepository;
            }
        }

        public GenericRepository<Release> ReleaseRepository
        {
            get
            {
                if (this.releaseRepository == null)
                {
                    this.releaseRepository = new GenericRepository<Release>(_context);
                }
                return releaseRepository;
            }
        }

        public GenericRepository<IssueStatus> IssueStatusRepository
        {
            get
            {
                if (this.issueStatusRepository == null)
                {
                    this.issueStatusRepository = new GenericRepository<IssueStatus>(_context);
                }
                return issueStatusRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }




    }
}
