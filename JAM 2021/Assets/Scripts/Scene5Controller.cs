using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene5Controller : MonoBehaviour{
    public Dialogs sceneDialogs;
    private bool isDialogFinished = true;
    private bool isDialogAnimationNotGoingOn = false;

    //Elementos de la UI
    public Text nameText, dialogText, button1OptionText, button2OptionText;
    public Image faceImage;
    public Sprite[] faceSprite;
    public GameObject nextButton, option1Button, option2Button;

    public Sprite[] flashbacks;
    public Image flashbackImage;
    public void StartDialog(Dialog dialogo){
        switch (dialogo.id){
            case 1:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                break;
            default:
                break;
        }
    }

    void Start(){
        GameManager.instance.user.ultima_escena = 5;
        GameManager.instance.user.ultimo_dialogo = 1;
        sceneDialogs = new Dialogs();
        sceneDialogs.dialogos = GameManager.instance.dialogs.dialogos.FindAll(dialog => dialog.escena == 4);
    }

    void Update(){
        if(isDialogFinished){
            switch (GameManager.instance.user.ultimo_dialogo){
                case 1:
                    StartDialog(sceneDialogs.dialogos[0]);
                    isDialogFinished = false;
                    break;
                default:
                    break;
            }
        }
    }

    private void GoToNextDialog(int decision){
        var currentDialog = sceneDialogs.dialogos.FindAll(dialog => dialog.id == GameManager.instance.user.ultimo_dialogo)[0];
        int nextDialogID = currentDialog.siguiente[decision - 1];

        Debug.Log("siguiente" + nextDialogID);

        GameManager.instance.user.ultimo_dialogo = nextDialogID;
        isDialogFinished = true;
    }

    public void MakeDesition(int desition){
        GameManager.instance.user.decisiones.Add(1.ToString() + '-' + GameManager.instance.user.ultimo_dialogo.ToString() + '-' + desition.ToString());
        GoToNextDialog(desition);
        ToogleButtons();
    }

    public void NextButtonListener(){
        if (isDialogAnimationNotGoingOn) isDialogAnimationNotGoingOn = false;
        else GoToNextDialog(1);
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
        foreach (char Character in text){
            dialogText.text = dialogText.text + Character;
            if (isDialogAnimationNotGoingOn) yield return new WaitForSeconds(0.1f * velocity);
            yield return new WaitForSeconds(0);

        }
        isDialogAnimationNotGoingOn = false;
        if (dialogo.decisiones.Count > 0){
            option1Button.GetComponentInChildren<Text>().text = dialogo.decisiones[0];
            option2Button.GetComponentInChildren<Text>().text = dialogo.decisiones[1];
            ToogleButtons();
        }
    }

    IEnumerator FinalAnimationText(Dialog dialogo){
        string text = dialogo.texto;
        float velocity = dialogo.velocidad;
        isDialogAnimationNotGoingOn = true;
        GameManager.instance.user.ultima_escena = 1;
        GameManager.instance.user.ultimo_dialogo = 10;
        foreach (char Character in text){
            dialogText.text = dialogText.text + Character;
            if (isDialogAnimationNotGoingOn) yield return new WaitForSeconds(0.1f * velocity);
            yield return new WaitForSeconds(0);

        }
        isDialogAnimationNotGoingOn = false;
        GameManager.instance.ChangeScene(1);
    }

    IEnumerator ProyectFlashback(){
        flashbackImage.gameObject.SetActive(true);
        foreach(Sprite flash in flashbacks){
            flashbackImage.sprite = flash;
            yield return new WaitForSeconds(5.0f);
        }
        flashbackImage.gameObject.SetActive(false);
    }

    public void ResizeFont(int newSize){
        dialogText.fontSize = newSize;
        button1OptionText.fontSize = newSize;
        button2OptionText.fontSize = newSize;
    }

    private void ChangeMiniatureImage(string actorName){
        if (actorName == "Ugah") faceImage.sprite = faceSprite[0];
        else if (actorName == "Paco") faceImage.sprite = faceSprite[1];
        else if (actorName == "Massimo") faceImage.sprite = faceSprite[2];
        else if (actorName == "Doctor") faceImage.sprite = faceSprite[3];
        else faceImage.sprite = null;
    }
}