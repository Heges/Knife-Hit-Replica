using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHUD : MonoBehaviour
{
    [SerializeField] private List<Image> icons;

    private Color active;
    private Color inActive;
    private int index;

    private void Awake()
    {
        active = Color.green;
        inActive = Color.gray;
    }

    private void OnEnable()
    {
        SetHUD();
        Knife.HitEvent += Hited;
        GameManager.GameRetryEvent += GameRetry;
        Knife.HitHandEvent += Hited;
    }

    private void OnDisable()
    {
        ResetHUD();
        Knife.HitEvent -= Hited;
        GameManager.GameRetryEvent -= GameRetry;
        Knife.HitHandEvent -= Hited;
    }

    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

    private void Hited()
    {
        for(int i = index; i >= 0; i--)
        {
            if (icons[i].isActiveAndEnabled && icons[i].color == active)
            {
                icons[i].color = inActive;
                index = i - 1;
                return;
            }
        }
    }
    private void GameRetry()
    {
        ResetHUD();
        SetHUD();
    }

    private void SetHUD()
    {
        for (int i = 0; i < Circle.CAPACITY_CIRCLE; i++)
        {
            icons[i].gameObject.SetActive(true);
            icons[i].color = active;
        }
        index = Circle.CAPACITY_CIRCLE;
    }

    private void ResetHUD()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].gameObject.SetActive(false);
        }
        index = 0;
    }
}
