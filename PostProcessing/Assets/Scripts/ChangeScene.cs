using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    [SerializeField]private string levelName;

    public void ChangeScecne()
    {
        Application.LoadLevel(levelName);
    }
}
