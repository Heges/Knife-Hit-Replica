using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotatorRandomizer
{
    private readonly CircleRotatorConfig configRotator;

    public CircleRotatorRandomizer(CircleRotatorConfig r)
    {
        configRotator = r;
    }

    public void GetRandomDirection()
    {
        configRotator.dir = Random.value > 0.5f ? EDirection.Anticlockwise : EDirection.Clockwise;
    }

    public void SwitchDirection()
    {
        if (configRotator.dir == EDirection.Clockwise)
            configRotator.dir = EDirection.Anticlockwise;
        else
            configRotator.dir = EDirection.Clockwise;
    }

    public void IncreaseSpeed()
    {
        var value = configRotator.rotateSpeed + Random.Range(5, 25);
        configRotator.rotateSpeed = (value > CircleRotatorConfig.MIN_SPEED 
            && value < CircleRotatorConfig.MAX_SPEED) 
            ? value 
            : configRotator.rotateSpeed;
    }

    public void DecreaseSpeed()
    {
        var value = configRotator.rotateSpeed - Random.Range(5, 25);
        configRotator.rotateSpeed = (value > CircleRotatorConfig.MIN_SPEED
            && value < CircleRotatorConfig.MAX_SPEED) 
            ? value 
            : configRotator.rotateSpeed;
    }

    public void GetRandomIncreaseDecrease()
    {
        if(Random.value > 0.5f)
        {
            GetRandomDirection();
            IncreaseSpeed();
        }
        else
        {
            GetRandomDirection();
            DecreaseSpeed();
        }
    }

    public void Subscribe()
    {
        Knife.HitEvent += GetRandomIncreaseDecrease;
        Circle.WinEvent += GetRandomIncreaseDecrease;
    }

    public void Unscribe()
    {
        Knife.HitEvent -= GetRandomIncreaseDecrease;
        Circle.WinEvent -= GetRandomIncreaseDecrease;
    }
}
