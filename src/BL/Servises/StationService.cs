using System;
using System.Collections.Generic;
using System.Security.Principal;
using DAL.Concrete;
using DAL.Entyties;


namespace BL.Servises
{
    public class StationService
    {
        private readonly IStationRepository _rep;

        public StationService(IStationRepository rep)
        {
            this._rep = rep ?? throw new ArgumentNullException(nameof(rep));
        }



        /// <summary>
        /// Вззвращает все станции только зарегистрированному пользователю
        /// </summary>
        public IEnumerable<Station> GetStations(IPrincipal user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));


            //if (user.Identity.IsAuthenticated)
            {
                return _rep.GetAll();
            }

            return null;
        }
    }
}