using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (totalPoints >= 20)
        {
            Debug.Log("Ending 1: Elysia is Rescued");
            SceneManager.LoadScene("GoodEnding");
        }
        else
        {
            Debug.Log("Ending 2: Elysia is captured by NeuroDyne!");
            SceneManager.LoadScene("BadEnding");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
