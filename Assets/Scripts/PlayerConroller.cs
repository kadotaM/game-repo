using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float health;
    public GameObject bullet;
    public float bullet_speed;
    public float shoot_timer;
    private bool can_shoot;
    

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.can_shoot = true;
        InvokeRepeating("change_shoot", 0, shoot_timer);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            if(this.can_shoot){
                shoot();
                this.can_shoot = false;
            }
        }
    }

    void shoot()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        Vector3 shoot_direction = worldPosition-gameObject.transform.position;
        shoot_direction.z = 0;

        Vector3 bullet_start = this.transform.position + shoot_direction.normalized;
        Debug.Log("shoot direction:" + shoot_direction.ToString());
        GameObject new_bullet = Instantiate<GameObject>(bullet, bullet_start, Quaternion.LookRotation(Vector3.back, shoot_direction));
        Debug.Log(shoot_direction);
        //Destroy(new_bullet, 1);
        new_bullet.GetComponent<Rigidbody2D>().velocity += new Vector2(shoot_direction.x, shoot_direction.y).normalized * bullet_speed;
    }

    void FixedUpdate()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        
        Vector2 movement = new Vector2 (x, y);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        this.rb.velocity += movement * speed;
        
    }

    void change_shoot(){
        this.can_shoot = true;
    }
}
