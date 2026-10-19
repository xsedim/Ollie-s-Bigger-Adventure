using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Utilities.Core;

namespace Circle
{
    public class ChangeSceneOnVideoEnd : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer;

        private void Start()
        {
            videoPlayer.loopPointReached += VideoFinished;
        }

        private void VideoFinished(VideoPlayer source)
        {
            StartCoroutine(SceneTools.TransitionToNextScene());
        }
    }
}
