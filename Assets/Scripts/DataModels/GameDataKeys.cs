namespace Bounce.EventSystem
{
    public class GameDataKeys
    {
        public static readonly int GameInitialised = KeyGenerator.GetKey();
        public static readonly int HealthUpdated = KeyGenerator.GetKey();
        public static readonly int ObstacleHit = KeyGenerator.GetKey();
        public static readonly int GameOver = KeyGenerator.GetKey();
        public static readonly int Pause = KeyGenerator.GetKey();
        public static readonly int LevelComplete = KeyGenerator.GetKey();
        public static readonly int ScoreUpdated = KeyGenerator.GetKey();
        public static readonly int CoinUpdated = KeyGenerator.GetKey();
        public static readonly int GameStarted = KeyGenerator.GetKey();

    }
}



