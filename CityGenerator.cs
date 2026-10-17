
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public int citySize = 10;
    public float blockSpacing = 20f;

    void Start()
    {
        CreateGround();
        CreateRoads();
        CreateBuildings();
    }

    void CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(
            PrimitiveType.Plane);

        ground.name = "City Ground";
        ground.transform.position = Vector3.zero;
        ground.transform.localScale =
            new Vector3(40f, 1f, 40f);

        ground.GetComponent<Renderer>().material.color =
            new Color(0.25f, 0.4f, 0.25f);
    }

    void CreateRoads()
    {
        for (int i = -citySize; i <= citySize; i++)
        {
            float p = i * blockSpacing;

            CreateCube(
                "Road",
                new Vector3(p, 0.02f, 0),
                new Vector3(6f, 0.1f,
                    citySize * blockSpacing * 2f),
                new Color(0.15f, 0.15f, 0.15f));

            CreateCube(
                "Road",
                new Vector3(0, 0.02f, p),
                new Vector3(
                    citySize * blockSpacing * 2f,
                    0.1f, 6f),
                new Color(0.15f, 0.15f, 0.15f));
        }
    }

    void CreateBuildings()
    {
        for (int x = -citySize; x < citySize; x++)
        {
            for (int z = -citySize; z < citySize; z++)
            {
                if (Random.value < 0.15f)
                    continue;

                float height = Random.Range(5f, 25f);

                Vector3 position = new Vector3(
                    (x + 0.5f) * blockSpacing,
                    height / 2f,
                    (z + 0.5f) * blockSpacing);

                GameObject building =
                    GameObject.CreatePrimitive(
                        PrimitiveType.Cube);

                building.name = "City Building";
                building.transform.position = position;
                building.transform.localScale =
                    new Vector3(9f, height, 9f);

                building.GetComponent<Renderer>()
                    .material.color = new Color(
                        Random.Range(0.35f, 0.75f),
                        Random.Range(0.35f, 0.65f),
                        Random.Range(0.35f, 0.7f));
            }
        }
    }

    void CreateCube(
        string objectName,
        Vector3 position,
        Vector3 scale,
        Color color)
    {
        GameObject obj = GameObject.CreatePrimitive(
            PrimitiveType.Cube);

        obj.name = objectName;
        obj.transform.position = position;
        obj.transform.localScale = scale;
        obj.GetComponent<Renderer>().material.color = color;
    }
}
