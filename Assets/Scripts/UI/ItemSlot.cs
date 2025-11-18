using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemText;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        
    }

    public Button ItemButton()
    {
        return button; 
    }

    public void SetItem(Item item)
    {
        Debug.Log(item.GetItemName());
        itemText.text = item.GetItemName();
        
    }

    

    
}
