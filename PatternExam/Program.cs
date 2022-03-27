using System;

namespace PatternExam
{
    class Program
    {
        private static DateTime _beginDate;
        private static int _days;
        static void Main(string[] args)
        {
            DateChoise();
            CountOfDaysChoise();
            TourChoise();
            
        }

        private static void DateChoise()
        {   
           

            do{
                Console.WriteLine("Введите дату (01\\01\\2022)\n");
            }while (DateTime.TryParse(Console.ReadLine(), out _beginDate));

        }

        private static void CountOfDaysChoise()
        {
            while(true)
            {
                Console.WriteLine("Введите количество дней (не более 30 дней)\n");
                if (int.TryParse(Console.ReadLine(), out _days))
                {
                    if (_days >= 0 && _days <= 30)
                        break;
                }
            }
        }

        private static void TourChoise()
        {   
            string answer = "";
            TourFactory currentFactory;
            while(true)
            {
                Console.WriteLine("Выберете путевку\nS - Сочи\nE - Египет\n");
                try
                {
                    answer = Console.ReadLine();
                    currentFactory = GetTourFactory(answer);
                    Console.WriteLine(currentFactory.GetTour());
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static TourFactory GetTourFactory(string name)
        {
            switch(name.ToLower())
            {
                case "s": 
                    return new SochiTourFactory(_beginDate, _days, 2000);
                case "e":
                    return new EgyptTourFactory(_beginDate, _days, 1000);
                default:
                    throw new Exception("Error factory!");
            }
        }
    }
}
