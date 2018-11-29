using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class MonsterSeed
    {
        private readonly string _path;

        public MonsterSeed()
        {
            _path = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/Monsters/AllMonstersData.txt";
        }

        public void CreateMonster()
        {
            int counter = 0;
            string line;
            int count = 0;
            string query = "INSERT INTO Monsters (ImageUrl, Level, NameKR, Alive, Tame, Experience, Attack, Defence, Fire, Cold, Light, Wind, Holy, Dark, Phantom, BC, Items, Description, MapId) VALUES (";

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(_path);

            using (StreamWriter sw = new StreamWriter(File.Open("N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/AllMonstersInserts.txt", FileMode.Create)))
            {
                while ((line = file.ReadLine()) != null)
                {
                    count++;

                    if (count > 10 * 17)
                    {
                        break;
                    }

                    if (counter > 17)
                    {
                        query += ");";
                        query += Environment.NewLine;

                        sw.Write(query);

                        Console.WriteLine("Query added");

                        query = "INSERT INTO Monsters (ImageUrl, Level, NameKR, Alive, Tame, Experience, Attack, Defence, Fire, Cold, Light, Wind, Holy, Dark, Phantom, BC, Items, Description, MapId) VALUES (";

                        counter = 0;
                    }

                    if (counter == 1)
                    {
                        var split = line.Replace("Lv", "").Replace(".&nbsp", "").Split(';');

                        query = query + "N'" + split[0] + "'" + ", ";
                        query = query + "N'" + split[1] + "'" + ", ";
                    }
                    // mapKR -> id
                    else if (counter == 17)
                    {
                        query = query + "N'" + line + "'";
                    }
                    else
                    {
                        if (line == "-")
                        {
                            line = "0";
                        }

                        query = query + "N'" + line + "'" + ", ";
                    }

                    counter++;
                }

                file.Close();
            }
        }

        public void CreateMonstersString()
        {
            const string sep = "\"";

            int count = 0;
            int fieldIndex = 0;            

            string line;

            var stringBuilder = new StringBuilder();

            using (var streamReader = new StreamReader(_path))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    count++;

                    // This is max index of monster fields
                    if (fieldIndex > 17)
                    {
                        stringBuilder.AppendLine();

                        fieldIndex = 0;

                        Console.WriteLine("Monster added! " + count / 18);
                    }

                    // Separate monster name and level
                    if (fieldIndex == 1)
                    {
                        var splitLevelName = line.Replace("Lv", "").Replace(".&nbsp", "").Split(';');

                        stringBuilder.Append(splitLevelName[0]).Append(sep);
                        stringBuilder.Append(splitLevelName[1]).Append(sep);
                    }
                    else
                    {
                        if (line == "-")
                        {
                            line = "0";
                        }

                        if (fieldIndex == 17)
                        {
                            stringBuilder.Append(line);
                        }
                        else
                        {
                            stringBuilder.Append(line).Append(sep);
                        }
                    }

                    fieldIndex++;
                }
            }

            string path = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/Monsters/AllMonsters.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.AppendAllText(path, stringBuilder.ToString());
        }
    }
}
