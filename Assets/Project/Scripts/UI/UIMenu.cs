using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        ClickStartEvent?.Invoke();
        ActiveDeactiveMenu();
    }

    public void OnClickShop()
    {
        ClickShopEvent?.Invoke();
        ActiveDeactiveMenu();
    }

    public void OnClickExit()
    {
        ClickEndEvent?.Invoke();
    }

    public void ActiveDeactiveMenu()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
