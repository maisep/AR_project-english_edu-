using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer_ch_mode : MonoBehaviour
{
    
    public Material[] mat = new Material[4]; // 색


    public int size_obj;// 0~2 크기순
    public string[] states = new string[3]; // 동작

    MeshRenderer[] chi_matArray;// 고양이
    public GameObject dog_lion_mat;//강아지, 사자
    public GameObject birds_mat;//새

    SkinnedMeshRenderer[] chi_skinnedMeshArray; // 사자, 개
    Animation anim_state;
    Animator anim;

    private string now_State="stand";

    private int random_ind=0;
    public Test_score save_answer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void anim_mat_save()// anim save , anim
    {
        anim = GetComponent<Animator>();
        if (gameObject.name != "Bird")
        {
            if (gameObject.name == "Cat")
            {
                chi_matArray = gameObject.GetComponentsInChildren<MeshRenderer>();
            }
            else
            {
               
                chi_skinnedMeshArray = dog_lion_mat.GetComponentsInChildren<SkinnedMeshRenderer>();
            }

        }

    }


    void mat_change(Material mat)
    {
       


        save_answer.answer[1] = mat.name;// 답저장
        if (gameObject.name == "Bird")
        {
            
            birds_mat.GetComponent<SkinnedMeshRenderer>().material = mat;

        }
        else if (gameObject.name == "Cat")
        {
            for (int j = 0; j < chi_matArray.Length; j++)// 자식 머터리얼 변경
            {
                chi_matArray[j].material = mat;
            }
        }
        else // 사자 개 
        {
            for (int j = 0; j < chi_skinnedMeshArray.Length; j++)// 자식 머터리얼 변경
            {
                chi_skinnedMeshArray[j].material = mat;
            }
        }

        //if (mat.name != "normal")
        //{
        //    sentence.text_all[1] = mat.name;
        //}
    }

    void size_ch(int size) // 사이즈 정하기
    {
       
        if (size == 0)
        {
            save_answer.answer[2] = "big";// 답저장
            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            //sentence.text_all[0] = size;

        }
        else if (size == 1)
        {
            save_answer.answer[2] = "small";// 답저장
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            //sentence.text_all[0] = size;

        }
        else
        {
            save_answer.answer[2] = "normal";// 답저장
            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }

    void update_state(string state)// 행동변경
    {
        save_answer.answer[3] = state;// 답저장
        anim.SetBool(now_State, false);

        anim.SetBool(state, true);
        now_State = state;

    }


    public void setting()
    {
        anim_mat_save();// 골격 저장

        random_ind = Random.Range(0, 4); // 머터리얼 변경
        mat_change(mat[random_ind]);

        random_ind = Random.Range(0, 3); // 크기 변경
        size_ch(random_ind);

        random_ind = Random.Range(0, 3); // 애님변경

        update_state(states[random_ind]);

    }



}
