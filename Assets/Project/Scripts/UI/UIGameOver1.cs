using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIGameOver
{
    public delegate void ClickRetryEventHandler();
    public delegate void ClickMenuEventHandler();

    public static event ClickRetryEventHandler ClickRetryEvent;
    public static event ClickMenuEventHandler ClickMenuEvent;
}
