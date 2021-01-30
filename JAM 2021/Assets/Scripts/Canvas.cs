using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour{

    void Start(){
        //var childrenGameObject = this.gameObject.GetComponentInChildren<Transform>();
        foreach (Transform child in this.transform){
            child.GetComponent<CanvaslSizeAdapter>().ReSize();
        }
    }

    void Update(){
        //var childrenGameObject = this.gameObject.GetComponentInChildren<Transform>();
        foreach (Transform child in this.transform){
            child.GetComponent<CanvaslSizeAdapter>().ReSize();
        }
    }
}
