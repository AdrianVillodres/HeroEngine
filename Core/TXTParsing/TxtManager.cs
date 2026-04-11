using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.TXTParsing
{
    public static class TxtManager
    {
        public static void Write<T>(string path, T obj)
        {
            File.WriteAllText(path, obj?.ToString() ?? string.Empty);
        }

        public static List<T> Read<T>(string path, Func<string, T> parser)
        {
            List<T> list = new List<T>();

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path no valid");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The specified file does not exist.");
            }

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string cleanLine = line.Trim();

                    try
                    {
                        T obj = parser(cleanLine);
                        list.Add(obj);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Error parsing line: {cleanLine}");
                    }
                }
            }

            return list;
        }

        public static void Append<T>(string path, T obj)
        {

            string content = obj?.ToString() ?? string.Empty;


            if (File.Exists(path) && new FileInfo(path).Length > 0)
            {

                File.AppendAllText(path, Environment.NewLine + content);
            }
            else
            {
                File.AppendAllText(path, content);
            }
        }
    }
}
