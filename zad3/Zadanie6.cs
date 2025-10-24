using UnityEngine;

public class Zadanie6 : MonoBehaviour
{
    public Transform obiekty;
    public float speed = 50f;
    public float speedmove = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        // obiekty.position = Vector3.Lerp(obiekty.position , transform.position-new Vector3(0,2,0) , speed*Time.deltaTime);
        // if(transform.position.x>4 || transform.position.x<=-2){
        //     speedmove*=-1;
        // }
        // transform.position=transform.position+new Vector3(speedmove*Time.deltaTime,0,0);
        if(obiekty.position.x>=transform.position.x){
            obiekty.position-=new Vector3(speed*Time.deltaTime,0,0);
        }
        if(obiekty.position.x<=transform.position.x){
            obiekty.position+=new Vector3(speed*Time.deltaTime,0,0);
        }
        if(obiekty.position.z<=transform.position.z){
            obiekty.position+=new Vector3(0,0,speed*Time.deltaTime);
        }
        if(obiekty.position.z>=transform.position.z){
            obiekty.position-=new Vector3(0,0,speed*Time.deltaTime);
        }
        if(obiekty.position.z<=transform.position.z){
            obiekty.position+=new Vector3(0,0,speed*Time.deltaTime);
        }
        if(obiekty.position.y>=transform.position.y-2){
            obiekty.position-=new Vector3(0,speed*Time.deltaTime,0);
        }
        if(obiekty.position.y<=transform.position.y-2){
            obiekty.position+=new Vector3(0,speed*Time.deltaTime,0);
        }
        if(transform.position.x>4 || transform.position.x<=-2){
            speedmove*=-1;
        }
        transform.position=transform.position+new Vector3(speedmove*Time.deltaTime,0,0);
    }
}
