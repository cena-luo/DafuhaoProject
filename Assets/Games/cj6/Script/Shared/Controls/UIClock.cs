using UnityEngine;
using System.Collections;

namespace com.QH.QPGame.BJL
{

    [AddComponentMenu("Custom/Controls/Clock")]
    public class UIClock : MonoBehaviour
    {
        uint _startTime = 0;
        uint _time = 0;
        bool _enable = false;
        public GameObject numLabel = null;
        public GameObject target = null;
        public string EndCallBack = "OnTimerEnd";

        public AudioClip audioClip;
        public float volume = 1f;
        public float pitch = 1f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_enable == false) return;

            if (_time > 0)
            {
                uint nNow = (uint)System.Environment.TickCount;
                if ((nNow - _startTime) > 1000)
                {

                    _time = _time - 1000;
                    _startTime = (uint)System.Environment.TickCount;
                    //
                    uint t = _time / 1000;
                    Show(t);
                    //
                    if ( t > 0 && t <= 3)
                    {
                        PlayWarnSound();
                    }
                }
            }
            else
            {
                KillTimer();
            }
        }
        public void SetTimer(uint time)
        {
            if (time > 0)
            {
                _startTime = (uint)System.Environment.TickCount;
                _time = time;
                _enable = true;
                Show(time / 1000);
                gameObject.SetActive(true);
            }
            else
            {
                _enable = false;
                _time = 0;
                gameObject.SetActive(false);
            }
        }
        public void KillTimer()
        {
            if (target != null && !string.IsNullOrEmpty(EndCallBack))
            {
                target.SendMessage(EndCallBack, gameObject, SendMessageOptions.DontRequireReceiver);
            }
            _enable = false;
            _time = 0;
            gameObject.SetActive(false);

        }
        void Show(uint t)
        {
            if (numLabel != null)
            {
                numLabel.GetComponent<UILabel>().text = t.ToString().PadLeft(2, '0');
            }

        }

        void PlayWarnSound()
        {
            string str = PlayerPrefs.GetString("ddz_effect_switch", "on");
            if (str == "on")
            {
                if (audioClip != null && volume > 0 && pitch > 0)
                {
                    NGUITools.PlaySound(audioClip, volume, pitch);
                }
            }
        }
    }

}