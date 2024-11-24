using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    public GameObject Health1;
    public GameObject Health2;
    public GameObject Health3;
    public GameObject Health4;
    public GameObject CanvsHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHead.Life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHead.Life == 0)
        {
            CanvsHealth.SetActive(false);  // 生命值为 0 时，隐藏生命 UI
        }
        else
        {
            CanvsHealth.SetActive(true);   // 生命值大于 0 时，显示生命 UI

            // 显示生命值对应的心
            Health1.SetActive(PlayerHead.Life >= 1); // Life >= 1 显示第一颗心
            Health2.SetActive(PlayerHead.Life >= 2); // Life >= 2 显示第二颗心
            Health3.SetActive(PlayerHead.Life >= 3); // Life >= 3 显示第三颗心
            Health4.SetActive(PlayerHead.Life >= 4); // Life >= 4 显示第四颗心
        }

    }
}
