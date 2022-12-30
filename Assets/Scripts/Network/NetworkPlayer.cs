using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour {
    public GameObject myCamera;

    bool isAlive = true;
    float lerpSmoothing = 10.0f;
    public Vector3 position;
    public Quaternion rotation;
    

    // Use this for initialization
    void Start()
    {
        if (photonView.isMine)
        {
            gameObject.name = "Me";
            myCamera.SetActive(true);

            GetComponent<MotorScript>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;

            SwayBar[] sb = GetComponentsInChildren<SwayBar>();
            foreach (SwayBar bar in sb)
                bar.enabled = true;

            WheelCollider[] wheelCollider = GetComponentsInChildren<WheelCollider>();
            foreach (WheelCollider wc in wheelCollider)
                wc.enabled = true;
        }
        else {
            gameObject.name = "Network Player";
            StartCoroutine("Alive");
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            position = (Vector3)stream.ReceiveNext();
            rotation = (Quaternion)stream.ReceiveNext();
        }
    }

	IEnumerator Alive()
    {
        while (isAlive)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * lerpSmoothing);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * lerpSmoothing);

            yield return null;
        }
    }
}
