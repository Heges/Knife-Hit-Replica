using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexiableLayoutGroup : LayoutGroup
{
    private float rows;
    private float cols;
    private Vector2 cellSize;

    public override void CalculateLayoutInputVertical()
    {
        
    }

    public override void SetLayoutHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float sqrt = Mathf.Sqrt(transform.childCount);

        rows = Mathf.CeilToInt(sqrt);
        cols = Mathf.CeilToInt(sqrt);

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = parentWidth / (float)cols;
        float cellHeight = parentHeight / (float)rows;

        cellSize.x = cellWidth;
        cellSize.y = cellHeight;

        int rowCount = 0;
        int colCount = 0;

        for(int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = (int)(i / cols);
            colCount = (int)(i % cols);

            var item = rectChildren[i];

            var xPos = (cellSize.x * colCount);
            var yPos = (cellSize.y * rowCount);

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }

    }

    public override void SetLayoutVertical()
    {
        
    }
}
