using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeRot : MonoBehaviour
{
    [SerializeField] private Hoe h;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReversalDir", 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 2);
    }
    void ReversalDir()
    {
        h.comeBack = true;
    }
}
