using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 enemyPos;
    public Vector3 playerPos;
    public Vector3 endEnemyPos;
    private Vector3[] possibleMoves={new Vector3(0,0,1),new Vector3(1,0,0),new Vector3(1,0,1),new Vector3(-1,0,-1),new Vector3(0,0,-1),new Vector3(-1,0,0)};
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy,enemyPos,Quaternion.Euler(0,0,0));
        enemy=GameObject.Find("Enemy(Clone)");
        InvokeRepeating("ReachEndPoint",0,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        EndEnemyPos();
    }
    //its constantly finding the end enemy position with the changing player position through the same concept
    void EndEnemyPos(){
        playerPos=PlayerController.Instance.playerPos;
        Vector3 closestNeighbour=new Vector3(0,0,0);
        float shortest=100f;
        for(int i=0;i<6;i++){
                Vector3 tempPossible=playerPos+possibleMoves[i];
                float length=Vector3.Distance(tempPossible,enemyPos);
                if(PlayerController.Instance.isValid(tempPossible) && shortest>length && !PlayerController.Instance.ObstacleDetector(tempPossible)){
                    shortest=length;
                    closestNeighbour=tempPossible;
                }
            
            }
        endEnemyPos=closestNeighbour;
    }
    //same algorithm to reach the adjacent tile to the player
    void ReachEndPoint(){
        if(Vector3.Distance(enemyPos,endEnemyPos)>0.1f){
            float shortest=10;
            Vector3 closestNeighbour=new Vector3(0,0,0);
            for(int i=0;i<6;i++){
                Vector3 tempPossible=playerPos+possibleMoves[i];
                float length=Vector3.Distance(tempPossible,endEnemyPos);
                if(PlayerController.Instance.isValid(tempPossible) && shortest>length && !PlayerController.Instance.ObstacleDetector(tempPossible)){
                    shortest=length;
                    closestNeighbour=tempPossible;
                }
            }
            enemy.transform.position=closestNeighbour;
            enemyPos=closestNeighbour;
        }
    }
        
}
