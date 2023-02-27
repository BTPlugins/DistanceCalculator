using DistanceCalculatorPlugin.Helpers;
using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DistanceCalculatorPlugin.Commands
{
    internal class DistanceCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "Distance";

        public string Help => "Gets the Distance";

        public string Syntax => "Distance";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "DistanceCalculator.Distance" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if(command.Length == 0)
            {
                var look = DamageTool.raycast(new Ray(player.Player.look.aim.position, player.Player.look.aim.forward), 1000, RayMasks.BLOCK_COLLISION);
                if (look == null)
                {
                    DebugManager.SendDebugMessage("Point Not Found | Returning");
                    TranslationHelper.SendMessageTranslation(player.CSteamID, "DistanceToFar");
                    return;
                }
                DebugManager.SendDebugMessage(player.CharacterName + " has checked the Distance!");
                TranslationHelper.SendMessageTranslation(player.CSteamID, "Distance", Math.Round(Vector3.Distance(player.Position, look.point)));
            }
            var target = UnturnedPlayer.FromName(command[0]);
            if(target == null)
            {
                DebugManager.SendDebugMessage("Target Not Found");
                TranslationHelper.SendMessageTranslation(player.CSteamID, "TargetNotFound");
                return;
            }
            DebugManager.SendDebugMessage("Sending Targets Distance");
            var distance = Vector3.Distance(player.Position, target.Position);
            TranslationHelper.SendMessageTranslation(player.CSteamID, "TargetDistance", target.CharacterName, Vector3.Distance(player.Position, target.Position));
        }
    }
}
