using UnityEngine;

public class JumpingBlock : MonoBehaviour
{
    [SerializeField] Transform Block;
    [SerializeField] Vector3 gravityBegin = new Vector3(0, -1, 0);
    [SerializeField] Vector3 velocityBegin = new Vector3(0, 3, 0);
    float ybegin;

    [SerializeField] float t = 0;

    Vector3 velocity;
    Vector3 gravity;

    enum State {ground, airborne};
    State myState = State.ground;

    void Start()
    {
        ybegin = Block.position.y;
        velocity = velocityBegin;
    }

    // Update is called once per frame
    void Update()
    {
        if (myState == State.ground)
        {
            velocity = Vector3.zero;
            gravity = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                t = 0;
                myState = State.airborne;
                velocity = velocityBegin;
                gravity = gravityBegin;
                
            }

        }

        if (myState == State.airborne)
        {
            t += Time.deltaTime;
   
            if (Block.position.y < ybegin) 
            {
                myState = State.ground;
                velocity = Vector3.zero;
                gravity = Vector3.zero;
                Block.position = new Vector3(Block.position.x, ybegin, 0);

            }
        }

        velocity += gravity * Time.deltaTime;
        Block.position += velocity * Time.deltaTime;
    }
}
