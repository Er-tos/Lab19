using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Program_1
    {
        static void Main(string[] args)
        {
            List<Computer> myList = new List<Computer>()
            {
                new Computer(){ Сode = 5856, MarkName = "MSI", ProcessorType = "Phenom", ProcessorFrequency = 3, RamSize = 4096, HdSize = 2, VideoCardMemory = 2, CostOfComputer = 69990, NumberOfCopiesAvailable = 5},
                new Computer(){ Сode = 5790, MarkName = "DELL", ProcessorType = "Celeron", ProcessorFrequency = 1, RamSize = 2048, HdSize = 1, VideoCardMemory = 1, CostOfComputer = 74800, NumberOfCopiesAvailable = 9},
                new Computer(){ Сode = 5698, MarkName = "Asus", ProcessorType = "Xeon", ProcessorFrequency = 3, RamSize = 4096, HdSize = 1, VideoCardMemory = 1, CostOfComputer = 47980, NumberOfCopiesAvailable = 3},
                new Computer(){ Сode = 4668, MarkName = "HP", ProcessorType = "Atom", ProcessorFrequency = 1, RamSize = 1024 , HdSize = 1, VideoCardMemory = 1, CostOfComputer = 30000, NumberOfCopiesAvailable = 4},
                new Computer(){ Сode = 4696, MarkName = "Huawei", ProcessorType = "Celeron", ProcessorFrequency = 2, RamSize = 2048 , HdSize = 2, VideoCardMemory = 1, CostOfComputer = 57300, NumberOfCopiesAvailable = 30},
                new Computer(){ Сode = 5680, MarkName = "Lenovo", ProcessorType = "Pentium", ProcessorFrequency = 1, RamSize = 1024 , HdSize = 1, VideoCardMemory = 2, CostOfComputer = 65500, NumberOfCopiesAvailable = 4},
            };
            Console.WriteLine("Введите название искомого процессора.");
            string correctProcessorType = Console.ReadLine();
            List<Computer> withCorrectProcessorType = myList
                .Where(c => c.ProcessorType == correctProcessorType)
                .Distinct()
                .ToList();
            Console.WriteLine($"В нашем магазине присутствуют {withCorrectProcessorType.Count} компьютеров с таким процессором:");
            foreach (Computer pc in withCorrectProcessorType)
            {
                Console.WriteLine($"Компьютер {pc.MarkName} за {pc.CostOfComputer}");
            }
            Console.WriteLine();
            Console.WriteLine("Введите искомый объем ОЗУ.");
            int requiredAmountRAM = Convert.ToInt32(Console.ReadLine());
            List<Computer> withCorrectRAM = myList
                .Where(c => c.RamSize >= requiredAmountRAM)
                .Distinct()
                .ToList();
            Console.WriteLine($"В нашем магазине присутствуют {withCorrectRAM.Count} компьютеров с таким количеством ОЗУ:");
            foreach (Computer pc in withCorrectRAM)
            {
                Console.WriteLine($"Компьютер {pc.MarkName} за {pc.CostOfComputer}");
            }
            Console.WriteLine();
            Console.WriteLine("Список компьютеров в наличии по возрастанию цены.");
            List<Computer> sortByCost = myList
                .OrderBy(s => s.CostOfComputer)
                .Distinct()
                .ToList();
            foreach (Computer pc in sortByCost)
            {
                Console.WriteLine($"Компьютер {pc.MarkName} за {pc.CostOfComputer}");
            }
            Console.WriteLine();
            Console.WriteLine("Список компьютеров, сгруппированный по типу процессора.");
            var groupByProcessorType = myList
                .GroupBy(s => s.ProcessorType)
                .ToList();
            foreach (IGrouping<string, Computer> gr in groupByProcessorType)
            {
                Console.WriteLine($"С процессором {gr.Key}");
                foreach (var pc in gr)
                    Console.WriteLine($"    присутствует компьютер {pc.MarkName} за {pc.CostOfComputer}");

            }
            Console.WriteLine();
            Console.WriteLine($"Самым недорогиим компьютером является: {sortByCost.First().MarkName} за {sortByCost.First().CostOfComputer}");
            Console.WriteLine($"Самым дорогим компьютером является: {sortByCost.Last().MarkName} за {sortByCost.Last().CostOfComputer}");
            if (myList.Any(c => c.NumberOfCopiesAvailable >= 30))
            {
                Console.Write("Есть модель компьютера в количестве не менее 30 штук.");
            }
            else
            {
                Console.Write("Нет ни одной модели компьютера в количестве не менее 30 штук.");
            }
            Console.ReadKey();
        }
    }
    class Computer
    {
        public int Сode { get; set; }
        public string MarkName { get; set; }
        public string ProcessorType { get; set; }
        public int ProcessorFrequency { get; set; }
        public int RamSize { get; set; }
        public int HdSize { get; set; }
        public int VideoCardMemory { get; set; }
        public int CostOfComputer { get; set; }
        public int NumberOfCopiesAvailable { get; set; }
    }
}
