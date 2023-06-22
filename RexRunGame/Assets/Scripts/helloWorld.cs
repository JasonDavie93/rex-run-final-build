using UnityEngine;

public class helloWorld : MonoBehaviour
{

    public string message = "default";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(message);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello Again!");
    }
}
