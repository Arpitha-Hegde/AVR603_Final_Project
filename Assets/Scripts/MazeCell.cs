using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject _leftWall;

    [SerializeField]
    private GameObject _rightWall;

    [SerializeField]
    private GameObject _frontWall;

    [SerializeField]
    private GameObject _backWall;

    [SerializeField]
    private GameObject _unvisitedBlock;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        _unvisitedBlock.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }

    public void ClearFrontWall()
    {
        _frontWall.SetActive(false);
    }

    public void ClearBackWall()
    {
        _backWall.SetActive(false);
    }
    public void ApplyWallMaterial(Material material)
    {
        ApplyMaterialToWall(_leftWall, material);
        ApplyMaterialToWall(_rightWall, material);
        ApplyMaterialToWall(_frontWall, material);
        ApplyMaterialToWall(_backWall, material);
    }

    private void ApplyMaterialToWall(GameObject wall, Material material)
    {
        if (wall != null)
        {
            // Attempt to get the Renderer directly
            Renderer renderer = wall.GetComponent<Renderer>();

            // If not found, search in children
            if (renderer == null)
            {
                renderer = wall.GetComponentInChildren<Renderer>();
            }

            // If a Renderer is found, assign the material
            if (renderer != null)
            {
                renderer.material = material;
            }
            else
            {
                Debug.LogWarning($"No Renderer found on {wall.name} or its children.");
            }
        }
    }
}