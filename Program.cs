using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Memory;
using System.Runtime.CompilerServices;

namespace AC_Hack
{
    class Helpers
    {
        public static bool isReady = false;
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "https://github.com/itssnee";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Assault Cube hack v1");
            Thread godModeThread = new Thread(new ThreadStart(godMode));
            godModeThread.Start();
            while (!Helpers.isReady)
            {
                if (Helpers.isReady)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            Thread.Sleep(100);
            Helpers.isReady = false;
            Console.WriteLine("[MAIN THREAD] Successfully injected to ac_client.exe");
            Console.WriteLine("[MAIN THREAD]   Entering Godmode...");
            Console.WriteLine("[MAIN THREAD]   Entering infiniteAmmo...");
            Thread infiniteAmmoThread = new Thread(new ThreadStart(infiniteAmmo));
            infiniteAmmoThread.Start();
            Console.WriteLine("[MAIN THREAD]   Entering infiniteGrenades...");
            Thread infiniteGrenadesThread = new Thread(new ThreadStart(infiniteGrenades));
            Thread CheckingThread = new Thread(new ThreadStart(checking));
            infiniteGrenadesThread.Start();
            CheckingThread.Start();
            Thread.Sleep(100);
            while (!Helpers.isReady)
            {
                if (Helpers.isReady)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("To start the cheat, please start Assault Cube V 1.1.0.4 and restart this program after starting.");
                    continue;
                }
            }
            Thread.Sleep(100);
            Console.ResetColor();
        }

        static void infiniteAmmo()
        {
            Mem mommy = new Mem();
            int PID = mommy.GetProcIdFromName("ac_client");
            if (PID > 0)
            {
                mommy.OpenProcess(PID);
                string rAmmo = "ac_client.exe+000DF73C, 14C";
                string rPistol = "ac_client.exe+000E4DBC, 138";
                string rSubMachine = "ac_client.exe+000DF73C, 144";
                string rSniper = "ac_client.exe+000DF73C, 148";
                string rShotGun = "ac_client.exe+000DF73C, 140";
                string rCarbine = "ac_client.exe+000DF73C, 140";

                Helpers.isReady = true;
                Console.WriteLine("[WORKER THREAD] Successfully entered InfiniteAmmo.");
                while (true)
                {
                    mommy.WriteMemory(rAmmo, "int", "1337");
                    mommy.WriteMemory(rPistol, "int", "1337");
                    mommy.WriteMemory(rSubMachine, "int", "1337");
                    mommy.WriteMemory(rSniper, "int", "1337");
                    mommy.WriteMemory(rShotGun, "int", "1337");
                    mommy.WriteMemory(rCarbine, "int", "1337");
                    Thread.Sleep(100);
                }
            }

        }

        static void infiniteGrenades()
        {
            Mem mommy = new Mem();
            int PID = mommy.GetProcIdFromName("ac_client");
            if (PID > 0)
            {
                mommy.OpenProcess(PID);
                string rNade = "ac_client.exe+000DF73C, 154";

                Helpers.isReady = true;
                Console.WriteLine("[WORKER THREAD] Successfully entered InfiniteGrenades");
                while (true)
                {
                    mommy.WriteMemory(rNade, "int", "1337");
                    Thread.Sleep(100);
                }

            }
        }
        static void godMode()
        {
            Mem mommy = new Mem();
            int PID = mommy.GetProcIdFromName("ac_client");
            if (PID > 0)
            {
                mommy.OpenProcess(PID);
                string rHealth = "ac_client.exe+000DF73C, F4";
                string rShield = "ac_client.exe+000DF73C, F8";

                Helpers.isReady = true;
                Thread.Sleep(200);
                Console.WriteLine("[WORKER THREAD] Successfully entered GodMode");
                while (true)
                {
                    mommy.WriteMemory(rHealth, "int", "1337");
                    mommy.WriteMemory(rShield, "int", "50");
                    Thread.Sleep(100);
                }

            }
        }
        static void checking()
        {
            Thread.Sleep(400);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[MAIN THREAD] Do you want to get notificated if the cheat is still online? (y/n)");
            var ansys = Console.ReadKey();
            if (ansys.KeyChar == 'y')
            {
                Console.WriteLine("");
                while (true)
                {
                    Helpers.isReady = true;
                    Thread.Sleep(300);
                    Console.ForegroundColor = ConsoleColor.Red;;
                    Console.WriteLine("[WORKER THREAD] Successfully renewed InfiniteAmmo, InfiniteGrenades and GodMode.");
                }
            }
            if (ansys.KeyChar == 'n')
            {
                Helpers.isReady = true;
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.WriteLine("[WORKER THREAD] Successfully disabled Notifications...");

            }
        }

    }
}   