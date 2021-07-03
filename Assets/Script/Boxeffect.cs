using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxeffect : MonoBehaviour
{
    // Start is called before the first frame update
   // bool _firstTimeRun = true;
    ParticleSystem[] particleSystems;
 
    void Awake()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }
 
private void OnParticleCollision(GameObject  other) {
  
                 Destroy(other);
           
}
    void OnEnable()
    {
       /* if (_firstTimeRun)
        {
            _firstTimeRun = false;
        }
        else
        {
            foreach (ParticleSystem ps in particleSystems)
            {
               ps.Play();
            }
        }*/
    }
 
    void Update()
    {
        if (!particleSystems[0].isPlaying)
        {
            DestroyParticles();
        }
    }
   
    public void DestroyParticles()
    {
        Destroy(this.gameObject);
    }
}
