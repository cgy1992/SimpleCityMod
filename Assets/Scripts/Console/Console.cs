using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public static bool isOpen = false;

    public GameObject uiObject;
    static GameObject sUIObject;

    public Transform parent;
    static Transform sParent;

    public Color errorColor = Color.red;
    public Color warningColor = Color.yellow;
    public Color normalColor = Color.white;

    static Color ErrorColor { get; set; }
    static Color WarningColor { get; set; }
    static Color NormalColor { get; set; }

    void Start()
    {
        sUIObject = uiObject;
        sParent = parent;

        ErrorColor = errorColor;
        WarningColor = warningColor;
        NormalColor = normalColor;
    }

    public static void ToggleShowConsole()
    {
        isOpen = !isOpen;
    }

	public static void LogError(string message)
    {
        GameObject go = Instantiate(sUIObject, sParent);

        go.GetComponentInChildren<Text>().text = message;
        go.GetComponentInChildren<Text>().color = ErrorColor;
    }

    public static void LogWarning(string message)
    {
        GameObject go = Instantiate(sUIObject, sParent);

        go.GetComponentInChildren<Text>().text = message;
        go.GetComponentInChildren<Text>().color = WarningColor;
    }

    public static void Log(string message)
    {
        GameObject go = Instantiate(sUIObject, sParent);

        go.GetComponentInChildren<Text>().text = message;
        go.GetComponentInChildren<Text>().color = NormalColor;
    }
}
