using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeObstacle : Obstacle
{
    [SerializeField] private BoxCollider2D myCollider;

    public override float OffsetToSpawn()
    {
        return myCollider.bounds.max.y;
    }
}
