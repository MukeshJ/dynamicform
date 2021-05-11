using System.Collections.Generic;

namespace Dynamic_form_api.DTO
{
    public class DtoParentObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<DtoProperties> Datas { get; set; }
    }
}
