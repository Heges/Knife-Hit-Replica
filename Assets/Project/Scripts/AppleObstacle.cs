using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleObstacle : Obstacle
{
    public delegate void AppleHitedEventHandler();
    public static AppleHitedEventHandler AppleHitedEvent;

    [SerializeField] private CircleCollider2D myCollider;
    [SerializeField] private List<Piece> pieces;

    public override float OffsetToSpawn()
    {
        return myCollider.bounds.extents.x;
    }

    public void Activate()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if(pieces[i] != null)
                pieces[i].Active();
        }
        Resycle();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edge"))
        {
            AppleHitedEvent?.Invoke();
            Activate();
        }
    }
}
