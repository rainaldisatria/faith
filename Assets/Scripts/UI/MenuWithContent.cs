using UnityEngine;
using UnityEngine.Animations;

public class MenuWithContent : MonoBehaviour
{
    [SerializeField] protected GameObject Prefab;
    
    protected Transform ContentTrans;

    protected virtual void Awake()
    {
        FindContentObj(this.transform);
    }

    protected virtual void OnDisable()
    {
        Close();
    }

    protected void Close()
    { 
        if (ContentTrans != null)
        {
            foreach (Transform childTrans in ContentTrans.transform)
            {
                Destroy(childTrans.gameObject);
            }
        }
    }

    private void FindContentObj(Transform parent)
    {
        foreach(Transform childTrans in parent)
        { 
            if(childTrans.name == "Content")
            {
                ContentTrans = childTrans;
                break;
            }

            FindContentObj(childTrans);
        } 
    }
}
