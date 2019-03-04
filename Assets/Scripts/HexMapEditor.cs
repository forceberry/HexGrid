﻿using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour
{
    int activeElevation;
    public Color[] colors;
    public HexGrid hexGrid;
    private Color activeColor;
    private void Awake()
    {
        SelectColor(0);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                HandleInput();
            }
        }
    }
    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit)) { EditCell(hexGrid.GetCell(hit.point)); }
    }
    void EditCell (HexCell cell)
    {
        cell.color = activeColor;
        cell.elevation = activeElevation;
        hexGrid.Refresh();
    }
    public void SelectColor(int index)
    {
        activeColor = colors[index];
    }
    public void SetElevation (float elevation)
    {
        activeElevation = (int)elevation;
    }
}
