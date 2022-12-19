using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class game_con : MonoBehaviour
{
    // Start is called before the first frame update


    public string[] text_all = new string[4]; // 문장 구성
    public TextMeshProUGUI text;// 텍스트
    public control[] ch_list;// 캐릭터들

    public AudioSource myaudio;//출력오디오
    public AudioClip[] Audios = new AudioClip[16];// 음성들  16번은 빈소리
   
    public int state = 0;// 현재 상태 >>>>>> 0~2;
    public bool change = false; // 바뀐다~

    public test stage;

    public int allscore = 100; // 필요없


    void Start()
    {

        //stage.spawn_prefeb(); // 세팅
    }

    // Update is called once per frame
    void Update()
    {
        text.text = text_all[0] + " " + text_all[1] + " " + text_all[2] + " " + text_all[3];
        

        if (change)// 변화 발생시 
        {
            stage.word_destroy();
            stage.delay_spawn();
            change = false;
        }


        if (index == 4)
        {
            CancelInvoke("playsound");
            index = 0;
            delay_reset();
        }
    }




    public void delay_reset() // 3초뒤 모든것 리셋
    {
        Invoke("reset_all", 2);

    }



    public void reset_all() // 모든캐릭터
    {
        for (int i = 0; i < ch_list.Length; i++)
        {
            ch_list[i].reset();
        }

        state = 0;
        change=true; // 다시 세팅
    }




    /// <summary>
    /// --------------------------------------소리
    /// </summary>
    private int index = 0;



    public void sound()
    {
        InvokeRepeating("playsound", 0.5f, 1.3f);// 2초마다 하나씩
    }


    public void playsound() // 음성출력
    {
        if (index == 4)
        {
            Debug.Log("------------");
            return;
        }

        if (text_all[index] != "")
        {
            Debug.Log("음성출력 " + index);
            for (int i = 0; i < 15; i++) 
            {
                if (Audios[i].name == text_all[index])
                {
                    Debug.Log("------------------------------------------");
                    myaudio.clip = Audios[i];
                    break;
                }

            }
            myaudio.Play();
        }
        index += 1;
    }


    public void gamequit()
    {
        Application.Quit();
    }
}


