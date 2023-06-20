using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject pocketWatch;
    public Player player;
    public Cup[] cups;

    public TextMesh infoText;

    private float resetTimer = 5f;
 
    
    // Start is called before the first frame update
    void Start()
    {
        // infoText.text="WElcome aLicE!!\n ThIS iS The lAsT stAGe to GO bACk HomE."
        // yield return new WaitForSeconds (3f);
        infoText.text = "WElcome aLicE!!\nThIS iS The LAsT stAGe to GO bACk HomE.\nbEFore tHAt, i nEED tO fIND a pOCket WAtCh.\nCaN yOu HElp mE??";
        StartCoroutine (ShuffleRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.picked) {
            if(player.won) {
                infoText.text = "You WIN, Alice";
            }
            else {
                infoText.text = "PoOR aLIce :( TRy AgaIN";

                resetTimer -= Time.deltaTime;
                if(resetTimer <=0f) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

            
        }
    }

    private IEnumerator ShuffleRoutine () {
        
        yield return new WaitForSeconds (8f);

        foreach (Cup cup in cups) {
            cup.MoveUp();
        }

        yield return new WaitForSeconds (1f);

        Cup targetCup = cups[Random.Range(0, cups.Length)];
        targetCup.pocketWatch = pocketWatch;
        pocketWatch.transform.position = new Vector3 (
            targetCup.transform.position.x,
            pocketWatch.transform.position.y,
            targetCup.transform.position.z
        );

        yield return new WaitForSeconds (1f);

        foreach (Cup cup in cups) {
            cup.MoveDown();
        }

        yield return new WaitForSeconds (1f);

        for (int i=0; i<5; i++) {
            Cup cup1 = cups[Random.Range(0, cups.Length)];
            Cup cup2 = cup1;

            while(cup2 == cup1) {
                cup2 = cups[Random.Range(0, cups.Length)];
            }
            //shuffle
            Vector3 cup1Position = cup1.targetPosition;
            cup1.targetPosition = cup2.targetPosition;
            cup2.targetPosition = cup1Position;

            yield return new WaitForSeconds (1f);
        }

        player.canPick = true;
    }
 }
