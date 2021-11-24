using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISelectController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject UnselectedItem;
    public GameObject SelectedItem;
    public EventSystem UIEventSystem;
    public bool isItemClicked;
    
    // Start is called before the first frame update
    void Start()
    {
        isItemClicked = false;
        SelectedItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        SelectedItem.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if(isItemClicked == false)
        {
            SelectedItem.SetActive(false);
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        isItemClicked = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        
    }
}