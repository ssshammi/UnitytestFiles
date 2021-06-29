using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
      private int currentPoint =0;

    public GameObject PatrolePointContainer;

     public float MovementSpeed = 6f;
    public float TurningSpeed = 0.2f;
  private float  minDistance =1;
      private Transform[] PatrolePoints;

    private void Awake() {
         PatrolePoints=  PatrolePointContainer.GetComponentsInChildren<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
               Vector3 lookPos = PatrolePoints[currentPoint].position - this.transform.position;
           Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * TurningSpeed);
              transform.position = Vector3.MoveTowards(transform.position, PatrolePoints[currentPoint].position, Time.deltaTime * MovementSpeed);

              
          float distace = Vector3.Distance(this.transform.position, PatrolePoints[currentPoint].position);
                    if (distace < minDistance)
                        currentPoint++;
                    if (currentPoint == PatrolePoints.Length)
                    {
                        currentPoint = 0;
                    }
        
   
    }
}
