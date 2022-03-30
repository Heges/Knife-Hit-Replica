using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="Config/CircleRotatorConfig", menuName = "Config/CircleRotatorConfig")]
public class CircleRotatorConfig : ScriptableObject
{
    public const float MAX_SPEED = 500f;
    public const float MIN_SPEED = 75f;
    public float rotateSpeed;
    public EDirection dir;
}
