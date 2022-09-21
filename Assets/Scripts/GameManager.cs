using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;

    public Text gameOverText;
    public Text scoreText;
    public Text livesText;

    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        //Ketika game over sudah dijalankan, maka tinggal pencet tombol untuk pacmannya bergerak akan langsung new game
        if (lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
    }

    //Andhika
    //Game baru dimulai akan mengatur score, lives 
    private void NewGame()
    {
        SetScore(0);
        SetLives(10);
        NewRound();
    }

    //Jika pellet sudah habis / sudah game over lalu play again maka pellet akan muncul kembali seperti semula
    private void NewRound()
    {
        gameOverText.enabled = false;

        foreach (Transform pellet in pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    //Code untuk mengembalikan pacman ketempat semula saat new game
    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
    }

    //Rajis
    //Ini adalah code saat game over, teks game over akan ditampilkan dan pacman akan di destroy
    private void GameOver()
    {
        gameOverText.enabled = true;

        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }

    //Ini untuk menampilkan jumlah nyawa dari pacman
    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = "x" + lives.ToString();
    }

    //Menampilkan text score di game
    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(2, '0');
    }

    //Tamam
    //Ketika pacman dimakan akan mengurangi nyawanya sebanyak 1, jika nyawa habis maka akan game over
    public void PacmanEaten()
    {
        pacman.DeathSequence();

        SetLives(lives - 1);

        if (lives <= 0) {
            GameOver();
        }
    }

    //Ini code untuk menambah point saat pacman memakan hantu
    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * ghostMultiplier;
        SetScore(score + points);

        ghostMultiplier++;
    }

    //Afin
    //Ini adalah code untukmenampilkan point saat pacman memakan pellet
    //Setiap pellet bernilai 10 point
    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(score + pellet.points);

        if (!HasRemainingPellets())
            //jika pellet habis otomatis akan new game
        {
            pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }

}
