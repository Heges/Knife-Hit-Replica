using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : View
{
    public override void Initialize()
    {
        
    }

    public void OnClickStart()
    {
        ViewManager.Show<GameView>();
    }

    public void OnClickShop()
    {
        ViewManager.Show<ShopView>();
    }

    public void OnClickExit()
    {
        Debug.Log("EXIT");
    }
}
