using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    bool playMusic;
    private AudioSource gameMusic;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    Image musicToggleSprite;

    // Start is called before the first frame update
    void Start()
    {
        playMusic = true;
        
        GameObject tmp = GameObject.FindWithTag("Music");
        gameMusic = tmp.GetComponent<AudioSource>();
        gameMusic.loop = true;

        musicToggleSprite = musicToggleButton.GetComponent<Image>();
    }

    public void HandleToggleMusic() 
    {
        playMusic = playMusic ? false : true;

        if (playMusic)
        {
            gameMusic.Play();
            musicToggleSprite.sprite = musicOnSprite;
        }
        else
        {
            gameMusic.Stop();
            musicToggleSprite.sprite = musicOffSprite;
        }
    }
}
