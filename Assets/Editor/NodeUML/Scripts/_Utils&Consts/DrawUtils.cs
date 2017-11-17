﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class DrawUtils
{


    private const float heightLenghtOffset = 22f;

    public static void DrawNodeCurve(Rect start, Rect end, int indexP1, float startOffset)
    {
        float direction = -1f;
        float offcetStart = 0f;
        float offcetEnd = 1f;

        float heightP1 = startOffset + (heightLenghtOffset * indexP1);

        if (start.x < end.x)
        {
            direction = 1f;
            offcetStart = 1f;
            offcetEnd = 0f;
        }

        Vector3 startPos = new Vector3(start.x + start.width * offcetStart, start.y + heightP1, 0);
        Vector3 endPos = new Vector3(end.x + end.width * offcetEnd, end.y + 10f, 0);

        Vector3 startTan = startPos + Vector3.right * 50 * direction;
        Vector3 endTan = endPos + Vector3.left * 50 * direction;
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 2);
    }

    public static void DrawNodeCurveWithButton(Rect start, Rect end, int indexP1, float startOffset, System.Action deleteCallBack)
    {
        float direction = 0f;
        float offset = -15f;
        if (start.x < end.x)
        {
            direction = 1f;
            offset = 0f;
        }

        DrawNodeCurve(start, end, indexP1, startOffset);
        float heightP1 = startOffset + (heightLenghtOffset * indexP1);
        if (GUI.Button(new Rect((start.x + (start.width * direction) + offset), start.y + heightP1 - 10, 15, 15), "X"))
        {
            deleteCallBack();
        }
    }
}