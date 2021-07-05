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
    [SerializeField]
    public GameObject copyBall;

   private void Awake() {
        
    }
    void Start()
    {
        Debug.Log(" initialX : "+transform.position.x );
        Debug.Log(" initialY : "+transform.position.y );
        float xPos =0.0f;
        TryCalculateXPositionAtHeight(floorH, new Vector2(transform.position.x, transform.position.y), new Vector2(10.0f, 10.0f) , gravitation, wallWidth,ref xPos);
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
         float vo =  Mathf.Sqrt(v.y*v.y + v.x * v.x);
          float predictedX =0.0f;
            float predictedY=0.0f;
        float tt_col =0;
         for (float tt = 0.0f; tt< 100 ;tt=tt+0.1f){ //0.1 increments
            float temppredictedX = p.x+v.x*(tt -tt_col);
             float temppredictedY  = p.y+v.y* (tt-tt_col)*Mathf.Sin(angle) +0.5f*G *Mathf.Pow((tt-tt_col),2) ;
           if (temppredictedX > w/2 || temppredictedX < -w/2){
                 
                    v.x = -1 * temppredictedX ;
                    v.y =  v.y*Mathf.Sin(angle);
                 //  tt_col = tt_col +tt;
                 tt =0;
                  vo =  Mathf.Sqrt(v.y*v.y + v.x * v.x);
                  angle = Mathf.Atan2 (v.y,v.x);
              //  TryCalculateXPositionAtHeight(h, new Vector2(temppredictedX, temppredictedY), new Vector2(v.x, v.y) , G, w,ref xPosition);
                  //   break;
                     p.x =predictedX;
                      p.y =predictedY;
                }
                    predictedX  =temppredictedX;
                    predictedY  = temppredictedY; 
             GameObject tempBall = Instantiate(copyBall,new Vector3(predictedX,predictedY,19.0f),Quaternion.identity);
            Debug.Log(" predictedX : "+predictedX +" predictedy : "+predictedY);
            if(predictedY <h) break;
            
            }
            // we know  x 
            xPosition = predictedX;
        return true;
  }

}
