using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum EtatJeu
{
    JEU,
    FIN
}

public class GestionnaireJeu : MonoBehaviour
{
    public static GestionnaireJeu instance;

    public EtatJeu etatJeu;
    [SerializeField] TMP_Text texteCibles;
    [SerializeField] TMP_Text texteFin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


    }

    public void DetruireCible(GameObject cible)
    {

    }

    IEnumerator FinJeu()
    {
        etatJeu = EtatJeu.FIN;
        texteFin.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Ex4");
        // Reste de la logique pour terminer le jeu
        // Ex: Afficher un panneau, changer de scène, cinématique, etc. 
    }
}
