using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpawaner : MonoBehaviour
{

public static  MultiSpawaner ObjectPoolInstace;
public List<GameObject> pooledObj;
public GameObject genericObject;
public int noOfObjets;
private void Awake() {
    ObjectPoolInstace = this;

    pooledObj = new List<GameObject>();
    GameObject objectInstance;

    for (int i =0;i<noOfObjets;i++ ){
        objectInstance = Instantiate(genericObject);
        objectInstance.SetActive(false);
        pooledObj.Add(objectInstance);

    }
    
}
private void Start() {
    
}

public GameObject getPoolObjects(){

   for (int i =0;i<noOfObjets;i++ ){
        
        if(!pooledObj[i].activeInHierarchy){

            return pooledObj[i];
        }

    }
    return null;
     
}
    
  
}
