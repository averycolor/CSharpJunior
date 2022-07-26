namespace Homework
{
    internal class Program
    {

        static void Main(string[] args)
        {
            char consoleCommand = ' ';
            Dictionary<string, string> dossiers = new Dictionary<string, string>();

            while (consoleCommand != '4')
            {
                Console.Clear();
                Console.Write(
                    "Кадровый учет v2" + "\n" +
                    "[1] Добавить досье" + "\n" +
                    "[2] Просмотр всех досье" + "\n" +
                    "[3] Удалить досье" + "\n" +
                    "[4] Выход" + "\n"
                );

                consoleCommand = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (consoleCommand)
                {
                    case '1':
                        AddDossier(dossiers);
                        break;
                    case '2':
                        DisplayDossiers(dossiers);
                        break;
                    case '3':
                        DeleteDossier(dossiers);
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, string> dossiers)
        {
            Console.Write("ФИО сотрудника: ");
            string name = Console.ReadLine();

            Console.Write("Должность сотрудника: ");
            string position = Console.ReadLine();

            dossiers.Add(name, position);
        }

        static string FormatDossier(int order, string name, string position)
        {
            return $"{order} - {name} - {position}";
        }

        static void DisplayDossiers(Dictionary<string, string> dossiers)
        {
            for (int currentOrder = 0; currentOrder < dossiers.Count; currentOrder++)
            {
                var dossier = dossiers.ElementAt(currentOrder);
                string name = dossier.Key;
                string position = dossier.Value;
                Console.WriteLine(FormatDossier(currentOrder, name, position));
            }

            WaitKey();
        }

        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            int dossierIndex;
            Console.Write("Укажите порядковый номер досье: ");

            while (int.TryParse(Console.ReadLine(), out dossierIndex) == false || (dossierIndex < 0 || dossierIndex >= dossiers.Count))
            {
                Console.WriteLine("Введённый литерал не является числом или не является валидным порядковым номером");
                Console.Write("Попробуйте ещё раз: ");
            }

            dossiers.Remove(dossiers.ElementAt(dossierIndex).Key);
            Console.WriteLine("Удаление успешно");
            WaitKey();
        }

        static void WaitKey()
        {
            Console.WriteLine("Нажмите на любую клавишу, чтобы продолжить");
            Console.ReadKey(true);
        }
    }
}
