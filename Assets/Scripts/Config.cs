using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public float speed;
    public float health;
    public float bullet_speed;
    public float shoot_timer;
    public float gun_damage;

    private static Config _instance;

    public static Config Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject instance = new GameObject("Game Manager");
                instance.AddComponent<Config>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
