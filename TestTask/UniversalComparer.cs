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
        //private readonly List<Condition> _conditions;

        public UniversalComparer(string sortString, bool nullValueIsSmallest = false)
        {
            _nullValueIsSmallest = nullValueIsSmallest;
            _sortString = sortString;
        }

        public List<string> SplitSortStringOnProperties(string sortString)
        {
            var delimiters = new[] { ", " };
            return sortString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public Condition SplitOnConditions(string property)
        {
            var condition = new Condition
            {
                Property = property.Split(' ')[0].Split('.').ToList(), 

                //how to check whether the sort string has asc/desc
                Desc = property.Split(' ').Contains("desc") 
            };
            return condition;
        }




        /*public static List<Condition> SplitSor(string sortString)
        {
            var delimiters = new[] { ", "};
            var condition = new Condition();
            var tmp = new List<Condition>();
            var listCondition = sortString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var c in listCondition)
            {
                condition.pr = c.Split(' ')[0];
                condition.Asc = c.Split(' ')[1] == "desc";
            }
            var cond = sortString.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            var x = cond.Select(x=>x.Value)
            return new List<Condition>(); sortString.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }*/

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }
}
