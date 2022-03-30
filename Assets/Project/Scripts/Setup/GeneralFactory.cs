using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Factory/GeneralFactory", menuName = "Factory/GeneralFactory")]
public class GeneralFactory : BaseFactory
{
    [SerializeField] private CircleRotator circleRotater;

    public void Reclaim(CircleRotator obj)
    {
        Destroy(obj.gameObject);
    }

    public CircleRotator Get()
    {
        return CreateInstance(circleRotater);
    }
}
