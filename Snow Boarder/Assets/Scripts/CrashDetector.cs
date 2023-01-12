using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem DeathEffect;

    bool hasPlayed=false;
    [SerializeField] AudioClip crashEffect;
    CircleCollider2D playerHead;
    [SerializeField] float InvokeTime= 0.5f;

    [SerializeField] new ParticleSystem particleSystem;


    private void Start()
    {
        playerHead=GetComponent<CircleCollider2D>();

    }

    
   public void OnCollisionEnter2D(Collision2D other) {
    
        if(other.gameObject.tag=="Head" && playerHead.IsTouching(other.collider))
        {
            if(!hasPlayed)
            {
                GetComponent<AudioSource>().PlayOneShot(crashEffect);
                hasPlayed=true;
            }
            
            FindObjectOfType<PlayerController>().DisableControls();
            DeathEffect.Play();
            Invoke("ReloadScene",InvokeTime);  

        }

        particleSystem.Play();


   }
   private  void OnCollisionExit2D(Collision2D other) {
    
    particleSystem.Pause();
   }

   void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
   
}
