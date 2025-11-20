using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemText;

    private Button button;
    private Image image;
    [SerializeField] private Color selectColor;
    private bool isSelected;
    private Item item;

    private void Start()
    {

        isSelected = false;
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        transform.parent.GetComponent<InverntoryContainer>().OnSelectedSlotChanged += ItemSlot_OnSelectedSlotChanged;
    }

    private void ItemSlot_OnSelectedSlotChanged(object sender, InverntoryContainer.OnSelectedSlotChangeEventArg e)
    {
        Debug.Log("hii");
        image.color = item == e.slot ? Color.gray : Color.black;
    }

    public Button ItemButton()
    {
        return button; 
    }

    public void SetIsSelect(bool val)
    {
        isSelected = val;
        Debug.Log(val);
        if (!isSelected)
        {
            image.color = Color.black;
        }
        else
        {
            image.color = selectColor;
        }
    }

    public void SetItem(Item item)
    {
        this.item = item;
        itemText.text = item.GetItemName();
        
    }

    

    
}
