using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightCar : MonoBehaviour
{
    private GameObject pointLightR;
    private GameObject pointLightL;
    private GameObject spotLightR;
    private GameObject spotLightL;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        // pega a luz do carro que esta dentro do prefab
        pointLightR = transform.Find("Pont Light R").gameObject;
        pointLightL = transform.Find("Pont Light L").gameObject;
        spotLightR = transform.Find("Spot Light R").gameObject;
        spotLightL = transform.Find("Spot Light L").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // time to turn on and off the lights
        time += Time.deltaTime;
        // segundos que ira desligar e ligar as luzes 10, 12, 14, 20, 21, 22, 24, 25, 26 , 33, 35, 37, 40, 41, 42, 44, 45, 46, 53, 55, 57
        if (isOff())
        {
            LightOnAndOff(false);
        }
        else
        {
            LightOnAndOff(true);
        }
        if (time > 60f){
            time = 0;
        }
    }

    // on and off the lights of the car
    public void LightOnAndOff(bool isOn)
    {
        pointLightR.SetActive(isOn);
        pointLightL.SetActive(isOn);
        spotLightR.SetActive(isOn);
        spotLightL.SetActive(isOn);
    }

    public bool isOff()
    {
        return (time > 10 && time < 11) || (time > 12 && time < 13) || (time > 14 && time < 15) || (time > 20 && time < 21) || (time > 22 && time < 23) || (time > 24 && time < 25) || (time > 26 && time < 27) || (time > 33 && time < 34) || (time > 35 && time < 36) || (time > 37 && time < 38) || (time > 40 && time < 41) || (time > 42 && time < 43) || (time > 44 && time < 45) || (time > 46 && time < 47) || (time > 53 && time < 54) || (time > 55 && time < 56) || (time > 57 && time < 58);
    }
}
