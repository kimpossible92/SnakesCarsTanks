﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Commons;

namespace UISystem
{
    public class UIV : Singleton<UIV>
    {
        public Text connectionStatus;
        [SerializeField] private InputField playerNameIF;
        [SerializeField] private Text playerName;
        [SerializeField] private GameObject lobbyPanel, loadingPanel, disconnectedPanel;
        [SerializeField] private GameObject gamePanel, logInPanel;
        [SerializeField] private Button joinLobby, loginBtn;
        
        private GameObject lastActivePanel;
        private UIService uiService;

        private void Start()
        {
            connectionStatus.text = "Connecting";
            lastActivePanel = loadingPanel;
            joinLobby.onClick.AddListener(JoinRoomBtn);
            loginBtn.onClick.AddListener(LogInBtn);
        }

        public void SetUIService(UIService uiService)
        {
            this.uiService = uiService;
        }

        void ActivatePanel(GameObject panel)
        {
            panel.SetActive(true);
            lastActivePanel.SetActive(false);
            lastActivePanel = panel;
        }
         void ActivePan(GameObject panel)
        {
            panel.SetActive(true);
            lastActivePanel.SetActive(false);
            lastActivePanel = panel;
        }

        void LogInBtn()
        {
            if (playerNameIF.text.Length > 3)
            {
                Debug.Log("[UIV] LogIn Button Clicked");
                PhotonNetwork.NickName = playerNameIF.text;
                uiService.LogInEvent(PhotonNetwork.NickName);
            }
        }

        void JoinRoomBtn()
        {
            Debug.Log("[UIV] Join Room Button Clicked");
            uiService.JoinRoomEvent();
        }

        public void ConnectedToMaster()
        {
            ActivatePanel(logInPanel);
            Debug.Log("[UIV] LogIn Panel");
        }

        public void JoinedLobby(string playerNameVal)
        {
            playerName.text = playerNameVal;
            ActivatePanel(lobbyPanel);
            Debug.Log("[UIV] JoinedLobby");
        }

        public void JoinedRoom()
        {
            ActivePan(gamePanel);
            //SceneManager.LoadScene(1);
        }

        public void Disconnected()
        {
            ActivatePanel(disconnectedPanel);
            Debug.Log("[UIV] Disconnected");
        }

    }
}