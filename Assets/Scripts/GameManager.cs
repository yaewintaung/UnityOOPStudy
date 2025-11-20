using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private DIGameManager diGameManager;

    [SerializeField] private Player player;
    [SerializeField] private IScoreSystem scoreSystem;
    [SerializeField] private IAudioSystem audioSystem;
    [SerializeField] private ISaveSystem saveSystem;

    private int currentEnemyCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        diGameManager = new(scoreSystem,saveSystem,audioSystem);
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
