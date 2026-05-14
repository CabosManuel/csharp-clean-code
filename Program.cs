namespace ToDo;

internal class Program
{
    public static List<string> TaskList { get; set; } = new List<string>();

    static void Main(string[] args)
    {
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
    /// Show the options for Task
    /// 1. Nueva tarea
    /// 2. Remover tarea
    /// 3. Tareas pendientes
    /// 4. Salir
    /// </summary>
    /// <returns>Returns option indicated by user</returns>
    public static int ShowMainMenu()
    {
        Console.WriteLine("""
            Ingrese la opción a realizar:
            1. Nueva tarea
            2. Remover tarea
            3. Tareas pendientes
            4. Salir
            """
        );

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

            // Remove one position because the array starts at 0 and the user starts at 1
            int indexToRemove = Convert.ToInt32(line) - 1;

            if (indexToRemove > TaskList.Count - 1 || indexToRemove < 0)
                Console.WriteLine("Número de tarea inválido.");
            else
            {
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea {task} eliminada");
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error al eliminar la tarea.");
        }
    }

    public static void ShowMenuAdd()
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string task = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("La tarea no puede estar vacía.");
            return;
        }

        TaskList.Add(task);
        Console.WriteLine("Tarea registrada");
    }

    public static void ShowMenuTaskList()
    {
        if (TaskList?.Count > 0)
        {
            PrintTaskList(TaskList);
        }
        else
        {
            Console.WriteLine("No hay tareas por realizar");
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
