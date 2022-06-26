using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    public HexGameUI gameUI;
    public Canvas parentCanvas;
    public Toggle skillToggle;
    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {  
       
    }
    public void MoveToCursor()
    {
        gameUI.HighlightCurrentCell();
        Vector2 movePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);
        transform.position = parentCanvas.transform.TransformPoint(movePos);
    }


    public void SetToggle()
    {
        if (enabled) {     
            gameUI.DisableCurrentHighlight();
            enabled = false;
            gameObject.SetActive(false);
        }
        else 
        {
            gameObject.transform.position = new Vector3(800f,1000f,0f);
            enabled = true;
            gameObject.SetActive(true);
        }
    }
}
