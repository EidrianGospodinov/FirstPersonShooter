using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;

    public float range = 200f;
    int gunDamage=100;
    public Animator weaponAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponAnimator.GetBool("isShooting"))
        {
            weaponAnimator.SetBool("isShooting", false);
        }

        //gets the shooting from inpuit axes
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        weaponAnimator.SetBool("isShooting", true);
        RaycastHit hit;
        //the raycast shoot form camera position, towards direction forwards, stores whatever has been hit in hit and specify the distance the bullet will travel
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {

            if(hit.collider.tag=="Enemy")
            {
                FindObjectOfType<EnemyManager>().shotAt(gunDamage);
            }

        }
    }
}
