using DAL.Abstract;
using DAL.Entyties;


namespace DAL.Concrete
{
    /// <summary>
    /// Доступ к Stations
    /// </summary>
    public interface IStationRepository : IGenericDataRepository<Station>
    {
    }

    /// <summary>
    /// Доступ к Routes
    /// </summary>
    public interface IRouteRepository : IGenericDataRepository<Route>
    {
    }
}