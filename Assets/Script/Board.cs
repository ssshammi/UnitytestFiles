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
    
    void findPattern(){ //pass an array either transpose of normal as paramater ffor more effeciency 
       int totalColor = System.Enum.GetValues(typeof(JewelKind)).Length;
       // we know total color in this level is 5 
       totalColor =5;
    
       int startIndex = 0;
    
        int endIndex = getWidth();
       // Direction is Horizontal
      //  for (int row =0;row<getWidth();row++)
        for(int currentColor =1; currentColor< totalColor ;currentColor++ )//skip empty , // we can exculde color not in the level
       {
           
        //find partern of 5  "c,c,?,c,c"  that makes a T 
        //use  Array.FindIndex(array, start, end, pattern));
        //only searching once each row;  
        //sadly this is not possible is c# without custom array, in javascript its possible to get a row from multdimentional array,
        // or to could just use tosting() and get row and colums from transpose of matrix.  FindIndex is usefulll
        //returns an index of match 
      //  int wildCard =totalColor -currentColor;
    //   while(wildCard >currentColor)
   //   {
     //     int [] parttern =  {currentColor,currentColor,wildCard,currentColor,currentColor}
      //     System.Array.FindIndex(GetRow(boardDimensional,row), startIndex, endIndex, parttern);//pattern 5
         //after you get index just check if index +2 value is equal to next row index +2 value 

      //   }
         //simillarly seach other patterns 
         // System.Array.FindIndex(boardDimensional[0], startIndex, endIndex, [i,i,?,i]); //pattern 4 
         //  System.Array.FindIndex(boardDimensional[0], startIndex, endIndex, [i,?,i,i]); //pattern 4 
  //if found  
                //check total to find out the odd number for the pattern. 
                // check if this color exist in transpose of matrix. to add addtional score.    
            //if not found 
                //transpose array 
                    //find patten of 5 again. 

        //find pattern of 4  that makes a  L 
        // reuse the patter 4 for the last options. 

        
          //final solution matrix - array check number same substracation is  zer0 matrix 
         int[,] tempMatrixPattern5 =  { 
                            { currentColor, currentColor, 0, currentColor, currentColor}, 
                            { 0, 0, currentColor, 0, 0}, 
        };


         int[,] tempMatrixPattern5_2 =  {  
                             { 0, 0, currentColor, 0, 0}, 
                            { currentColor, currentColor, 0, currentColor, currentColor}, 
                          
        };


        //as the matrix is 8 x 8 there will be 3 comparasion. for 5 pattern in this horizontal board

         for (int filter =0;filter<getWidth() -tempMatrixPattern5.GetLength(1);filter++) 
            //int [,] compareArray = GetRowColumMatrix(boardDimensional,filter,tempMatrixPattern5)
            Debug.Log(""+GetRowColumMatrix(boardDimensional,filter,tempMatrixPattern5));
       }
    }

    public static IEnumerable<int> GetRowColumMatrix(int[,] array, int indx, int[,] array2)
    {
        for (int i = 0; i <= array2.GetUpperBound(1); ++i)
         for (int j = 0; j <= array2.GetUpperBound(0); ++i){
            int elm =  (array[j+indx, i] ==array2[j,i])?0:1;
            yield return elm;
            }
    }

  // if we are using matrix filer then there is not need to transpose we and just use a 2x5 matrix stored filter. 
    void transposeArray(){
        var clm = getWidth();
        int row = getHeight();
    boardDimensionalInver = new int[clm,row ];
     if (clm ==row) // if square matrix ignore diagnoal to copy faster. 
    {
        boardDimensionalInver = (int[,])boardDimensional.Clone();
        for (int i = 1; i < row; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int temp = boardDimensionalInver[i, j];
                boardDimensionalInver[i, j] = boardDimensionalInver[j, i];
                boardDimensionalInver[j, i] = temp;
            }
        }
    }
    else
    {
        for (int i = 0; i < clm; i++)
        {
            for (int j = 0; j < row; j++)
            {
                boardDimensionalInver[i, j] = boardDimensionalInver[j, i];
            }
        }
    }
    }

    // can get row and column

/*public static IEnumerable<T> GetRow<T>(T[,] array, int row)
    {
        for (int i = 0; i <= array.GetUpperBound(1); ++i)
            yield return array[row, i];
    }
    public static IEnumerable<T> GetColumn<T>(T[,] array, int column)
    {
        for (int i = 0; i <= array.GetUpperBound(0); ++i)
            yield return array[i, column];
    }
*/
     Move CalculateBestMoveForBoard(){
        Move mov = new Move();
        mov.x= 2;
        mov.y =2;
        mov.direction =MoveDirection.Down;
            findPattern();
          Debug.Log("The best move for Current board is  "+ JsonUtility.ToJson(mov));
         
          
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
 int[,] boardDimensionalInver ;
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
         transposeArray();
          CalculateBestMoveForBoard();
    }

    
    void Update()
    {
        
    }
}



