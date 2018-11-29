using MirWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MirWebAPI.Data
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedMapTypes()
        {
            var mapTypes = GenerateMapTypes();

            foreach (var mapType in mapTypes)
            {
                _dataContext.MapTypes.Add(mapType);
            }

            _dataContext.SaveChanges();
        }
        
        private ICollection<MapType> GenerateMapTypes()
        {
            var mapTypes = new Collection<MapType>();

            var mapTypesDataPath = "N:/vs2017-workspace/MirWebAPI/MirWebAPI/Data/SeedData/AllMapTypes.txt";
            var mapTypesData = File.ReadAllText(mapTypesDataPath);

            using (StringReader reader = new StringReader(mapTypesData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var mapType = new MapType();
                    var fields = line.Split('"');

                    mapType.LevelRange = fields[0];
                    mapType.Description = fields[1];
                    mapType.DescriptionKR = fields[2];

                    var mapNames = fields[3].Split('%');

                    foreach (var mapName in mapNames)
                    {
                        var map = _dataContext.Maps.Where(m => m.NameKR.Equals(mapName))
                                                    .FirstOrDefault();

                        if (mapType.Maps == null)
                        {
                            mapType.Maps = new Collection<Map>();
                        }

                        mapType.Maps.Add(map);
                    }

                    mapTypes.Add(mapType);
                }
            }

            return mapTypes;
        }

        public void SeedMaps()
        {
            var maps = GenerateMaps();

            foreach (var map in maps)
            {
                _dataContext.Maps.Add(map);
            }

            _dataContext.SaveChanges();
        }

        private ICollection<Map> GenerateMaps()
        {
            var maps = new Collection<Map>();

            var mapDataPath = "N:/vs2017-workspace/MirWebAPI/MirWebAPI/Data/SeedData/AllMaps.txt";
            var mapData = File.ReadAllText(mapDataPath);

            using (StringReader reader = new StringReader(mapData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var map = new Map();
                    var fields = line.Split('"');

                    map.NameKR = fields[0];
                    map.Description = fields[1];
                    map.LastUpdate = GetDateTimeFromString(fields[2]);

                    maps.Add(map);
                }
            }

            return maps;
        }

        private DateTime GetDateTimeFromString(string dateString)
        {
            var dateTime = dateString.Replace("오후", "PM")
                                        .Replace("오전", "AM")
                                        .Replace("[게임정보 갱신일 : ", "")
                                        .Replace(" ]", "");

            if (String.IsNullOrEmpty(dateTime) || dateTime.Equals("]"))
            {
                return DateTime.Now;
            }
            else
            {
                return DateTime.ParseExact(dateTime, "yyyy-MM-dd tt h:mm:ss", CultureInfo.InvariantCulture);
            }
        }

        public void SeedMonsters()
        {
            var monsters = GenerateMonsters();

            foreach (var monster in monsters)
            {
                _dataContext.Monsters.Add(monster);
            }

            _dataContext.SaveChanges();
        }

        private ICollection<Monster> GenerateMonsters()
        {
            var monsters = new Collection<Monster>();

            var monsterDataPath = "N:/vs2017-workspace/MirWebAPI/MirWebAPI/Data/SeedData/AllMonsters.txt";
            var monsterData = File.ReadAllText(monsterDataPath);

            using (StringReader reader = new StringReader(monsterData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var monster = new Monster();
                    var fields = line.Split('"');                    
                     
                    monster.NameKR          = fields[2];
                    monster.Level           = fields[1];
                    monster.ImageUrl        = fields[0];
                    monster.Alive           = fields[3];
                    monster.Tame            = fields[4];
                    monster.Experience      = fields[5];
                    monster.Attack          = fields[6];
                    monster.Defence         = fields[7];
                    monster.Fire            = fields[8];
                    monster.Cold            = fields[9];
                    monster.Light           = fields[10];
                    monster.Wind            = fields[11];
                    monster.Holy            = fields[12];
                    monster.Dark            = fields[13];
                    monster.Phantom         = fields[14];
                    monster.BC              = fields[15];
                    monster.Items           = fields[16];
                    monster.Description     = fields[17];
                    monster.MapId           = GetMapIdFromNameKR(fields[18]);

                    monsters.Add(monster);
                }
            }

            return monsters;
        }

        public void SeedNpcs()
        {
            var npcs = GenerateNpcs();

            foreach (var npc in npcs)
            {
                _dataContext.Npcs.Add(npc);
            }

            _dataContext.SaveChanges();
        }

        private ICollection<Npc> GenerateNpcs()
        {
            var npcs = new Collection<Npc>();

            var npcDataPath = "N:/vs2017-workspace/MirWebAPI/MirWebAPI/Data/SeedData/AllNpcs.txt";
            var npcData = File.ReadAllText(npcDataPath);

            using (StringReader reader = new StringReader(npcData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var npc = new Npc();
                    var fields = line.Split('"');
                    
                    var tempTitle = "";
                    var tempNameKR = "";

                    if (fields[2].Contains("]"))
                    {
                        var bracketIndex = fields[2].IndexOf(']');

                        tempTitle = fields[2].Substring(0, bracketIndex + 1);
                        tempNameKR = fields[2].Substring(bracketIndex + 1, fields[2].Length - 1 - bracketIndex);
                    }
                    else
                    {
                        tempNameKR = fields[2];
                    }

                    npc.ImageUrl = fields[1];
                    npc.Title = tempTitle;
                    npc.NameKR = tempNameKR;
                    npc.Quest = fields[4];
                    npc.Description = fields[3];
                    npc.Location = fields[5];
                    npc.Explanation = fields[6];

                    npc.MapId = GetMapIdFromNameKR(fields[0]);

                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        public void SeedFloors()
        {
            var floors = GenerateFloors();

            foreach (var floor in floors)
            {
                _dataContext.Floors.Add(floor);
            }

            _dataContext.SaveChanges();
        }

        private ICollection<Floor> GenerateFloors()
        {
            var floors = new Collection<Floor>();

            var floorDataPath = "N:/vs2017-workspace/MirWebAPI/MirWebAPI/Data/SeedData/AllFloors.txt";
            var floorData = File.ReadAllText(floorDataPath);

            using (StringReader reader = new StringReader(floorData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var floor = new Floor();
                    var fields = line.Split('"');

                    floor.ImageUrl = fields[1];
                    floor.NameKR = fields[2];
                    floor.Description = fields[3];
                    floor.MapId = GetMapIdFromNameKR(fields[0]);

                    floors.Add(floor);
                }
            }

            return floors;
        }

        public void SeedRoles()
        {
            var roles = GenerateRoles();

            foreach (var role in roles)
            {
                _dataContext.Roles.Add(role);
            }

            _dataContext.SaveChanges();
        }

        private ICollection<Role> GenerateRoles()
        {
            var roles = new Collection<Role>();

            var roleDataPath = "N:/vs2017-workspace/MirWebAPI/MirWebAPI/Data/SeedData/AllRoles.txt";
            var roleData = File.ReadAllText(roleDataPath);

            using (StringReader reader = new StringReader(roleData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var role = new Role();
                    var fields = line.Split('"');

                    role.Name = fields[0];
                    role.NameKR = fields[1];
                    role.ImageUrl = fields[2];
                    role.Description = fields[3];

                    roles.Add(role);
                }
            }

            return roles;
        }

        public void SeedSkills()
        {
            var skills = GenerateSkills();

            foreach (var skill in skills)
            {
                _dataContext.Skills.Add(skill);
            }

            _dataContext.SaveChanges();
        }

        private ICollection<Skill> GenerateSkills()
        {
            var skills = new Collection<Skill>();

            var skillDataPath = "N:/vs2017-workspace/MirWebAPI/MirWebAPI/Data/SeedData/AllSkills.txt";
            var skillData = File.ReadAllText(skillDataPath);

            using (StringReader reader = new StringReader(skillData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var skill = new Skill();
                    var fields = line.Split('"');

                    skill.NameKR = fields[2];
                    skill.IconUrl = fields[3];
                    skill.Type = fields[1];
                    skill.Consumption = fields[5];
                    skill.Training = fields[6];
                    skill.Explanation = fields[7];
                    skill.SkillUrl = fields[4];

                    var roleName = fields[0];

                    skill.RoleId = GetRoleIdFromName(roleName);

                    skills.Add(skill);
                }
            }

            return skills;
        }

        public void SeedQuests()
        {
            var quests = GenerateQuests();

            foreach (var quest in quests)
            {
                _dataContext.Quests.Add(quest);
            }

            _dataContext.SaveChanges();
        }

        private ICollection<Quest> GenerateQuests()
        {
            var quests = new Collection<Quest>();

            var questDataPath = "N:/vs2017-workspace/MirWebAPI/MirWebAPI/Data/SeedData/AllQuests.txt";
            var questData = File.ReadAllText(questDataPath);

            using (StringReader reader = new StringReader(questData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var quest = new Quest();
                    var fields = line.Split('"');

                    quest.NameKR = fields[2];
                    quest.IconUrl = fields[1];
                    quest.Type = fields[0];
                    quest.Role = fields[3];
                    quest.Condition = fields[4];
                    quest.Reward = fields[5];
                    quest.PrecedingQuest = fields[6];
                    quest.StartLocation = fields[7];
                    quest.CompleteLocation = fields[8];
                    quest.Description = fields[9];

                    quests.Add(quest);
                }
            }

            return quests;
        }

        private int GetMapIdFromNameKR(string mapNameKR)
        {
            return _dataContext.Maps.Where(m => m.NameKR == mapNameKR).FirstOrDefault().Id;
        }

        private int GetRoleIdFromName(string roleName)
        {
            return _dataContext.Roles.Where(r => r.Name == roleName).FirstOrDefault().Id;
        }
    }
}
