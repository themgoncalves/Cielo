using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cielo.Demo
{
    /// <summary>
    /// Cielo E-Commerce Demo
    /// </summary>
    public class AppConsole
    {
        private readonly List<CieloDemoInfo> demos = new List<CieloDemoInfo>();

        public AppConsole()
        {
            const string method = "get_Info";
            var cieloDemoTypes = Assembly
                    .GetExecutingAssembly()
                    .GetTypes().ToList()
                    .Where(t => t.Namespace != null && t.Namespace.StartsWith("Cielo.Demo.Services")).ToList();

            cieloDemoTypes
                .ForEach(e =>
                {
                    if (e.GetMembers().Any(m => m.Name == method))
                    {
                        var info = e.InvokeMember(method, BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { });
                        demos.Add((CieloDemoInfo)info);
                    }
                });
        }


        public void Execute(String[] args)
        {
            int index = 0;
            string command = string.Empty;

            // process any options
            while (index < args.Length && !args[index][0].ToString().StartsWith("-"))
            {
                command = args[index].ToLower();
                index++;
            }

            if (index == 0)
            {
                Console.WriteLine(@"Choose an option to execute");
                ListCommands();
                return;
            }

            var pargs = new String[args.Length - index];
            for (int i = 0; i < pargs.Length; i++)
            {
                pargs[i] = args[index + i];
            }
            foreach (CieloDemoInfo info in demos)
            {
                if (String.Compare(command, info.Command, true) == 0 ||
                    String.Compare(command, "all", true) == 0)
                {
                    ICieloDemo demo = info.CreateInstance();
                    demo.Execute(new ConsoleInterface(pargs));
                    
                    if (String.Compare(command, "all", true) != 0)
                    {
                        break;
                    }
                }
            }
        }
        
        public void Pause()
        {
            Console.Write("\n\nAperte qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ListCommands()
        {
            var commands = new List<string>();

            Console.WriteLine("");
            Console.WriteLine(@"Commands available:");

            commands.Add("all".PadRight(20) + ": Execute all available tests");

            foreach (CieloDemoInfo info in demos)
            {
                commands.Add(info.Command.PadRight(20) + ": " + info.Title);
            }

            commands.Sort();

            foreach (String str in commands)
            {
                Console.WriteLine(str);
            }
        }

        [STAThread]
        private static void Main(string[] args)
        {
            var app = new AppConsole();
            app.Execute(args);
        }
    }
}
