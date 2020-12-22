using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(Toggleable<>))]
public class TogallableVariable : PropertyDrawer
{
   
   // bool initializedDrawer;


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
    
     
        SerializedProperty myValue = property.FindPropertyRelative("myData");
        SerializedProperty togglableBool = property.FindPropertyRelative("toogle");

        EditorGUI.BeginProperty(position, label, property);


        Rect varNameRect = new Rect( 35 , position.y, 180, 20);
        Rect boolRect = new Rect( 5, position.y, 60, 20);
        Rect varValueRect = new Rect(135, position.y, 120, 20);

        

        EditorGUI.LabelField(varNameRect,property.name);
        togglableBool.boolValue = EditorGUI.Toggle(boolRect, togglableBool.boolValue);
        if (togglableBool.boolValue)
        {
            EditorGUI.PropertyField(varValueRect, myValue,GUIContent.none);
        }
        EditorGUI.EndProperty();
      

    
    }


}
