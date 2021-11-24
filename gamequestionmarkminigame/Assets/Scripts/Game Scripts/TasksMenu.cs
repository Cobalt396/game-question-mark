using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksMenu : MonoBehaviour
{
    public GameObject SelectedClipboard;
    public GameObject UnselectedClipboard;
    public bool isClipboardClicked;
    public bool waitedForSeconds;
    public Vector2 translationVector;
    public Vector3 scaleVector;
    public int transformCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        waitedForSeconds = true;
        translationVector = new Vector2(179, -90);
        scaleVector = new Vector3(3.25f, 3.25f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        isClipboardClicked = GetComponent<UISelectController>().isItemClicked;
        if(CheckIfCanTransform())
        {
            StartCoroutine(WaitedRoutine());
            TransformClipboard();
        }
    }

    IEnumerator WaitedRoutine()
    {
        yield return new WaitForSeconds(1);
        waitedForSeconds = false;
    }

    void TransformClipboard()
    {
        UnselectedClipboard.transform.Translate(translationVector * transformCounter * Time.deltaTime);
        UnselectedClipboard.transform.localScale += (scaleVector * transformCounter * Time.deltaTime);
        transformCounter *= -1;
    }

    bool CheckIfCanTransform()
    {
        if(waitedForSeconds == true)
        {
            if(isClipboardClicked == true && transformCounter == 1)
            {
                return true;
            }
            if(Input.GetKeyDown(KeyCode.Escape) && transformCounter == -1)
            {
                return true;
            }
        } 
        
        return false;
    }
}
