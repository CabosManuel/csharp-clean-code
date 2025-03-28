using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            Menu menuSelected;
            do
            {
                menuSelected = (Menu) ShowMainMenu();
                switch (menuSelected)
                {
                    case Menu.Add: ShowMenuAdd();
                        break;
                    case Menu.Remove: ShowMenuRemove();
                        break;
                    case Menu.List: ShowMenuTaskList();
                        break;
                }
            } while (menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                PrintTaskList(TaskList);

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + task + " eliminada");
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                PrintTaskList(TaskList);
            }
        }

        private static void PrintTaskList(List<string> TaskList)
        {
            Console.WriteLine("----------------------------------------");
            // Using foreach
            TaskList.ForEach( task => Console.WriteLine($"{TaskList.IndexOf(task) + 1}. {task}") );
            Console.WriteLine("----------------------------------------");
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4,
    }
}
