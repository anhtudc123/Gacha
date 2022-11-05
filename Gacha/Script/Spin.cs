using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    float speed = 100.0f;
    bool isPressed = false;
    float spinningTime;
    public GameObject Gacha;
    [SerializeField] Button btnSpin;
    public Text txtResult;

    // Start is called before the first frame update
    void Start()
    {
        btnSpin.onClick.AddListener(TogglePressed);
        spinningTime = UnityEngine.Random.Range(4.0f, 6.0f);
    }
    public void TogglePressed()
    {
        isPressed = true;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float degree = Gacha.transform.eulerAngles.z;
        float spinningSpeed = speed * spinningTime;
        if (isPressed == true)
        {
            if (spinningSpeed > 0)
            {
                Gacha.transform.Rotate(0, 0, spinningSpeed * Time.deltaTime);
                spinningTime -= Time.deltaTime;  
            }
            if(spinningSpeed <= 0)
            {
                spinningSpeed = 0;
                for (int i = 0; i < 12; i++)
                {
                    if (360/11 * i <= degree && degree < 360/11+360/11 * i)
                    {
                        txtResult.text = value()[i];
                        
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
    string[] value()
    {
        string[] gift = new string[] { "5k", "10k", "20k", "Spin again", "50k", "30k", "100k", "Double", "200k", "Halve", "500k"};
        return gift;
    }
}
