using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
   public static VibrationManager instance;

    private void Awake()
    {
        if (instance != null && instance !=this)
        {
            Destroy(this.gameObject);
            return; 
        }

        instance = this;
        DontDestroyOnLoad(gameObject);      
    }

    public void VibrateController(float duration,float frequency,float amplitude, OVRInput.Controller controller)
    {
        StartCoroutine(vibrateforsec(duration, frequency, amplitude, controller));  

    }

    IEnumerator vibrateforsec(float duration , float frequency , float amplitude , OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);  


        yield return new WaitForSeconds(duration);  

        OVRInput.SetControllerVibration(0,0,controller);    
    }
}
