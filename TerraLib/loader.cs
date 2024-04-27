using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace TerraLib
{
    class loader
    {
        public void modloader()
        {
            //point the loader where it needs to get it's files
            string modsFolder = "Mods";
            string[] dlls = Directory.GetFiles(modsFolder, "*.dll");

            //message
            Console.WriteLine("Attempting to load ALL dlls from Mods folder...");

            //attempt to load mods
            foreach (string dllFile in dlls)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dllFile);
                    Type[] types = assembly.GetTypes();

                    //find and execute init functions
                    foreach (Type type in types)
                    {
                        MethodInfo method = type.GetMethod("Init", BindingFlags.Static | BindingFlags.Public);
                        if (method != null)
                        {
                            method.Invoke(null, null);
                        }
                        else
                        {
                            Console.WriteLine("Method Null! maybe there's no mods?");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Stubborn DLL: {dllFile}: {ex.Message}");
                }
            }

            //now we attempt to read the inits folder
            string initsFolder = Path.Combine(modsFolder, "inits");
            string[] inits = Directory.GetFiles(initsFolder, "*.txt, *.tmi");

            foreach (string init in inits)
            {
                try
                {
                    string initFunction = File.ReadAllText(init);
                    //execute the function
                    foreach (string dll in dlls)
                    {
                        ExecuteInitFunction(dll, initFunction);
                    }
                    //ExecuteInitFunction(initFunction);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Damn you Kuja!");
                    Console.WriteLine($"Error reading init file {init}: {ex.Message}");
                }
            }
        }

        private void ExecuteInitFunction(string dllFileName, string initFunctionName)
        {
            try
            {
                // Load the DLL
                Assembly assembly = Assembly.LoadFrom(dllFileName);

                // Find the type containing the init function
                Type type = assembly.GetTypes().FirstOrDefault(t => t.GetMethod(initFunctionName) != null);
                if (type != null)
                {
                    // Get the init method
                    MethodInfo method = type.GetMethod(initFunctionName);

                    // Invoke the init method
                    if (method != null)
                    {
                        method.Invoke(null, null);
                        Console.WriteLine($"Init function '{initFunctionName}' executed successfully from {dllFileName}");
                    }
                    else
                    {
                        Console.WriteLine($"Init function '{initFunctionName}' not found in {dllFileName}");
                    }
                }
                else
                {
                    Console.WriteLine($"Type containing init function '{initFunctionName}' not found in {dllFileName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading or executing init function: {ex.Message}");
            }
        }

        private int CountLoadedMods()
        {
            string modsFolder1 = "Mods";
            string[] dllFiles = Directory.GetFiles(modsFolder1, "*.dll");
            return dllFiles.Length;
        }

        //private int modscount()
        //{
            //int loadedModsCount = CountLoadedMods();
            //UpdateModCountText(loadedModsCount);
        //}
        private void modsloaded()
        {
            //alright, unity code here we come!
            //okay nvm, damn you Unity
            Console.WriteLine("Terralib loaded with mods from /mods Directory");
        }
    }
}
