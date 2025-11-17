using UnityEngine;

public class PlayerPrefsaveSystem : MonoBehaviour, ISaveSystem
{
    

    public int LoadScore()
    {
        int s = PlayerPrefs.GetInt("Score");
        return s;
    }

    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }
    
}
