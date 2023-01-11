using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeMerger
{
    public class ConsoleWriteLine
    {
        public void WhichObject()
        {
            Console.WriteLine("Hangi objeyi seçmek istersiniz? <pet/car/both>");
            Console.WriteLine();
        }

        public void WannaDeserialize()
        {
            Console.WriteLine("Objeleri deserialize etmek ister misin? y/n ");
        }

        public void CreateObject()
        {
            Console.WriteLine("Obje oluşturmak ister misiniz? y/n ");
        }

        public void OneMoreObject()
        {
            Console.WriteLine("Yeni bir obje daha oluşturmak ister misiniz? y/n ");
        }

        public void EmptySpace()
        {
            Console.WriteLine();
        }

        public void FormatExceptionAlert()
        {
            Console.WriteLine("Format Exception detected: The input needs to be a number!");
        }

        public void ArgumentOutOfRangeException()
        {
            Console.WriteLine("Argument Out Of Range Exception");
        }

    }
}
