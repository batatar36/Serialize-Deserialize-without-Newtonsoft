using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Security.Principal;
using static TypeMerger.EnumClass;
using System.ComponentModel.DataAnnotations;
//using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace TypeMerger
{
    class Program
    {
        static void Main(string[] args)
        {

            Pet1 PetObject = new();
            Car1 carObject = new();

            List<string> pets = new();
            List<string> cars = new();
            List<string> both = new();

            Serialize1 serialize = new();
            Deserialize1 deserialize = new();
            ConsoleWriteLine writeLine = new();

            string? askUserToDerialize;
            string? askObjectType;
            string? answer_from_user;

           

            try
            {
                writeLine.WhichObject();

                askObjectType = Console.ReadLine();

                switch (askObjectType)
                {
                    case "pet":

                        
                        while (true)
                        {
                            if (serialize.numberOfObject == 1)
                            {
                                writeLine.EmptySpace();
                                writeLine.CreateObject();                                
                                answer_from_user = Console.ReadLine();
                                writeLine.EmptySpace();
                            }
                            else
                            {
                                writeLine.EmptySpace();
                                writeLine.OneMoreObject();
                                answer_from_user = Console.ReadLine();
                                writeLine.EmptySpace();
                            }

                            if (answer_from_user == "y")
                            {
                                foreach (PropertyInfo prop in PetObject.GetType().GetProperties())
                                {
                                    writeLine.EmptySpace();
                                    Console.WriteLine($"{prop.Name}: ");

                                    prop.SetValue(PetObject, prop.PropertyType == typeof(string) ? Console.ReadLine() : Convert.ToInt32(Console.ReadLine()));

                                    pets.AddRange(new string[] { prop.GetValue(PetObject).ToString() });
                                }

                                writeLine.EmptySpace();
                                string json1 = serialize.SerializeObject(ref PetObject, pets);

                                Console.WriteLine(json1);
                                writeLine.EmptySpace();

                                writeLine.WannaDeserialize();

                                askUserToDerialize = Console.ReadLine();

                                if (askUserToDerialize == "y")
                                {
                                    writeLine.EmptySpace();
                                    Console.WriteLine(deserialize.DeserializeObject(json1, ref PetObject));
                                }
                            }
                            else
                                break;
                            
                            serialize.numberOfObject++;
                        }
                        
                        break;

                    case "car":

                        while (true)
                        {
                            if (serialize.numberOfObject == 1)
                            {
                                writeLine.EmptySpace();
                                writeLine.CreateObject();
                                answer_from_user = Console.ReadLine();
                                writeLine.EmptySpace();
                            }
                            else
                            {
                                writeLine.EmptySpace();
                                writeLine.OneMoreObject();
                                answer_from_user = Console.ReadLine();
                                writeLine.EmptySpace();
                            }

                            if (answer_from_user == "y")
                            {
                                foreach (PropertyInfo prop in carObject.GetType().GetProperties())
                                {
                                    writeLine.EmptySpace();
                                    Console.WriteLine($"{prop.Name}: ");

                                    prop.SetValue(carObject, Console.ReadLine());

                                    cars.AddRange(new string[] { prop.GetValue(carObject).ToString() });
                                }

                                writeLine.EmptySpace();
                                string json1 = serialize.SerializeObject(ref carObject, cars);
                                Console.WriteLine(json1);

                                writeLine.EmptySpace();

                                writeLine.WannaDeserialize();

                                askUserToDerialize = Console.ReadLine();

                                if (askUserToDerialize == "y")
                                {
                                    writeLine.EmptySpace();
                                    Console.WriteLine(deserialize.DeserializeObject(json1, ref carObject));
                                }
                            }
                            else
                                break;

                            serialize.numberOfObject++;
                        }
                        break;
                        
                    case "both":

                        while (true)
                        {
                            if (serialize.numberOfObject2 == 2)
                            {
                                writeLine.EmptySpace();
                                writeLine.CreateObject();
                                answer_from_user = Console.ReadLine();
                                writeLine.EmptySpace();
                            }
                            else
                            {
                                writeLine.EmptySpace();
                                writeLine.OneMoreObject();
                                answer_from_user = Console.ReadLine();
                                writeLine.EmptySpace();
                            }

                            if (answer_from_user == "y")
                            {
                                foreach (PropertyInfo prop in PetObject.GetType().GetProperties())
                                {
                                    writeLine.EmptySpace();
                                    Console.WriteLine($"{prop.Name}: ");

                                    prop.SetValue(PetObject, prop.PropertyType == typeof(string) ? Console.ReadLine() : Convert.ToInt32(Console.ReadLine()));

                                    both.AddRange(new string[] { prop.GetValue(PetObject).ToString() });                                    
                                }

                                foreach (PropertyInfo prop in carObject.GetType().GetProperties())
                                {
                                    writeLine.EmptySpace();
                                    Console.WriteLine($"{prop.Name}: ");

                                    prop.SetValue(carObject, Console.ReadLine());

                                    both.AddRange(new string[] { prop.GetValue(carObject).ToString() });
                                }
                                
                                writeLine.EmptySpace();
                                string json = serialize.SerializeObject2(ref PetObject, ref carObject, both);
                                Console.WriteLine(json);

                                writeLine.EmptySpace();

                                writeLine.WannaDeserialize();

                                askUserToDerialize = Console.ReadLine();

                                if (askUserToDerialize == "y")
                                {
                                    writeLine.EmptySpace();
                                    Console.WriteLine(deserialize.DeserializeObject2(json, ref PetObject, ref carObject));
                                }
                            }
                            else
                                break;

                            serialize.numberOfObject2 += 2;
                        }                        
                        break;                        
                }
            }
            catch (FormatException)
            {
                writeLine.FormatExceptionAlert();
            }
            catch (ArgumentOutOfRangeException )
            {
                writeLine.ArgumentOutOfRangeException(); 
            }
        }
    }
}