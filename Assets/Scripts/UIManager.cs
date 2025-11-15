using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject RtoReloadText;
    [SerializeField] private Image HealBar;



    private void Awake()
    {
        Instance = this;
    }
    
    

    private void Start()
    {
        GameManager.Instance.GetActivePlayer().OnPlyerHealthUpdate += Player_OnPlayerHealthUpdate;
        HealBar.fillAmount = GameManager.Instance.GetActivePlayer().GetCurrentHealth() / GameManager.Instance.GetActivePlayer().GetMaxHealth();
    }

    private void Player_OnPlayerHealthUpdate(object sender, Player.OnPlyerHealthUpdateEventArgs e)
    {
        HealBar.fillAmount = e.playerHealth / GameManager.Instance.GetActivePlayer().GetMaxHealth();
    }



    public void ShowRToReload()
    {
        RtoReloadText.SetActive(true);
        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2f);
        RtoReloadText.SetActive(false);

    }
}
