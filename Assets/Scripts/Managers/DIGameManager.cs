
public class DIGameManager
{
    private IScoreSystem scoreSystem;
    private ISaveSystem saveSystem;
    private IAudioSystem audioSystem;

    public DIGameManager(IScoreSystem score,ISaveSystem save,IAudioSystem audio)
    {
        scoreSystem = score;
        saveSystem = save;
        audioSystem = audio;
    }

    public void AddPlayerScore(int score)
    {
        scoreSystem.AddScore(score);
        audioSystem.PlaySoud();

        saveSystem.SaveScore(score);
    }



}
