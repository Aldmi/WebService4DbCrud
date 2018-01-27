using System.Collections.Generic;
using DAL.Entyties;

namespace DAL.EFcore.Entyties
{
    public class EfRoute : IEntity
    {
        public int Id { get; set; }
        public ICollection<EfStation> Stations { get; set; }
    }
}