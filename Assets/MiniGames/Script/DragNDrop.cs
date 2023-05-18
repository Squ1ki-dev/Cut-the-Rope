using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    
    private RectTransform rectTransform;
    private Vector2 lastPos, newPos;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    public bool correctAnswer;

    private void Start()
    {
        lastPos = transform.position;
        newPos = lastPos;
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = newPos;
        if(correctAnswer){
            rectTransform.localScale = rectTransform.localScale * 1.5f;
            gameObject.GetComponent<Image>().raycastTarget = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == gameObject.name){
            newPos = other.gameObject.transform.position;
            correctAnswer=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == gameObject.name){
            newPos = lastPos;
            correctAnswer = false;
        }
    }
}
