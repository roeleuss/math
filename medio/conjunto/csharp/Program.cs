using System;

class Program
{
    private static int loop = 0;

    static void Main(string[] args)
    {
        if (args.Length == 0 || !int.TryParse(args[0], out loop)) loop = 150;
        Random rnd = new Random();
        BinarySet set = new BinarySet();
        Populate(rnd, set);
        Count(set);
        Search(rnd, set);
        Remove(rnd, set);
        Count(set);
    }

    private static void Remove(Random rnd, BinarySet set)
    {
        DateTime init = DateTime.Now;
        for (int i = 0; i < loop; i++)
        {
            set.Remove(rnd.Next(loop));
        }
        DateTime end = DateTime.Now;
        Console.WriteLine($"Elapse Time to Try Remove {loop,12} elements: {(end - init).TotalSeconds:F3} seconds");
    }

    private static void Search(Random rnd, BinarySet set)
    {
        DateTime init = DateTime.Now;
        int found = 0;
        for (int i = 0; i < loop; i++)
        {
            if (set.Contains(rnd.Next(loop))) 
            {
                found++;
            }
        }
        DateTime end = DateTime.Now;
        Console.WriteLine($"Elapse Time to Found {found,17} elements: {(end - init).TotalSeconds:F3} seconds");
    }

    private static void Count(BinarySet set)
    {
        DateTime init = DateTime.Now;
        int count = set.Count();
        DateTime end = DateTime.Now;
        Console.WriteLine($"Elapse Time to Count {count,17} elements: {(end - init).TotalSeconds:F3} seconds");
    }

    private static void Populate(Random rnd, BinarySet set)
    {
        DateTime init = DateTime.Now;
        for (int i = 0; i < loop; i++)
        {
            set.Add(new BinaryNode(rnd.Next(loop)));
        }
        DateTime end = DateTime.Now;
        Console.WriteLine($"Elapse Time to Try Populate {loop,10} elements: {(end - init).TotalSeconds:F3} seconds");
    }
}

