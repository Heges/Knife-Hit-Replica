using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Config/KnifeConfig", menuName = "Config/KnifeConfig")]
public class KnifeConfig : ScriptableObject
{
    public const float DELAY_THROW = .55f;
    public float throwSpeed;
    public KnifeItem currentKnife;
    [SerializeField] private ItemData itemData;

    public void SetKnife(string name)
    {
        var knife = itemData.GetKnifeItem(name);
        if (knife != null)
        {
            currentKnife = knife;
        }
    }
}
