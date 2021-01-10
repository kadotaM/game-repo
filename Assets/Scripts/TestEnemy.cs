using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    public GameObject health_gameobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void update_health(){
        StartCoroutine(health_gameobject.GetComponent<EnemyHealth>().update_health());
    }
}
