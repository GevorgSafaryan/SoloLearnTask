using System.Collections.Generic;

namespace TheGuardianApi.ApiConsumer.Models
{
    public class PageSizeAndResultsModel
    {
        public int PageSize { get; set; }
        public List<SectionIdAndFieldsModel> Results { get; set; }
    }
}
