using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_al : MonoBehaviour
{
    // Start is called before the first frame update


    public TextMeshProUGUI score;
    public instance_script save;
    void Start()
    {
        score.text = "Your Score : " + save.score + " !";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
