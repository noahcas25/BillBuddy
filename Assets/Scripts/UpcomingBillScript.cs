using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UpcomingBillScript : MonoBehaviour
{


public GameObject bill;

    string billName = "";
    string date = "";
    string cost = "";
    int count = 0;

    List<List<string>> bills = new List<List<string>>();
    FileStream file;

    void OnEnable() {
        if(PlayerPrefs.HasKey("BillName")) 
            billName = PlayerPrefs.GetString("BillName");

        if(PlayerPrefs.HasKey("Date")) 
            date = PlayerPrefs.GetString("Date");

        if(PlayerPrefs.HasKey("Cost")) 
            cost = PlayerPrefs.GetString("Cost");


        if(billName != "" && date != "" && cost != "") {
            // Bill.GetComponent<BillScript>().name = billName;
            // Bill.GetComponent<BillScript>().date = date;
            // Bill.GetComponent<BillScript>().cost = cost;

        //     Bill.GetComponent<BillScript>().fillData(1);

            if(count < 1) {
            LoadSave();
            displayBills();
            }

            count++;
        }

        // PlayerPrefs.DeleteAll();
    }

    void displayBills() {

        if(bills.Count == 1) {
            // bill;
                 bill.GetComponent<BillScript>().name = bills[0][0];
                 bill.GetComponent<BillScript>().date = bills[0][1];
                 bill.GetComponent<BillScript>().cost = bills[0][2];
                 bill.GetComponent<BillScript>().fillData(1);
        }

        for(int i = 0; i < bills.Count; i++) {
             if(i == 0) {
                bill.GetComponent<BillScript>().name = bills[0][0];
                bill.GetComponent<BillScript>().date = bills[0][1];
                bill.GetComponent<BillScript>().cost = bills[0][2];
                bill.GetComponent<BillScript>().fillData(1);
            } else{
                      GameObject Bill = Instantiate(bill, bill.GetComponent<RectTransform>());
                    Bill.GetComponent<RectTransform>().offsetMax = new Vector2(0, -120*(i));
                    Bill.GetComponent<RectTransform>().offsetMin = new Vector2(0, -120*(i));
                    Bill.GetComponent<RectTransform>().SetParent(bill.GetComponent<RectTransform>().parent, true);

                    Bill.GetComponent<BillScript>().name = bills[i][0];
                    Bill.GetComponent<BillScript>().date = bills[i][1];
                    Bill.GetComponent<BillScript>().cost = bills[i][2];
                    Bill.GetComponent<BillScript>().fillData(1);
                }
        }
    }

    void LoadSave() {
         if(File.Exists(Application.persistentDataPath + "/gameData2.txt")) {

                BinaryFormatter bf = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + "/gameData2.txt", FileMode.Open);
                bills = (List<List<string>>)bf.Deserialize(file);
                file.Close();
            }
    }

    void Update() {
        OnEnable();


    }
}