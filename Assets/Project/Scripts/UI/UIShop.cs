using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShop : MonoBehaviour
{
    public delegate void ClickMenuEventHandler();
    public static event ClickMenuEventHandler ClickMenuEvent;

    private const string BUY = "Buy";
    private const string EQUIP = "Equip";

    [SerializeField] private List<UIShopSlot> slots;
    [SerializeField] private ItemData itemData;
    [SerializeField] private KnifeConfig knifeConfig;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private TMP_Text appleCount;

    private UIShopSlot activeSlot;

    private void OnEnable()
    {
        PlayerData.ChangeAppleEvent += UpdateShopCurrency;
        //форс апдейт
        appleCount.text = GameManager.Player.GetApples().ToString();
        buttonText.text = BUY;

        for (int i = 0; i < itemData.GetData.Count; i++)
        {
            if(i < slots.Count)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].SetIcon(itemData.GetData[i].Image);
                slots[i].ObjectName = itemData.GetData[i].Name;
                slots[i].Cost = itemData.GetData[i].Cost;
                slots[i].OnHovered += Hover;

                if (GameManager.Player.Contains(itemData.GetData[i].Name))
                {
                    slots[i].Sold();
                }
            }
            else
            {
                slots[i].gameObject.SetActive(false);
                slots[i].UnSold();
                slots[i].OnHovered -= Hover;
            }
        }
    }

    private void OnDisable()
    {
        PlayerData.ChangeAppleEvent -= UpdateShopCurrency;
    }

    public void UpdateShopCurrency(int value)
    {
        appleCount.text = value.ToString();
    }

    public void ActivateDeactivate()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
        activeSlot?.UnHover();
        activeSlot = null;
    }

    private void Hover(UIShopSlot hoverSlot)
    {
        if (hoverSlot.Solded)
        {
            buttonText.text = EQUIP;
        }
        else
        {
            buttonText.text = BUY;
        }

        if(activeSlot == null)
        {
            activeSlot = hoverSlot;
            activeSlot.Hover();
        }
        else
        {
            activeSlot.UnHover();
            activeSlot = hoverSlot;
            activeSlot.Hover();
        } 
    }

    public void OnClickBuy()
    {
        if(activeSlot != null)
        {
            if (GameManager.Player.Contains(activeSlot.ObjectName))
            {
                GameManager.Player.SetKnife(activeSlot.ObjectName);
                Debug.LogWarning("ВЫБРАЛИ");
            }
            else if (activeSlot.Cost <= GameManager.Player.GetApples() && !activeSlot.Solded)
            {
                GameManager.Player.BuyItem(activeSlot.Cost);
                GameManager.Player.SetKnife(activeSlot.ObjectName);
                activeSlot.Sold();
                activeSlot.UnHover();
            }
            else
            {
                Debug.LogWarning("WE CANT! DONT ENOGH MONEY");
            }
        }
    }

    public void OnClickMenu()
    {
        ClickMenuEvent?.Invoke();
        ActivateDeactivate();
    }
}
