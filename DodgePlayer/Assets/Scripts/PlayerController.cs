using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float speed = 8f;

    public int hp = 100;
    public HPBar hpbar;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
    }

    void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        if(hp<=0)
        {
            Die();
        }
    }
}
