using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KnifeSpawner
{
    private readonly KnifeFactory factory;
    private Knife activeKnife;
    private readonly Vector2 spawnPoint;
    private readonly List<Knife> allKnifes;

    public KnifeSpawner(KnifeFactory knifeFactory, Vector2 sP)
    {
        factory = knifeFactory;
        spawnPoint = sP;
        allKnifes = new List<Knife>(27);
    }

    public void Subscribe()
    {
        Knife.HitEvent += ResetActiveKnife;
        Circle.WinEvent += ResetLastActiveKnife;
    }

    public void Unscribe()
    {
        Knife.HitEvent -= ResetActiveKnife;
        Circle.WinEvent -= ResetLastActiveKnife;
    }

    //��� �������� ������� ���� ��� ������ ����
    public void CreateFirstInstance()
    {
        Process();
    }

    public Knife Process()
    {
        if (activeKnife == null)
        {
            activeKnife = factory.Get();
            activeKnife.transform.position = spawnPoint;
        }
        return activeKnife;
    }

    private void ResetActiveKnife()
    {
        //��������� � ���� � ���������� �������� ��� ��� ����� ���������
        allKnifes.Add(activeKnife);
        activeKnife = null;
        Process();
    }

    public void Clear()
    {
        Unscribe();
        foreach (var knife in allKnifes)
        {
            if(knife != null)
                knife.Resycle();
        }
        
        ResetLastActiveKnife();

        allKnifes.Clear();
    }

    private void ResetLastActiveKnife()
    {
        //���������� ��������� �������� ��� ��� ���������� ����
        if (activeKnife != null)
        {
            activeKnife.Resycle();
            activeKnife = null;
        }
    }
}
