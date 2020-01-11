using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

public class Example
{
    public static void Main()
    {
        // A simple source for demonstration purposes. Modify this path as necessary.
        string[] files = Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg");
        string newDir = @"C:\Users\Public\Pictures\Sample Pictures\Modified";
        Directory.CreateDirectory(newDir);

        // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
        Parallel.ForEach(files, (currentFile) => 
                                {
                                    // The more computational work you do here, the greater 
                                    // the speedup compared to a sequential foreach loop.
                                    string filename = Path.GetFileName(currentFile);
                                    var bitmap = new Bitmap(currentFile);

                                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    bitmap.Save(Path.Combine(newDir, filename));

                                    // Peek behind the scenes to see how work is parallelized.
                                    // But be aware: Thread contention for the Console slows down parallel loops!!!

                                    Console.WriteLine($"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}");
                                    //close lambda expression and method invocation
                                });


        // Keep the console window open in debug mode.
        Console.WriteLine("Processing complete. Press any key to exit.");
        Console.ReadKey();
    }
}

using System;
					
public class Program
{
	public static void Main()
	{
		Base b = new Derived();
		Derived d = new Derived();
		b.SomeMethod();
		d.SomeMethod();
		
		b.SomeOtherMethod();
		d.SomeOtherMethod();
	}
}
public class Base
{
  public virtual void SomeMethod()
  {
	  Console.WriteLine("Some method in Base");
  }
  public virtual void SomeOtherMethod()
  {
	  Console.WriteLine("Some Other method in Base");
  }
}

public class Derived : Base
{
  public override void SomeMethod()
  {
  	 Console.WriteLine("Some method in Derived");
  }
  public new void SomeOtherMethod()
  {
  	 Console.WriteLine("Some Other method in Derived");
  }
}


using System;
					
public class Program
{
	public static void Main()
	{
		Base b = new Derived();
		Derived d = new Derived();
		
		Console.WriteLine(b.Foo()); // output 5
		Console.WriteLine(b.Bar()); // output 1 (Exposes Derived method even if cast it to base)
		Console.WriteLine(d.Foo()); // output 1
		Console.WriteLine(d.Bar()); // output 1

		Console.WriteLine(b.Foo()); // output 5 <<<-- shadow. 
		//The whole point here is that if you want to use base class method instead of inherited, then use 'new' keyword on the derived class so that it can be hidden.
		Console.WriteLine(b.Bar()); // output 1
	}
}
class Base {
   public int Foo(){ return 5;}
   public virtual int Bar(){return 5;}
}
class Derived : Base{
   public new int Foo() { return 1;}     //shadow
   public override int Bar() {return 1;} //override
}
