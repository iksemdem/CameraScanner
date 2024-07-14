using System;
using System.ComponentModel;
using Exiled.API;
using Exiled.API.Interfaces;
using Microsoft.Win32;

namespace CharlieScanner
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Should camera scan be failed when there is SCP-079 player?")]
        public bool Is079BlockingCameraScan = true;
        [Description("Time since Chaos Respawn, to the CASSIE announcement about a camera scan.")]
        public int CassieDelaySinceRespawn = 5;
        [Description("Time since first announcement, to the camera scan result CASSIE announcement.")]
        public int CassieDelaySinceAnnouncement = 5;
        [Description("The content of cassie message about a camera scan.")]
        public string CameraScanAnnouncementCassie = "attention all personnel . unauthorized personnel detected inside the facility . initializing a full camera scan . standby for up dates .";
        [Description("The content of text message about a camera scan.")]
        public string CameraScanAnnouncementText = "Attention all personnel. Unauthorized personnel detected inside the facility. Initializing a full camera scan. Standby for updates";
        [Description("The content of cassie message about camera scan result successful.")]
        public string CameraScanSuccessfulCassie = "camera scan complete . remaining class d personnel . {ClassDAlive} . remaining scientists . {ScientistsAlive} . remaining M T F units . {MtfsAlive} . remaining SCPs . {ScpsAlive} . remaining chaosinsurgency . {ChaosInsurgencyAlive} . noscpsleft";
        [Description("The content of text message about camera scan result successful.")]
        public string CameraScanSuccessfulText = "Camera scan complete. Remaining Class D personnel: {ClassDAlive}. Remaining scientists: {ScientistsAlive}. Remaining MTF units: {MtfsAlive}. Remaining SCPs: {ScpsAlive}. Remaining Chaos Insurgency: {ChaosInsurgencyAlive}";
        [Description("The content of cassie message about camera scan result failed.")]
        public string CameraScanFailedCassie = "do to unspecified anomalys camera scan cannot be executed at this time . noscpsleft";
        [Description("The content of text message about camera scan result failed.")]
        public string CameraScanFailedText = "Due to unspecified anomalies, camera scan cannot be executed at this time";

    }
}
