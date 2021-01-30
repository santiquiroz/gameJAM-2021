using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour{

    void Start(){
        foreach (Transform child in this.transform){
            if(child.GetComponent<CanvaslSizeAdapter>() != null) child.GetComponent<CanvaslSizeAdapter>().ReSize();
        }
    }
}
