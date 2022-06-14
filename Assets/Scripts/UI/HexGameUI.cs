﻿using UnityEngine;
using UnityEngine.EventSystems;

public class HexGameUI : MonoBehaviour {
	public HexGrid grid;
	HexCell currentCell;
	HexUnit selectedUnit;

	public bool isTravelling;
	public CoverSelectionMenu coverMenu;
	public void SetEditMode (bool toggle) {
		enabled = !toggle;
		grid.ShowUI(!toggle);
		grid.ClearPath();
	}

	void Update () {
		if (!EventSystem.current.IsPointerOverGameObject()) {
			if (Input.GetMouseButtonDown(0)) {
				DisableCurrentHighlight();
				if(coverMenu.isActiveAndEnabled)
				{
					UpdateCurrentCell();
					coverMenu.MoveToCursor();
				}
				else
				{
					isTravelling = false;
					DoSelection();
				}

			}
			else if (selectedUnit) {
				isTravelling = true;
				if (Input.GetMouseButtonDown(1)) {
					DoMove();	
					isTravelling = false;
				}
				else {
					if(isTravelling) DoPathfinding();
				}
			}
		}
	}

	void DoSelection () {
		grid.ClearPath();
		UpdateCurrentCell();
		if (currentCell) {
			selectedUnit = currentCell.Unit;
		}
	}

	void DoPathfinding () {
		if (UpdateCurrentCell()) {
			if (currentCell && selectedUnit.IsValidDestination(currentCell)) {
				grid.FindPath(selectedUnit.Location, currentCell, 24);
			}
			else {
				grid.ClearPath();
			}
		}
	}

	void DoMove () {
		if (grid.HasPath) {
//			selectedUnit.Location = currentCell;
			selectedUnit.Travel(grid.GetPath());
			grid.ClearPath();
			selectedUnit = null;
		}
	}

	public bool UpdateCurrentCell () {
		HexCell cell =
			grid.GetCell(Camera.main.ScreenPointToRay(Input.mousePosition));
		if (cell != currentCell) {
			currentCell = cell;
			return true;
		}
		return false;
	}

	public void HighlightCurrentCell() 
	{
		if(currentCell) currentCell.EnableHighlight(Color.cyan);
	}

	public void DisableCurrentHighlight()
	{
		if(currentCell) currentCell.DisableHighlight();
	}

	public void SetCurrentCellCover(int dir)
	{
		if(currentCell) currentCell.BuildCover(dir);
	}
}