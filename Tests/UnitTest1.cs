using Coplt.Dropping;

namespace Tests;

[Dropping]
public partial class Foo1
{
    [Drop]
    public void Drop()
    {
        Console.WriteLine(1);
    }
}

[Dropping(From = DropFrom.Dispose)]
public partial class Foo2
{
    [Drop]
    public void Drop()
    {
        Console.WriteLine(1);
    }
}

[Dropping(From = DropFrom.Finalizer)]
public partial class Foo3
{
    [Drop]
    public void Drop()
    {
        Console.WriteLine(1);
    }
}

[Dropping(AllowInherit = false)]
public partial class Foo4
{
    [Drop]
    public void Drop()
    {
        Console.WriteLine(1);
    }
}

[Dropping(AllowInherit = false, From = DropFrom.Dispose)]
public partial class Foo5
{
    [Drop]
    public void Drop()
    {
        Console.WriteLine(1);
    }
}

[Dropping(AllowInherit = false, From = DropFrom.Finalizer)]
public partial class Foo6
{
    [Drop]
    public void Drop()
    {
        Console.WriteLine(1);
    }
}

[Dropping]
public partial struct Foo7
{
    [Drop]
    public void Drop()
    {
        Console.WriteLine(1);
    }
}

[Dropping]
public partial class Bar1
{
    [Drop]
    public Foo1 A = new();
    [Drop]
    public Foo2? B;
    [Drop]
    public Foo7? C;
    [Drop]
    public Foo7 D;

    [Drop]
    public void Drop1()
    {
        Console.WriteLine(1);
    }

    [Drop]
    public void Drop2()
    {
        Console.WriteLine(2);
    }
}

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
