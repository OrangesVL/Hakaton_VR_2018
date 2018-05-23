using Managers;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class TileView : MonoBehaviour
    {
        public RectTransform RectTransform;
        public Text Description;
        public Button Button;
        
        public void Initialize(Command command)
        {
            Description.text = command.NameCommand.ToString();
            Button.onClick.AddListener(()=>EventManager.Instance.OnClickTileCreate(command));
        }
    }
}