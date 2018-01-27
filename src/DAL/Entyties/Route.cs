using System.Collections;
using System.Collections.Generic;

namespace DAL.Entyties
{
    public class Route
    {
        public string Id { get; set; }
        public ICollection<Station> Stations { get; set; } 
    }
}