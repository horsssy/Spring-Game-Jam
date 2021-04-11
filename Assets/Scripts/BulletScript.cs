using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class BulletScript : MonoBehaviour
{
    public Transform bullets;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            transform.SetParent(bullets);
            transform.localPosition = Vector2.zero;
            gameObject.SetActive(true);
        }

        
    }
    private void OnEnable()
    {
        //print("enabled");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
