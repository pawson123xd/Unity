using UnityEngine;
using System.Collections.Generic;
public class zadanie5 : MonoBehaviour
{
    public GameObject prefab;
    private List<float> x= new List<float>();
    private List<float> z= new List<float>();
    void Start() 
    {
        Destroy(prefab);
        System.Random rand = new System.Random(); 
        for (int i = 0; i < 10; i++)
        {
            float x = rand.Next(10);
            float z = rand.Next(10);
            for (int j = 0; j < this.x.Count; j++){
                if(this.x[j]==x && this.z[j]==z){
                    while (this.x[j]==x && this.z[j]==z)
                    {
                        x = rand.Next(10);
                        z = rand.Next(10);
                    }
                    j=0;
                    continue;
                }
            }
            
            Vector3 pos = transform.position + new Vector3(x, 0.5f, z);
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
