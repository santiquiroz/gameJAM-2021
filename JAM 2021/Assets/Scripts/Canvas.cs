using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour{

    public GameObject[] NPC;

    void Start(){
        foreach (Transform child in this.transform){
            if(child.GetComponent<CanvaslSizeAdapter>() != null) child.GetComponent<CanvaslSizeAdapter>().ReSize();
        }
    }

    public void MenuPause(GameObject obj){
        obj.SetActive(!obj.activeInHierarchy);
        if(obj.name == "MenuPanel") Time.timeScale = 1 - Time.timeScale;
    }


    public void AppearNPC(bool ugah, bool paco, bool massimo, bool doctor, bool player, bool[] extra){
        NPC[0].SetActive(ugah);
        NPC[1].SetActive(ugah);
        NPC[2].SetActive(ugah);
        NPC[3].SetActive(ugah);
        NPC[4].SetActive(ugah);
        for(int i = 0; i < extra.Length; i++){
            NPC[5 + i].SetActive(extra[i]);
        }
    }
}
