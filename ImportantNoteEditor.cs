#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InspectorNote))]
public class InspectorNoteEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InspectorNote inspectorNote = (InspectorNote)target;

        if (inspectorNote.fontSize < 1)
        {
            inspectorNote.fontSize = GUI.skin.textArea.fontSize;
        }

        if (inspectorNote.fontColor == Color.clear)
        {
            inspectorNote.fontColor = GUI.skin.textArea.normal.textColor;
        }
        
        GUIStyle style = new GUIStyle(GUI.skin.textArea)
        {
            fontStyle = inspectorNote.fontStyle,
            fontSize = inspectorNote.fontSize,
            normal = { textColor = inspectorNote.fontColor }
        };

        inspectorNote.text = EditorGUILayout.TextArea(inspectorNote.text, style);
    }
}

public class InspectorNote : MonoBehaviour
{
    [HideInInspector]
    public string text = "Some notes here; you can change the font style in the component menu (3-dot icon at the top-right of this component title bar).";
    [HideInInspector]
    public Color fontColor = Color.yellow;
    [HideInInspector]
    public FontStyle fontStyle = FontStyle.Bold;
    [HideInInspector]
    public int fontSize = 0;

    // Simplify context menus with a helper method
    [ContextMenu("Color: Normal")]
    public void SetFontColorNormal() => fontColor = Color.clear;

    [ContextMenu("Color: Yellow")]
    public void SetFontColorYellow() => fontColor = Color.yellow;

    [ContextMenu("Color: Red")]
    public void SetFontColorRed() => fontColor = Color.red;

    [ContextMenu("Font Size: Normal")]
    public void NormalFontSize() => fontSize = 0;

    [ContextMenu("Font Size: Large")]
    public void SetFontSizeLarge() => fontSize = 20;

    [ContextMenu("Font Size: Small")]
    public void SetFontSizeSmall() => fontSize = 10;

    [ContextMenu("Font Size: +1")]
    public void SetFontSizeBigger() => fontSize++;

    [ContextMenu("Font Size: -1")]
    public void SetFontSizeSmaller() => fontSize--;

    [ContextMenu("Style: Normal")]
    public void SetFontStyleNormal() => fontStyle = FontStyle.Normal;

    [ContextMenu("Style: Bold")]
    public void SetFontStyleBold() => fontStyle = FontStyle.Bold;

    [ContextMenu("Style: Italic")]
    public void SetFontStyleItalic() => fontStyle = FontStyle.Italic;

    [ContextMenu("Style: Bold And Italic")]
    public void SetFontStyleBoldAndItalic() => fontStyle = FontStyle.BoldAndItalic;
}
#endif
