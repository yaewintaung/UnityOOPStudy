using UnityEngine;

public interface ISaveSystem
{
    public void SaveScore(int score);
    public int LoadScore();
}
