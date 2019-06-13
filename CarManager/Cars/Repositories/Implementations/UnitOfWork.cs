using Data.Context;
using Data.Entities;
using System;

namespace Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private CarManagerDbContext context = new CarManagerDbContext();
        private GenericRepository<Car> carRepository;
        private GenericRepository<Make> makeRepository;
        private GenericRepository<Data.Entities.Type> typeRepository;

        public GenericRepository<Car> CarRepository
        {
            get
            {
                if(this.carRepository == null)
                {
                    this.carRepository = new GenericRepository<Car>(context);
                }
                return carRepository;
            }
        }

        public GenericRepository<Make> MakeRepository
        {
            get
            {
                if(this.makeRepository == null)
                {
                    this.makeRepository = new GenericRepository<Make>(context);
                }
                return makeRepository;
            }
        }

        public GenericRepository<Data.Entities.Type> TypeRepository
        {
            get
            {
                if(this.typeRepository == null)
                {
                    this.typeRepository = new GenericRepository<Data.Entities.Type>(context);
                }
                return typeRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }


        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
