using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Controller : MonoBehaviour{   
    public Dialogs sceneDialogs;
    private bool isDialogFinished = true;
    private bool isDialogAnimationNotGoingOn = false;

    

    //Elementos de la UI
    public Text nameText, dialogText, button1OptionText, button2OptionText;
    public Image faceImage;
    public Sprite[] faceSprite;

    public void StartDialog1(Dialog dialogo){
        dialogText.text = "";
        nameText.text = dialogo.actor;
        StartCoroutine(AnimationText(dialogo.texto, dialogo.velocidad));
    } 
     public void StartDialog2(Dialog dialogo){
        dialogText.text = "";
        nameText.text = dialogo.actor;
        StartCoroutine(AnimationText(dialogo.texto, dialogo.velocidad));
    } 

    void Start(){   
        sceneDialogs = new Dialogs();
        sceneDialogs.dialogos = GameManager.instance.dialogs.dialogos.FindAll(dialog => dialog.escena == 1);
    }

    void Update(){
        if(isDialogFinished){ 
            switch (GameManager.instance.user.ultimo_dialogo){
                case 1 :
                    StartDialog1(sceneDialogs.dialogos[0]);
                    isDialogFinished=false;
                    break;
                case 2 :
                    StartDialog2(sceneDialogs.dialogos[1]);
                    isDialogFinished=false;
                    break;
                default:
                    break;
            }
        }
    }

    void goToNextDialog(){
        GameManager.instance.user.ultimo_dialogo ++;
        isDialogFinished=true;
    }

    public void nextButtonListener(){
        if(isDialogAnimationNotGoingOn){
            isDialogAnimationNotGoingOn=false;
        }
        else{
            goToNextDialog();
        }
    }

    IEnumerator AnimationText(string text, float velocity){
        isDialogAnimationNotGoingOn = true;
        foreach(char Character in text){
            dialogText.text = dialogText.text + Character;
            /* yield return new WaitForSeconds(1 * Mathf.Abs(Mathf.Log(velocity / 2))); */
            if(isDialogAnimationNotGoingOn){
                yield return new WaitForSeconds(0.1f * velocity );
            }
            yield return new WaitForSeconds(0);
            
        }
        isDialogAnimationNotGoingOn= false;
    }

    public void ResizeFont(int newSize){
        dialogText.fontSize = newSize;
        button1OptionText.fontSize = newSize;
        button2OptionText.fontSize = newSize;
    }
}
