using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreatSpawner : MonoBehaviour
{
    public float willPowerLevel;
    public float startingWillPower = 100f;
    public Willpower willpower;
    //public int difficultyLevel;
    public IntValue difficultyLevel;
    public float nextActionTime = 60f;
    public float period = 60f;
    public int escape;
    private AudioSource audioS;
    public float musicDelay = 10f;
    public int jesusLimit = 3;
    private bool jesusCoolingDown;
    public SpriteRenderer face;
    public Sprite treatFace;
    public Sprite nonTreatFace;
    public Animator faceAnim;


    public float[] treatDamageValues;
    public float[] nonTreatValues;
    public GameObject[] Treats;
    public GameObject[] NonTreats;
    Dictionary<int, float> treatDamage = new Dictionary<int, float>();
    Dictionary<int, float> nonTreatRefill = new Dictionary<int, float>();

    private int numberOfTreats;

    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel.RunTimeValue = 0;
        willPowerLevel = startingWillPower;
        willpower.SetSize(1f);

        audioS = GetComponent<AudioSource>();
        audioS.PlayDelayed(musicDelay);

        treatDamage.Add(1, treatDamageValues[0]);
        treatDamage.Add(2, treatDamageValues[1]);
        treatDamage.Add(3, treatDamageValues[2]);
        treatDamage.Add(4, treatDamageValues[3]);
        treatDamage.Add(5, treatDamageValues[4]);
        treatDamage.Add(6, treatDamageValues[5]);

        nonTreatRefill.Add(1, nonTreatValues[0]);
        nonTreatRefill.Add(2, nonTreatValues[1]);
        nonTreatRefill.Add(3, nonTreatValues[2]);
        nonTreatRefill.Add(4, nonTreatValues[3]);
        nonTreatRefill.Add(5, nonTreatValues[4]);
        nonTreatRefill.Add(6, nonTreatValues[5]);

        jesusCoolingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            escape++;
            if (escape > 30)
            {
                SceneManager.LoadScene("Lose");
            }
        }
        else
        {
            escape = 0;
        }

        

        if (willPowerLevel >= 100f)
            willPowerLevel = 100f;

        willpower.SetSize(willPowerLevel / 100);

        if(Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += period;
            Debug.Log("time since load: " + Time.timeSinceLevelLoad);

            IncreaseDifficulty();
        }

        if(willPowerLevel < 10 && !jesusCoolingDown && jesusLimit > 0)
        {
            StartCoroutine(SpawnJesus());
        }

        if (willPowerLevel < 1)
            SceneManager.LoadScene("Lose");
    }

    public void DecreaseWillPower(int treatID)
    {
        willPowerLevel -= treatDamage[treatID];
        face.sprite = treatFace;
        faceAnim.enabled = false;
    }

    public void IncreaseWillPower(int treatID)
    {
        willPowerLevel += nonTreatRefill[treatID];
        face.sprite = nonTreatFace;
        faceAnim.enabled = false;
    }

    public int CheckTreatNumber()
    {
        return numberOfTreats = GameObject.FindGameObjectsWithTag("Treat").Length;
    }

    private IEnumerator SpawnMoreTreats(GameObject[] treatsToSpawn)
    {

        for(int i = 0; i < treatsToSpawn.Length; i++)
        {
            Instantiate(treatsToSpawn[i], transform.position, Quaternion.identity);
            //Instantiate(treatsToSpawn[i], transform.position, Quaternion.identity);
            Debug.Log(treatsToSpawn[i].name + " has been instantiated");
            yield return new WaitForSeconds(5f);
        }       
    }

    private IEnumerator SpawnNonTreats(GameObject[] nonTreatsToSpawn)
    {
        for (int i = 0; i < nonTreatsToSpawn.Length; i++)
        {
            yield return new WaitForSeconds(6f);
            Instantiate(nonTreatsToSpawn[i], transform.position, Quaternion.identity);
            Debug.Log(nonTreatsToSpawn[i].name + " has been instantiated");
            yield return new WaitForSeconds(12f);
        }
    }

    private IEnumerator SpawnJesus()
    {
        jesusCoolingDown = true;
        Instantiate(NonTreats[5], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(30f);
        jesusCoolingDown = false;
        jesusLimit--;
    }

    private void IncreaseDifficulty()
    {
        //Debug.Log("Reached Increase Difficulty");
        
        difficultyLevel.RunTimeValue++;
        //Debug.Log("Difficulty runtime value: " + difficultyLevel.RunTimeValue);

        switch(difficultyLevel.RunTimeValue)
        {
            case 1:
                Debug.Log("Increase difficulty case 1");
                GameObject[] TreatsToPass = { Treats[1], Treats[2] };
                StartCoroutine(SpawnMoreTreats(TreatsToPass));
                GameObject[] NonTreatsToPass = { NonTreats[1], NonTreats[2] };
                StartCoroutine(SpawnNonTreats(NonTreatsToPass));
                break;
            case 2:
                Debug.Log("Increase difficulty case 2");
                GameObject[] TreatsToPass2 = { Treats[2], Treats[3]};
                StartCoroutine(SpawnMoreTreats(TreatsToPass2));
                GameObject[] NonTreatsToPass2 = { NonTreats[2], NonTreats[3] };
                StartCoroutine(SpawnNonTreats(NonTreatsToPass2));
                break;
            case 3:
                Debug.Log("Increase difficulty case 3");
                GameObject[] TreatsToPass3 = { Treats[3], Treats[4]};
                StartCoroutine(SpawnMoreTreats(TreatsToPass3));
                GameObject[] NonTreatsToPass3 = { NonTreats[3], NonTreats[4] };
                StartCoroutine(SpawnNonTreats(NonTreatsToPass3));
                break;
            case 4:
                Debug.Log("Increase difficulty case 4");
                GameObject[] TreatsToPass4 = { Treats[5], NonTreats[5] };
                StartCoroutine(SpawnMoreTreats(TreatsToPass4));
                break;
            default:
                break;
        }
    }
}
