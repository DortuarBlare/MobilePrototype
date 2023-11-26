using System;
using Unity.Services.UserReporting;
using UnityEngine;

/// <summary>
/// This example shows how to use Cloud Diagnostics User Reporting to add custom metric data to a report
/// </summary>
public class CustomMetricExample : MonoBehaviour
{
    int m_CubeCount;

    [Tooltip("Material used by spawned cubes.")]
    public Material CubeMaterial;

    [Tooltip("Source camera used for the screenshots added to the User Report.")]
    public Camera ScreenshotSource;

    /// <summary>
    /// Spawn a cube, sample the number of cubes in the scene as a custom metric, and take a screenshot for the report
    /// </summary>
    void SpawnCube()
    {
        // Spawn the cube.
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(-5, 5, 0);
        cube.transform.parent = transform;
        var cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material = CubeMaterial;
        var rigidBody = cube.AddComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(0, 5, 0);
        Debug.Log("Cube spawned.");

        // Update the custom metric, sample it, and take a screenshot
        m_CubeCount++;
        UserReportingService.Instance.SampleMetric("CubeCount", m_CubeCount);
        UserReportingService.Instance.TakeScreenshot(1920, 1080, ScreenshotSource);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnCube();
        }
    }
}
