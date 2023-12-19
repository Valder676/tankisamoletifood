using System;
using System.Collections.Generic;


interface IDrive
{
    string Drive();
}

interface IRotateTurret
{
    string RotateTurret();
}

interface IShoot
{
    string Shoot();
}

interface ISwim
{
    string Swim();
}


abstract class Vehicle
{
    public abstract string StartEngine();
}

class Car : Vehicle, IDrive
{
    public override string StartEngine()
    {
        return "Двигатель автомобиля заведен!";
    }

    public string Drive()
    {
        return "Автомобиль едет.";
    }
}


class Motorcycle : Vehicle, IDrive
{
    public override string StartEngine()
    {
        return "Двигатель мотоцикла заведен!";
    }

    public string Drive()
    {
        return "Мотоцикл едет.";
    }
}


class Boat : Vehicle, ISwim
{
    public override string StartEngine()
    {
        return "Двигатель лодки заведен!";
    }

    public string Swim()
    {
        return "Лодка плывет.";
    }
}

class Tank : Vehicle, IDrive, IRotateTurret, IShoot
{
    public override string StartEngine()
    {
        return "Двигатель танка заведен!";
    }

    public string Drive()
    {
        return "Танк едет.";
    }

    public string RotateTurret()
    {
        return "Танк вращает башней.";
    }

    public string Shoot()
    {
        return "Танк стреляет.";
    }
}

class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car(),
            new Motorcycle(),
            new Boat(),
            new Tank()
        };


        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle.StartEngine());
        }

        foreach (var vehicle in vehicles)
        {
            if (vehicle is IDrive drivable)
            {
                Console.WriteLine(drivable.Drive());
            }
            if (vehicle is IRotateTurret turretRotatable)
            {
                Console.WriteLine(turretRotatable.RotateTurret());
            }
            if (vehicle is IShoot shootable)
            {
                Console.WriteLine(shootable.Shoot());
            }
            if (vehicle is ISwim swimmable)
            {
                Console.WriteLine(swimmable.Swim());
            }
        }
    }
}
