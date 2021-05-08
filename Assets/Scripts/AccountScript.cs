using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

 public class AccountScript : MonoBehaviour
 {

   
    List<string> accountInfo;
    FileStream file;

    void Start() {
        LoadSave();
        accountInfo.Add("");
        accountInfo.Add("");
        accountInfo.Add("");
        accountInfo.Add("");
        Display();
    }

    // void Update() {
    //     // LoadSave();
    // }
    
    void Display() {
        if(accountInfo[0] != "") {
            this.GetComponent<RectTransform>().GetChild(1).GetChild(0).GetComponent<TMP_InputField>().text = accountInfo[0];
        }

        if(accountInfo[1] != "") {
            this.GetComponent<RectTransform>().GetChild(1).GetChild(1).GetComponent<TMP_InputField>().text = accountInfo[1];
        }

        if(accountInfo[2] != "") {
            this.GetComponent<RectTransform>().GetChild(1).GetChild(2).GetComponent<TMP_InputField>().text = accountInfo[2];
        }

        if(accountInfo[3] != "") {
            this.GetComponent<RectTransform>().GetChild(1).GetChild(3).GetComponent<TMP_InputField>().text = accountInfo[3];
        }
       
    }


    public void UpdateInfo() {

        if(this.GetComponent<RectTransform>().GetChild(1).GetChild(0).GetComponent<TMP_InputField>().text != "") {
           accountInfo[0] =  this.GetComponent<RectTransform>().GetChild(1).GetChild(0).GetComponent<TMP_InputField>().text;
        }
        
         if(this.GetComponent<RectTransform>().GetChild(1).GetChild(1).GetComponent<TMP_InputField>().text != "") {
           accountInfo[1] =  this.GetComponent<RectTransform>().GetChild(1).GetChild(1).GetComponent<TMP_InputField>().text;
        }

         if(this.GetComponent<RectTransform>().GetChild(1).GetChild(2).GetComponent<TMP_InputField>().text != "") {
           accountInfo[2] =  this.GetComponent<RectTransform>().GetChild(1).GetChild(2).GetComponent<TMP_InputField>().text;
        }

         if(this.GetComponent<RectTransform>().GetChild(1).GetChild(3).GetComponent<TMP_InputField>().text != "") {
           accountInfo[3] =  this.GetComponent<RectTransform>().GetChild(1).GetChild(3).GetComponent<TMP_InputField>().text;
        }

        SaveFile(accountInfo);

        SceneManager.LoadScene("MainHub");

    }

    void LoadSave() {
         if(File.Exists(Application.persistentDataPath + "/AccountData.txt")) {
                BinaryFormatter bf = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + "/AccountData.txt", FileMode.Open);
                accountInfo = (List<string>)bf.Deserialize(file);
                file.Close();
            }
    }

    void SaveFile(List<string> accountInfo) {
        BinaryFormatter bf = new BinaryFormatter();
        file = File.Open(Application.persistentDataPath + "/AccountData.txt", FileMode.Open);
        bf.Serialize(file, accountInfo);
        file.Close();
    }
       
}

