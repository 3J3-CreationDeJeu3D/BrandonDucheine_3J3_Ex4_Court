using System.Collections;//Pour les coroutines et les arrays
using System.Collections.Generic;//Pour les listes
using System.Linq;//Pour converitr un array en liste
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

    [SerializeField] Color[] listeCouleurs;
    [SerializeField] List<GameObject> listeCibles;

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

        listeCibles = GameObject.FindGameObjectsWithTag("Cible").ToList();
        //GameObject cibleAleatoire = listeCibles[Random.Range(0, listeCibles.Count)];
    }

    void Update()
    {
         texteCibles.text = $"{listeCibles.Count()}" ;
        
    }

    public void DetruireCible(GameObject cible)
    {
        if (listeCibles.Contains(cible))
        {
            listeCibles.Remove(cible);
            // listeCibles.Add(cible);
        }

        if (listeCibles.Count <= 0)
        {
            StartCoroutine(FinJeu());
        }
        
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
