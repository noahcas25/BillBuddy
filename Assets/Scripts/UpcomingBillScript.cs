using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpcomingBillScript : MonoBehaviour
{

    string billName = "";
    string date = "";
    string cost = "";

    public GameObject Bill;

    void OnEnable(){
        if(PlayerPrefs.HasKey("BillName")) 
            billName = PlayerPrefs.GetString("BillName");

        if(PlayerPrefs.HasKey("Date")) 
            date = PlayerPrefs.GetString("Date");

        if(PlayerPrefs.HasKey("Cost")) 
            cost = PlayerPrefs.GetString("Cost");

        Bill.GetComponent<BillScript>().name = billName;
        Bill.GetComponent<BillScript>().date = date;
        Bill.GetComponent<BillScript>().cost = cost;

        PlayerPrefs.DeleteAll();
    }



    void Update() {
        OnEnable();


    }
}
