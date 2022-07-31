using System;

namespace TestPowerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    abstract class Car
    {
        public string CarType { get; set; }
        public int AvgFuelConsumationLiterPerKm { get; set; }
        public int FuelTankCapacity { get; set; }
        public int Speed { get; set; }
        public int Fuel { get
            {
                return Fuel;
            } set
            {
                if(value > FuelTankCapacity)
                {
                    throw new Exception($"В баке не может быть больше максимума");
                }
                else
                {
                    Fuel = value;
                }
            }
        }
        public int GetFullTankKms()
        {
            return FuelTankCapacity / AvgFuelConsumationLiterPerKm;
        }
        public virtual int GetLeftKms()
        {
            return Fuel / AvgFuelConsumationLiterPerKm;
        }
        public double GetTimeToRichDistance(double kms)
        {
            return kms/Convert.ToDouble(Speed);
        }
    }
    class PassengerCar : Car
    {
        int PassengersCapacity { get; set; }
        int Passengers
        {
            get
            {
                return Passengers;
            }
            set
            {
                if (value > PassengersCapacity)
                {
                    throw new Exception($"Пассажиров в машине не может быть больше максимума");
                }
                else
                {
                    Passengers = value;
                }

            }
        }
        public override int GetLeftKms()
        {
            return Fuel / AvgFuelConsumationLiterPerKm * (100-Passengers*6)/100;
        }


    }
    class Truck : Car
    {
        int LoadCapacity { get; set; }
        int Load
        {
            get
            {
                return Load;
            }
            set
            {
                if (value > LoadCapacity)
                {
                    throw new Exception($"Перегруз");
                }
                else
                {
                    Load = value;
                }

            }
        }
        public override int GetLeftKms()
        {
            return Fuel / AvgFuelConsumationLiterPerKm * (100 - Load/200*4) / 100;
        }
    }
    class SportCar : Car { }
}

//MS SQL
//create table Customers (Id int IDENTITY(1,1) NOT NULL, Name varchar(50))
//insert into Customers (Name) values('Max'),('Pavel'),('Ivan'),('Leonid')

//create table Orders  (Id int IDENTITY(1,1) NOT NULL , CustomerID int)
//insert into Orders (CustomerID) values(2),(4)

//select Name as Customers from Customers where Customers.Id not in (select distinct CustomerID from Orders)