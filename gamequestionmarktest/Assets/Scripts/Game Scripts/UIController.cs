using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject UnselectedItem;
    public GameObject SelectedItem;
    public EventSystem UIEventSystem;
    
    // Start is called before the first frame update
    void Start()
    {
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
        SelectedItem.SetActive(false);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("HELLO");
    }
}