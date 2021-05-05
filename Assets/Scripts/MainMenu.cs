using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

    // public GameObject canvas; 

    public void StartButton() {
        SceneManager.LoadScene("MainHub");
    }

    public void HomeButton() {
        SceneManager.LoadScene("MainHub");
    }

    public void AccountButton() {
        SceneManager.LoadScene("AccountPage");
    }

    public void CalendarButton() {
        SceneManager.LoadScene("CalendarPage");
    }

    public void SettingsButton() {
        SceneManager.LoadScene("SettingsPage");
    }
}
