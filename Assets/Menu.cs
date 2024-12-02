using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject optionsPanel1; // Reference to the first Options Panel
    [SerializeField] private GameObject optionsPanel2; // Reference to the second Options Panel

    private void Start()
    {
        // Ensure both Options Panels are hidden at the start
        if (optionsPanel1 != null)
        {
            optionsPanel1.SetActive(false);
        }

        if (optionsPanel2 != null)
        {
            optionsPanel2.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleOptionsPanel1()
    {
        if (optionsPanel1 != null)
        {
            // Toggle the active state of Options Panel 1
            optionsPanel1.SetActive(!optionsPanel1.activeSelf);
        }
    }

    public void ToggleOptionsPanel2()
    {
        if (optionsPanel2 != null)
        {
            // Toggle the active state of Options Panel 2
            optionsPanel2.SetActive(!optionsPanel2.activeSelf);
        }
    }

    public void CloseOptionsPanel1()
    {
        if (optionsPanel1 != null)
        {
            optionsPanel1.SetActive(false);
        }
    }

    public void CloseOptionsPanel2()
    {
        if (optionsPanel2 != null)
        {
            optionsPanel2.SetActive(false);
        }
    }
}
