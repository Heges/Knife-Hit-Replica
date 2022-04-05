using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public static ViewManager instance;

    [SerializeField] private View[] views;

    private View current;
    private readonly Stack<View> history = new Stack<View>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < views.Length; i++)
        {
            views[i].Initialize();
        }
        Show<MenuView>();
    }

    public static T GetView<T>() where T : View
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                return instance.views[i] as T;
            }
        }
        return null;
    }

    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                if (instance.current != null)
                {
                    if (remember)
                    {
                        instance.history.Push(instance.current);
                    }
                    instance.current.Hide();
                }

                instance.views[i].Show();
                instance.current = instance.views[i];
            }
        }
    }

    public static void Show(View view, bool remember = true)
    {
        if (instance.current != null)
        {
            if (instance.current != null)
            {
                if (remember)
                {
                    instance.history.Push(instance.current);
                }
                instance.current.Hide();
            }
            view.Show();
            instance.current = view;
        }
    }

    public static void ShowLast()
    {
        if (instance.history.Count > 0)
        {
            if (instance.current != null)
            {
                Show(instance.history.Pop());
            }
        }
    }
}
