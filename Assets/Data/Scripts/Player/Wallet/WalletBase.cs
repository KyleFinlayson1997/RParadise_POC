using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletBase : MonoBehaviour
{
    public float money = 100;

    public Text moneyUI;

    public bool mchanged;

    void Moneyadd(float amount)
    {
        money = money + amount;
        mchanged = true;
    }

    void Moneysub(float amount)
    {
        money = money - amount;
        if (money < 0)
        {
            money = 0;
        }
        mchanged = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        moneyUI = GetComponent<Text>();
        moneyUI.text = "$" + money;
    }

    // Update is called once per frame
    void Update()
    {
        if (mchanged == true)
        {
            moneyUI.text = "$" + money;
            mchanged = false;
        }
    }
}
