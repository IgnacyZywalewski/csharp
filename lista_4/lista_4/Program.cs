using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Security.AccessControl;

class Program
{
    static void Main()
    {
        Console.Write("Ścieżka do DLL: ");
        string? path = Console.ReadLine();

        if (!File.Exists(path))
        {
            Console.WriteLine("Plik nie istnieje.");
            return;
        }

        Assembly assembly = Assembly.LoadFrom(path);

        var classes = assembly.GetTypes().Where(t => t.IsClass && !HasHiddenAttribute(t)).ToList();

        Dictionary<Type, List<Type>> tree = new();
        List<Type> roots = new();

        foreach (var c in classes)
        {
            var baseClass = c.BaseType;
            if (baseClass != null && classes.Contains(baseClass))
            {
                if (!tree.ContainsKey(baseClass))
                {
                    tree[baseClass] = new();
                }
                tree[baseClass].Add(c);
            }
            else roots.Add(c);
        }

        foreach (var r in roots)
        {
            PrintTree(r, "", tree);
        }
    }

    static bool HasHiddenAttribute(Type type)
    {
        return type.GetCustomAttributes(false).Any(attr => attr.GetType().Name == "HiddenAttribute");
    }

    static void PrintTree(Type t, string space, Dictionary<Type, List<Type>> tree)
    {
        Console.WriteLine(space + t.Name);
        if (tree.TryGetValue(t, out var children))
        {
            foreach (var c in children)
            {
                PrintTree(c, space + "  ", tree);
            }
        }
    }
}