using UnityEngine;

public class GameInfoContainer
{
    public GameScore Score;

    // Start is called before the first frame update
    public GameInfoContainer()
    {
        Score = new GameScore
        {
            Player1 = 0,
            Player2 = 0
        };
    }

    public class GameScore
    {
        public int Player1 { get; set; }
        public int Player2 { get; set; }
    }
}
