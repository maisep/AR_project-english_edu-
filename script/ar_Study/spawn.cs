using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject[] obj=new GameObject[11];
    public int state = 0;// 현재 상태 >>>>>> 0~2;
    public bool change = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            statechange();
            change = !change;
        }
    }


    void statechange() // 사용안함--------------------------------------
    {

        for (int i = 0; i < 12; i++)// 다지우고
        {
            obj[i].SetActive(false);
        }


        if (state == 0)// 색
        {
            for(int i = 0; i < 4; i++)// 보이게
            {
                obj[i].SetActive(true);
            }
        }
        else if (state == 1) // 크기
        {
            for (int i = 4; i < 7; i++)// 보이게
            {
                obj[i].SetActive(true);
            }
        }
        else// 동작
        {
            for (int i = 7; i < 12; i++)// 보이게
            {
                obj[i].SetActive(true);
            }
        }
        

    }
}
