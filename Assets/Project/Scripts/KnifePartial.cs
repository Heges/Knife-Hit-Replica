using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Knife
{
    public delegate void HitHandEventHandler();
    public delegate void HitKnifeEventHandler();
    
    public static HitHandEventHandler HitHandEvent;
    public static event HitKnifeEventHandler HitEvent;
}
