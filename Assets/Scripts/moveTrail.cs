using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrail : MonoBehaviour
{
    public int moveSpeed = 230;
    public float Power;
    public float Radius;
    public GameObject explosion;
    public Rigidbody2D rb;
    // Update is called once per frame

    private void Start()
    {

    
    }


    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(this.gameObject, 5);
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "floor")
        {
            
            
            Debug.Log("Ue cade essa merda");
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
    }

    


}
