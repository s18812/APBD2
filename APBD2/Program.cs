
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace APBD2
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            try
            {
                var enPath = @"C:\Users\jdlus\Desktop\data.csv";
                var resPath = @"C:\Users\jdlus\Desktop\żesult.xml";
                var lastArg = "xml";

                var łogtxt = @"D:\łog.txt";

                if (args.Length == 3)
                {
                    enPath = "@" + args[0];
                    resPath = "@" + args[1];
                    lastArg = args[2];
                }

                var lines = File.ReadAllLines(enPath);

                var uczelnia = new Uczelnia();

                var hash = uczelnia.students;


                if (File.Exists(łogtxt))
                {
                    File.Delete(łogtxt);
                }

                foreach (var line in lines)
                {
                    var splittedLine = line.Split(",");

                    if (splittedLine.Length != 9)
                    {
                        using (StreamWriter writer = new StreamWriter(łogtxt, true))
                        {
                            writer.WriteLine(line);
                        }
                        continue;
                    }

                    foreach (var el in splittedLine)
                    {
                        if (string.IsNullOrWhiteSpace(el) || string.IsNullOrEmpty(el))
                        {
                            using (StreamWriter writer = new StreamWriter(łogtxt, true))
                            {
                                writer.WriteLine(line);
                            }
                            break;
                        }
                    }

                    if (splittedLine.Length == 9)
                    {
                        foreach (var el in splittedLine)
                        {
                            if (!string.IsNullOrEmpty(el) && !string.IsNullOrWhiteSpace(el))
                            {
                                hash.Add(new Student
                                {
                                    idx = splittedLine[4],
                                    imie = splittedLine[0],
                                    nazwisko = splittedLine[1],
                                    birthDate = splittedLine[5],
                                    email = splittedLine[6],
                                    mothersName = splittedLine[7],
                                    fathersName = splittedLine[8],
                                    studies = new Studies
                                    {
                                        studiesName = splittedLine[2],
                                        studiesMode = splittedLine[3]
                                    }
                                });
                            }
                        }
                    }
                }

                if (lastArg == "xml")
                {
                    var serializer = new XmlSerializer(typeof(Uczelnia));

                    var writerr = new FileStream(resPath, FileMode.Create);

                    serializer.Serialize(writerr, uczelnia, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

                }

                else if (lastArg == "json")
                {
                   
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik nazwa nie istnieje");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna");
            }
        }
    }
}
