using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string typeName = "KittyKnight";
	private const string gameName = "TestingRoom";

	private HostData[] hostList;

	public GameObject playerPrefab;
	
	private void RefreshHostList() {
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent) {
		if (msEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList();
		}
	}

	private void StartServer() {
		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}

	void OnServerInitialized() {
		SpawnPlayer();
	}

	private void JoinServer(HostData hostData) {
		Network.Connect(hostData);
	}
	
	void OnConnectedToServer() {
		SpawnPlayer();
	}

	void OnGUI() {
		if (!Network.isClient && !Network.isServer) {
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server")) {
				StartServer();
			}
			
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts")) {
				RefreshHostList();
			}
			
			if (hostList != null) {
				for (int i = 0; i < hostList.Length; i++) {
					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName)) {
						JoinServer(hostList[i]);
					}
				}
			}
		}
	}

	private void SpawnPlayer() {
		GameObject player = (GameObject)Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
		PlayerTracker playerTracker = (PlayerTracker)Camera.main.GetComponent("PlayerTracker");
		playerTracker.player = player.transform;
	}
}
