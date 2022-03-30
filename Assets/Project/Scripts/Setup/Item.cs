using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item : ScriptableObject
{
    public string Name => name;
    public string Decription => description;
    public int Cost => cost;
    public Sprite Image => itemImage;

    [SerializeField] protected new string name;
    [SerializeField] protected string description;
    [SerializeField] protected int cost;
    [SerializeField] protected Sprite itemImage;

    protected abstract Item Buy();

}
