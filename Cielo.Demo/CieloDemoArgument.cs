using System;

namespace Cielo.Demo
{
    public class CieloDemoArgument
    {
        public CieloDemoArgument(String name, String description)
        {
            Name = name;
            Description = description;
        }

        public String Name { get; set; }
        public String Description { get; set; }
    }
}
