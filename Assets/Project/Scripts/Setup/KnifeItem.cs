using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeffaultKnife", menuName = "Item/Knife")]
public class KnifeItem : Item
{
    protected override Item Buy()
    {
        return this;
    }
}
