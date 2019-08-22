using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class TapController : MonoBehaviour
{
    protected Button btn;
    protected Transform text;
    protected Transform image;



    private bool isPressed;
    public bool IsPressed
    {
        get
        {
            bool value = isPressed;
            IsPressed = false;
            return value;
        }
        set
        {
            isPressed = value;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        text = transform.Find("Text");
        image = transform.Find("Image");
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => { SetActiveTapIndication(false); });

    }


    /// <summary>
    /// ActivatesDeactivates Text and Image GameObject, depending on the given true or false/ value.
    /// </summary>
    /// <param name="value">
    /// Activate or deactivate the object, where true activates the GameObject and false
    ///     deactivates the GameObject.
    /// </param>
    public void SetActiveTapIndication(bool value)
    {
        text.gameObject.SetActive(value);
        image.gameObject.SetActive(value);
    }

    public void Pressed()
    {
        IsPressed = true;
    }
    public void Released()
    {
        IsPressed = false;
    }

}
