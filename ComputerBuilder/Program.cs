using System;
using System.Collections;

namespace ComputerBuilder
{
    class Mainboard
    {
        public Mainboard()
        {
            Console.WriteLine("Mainboard");
        }
    }
    class Processor
    {
        public Processor()
        {
            Console.WriteLine("Processor");
        }
    }
    class VideoCard
    {
        public VideoCard()
        {
            Console.WriteLine("VideoCard");
        }
    }
    class SoundCard
    {
        public SoundCard()
        {
            Console.WriteLine("SoundCard");
        }
    }

    class Tuner
    {
        public Tuner()
        {
            Console.WriteLine("Tuner");
        }
    }

    class Computer
    {
        ArrayList parts = new ArrayList();

        public void Add(object part)
        {
            parts.Add(part);
        }
    }

    interface IComputerBuilder
    {
        void BuildMainboard();
        void BuildVideoCard();
        void BuildProcessor();
        void BuildSoundCard();
        void BuildTuner();

        Computer GetComputer();
    }

    class Dell : IComputerBuilder
    {
        Computer computer = new Computer();
        public void BuildMainboard()
        {
            computer.Add(new Mainboard());
        }

        public void BuildProcessor()
        {
            computer.Add(new Processor());
        }

        public void BuildSoundCard()
        {
            computer.Add(new SoundCard());

        }

        public void BuildTuner()
        {
            computer.Add(new Tuner());
        }

        public void BuildVideoCard()
        {
            computer.Add(new VideoCard());
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }

    class Director
    {
        IComputerBuilder _dell;
        public Director(IComputerBuilder dell)
        {
            _dell = dell;
        }

        public void Basic()
        {
            _dell.BuildMainboard();
            _dell.BuildProcessor();
        }
        public void Standard()
        {
            _dell.BuildMainboard();
            _dell.BuildProcessor();
            _dell.BuildSoundCard();
        }

        public void StandardPlus()
        {
            _dell.BuildMainboard();
            _dell.BuildProcessor();
            _dell.BuildSoundCard();
            _dell.BuildVideoCard();
        }
        public void Lux()
        {
            _dell.BuildMainboard();
            _dell.BuildProcessor();
            _dell.BuildSoundCard();
            _dell.BuildVideoCard();
            _dell.BuildTuner();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IComputerBuilder dell = new Dell();

            Director director = new Director(dell);
            Console.WriteLine("***********************\nбазовая комплектация:");
            director.Basic();
            Console.WriteLine("***********************\nстандартная комплектация:");
            director.Standard();
            Console.WriteLine("***********************\nстандарт плюс комплектация:");
            director.StandardPlus();
            Console.WriteLine("***********************\nстандарт плюс комплектация:");
            director.Lux();

            Computer computer = dell.GetComputer();
        }
    }
}
