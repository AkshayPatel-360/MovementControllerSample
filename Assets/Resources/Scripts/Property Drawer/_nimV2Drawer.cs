using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(AnimV2))]
public class AnimV2Drawer : PropertyDrawer
{
    //Drawer for V2 class, it sucks
    bool initializedDrawer;

    const float displayPropertyWidth = 125f;

    public void OnEnable(SerializedProperty property)  //Not sure how to call this
    {
        initializedDrawer = true;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!initializedDrawer)
            OnEnable(property);


        SerializedProperty animCurve = property.FindPropertyRelative("animCurve");
        SerializedProperty animBounds = property.FindPropertyRelative("animBounds");

        /////Indent hack
        EditorGUI.BeginProperty(position, label, property);
        int indentSaved = EditorGUI.indentLevel;
        float widthFromIndentation = indentSaved * 9f;
        EditorGUI.indentLevel = 0;

        Rect labelRect = new Rect(widthFromIndentation + position.x, position.y, 180, 20);
        Rect leftRect = new Rect(widthFromIndentation + position.x + 180, position.y, 60, 20);
        Rect rightRect = new Rect(widthFromIndentation + position.x + 240, position.y, 120, 20);

        EditorGUI.LabelField(labelRect, property.name);
        animCurve.animationCurveValue = EditorGUI.CurveField(leftRect, "", animCurve.animationCurveValue);
        animBounds.vector2Value = EditorGUI.Vector2Field(rightRect, "", animBounds.vector2Value);
        //EditorGUI.PropertyField(rightRect, animBounds);

        EditorGUI.EndProperty();
        EditorGUI.indentLevel = indentSaved;

        //base.OnGUI(position, property, label);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (!initializedDrawer)
            OnEnable(property);

        return 20; //base.GetPropertyHeight(property, label); //* amtOfLines
    }
}
