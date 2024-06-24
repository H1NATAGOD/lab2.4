namespace ConsoleApp5;


internal class Program
{


    static void Main()
    {
        string choose = "";
        int IdTask = 0;
        bool flag = true;
        bool flag2 = true;
        
        while (flag)
        {
            Console.WriteLine("1 - зарегистрироватся \n2 - Войти");
            choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    DatabaseRequests.CreateNewUser();
                    break;
                case "2":
                    DatabaseRequests.EnterUser();
                    if (DatabaseRequests.activeUser != 0)
                    {
                        flag = false;
                    } 
                    break;
                default:
                    Console.WriteLine("Неверный формат ввода");
                    break;
            }
        }
        
        while (flag2)
        {
            Console.WriteLine(
                " \n Введите команду: \n 1 - Добавить задачу \n 2 - Удалить задачу \n 3 - Посмотреть все задачи \n 4 - Посмотреть все задачи на сегодня \n 5 - Посмотреть все задачи на завтра \n 6 - Посмотреть все задачи на эту неделю \n 7 - Изменить задачу \n 0 - Завершить работу программы");
            choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    DatabaseRequests.CreateNewTask();
                    break;
                case "2":
                    DatabaseRequests.DeleteTask();
                    break;
                case "3":
                    DatabaseRequests.WriteAllTasks();
                    break;
              
                case "4":
                    DatabaseRequests.WriteTodayTasks();
                    break;
                case "5":
                    DatabaseRequests.WriteTomorrowTasks();
                    break;
                case "6":
                    DatabaseRequests.WriteWeekTasks();
                    break;
                case "7":
                    DatabaseRequests.UpdateTask();
                    break;
                case "0":
                    Console.WriteLine("Окончание работы.......... ");
                    flag2 = false;
                    break;
                default:
                    Console.WriteLine("Команда на данную клавишу отсутсвует");
                    break;
            }
        }
    }
}