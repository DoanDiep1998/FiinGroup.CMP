using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace StoxPlus.Core.Models.Chart
{
    public class ChartEventItem : DynamicObject
    {
        private Dictionary<string, object> _dict = new Dictionary<string, object>();

        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            return _dict.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            _dict[binder.Name.ToLower()] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _dict.Keys;
        }
    }
}
