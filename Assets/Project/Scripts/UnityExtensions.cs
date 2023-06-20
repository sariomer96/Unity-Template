using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace omer.Project.Scripts
{
    public static class UnityExtensions  
    {

        
        public static void Show(this  GameObject gO)
        { 
            gO.SetActive(true);
        }

        public static void Hide(this GameObject gO)
        {
            gO.SetActive(false);
        }

        #region Transform

        public static void ResetTransformation(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static void ResetPosition(this Transform transform)
        {
            transform.position=Vector3.zero;
            
            
        }
        
        public static void ResetScale(this Transform transform)
        {
            transform.localScale=Vector3.one;
        }

        public static void DestroyChildren(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
        #endregion
   

        #region List

        public static T GetRandomItem<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
        
        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count - 1; i > 1; i--)
            {
                var j = Random.Range(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }
        
        

        #endregion
        
    

        public static GameObject GetClosestObjectFromList(this GameObject obj, List<GameObject> objList)
        {
            float minDistance = Mathf.Infinity;
            GameObject minDistObj = null;

            for (int i = 0; i < objList.Count; i++)
            {
                float distance = Vector3.Distance(objList[i].transform.position, obj.transform.position);

                if (distance<minDistance)
                {
                    minDistance = distance;
                    minDistObj = objList[i];
                    
                }
            }

            return minDistObj;
        }

        public static List<GameObject> SortGameObjectList(this GameObject obj, List<GameObject> objList)
        {
            objList = objList.OrderBy(
                x => Vector3.Distance(obj.transform.position,x.transform.position)
            ).ToList();
            return objList;
        }
        
        
    }
}
