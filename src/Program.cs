internal class Program
{
    private static void Main(string[] args)
    {
        var col = new Color(23, 42, 223);
        var car = new Car(23, "small", col);

        var shallowCopy = car.ShallowCopy();
        var deepCopy = car.DeepCopy();

        shallowCopy.id += 1;
        shallowCopy.size = "big";
        shallowCopy.color.red = 656565;

        Console.WriteLine("+==============original=============");
        Console.WriteLine(car.ToString());
        Console.WriteLine("+==============Shallow Copy=============");
        Console.WriteLine(shallowCopy.ToString());
        Console.WriteLine("+============Deep Copy===============");
        Console.WriteLine(deepCopy.ToString());

        Console.ReadKey();
    }
}

#region Objects
class Color
{
    public int red;
    public int green;
    public int blue;

    public Color(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    public Color? ShallowCopy()
    {
        return this.MemberwiseClone() as Color;
    }
}

class Car : ICloneable
{
    public int id;
    public string size;
    public Color color;

    public Car(int id, string size, Color col)
    {
        this.id = id;
        this.size = size;
        this.color = col;
    }

    public Car? ShallowCopy()
    {
        return this.MemberwiseClone() as Car;
    }

    public Car? DeepCopy()
    {
        var deepCopy = this.MemberwiseClone() as Car;
        deepCopy.color = this.color.ShallowCopy() as Color;

        return deepCopy;
    }

    public object Clone()
    {
        return new Car(this.id, this.size, this.color);
    }

    public override string ToString()
    {
        var strings = String.Format("id: {0}, size: {1}, color:({2}, {3}, {4})",
            this.id, this.size, this.color.red, this.color.green, this.color.blue);
        return strings;
    }
}
#endregion Objects