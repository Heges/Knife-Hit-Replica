using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    public Action<ShopSlot> OnHovered;
    public string ObjectName { get; set; }
    public int Cost { get; set; }
    public bool Solded { get; private set; }

    [SerializeField] private Image background;
    [SerializeField] private Image icon;
    [SerializeField] private Image soldIcon;

    private Color hover;
    private Color standart;

    private void Awake()
    {
        hover = Color.red;
        standart = background.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnHovered?.Invoke(this);
    }

    public void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public void Hover()
    {
        background.color = hover;
    }

    public void UnHover()
    {
        background.color = standart;
    }

    public void Sold()
    {
        soldIcon.gameObject.SetActive(true);
        Solded = true;
    }
    public void UnSold()
    {
        soldIcon.gameObject.SetActive(false);
        Solded = false;
    }
}
