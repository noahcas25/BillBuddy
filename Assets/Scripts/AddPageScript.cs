using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class AddPageScript : MonoBehaviour
 {

    string billName = "";
    string date = "";
    string cost = "";

    public void Submit() {
        if(this.GetComponent<RectTransform>().GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text != "") 
            billName = this.GetComponent<RectTransform>().GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text;

        if(this.GetComponent<RectTransform>().GetChild(2).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text != "Month" && 
        this.GetComponent<RectTransform>().GetChild(3).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text != "Day") 
            date = this.GetComponent<RectTransform>().GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text + " " + this.GetComponent<RectTransform>().GetChild(3).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text;

        if(this.GetComponent<RectTransform>().GetChild(4).GetComponent<TMPro.TextMeshProUGUI>().text != "") 
            cost = transform.GetChild(4).GetComponent<TMPro.TextMeshProUGUI>().text;

        if(billName != "" && date != "" && cost != "")
            OnDisable();
    }

    void OnDisable() {
        PlayerPrefs.SetString("BillName", billName);
        PlayerPrefs.SetString("Date", date);
        PlayerPrefs.SetString("Cost", cost);

        PlayerPrefs.Save();
    }
}
