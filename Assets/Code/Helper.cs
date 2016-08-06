using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Helper  {

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
    public static bool HasResources(Dictionary<string, Resource> building, List<Resource> resources)
    {
        for(int i = 0; i < resources.Count; i++)
        {
            if(!HasResource(building, resources[i]))
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
    public static bool HasResource(Dictionary<string, int> building, Resource resource)
    {
        return (building[resource.Type] >= resource.Amount);
    }
    public static bool HasResource(Dictionary<string, Resource> building, Resource resource)
    {
        return (building[resource.Type].Amount >= resource.Amount);
    }
    public static void RemoveRsources(Dictionary<string, Resource> building, List<Resource> resources)
    {
        for(int i = 0; i < resources.Count; i++)
        {
            RemoveResource(building, resources[i]); 
        }
    }

    private static void RemoveResource(Dictionary<string, Resource> building, Resource resource)
    {
        building[resource.Type].Amount -= resource.Amount; 
    }

    //public static bool HasResources(List<Resource> building, List<Resource> requiremnts)
    //{
    //    for(int i = 0; i < requiremnts.Count; i++)
    //    {
    //        if(!HasResource(building, requiremnts[i]))
    //        {
    //            return false; 
    //        }
    //    }
    //    return true; 
    //}
    //public static bool HasResource(List<Resource> building, Resource resource)
    //{
    //    for(int i = 0; i < building.Count; i++)
    //    {
    //        if(building[i].Type == resource.Type)
    //        {
    //            if(building[i].Amount >= resource.Amount)
    //            {
    //                return true;
    //            }
    //        }
    //    }
    //    return false; 
    //}
    //public static Resource GetResource(List<Resource> building, string resourceName)
    //{
    //    for(int i = 0; i < building.Count; i++)
    //    {
    //        if(building[i].Type == resourceName)
    //        {
    //            return building[i]; 
    //        }
    //    }
    //    return null; 
    //}
    //public static void AddResources(List<Resource> building, List<Resource> cost)
    //{
    //    for(int i = 0; i < cost.Count; i++)
    //    {
    //        Resource resource = GetResource(building, cost[i].Type);
    //        if(resource != null)
    //        {
    //            resource.Amount += cost[i].Amount;  
    //        }
    //    }
    //}
    //public static void RemoveResources(List<Resource> building, List<Resource> cost)
    //{
    //    for (int i = 0; i < cost.Count; i++)
    //    {
    //        Resource resource = GetResource(building, cost[i].Type);
    //        if (resource != null)
    //        {
    //            resource.Amount -= cost[i].Amount;
    //        }
    //    }
    //}
}
