using UnityEditor;
using UnityEngine;

public class ObstacleSpawner : EditorWindow
{
    bool[,] toggles=new bool[10,10];
    bool currentState=false;
    public GameObject obstacle;
    [MenuItem("Tools/Obstacle Spawner")]
    
    
    public static void ShowWindow(){
        GetWindow(typeof(ObstacleSpawner));
    }
    void OnGUI(){
        
        for(int i=0;i<10;i++){
            EditorGUILayout.BeginHorizontal();
            for(int j=0;j<10;j++){
                toggles[i,j]=EditorGUILayout.Toggle(toggles[i,j]);
            }
            EditorGUILayout.EndHorizontal();
        }
        if(GUILayout.Button("Spawn Obstacles")){
            SpawnObstacles();
        }
        
    }
    void SpawnObstacles(){
        for(int i=0;i<10;i++){
            for(int j=0;j<10;j++){
                if(toggles[i,j]){
                    Instantiate(obstacle,new Vector3(i,0,j),Quaternion.Euler(0,0,0));
                    ObstacleManager.Instance.toggles[i,j]=true;
                }
            }
        }
    }
}
