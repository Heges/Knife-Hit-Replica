using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//частичка для анимации разлетов,падений аля разрушаемый объект
public class Piece : MonoBehaviour
{
    public Vector3 Direction { get; set; }

    [SerializeField] private float speedFLy;
    [SerializeField] private float speedToque;
    [SerializeField] private Rigidbody2D myBody;
    [SerializeField] private Vector3 vector;
    private CircleRotator rotator;

    public void Active()
    {
        if (myBody == null)
        {
            rotator = GetComponentInParent<CircleRotator>();
            myBody = GetComponent<Rigidbody2D>();
            myBody.bodyType = RigidbodyType2D.Dynamic;
            speedFLy = 16;
            speedToque = 2f;
        }
        if(vector != Vector3.zero)
        {
            Direction = vector - Vector3.zero;
        }
        else
        {
            Direction = rotator.transform.position - transform.position;
        }

        gameObject.SetActive(true);
        StartCoroutine(ActiveEffectBlowUp());
    }

    private IEnumerator ActiveEffectBlowUp()
    {
        transform.parent = null;
        myBody.AddForce(Direction * speedFLy, ForceMode2D.Impulse);
        myBody.AddTorque(45f * speedToque);
        float time = 1f;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
