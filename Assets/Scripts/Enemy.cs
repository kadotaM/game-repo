using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Enemy: MonoBehaviour{
    public float health; 
    public float total_health;

    public Enemy(){
    }
    
    public void take_damage(float damage){
        this.health -= damage;
    }

    public void kill(){
        Destroy(this.gameObject);
    }

    public float get_health(){
        return this.health;
    }

    public float get_total_health(){
        return this.total_health;
    }

    abstract public void update_health();

}
