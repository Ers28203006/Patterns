using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder
{
    class Body
    {
        public Body()
        {
            Console.WriteLine("Корпус");
        }
    }

    class TankPluss
    {
        public TankPluss()
        {
            Console.WriteLine("подвеска TankPluss");
        }
    }

    class Сonditioner
    {
        public Сonditioner()
        {
            Console.WriteLine("Кондиционер");
        }
    }

    class Nitro
    {
        public Nitro()
        {
            Console.WriteLine("Возможность добавления Nitro в топливо");
        }
    }

    class Car
    {
        readonly ArrayList parts = new ArrayList();
        public void Add(object part)
        {
            parts.Add(part);
        }
    }

    interface ICarBuilder
    {
        void BodyCreate();
        void TankPlussCreate();
        void СonditionerCreate();
        void NitroCreate();

        Car GetCar();
    }

    class Ford : ICarBuilder
    {
        Car car = new Car();
        public void BodyCreate()
        {
            car.Add(new Body());
        }

        public Car GetCar()
        {
            return car;
        }

        public void NitroCreate()
        {
            car.Add(new Nitro());
        }

        public void TankPlussCreate()
        {
            car.Add(new TankPluss());
        }

        public void СonditionerCreate()
        {
            car.Add(new Сonditioner());
        }
    }

    class Director
    {
        ICarBuilder _carBuilder;
        public Director(ICarBuilder carBuilder)
        {
            _carBuilder = carBuilder;
        }

        public void Basic()
        {
            _carBuilder.BodyCreate();
        }
        public void Standard()
        {
            _carBuilder.BodyCreate();
            _carBuilder.NitroCreate();
            _carBuilder.TankPlussCreate();
        }
        public void Lux()
        {
            _carBuilder.BodyCreate();
            _carBuilder.NitroCreate();
            _carBuilder.TankPlussCreate();
            _carBuilder.СonditionerCreate();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICarBuilder ford = new Ford();

            Director director = new Director(ford);

            Console.WriteLine("***********************\nбазовая комплектация:");
            director.Basic();
            Console.WriteLine("***********************\nстандартная комплектация:");
            director.Standard();
            Console.WriteLine("***********************\nполная комплектация:");
            director.Lux();

            Car car = ford.GetCar();
        }
    }
}
