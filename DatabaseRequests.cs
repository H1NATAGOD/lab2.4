using ConsoleApp5.Models;
using Task = ConsoleApp5.Models.Task;

namespace ConsoleApp5;

public class DatabaseRequests
{
    public static int activeUser = 0;
    static string formattedDate = "";
    
    
    public static void CreateNewUser()
    {
        Console.WriteLine("Введите Логин ");
        string login = Console.ReadLine();
        Console.WriteLine("Введите Пароль ");
        string password = Console.ReadLine();

        Models.User newUser = new User()
        {
            Loginuser = login,
            Password = password
        };
        try
        {
            DatabaseServisce.GetDbContext().Users.Add(newUser);
            DatabaseServisce.GetDbContext().SaveChanges();
        }
        catch 
        {
            Console.WriteLine("Такой пользователь уже сушествует");
        }
        
    }
    
    public static bool EnterUser()
    {
        Console.WriteLine("Введите login ");
        string login = Console.ReadLine();
        Console.WriteLine("Введите password ");
        string password = Console.ReadLine();

        var searchedUser = DatabaseServisce.GetDbContext().Users
            .FirstOrDefault(n => n.Loginuser == login && n.Password == password);

        if (searchedUser != null)
        {
            activeUser = searchedUser.Iduser;
            return true;
        }

        return false;
    }
    
    public static void CreateNewTask()
    {
        Console.Write("Введите заголовок: ");
        string title = Console.ReadLine();
        Console.Write("Введите задачу: ");
        string desckription = Console.ReadLine();
        Console.Write("Введите дату в формате гггг-мм-дд: ");
        DateOnly dateOfTask = new DateOnly();
        try
        {
            dateOfTask = DateOnly.Parse(Console.ReadLine());
            formattedDate = dateOfTask.ToString();
        }
        catch
        {
            Console.WriteLine("Неверный формат даты");
            return;
        }

        Models.Task newTask = new Task()
        {
            Userid = activeUser,
            Nametask = title,
            Description = desckription,
            DateOfTask = dateOfTask
        };
        DatabaseServisce.GetDbContext().Tasks.Add(newTask);
        DatabaseServisce.GetDbContext().SaveChanges();
    }
    
    public static void DeleteTask()
    {
        Console.Write($"Введите ID Задачи, которую хотите удалить: ");
        int idtask = int.Parse(Console.ReadLine());
        var DeleteTask = DatabaseServisce.GetDbContext().Tasks.FirstOrDefault(n => n.Idtask == idtask && n.Userid == activeUser);
        if (DeleteTask != null)
        {
            DatabaseServisce.GetDbContext().Tasks.Remove(DeleteTask);
            DatabaseServisce.GetDbContext().SaveChanges();
        }
    }
    
    public static void UpdateTask()
    {
        Console.Write($"Введите ID Задачи, которую хотите Обновить: ");
        int idtask = int.Parse(Console.ReadLine());
        Console.Write("Введите заголовок: ");
        string title = Console.ReadLine();
        Console.Write("Введите задачу: ");
        string desckription = Console.ReadLine();
        Console.Write("Введите дату в формате гггг-мм-дд: ");
        DateOnly dateOfTask = new DateOnly();
        try
        {
            dateOfTask = DateOnly.Parse(Console.ReadLine());
            formattedDate = dateOfTask.ToString();
        }
        catch
        {
            Console.WriteLine("Неверный формат даты");
            return;
        }

        Models.Task newTask = new Task()
        {
            Userid = activeUser,
            Nametask = title,
            Description = desckription,
            DateOfTask = dateOfTask
        };
        DatabaseServisce.GetDbContext().Tasks.Add(newTask);
        DatabaseServisce.GetDbContext().SaveChanges();

    }
    
    public static void WriteTodayTasks()
    {
       
        formattedDate = DateOnly.FromDateTime(DateTime.Today).ToString();

        foreach (var task in DatabaseServisce.GetDbContext().Tasks)
        {
            if(task.Userid == activeUser && task.DateOfTask == DateOnly.Parse(formattedDate))
                Console.WriteLine($"Id: {task.Idtask} \nНазвание: {task.Nametask} \nЗадача: {task.Description} \nДата выполнения: {task.DateOfTask}");
        }
    }
    
    public static void WriteTomorrowTasks()
    {
        formattedDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Tasks)
        {
            if(task.Userid == activeUser && task.DateOfTask == DateOnly.Parse(formattedDate))
                Console.WriteLine($"Id: {task.Idtask} \nНазвание: {task.Nametask} \nЗадача: {task.Description} \nДата выполнения: {task.DateOfTask}");
        }
    }
    
    public static void WriteWeekTasks()
    {
        int weekConvert = (int)DateTime.Today.DayOfWeek;
        if (weekConvert == 0)
        {
            weekConvert = 7;
        }

        formattedDate = DateOnly.FromDateTime(DateTime.Today).ToString();
        string formattedDateWeekConvert = DateOnly.FromDateTime(DateTime.Today.AddDays(7 - weekConvert)).ToString();
        
        foreach (var task in DatabaseServisce.GetDbContext().Tasks)
        {
            if(task.Userid == activeUser && task.DateOfTask >= DateOnly.Parse(formattedDate) && task.DateOfTask <= DateOnly.Parse(formattedDateWeekConvert))
                Console.WriteLine($"Id: {task.Idtask} \nНазвание: {task.Nametask} \nЗадача: {task.Description} \nДата выполнения: {task.DateOfTask}");
        }
    }
    
    public static void WriteAllTasks()
    {
        foreach (var task in DatabaseServisce.GetDbContext().Tasks)
        {
            if(task.Userid == activeUser)
                Console.WriteLine($"Id: {task.Idtask} \nНазвание: {task.Nametask} \nЗадача: {task.Description} \nДата выполнения: {task.DateOfTask}");
        }
    }
}