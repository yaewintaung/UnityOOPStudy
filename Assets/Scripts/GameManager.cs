using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Player player;

    private int currentEnemyCount;

    private void Awake()
    {
        Instance = this;
    }

    public Player GetActivePlayer() => player;

    public void SetEnemyCount(int enemyCount)
    {
        currentEnemyCount = enemyCount;
    }

    public int GetEnemyCouont()
    {
        return currentEnemyCount;
    }
}
