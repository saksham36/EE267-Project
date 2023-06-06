using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour, ITakeDamage
{
    public AudioSource fireSound;

    [SerializeField] float fireDamage = 10;
    [SerializeField] private float fireHealth;
    [SerializeField] private float maxFireHealth = 100;
    [SerializeField] private float regenTime = 5;
    [SerializeField] float healthRegen = 5;

    [SerializeField] float fireLife = 2;

    [SerializeField] private ParticleSystem fireExtinguishFX;

    [SerializeField] bool debug = false;

    // public FireHealthScreen fireHealthScreen;

    private bool isOnFire = true;
    // private float currTime;
    private float regenTimer;


    void Start()
    {   
        fireHealth = 50; //maxFireHealth;
        fireSound = GetComponent<AudioSource>();
        fireSound.Play();
        // currTime = 0;
        regenTimer = 0;

    }
    private void regenHealth()
    {
        fireHealth = Math.Min(fireHealth+healthRegen, maxFireHealth);
    }

    // Update is called once per frame
    void Update()
    {   
        if(isOnFire){
            // Debugging to see fire being extinguished
            // int fH = (int) fireHealth;
            // fireHealthScreen.Setup(fH);

            regenTimer += Time.deltaTime;
            // currTime += Time.deltaTime;
            // Debug.Log("currTime: "+ currTime);
            if(regenTimer >= regenTime){
                regenHealth();
                regenTimer = 0;
            }
            if(fireSound.isPlaying == false)
            {
                fireSound.Play();
            }

            // if(currTime >= fireLife)
            // {
            //     // Debug.Log("Fire Time over, Bye bye");
            //     Destroy(gameObject); // no smoke
            //     GetComponent<Spawner>().decNumFires();
            // }
            if(debug)
            {
                if(Input.GetKeyDown(KeyCode.Space)) 
                {
                    Debug.Log("Space Pressed");
                    TakeDamageDebug();
                }
            }
            
        }
    }

    // void FireCollision(Vector3 contactPoint)
    // {
    //     void OnTriggerEnter(Collider other)
    //     {
    //         // As soon as you collide with fire, take damage and fire extinguishes
    //         other.gameObject.GetComponent<Player>().TakeDamage(fireDamage);
    //         Destroy(gameObject);
    //         ParticleSystem effect = Instantiate(fireExtinguishFX, contactPoint, Quaternion.identity);
    //         effect.Play();
    //         effect.Stop();
    //     }
    // }
    void OnTriggerEnter(Collider other)
    {
        // As soon as you collide with fire, take damage and fire extinguishes
        other.gameObject.GetComponent<Player>().TakeDamage(fireDamage);
        Destroy(gameObject);
    }
    
    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        if(isOnFire)
        {
            fireHealth -= weapon.GetDamage();
            if(fireHealth <= 0)
            {
                isOnFire = false;
                FindObjectOfType<GameManager>().IncreaseScore();
                Destroy(gameObject);
                // GetComponent<Spawner>().decNumFires();
                ParticleSystem effect = Instantiate(fireExtinguishFX, contactPoint, Quaternion.LookRotation(weapon.transform.position - contactPoint));
                effect.Play();
                effect.Stop();
            }
        }
    }

    void TakeDamageDebug()
    {
        if(isOnFire)
        {
            fireHealth -= 20;
            if(fireHealth <= 0)
            {
                isOnFire = false;
                FindObjectOfType<GameManager>().IncreaseScore();
                Destroy(gameObject);
                // GetComponent<Spawner>().decNumFires();
                Vector3 contactPoint =  GameObject.Find("TinyFireDebug").transform.position;
                ParticleSystem effect = Instantiate(fireExtinguishFX, contactPoint, Quaternion.LookRotation(new Vector3(0,0,0)));
                Debug.Log("Play Effect");
                effect.Play();
                effect.Stop();
            }
        }
    }


}
