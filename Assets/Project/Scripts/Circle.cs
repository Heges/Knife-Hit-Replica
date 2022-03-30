using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//главный антагонист для наших ножей
//служит целью для наших точных бросков
public class Circle : MonoBehaviour
{
    public delegate void WinLevelEventHandler();
    public static event WinLevelEventHandler WinEvent;

    public const int CAPACITY_CIRCLE = 4;

    public float GetRadius
    {
        get
        {
            if (myCollider == null)
                myCollider = GetComponent<CircleCollider2D>();
            return myCollider.radius;
        }
    }

    [SerializeField] private CircleCollider2D myCollider;
    [SerializeField] private List<Piece> pieces;
    [SerializeField] private GameObject mainCircle;
    private int capacity;

    private void Awake()
    {
        capacity = CAPACITY_CIRCLE;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edge"))
        {
            DecreaseCapacity(1);
        }
    }

    public void DecreaseCapacity(int value)
    {
        if(capacity > 0)
            capacity -= value;
        if (capacity <= 0)
            BlowUP();
    }

    private void BlowUP()
    {
        NotifyGameOver();
        mainCircle.gameObject.SetActive(false);
        for(int i = 0; i < pieces.Count; i++)
        {
            if(pieces[i] != null)
            {
                pieces[i].Active();
            }
        }
    }

    public void AddPiece(Piece piece)
    {
        pieces.Add(piece);
    }

    public void NotifyGameOver()
    {
        WinEvent?.Invoke();
    }
}
