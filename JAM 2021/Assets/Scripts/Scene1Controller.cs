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

    //Botones finales
    public GameObject ugahButton, pacoButton, massimoButton;

    public void StartDialog(Dialog dialogo){
        switch (dialogo.id)
        {   
            case 1:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 2:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 3:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 4:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 5:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 6:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 7:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 8:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 9:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            case 10:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(FinalAnimationText(dialogo));
                break;
            default:
                break;
        }
    }

    void Start(){   
        sceneDialogs = new Dialogs();
        sceneDialogs.dialogos = GameManager.instance.dialogs.dialogos.FindAll(dialog => dialog.escena == 1);
    }

    void Update(){
        if(isDialogFinished){ 
            switch(GameManager.instance.user.ultimo_dialogo){
                case 1 :
                    StartDialog(sceneDialogs.dialogos[0]);
                    isDialogFinished=false;
                    break;
                case 2 :
                    StartDialog(sceneDialogs.dialogos[1]);
                    isDialogFinished=false;
                    break;
                case 3 :
                    StartDialog(sceneDialogs.dialogos[2]);
                    isDialogFinished=false;
                    break;
                case 4 :
                    StartDialog(sceneDialogs.dialogos[3]);
                    isDialogFinished=false;
                    break;
                case 5 :
                    StartDialog(sceneDialogs.dialogos[4]);
                    isDialogFinished=false;
                    break;
                case 6 :
                    StartDialog(sceneDialogs.dialogos[5]);
                    isDialogFinished=false;
                    break;
                case 7 :
                    StartDialog(sceneDialogs.dialogos[6]);
                    isDialogFinished=false;
                    break;
                case 8 :
                    StartDialog(sceneDialogs.dialogos[7]);
                    isDialogFinished=false;
                    break;
                case 9 :
                    StartDialog(sceneDialogs.dialogos[8]);
                    isDialogFinished=false;
                    break;
                case 10 :
                    StartDialog(sceneDialogs.dialogos[9]);
                    isDialogFinished=false;
                    break;
                default:
                    break;
            }
        }
    }

    private void GoToNextDialog(int decision){
              
        var currentDialog = sceneDialogs.dialogos.FindAll(dialog => dialog.id == GameManager.instance.user.ultimo_dialogo)[0];
        int nexDialogId =  currentDialog.siguiente[decision -1];

        Debug.Log("siguiente" + nexDialogId);

        GameManager.instance.user.ultimo_dialogo = nexDialogId;
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
    private void ToogleFinalButtons(){
        
        ugahButton.SetActive(!nextButton.activeInHierarchy);
        pacoButton.SetActive(!option1Button.activeInHierarchy);
        massimoButton.SetActive(!option2Button.activeInHierarchy);
    }

    IEnumerator FinalAnimationText(Dialog dialogo){
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
            ToogleFinalButtons();
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
