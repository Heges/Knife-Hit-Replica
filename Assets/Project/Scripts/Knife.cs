using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class Knife : MonoBehaviour
{
    public KnifeFactory Factory { get; set; }

    [SerializeField] private BoxCollider2D edge;
    [SerializeField] private BoxCollider2D hand;

    private KnifeConfig knifeConfig;
    private bool isPinned;
    private Rigidbody2D rb2D;
    private IEnumerator falling;
    private float fallSpeed = 14f;
    private Vector3 dirToCenterImpact;

    private void Awake()
    {
        isPinned = true;
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Resycle()
    {
        Factory.Reclaim(this);
    }

    public void Initialize(KnifeConfig knifeConf)
    {
        knifeConfig = knifeConf;
        var sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = knifeConfig.currentKnife.Image;
    }

    public void Activate()
    {
        isPinned = false;
    }

    private void FixedUpdate()
    {
        if (!isPinned && falling == null)
        {
            rb2D.MovePosition(rb2D.position + knifeConfig.throwSpeed * Time.deltaTime * Vector2.up);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Hand") && !isPinned)
        {
            if (falling == null)
            {
                edge.enabled = false;
                dirToCenterImpact = collider.transform.position - transform.position;
                StopAllCoroutines();
                falling = LetsFall(fallSpeed);
                StartCoroutine(falling);
            }
        }
        else if (collider.CompareTag("Circle Rotator") && !isPinned && falling == null)
        {
            transform.SetParent(collider.transform);
            
            isPinned = true;

            HitEvent?.Invoke();

            Circle circle = collider.GetComponent<Circle>();

            Piece knifePiece = gameObject.AddComponent<Piece>();
            circle.AddPiece(knifePiece);
            edge.enabled = false;
            this.enabled = false;
        }
    }
    private IEnumerator LetsFall(float time)
    {
        HitHandEvent?.Invoke();
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        rb2D.AddForce(2f * fallSpeed * (Vector2.down * -dirToCenterImpact.normalized));
        rb2D.AddTorque(90f * fallSpeed * Time.deltaTime);

        yield return new WaitForSeconds(time);

        Resycle();
    }
}
