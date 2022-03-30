using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName ="Item/ItemData")]
public class ItemData : ScriptableObject
{
    public List<KnifeItem> GetData => listKnifeItems;

    [SerializeField] private List<KnifeItem> listKnifeItems;

    public KnifeItem GetKnifeItem(string name)
    {
        if (listKnifeItems == null || listKnifeItems.Count < 0)
            return null;

        foreach (KnifeItem item in listKnifeItems)
        {
            if (item.Name == name)
                return item;
        }
        return null;
    }
}
