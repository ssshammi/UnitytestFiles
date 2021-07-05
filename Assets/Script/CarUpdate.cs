using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

//we can pass the list as reference. 
    void UpdateRacers(float deltaTimeS, List<Racer> racers)
{
    List<Racer> racersNeedingRemoved = new List<Racer>();
    //no need to call clear as this nothing has been added. 
    racersNeedingRemoved.Clear();

    // Updates the racers that are alive
    //can start with 0 int racerIndex = 0; 
    int racerIndex;
    for (racerIndex = 0; racerIndex <= racers.Count; racerIndex++) //changed 1000 
    {
      //  if (racerIndex <= racers.Count)
       // {
           //additonal computation racerIndex - 1
            if (racers[racerIndex].IsAlive()) //seems only active racers need to be sent update. 
            {
                //Racer update takes milliseconds
                racers[racerIndex].Update(deltaTimeS * 1000.0f);  //asuming the racers will move or stop or change lanes or turn, 
            }
        //}
    }
    // if we need to check after all racer updates then we need to add delay here Invoke call. 
    // Collides

    //
    /*
I would change this function completly. 
for example of they are running in lanes or in order. then we just need to check the one that are are a distance of collision and not needed to check with everyone.
// if it's possible to sort by distance then i would sort the list first and check only racers that are very close 
for example we could have the z location and sort method implement in racer class. 
    */
    
    for (int racerIndex1 = 0; racerIndex1 < racers.Count; racerIndex1++)
    {
        //why check with it self ? 
        //changed oder and decrement -- 
        for (int racerIndex2 =  racers.Count; racerIndex2 > racerIndex1; racerIndex2--)
        {
            Racer racer1 = racers[racerIndex1];
            Racer racer2 = racers[racerIndex2];
           // if (racerIndex1 != racerIndex2)
           // {
                if (racer1.IsCollidable() && racer2.IsCollidable() && racer1.CollidesWith(racer2))
                {
                    OnRacerExplodes(racer1); // checking if the aniamtion of any of the racer ends ? dosn't look like this will no anything.
                    // maybe it keeps track of racer explotion or a list. 

                    //if the racer has already colided with another racer it might be added twice so this is a temporay list 
                    racersNeedingRemoved.Add(racer1);
                    racersNeedingRemoved.Add(racer2);
                    
                    
                }
            }
        //}
    }
    //totally unnecessay sept we have the list of racers we need to remove. 
    // Gets the racers that are still alive
  /*  List<Racer> newRacerList = new List<Racer>();
 
    for ( racerIndex = 0; racerIndex != racers.Count; racerIndex++)
    {
    // check if this racer must be removed
    if (racersNeedingRemoved.IndexOf(racers[racerIndex]) < 0)
        {
            newRacerList.Add(racers[racerIndex]);
        }
    }
    // Get rid of all the exploded racers
    for (racerIndex = 0; racerIndex != racersNeedingRemoved.Count; racerIndex++)
    {
        int foundRacerIndex = racers.IndexOf(racersNeedingRemoved[racerIndex]);
        if (foundRacerIndex >= 0) // Check we've not removed this already!
        {
            racersNeedingRemoved[racerIndex].Destroy();
            racers.Remove(racersNeedingRemoved[racerIndex]);
        }
    }
    // Builds the list of remaining racers
    racers.Clear();
    for (racerIndex = 0; racerIndex < newRacerList.Count; racerIndex++)
    {
        racers.Add(newRacerList[racerIndex]);
    }

    for (racerIndex = 0; racerIndex < newRacerList.Count; racerIndex++)
    {
        newRacerList.RemoveAt(0);
    }*/
// Get rid of all the exploded racers added new
 for ( racerIndex = 0; racerIndex < racersNeedingRemoved.Count; racerIndex++){
      int foundRacerIndex = racers.IndexOf(racersNeedingRemoved[racerIndex]);
        if (foundRacerIndex >= 0) 
        {  //probaly should not remove the racer from racers , there is setAlive so set it dead and disable it. till the animation is not over. But ill keey it like so 
             racers.RemoveAt(foundRacerIndex);//racersNeedingRemoved[racerIndex],
             racersNeedingRemoved[racerIndex].Destroy();
         }
 }
 racersNeedingRemoved.Clear();

}

public  void OnRacerExplodes(Racer r){


}

}

public class Racer{

   public  bool IsAlive(){

        return true;
    }
   public void Update(float currentTime){


    }

    public bool IsCollidable(){
        
        return true;
    }

    public bool CollidesWith(Racer r){

return true;
    }

    public void Destroy(){

    }

}

