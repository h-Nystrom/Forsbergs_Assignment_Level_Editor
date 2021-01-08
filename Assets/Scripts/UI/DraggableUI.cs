using UnityEngine;
using UnityEngine.EventSystems;

namespace UI{
    public class DraggableUI : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler,
        IEndDragHandler{
        RectTransform rectTransform;

        void Awake(){
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData){ }

        public void OnDrag(PointerEventData eventData){
            rectTransform.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData){ }

        public void OnPointerDown(PointerEventData eventData){ }

        public void OnPointerUp(PointerEventData eventData){ }
    }
}