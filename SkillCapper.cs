using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Skills;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using Rocket.Core.Logging;
using Rocket.API;
using System.Threading.Tasks;
using SDG.Unturned;

namespace SkillCapper
{
    public class SkillCapper : RocketPlugin<Configuration>
    {
        public static SkillCapper instance = null;

        protected override void Load()
        {
            instance = this;

            U.Events.OnPlayerConnected += PlayerConnected;
        }

        public async Task SetPlayerSkills(UnturnedPlayer uplayer, RoleSkillInfo uskilli)
        {
            await Task.Run(() =>
            {
                uplayer.SetSkillLevel(UnturnedSkill.Agriculture, uskilli.AgricultureSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Cardio, uskilli.CardioSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Cooking, uskilli.CookingSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Crafting, uskilli.CraftingSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Dexerity, uskilli.DexeritySkill);
                uplayer.SetSkillLevel(UnturnedSkill.Diving, uskilli.DivingSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Engineer, uskilli.EngineerSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Exercise, uskilli.ExerciseSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Fishing, uskilli.FishingSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Healing, uskilli.HealingSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Immunity, uskilli.ImmunitySkill);
                uplayer.SetSkillLevel(UnturnedSkill.Mechanic, uskilli.MechanicSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Outdoors, uskilli.OutdoorsSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Overkill, uskilli.OverkillSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Parkour, uskilli.ParkourSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Sharpshooter, uskilli.SharpshooterSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Sneakybeaky, uskilli.SneakybeakySkill);
                uplayer.SetSkillLevel(UnturnedSkill.Strength, uskilli.StrengthSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Survival, uskilli.SurvivalSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Toughness, uskilli.ToughnessSkill);
                uplayer.SetSkillLevel(UnturnedSkill.Vitality, uskilli.VitalitySkill);
                uplayer.SetSkillLevel(UnturnedSkill.Warmblooded, uskilli.WarmbloodedSkill);
            });
            
            //Player player = uplayer.Player;
            //CSteamID csid = uplayer.CSteamID;
            //player.skills.tellSkills(csid, 0, uskilli.AgricultureSkill);
        }

        private async Task FindPlayerSkillgroups(UnturnedPlayer uplayer)
        {
            await Task.Run(async () =>
            {
                //Logger.Log($"Skillgroup function for the player {uplayer.DisplayName} is running.");

                IRocketPlayer rplayer = (IRocketPlayer)uplayer;
                if (rplayer.IsAdmin)
                {
                    if(Configuration.Instance.AutoMaxskillsAdmins)
                    {
                        uplayer.MaxSkills();
                    }
                    return;
                }

                int lastpriority = -1;
                foreach (RoleSkillInfo uskilli in Configuration.Instance.RoleSkillInfos)
                {
                    if (rplayer.HasPermission(uskilli.Permission) && lastpriority < uskilli.Priority)
                    {
                        await SetPlayerSkills(uplayer, uskilli);
                        lastpriority = uskilli.Priority;
                    }
                }
            });
        }

        private void PlayerConnected(UnturnedPlayer uplayer)
        {
            FindPlayerSkillgroups(uplayer);
        }
    }
}
