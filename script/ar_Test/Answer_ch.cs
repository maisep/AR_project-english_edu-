using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_ch : MonoBehaviour
{


    public GameObject[] prefab;// 고양이 개 사자 새

    public answer_ch_mode[] answer_ch_mode; // 각 동물의 함수일듯 >> 

    private int random_ind = 0;

    public Test_score save_answer;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //Reset();
        //Invoke("setting", 3);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        for (int i = 0; i < 4; i++)
        {
            prefab[i].SetActive(false);
        }
    }



    public void setting()
    {
        Reset();
        random_ind = Random.Range(0, 4);// 캐릭터 설정
        prefab[random_ind].SetActive(true);
        save_answer.answer[0] = prefab[random_ind].name;// 답저장

        answer_ch_mode[random_ind].setting(); // 설정후 랜덤설정
    }



   






}

