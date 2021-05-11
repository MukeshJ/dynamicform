using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamic_form_api.DTO
{
    public enum EntityPropertyDataType 
    {
        StringProperty = 0,
        QuantityProperty = 1,
        NumericProperty = 2,
        BooleanProperty = 3,
        GeometryProperty = 4
    }
}
