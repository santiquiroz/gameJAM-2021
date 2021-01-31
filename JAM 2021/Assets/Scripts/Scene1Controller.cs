using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Controller : MonoBehaviour
{   
    public Dialogs sceneDialogs;
    private bool isDialogAnimationNotGoingIn = true;

    public void startDialog1(){
        Debug.Log("PUTA VIDA");
    }

    // Start is called before the first frame update
    void Start()
    {   
        sceneDialogs = new Dialogs();
       sceneDialogs.dialogos = GameManager.instance.dialogs.dialogos.FindAll(dialog => dialog.escena == 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDialogAnimationNotGoingIn){
            switch (GameManager.instance.user.ultimo_dialogo)
            {
                case 1 :
                    startDialog1();
                    isDialogAnimationNotGoingIn=false;
                    break;                    
                default:
                    break;
            }
        }
    }
}
