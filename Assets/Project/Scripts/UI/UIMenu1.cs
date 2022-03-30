using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIMenu
{
    public delegate void ClickStartEventHandler();
    public delegate void ClickEndEventHandler();
    public delegate void ClickShopEventHandler();

    public static event ClickStartEventHandler ClickStartEvent;
    public static event ClickEndEventHandler ClickEndEvent;
    public static event ClickShopEventHandler ClickShopEvent;
}
