using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    public class UniversalComparer : IComparer
    {
        private readonly bool _nullValueIsSmallest;
        private readonly string _sortString;

        //do i need that?
        private readonly List<Condition> _conditions;

        public UniversalComparer(string sortString, bool nullValueIsSmallest = false)
        {
            _nullValueIsSmallest = nullValueIsSmallest;
            _sortString = sortString;
            _conditions = GetConditions();
        }

        public List<string> SplitSortStringOnProperties(string sortString)
        {
            //do i need this if there is only one separator?
            var delimiters = new[] { ", " };
            return sortString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public Condition SplitOnConditions(string property)
        {
            var condition = new Condition
            {
                Field = new Field
                {
                    Property = property.Split(' ')[0].Split('.').ToList(),
                },

                //how to check whether the sort string has asc/desc
                Desc = property.Split(' ').Contains("desc") 
            };
            return condition;
        }

        public List<Condition> GetConditions()
        {
            var properties = SplitSortStringOnProperties(_sortString);
            return properties.Select(property => SplitOnConditions(property)).ToList();
        }

        public object GetValue(object obj, Field field)
        {
            
            object result = obj;
            //var value = obj.GetType().GetField(conditions.Field.Property.Select(conditions => GetValue(conditions.))).
            foreach (var c in field.Property)
            {
                var fields = result.GetType().GetFields().ToList();
                var properties = result.GetType().GetProperties().ToList();
                if (fields.Count > 0)
                {
                    result = fields.SingleOrDefault(p => p.Name == c)?.GetValue(result);
                }

                if (properties.Count > 0)
                {
                    result = properties.SingleOrDefault(p => p.Name == c)?.GetValue(result);
                }
            }

            //
            //result = GetConditions(result, conditions.)
            return result;
        }

        public int Compare(object x, object y)
        {
            foreach (var condition in _conditions)
            {
                var firstValue = GetValue(x, condition.Field);
                var secondValue = GetValue(y, condition.Field);


            }
            throw new NotImplementedException();
        }
    }
}
