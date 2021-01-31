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



public class GameManager : MonoBehaviour{
    public SystemClass system;
    public User user;

    public string ReadFromFile (string fileName) {
        string path= fileName;
            using (StreamReader reader = new StreamReader(path)){
                /* string json = reader.ReadEnd(); */
                string json = "";
                string line;
                while ((line = reader.ReadLine()) != null)
                {   
                    json = json + line;
                }
                /* string json = reader.ReadAllText(); */
                return json;
            }
            return "" ;
        }
        

    void Start(){
        DontDestroyOnLoad(this.gameObject);

        /* string systemJsonCrudo = File.ReadAllText(Application.dataPath +"/Storage/system.JSON");
        system = JsonUtility.FromJson<SystemClass>(systemJsonCrudo); */
        string aux = this.ReadFromFile(Application.dataPath+"/Storage/system.JSON");
        Debug.Log(aux);
        system = new SystemClass();
        system = JsonUtility.FromJson<SystemClass>(aux);
        /* JsonUtility.FromJsonOverwrite(aux,system); */
        /* foreach (User user in system.usuarios)
        {
            Debug.Log("Found user: " + user.id + " " + user.ultima_escena);
        } */
        Debug.Log(system);
        Debug.Log("Volume:" + system.sistema.configuracion.volumen);
        Debug.Log("Ultimo dialogo user: " + system.usuarios[0].ultimo_dialogo);

        user=system.usuarios[0];
        

    }

    public void LetsStart(){
        ChangeScene(user.ultima_escena);
    }

    public void ChangeScene(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
    }
}
