using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Configuracion {
    public int volumen;
}

[System.Serializable]
public class SystemData {
    public Configuracion configuracion;
}

[System.Serializable]
public class User{
    public int id;
    public int ultima_escena;
    public int ultimo_dialogo;
    public List<string> decisiones;
    public List<string> finales;
}

[System.Serializable]
public class SystemClass {
    public List<User> usuarios;
    public SystemData sistema;
}

[System.Serializable]
public class Dialog {
    public List<string> dialogo;
}

[System.Serializable]
public class Dialogs {
    public List<Dialog> dialogos;
}



public class GameManager : MonoBehaviour{
    public SystemClass system;
    public User user;

    public Dialogs dialogs;
    public Dialog dialog;

    public string ReadFromFile (string fileName) {
        string path= fileName;
            using (StreamReader reader = new StreamReader(path)){
                string json = "";
                string line;
                while ((line = reader.ReadLine()) != null)
                {   
                    json = json + line;
                }
                return json;
            }
            return "" ;
        }

    public void Save(){

    }
        
    void LoadData (){
        string aux = this.ReadFromFile(Application.dataPath+"/Storage/system.JSON");
        system = JsonUtility.FromJson<SystemClass>(aux);
        user=system.usuarios[0];

        //en el futuro implemetar que se pueda cargar varios usuarios y que los dialogos se carguen solo desde el iicio de la escena
        aux = this.ReadFromFile(Application.dataPath+"/Storage/dialogs.JSON");
        dialogs = JsonUtility.FromJson<Dialogs>(aux);
    }

    void Start(){
        DontDestroyOnLoad(this.gameObject);
        LoadData();        

    }

    public void LetsStart(){
        ChangeScene(user.ultima_escena);
    }

    public void ChangeScene(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
    }
}
