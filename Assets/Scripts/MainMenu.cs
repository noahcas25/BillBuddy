using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

    public GameObject bill;

    public void StartButton() {
        SceneManager.LoadScene("MainHub");


        List<List<string>> bills = new List<List<string>>();
        BinaryFormatter bf = new BinaryFormatter();

        List<string> accountInfo = new List<string>();

        FileStream file = File.Create(Application.persistentDataPath + "/gameData2.txt");
        bf.Serialize(file, bills);
        file.Close();

        FileStream file2 = File.Create(Application.persistentDataPath + "/AccountData.txt");
        bf.Serialize(file2, accountInfo);
        file2.Close();
    }
    public void AddButton() {
        // GameObject BillNew = Instantiate(bill, bill.GetComponent<RectTransform>());
    
        // BillNew.GetComponent<RectTransform>().offsetMax = new Vector2(bill.GetComponent<RectTransform>().offsetMax.x, 100);
        // BillNew.GetComponent<RectTransform>().offsetMin = new Vector2(bill.GetComponent<RectTransform>().offsetMin.x, -100);
        // BillNew.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>(), true);


        SceneManager.LoadScene("AddPage");
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

