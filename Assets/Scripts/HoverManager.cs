using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverManager : MonoBehaviour
{
    public TMP_Text tileInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit)){
            Debug.Log(hit.transform.name);
            if(hit.transform.tag=="Tile"){
                int x=(int)hit.transform.position.x;
                int z=(int)hit.transform.position.z;
                tileInfo.text= $"Tile- \nRow:{x}\nColumn:{z}";
            }
            
        }
    }
}
