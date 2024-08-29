using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteAnimation>().SetSprite(sprites, 0.2f, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
