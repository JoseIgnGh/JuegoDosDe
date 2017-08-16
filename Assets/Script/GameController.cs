using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Variable con Minusculas
    //Funciones con Mayuscula 

        [Range(0f, 0.20f)]
        //Velocidad y Movimiento de Fondo o plataforma
    public float parallaxSpeed = 0.02f;
    public RawImage background;
    public RawImage platform;

    public enum GameState {idle, Playing};
    public GameState gameState = GameState.idle;
    public GameObject iuIdle;

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



        if (gameState == GameState.idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            iuIdle.SetActive(false);
            player.SendMessage("UpdateState", "PlayerRun");
        }
        else if (gameState == GameState.Playing)
        {

            float finalSpeed = parallaxSpeed * Time.deltaTime;
            background.uvRect = new Rect(background.uvRect.x + finalSpeed * 5, 0f, 1f, 1f);
            platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 3, 0f, 1f, 1f);

        }
    
    }
}
