using System.Collections.Generic;

namespace TestTask
{
    public class Condition
    {
        public Field Field { get; set; }
        public bool Desc { get; set; }
    }

    public class Field
    {
        public List<string> Property { get; set; }
    }
}
