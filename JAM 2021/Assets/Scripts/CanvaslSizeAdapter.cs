using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CanvaslSizeAdapter : MonoBehaviour{

    // Se definen el objeto padre y un vector que definirá las medidas (Ancho y alto) 
    // del objeto con sus repectivos factores de escala.
    public GameObject parent;
    private Vector2 sizeObject;
    public float factorX, factorY;

    public void ReSize(){
        sizeObject.x = parent.GetComponent<RectTransform>().sizeDelta.x * factorX;
        sizeObject.y = parent.GetComponent<RectTransform>().sizeDelta.y * factorY;
        this.gameObject.GetComponent<RectTransform>().sizeDelta = sizeObject;
        foreach(Transform child in this.transform){
            if(child.GetComponent<CanvaslSizeAdapter>() != null){
                child.GetComponent<CanvaslSizeAdapter>().ReSize();
            }
        }
    }
}
