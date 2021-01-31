using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Controller : MonoBehaviour{   
    public Dialogs sceneDialogs;
    
    private bool isDialogAnimationNotGoingIn = true;
    

    //Elementos de la UI
    public Text nameText, dialogText, button1OptionText, button2OptionText;
    public Image faceImage;
    public SpriteRenderer[] faceSprite;

    public void StartDialog1(Dialog dialogo){
        dialogText.text = "";
        nameText.text = dialogo.actor;
        StartCoroutine(AnimationText(dialogo.texto, dialogo.velocidad));
    } 

    void Start(){   
        sceneDialogs = new Dialogs();
        sceneDialogs.dialogos = GameManager.instance.dialogs.dialogos.FindAll(dialog => dialog.escena == 1);
    }

    void Update(){
        if(isDialogAnimationNotGoingIn){ 
            switch (GameManager.instance.user.ultimo_dialogo){
                case 1 :
                    StartDialog1(sceneDialogs.dialogos[0]);
                    isDialogAnimationNotGoingIn=false;
                    break;                    
                default:
                    break;
            }
        }
    }

    IEnumerator AnimationText(string text, float velocity){
        Debug.Log("Inicia");
        Debug.Log(text);
        Debug.Log(velocity);
        foreach(char Character in text){
            dialogText.text = dialogText.text + Character;
            /* yield return new WaitForSeconds(1 * Mathf.Abs(Mathf.Log(velocity / 2))); */
            yield return new WaitForSeconds(0.1f * velocity );
        }
    }

    public void ResizeFont(int newSize){
        dialogText.fontSize = newSize;
        button1OptionText.fontSize = newSize;
        button2OptionText.fontSize = newSize;
    }
}
