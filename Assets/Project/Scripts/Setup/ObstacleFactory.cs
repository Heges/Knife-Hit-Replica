using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Factory/GeneralObstacles", menuName = "Factory/ObstacleFactory")]
public class ObstacleFactory : BaseFactory
{
    [SerializeField] private Obstacle obstacleApple;
    [SerializeField] private Obstacle obstacleKnife;

    public Obstacle Get(string name)
    {
        Obstacle obj = null;
        switch (name)
        {
            case "apple":
                 obj = CreateInstance(obstacleApple);
                obj.Factory = this;
                return obj;
            case "knife":
                 obj = CreateInstance(obstacleKnife);
                obj.Factory = this;
                return obj;
            default:
                break;
        }
        return obj;
    }

    public void Reclaim(Obstacle obj)
    {
        Destroy(obj.gameObject);
    }
}
