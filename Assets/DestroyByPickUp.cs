using UnityEngine;
using System.Collections;

public class DestroyByPickUp : MonoBehaviour
{
    //public GameObject explosion;
    //public GameObject playerExplosion;
 
    public PlayerController playerController;
    public AudioClip pickUpMusic;
    public AudioSource musicSource;

    void Start()
    {



    }

    void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Boundry") )
        {
            return;
        }


        if (other.CompareTag("Player"))
        {

            playerController.fireRate = 0.10f;
            //musicSource.clip = pickUpMusic;
           // musicSource.Play();
         
            Destroy(gameObject);

        }


     

        Destroy(gameObject);

    }
}