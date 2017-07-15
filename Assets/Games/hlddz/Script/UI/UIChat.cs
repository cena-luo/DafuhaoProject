using UnityEngine;
using System.Collections;

namespace com.QH.QPGame.DDZ
{

    public class UIChat : MonoBehaviour
    {

        static UIChat instance = null;
        GameObject o_chat_panel ;


        public static UIChat Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("UIChat").AddComponent<UIChat>();
                }
                return instance;
            }
        }

        void Awake()
        {
            o_chat_panel = GameObject.Find("scene_chat");
			//OnChatCloseIvk();
        }


        private void OnDestroy()
        {
            instance = null;
        }

        public void Show(bool bshow)
        {
            o_chat_panel.SetActive(bshow);
        }
        void OnChatCloseIvk()
        {
            o_chat_panel.SetActive(false);
        }
        //
        void OnChatMsgIvk(GameObject obj)
        {
            try
            {
                string str = obj.GetComponentInChildren<UILabel>().text;
                GameEngine.Instance.SendChatMessage(GameLogic.NULL_CHAIR, str, 0);
                o_chat_panel.SetActive(true);
            }
            catch
            {
                o_chat_panel.SetActive(false);
            }
        }

    }
}