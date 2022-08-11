using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public AudioSource bounce, shot, ui, audiosw,zombiedes,blast;
    // Start is called before the first frame update
    public void bouncesf()
    {
        bounce.Play();
    }

    public void shootsf()
    {
        shot.Play();
    }

    public void uisf()
    {
        ui.Play();
    }

    public void audiosf()
    {
        audiosw.Play();
    }

    public void zombieexp()
    {
        zombiedes.Play();
    }

    public void explo()
    {
        blast.Play();
    }
    
    
}
