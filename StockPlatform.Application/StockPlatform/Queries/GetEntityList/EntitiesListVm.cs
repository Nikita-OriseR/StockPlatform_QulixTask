using System.Collections.Generic;

namespace StockPlatform.Application.StockPlatform.Queries.GetEntityList
{
    public class EntitiesListVm
    {
        public IList<EntitiesLookupDto> Authors { get; set; }
        public IList<EntitiesLookupDto> Photos { get; set; }
        public IList<EntitiesLookupDto> Texts { get; set; }
    }
}
