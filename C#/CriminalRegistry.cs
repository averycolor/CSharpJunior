namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>() {
                new Criminal("Andrei", "Chernov", "Vladimirovich", 190, 90, Nationality.Russian),
                new Criminal("Viktor", "Reznov", "Aleksandrovich", 183, 78, Nationality.English),
                new Criminal("Elena", "Dobrykh", "Viktorovna", 167, 59, Nationality.Italian),
                new Criminal("Vladislav", "Iskandarov", "Ivanovich", 172, 71, Nationality.French)
            };

            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();

                Console.WriteLine("Укажите ИФО, рост, вес и национальность преступника через пробел");
                List<string> criminalInfo = Console.ReadLine().Split().ToList();

                int criminalHeight;
                int criminalWeight;
                string criminalName;
                string criminalLastName;
                string criminalPatronymic;
                string criminalNationality;
                if (criminalInfo.Count >= 6 && int.TryParse(criminalInfo[3], out criminalHeight) && int.TryParse(criminalInfo[4], out criminalWeight))
                {
                    criminalName = criminalInfo[0];
                    criminalLastName = criminalInfo[1];
                    criminalPatronymic = criminalInfo[2];
                    criminalNationality = criminalInfo[5];
                    List<Criminal> matchingCriminals = criminals.Where(criminal => criminal.MatchesCharacteristic(criminalName, criminalLastName, criminalPatronymic, criminalHeight, criminalWeight, criminalNationality) && criminal.IsUnderArrest == false).ToList();
                    
                    if (matchingCriminals.Count > 0)
                    {
                        matchingCriminals[0].Arrest();
                        Console.WriteLine("Преступник найден и заключен под стражу");
                    }
                    else
                    {
                        Console.WriteLine("Преступники не найдены.");
                    }
                } else
                {
                    Console.WriteLine("Характеристика указана в неверном формате.");
                }

                Console.WriteLine("Нажмите на Esc, чтобы выйти или на любую другую клавишу, чтобы продолжить");

                ConsoleKey pressedKey = Console.ReadKey(true).Key;

                if (pressedKey == ConsoleKey.Escape)
                {
                    isWorking = false;
                }
            }
        }
    }

    public enum Nationality
    {
        Russian, English, French, Italian
    }

    class Criminal
    {
        public bool IsUnderArrest { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Patronymic { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public Nationality Nationality { get; private set; }

        public Criminal(string name, string lastName, string patronymic, int height, int weight, Nationality nationality)
        {
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsUnderArrest = false;
        }

        public bool MatchesCharacteristic(string name, string lastName, string patronymic, int height, int weight, string nationality)
        {
            return Name == name && LastName == lastName && Patronymic == patronymic && Height == height && Weight == weight && Nationality.ToString() == nationality;
        }

        public void Arrest()
        {
            IsUnderArrest = true;
        }
    } 
}
