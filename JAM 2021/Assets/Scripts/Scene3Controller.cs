using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene3Controller : MonoBehaviour
{
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
        switch (dialogo.id)
        {   
            case 1:
                dialogText.text = "";
                nameText.text = dialogo.actor;
                ChangeMiniatureImage(dialogo.actor);
                StartCoroutine(AnimationText(dialogo));
                GameManager.instance.massimoCheck = true;
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
                StartCoroutine(ProyectFlashback());
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
                StartCoroutine(FinalAnimationText(dialogo));
                break;
            default:
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.user.ultima_escena = 3;
        GameManager.instance.user.ultimo_dialogo = 1;

        sceneDialogs = new Dialogs();
        sceneDialogs.dialogos = GameManager.instance.dialogs.dialogos.FindAll(dialog => dialog.escena == 3);
    }

    // Update is called once per frame
    void Update()
    {
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
                default:
                    break;
            }
        }
    }

    private void GoToNextDialog(int decision){
              
        var currentDialog = sceneDialogs.dialogos.FindAll(dialog => dialog.id == GameManager.instance.user.ultimo_dialogo)[0];
        int nexDialogId =  currentDialog.siguiente[decision -1];

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
                //en el futuro cambiarlo por 1/20 *velocidad * factor dado por la configuracion del sistema
                yield return new WaitForSeconds(0.1f * velocity );
            }
            yield return new WaitForSeconds(0);
            
        }
        isDialogAnimationNotGoingOn= false;
        if(dialogo.decisiones.Count > 0){
            option1Button.GetComponentInChildren<Text>().text=dialogo.decisiones[0];
            option2Button.GetComponentInChildren<Text>().text=dialogo.decisiones[1];
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
            yield return new WaitForSeconds(10.0f);
        }
        flashbackImage.gameObject.SetActive(false);
    }

    public void ResizeFont(int newSize){
        dialogText.fontSize = newSize;
        button1OptionText.fontSize = newSize;
        button2OptionText.fontSize = newSize;
    }

    private void ChangeMiniatureImage(string actorName){
        faceImage.color = new Color(255, 255, 255, 255);
        if (actorName == "Ugah") faceImage.sprite = faceSprite[0];
        else if (actorName == "Paco") faceImage.sprite = faceSprite[1];
        else if (actorName == "Massimo") faceImage.sprite = faceSprite[2];
        else if (actorName == "Doctor") faceImage.sprite = faceSprite[3];
        else faceImage.color = new Color(0, 0, 0, 0);
    }
}
