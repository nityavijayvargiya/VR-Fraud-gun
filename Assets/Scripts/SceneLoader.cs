using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [SerializeField] OVROverlay background; 
    [SerializeField] OVROverlay loading_text;

   

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return; 
        }

        Instance = this;
        DontDestroyOnLoad(Instance);    
    }
    public void LoadScene(string sceneName)
    {
           StartCoroutine(showoverlayandload(sceneName));                
    }

    private IEnumerator showoverlayandload(string sceneName)
    {
        background.enabled = true;  
        loading_text.enabled = true;

        GameObject centerEyeAnchor = GameObject.Find("CenterEyeAnchor");

        loading_text.gameObject.transform.position = centerEyeAnchor.transform.position + new Vector3(0,0,3f);    

            yield return new WaitForSeconds(6f); 
        
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);  

        while(!asyncLoad.isDone) 
        {
          yield return null; 
        }

        background.enabled = false;
        loading_text.enabled = false;   

        yield return null;
    }
}
