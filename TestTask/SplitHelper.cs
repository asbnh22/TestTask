using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversalComparer
{
    public class SplitHelper
    {
        const string SortCondition = "desc";

        public static List<string> SplitSortStringOnProperties(string sortString)
        {
            return sortString.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static Condition SplitOnConditions(string property)
        {
            var condition = new Condition
            {
                Field = new Field
                {
                    Property = property.Split(' ')[0].Split('.').ToList(),
                },
                Desc = property.ToLower().Split(' ').Contains(SortCondition.ToLower())
            };
            return condition;
        }
    }
}
