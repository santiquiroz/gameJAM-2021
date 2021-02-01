using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoController : MonoBehaviour{

    private Camera camara;
    private VideoPlayer videoPlayer;
    public GameObject canvas;

    void Start(){
        videoPlayer = this.gameObject.GetComponent<VideoPlayer>();
        camara = Camera.main;
        StartCoroutine(WaitVideo(5));
    }

    IEnumerator WaitVideo(int time){
        canvas.SetActive(false);
        videoPlayer.Play();
        videoPlayer.renderMode=VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCamera=camara;
        yield return new WaitForSeconds(time);
        videoPlayer.Stop();
        canvas.SetActive(true);
    }
}
