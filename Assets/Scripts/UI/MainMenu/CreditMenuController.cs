using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditMenuController : MenuWithContent
{
    [Serializable]
    public class CreditElement
    {
        public string name;
        public string nim;
        public Sprite avatar;
    }
     
    [SerializeField] private List<CreditElement> _creditElements = new List<CreditElement>(); 

    private void OnEnable()
    {
        OpenCreditMenu();
    } 

    #region Helper methods
    public void OpenCreditMenu()
    {
        foreach(CreditElement element in _creditElements)
        {
            GameObject elementObj = Instantiate(Prefab, ContentTrans.transform);
            elementObj.name = element.name;
            elementObj.transform.Find("Mask").Find("Image").GetComponent<Image>().sprite = element.avatar;
            elementObj.transform.Find("NIM").GetComponent<TMP_Text>().text = element.nim;
            elementObj.transform.Find("Nama").GetComponent<TMP_Text>().text = element.name;
        }
    } 
    #endregion
}
