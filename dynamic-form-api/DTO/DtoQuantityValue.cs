using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamic_form_api.DTO
{
    public class DtoQuantityValue
    { /// <Summary> /// Quantity value /// </Summary> 
        public double? Value { get; set; }
        /// <Summary> /// Quantity unit /// </Summary> 
        public string Unit { get; set; }
    }
}
