using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtschedule
{
    internal class Program
    {
        public class Lesson
        {
            string _name;
            int _classroom;
            public Lesson(string name, int classroom)
            {
                _name = name;
                _classroom = classroom;
            }
            public string Name { get => _name; set => _name = value; }
            public int Classroom { get => _classroom; set => _classroom = value; }
        }
        public class DayOfWeek
        {
            string _nameday;
            Lesson[] _lessons = new Lesson[8];
            string[] _time = new string[8] { "09:10 - 09:55", "09:55 - 10:40", "10:50 - 11:35", "11:35 - 12:20", "12:30 - 13:20", "14:00 - 14:40", "14:50 - 15:35", "15:35 - 16:20" };
            public string[] Time { get => _time; }
            public DayOfWeek(string nameday)
            {
                _nameday = nameday;
                _lessons = new Lesson[8];
                for (int i = 0; i < 8; i++)
                {
                    _lessons[i] = new Lesson("-", 0);
                }
            }
            public DayOfWeek(string nameday, Lesson[] lessons)
            {
                _nameday = nameday;
                _lessons = lessons;
                for (int i = 0; i < 8; i++)
                {
                    _lessons[i] = new Lesson("-", 0);
                }
            }
            public string NameDay { get => _nameday; set => _nameday = value; }
            public Lesson[] Lessons { get => _lessons; set => _lessons = value; }
            public void OneDay(string path)
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"        {NameDay}");
                    sw.WriteLine(
                    format: "{0, -15} {1,-15} {2, -20}",
                    arg0: "Время",
                    arg1: "Урок",
                    arg2: "Кабинет");
                    for (int j = 0; j < 8; j++)
                    {
                        Lesson lessontoday = Lessons[j];
                        sw.WriteLine(
                        format: "{0, -15} {1, -15} {2, -20}",
                        arg0: Time[j],
                        arg1: lessontoday.Name,
                        arg2: lessontoday.Classroom);
                    }
                    sw.WriteLine("");
                }
            }

            public void ChangeLesson(string numl, string namel, string classl)
            {
                try
                {
                    int a = Convert.ToInt32(numl);
                    int b = Convert.ToInt32(classl);
                    if (a - 1 >= 0 && a - 1 <= 7)
                    {
                        Lesson addl = new Lesson(namel, b);
                        Lessons[a - 1] = addl;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: некорректный ввод. Номер урока должен находиться в интервале от 1 до 8 включительно. Повторите попытку");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: некорректный ввод. Номер урока и номер кабинета должны быть числами. Повторите попытку");
                }
            }
            public void RemoveLesson(string numl)
            {
                try
                {
                    int a = Convert.ToInt32(numl);
                    if (a - 1 > 0 && a - 1 <= 7)
                    {
                        Lesson removel = new Lesson("-", 0);
                        Lessons[a - 1] = removel;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: некорректный ввод. Номер урока должен находиться в интервале от 1 до 8 включительно. Повторите попытку");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: некорректный ввод. Номер урока должен быть числом. Повторите попытку");
                }
            }

        }
        public class TimeTable
        {
            DayOfWeek[] _days = new DayOfWeek[6];
            public TimeTable()
            {
                _days[0] = new DayOfWeek("Понедельник");
                _days[1] = new DayOfWeek("Вторник");
                _days[2] = new DayOfWeek("Среда");
                _days[3] = new DayOfWeek("Четверг");
                _days[4] = new DayOfWeek("Пятница");
                _days[5] = new DayOfWeek("Суббота");
            }
            public DayOfWeek[] Days { get => _days; set => _days = value; }

        }


        static void Main(string[] args)
        {
            TimeTable tt = new TimeTable();
            DayOfWeek monday0 = tt.Days[0];
            DayOfWeek tuesday0 = tt.Days[1];
            DayOfWeek wednesday0 = tt.Days[2];
            DayOfWeek thursday0 = tt.Days[3];
            DayOfWeek friday0 = tt.Days[4];
            DayOfWeek saturday0 = tt.Days[5];
            Lesson chem = new Lesson("Химия", 501);
            Lesson phys1 = new Lesson("Физика (Семинар)", 309);
            Lesson eng = new Lesson("Английский язык", 04);
            Lesson math1 = new Lesson("Математика", 1417);
            Lesson lit1 = new Lesson("Литература", 302);
            Lesson it = new Lesson("Информатика", 302);
            Lesson geo = new Lesson("География", 508);
            Lesson rov = new Lesson("Разговоры о важном", 419);
            Lesson calc = new Lesson("Математический анализ", 1406);
            Lesson rus = new Lesson("Русский язык", 307);
            Lesson math2 = new Lesson("Математика", 1402);
            Lesson ss = new Lesson("Обществознание", 1317);
            Lesson prog = new Lesson("Программирование", 302);
            Lesson math3 = new Lesson("Математика", 419);
            Lesson lit2 = new Lesson("Литература", 305);
            Lesson hist = new Lesson("История", 1406);
            Lesson phys2 = new Lesson("Физика (Лекция)", 317);
            Lesson physprac = new Lesson("Физический практикум", 309);
            monday0.Lessons[0] = chem; monday0.Lessons[1] = chem;
            monday0.Lessons[2] = phys1; monday0.Lessons[3] = phys1; monday0.Lessons[4] = phys1; monday0.Lessons[5] = phys1;
            monday0.Lessons[6] = eng; monday0.Lessons[7] = eng; wednesday0.Lessons[4] = eng; wednesday0.Lessons[5] = eng;
            tuesday0.Lessons[0] = math1; tuesday0.Lessons[1] = math1;
            tuesday0.Lessons[2] = lit1; tuesday0.Lessons[3] = it; tuesday0.Lessons[4] = geo; tuesday0.Lessons[5] = rov; tuesday0.Lessons[6] = calc; tuesday0.Lessons[7] = calc;
            wednesday0.Lessons[0] = rus; wednesday0.Lessons[1] = rus;
            wednesday0.Lessons[2] = math2; wednesday0.Lessons[3] = math2;
            wednesday0.Lessons[4] = eng; wednesday0.Lessons[5] = eng;
            wednesday0.Lessons[6] = ss; wednesday0.Lessons[7] = ss;
            thursday0.Lessons[0] = prog; thursday0.Lessons[1] = prog;
            thursday0.Lessons[2] = math3; thursday0.Lessons[3] = math3; thursday0.Lessons[4] = math3; thursday0.Lessons[5] = math3;
            thursday0.Lessons[6] = lit2; thursday0.Lessons[7] = lit2;
            friday0.Lessons[0] = hist; friday0.Lessons[1] = hist;
            friday0.Lessons[2] = phys2; friday0.Lessons[3] = phys2; friday0.Lessons[4] = phys2; friday0.Lessons[5] = phys2;
            saturday0.Lessons[4] = physprac; saturday0.Lessons[5] = physprac; saturday0.Lessons[6] = physprac; saturday0.Lessons[7] = physprac;
            string dirpath = @"C:\Users\Admin\Downloads";
            string subpath = @"CSharp\projects";
            DirectoryInfo dirInfo = new DirectoryInfo(dirpath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            string filepath = @"C:\Users\Admin\Downloads\CSharp\projects\schedule.txt";
            FileInfo fileInfo = new FileInfo(filepath);
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }
            for (int i = 0; i < 6; i++)
            {
                DayOfWeek today = tt.Days[i];
                today.OneDay(filepath);
            }
            Console.WriteLine("Введите !ИзменитьУрок для изменения урока");
            Console.WriteLine("Введите !УдалитьУрок для удаления урока");
            Console.WriteLine("Введите !СброситьИзменения для сброса изменений");
            while (true)
            {
                Console.WriteLine(" ");
                string command = Console.ReadLine();
                if (command == "!ИзменитьУрок")
                {
                    Console.WriteLine("День:");
                    string addday = Console.ReadLine();
                    Console.WriteLine("Номер урока:");
                    string addnum = Console.ReadLine();
                    Console.WriteLine("Название нового урока:");
                    string addname = Console.ReadLine();
                    Console.WriteLine("Кабинет:");
                    string addclass = Console.ReadLine();
                    if (addday == "Понедельник" || addday == "понедельник")
                    {
                        DayOfWeek today = tt.Days[0];
                        today.ChangeLesson(addnum, addname, addclass);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (addday == "Вторник" || addday == "вторник")
                    {
                        DayOfWeek today = tt.Days[1];
                        today.ChangeLesson(addnum, addname, addclass);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (addday == "Среда" || addday == "среда")
                    {
                        DayOfWeek today = tt.Days[2];
                        today.ChangeLesson(addnum, addname, addclass);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (addday == "Четверг" || addday == "четверг")
                    {
                        DayOfWeek today = tt.Days[3];
                        today.ChangeLesson(addnum, addname, addclass);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (addday == "Пятница" || addday == "пятница")
                    {
                        DayOfWeek today = tt.Days[4];
                        today.ChangeLesson(addnum, addname, addclass);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (addday == "Суббота" || addday == "суббота")
                    {
                        DayOfWeek today = tt.Days[5];
                        today.ChangeLesson(addnum, addname, addclass);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: некорректный ввод. Повторите попытку");
                    }
                }
                else if (command == "!УдалитьУрок")
                {
                    Console.WriteLine("День:");
                    string removeday = Console.ReadLine();
                    Console.WriteLine("Номер урока:");
                    string removenum = Console.ReadLine();
                    if (removeday == "Понедельник" || removeday == "понедельник")
                    {
                        DayOfWeek today = tt.Days[0];
                        today.RemoveLesson(removenum);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (removeday == "Вторник" || removeday == "вторник")
                    {
                        DayOfWeek today = tt.Days[1];
                        today.RemoveLesson(removenum);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (removeday == "Среда" || removeday == "среда")
                    {
                        DayOfWeek today = tt.Days[2];
                        today.RemoveLesson(removenum);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (removeday == "Четверг" || removeday == "четверг")
                    {
                        DayOfWeek today = tt.Days[3];
                        today.RemoveLesson(removenum);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (removeday == "Пятница" || removeday == "пятница")
                    {
                        DayOfWeek today = tt.Days[4];
                        today.RemoveLesson(removenum);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else if (removeday == "Суббота" || removeday == "суббота")
                    {
                        DayOfWeek today = tt.Days[5];
                        today.RemoveLesson(removenum);
                        File.Delete(filepath);
                        for (int i = 0; i < 6; i++)
                        {
                            DayOfWeek today0 = tt.Days[i];
                            today0.OneDay(filepath);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: некорректный ввод. Повторите попытку");
                    }
                }
                else if (command == "!СброситьИзменения")
                {
                    monday0.Lessons[0] = chem; monday0.Lessons[1] = chem;
                    monday0.Lessons[2] = phys1; monday0.Lessons[3] = phys1; monday0.Lessons[4] = phys1; monday0.Lessons[5] = phys1;
                    monday0.Lessons[6] = eng; monday0.Lessons[7] = eng; wednesday0.Lessons[4] = eng; wednesday0.Lessons[5] = eng;
                    tuesday0.Lessons[0] = math1; tuesday0.Lessons[1] = math1;
                    tuesday0.Lessons[2] = lit1; tuesday0.Lessons[3] = it; tuesday0.Lessons[4] = geo; tuesday0.Lessons[5] = rov; tuesday0.Lessons[6] = calc; tuesday0.Lessons[7] = calc;
                    wednesday0.Lessons[0] = rus; wednesday0.Lessons[1] = rus;
                    wednesday0.Lessons[2] = math2; wednesday0.Lessons[3] = math2;
                    wednesday0.Lessons[4] = eng; wednesday0.Lessons[5] = eng;
                    wednesday0.Lessons[6] = ss; wednesday0.Lessons[7] = ss;
                    thursday0.Lessons[0] = prog; thursday0.Lessons[1] = prog;
                    thursday0.Lessons[2] = math3; thursday0.Lessons[3] = math3; thursday0.Lessons[4] = math3; thursday0.Lessons[5] = math3;
                    thursday0.Lessons[6] = lit2; thursday0.Lessons[7] = lit2;
                    friday0.Lessons[0] = hist; friday0.Lessons[1] = hist;
                    friday0.Lessons[2] = phys2; friday0.Lessons[3] = phys2; friday0.Lessons[4] = phys2; friday0.Lessons[5] = phys2;
                    saturday0.Lessons[4] = physprac; saturday0.Lessons[5] = physprac; saturday0.Lessons[6] = physprac; saturday0.Lessons[7] = physprac;
                    File.Delete(filepath);
                    for (int i = 0; i < 6; i++)
                    {
                        DayOfWeek today0 = tt.Days[i];
                        today0.OneDay(filepath);
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: неопознанная команда. Повторите попытку");
                }
            }
        }
    }
}
