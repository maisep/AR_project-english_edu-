using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_answer : MonoBehaviour
{
    public Material[] mat = new Material[4]; // 색


    public int size_obj;// 0~2 크기순
    public string[] states = new string[3]; // 동작

    public MeshRenderer[] chi_matArray;// 고양이
    public GameObject dog_lion_mat;//강아지, 사자
    public GameObject birds_mat;//새

    SkinnedMeshRenderer[] chi_skinnedMeshArray; // 사자, 개
    Animation anim_state;
    Animator anim;

    private string now_State = "stand";

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


    public void findcol(string col)
    {
        
        
        for (int i = 0; i < mat.Length; i++)
        {
            if (mat[i].name == col)
            {
                anim_mat_save();
                mat_change(mat[i]);
                return;
            }
        }

    }


    void mat_change(Material mat)
    {

        Debug.Log("__1___" + gameObject.name);

        if (gameObject.name == "Bird")
        {
            Debug.Log("__111___" + mat.name);
            //GameObject obj = GameObject.Find("Condor_col"); // 새는..... 따로
            birds_mat.GetComponent<SkinnedMeshRenderer>().material = mat;

        }
        else if (gameObject.name == "Cat")
        {
            Debug.Log("__222___" + mat.name);
            for (int j = 0; j < chi_matArray.Length; j++)// 자식 머터리얼 변경
            {
                chi_matArray[j].material = mat;
            }
        }
        else // 사자 개 
        {
            Debug.Log("사자하고 개");
            Debug.Log("__333___" + mat.name);
            for (int j = 0; j < chi_skinnedMeshArray.Length; j++)// 자식 머터리얼 변경
            {
                chi_skinnedMeshArray[j].material = mat;
            }
        }


    }


    public void size_ch(string size) // 사이즈 정하기
    {

        if (size == "big")
        {

            gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);


        }
        else if (size == "small")
        {

            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);


        }
        else
        {

            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
    }


    public void update_state(string state)// 행동변경
    {

        anim.SetBool(now_State, false);
        anim.SetBool(state, true);
        now_State = state;
    }


    public void Reset_zoo()// 리셋
    {
        findcol("normal");
        size_ch("normal");
        update_state("stand");
    }

}
