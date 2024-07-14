using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieScanner
{
    internal class EventHandlers
    {
        internal void OnSpawn(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(Plugin.Instance.Config.CassieDelaySinceRespawn * 1000);
                    Cassie.MessageTranslated(Plugin.Instance.Config.CameraScanAnnouncementCassie,
                        Plugin.Instance.Config.CameraScanAnnouncementText, false, true, true);
                    Scan();

                });
            }
           
        }

        internal void Scan()
        {
            Task.Run(async () =>
            {
                await Task.Delay(Plugin.Instance.Config.CassieDelaySinceAnnouncement * 1000);
                
                if(Exiled.API.Features.Player.List.Any(p => p.Role == RoleTypeId.Scp079) && Plugin.Instance.Config.Is079BlockingCameraScan)
                {
                    Cassie.MessageTranslated(Plugin.Instance.Config.CameraScanFailedCassie,
                    Plugin.Instance.Config.CameraScanFailedText, false, true, true);
                }
                else
                {

                    var message = ReplacePlaceHolders(Plugin.Instance.Config.CameraScanSuccessfulCassie);
                    var text = ReplacePlaceHolders(Plugin.Instance.Config.CameraScanSuccessfulText);
                    Cassie.MessageTranslated($"{message}", $"{text}", false, true, true);
                }
            });
        }

        private string ReplacePlaceHolders(string template)
        {
            string ClassDAlive = Player.Get(RoleTypeId.ClassD).Count().ToString();
            string ScientistsAlive = Player.Get(RoleTypeId.Scientist).Count().ToString();
            string MtfsAlive = Player.Get(Team.FoundationForces).Count().ToString();
            string ScpsAlive = Player.Get(Team.SCPs).Count().ToString();
            string ChaosInsurgencyAlive = Player.Get(Team.ChaosInsurgency).Count().ToString();

            return template
                .Replace("{ClassDAlive}", ClassDAlive)
                .Replace("{ScientistsAlive}", ScientistsAlive)
                .Replace("{MtfsAlive}", MtfsAlive)
                .Replace("{ScpsAlive}", ScpsAlive)
                .Replace("{ChaosInsurgencyAlive}", ChaosInsurgencyAlive);
        }





    }
}
