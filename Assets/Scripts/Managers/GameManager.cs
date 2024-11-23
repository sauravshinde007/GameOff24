using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int totalPoints = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateTotalPoints(int points)
    {
        totalPoints = points;
        Debug.Log("Total Points: " + totalPoints);
    }

    public void CheckGameEnding()
    {
        if (totalPoints >= 30)
        {
            Debug.Log("Ending 1: The Hero!");
        }
        else if (totalPoints >= 15)
        {
            Debug.Log("Ending 2: The Neutral Adventurer.");
        }
        else
        {
            Debug.Log("Ending 3: The Villain!");
        }
    }
}
