using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

 public class AddPageScript : MonoBehaviour
 {

    string billName = "";
    string date = "";
    string cost = "";

    List<List<string>> bills;
    FileStream file;

    public void Submit() {
        if(this.GetComponent<RectTransform>().GetChild(1).GetComponent<TMP_InputField>().text != "") 
            billName = this.GetComponent<RectTransform>().GetChild(1).GetComponent<TMP_InputField>().text;

        if(this.GetComponent<RectTransform>().GetChild(2).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text != "Month" && 
        this.GetComponent<RectTransform>().GetChild(3).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text != "Day") 
            date = this.GetComponent<RectTransform>().GetChild(2).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text + " " + this.GetComponent<RectTransform>().GetChild(3).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text;

        if(this.GetComponent<RectTransform>().GetChild(4).GetComponent<TMP_InputField>().text != "") 
            cost = transform.GetChild(4).GetComponent<TMP_InputField>().text;

        if(billName != "" && date != "" && cost != "") {
            OnDisable();

            List<string> bill = new List<string>();

            bill.Add(billName);
            bill.Add(date);
            bill.Add(cost);

            LoadSave();
            SaveFile(bill);
            }

         SceneManager.LoadScene("MainHub");
    }

    void OnDisable() {
        PlayerPrefs.SetString("BillName", billName);
        PlayerPrefs.SetString("Date", date);
        PlayerPrefs.SetString("Cost", cost);

        PlayerPrefs.Save();
    }

    void LoadSave() {
         if(File.Exists(Application.persistentDataPath + "/gameData2.txt")) {

                BinaryFormatter bf = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + "/gameData2.txt", FileMode.Open);
                bills = (List<List<string>>)bf.Deserialize(file);
                file.Close();
            }
    }

    void SaveFile(List<string> bill) {
        bills.Add(bill);
        BinaryFormatter bf = new BinaryFormatter();
        file = File.Open(Application.persistentDataPath + "/gameData2.txt", FileMode.Open);
        bf.Serialize(file, bills);
        file.Close();
    }
}
 
