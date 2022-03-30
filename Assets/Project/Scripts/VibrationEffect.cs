using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationEffect
{
    public void Initialize()
    {
        Vibration.Init();
    }

    public void Subscribe()
    {
        Knife.HitEvent += VibrateDeffault;
        Knife.HitHandEvent += VibrateDeffault;
        Circle.WinEvent += VibrateDeffault;
    }

    public void Unscribe()
    {
        Knife.HitEvent -= VibrateDeffault;
        Knife.HitHandEvent -= VibrateDeffault;
        Circle.WinEvent -= VibrateDeffault;
    }

    public void VibrateDeffault()
    {
        Vibration.Vibrate();
    }
}
