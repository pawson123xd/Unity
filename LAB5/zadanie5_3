using Unity.Burst.Intrinsics;
using UnityEngine;

public class zadanie5_3 : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 target;
    public Vector3 target1;
    private Vector3 start;
    private GameObject player;
    private Vector3 lastPos;
    private Vector3[] targets=new Vector3[2];
    private Vector3[] targets_cop=new Vector3[2];
    private Vector3 meta;
    private int i=0;
    private bool back=false;
    void Start()
    {
        lastPos = transform.position;
        start = transform.position;
        player= GameObject.FindGameObjectWithTag("Player");
        targets[0]=target;
        targets[1]=target1;
        meta=start;
        targets_cop = (Vector3[])targets.Clone();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                if(Vector3.Distance(transform.position, meta) < 0.02f && back)
                {
                    back=false;
                    if (i == targets.Length-1)
                    {
                        i=0;
                        start=meta;
                        targets=(Vector3[])targets_cop.Clone();

                    }
                    else
                    {
                        i++;
                    }

                }
                else if (Vector3.Distance(transform.position, targets[i]) < 0.02f && !back)
                {
                    targets[i]= start;
                    start=meta;
                    back=true;
                }
                transform.position = Vector3.MoveTowards(transform.position, targets[i], speed * Time.deltaTime);
                player.transform.position += transform.position - lastPos;
                lastPos = transform.position;

        }
    }
}
