using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPos;
    public Vector3 startPos;
    public Vector3 endPos;
    private Vector3[] possibleMoves={new Vector3(0,0,1),new Vector3(1,0,0),new Vector3(1,0,1),new Vector3(-1,0,-1),new Vector3(0,0,-1),new Vector3(-1,0,0)};
    public ObstacleManager obstacleManager;
    public static PlayerController Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance=this;
        Instantiate(player,startPos,Quaternion.Euler(0,0,0));
        player=GameObject.Find("Player(Clone)");
        playerPos=startPos;
        obstacleManager=GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
        InvokeRepeating("ReachEndPoint",0,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //To implement the tile selection functionality
        if(Input.GetKey(KeyCode.Mouse0)){
            Debug.Log("Hello");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
                if(hit.transform.tag=="Tile"){
                    endPos.x=hit.transform.position.x;
                    endPos.z=hit.transform.position.z;
                    // StartCoroutine(RepeatFunction(0.5f));
                }
            }
        }
        
    }

    

    void ReachEndPoint(){
        if(Vector3.Distance(playerPos,endPos)>0.1f){
            float shortest=10;
            Vector3 closestNeighbour=new Vector3(0,0,0);
            //checking for the closest neighbour
            for(int i=0;i<6;i++){
                Vector3 tempPossible=playerPos+possibleMoves[i];
                float length=Vector3.Distance(tempPossible,endPos);
                if(isValid(tempPossible) && shortest>length && !ObstacleDetector(tempPossible)){
                    shortest=length;
                    closestNeighbour=tempPossible;
                }
            }
            player.transform.position=closestNeighbour;
            playerPos=closestNeighbour;
        }
    }
    //to make sure that the values are not outofbounds
    public bool isValid(Vector3 pos){
        if(pos.x<10 && pos.x>=0 && pos.z<10 && pos.z>=0){
            return true;
        }
        return false;
    }
    //checking if there is a obstacle on the tile
    public bool ObstacleDetector(Vector3 pos){
        return obstacleManager.toggles[(int)pos.x,(int)pos.z];
    }
    
}
