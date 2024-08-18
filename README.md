# Coplt.Dropping

[![Nuget](https://img.shields.io/nuget/v/Coplt.Dropping)](https://www.nuget.org/packages/Coplt.Dropping/)
![MIT](https://img.shields.io/github/license/2A5F/Coplt.Dropping)

Auto gen dispose pattern

- Allow multiple drops
- Specify the drop order `[Drop(Order = X)]`
- Mark Drop directly on fields and properties

## Example

- Basic usage
    
    ```cs
    [Dropping]
    public partial class Foo1
    {
        [Drop]
        public void Drop()
        {
            Console.WriteLine(1);
        }
    }
    ```
    
    Generate output:

    <details>
      <summary>Foo1.dropping.g.cs</summary>
    
    ```cs
    // <auto-generated/>
    
    #nullable enable
    
    using Coplt.Dropping;
    
    public partial class Foo1 : global::System.IDisposable
    {
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) Drop();
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        ~Foo1()
        {
            Dispose(false);
        }
    
    }
    ```

    </details>
    <br/>
  
- Unmanaged resources
    
    ```csharp
    [Dropping(Unmanaged = true /* set drop in the class all default is unmanaged */)]
    public partial class Foo2
    {
        [Drop]
        private void Drop()
        {
            Console.WriteLine(1);
        }
    
        [Drop(Unmanaged = false)]
        private void Drop2()
        {
            Console.WriteLine(2);
        }
    }
    ```
    
    Generate output:

    <details>
      <summary>Foo2.dropping.g.cs</summary>

    ```cs
    // <auto-generated/>

    #nullable enable

    using Coplt.Dropping;

    public partial class Foo2 : global::System.IDisposable
    {

        protected virtual void Dispose(bool disposing)
        {
            Drop();
            if (disposing) Drop2();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Foo2()
        {
            Dispose(false);
        }

    }
    ```

    </details>
    <br/>
  

- Inherit

    ```cs
    [Dropping]
    public partial class Foo3 : Foo2
    {
        [Drop]
        private void Drop()
        {
            Console.WriteLine(1);
        }

        [Drop(Unmanaged = true)]
        private void Drop2()
        {
            Console.WriteLine(2);
        }
    }
    ```

    Generate output:

    <details>
      <summary>Foo3.dropping.g.cs</summary>

    ```cs
    // <auto-generated/>

    #nullable enable

    using Coplt.Dropping;

    public partial class Foo3 : global::System.IDisposable
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing) Drop();
            Drop2();
            base.Dispose(disposing);
        }

    }
    ```

    </details>
    <br/>

- Sealed And Struct

    ```cs
    [Dropping]
    public sealed partial class Foo4
    {
        [Drop]
        public void Drop()
        {
            Console.WriteLine(1);
        }
    }

    [Dropping(Unmanaged = true)]
    public sealed partial class Foo5
    {
        [Drop]
        public void Drop()
        {
            Console.WriteLine(1);
        }
    }

    [Dropping]
    public partial struct Foo6
    {
        [Drop]
        private void Drop()
        {
            Console.WriteLine(1);
        }
    }
    ```

    Generate output:

    <details>
      <summary>Foo4.dropping.g.cs</summary>

    ```cs
    // <auto-generated/>

    #nullable enable

    using Coplt.Dropping;

    public partial class Foo4 : global::System.IDisposable
    {

        public void Dispose()
        {
            Drop();
        }

    }
    ```

    </details>

    <details>
      <summary>Foo5.dropping.g.cs</summary>

    ```cs
    // <auto-generated/>

    #nullable enable

    using Coplt.Dropping;

    public partial class Foo5 : global::System.IDisposable
    {

        public void Dispose()
        {
            Drop();
            GC.SuppressFinalize(this);
        }

        ~Foo5()
        {
            Dispose();
        }

    }
    ```

    </details>
    
    <details>
      <summary>Foo6.dropping.g.cs</summary>

    ```cs
    // <auto-generated/>

    #nullable enable

    using Coplt.Dropping;

    public partial struct Foo6 : global::System.IDisposable
    {

        public void Dispose()
        {
            Drop();
        }

    }
    ```

    </details>
    <br/>

