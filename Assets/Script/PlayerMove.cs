using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
      private int currentPoint =0;

    public GameObject PatrolePointContainer;
  public AudioSource playSound;

  [SerializeField]
  public AudioClip dash;
   [SerializeField]
  public AudioClip win;

     public float MovementSpeed = 6f;
    public float TurningSpeed = 20.0f;
    public int placeObjects  =20;
//to get bounds of box
     public Renderer SpwanAreaBox;
     public GameObject particleEffect;
  private float  minDistance =1.0f;
      private Transform[] PatrolePoints;

    private void Awake() {
         PatrolePoints=  PatrolePointContainer.GetComponentsInChildren<Transform>();

        
    }

   private void  placeRandomObject(){

      Vector3 center = SpwanAreaBox.bounds.center;
        float radius = SpwanAreaBox.bounds.extents.magnitude/2;
     for (int i =0; i< placeObjects ;i++){
      GameObject tempObject = MultiSpawaner.ObjectPoolInstace.getPoolObjects(); 
         if(tempObject!= null){
          //Debug.Log("Text: " + center.ToString());

          //tempObject.transform.localScale =new Vector3(0.5f,0.5f,0.5f);
          tempObject.transform.position = new Vector3(Random.Range(-radius,radius), center.y +Random.Range(-radius,radius),Random.Range(-radius,radius));
          tempObject.SetActive(true);
         }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      // dashSound = GetComponent<AudioSource>();
         placeRandomObject();
    }

private void OnCollisionEnter(Collision other) { //in case of rigit body  
//private void OnTriggerEnter(Collider other) { // enable trigger
        

       if (other.gameObject.CompareTag("Obstacles"))
        {
          playSound.PlayOneShot(dash, 1.0F);
          
           // Debug.Log("Triggered by Enemy");
            Vector3 myVector3  = other.gameObject.transform.position;
            
           Instantiate(particleEffect,myVector3, Quaternion.Euler(90, 0, 0));
            other.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      //Debug.Log(this.gameObject.name);
      // look in the direction of movement
            Vector3 lookPos = PatrolePoints[currentPoint].position - this.transform.position;
            //angle of rotation to quaternion
           Quaternion rotation = Quaternion.LookRotation(lookPos);
           //rotate and movement of player
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, TurningSpeed);// Time.deltaTime * to slow it down
            //constant rate of movement. 
              transform.position = Vector3.MoveTowards(transform.position, PatrolePoints[currentPoint].position, Time.deltaTime * MovementSpeed);

              //if the main object reached the destination change cordinates. 
          float distace = Vector3.Distance(this.transform.position, PatrolePoints[currentPoint].position);
                    if (distace < minDistance)
                    {   
                      
                       
                         currentPoint++;
                    }
                    if (currentPoint == PatrolePoints.Length)
                    {
                       playSound.PlayOneShot(win, 1.0F);
                        currentPoint = 0;
                          //.sharedMaterial.SetColor("_Color",Color.white)  ;
                       GameObject tempPS = Instantiate(particleEffect,this.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
                        tempPS.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color",Color.white)  ;
                        Destroy(this.gameObject);
                    }
        
   
    }
}
