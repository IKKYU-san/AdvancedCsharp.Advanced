
namespace AdvancedCsharp.Advanced.Event
{
    using System;
    using System.Threading;

    // Roulette är tänk som en generell klass som kan användas på flera ställen
    // Andra kan jacka in i event'en som Roulette förser, för att modifera beteendet

    class Roulette
    {
        public delegate void SimpleAction();
        public delegate void SimpleFunctionReturnInteger(int number);

        public event SimpleAction WheelBeforeStart;               // Alternativt: public event Action WheelBeforeStart;
        public event SimpleFunctionReturnInteger WheelAfterStop;  // Alternativt: public event Action<int> WheelAfterStop;

        int RandomNumber()
        {
            return new Random().Next(37);
        }

        public void SpinWheel()
        {
            if (WheelBeforeStart!=null)
            {
                WheelBeforeStart();         // Alternativt: WheelBeforeStart.Invoke();
            }

            Console.WriteLine("Hjulet börjar snurra...");
            Thread.Sleep(3000);

            var number = RandomNumber();

            Console.WriteLine($"Hjulet har snurrat klart, kulan hamnade på {number}");

            if (WheelAfterStop!=null)
            {
                WheelAfterStop(number);     // Alternativt: WheelAfterStop.Invoke(number);
            }
        }
    }

    public class EventExample2
    {
        public void Run()
        {
            // En instans av Roulette skapas

            var r = new Roulette();

            Console.WriteLine("Kalle satsar på ett jämnt nummer");

            // Nu jackar vi in i WheelBeforeStart och WheelAfterStop
            // Då kan vi ändra/utöka beteendet av Roulette's metod "SpinWheel"
            // Testa att kommentera bort följande fem rader och se vad som händer

            r.WheelBeforeStart += Kalle1;
            r.WheelBeforeStart += Kalle2;
            r.WheelBeforeStart += Kalle2;
            r.WheelAfterStop += Kalle3;

            Console.WriteLine("Detta sker efter att vi prenumerat på event'en");

            r.SpinWheel();

            Console.ReadKey();
        }

        private void Kalle1()
        {
            Console.WriteLine("Kalle gör saker innan hjulet har börjat snurra");
        }

        private void Kalle2()
        {
            Console.WriteLine("Kalle gör fler saker");
        }

        private void Kalle3(int i)
        {
            Console.WriteLine("Kalle vet nu att hjulet stannat");
            if (i % 2 == 0)
            {
                Console.WriteLine("Kalle vann!");
            } else
            {
                Console.WriteLine("Kalle förlorade :(");
            }
        }

    }
}
