using Rocket.API;
using System.Collections.Generic;

namespace SkillCapper
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool AutoMaxskillsAdmins;
        public List<RoleSkillInfo> RoleSkillInfos;

        public void LoadDefaults()
        {
            AutoMaxskillsAdmins = true;
            RoleSkillInfos = new List<RoleSkillInfo>()
            {
                new RoleSkillInfo()
                {
                    Permission = "skillset.farmer",
                    Priority = 10,
                    AgricultureSkill = 2
                }
            };
        }
    }

    public class RoleSkillInfo
    {
        public string Permission;
        public int Priority;

        public byte AgricultureSkill;
        public byte CardioSkill;
        public byte CookingSkill;
        public byte CraftingSkill;
        public byte DexeritySkill;
        public byte DivingSkill;
        public byte EngineerSkill;
        public byte ExerciseSkill;
        public byte FishingSkill;
        public byte HealingSkill;
        public byte ImmunitySkill;
        public byte MechanicSkill;
        public byte OutdoorsSkill;
        public byte OverkillSkill;
        public byte ParkourSkill;
        public byte SharpshooterSkill;
        public byte SneakybeakySkill;
        public byte StrengthSkill;
        public byte SurvivalSkill;
        public byte ToughnessSkill;
        public byte VitalitySkill;
        public byte WarmbloodedSkill;
    }

    //public class OffenseSpeciality
    //{
    //    public byte OverkillSkill;
    //}
    //
    //public class OffenseSkills
    //{
    //    public static byte[] Get()
    //    {
    //        return 
    //    }
    //}
}
