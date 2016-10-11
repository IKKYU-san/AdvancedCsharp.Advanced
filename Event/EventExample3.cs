
namespace AdvancedCsharp.Advanced.Event
{
    using System;
    using System.IO;
    

    // En enkel klass som håller reda på temperatur och tryck

    class Boiler
    {
        public int Temperature { get; }
        public int Pressure { get; }

        public Boiler(int t, int p)
        {
            Temperature = t;
            Pressure = p;
        }

    }

    // "publisher" - den klass som talar om att ett "event" har skett

    class DelegateBoilerEvent
    {
        // Denna delegate används bara för att definiera vilken typ "eventet" har
        public delegate void BoilerLogHandler(string status); 

        // Detta är event'et som andra klasser kan prenumera på
        public event BoilerLogHandler BoilerEventLog;

        public void CheckBoiler(Boiler b)
        {
            string remarks = "Allt är ok";
            
            if (b.Temperature > 150 || b.Temperature < 80 || b.Pressure < 12 || b.Pressure > 15)
            {
                remarks = "Behöver underhåll";
            }

            // Detta görs alltid

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(remarks);
            Console.ForegroundColor = ConsoleColor.White;

            // Om någon prenumerar på eventet så körs det

            OnBoilerEventLog($"{DateTime.Now}");
            OnBoilerEventLog($"Temparature: {b.Temperature} Pressure: {b.Pressure}");
            OnBoilerEventLog($"Message: {remarks}");
            OnBoilerEventLog("---------------------------------");
        }

        protected void OnBoilerEventLog(string message)
        {
            if (BoilerEventLog != null) // Om eventet inte används så vill vi inte ha NullException
            {
                BoilerEventLog(message);
            }
        }
    }

    // En en enkel klass som loggar till en textfil

    class BoilerInfoLogger
    {
        FileStream fs;
        StreamWriter sw;

        public BoilerInfoLogger(string filename)
        {
            fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
        }

        public void Logger(string info)
        {
            sw.WriteLine(info);
        }

        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }

    // Huvudprogrammet
    // Innehåller även en egen loggningsfunktion

    class EventExample3
    {
        static void LoggerToScreen(string info)
        {
            Console.WriteLine(info);
        }

        public void Run()
        {
            BoilerInfoLogger filelog = new BoilerInfoLogger("c:\\TMP\\boiler.txt");

            // Skapa en instans av "publiser'n"
            DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();

            // När eventet "BoilerEventLog" körs så körs båda loggningmetoderna (till fil och till skärm)
            // Det går alltså lätt "utifrån" att styra vilken loggning som ska hakas på (eller ingen loggning alls om så önskas)
            // Testa att kommentera bort följande två rader och se vad det blir för skillnad

            boilerEvent.BoilerEventLog += LoggerToScreen; 
            boilerEvent.BoilerEventLog += filelog.Logger;

            // Testkörning

            boilerEvent.CheckBoiler(new Boiler(100, 12));
            boilerEvent.CheckBoiler(new Boiler(800, 12));
            boilerEvent.CheckBoiler(new Boiler(100, 120));

            filelog.Close();
        }
    }

    
}
