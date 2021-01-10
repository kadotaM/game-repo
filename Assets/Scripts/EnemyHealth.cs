using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemy;
    private float total_health;
    private RectTransform health_bar;
    private float width;


    // Start is called before the first frame update
    void Start()
    {

        this.total_health = enemy.GetComponent<Enemy>().get_total_health();
        GameObject child = this.gameObject.transform.GetChild(0).gameObject;
        this.width = child.GetComponent<RectTransform>().rect.width;

        this.health_bar = child.GetComponent<RectTransform>();
        Debug.Log(this.health_bar.name);
        StartCoroutine("update_health");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator update_health(){

        Vector2 prev_health = this.health_bar.offsetMax;

        float health = enemy.GetComponent<Enemy>().get_health();
        float conversion = this.width/this.total_health;
        float heal_px = conversion * health;

        float right = this.width - heal_px;

        float new_diff = prev_health.x + right;
        Debug.Log("update_health: " + new_diff + " " + prev_health.x);



        for(float i = 10; i >= 1; i--){
            this.health_bar.offsetMax = new Vector2(prev_health.x - new_diff/i, this.health_bar.offsetMax.y);
            Debug.Log(prev_health.x + " " + new_diff/i);
            yield return new WaitForSeconds(.01f);
        }

        if(health == 0){
            enemy.GetComponent<Enemy>().kill();
        }

    }
}
