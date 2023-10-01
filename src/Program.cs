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
}

class MyObject : ICloneable
{
    public int id;
    public string size;
    public Color col;

    public MyObject(int id, string size, Color col)
    {
        this.id = id;
        this.size = size;
        this.col = col;
    }

    public object Clone()
    {
        return new MyObject(this.id, this.size, this.col);
    }

    public override string ToString()
    {
        var s = String.Format("id: {0}, size: {1}, color:({2}, {3}, {4})",
            this.id, this.size, this.col.red, this.col.green, this.col.blue);
        return s;
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        //ShallowCopy();
        DeepCopy();

        Console.ReadKey();
        //Console.WriteLine("Hello, World!");
    }

    private static void ShallowCopy()
    {
        var col = new Color(23, 42, 223);
        var obj1 = new MyObject(23, "small", col);

        var obj2 = (MyObject)obj1.Clone();

        obj2.id += 1;
        obj2.size = "big";
        obj2.col.red = 255;

        Console.WriteLine(obj1);
        Console.WriteLine(obj2);
    }

    private static void DeepCopy()
    {
        var col = new Color(23, 42, 223);
        var obj1 = new MyObject(23, "small", col);

        var obj2 = (MyObject)obj1.Clone();

        obj2.id += 1;
        obj2.size = "big";
        obj2.col.red = 255;

        Console.WriteLine(obj1);
        Console.WriteLine(obj2);
    }
}