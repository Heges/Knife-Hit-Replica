using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public ObstacleFactory Factory { get; set; }
    public abstract float OffsetToSpawn();

    public void Resycle()
    {
        Factory.Reclaim(this);
    }
}
