namespace steam_id_convertor
{
    public static class SteamIdConvertor
    {
        private const string steamID = "STEAM_0:1:77972697";
        private const string steamID3 = "[U:1:155945395]";
        private const ulong steamID64 = 76561198116211123;
        private const ulong hzId = 76561197960265728;

        public static void Main()
        {
            Console.WriteLine($"SteamID: {steamID}");
            Console.WriteLine($"Результат из Айди64: {GetSteamIdFrom64(steamID64)}");
            Console.WriteLine($"Результат из Айди3: ");
            Console.WriteLine("======================================");
            Console.WriteLine($"SteamID64: {steamID64}");
            Console.WriteLine($"Результат из Айди3: ");
            Console.WriteLine($"Результат из Айди: {GetSteamId64FromId(steamID)}");
            Console.WriteLine("======================================");
            Console.WriteLine($"SteamID3: {steamID3}");
            Console.WriteLine($"Результат из Айди64: ");
            Console.WriteLine($"Результат из Айди: {GetSteamId3FromId(steamID)}");
        }

        private static string GetSteamIdFrom64(ulong id64)
        {
            var idNumber = 0;
            var time64 = id64-hzId;

            if (id64 % 2 != 0)
            {
                idNumber = 1;
                time64++;
            }
            var steamReturn = $"STEAM_0:{idNumber}:{time64 / 2}";

            return steamReturn;
        }

        private static ulong GetSteamId64FromId(string id)
        {
            var s = id.Split(':');

            if (!ulong.TryParse(s[2], out var s2) || !ulong.TryParse(s[1], out var s1)) return 0;
            
            var steamReturn = s2 * 2 + hzId + s1;
            return steamReturn;

        }
        
        private static string GetSteamId3FromId(string id)
        {
            var s = id.Split(':');

            if (!ulong.TryParse(s[2], out var s2) || !ulong.TryParse(s[1], out var s1)) return "null";
            
            var steam3 = s2 * 2 + s1;
            var steamReturn = $"[U:1:{steam3}]";
            return steamReturn;

        }
    }
}