using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour
{
    public int moveSpeed = 230;
    public float Power;
    public float Radius;
    public GameObject character;
    public Rigidbody2D rb;
    // Update is called once per frame

    private void Start()
    {
        rb = character.GetComponent<Rigidbody2D>();
    
    }


    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(this.gameObject, 5);
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "floor")
        {
            Vector3 bulletPos = transform.position;
            AddExplosionForce(rb, Power * 100, bulletPos, Radius);
            Debug.Log("Ue cade essa merda");
            Destroy(this.gameObject);
            
        }
    }

    public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }

        body.AddForce(dir.normalized * expForce * calc);
    }


}
