using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Tee Locations")]
    public Transform T1;
    public Transform T2;
    public Transform T3;
    public Transform T4;
    public Transform T5;
    public Transform T6;
    public Transform T7;
    public Transform T8;
    public Transform T9;
    
    [Header("Hole Locations")]
    private Transform[] tees;
    
    [SerializeField] 
    private GameObject player;
    private int currHole;
    private int currHoleScore;
    private int[] courseScore;

    // Start is called before the first frame update
    void Start()
    {
        tees = new Transform[9]{T1, T2, T3, T4, T5, T6, T7, T8, T9};
        currHole = 0;
        courseScore = new int[9];
        player.transform.position = tees[currHole].transform.position + new Vector3(0, 1, 0);

        //PlayHole(currHole);
    }

    public void newHole()
    {
        courseScore[currHole] = currHoleScore;
        if (currHole == 8) 
        { 
            FinishGame(); 
        }
        else 
        { 
            currHole += 1; 
            player.transform.position = tees[currHole].transform.position + new Vector3(0, 1, 0);
            player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
        
    }

    public void AddStroke()
    {
        currHoleScore++;
    }

    public void FinishGame()
    {
        int sum = 0;
        for (int i = 0; i < courseScore.Length; i++)
        {
            sum += courseScore[i];
        }

        Debug.Log("Game Finished: " + sum);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("Game Restarted");
    }
}
