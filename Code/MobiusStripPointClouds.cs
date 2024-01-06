using UnityEngine;

public class MobiusStripPointClouds : MonoBehaviour
{
    public int numPoints = 1000; // Number of points to generate
    public float R = 100f;       // Radius of the Mobius strip
    public float width = 20f;   // Width of the Mobius strip
    public GameObject point_cloud; // Prefab for representing points
    public float pointScale = 0.01f; // Scale for the point prefab

    // Start is called before the first frame update
    void Start()
    {
        GenerateMobiusPoints();
    }

    void GenerateMobiusPoints()
    {
        for (int i = 0; i < numPoints; i++)
        {
            // Randomly generate u and v within their respective ranges
            float u = Random.Range(0.0f, 2.0f * Mathf.PI * R);
            float v = Random.Range(-width / 2.0f, width / 2.0f);

            // Calculate the position for this point
            Vector3 position = new Vector3(
                (R + v * Mathf.Cos(u / (2.0f * R))) * Mathf.Cos(u / R),
                (R + v * Mathf.Cos(u / (2.0f * R))) * Mathf.Sin(u / R),
                v * Mathf.Sin(u / (2.0f * R))
            );

            // Instantiate the point prefab at the calculated position
            GameObject point = Instantiate(point_cloud, position, Quaternion.identity, transform);
           
            // Scale down the point to make it smaller
            point.transform.localScale = new Vector3(pointScale, pointScale, pointScale);
        }
    }
}

