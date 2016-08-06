using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Helper
{

    #region ToDictionary
    //if we end up wanting ot use dictionaires after game starts, instead of lists. 
    public static Dictionary<string, Resource> ResourceListToDict(List<Resource> resource)
    {
        Dictionary<string, Resource> dict = new Dictionary<string, Resource>();
        for (int i = 0; i < resource.Count; i++)
        {
            string key = resource[i].Type;
            dict[key] = resource[i];
        }
        return dict;
    }
    public static Dictionary<string, ResourceMax> ResourceListToDict(List<ResourceMax> resource)
    {
        Dictionary<string, ResourceMax> dict = new Dictionary<string, ResourceMax>();
        for (int i = 0; i < resource.Count; i++)
        {
            string key = resource[i].Type;
            dict[key] = resource[i];
        }
        return dict;
    }
    #endregion

    #region HasResources
    public static bool HasResources(Dictionary<string, Resource> building, List<Resource> resources)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (!HasResource(building, resources[i]))
            {
                return false;
            }
        }
        return true;
    }
    public static bool HasResources(Dictionary<string, ResourceMax> building, List<Resource> resources)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (!HasResource(building, resources[i]))
            {
                return false;
            }
        }
        return true;
    }
    public static bool HasResources(Dictionary<string, int> building, List<Resource> resources)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (!HasResource(building, resources[i]))
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    #region HasResource
    public static bool HasResource(Dictionary<string, int> building, Resource resource)
    {
        return (building[resource.Type] >= resource.Amount);
    }
    public static bool HasResource(Dictionary<string, Resource> building, Resource resource)
    {
        return (building[resource.Type].Amount >= resource.Amount);
    }
    public static bool HasResource(Dictionary<string, ResourceMax> building, Resource resource)
    {
        return (building[resource.Type].Amount >= resource.Amount);
    }
    #endregion

    #region RemoveResources
    public static void RemoveResources(Dictionary<string, Resource> building, List<Resource> resources)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            RemoveResource(building, resources[i]);
        }
    }
    public static void RemoveResources(Dictionary<string, ResourceMax> building, List<Resource> resources)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            RemoveResource(building, resources[i]);
        }
    }
    #endregion

    #region TakeResources
    public static List<Resource> TakeResources(Dictionary<string, Resource> building, List<Resource> resources)
    {
        List<Resource> results = new List<Resource>(); 
        for(int i = 0; i < resources.Count; i++){
            Resource resource = new Resource();
            resource.Amount = TakeResource(building, resources[i]);
            resource.Type = resources[i].Type;
            results.Add(resource); 
        }
        return results; 
    }
    public static List<Resource> TakeResources(Dictionary<string, ResourceMax> building, List<Resource> resources)
    {
        List<Resource> results = new List<Resource>();
        for (int i = 0; i < resources.Count; i++)
        {
            Resource resource = new Resource();
            resource.Amount = TakeResource(building, resources[i]);
            resource.Type = resources[i].Type;
            results.Add(resource);
        }
        return results;
    }
    #endregion

    #region TakeResource
    public static int TakeResource(Dictionary<string, Resource> building, Resource resource)
    {
        int ownedAmount = building.ContainsKey(resource.Type) ? building[resource.Type].Amount : 0;
        int removedAmount = Math.Min(ownedAmount, resource.Amount); 
        if(removedAmount > 0)
        {
            building[resource.Type].Amount -= removedAmount; 
        }
        return removedAmount; 
    }
    public static int TakeResource(Dictionary<string, ResourceMax> building, Resource resource)
    {
        int ownedAmount = building.ContainsKey(resource.Type) ? building[resource.Type].Amount : 0;
        int removedAmount = Math.Min(ownedAmount, resource.Amount);
        if (removedAmount > 0)
        {
            building[resource.Type].Amount -= removedAmount;
        }
        return removedAmount;
    }
    #endregion

    #region RemoveResource
    public static void RemoveResource(Dictionary<string, Resource> building, Resource resource)
    {
        building[resource.Type].Amount -= resource.Amount;
    }
    public static void RemoveResource(Dictionary<string, ResourceMax> building, Resource resource)
    {
        building[resource.Type].Amount -= resource.Amount;
    }
    #endregion

    #region AddResources
    public static void AddResources(Dictionary<string, Resource> building, List<Resource> resources)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            AddResource(building, resources[i]);
        }
    }
    public static void AddResources(Dictionary<string, ResourceMax> building, List<Resource> resources)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            AddResource(building, resources[i]);
        }
    }
    #endregion

    #region AddResource
    public static void AddResource(Dictionary<string, Resource> building, Resource resource)
    {
        if (building.ContainsKey(resource.Type))
        {
            building[resource.Type].Amount += resource.Amount;
        }
        else
        {
            Resource newResource = new Resource();
            newResource.Type = resource.Type;
            newResource.Amount = resource.Amount;
            building[resource.Type] = newResource;
        }
    }
    public static void AddResource(Dictionary<string, ResourceMax> building, Resource resource)
    {
        if (building.ContainsKey(resource.Type))
        {
            building[resource.Type].Amount += resource.Amount;
        }
        else
        {
            ResourceMax newResource = new ResourceMax();
            newResource.Type = resource.Type;
            newResource.Amount = resource.Amount;
            newResource.Max = -1; //This needs to be figured out, right now leaving -1 as a 'no max' 
            building[resource.Type] = newResource;
        }
    }
    #endregion
}
