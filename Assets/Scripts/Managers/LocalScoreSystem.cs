using UnityEngine;

public class LocalScoreSystem : MonoBehaviour, IScoreSystem
{
    private int PlayerScore;
    public void AddScore(int score)
    {
        PlayerScore = score;
    }

    public int GetScore(int score)
    {
        return PlayerScore;
    }
}
