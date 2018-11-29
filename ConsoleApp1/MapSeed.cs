using System;
using System.Globalization;
using System.IO;

namespace ConsoleApp1
{
    public class MapSeed
    {
        private readonly string _path;

        public MapSeed()
        {
            _path = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/Maps/AllMapsData.txt";
        }

        public void CreateMapInserts()
        {
            string line;

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(_path);

            using (StreamWriter sw = new StreamWriter(File.Open("N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/AllMapsInserts.txt", FileMode.Create)))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length == 0)
                    {
                        continue;
                    }

                    string query = "INSERT INTO Maps (NameKR, Description, LastUpdate) VALUES (";

                    var lines = line.Split('%');

                    var nameKR = lines[0];
                    var description = lines[1];
                    var dateString = lines[2].Replace("오후", "PM").Replace("오전", "AM").Replace("[게임정보 갱신일 : ", "").Replace(" ]", "");

                    DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd tt h:mm:ss", CultureInfo.InvariantCulture);

                    string format = "yyyy-MM-dd HH:mm:ss";

                    query += "N'" + nameKR + "',";
                    query += "N'" + description + "',";
                    query += "'" + date.ToString(format) + "'";

                    query += ");";
                    query += Environment.NewLine;

                    sw.Write(query);

                    Console.WriteLine("Query added");
                }

                file.Close();

                Console.WriteLine("Finished");
            }
        }
    }
}
