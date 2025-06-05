using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using HiddenLibrary;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj ścieżkę do zestawu (DLL lub EXE):");

        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Nie podano ścieżki.");
            return;
        }
        string assemblyPath = input;

        if (!File.Exists(assemblyPath))
        {
            Console.WriteLine("Plik nie istnieje.");
            return;
        }

        Assembly assembly = Assembly.LoadFrom(assemblyPath);

        var allTypes = assembly.GetTypes().Where(t => t.IsClass && !t.GetCustomAttributes(false).Any(attr => attr.GetType().FullName == "HiddenLibrary.HiddenAttribute"));


        var hierarchy = new Dictionary<Type, List<Type>>();
        var rootTypes = new List<Type>();

        foreach (var type in allTypes)
        {
            Type? baseType = type.BaseType;
            if (baseType != null)
            {
                if (baseType != null && allTypes.Contains(baseType))
                {
                    if (!hierarchy.ContainsKey(baseType))
                        hierarchy[baseType] = new List<Type>();

                    hierarchy[baseType].Add(type);
                }
                else
                {
                    rootTypes.Add(type);
                }
            }
        }

        void PrintTree(Type type, string indent)
        {
            Console.WriteLine(indent + type.FullName);
            if (hierarchy.ContainsKey(type))
            {
                foreach (var child in hierarchy[type])
                {
                    PrintTree(child, indent + "  ");
                }
            }
        }

        if (rootTypes.Count == 0)
        {
            Console.WriteLine("Brak klas do wyświetlenia.");
            return;
        }

        foreach (var root in rootTypes)
        {
            PrintTree(root, "");
        }

        //Console.ReadLine();
    }
}
