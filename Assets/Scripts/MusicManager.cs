using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    private static MusicManager instance = null;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            if (this != instance) {
                Destroy(this.gameObject);
            }
        }
    }
}
