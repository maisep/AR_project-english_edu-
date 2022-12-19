using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_score : MonoBehaviour
{
    // Start is called before the first frame update


    public TextMeshProUGUI score;
    public TextMeshProUGUI timetext;

    public int MyScore = 0;
    public string[] answer = new string[4];//동물 , 색 ,사이즈 행동 

    public int timer = 30;
    float tiem = 0;

    public instance_script save;

    void Start()
    {
        Invoke("level_move", timer);
    }


    void level_move() {

        save.score = MyScore;
        SceneManager.LoadScene("Test_Score");
    }

    // Update is called once per frame
    void Update()
    {
        //answer_string.text = answer[2] +" "+ answer[1] + " " + answer[0] + " " + answer[3];
        score.text = "Score : " + MyScore;

        tiem += Time.deltaTime;
        timetext.text = string.Format("{0:N0}", tiem);
    }
}
