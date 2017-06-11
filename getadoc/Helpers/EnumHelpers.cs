using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace getadoc.Helpers
{
    public static class EnumHelpers
    {
       
        public static IEnumerable<SelectListItem> GetItems(this Type Enumtype, int? selectedValue)
        {
            if (!typeof(Enum).IsAssignableFrom(Enumtype))
            {
                throw new HttpException("The Type of refenece must be enum");
            }
            var names = Enum.GetNames(Enumtype);
            var values = Enum.GetValues(Enumtype).Cast<int>();
            var items = names.Zip(values, (name, value) =>
                 new SelectListItem
                 {
                     Text = name,
                     Value = value.ToString(),
                     Selected = value == selectedValue

                 }
            );
            return items;
        }

    }
}