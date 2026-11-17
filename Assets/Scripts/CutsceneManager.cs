using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using Utilities.Core;

namespace Circle
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer;
        
        private InputAction holdAction;
        
        private void Start()
        {
            videoPlayer.loopPointReached += OnVideoEnd;
            videoPlayer.prepareCompleted += OnVideoPrepared;
            videoPlayer.Prepare();

            holdAction = InputHandler.Inputs.UI.Hold;
            holdAction.performed += _ => OnVideoEnd(videoPlayer);
        }

        private void OnVideoPrepared(VideoPlayer vp)
        {
            vp.Play();
        }

        private void OnVideoEnd(VideoPlayer vp)
        {
            // Load the next scene or perform any action after the video ends
            vp.Stop();
            vp.targetTexture.Release();

            StartCoroutine(SceneTools.TransitionToNextScene());
        }
    }
}
