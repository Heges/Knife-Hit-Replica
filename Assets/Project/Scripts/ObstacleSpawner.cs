using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner
{
   private readonly ObstacleFactory factory;
   private readonly ChanseCallculatorConfig spawnConfig;
   private readonly List<Obstacle> obstacleList;
   public ObstacleSpawner(ObstacleFactory f, ChanseCallculatorConfig sConfig)
   {
        factory = f;
        spawnConfig = sConfig;
        obstacleList = new List<Obstacle>(4);
   }

    public void Spawn(int count, Circle circle)
    {
        
        float TAU = 6.283185307179586f;
        List<int> positions = new List<int>();
        //���� ������� � ��������� �� 0 �� ��������� ���������.
        foreach (int pos in spawnConfig.GetNumbersPositionSpawn(count))
        {
            positions.Add(pos);
        }
        //� �������� ��������� �������������� �����������, ��� ��� � ����� ����� �� ����� ���� ������ ��������� ���������
        //�� ������� ����� ������ �������� �� �� ����� ������������
        //��� �� ��������� �� �������� ������� Piece ��� �������� �������/��������, ����� ���� � �� ����������
        // ������ ����� ������������������ �������, �� ������� ���.
        int i = 0;
        foreach (string name in spawnConfig.GetObjectToSpawn(count))
        {
            Obstacle obj = factory.Get(name);
            Transform tr = circle.transform;
            Transform obstTR = obj.transform;

            int value = positions[i++];
            float t = (float) value / spawnConfig.maxCircleSize;
            float angle = t * TAU;

            obstTR.position = new Vector3(tr.position.x + Mathf.Cos(angle) * circle.GetRadius,
                tr.position.y + Mathf.Sin(angle) * circle.GetRadius);

            Vector3 direction = tr.position - obstTR.position;
            obstTR.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            obstTR.position -= direction.normalized * obj.OffsetToSpawn() / 2f;

            Piece piece = obj.gameObject.AddComponent<Piece>();
            circle.AddPiece(piece);
            obstacleList.Add(obj);
            obstTR.SetParent(tr);
        }
    }

    public void Clear()
    {
        foreach (var obst in obstacleList)
        {
            if(obst != null)
                obst.Resycle();
        }
        obstacleList.Clear();
    }
}
