using UnityEngine; // audio lives here

public class KeepMusic : MonoBehaviour
{
    private static KeepMusic instance;  // one of these only

    void Awake()
    {
        // simple singleton-ish thing
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // keep across scenes
        }
        else
        {
            Destroy(gameObject);    // extra copy, just drop it
        }
    }
}
