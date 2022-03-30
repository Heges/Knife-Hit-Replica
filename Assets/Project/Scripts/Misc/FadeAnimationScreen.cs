using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimationScreen : MonoBehaviour
{
    public bool TransitionOver { get; set; }

    [SerializeField] private Animator transition;

    private IEnumerator fade;

    public void Subscribe()
    {
        GameManager.FadeTransitionEvent += Fade;
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        GameManager.FadeTransitionEvent -= Fade;
    }

    public void Fade()
    {
        if(fade == null)
        {
            gameObject.SetActive(true);
            TransitionOver = false;
            fade = ActiveFade();
            StartCoroutine(fade);
        }
    }

    public IEnumerator ActiveFade()
    {
        yield return new WaitForSeconds(1f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        fade = null;
    }
}
