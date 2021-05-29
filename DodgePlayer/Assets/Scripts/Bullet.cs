using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody bulletRigidbody;
    public float speed = 8f;

    public int damage = 30;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                player.GetDamage(damage);
                Destroy(gameObject);
                //player.Die();
            }
        }
    }
}
