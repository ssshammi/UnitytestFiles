using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    enum JewelKind
{
       Empty =0,
       Red =1,
       Orange=2,
       Yellow,
       Green,
       Blue,
       Indigo,
       Violet
};

enum MoveDirection
{
       Up,
       Down,
       Left,
       Right
};

 struct Move
{

public int x;
public int y;
public MoveDirection direction;
};

        int getWidth(){
           
           return boardDimensional.GetLength(1);
       }
      int getHeight(){
           
           return boardDimensional.GetLength(0);
       }

              JewelKind GetJewel(int x, int y){
                  
                  return JewelKind.Empty;
              }
       void SetJewel(int x, int y, JewelKind kind){
           
       }
    
    void findPattern(){


    }
    void transposeArray(){

        
    }


     Move CalculateBestMoveForBoard(){
        Move mov = new Move();
        mov.x= 2;
        mov.y =2;
        mov.direction =MoveDirection.Left;
        return mov;
    }
    // Start is called before the first frame update
    
    // Update is called once per frame

int[,] boardDimensional = { 
                            { 1, 2, 4, 2, 3, 2, 3, 5 },
                            { 1, 2, 4, 4, 3, 2, 3, 5 },
                            { 4, 4, 1, 4, 4, 1, 4, 4 },
                            { 1, 1, 4, 1, 1, 4, 3, 4 },
                            { 2, 2, 1, 4, 5, 1, 3, 5 },
                            { 1, 2, 1, 3, 3, 1, 4, 5 },
                            { 2, 1, 3, 4, 3, 2, 4, 4 },
                            { 5, 3, 3, 2, 2, 1, 1, 5 }
                        };
Color[] colors = {Color.clear, Color.red,Color.white, Color.yellow, Color.green,Color.blue, Color.cyan, Color.grey};
     private void Awake() {
        
       
    }
    private void  placeRandomObject(){
        Debug.Log("width height "+getWidth()*getHeight());
        Vector3 parentContianer = this.transform.position;
     for (int i =0; i<(getHeight()) ;i++){
           for(int j =0; j<(getWidth()) ;j++){
        GameObject tempObject = MultiSpawaner.ObjectPoolInstace.getPoolObjects(); 
         if(tempObject!= null){
          //Debug.Log("Text: " + center.ToString());
            
           tempObject.transform.parent  =this.transform;
            tempObject.GetComponent<Renderer>().material.SetColor("_Color",colors[boardDimensional[i,j]])  ;
          tempObject.transform.localScale =new Vector3(2.0f,2.0f,2.0f);
          tempObject.transform.localPosition  = new Vector3(j*5, i*5,5.0f);
          tempObject.transform.name ="Cube_"+j +"_"+i;
           
          tempObject.SetActive(true);
          
         }}
        }
    }
    void Start()
    {
      
         placeRandomObject();
    }

    
    void Update()
    {
        
    }
}



