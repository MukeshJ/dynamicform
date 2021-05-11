using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Dynamic_form_api.DTO
{
    [KnownType(typeof(DtoQuantityValue))]
    public class DtoProperty
    {
        public long Id { get; set; }
        public Object Value { get; set; }
        public string Label { get; set; }
        public EntityPropertyDataType PropertyType { get; set; }

       
    }
}
