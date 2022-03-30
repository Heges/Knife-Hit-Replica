using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "FactoryKnifes", menuName = "Factory/KnifeFactory")]
public class KnifeFactory : BaseFactory
{
    [SerializeField] private Knife prefub;
    [SerializeField] private KnifeConfig knifeConfig;

    public Knife Get()
    {
        Knife knife = CreateInstance(prefub);
        knife.Factory = this;
        knife.Initialize(knifeConfig);
        return knife;
    }

    public void Reclaim(Knife obj)
    {
        Destroy(obj.gameObject);
    }
}
