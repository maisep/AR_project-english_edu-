using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] text_all = new string[4]; // 문장 구성
    public TextMeshProUGUI text;


    public control[] ch_list;
    public int allscore = 100; // 필요없

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = text_all[0]+" "+ text_all[1] + " "+ text_all[2] + " "+ text_all[3];
    }


    public void reset_all()
    {
        for(int i = 0; i < ch_list.Length; i++)
        {
            ch_list[i].reset();
        }
    }
}
