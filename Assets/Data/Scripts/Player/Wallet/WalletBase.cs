using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletBase : MonoBehaviour
{
    public float money = 100;

    public Text moneyUI;

    // Start is called before the first frame update
    void Start()
    {
        moneyUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyUI.text = "$" + money;
        if (money < 0)
        {
            money = 0;
        }
    }
}
