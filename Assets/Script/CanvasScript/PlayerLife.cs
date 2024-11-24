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
            CanvsHealth.SetActive(false);  // ����ֵΪ 0 ʱ���������� UI
        }
        else
        {
            CanvsHealth.SetActive(true);   // ����ֵ���� 0 ʱ����ʾ���� UI

            // ��ʾ����ֵ��Ӧ����
            Health1.SetActive(PlayerHead.Life >= 1); // Life >= 1 ��ʾ��һ����
            Health2.SetActive(PlayerHead.Life >= 2); // Life >= 2 ��ʾ�ڶ�����
            Health3.SetActive(PlayerHead.Life >= 3); // Life >= 3 ��ʾ��������
            Health4.SetActive(PlayerHead.Life >= 4); // Life >= 4 ��ʾ���Ŀ���
        }

    }
}
