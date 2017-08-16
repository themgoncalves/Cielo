using System;
using System.Reflection;

namespace Cielo.Demo
{
    public class CieloDemoInfo
    {
        public CieloDemoInfo(Type type, String command, String title, String description)
        {
            CieloDemoType = type;
            Command = command;
            Title = title;
            Description = description;
        }

        public String Command { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Type CieloDemoType { get; set; }


        #region IComparable<CieloDemoInfo> Members

        public int CompareTo(CieloDemoInfo other)
        {
            return Command.CompareTo(other.Command);
        }

        #endregion

        public ICieloDemo CreateInstance()
        {
            var result = (ICieloDemo)Assembly.GetExecutingAssembly().CreateInstance(CieloDemoType.FullName);
            return result;
        }
    }
}
