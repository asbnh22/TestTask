using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniversalComparer
{
    public class UniversalComparer : IComparer
    {
        private readonly bool _nullValueIsSmallest;
        private readonly string _sortString;
        private readonly List<Condition> _conditions;

        public UniversalComparer(string sortString, bool nullValueIsSmallest = true)
        {
            _nullValueIsSmallest = nullValueIsSmallest;
            _sortString = sortString;
            _conditions = GetConditions();
        }

        public List<Condition> GetConditions()
        {
            var properties = SplitHelper.SplitSortStringOnProperties(_sortString);
            return properties.Select(property => SplitHelper.SplitOnConditions(property)).ToList();
        }

        public object GetValue(object obj, Field field)
        { 
            object result = obj;
            foreach (var c in field.Property)
            {
                if (result is null) return null; 
                var fields = result.GetType().GetFields().ToList();
                var properties = result.GetType().GetProperties().ToList();
                if (fields.Count > 0)
                {
                    result = fields.SingleOrDefault(p => p.Name == c)?.GetValue(result) ?? result;
                }

                if (properties.Count > 0)
                {
                    result = properties.SingleOrDefault(p => p.Name == c)?.GetValue(result);
                }
            }
            return result;
        }

        public int Compare(object x, object y)
        {
            int result = 0;
            foreach (var condition in _conditions)
            {
                var firstValue = GetValue(x, condition.Field);
                var secondValue = GetValue(y, condition.Field);

                result = Comparer.Default.Compare(firstValue, secondValue);

                result *= condition.Desc ? -1 : 1;
                result *= (firstValue is null || secondValue is null) && !(_nullValueIsSmallest) ? -1 : 1;
                
                if (result != 0)
                    return result;
            }

            return result;
        }
    }
}
