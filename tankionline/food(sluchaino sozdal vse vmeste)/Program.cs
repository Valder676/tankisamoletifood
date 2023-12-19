using System;
using System.Collections.Generic;


interface IHot
{
    string ServeHot();
}

interface ICold
{
    string ServeCold();
}

interface IVegetarian
{
    string ServeVegetarian();
}

interface IMeatDish
{
    string ServeMeat();
}


abstract class Food
{
    public string Name { get; }

    protected Food(string name)
    {
        Name = name;
    }

    public abstract string Consume();
}


class Soup : Food, IHot
{
    public Soup(string name) : base(name) { }

    public override string Consume()
    {
        return $"Вы едите горячий суп {Name}.";
    }

    public string ServeHot()
    {
        return $"Суп {Name} подается горячим.";
    }
}


class Salad : Food, ICold
{
    public Salad(string name) : base(name) { }

    public override string Consume()
    {
        return $"Вы едите свежий салат {Name}.";
    }

    public string ServeCold()
    {
        return $"Салат {Name} подается холодным.";
    }
}


class Steak : Food, IHot, IMeatDish
{
    public Steak(string name) : base(name) { }

    public override string Consume()
    {
        return $"Вы наслаждаетесь стейком {Name}.";
    }

    public string ServeHot()
    {
        return $"Стейк {Name} подается горячим.";
    }

    public string ServeMeat()
    {
        return $"Стейк {Name} - блюдо из мяса.";
    }
}

class CanteenProgram
{
    static void Main()
    {
        List<Food> menu = new List<Food>
        {
            new Soup("Борщ"),
            new Salad("Цезарь"),
            new Steak("Рибай")
        };

        foreach (var dish in menu)
        {
            Console.WriteLine(dish.Consume());

            if (dish is IHot hotDish)
            {
                Console.WriteLine(hotDish.ServeHot());
            }
            if (dish is ICold coldDish)
            {
                Console.WriteLine(coldDish.ServeCold());
            }
            if (dish is IVegetarian vegetarianDish)
            {
                Console.WriteLine(vegetarianDish.ServeVegetarian());
            }
            if (dish is IMeatDish meatDish)
            {
                Console.WriteLine(meatDish.ServeMeat());
            }
        }
    }
}
