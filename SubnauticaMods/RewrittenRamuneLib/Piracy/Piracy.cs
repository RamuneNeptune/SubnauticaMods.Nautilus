

namespace RamuneLib
{
    public static partial class Piracy
    {
        public static readonly HashSet<string> HelloDecompiler = new() {
            @"                         ⠀⠀⠀⠀⠀⠀⠀ ⢀⣶⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⠿⠟⠛⠻⣿⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣆⣀⣀⠀⣿⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠻⣿⣿⣿⠅⠛⠋⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢼⣿⣿⣿⣃⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣟⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣛⣛⣫⡄⠀⢸⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⣾⡆⠸⣿⣿⣿⡷⠂⠨⣿⣿⣿⣿⣶⣦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣾⣿⣿⣿⣿⡇⢀⣿⡿⠋⠁⢀⡶⠪⣉⢸⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⡏⢸⣿⣷⣿⣿⣷⣦⡙⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣇⢸⣿⣿⣿⣿⣿⣷⣦⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀
                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣵⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⡁
            ",

            @"
                                      We're no strangers to love
                                    You know the rules and so do I
                                A full commitment's what I'm thinking of
                                You wouldn't get this from any other guy

                                 I just wanna tell you how I'm feeling
                                     Gotta make you understand

                                      Never gonna give you up
                                      Never gonna let you down
                                 Never gonna run around and desert you
                                       Never gonna make you cry
                                       Never gonna say goodbye
                                  Never gonna tell a lie and hurt you

                                  We've known each other for so long
                                    Your heart's been aching, but
                                       You're too shy to say it
                                Inside, we both know what's been going on
                                 We know the game and we're gonna play it

                                   And if you ask me how I'm feeling
                                 Don't tell me you're too blind to see

                                       Never gonna give you up
                                      Never gonna let you down
                                 Never gonna run around and desert you
                                       Never gonna make you cry
                                       Never gonna say goodbye
                                  Never gonna tell a lie and hurt you

                                       Never gonna give you up
                                      Never gonna let you down
                                 Never gonna run around and desert you
                                       Never gonna make you cry
                                       Never gonna say goodbye
                                  Never gonna tell a lie and hurt you

                                        (Ooh, give you up)
                                        (Ooh, give you up)
                                Never gonna give, never gonna give
                                          (Give you up)
                                Never gonna give, never gonna give
                                          (Give you up)

                                 We've known each other for so long
                                   Your heart's been aching, but
                                     You're too shy to say it
                              Inside, we both know what's been going on
                               We know the game and we're gonna play it

                                I just wanna tell you how I'm feeling
                                     Gotta make you understand

                                       Never gonna give you up
                                      Never gonna let you down
                                 Never gonna run around and desert you
                                       Never gonna make you cry
                                       Never gonna say goodbye
                                  Never gonna tell a lie and hurt you

                                       Never gonna give you up
                                      Never gonna let you down
                                 Never gonna run around and desert you
                                       Never gonna make you cry
                                       Never gonna say goodbye
                                  Never gonna tell a lie and hurt you

                                       Never gonna give you up
                                      Never gonna let you down
                                 Never gonna run around and desert you
                                       Never gonna make you cry
                                       Never gonna say goodbye
                                  Never gonna tell a lie and hurt you
            "
        };


        public static readonly List<string> Targets = new() {
            "steam_api64.cdx", "steam_api64.ini", "steam_emu.ini",
            "Torrent-Igruha.Org.URL", "oalinst.exe", "account_name.txt",
            "valve.ini", "chuj.cdx", "SteamUserID.cfg", "Achievements.bin",
            "steam_settings", "user_steam_id.txt", "Free Steam Games Pre-installed for PC.url", 
        };


        public static bool Exists()
        {
            if(GameObject.Find("IsPirated"))
            {
                LoggerUtils.LogInfo(">> Ahoy matey!");
                return true;
            }

            if(GameObject.Find("IsClean"))
            {
                LoggerUtils.LogInfo(">> Piracy was not detected");
                return false;
            }

            // This ensures we don't run the file check if another mod has already done so

            var directory = Directory.GetFiles(Environment.CurrentDirectory);
            var filenames = directory.Select(_ => Path.GetFileName(_));

            foreach(var filename in filenames)
            {
                if(Targets.Contains(filename))
                {
                    new GameObject("IsPirated");
                    Core.HackTheMainframe();
                    return true;
                }
            }

            LoggerUtils.LogInfo(">> Piracy was not detected");
            new GameObject("IsClean");

            return false;
        }
    }
}