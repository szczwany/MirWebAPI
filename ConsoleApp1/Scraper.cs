using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Scraper
    {
        private static readonly HttpClient client = new HttpClient();

        //public static void GetMapParameters()
        //{
        //    string path = @"N:\vs2017-workspace\MirApp\MirApp.scraper\MirApp.scraper\bin\Debug\html.txt";
        //    string readText = File.ReadAllText(path);

        //    var htmlText = new HtmlDocument();
        //    htmlText.LoadHtml(readText);

        //    var nodes = htmlText.DocumentNode
        //        .SelectNodes("//a");

        //    using (StreamWriter sw = new StreamWriter(File.Open("monsterParams.txt", FileMode.Create)))
        //    {
        //        foreach (var node in nodes)
        //        {
        //            var mapName = node.InnerText;

        //            var parameters = node.GetAttributeValue("onClick", "").Replace("getGameInfoList(", "");
        //            parameters = parameters.Substring(0, parameters.IndexOf(")") + 1).Replace(")", "");

        //            sw.WriteLine(String.Format("{0},{1}", mapName, parameters));
        //        }
        //    }
        //}

        public static void ScrapeMaps()
        {
            Console.WriteLine("Maps Scraping!");

            string paramsPath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/MapParams.txt";
            string savePath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/AllMapsData.txt";

            StreamReader file = new StreamReader(paramsPath);
            string line;
            int count = 0;
            int sites = 1;

            var sb = new StringBuilder();

            while ((line = file.ReadLine()) != null)
            {
                count++;

                if (count > 15)
                {
                    // reak;
                }

                var lines = line.Replace("\"", string.Empty).Split(',');

                // map name
                sb.AppendLine(lines[0]);

                var content = new Content(lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7], lines[8])
                                .GetContent();

                var response = GetHtmlResponseAsync("http://mir3.mironline.co.kr/info/get_info_list.asp", content);
                var result = response.Result;

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(result);

                var node = htmlDocument.DocumentNode
                    .SelectSingleNode("//span[@name='setContsLastUp']");
                
                // map description
                sb.AppendLine(node.InnerText);

                Console.WriteLine("Scraped " + sites++);
            }

            file.Close();

            using (StreamWriter sw = new StreamWriter(File.Open(savePath, FileMode.Create)))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        public static void ScrapeMonsters()
        {
            Console.WriteLine("Monsters Scraping!");

            string paramsPath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/MonsterParams.txt";
            string savePath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/AllMonstersData.txt";

            StreamReader file = new StreamReader(paramsPath);
            string line;
            // int count = 0;
            int sites = 1;
            
            var sb = new StringBuilder();

            while ((line = file.ReadLine()) != null)
            {
                // count++;
                // 
                // if (count != 32)
                // {
                //     continue;
                // }

                var lines = line.Replace("\"",string.Empty).Split(',');

                var mapKR = lines[0];

                var content = new Content(lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7], lines[8])
                                .GetContent();

                var response = GetHtmlResponseAsync("http://mir3.mironline.co.kr/info/get_info_list.asp", content);
                var result = response.Result;

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(result);

                var nodes = htmlDocument.DocumentNode
                    .SelectNodes("//td");

                var index = 0;

                foreach (var node in nodes)
                {
                    if (index > 17)
                    {
                        index = 0;
                    }

                    if (index != 0)
                    {
                        if (index == 1)
                        {
                            var temp = node.SelectSingleNode("img");

                            if (temp != null)
                            {
                                sb.AppendLine(temp.GetAttributeValue("src", ""));
                            }
                            else
                            {
                                sb.AppendLine();
                            }
                        }
                        else
                        {
                            sb.AppendLine(node.InnerText);
                        }
                    }

                    index++;

                    if (index == 18)
                    {
                        sb.AppendLine(mapKR);
                    }
                }
                
                Console.WriteLine("Scraped " + sites++);
            }

            file.Close();

            using (StreamWriter sw = new StreamWriter(File.Open(savePath, FileMode.Create)))
            {
                sw.WriteLine(sb.ToString());     
            }
        }

        public static void ScrapeNpcs()
        {
            Console.WriteLine("Npc Scraping!");

            string paramsPath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/data.txt";
            string savePath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/Npcs/AllNpcsData.txt";

            StreamReader file = new StreamReader(paramsPath);
            string line;
            int count = 0;
            int sites = 1;

            var sb = new StringBuilder();

            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("Npc"))
                {
                    continue;
                }

                count++;
                
                if (count == 160000)
                {
                    continue;
                }

                var data = line.Split(',');
                var mapKR = data[1];                

                if (data[2] != null)
                {
                    sb.Append(GetNpc(data[2], mapKR));
                }

                if (data.Length > 3)
                {
                    sb.Append(GetNpc(data[3], mapKR));
                }

                Console.WriteLine("Scraped " + sites++);
            }

            file.Close();

            using (StreamWriter sw = new StreamWriter(File.Open(savePath, FileMode.Create)))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        private static string GetNpc(string data, string mapKR)
        {
            var sb = new StringBuilder();

            var lines = data.Replace("a=", "").Replace("d1=", "").Replace("d2=", "").Replace("d3=", "").Replace("d4=", "").Replace("s=", "").Replace("t=", "").Replace("p=", "")
                .Split('&');

            var content = new Content(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7])
                            .GetContent();

            var response = GetHtmlResponseAsync("http://mir3.mironline.co.kr/info/get_info_list.asp", content);
            var result = response.Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(result);

            var nodes = htmlDocument.DocumentNode  
                .SelectNodes("//td[contains(@class, 'center')]");

            var index = 0;

            if (nodes == null)
            {
                return "";
            }

            foreach (var node in nodes)
            {
                if (index > 5)
                {
                    sb.AppendLine();

                    index = 0;
                }

                if (index == 0)
                {
                    sb.Append(mapKR).Append('"');

                    var temp = node.SelectSingleNode("img");

                    if (temp != null)
                    {
                        sb.Append(temp.GetAttributeValue("src", "")).Append('"');
                    }
                    else
                    {
                        sb.Append("").Append('"');
                    }
                }
                else
                {
                    sb.Append((node.InnerHtml).Replace("<br>", " ")).Append('"');
                }

                index++;
            }

            sb.AppendLine();

            return sb.ToString();
        }

        public static void ScrapeFloors()
        {
            Console.WriteLine("Floor Scraping!");

            string paramsPath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/data.txt";
            string savePath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/Floors/AllFloorsData.txt";

            StreamReader file = new StreamReader(paramsPath);
            string line;
            int count = 0;
            int sites = 1;

            var sb = new StringBuilder();

            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("Map") || !line.Contains("a="))
                {
                    continue;
                }

                count++;

                if (count == 50005)
                {
                    continue;
                }

                var data = line.Split(',');
                var mapKR = data[1];

                sb.Append(GetFloor(data[2], mapKR));                
                
                Console.WriteLine("Scraped " + sites++);
            }

            file.Close();

            using (StreamWriter sw = new StreamWriter(File.Open(savePath, FileMode.Create)))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        private static string GetFloor(string data, string mapKR)
        {
            var sb = new StringBuilder();

            var lines = data.Replace("a=", "").Replace("d1=", "").Replace("d2=", "").Replace("d3=", "").Replace("d4=", "").Replace("s=", "").Replace("t=", "").Replace("p=", "")
                .Split('&');

            var content = new Content(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7])
                            .GetContent();

            var response = GetHtmlResponseAsync("http://mir3.mironline.co.kr/info/get_info_list.asp", content);
            var result = response.Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(result);

            var nodes = htmlDocument.DocumentNode
                .SelectNodes("//td[contains(@class, 'center')]");

            var index = 0;

            if (nodes == null)
            {
                return "";
            }

            foreach (var node in nodes)
            {
                if (index > 3)
                {
                    sb.AppendLine();

                    index = 0;
                }

                if (index == 1)
                {
                    sb.Append(mapKR).Append('"');

                    var temp = node.SelectSingleNode("img");

                    if (temp != null)
                    {
                        sb.Append(temp.GetAttributeValue("src", "")).Append('"');
                    }
                    else
                    {
                        sb.Append("").Append('"');
                    }
                }
                else if (index == 0)
                {

                }
                else
                {
                    sb.Append(node.InnerText).Append('"');
                }

                index++;
            }

            sb.AppendLine();

            return sb.ToString();
        }

        private static async Task<string> GetHtmlResponseAsync(string url, FormUrlEncodedContent content)
        {
            var response = await client.PostAsync(url, content);

            Console.WriteLine("Response with code: " + response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
        
        public static void ScrapeSkills()
        {
            Console.WriteLine("Skill Scraping!");

            string paramsPath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/data.txt";
            string savePath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/Skills/AllSkillsData.txt";

            StreamReader file = new StreamReader(paramsPath);
            string line;
            int count = 0;
            int sites = 1;

            var sb = new StringBuilder();

            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("Skills") || !line.Contains("a="))
                {
                    continue;
                }

                count++;

                if (count > 1231231)
                {
                    continue;
                }

                var data = line.Split(',');
                var role = data[0];
                var type = data[1];

                sb.Append(GetSkill(data[3], role, type));

                Console.WriteLine("Scraped " + sites++);
            }

            file.Close();

            using (StreamWriter sw = new StreamWriter(File.Open(savePath, FileMode.Create)))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        private static string GetSkill(string data, string role, string type)
        {
            var sb = new StringBuilder();

            var lines = data.Replace("a=", "").Replace("d1=", "").Replace("d2=", "").Replace("d3=", "").Replace("d4=", "").Replace("s=", "").Replace("t=", "").Replace("p=", "")
                .Split('&');

            var content = new Content(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7])
                            .GetContent();

            var response = GetHtmlResponseAsync("http://mir3.mironline.co.kr/info/get_info_list.asp", content);
            var result = response.Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(result);
            
            var nodes = htmlDocument.DocumentNode
                .SelectNodes("//td[contains(@class, 'center')]");

            var names = htmlDocument.DocumentNode
                .SelectNodes("//td[contains(@class, 'f_orange5')]");

            var index = 0;
            var count = 0;

            if (nodes == null)
            {
                return "";
            }

            foreach (var node in nodes)
            {
                if (index > 3)
                {     
                    sb.AppendLine();

                    index = 0;
                    count++;
                }

                if (index == 0)
                {
                    sb.Append(role).Append('"');
                    sb.Append(type).Append('"');

                    var name = names[count].InnerText.Replace("\t", "");

                    sb.Append(name).Append('"');

                    //var images = htmlDocument.DocumentNode
                    //    .SelectNodes($"//img[contains(@alt, '{name}')]");

                    if (name.Contains("]"))
                    {
                        var indexOf = name.IndexOf(']');

                        name = name.Substring(indexOf + 1, name.Length - 1 - indexOf);
                    }      
                    
                    if (name.StartsWith(" "))
                    {
                        name = name.Substring(1, name.Length - 1);
                    }

                    var images = htmlDocument.DocumentNode
                        .SelectNodes($"//img[@alt[contains(., '{name}')]]");
                    
                    
                    foreach (var image in images)
                    {
                        if (image != null)
                        {
                            sb.Append(image.GetAttributeValue("src", "")).Append('"');
                        }
                        else
                        {
                            sb.Append("").Append('"');
                        }   
                    }
                }
                else
                {
                    var text = node.InnerText.Replace("\r", "");

                    sb.Append(text).Append('"');
                }

                index++;
            }

            sb.AppendLine();

            return sb.ToString();
        }

        public static void ScrapeQuests()
        {
            Console.WriteLine("Quest Scraping!");

            string paramsPath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/questData.txt";
            string savePath = "N:/vs2017-workspace/MirWebApi/ConsoleApp1/Data/Quests/AllQuestsData.txt";

            StreamReader file = new StreamReader(paramsPath);
            string line;
            int sites = 1;

            var sb = new StringBuilder();

            while ((line = file.ReadLine()) != null)
            {
                var data = line.Split(',');
                var type = data[0];

                //if (type == "Normal")
                //{
                //    continue;
                //}

                sb.Append(GetQuest(data[1], type));

                Console.WriteLine("Scraped " + sites++);
            }

            file.Close();

            using (StreamWriter sw = new StreamWriter(File.Open(savePath, FileMode.Create)))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        private static string GetQuest(string data, string type)
        {
            var sb = new StringBuilder();

            var lines = data.Replace("a=", "").Replace("d1=", "").Replace("d2=", "").Replace("d3=", "").Replace("d4=", "").Replace("s=", "").Replace("t=", "").Replace("p=", "")
                .Split('&');

            var content = new Content(lines[0], lines[1], lines[2], lines[3], lines[4], lines[5], lines[6], lines[7])
                            .GetContent();

            var response = GetHtmlResponseAsync("http://mir3.mironline.co.kr/info/get_info_list.asp", content);
            var result = response.Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(result);

            var nodes = htmlDocument.DocumentNode
                .SelectNodes("//td[contains(@class, 'center')]");

            var images = htmlDocument.DocumentNode
                .SelectNodes("//img[contains(@width, '50')]");

            var index = 0;
            var count = 0;

            if (nodes == null)
            {
                return "";
            }

            foreach (var node in nodes)
            {
                if (index > 8)
                {
                    sb.AppendLine();

                    index = 0;
                    count++;
                }

                if (index == 0)
                {
                    sb.Append(type).Append('"');

                    var image = images[count].GetAttributeValue("src", "");

                    if (image != null)
                    {
                        sb.Append(image).Append('"');
                    }
                    else
                    {
                        sb.Append("").Append('"');
                    }
                }
                else if (index == 1)
                {
                    var text = node.InnerHtml.Replace("<br>", " ");

                    if (text.Contains("/"))
                    {
                        text = text.Substring(0, text.IndexOf('/') - 1);

                        text = text.Replace("=\"\"", "");
                    }

                    sb.Append(text).Append('"');

                    if (type != "Normal")
                    {
                        sb.Append('"');
                        index++;
                    }
                }
                else if (index == 3)
                {
                    var text = node.InnerHtml.Replace("<br>", "/");

                    sb.Append(text).Append('"');
                }                   
                else if (index == 8)
                {
                    var text = node.InnerHtml.Replace("<br>", " ");

                    sb.Append(text).Append('"');
                }
                else
                {
                    var text = node.InnerText.Replace("\r", "");

                    if (text.Contains("[퀘스트보상 내역]"))
                    {
                        text = text.Replace("\t\t\t\t\t\t", "").Replace("\t\t\t", "/");
                    }

                    text.Replace("\t", "");

                    sb.Append(text).Append('"');
                }

                index++;
            }

            sb.AppendLine();

            return sb.ToString();
        }
    }
}
