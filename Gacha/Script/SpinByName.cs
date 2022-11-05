using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpinByName : MonoBehaviour
{
    float speed = 100.0f;
    bool isPressed = false;
    public GameObject Gacha;
    [SerializeField] Button btnSpin;
    public Text txtResult;
    int i;
    string[] value()
    {
        string[] gift = new string[] { "5k", "10k", "20k", "Spin again", "50k", "30k", "100k", "Double", "200k", "Halve", "500k" };
        return gift;
    }
    // Start is called before the first frame update
    void Start()
    {
        btnSpin.onClick.AddListener(TogglePressed);
        i = Random.Range(1, 11);
        txtResult.text = value()[i];
    }
    public void TogglePressed()
    {
        isPressed = true;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float degree = Gacha.transform.eulerAngles.z;
        if (isPressed == true)
        {
            if (speed > 0)
            {
                Gacha.transform.Rotate(0, 0, speed * Time.deltaTime);
                for (int j = 0; j < 12; j++)
                {
                    if (360 / 11 * i <= degree && degree < 360 / 11 + 360 / 11 * i)
                    {
                        speed -= 0.3f;

                    }
                }
                btnSpin.onClick.AddListener(spinAgain2D);
            }
        }


        //Gacha.transform.Rotate(0,0,5f);
    }
    public void spinAgain2D()
    {
        SceneManager.LoadScene("Gacha");
    }
    
}
