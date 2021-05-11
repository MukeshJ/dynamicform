using System;
using System.Collections.Generic;

namespace Dynamic_form_api.DTO
{
    public class DtoProperties
    {
        public DateTime SamplingTime { get; set; }
        public List<DtoProperty> Properties { get; set; }

    }
}
