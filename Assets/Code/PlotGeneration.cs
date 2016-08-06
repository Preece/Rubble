using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class PlotGeneration : MonoBehaviour {

    [SerializeField]
    int plotsWide = 10;
    [SerializeField]
    int plotsDeep = 10; 
    [SerializeField]
    float plotSize = 15f;
    [SerializeField]
    float sidewalkWidth = 2f;
    [SerializeField]
    float roadWidth = 5f; 
    [SerializeField]
    GeneratedBuilding[] startingBuildings;
    [SerializeField]
    Material roadMat;
    [SerializeField]
    Material sidewalkMat; 
    float plotDistance;
    GameObject roads;
    GameObject buildings; 
    
    void Awake()
    {
        plotDistance = plotSize + sidewalkWidth * 2 + roadWidth; 
    }

    void Start()
    {
        roads = new GameObject();
        roads.name = "Roads";
        buildings = new GameObject();
        buildings.name = "Buildings";
        Building[] lots = MakeMinimumBuildingArray();
        BuildingWeightProb[] weights = GenerateWeights(); 
        for (int y = 0; y < plotsDeep; y++)
        {
            for (int x = 0; x < plotsWide; x++)
            {
                Building building; 
                int lotsI = y * plotsWide + x;
                if (lots[lotsI] != null) {
                    building = Instantiate(lots[lotsI]);
                }
                else
                {
                    building = Instantiate(PickRandomBuilding(weights, 0, weights.Length, -1));
                }
                BoxCollider coll = building.gameObject.AddComponent<BoxCollider>();
                coll.size = new Vector3(plotSize, 1, plotSize);
                coll.center = new Vector3(0, -0.5f, 0); 
                building.transform.position = new Vector3(x * plotDistance, 0, y * plotDistance);
                building.transform.parent = buildings.transform; 
                MakeSidewalk(building.transform.position);
                MakeRoads(building.transform.position);
                if(x < plotsWide - 1 && y < plotsDeep - 1)
                {
                    MakeCorner(building.transform.position); 
                }
            }
        }
    }
    BuildingWeightProb[] GenerateWeights()
    {
        BuildingWeightProb[] weights = new BuildingWeightProb[startingBuildings.Length];
        int count = 0; 
        for(int i = 0; i < startingBuildings.Length; i++)
        {
            count += startingBuildings[i].weight;
            weights[i] = new BuildingWeightProb(count, startingBuildings[i].buildling);  
        }
        return weights;
    }
    Building[] MakeMinimumBuildingArray()
    {
        Building[] lots = new Building[plotsWide * plotsDeep];
        for(int i = 0; i < startingBuildings.Length; i++)
        {
            FillWithMin(startingBuildings[i], lots); 
        }
        return lots; 
    }
    //prefills lots to ensure a minimum. 
    void FillWithMin(GeneratedBuilding genBuilding, Building[] buildings)
    {
        for(int i = 0; i < genBuilding.minimum; i++)
        {
            buildings[PickEmptySpot(buildings)] = genBuilding.buildling; 
        }
    }
    int PickEmptySpot(Building[] buildings)
    {
        int selected = Random.Range(0, buildings.Length);
        if (buildings[selected] == null) {
            return selected; 
        }
        return PickEmptySpot(buildings); 
    }
    Building PickRandomBuilding(BuildingWeightProb[] weights, int min, int max, int randWeight)
    {
        if(randWeight == -1)
        {
            randWeight = Random.Range(0, weights[weights.Length - 1].maxWeight); 
        }
        int index = (min + max) / 2; 
        int targetWeight = weights[index].maxWeight;
        if(targetWeight < randWeight)
        {
            return PickRandomBuilding(weights, index, max, randWeight);
        }else
        {
            if(index == 0)
            {
                return weights[index].building; 
            }
            else if(weights[index - 1].maxWeight < randWeight)
            {
                return weights[index].building; 
            }
            else
            {
                return PickRandomBuilding(weights, min, index, randWeight); 
            }
        }
        return startingBuildings[Random.Range(0, startingBuildings.Length)].buildling;
    }
    Transform GenerateSidewalk(int rotateTimes)
    {
        Transform tran = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        tran.localScale = new Vector3(sidewalkWidth, 0.3f, plotSize + ((rotateTimes % 2) * sidewalkWidth * 2));
        tran.gameObject.name = "sidewalk";
        tran.parent = roads.transform;
        tran.gameObject.GetComponent<MeshRenderer>().material = sidewalkMat; 
        return tran; 
    }
    Transform GenerateRoad(int rotateTimes)
    {
        Transform tran = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        tran.localScale = new Vector3(roadWidth * 0.5f, 0.1f, plotSize + sidewalkWidth * 2);
        tran.gameObject.name = "road";
        tran.parent = roads.transform;
        tran.gameObject.GetComponent<MeshRenderer>().material = roadMat; 
        return tran;
    }
    Transform GenerateCorner()
    {
        Transform tran = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        tran.localScale = new Vector3(roadWidth, 0.1f, roadWidth);
        tran.gameObject.name = "corner";
        tran.parent = roads.transform;
        tran.gameObject.GetComponent<MeshRenderer>().material = roadMat;
        return tran; 
    }
    void MakeCorner(Vector3 startingPos)
    {
        Transform corner = GenerateCorner();
        corner.position = new Vector3(startingPos.x + plotSize * 0.5f + sidewalkWidth + roadWidth * 0.5f, 0, startingPos.z + plotSize * 0.5f + sidewalkWidth + roadWidth * 0.5f);
    }
    void MakeSidewalk(Vector3 startingPos)
    {
        Transform sidewalk1 = GenerateSidewalk(0);
        sidewalk1.position = new Vector3(startingPos.x + plotSize / 2f + sidewalkWidth * 0.5f, 0, startingPos.z);
        Transform sidewalk2 = GenerateSidewalk(1);
        sidewalk2.position = new Vector3(startingPos.x, 0, startingPos.z + plotSize / 2f + sidewalkWidth * 0.5f);
        sidewalk2.Rotate(new Vector3(0, 90, 0));
        Transform sidewalk3 = GenerateSidewalk(0);
        sidewalk3.position = new Vector3(startingPos.x - plotSize / 2f - sidewalkWidth * 0.5f, 0, startingPos.z);
        Transform sidewalk4 = GenerateSidewalk(1);
        sidewalk4.position = new Vector3(startingPos.x, 0, startingPos.z - plotSize / 2f - sidewalkWidth * 0.5f);
        sidewalk4.Rotate(new Vector3(0, 90, 0));
    }
    void MakeRoads(Vector3 startingPos)
    {
        Transform road1 = GenerateRoad(0);
        road1.position = new Vector3(startingPos.x + plotSize / 2f + sidewalkWidth + roadWidth * 0.25f, 0, startingPos.z);
        Transform road2 = GenerateRoad(1);
        road2.position = new Vector3(startingPos.x, 0, startingPos.z + plotSize / 2f + sidewalkWidth + roadWidth * 0.25f);
        road2.Rotate(new Vector3(0, 90, 0));
        Transform road3 = GenerateRoad(0);
        road3.position = new Vector3(startingPos.x - plotSize / 2f - sidewalkWidth - roadWidth * 0.25f, 0, startingPos.z);
        Transform road4 = GenerateRoad(1);
        road4.position = new Vector3(startingPos.x, 0, startingPos.z - plotSize / 2f - sidewalkWidth - roadWidth * 0.25f);
        road4.Rotate(new Vector3(0, 90, 0));
    }
    
}
