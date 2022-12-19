using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class My_ans_check : MonoBehaviour
{
    // Start is called before the first frame update


    
    private int index = 0;
    public GameObject[] zoo=new GameObject[5];
    public My_answer[] zoo_fun = new My_answer[5];

    private int sel_zoo=0;

    public GameObject corr_text;
    public GameObject wron_text;





    public Test_score save_answer;
    public Test_score score;
    public Answer_ch question;
    public spanw_Q spawn;

    void Start()
    {
        all_reset();
        corr_text.SetActive(false);
        wron_text.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other) // 추돌시?  // 동물 색 사이즈 행동
    {
        Debug.Log("? "+index);
        Debug.Log(save_answer.answer[index]);

        spawn.destroy_word();



        string memo = other.name.Replace("(Clone)", "");
        Debug.Log(memo);


        
        if (save_answer.answer[index]== memo)// 맞다면 계속진행
        {
            Debug.Log("-0--" + sel_zoo);
            if (index == 0)
            {
                zoo[0].SetActive(false);
                for (int i = 0; i < zoo.Length; i++)
                {
                    if (zoo[i].name == memo)
                    {
                        sel_zoo = i;
                        break;
                    }
                }
                zoo[sel_zoo].SetActive(true);
                spawn.delay_spawn();
            }
            else if (index == 1)
            {
                Debug.Log("-mat--" + sel_zoo);
                zoo_fun[sel_zoo].findcol(memo);
                spawn.delay_spawn();
            }
            else if (index == 2)
            {
                zoo_fun[sel_zoo].size_ch(memo); 
                spawn.delay_spawn();
            }
            else
            {
                zoo_fun[sel_zoo].update_state(memo);
            }

            index += 1;
           
        }
        else
        {
            wrong();
        }

        if (index == 4)
        {
            correct();
        }
    }


    void all_reset()
    {
        //
        question.setting();
        for (int i = 1; i < 5; i++)
        {
            
            zoo[i].SetActive(false);
            Debug.Log(zoo[i].name);

        }
       
        zoo[0].SetActive(true);
        index = 0;
        sel_zoo = 0;
        //spawn.destroy_word();


        spawn.index = 0;
        spawn.delay_spawn();
    }


    void correct()
    {
        score.MyScore += 1;
        Invoke("cor_delay_anim", 0.5f);
        Invoke("reset_anim", 2);

        Invoke("erase", 2);
        Invoke("all_reset",2);
        
    }


    void wrong()
    {
        Debug.Log("틀렸습니다...");



        anim_ox(1);
        Invoke("reset_anim", 2);


        Invoke("erase", 2);
        Invoke("all_reset", 2);
       
    }


    

    void erase()
    {

        zoo_fun[sel_zoo].Reset_zoo();
    }


    void reset_anim()
    {
        anim_ox(2);
    }

    void cor_delay_anim()
    {
        anim_ox(0);
    }

    void anim_ox(int i)
    {
        if (i == 0)// 정답
        {
            corr_text.SetActive(true);
        }
        else if(i==1)//오답
        {
            wron_text.SetActive(true);
        }
        else//리셋
        {
            corr_text.SetActive(false);
            wron_text.SetActive(false);
        }
        
    }

}
