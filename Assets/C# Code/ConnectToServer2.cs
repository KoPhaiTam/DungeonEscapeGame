using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer2 : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;
    public Text buttonText;

    public void OnClickConnect()
    {
        if(usernameInput.text.Length >= 1) // buộc người chơi nhập tên
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true; // to fix bug master client join the scene not the others 
            PhotonNetwork.ConnectUsingSettings();// kết nối đến máy chủ có trong cài đặt của object PhotonNetwork
            
        }
    }



    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the " + PhotonNetwork.CloudRegion + " server"); // hiển thị thông tin server đã kết nối
        SceneManager.LoadScene("Lobby");
    }
}
