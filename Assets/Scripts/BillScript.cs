using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillScript : MonoBehaviour
{

    public string name;
    public string date;
    public string cost;

    private void convertDate(){
        string[] splitter = date.Split(' ');
        string month = "";

        switch(splitter[0]) {
            case "January": month = "1/";
            break;
            case "February": month = "2/";
            break;
            case "March": month = "3/";
            break;
            case "April": month = "4/";
            break;
            case "May": month = "5/";
            break;
            case "June": month = "6/";
            break;
            case "July": month = "7/";
            break;
            case "August": month = "8/";
            break;
            case "September": month = "9/";
            break;
            case "October": month = "10/";
            break;
            case "November": month = "11/";
            break;
            case "December": month = "12/";
            break;
        }

        date = month + splitter[1];
    }

    public void fillData(int position){

        convertDate();
        this.GetComponent<RectTransform>().GetChild(position).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "\n" + " " + name;
        this.GetComponent<RectTransform>().GetChild(position).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = date;
        this.GetComponent<RectTransform>().GetChild(position).GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = "$" + cost;
        }
}
