using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    private SerializedProperty _type;
    private SerializedProperty _stats;

    private void OnEnable() {
        _type= serializedObject.FindProperty("_type");
        _stats = serializedObject.FindProperty("_stats");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_type);

        switch ((Enemy.EnemyType)_type.enumValueIndex) {
            case Enemy.EnemyType.MeleeEnemy:
                _stats.objectReferenceValue = EditorGUILayout.ObjectField("Melee Enemy Stats", _stats.objectReferenceValue, typeof(MeleeEnemy), false);
                break;
            case Enemy.EnemyType.RangedEnemy:
                _stats.objectReferenceValue = EditorGUILayout.ObjectField("Ranged Enemy Stats", _stats.objectReferenceValue, typeof(RangedEnemy), false);
                break;
            case Enemy.EnemyType.CasterEnemy:
                _stats.objectReferenceValue = EditorGUILayout.ObjectField("Caster Enemy Stats", _stats.objectReferenceValue, typeof(CasterEnemy), false);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

}
