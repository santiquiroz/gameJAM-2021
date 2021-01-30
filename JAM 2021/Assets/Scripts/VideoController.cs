using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoController : MonoBehaviour{

    private VideoPlayer videoplayer;
    void Start(){
        videoplayer = this.gameObject.GetComponent<VideoPlayer>();
    }

    void Update(){
        
    }
}
