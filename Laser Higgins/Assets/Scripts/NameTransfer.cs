using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public static string playerName;
    // Start is called before the first frame update
    public void StoreName()
    {
        playerName = inputField.GetComponent<Text>().text;
        print(playerName);
    }
}
