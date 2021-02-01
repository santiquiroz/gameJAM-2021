using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RectTransform))]
public class CanvaslSizeAdapter : MonoBehaviour{

    // Se definen el objeto padre y un vector que definir� las medidas (Ancho y alto) 
    // del objeto con sus repectivos factores de escala.
    public GameObject parent;
    private Vector2 sizeObject;
    public float factorX, factorY;
    public Vector3 originalPosition;
    public int sizeFont;

    float Signo(float number){
        if(number != 0) return number / Mathf.Abs(number);
        else return 0;
    }

    public void ReSize(){
        sizeObject.x = parent.GetComponent<RectTransform>().sizeDelta.x * factorX;
        sizeObject.y = parent.GetComponent<RectTransform>().sizeDelta.y * factorY;
        this.gameObject.GetComponent<RectTransform>().sizeDelta = sizeObject;
        this.gameObject.GetComponent<RectTransform>().anchoredPosition =
            new Vector3(sizeObject.x * originalPosition.x,sizeObject.y * originalPosition.y, 0) * 0.577f;
        foreach(Transform child in this.transform){
            if(child.GetComponent<CanvaslSizeAdapter>() != null){
                child.GetComponent<CanvaslSizeAdapter>().ReSize();
            }
        }
        if(GameObject.Find("Player") != null){
            if (this.gameObject.name == "PanelText") GameObject.Find("Player").GetComponent<Scene1Controller>().ResizeFont(
             Mathf.RoundToInt((sizeObject.x / 224) * (sizeObject.y / 121) * 16));
        }
        /*else if (GameObject.Find("Player2") != null){
            if (this.gameObject.name == "PanelText") GameObject.Find("Player2").GetComponent<Scene2Controller>().ResizeFont(
             Mathf.RoundToInt((sizeObject.x / 224) * (sizeObject.y / 121) * 16));
        }
        else if (GameObject.Find("Player3") != null){
            if (this.gameObject.name == "PanelText") GameObject.Find("Player3").GetComponent<Scene3Controller>().ResizeFont(
             Mathf.RoundToInt((sizeObject.x / 224) * (sizeObject.y / 121) * 16));
        }*/
        else if (GameObject.Find("Player4") != null){
            if (this.gameObject.name == "PanelText"){
                Debug.Log((sizeObject.x / 224) * (sizeObject.y / 121) * 16);
                GameObject.Find("Player4").GetComponent<Scene4Controller>().ResizeFont(
                    Mathf.RoundToInt((sizeObject.x / 224) * (sizeObject.y / 121) * 16));
            }
        }
        /*else if (GameObject.Find("Player5") != null){
            if (this.gameObject.name == "PanelText") GameObject.Find("Player5").GetComponent<Scene5Controller>().ResizeFont(
             Mathf.RoundToInt((sizeObject.x / 224) * (sizeObject.y / 121) * 16));
        }
        else if (GameObject.Find("Player6") != null){
            if (this.gameObject.name == "PanelText") GameObject.Find("Player6").GetComponent<Scene6Controller>().ResizeFont(
             Mathf.RoundToInt((sizeObject.x / 224) * (sizeObject.y / 121) * 16));
        }
        else if (GameObject.Find("Player7") != null){
            if (this.gameObject.name == "PanelText") GameObject.Find("Player7").GetComponent<Scene7Controller>().ResizeFont(
             Mathf.RoundToInt((sizeObject.x / 224) * (sizeObject.y / 121) * 16));
        }*/
    }
}
