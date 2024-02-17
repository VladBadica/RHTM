using UnityEngine;
using RHTMGame.Utils;

public class StepCollision : MonoBehaviour
{
    public BoxCollider2D trackballCollider;
    private BoxCollider2D stepCollider;

    // Start is called before the first frame update
    void Start()
    {
        stepCollider = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {

        if (stepCollider.bounds.min.x > trackballCollider.bounds.max.x)
        {
            Globals.Instance.ChangeTrackballDirection();
        }

        if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            if (stepCollider.bounds.Intersects(trackballCollider.bounds))
            {
                Debug.Log("Hit");
            }
        }
    }
}
