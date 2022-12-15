namespace uhlig.game.domain.Util
{
    public static class Characters
    {
        public const string a_z = "abcdefghijklmnopqrstuvwxyz";
        public const string A_Z = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string numbers = "0123456789";

        public static string AllCharacters() => $"{numbers}{a_z}{A_Z}";

        public static char GetRandonChar()
        {
            var rand = new Random();
            var chars = AllCharacters();
            var i = rand.Next(0, chars.Length - 1);
            return chars[i];
        }
    }
}
