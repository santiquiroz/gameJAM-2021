using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Controller : MonoBehaviour
{   
    private bool isDialogAnimationNotGoingIn = true;

    public void startDialog1(){
        Debug.Log("PUTA VIDA");
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isDialogAnimationNotGoingIn){
            switch (gameObject.GetComponent<GameManager>().user.ultimo_dialogo)
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
