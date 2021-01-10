using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controller : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        TestEnemy enemy = collision.gameObject.GetComponent<TestEnemy>();
        enemy.take_damage(Config.Instance.gun_damage);
        enemy.update_health();
        Destroy(gameObject);
    }
}
