using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance;
    public bool[,] toggles=new bool[10,10];
    // Start is called before the first frame update
    void Start()
    {
        Instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
