//пример с телефоном
using System;
using System.Collections;

namespace Builder
{
    class Body
    {
        public Body()
        {
            Console.WriteLine("Тело");
        }
    }

    class BatteryPlus
    {
        public BatteryPlus()
        {
            Console.WriteLine("Дополнительная батарея");
        }
    }

    class Cover
    {
        public Cover()
        {
            Console.WriteLine("Обложка");
        }
    }

    class Telephone
    {
        ArrayList parts = new ArrayList();

        public void Add(object part)
        {
            parts.Add(part);
        }

    }
    interface IVendor
    {
        void BodyCreate();
        void BatteryPlusCreate();
        void CoverCreate();

        Telephone GetTelephone();
    }

    class Samsung : IVendor
    {
        Telephone _telephone = new Telephone();
        public void BodyCreate()
        {
            _telephone.Add(new Body());
        }

        public void BatteryPlusCreate()
        {
            _telephone.Add(new BatteryPlus());
        }

        public void CoverCreate()
        {
            _telephone.Add(new Cover());
        }

        public Telephone GetTelephone()
        {
            return _telephone;
        }
    }

    class Director
    {
        IVendor _vendor;
        public Director(IVendor vendor)
        {
            _vendor = vendor;
        }

        public void Basic()
        {
            _vendor.BodyCreate();
        }

        public void Standard()
        {
            _vendor.BodyCreate();
            _vendor.BatteryPlusCreate();
        }
        public void Lux()
        {
            _vendor.BodyCreate();
            _vendor.BatteryPlusCreate();
            _vendor.CoverCreate();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IVendor samsung = new Samsung();

            Director director = new Director(samsung);

            Console.WriteLine("***********************\nбазовая комплектация:");
            director.Basic();
            Console.WriteLine("***********************\nстандартная комплектация:");
            director.Standard();
            Console.WriteLine("***********************\nполная комплектация:");
            director.Lux();

            Telephone telephone = samsung.GetTelephone();
        }
    }
}
