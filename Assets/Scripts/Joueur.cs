using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Joueur : MonoBehaviour
{
    [Header("Détection sol")]
    [SerializeField] LayerMask masqueSol;
    [SerializeField] float distance = 1000f;
    [SerializeField] float vitesseRotation = 5f;

    [Header("Tir")]
    [SerializeField] GameObject projectile;

    [Header("Gestion des touches")]
    [SerializeField] InputAction curseurAction;
    [SerializeField] InputAction tirAction;
    NavMeshAgent agent;
    Quaternion rotationCible;
    void OnEnable()
    {
        curseurAction.Enable();
        tirAction.Enable();

    }
    void OnDisable()
    {
        curseurAction.Disable();
        tirAction.Disable();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; //On gère la rotation manuellement
        rotationCible = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GestionnaireJeu.instance.etatJeu != EtatJeu.JEU)
        {
            return;
        }




        if (curseurAction.WasPressedThisFrame())
        {

        }


        if (tirAction.WasPressedThisFrame())
        {

        }

        // Chaque image, on tourne progressivement vers la rotation cible
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationCible, vitesseRotation * Time.deltaTime);
    }

}
