using UnityEngine;
using UnityEngine.EventSystems;

public class HexGameUI : MonoBehaviour {
	public HexGrid grid;
	HexCell currentCell;
	HexUnit selectedUnit;

	public bool isTravelling;
	public SkillMenu coverMenu;
	public SkillMenu bridgeMenu;
	public BridgeBuilder bridgeBuilder;
	public void SetEditMode (bool toggle) {
		enabled = !toggle;
		grid.ShowUI(!toggle);
		grid.ClearPath();
		if (toggle) {
			Shader.EnableKeyword("HEX_MAP_EDIT_MODE");
		}
		else {
			Shader.DisableKeyword("HEX_MAP_EDIT_MODE");
		}
	}

	void Update () {
		if (!EventSystem.current.IsPointerOverGameObject()) {
			if (Input.GetMouseButtonDown(0)) {
				DisableCurrentHighlight();
				if(coverMenu.isActiveAndEnabled)
				{
					UpdateCurrentCell();
					// Lets player put cover on cells 
					coverMenu.MoveToCursor();
				}
				else if(bridgeMenu.isActiveAndEnabled)
				{
					UpdateCurrentCell();
					bridgeMenu.MoveToCursor();
				}
				else
				{
					updateTravelState(false);
					DoSelection();
				}

			}
			else if (selectedUnit) {
				updateTravelState(true);
				if (Input.GetMouseButtonDown(1)) {
					DoMove();	
					updateTravelState(false);
					
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
				grid.FindPath(selectedUnit.Location, currentCell, selectedUnit);
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

	// Buttons
	public void SetCurrentCellCover(int dir)
	{
		if(currentCell) currentCell.BuildCover(dir);
	}

	public void BuildBridge()
	{
		if(currentCell) currentCell.BuildBridge(bridgeBuilder.BridgeDirection);
	}
	//
	public void updateTravelState(bool toTravel)
	{
		isTravelling = toTravel;
		coverMenu.skillToggle.interactable = !toTravel;
	}
}