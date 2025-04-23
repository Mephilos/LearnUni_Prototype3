using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0); 
    private float startDelay = 2.0f;
    private float repeatRate = 1.5f;
    // C# script PlayerController 변수 선언
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        // 변수에 게임오브젝트 player 찾기, 컴포넌트의 PlayerController 저장
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
