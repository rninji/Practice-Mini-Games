using UnityEngine;

public static class Util
{
    public static GameObject FindGameObjectInChildWithTag (GameObject parent, string tag)
    {
        Transform transform = parent.transform;

        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.tag == tag)
                return transform.GetChild(i).gameObject;
        }
        return null;
    }
}
