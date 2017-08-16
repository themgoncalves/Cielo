using System;

namespace Cielo.Demo
{
    public interface ICieloDemoInterface
    {
        String[] Args { get; }
        void WriteLine(String str);
        void Write(String str);
        void WriteLine();
        void Exit();
    }
}
