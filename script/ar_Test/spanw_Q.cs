using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spanw_Q : MonoBehaviour
{

    public Transform[] target = new Transform[4];// 좌표들


    public GameObject[] animals = new GameObject[4];
    public GameObject[] col = new GameObject[4];
    public GameObject[] size = new GameObject[3];
    public GameObject[] act = new GameObject[4];



    List<Vector3> save_target = new List<Vector3>();//생성된 위치
    List<GameObject> spawn_obj = new List<GameObject>(); // 생성된 액터들
    private Quaternion rota;

    public int index = 0;// 몇번째인지   

    // Start is called before the first frame update
    void Start()
    {
        rota = target[0].transform.rotation;
        index = 0;
        //delay_spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void delay_spawn()
    {
        Invoke("spawn_cal", 3);
    }

    public void spawn_cal()//단계에 맞게 생성    //동물 , 색 ,사이즈 행동 
    {
        if (index == 0)
        {
            random_for(4);
            spawn_prefeb(animals);
        }
        else if (index==1)
        {
            random_for(4);
            spawn_prefeb(col);
        }
        else if (index == 2)
        {
            random_for(3);
            spawn_prefeb(size);
        }
        else
        {
            random_for(4);
            spawn_prefeb(act);
            index = 0;
            return;
        }

        index += 1;
    }



    public void destroy_word()// 단어제거
    {
        
        for (int i = 0; i < spawn_obj.Count; i++) {
            Destroy(spawn_obj[i]);
        }
        spawn_obj.Clear();

    }


    public void spawn_prefeb(GameObject[] word)//단어생성
    {
        for (int i=0;i< word.Length; i++)
        {
            GameObject temp = Instantiate(word[i], save_target[i], rota);
            temp.transform.parent = this.transform;
            spawn_obj.Add(temp);
        }
    }



    public void random_for(int n) // 랜덤 좌표뽑기함수
    {
        save_target.Clear();
        int num = 0;

        for (int i = 0; i < n; i++)
        {
            num = Random.Range(0, n);
            while (true)
            {
                if (save_target.Contains(target[num].transform.position))
                {
                    num = Random.Range(0, n);
                }
                else
                {
                    save_target.Add(target[num].transform.position);
                    break;
                }
            }
        }
    }



}
