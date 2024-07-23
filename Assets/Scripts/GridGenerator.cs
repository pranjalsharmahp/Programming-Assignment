using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<10;i++){
            for(int j=0;j<10;j++){
                
                GameObject tile=Instantiate(cubePrefab,new Vector3(i,-0.3f,j),transform.rotation);
                tile.name=$"Tile_{i}_{j}";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
