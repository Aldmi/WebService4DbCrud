namespace DAL.EFcore.Entyties
{
    public class EfStation : IEntity
    {
        public int Id { get; set; }
        public string NameRu { get; set; }
        public string NameEng { get; set; }
        public string NameCh { get; set; }

        public int EfRouteId { get; set; }
        public EfRoute EfRoute { get; set; }
    }
}