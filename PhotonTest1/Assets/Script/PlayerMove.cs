using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PhotonView PV;
    [SerializeField] private SpriteRenderer SR;

    private void Update()
    {
        if (PV.IsMine)
        {
            float axis = Input.GetAxisRaw("Horizontal");
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 7, 0, 0));

            if (axis != 0) PV.RPC("FilpXRPC", RpcTarget.AllBuffered, axis);
        }        
    }

    [PunRPC]
    public void FilpXRPC(float axis)
    {
        SR.flipX = axis == -1;
    }
}
