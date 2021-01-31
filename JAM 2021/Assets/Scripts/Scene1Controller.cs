using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Controller : MonoBehaviour {
    public Dialogs sceneDialogs;
    private bool isDialogFinished = true;
    private bool isDialogAnimationNotGoingOn = false;

    //Elementos de la UI
    public Text nameText, dialogText, button1OptionText, button2OptionText;
    public Image faceImage;
    public Sprite[] faceSprite;
    public GameObject nextButton, option1Button, option2Button;

    public void StartDialog1(Dialog dialogo){
        dialogText.text = "";
        nameText.text = dialogo.actor;
        ChangeMiniatureImage(dialogo.actor);
        StartCoroutine(AnimationText(dialogo));
    } 
    private void StartDialog2(Dialog dialogo){
        dialogText.text = "";
        nameText.text = dialogo.actor;
        ChangeMiniatureImage(dialogo.actor);
        StartCoroutine(AnimationText(dialogo));
    } 
    private void StartDialog3(Dialog dialogo){
        dialogText.text = "";
        nameText.text = dialogo.actor;
        ChangeMiniatureImage(dialogo.actor);
        StartCoroutine(AnimationText(dialogo));
    } 


    void Start(){   
        sceneDialogs = new Dialogs();
        sceneDialogs.dialogos = GameManager.instance.dialogs.dialogos.FindAll(dialog => dialog.escena == 1);
    }

    void Update(){
        if(isDialogFinished){ 
            switch(GameManager.instance.user.ultimo_dialogo){
                case 1 :
                    StartDialog1(sceneDialogs.dialogos[0]);
                    isDialogFinished=false;
                    break;
                case 2 :
                    StartDialog2(sceneDialogs.dialogos[1]);
                    isDialogFinished=false;
                    break;
                case 3 :
                    StartDialog3(sceneDialogs.dialogos[2]);
                    isDialogFinished=false;
                    break;
                default:
                    break;
            }
        }
    }

    private void GoToNextDialog(int i){
        GameManager.instance.user.ultimo_dialogo += i;
        isDialogFinished=true;
    }

    public void MakeDesition (int desition) {
        GameManager.instance.user.decisiones.Add(1.ToString()+'-'+GameManager.instance.user.ultimo_dialogo.ToString()+'-'+desition.ToString());
        GoToNextDialog(desition);
        ToogleButtons();
    }

    public void NextButtonListener(){
        if(isDialogAnimationNotGoingOn){
            isDialogAnimationNotGoingOn=false;
        }
        else{
            GoToNextDialog(1);
        }
    }
    private void ToogleButtons(){
        /*if(nextButton.activeInHierarchy){
            nextButton.SetActive(false);
            option1Button.SetActive(true);
            option2Button.SetActive(true);
        }
        else{
            nextButton.SetActive(true);
            option1Button.SetActive(false);
            option2Button.SetActive(false);
        }*/
        nextButton.SetActive(!nextButton.activeInHierarchy);
        option1Button.SetActive(!option1Button.activeInHierarchy);
        option2Button.SetActive(!option2Button.activeInHierarchy);
    }

    IEnumerator AnimationText(Dialog dialogo){
        string text = dialogo.texto;
        float velocity = dialogo.velocidad;
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
        if(dialogo.decisiones.Count > 0){
            ToogleButtons();
        }
    }

    public void ResizeFont(int newSize){
        dialogText.fontSize = newSize;
        button1OptionText.fontSize = newSize;
        button2OptionText.fontSize = newSize;
    }

    private void ChangeMiniatureImage(string actorName){
        if(actorName == "Ugah") faceImage.sprite = faceSprite[0];
        else if(actorName == "Paco") faceImage.sprite = faceSprite[1];
        else if(actorName == "Massimo") faceImage.sprite = faceSprite[2];
        else if(actorName == "Doctor") faceImage.sprite = faceSprite[3];
        else faceImage.sprite = null;
    }
}
