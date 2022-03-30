using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIManager : MonoBehaviour
{
    public delegate void StartEventHandler();
    public delegate void EndEventHandler();

    public static event StartEventHandler StartEvent;
    public static event EndEventHandler EndEvent;
}
