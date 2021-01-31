using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    void Start(){
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
    }
}
