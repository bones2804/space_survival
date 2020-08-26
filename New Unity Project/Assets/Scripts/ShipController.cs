using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject floor_container, component_conatiner;

    public ColorToPrefab[] colorMap;

    public Texture2D design;

    void Start()
    {
        GenerateShip();
    }

    void FixedUpdate()
    {

    }

    void GenerateShip()
    {
        for (int x = 0; x < design.width; x++)
        {
            for (int y = 0;y < design.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = design.GetPixel(x, y);

        if (pixelColor.a == 0) //the pixel is transparent and empty
            return;

        foreach(ColorToPrefab colorMap in colorMap)
        {
            if (colorMap.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y) - new Vector2(design.width/2f, design.height/2f);
                Instantiate(colorMap.prefab, position, Quaternion.identity, floor_container.transform);
            }
        }

        Debug.Log(pixelColor);
    }
}

public class Quad_Tree<TType>
{
    Quad_Node<TType> root;

    public void Insert(TType component, Vector2 position) => root.Insert(component, position);

    public void Balance() => root.Merge();
}
public class Quad_Node<TType>
{
    public TType Component { get; private set; }
    public Quad_Node<TType>[] Children { get; private set; }
    public bool IsLeafNode => (Children.Length <= 0);
    public bool IsEmptyNode => (!Component.Equals(default(TType)) && IsLeafNode);

    private Vector2 SplitPoint;

    private Quad_Node()
    {
        Children = new Quad_Node<TType>[0];
        Component = default;
    }

    public void Insert(TType[] components, Vector2[] positions)
    {
        if(positions.Length <= 0)
        {
            return;
        }

        if(positions.Length == 1)
        {
            Insert(components[0], positions[0]);
            return;
        }

        Vector2 sum = new Vector2(0, 0);

        foreach(Vector2 pos in positions)
        {
            sum += pos;
        }

        Vector2 newSplit = sum * (1 / (positions.Length));

        var topLeftComp = new ArrayList();
        var topLeftPos = new ArrayList();
        var topRightComp = new ArrayList();
        var topRightPos = new ArrayList();
        var bottomLeftComp = new ArrayList();
        var bottomLeftPos = new ArrayList();
        var bottomRightComp = new ArrayList();
        var bottomRightPos = new ArrayList();

        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].y < newSplit.y)                          //top
            {
                if (positions[i].x < newSplit.x)                          //left
                {
                    topLeftComp.Add(components[i]);
                    topLeftPos.Add(positions[i]);
                }
                else                                                    //right
                {
                    topRightComp.Add(components[i]);
                    topRightPos.Add(positions[i]);
                }
            }
            else                                                    //bottom
            {
                if (positions[i].x < newSplit.x)                          //left
                {
                    bottomLeftComp.Add(components[i]);
                    bottomLeftPos.Add(positions[i]);
                }
                else                                                    //right
                {
                    bottomRightComp.Add(components[i]);
                    bottomRightPos.Add(positions[i]);
                }
            }
        }

        var tempComp = new TType[topLeftComp.Count];
        var tempPos = new Vector2[topLeftPos.Count];

        Array.Copy(topLeftComp.ToArray(), tempComp, tempComp.Length);
        Array.Copy(topLeftPos.ToArray(), tempPos, tempPos.Length);

        Children[0].Insert(tempComp, tempPos);

        tempComp = new TType[topRightComp.Count];
        tempPos = new Vector2[topRightPos.Count];

        Array.Copy(topRightComp.ToArray(), tempComp, tempComp.Length);
        Array.Copy(topRightPos.ToArray(), tempPos, tempPos.Length);

        Children[1].Insert(tempComp, tempPos);

        tempComp = new TType[bottomLeftComp.Count];
        tempPos = new Vector2[bottomLeftPos.Count];

        Array.Copy(bottomLeftComp.ToArray(), tempComp, tempComp.Length);
        Array.Copy(bottomLeftPos.ToArray(), tempPos, tempPos.Length);

        Children[2].Insert(tempComp, tempPos);

        tempComp = new TType[bottomRightComp.Count];
        tempPos = new Vector2[bottomRightPos.Count];

        Array.Copy(bottomRightComp.ToArray(), tempComp, tempComp.Length);
        Array.Copy(bottomRightPos.ToArray(), tempPos, tempPos.Length);

        Children[3].Insert(tempComp, tempPos);
    }

    public void Insert(TType component, Vector2 position)
    {
        if (!IsLeafNode)                                        //find child to insert into
        {
            if (position.y < SplitPoint.y)                          //top
            {
                if (position.x < SplitPoint.x)                          //left
                    Children[0].Insert(component, position);
                else                                                    //right
                    Children[1].Insert(component, position);
            }
            else                                                    //bottom
            {
                if (position.x < SplitPoint.x)                          //left
                    Children[2].Insert(component, position);
                else                                                    //right
                    Children[3].Insert(component, position);
            }
        }
        else if (IsEmptyNode)
        {
            Component = component;
            SplitPoint = position;
        }
        else if (IsLeafNode)
        {
            Split(component, position);
        }

    }

    private void Split(TType component, Vector2 position)
    {
        var oldPos = SplitPoint;
        var oldComp = Component;

        SplitPoint = (position + SplitPoint) * 0.5f;
        Component = default(TType);

        Children = new Quad_Node<TType>[4];

        Insert(oldComp, oldPos);
        Insert(component, position);
    }

    public void Merge()
    {
        var comps = GetComponents();
        DeleteChildren();

        Component = default;

        Insert(comps.Item1, comps.Item2);
    }

    private void DeleteChildren()
    {
        if (IsLeafNode)
            return;

        foreach(Quad_Node<TType> child in Children)
        {
            child.DeleteChildren();
        }

        Children = new Quad_Node<TType>[0];
    }

    private int GetHeight()
    {
        if(IsEmptyNode)
            return 0;
    
        if (IsLeafNode)
            return 1;

        var maxHeight = 0;
        foreach(Quad_Node<TType> child in Children)
        {
            maxHeight = child.GetHeight() > maxHeight ? child.GetHeight():maxHeight;
        }
        return maxHeight;
    }

    private Tuple<TType[], Vector2[]> GetComponents()
    {
        if (IsEmptyNode)
            return Tuple.Create(new TType[0], new Vector2[0]);
        if (IsLeafNode)
            return Tuple.Create(new TType[] { Component }, new Vector2[] { SplitPoint });

        var tempComp = new ArrayList();
        var tempPos = new ArrayList();

        foreach(Quad_Node<TType> child in Children)
        {
            tempComp.AddRange(child.GetComponents().Item1);
            tempPos.AddRange(child.GetComponents().Item2);
        }

        var retComp = new TType[tempComp.Count];
        var retPos = new Vector2[tempPos.Count];

        Array.Copy(tempComp.ToArray(), retComp, retComp.Length);
        Array.Copy(tempPos.ToArray(), retPos, retPos.Length);

        return Tuple.Create(retComp, retPos);
    }

   
}
