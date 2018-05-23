using System.Runtime.Serialization;
using Managers;
using Model;
using UnityEngine;

namespace View
{
    public class CreaterTiles : MonoBehaviour
    {
        public GameObject PrefabTile;
        public float DistanceBetweenElements;
        public Transform TransformCollectionElements;

        public void Start()
        {
            FillListCommands();
        }

        private void FillListCommands()
        {
            for (var index = 0; index < ObjectManagers.Instance.Commands.Length; index++)
            {
                ShowElement(ObjectManagers.Instance.Commands[index],index);
            }
        }
        
        private void ShowElement(Command command, int numberPosition)
        {
            var obj = Instantiate(PrefabTile);
            var tileComp = obj.GetComponent<TileView>();
            tileComp.Initialize(command);
            
            obj.transform.SetParent(TransformCollectionElements,false);
            obj.transform.position = new Vector3(
                obj.transform.position.x-TransformCollectionElements.up.normalized.x*(numberPosition*tileComp.RectTransform.rect.height),
                obj.transform.position.y-TransformCollectionElements.up.normalized.y*(numberPosition*tileComp.RectTransform.rect.height),
                obj.transform.position.z-TransformCollectionElements.up.normalized.z*(numberPosition*tileComp.RectTransform.rect.height));
        }
    }
}