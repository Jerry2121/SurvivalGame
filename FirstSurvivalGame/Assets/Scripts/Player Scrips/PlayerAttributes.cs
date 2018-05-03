using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    //Attributres
    public float maxHunger, maxThirst, maxStamina, maxColdness;
    public float hunger, thirst, stamina, coldness;

    private bool running;
    private bool triggeringCampFire;

    void Start()
    {
        stamina = maxStamina;
    }

    void Update()
    {
        if(hunger < maxHunger)
            hunger += 1 * Time.deltaTime;

        if (thirst < maxThirst)
            thirst += 1 * Time.deltaTime;

        if (hunger >= maxHunger || thirst >= maxThirst)
        
            Die();

            if (Input.GetKey(KeyCode.LeftShift ) && stamina > 0 )
                stamina -= 10 * Time.deltaTime;

        if (stamina <= 0) ;

        if (triggeringCampFire && coldness > 0)
        {
            coldness -= 1 * Time.deltaTime;
        }

        if(triggeringCampFire == false)
        {
            coldness += 1 * Time.deltaTime;
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            hunger = hunger - 25;
            Destroy(other.gameObject);
        }
    
        if(other.tag == "Water")
        {
            thirst = thirst - 25;
            Destroy(other.gameObject);
        }

        if(other.tag == "CampFire")
        {
            triggeringCampFire = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CampFire")
        {
            triggeringCampFire = false;
        }
    }


    void Die()
    {
        if (hunger == 0)
        {
            print("You have died of Hunger");
        }
        if (thirst == 0)
        {
            print("You have died of Thirst");
        }

    }

}
