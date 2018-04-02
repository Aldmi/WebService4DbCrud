using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Concrete;
using DAL.EFcore.DbContext;
using DAL.Entyties;


namespace DAL.EFcore.Repository
{
    public class EfStationsRepository : IStationRepository
    {
        private readonly Context _context;



        public EfStationsRepository(string connStr)
        {
            _context = new Context(connStr);
        }




        public IList<Station> GetAll(params Expression<Func<Station, object>>[] navigationProperties)
        {
           var hh= _context.EfStations.ToList();


            return new List<Station>();
           // throw new NotImplementedException();
        }

        public IList<Station> GetList(Func<Station, bool> @where, params Expression<Func<Station, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public Station GetSingle(Func<Station, bool> @where, params Expression<Func<Station, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Add(params Station[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params Station[] items)
        {
            throw new NotImplementedException();
        }

        public void Remove(params Station[] items)
        {
            throw new NotImplementedException();
        }
    }
}