using System;

namespace Cielo.Demo
{
    public class ConsoleInterface : ICieloDemoInterface
    {
        private readonly String[] args;

        public ConsoleInterface(String[] args)
        {
            this.args = args;
        }

        #region ICieloDemoInterface Members

        public String[] Args
        {
            get { return args; }
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void Write(string str)
        {
            Console.Write(str);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Exit()
        {
        }

        #endregion
    }
}
