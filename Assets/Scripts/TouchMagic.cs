using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TouchMagic : MonoBehaviour
{
    public GameObject lineRendererPrefab;

    private GameObject currentLine;
    private LineRenderer lineRenderer;
    private int currentLineVertexCount = 0;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartNewLine();
        }
        else if (Input.GetMouseButton(0) && currentLine != null)
        {
            AddNewLineVertex();
        }
        else if (Input.GetMouseButtonUp(0) && currentLine != null)
        {
            EndLine();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            ClearDraw();
        }
    }

    private void StartNewLine()
    {
        currentLine = Instantiate(lineRendererPrefab);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        currentLineVertexCount = 0;
        AddNewLineVertex();
    }

    private void AddNewLineVertex()
    {
        currentLineVertexCount++;
        lineRenderer.positionCount = currentLineVertexCount;
        lineRenderer.SetPosition(currentLineVertexCount - 1, GetMousePosition());
    }

    private void EndLine()
    {
        currentLine = null;
    }

    private void ClearDraw()
    {
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType<GameObject>())
        {
            LineRenderer lineRenderer = obj.GetComponent<LineRenderer>();
            if (lineRenderer != null)
            {
                UnityEngine.Object.Destroy(lineRenderer.gameObject);
            }
        }
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
