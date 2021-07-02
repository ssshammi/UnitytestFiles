using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPriddictor : MonoBehaviour
{
    // Start is called before the first frame update

    public float floorH = 5.0f;

    private Vector2  ballPos;
    private Vector2  velcity2D;

    private float wallWidth = 40.0f;
    private float gravitation =-9.8f;

    private float predictedX =0.0f;

   private void Awake() {
        
    }
    void Start()
    {
        Debug.Log(" initialX : "+transform.position.x );
        Debug.Log(" initialY : "+transform.position.y );
        float xPos =0.0f;
        TryCalculateXPositionAtHeight(floorH, new Vector2(transform.position.x, transform.position.y), new Vector2(5.0f, 5.0f) , gravitation, 20.0f,ref xPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// p is initial point , v is velocity , g is gravaity, w is width, need to predict xPosition
    private bool TryCalculateXPositionAtHeight(float h, Vector2 p, Vector2 v, float G, float w, ref float xPosition){
            //h -( p + v *t + G*t^2/2)
          float angle = Mathf.Atan2 (v.y,v.x); float speed = Mathf.Sqrt(v.y*v.y + v.x * v.x);
         // float time = v.magnitude/speed;
          float predictedX;
           float predictedY;

         for (float tt = 0.0f; tt< 1000 ;tt=tt+0.1f){
            predictedX = p.x+ v.x*tt;
             predictedY  = p.y+v.y* tt +0.5f*G *Mathf.Pow(tt,2) ;
            if (predictedX > w/2)
             v.x = -v.x;
             if (predictedX < -w/2)
             v.x = -v.x;  
             GameObject tempBall = Instantiate(this.gameObject,new Vector3(predictedX,predictedY,19.0f),Quaternion.identity);
            Debug.Log(" predictedX : "+predictedX +" predictedy : "+predictedY);
            if(predictedY <h) break;
            
            }
            // we know final y  p.y -h 
            
        return true;
  }

}
