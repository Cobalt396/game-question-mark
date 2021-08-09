using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotbarController : MonoBehaviour
{
    public GameObject HotbarActive1;
    public GameObject HotbarActive2;
    public GameObject HotbarActive3;
    public GameObject HotbarActive4;
    public GameObject HotbarActive5;
    public GameObject HotbarActive6;
    public GameObject HotbarActive7;
    public GameObject HotbarActive8;
    public GameObject HotbarActive9;
    public bool[] HotbarsAreFilled = {false, false, false, false, false, false, false, false, false};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForHotbarSwitch();
    }

    public void SetAllUnactive()
    {
        HotbarActive1.SetActive(false);
        HotbarActive2.SetActive(false);
        HotbarActive3.SetActive(false);
        HotbarActive4.SetActive(false);
        HotbarActive5.SetActive(false);
        HotbarActive6.SetActive(false);
        HotbarActive7.SetActive(false);
        HotbarActive8.SetActive(false);
        HotbarActive9.SetActive(false);
    }

    // There 100% is a better way to do this
    public void CheckForHotbarSwitch()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetAllUnactive();
            HotbarActive1.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetAllUnactive();
            HotbarActive2.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetAllUnactive();
            HotbarActive3.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetAllUnactive();
            HotbarActive4.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetAllUnactive();
            HotbarActive5.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetAllUnactive();
            HotbarActive6.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetAllUnactive();
            HotbarActive7.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetAllUnactive();
            HotbarActive8.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetAllUnactive();
            HotbarActive9.SetActive(true);
        }
    }
}
