using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapG2 : MonoBehaviour
{

    public GameObject groundTop, groundMid, bridge, spikes, player;

    public int minPlatformSize = 1;
    public int maxPlatformSize = 10;
    public int maxHazardSize = 3;
    public int maxheight = 3;
    public int maxDrop = -3;

    public int platforms = 1000;
    [Range(0.0f, 1f)]
    public float hazardChance = .5f;
    [Range(0.0f, 1f)]
    public float bridgeChance = .1f;
    [Range(0.0f, 1f)]
    public float spikeChance = .5f;
    [Range(0.0f, 1f)]
    public float coinChance = .5f;

    private int blockNum = 1;
    private int blockHeight;
    private bool isHazard;

    void Start()
    {
        Time.timeScale = 1;

        Instantiate(groundTop, new Vector2(0, 0), Quaternion.identity);

        ScoreSystem.score = 0;

        for (int plat = 1; plat < platforms; plat++)
        {
            if (isHazard == true)
            {
                isHazard = false;
            }
            else {
                if (Random.value < hazardChance)
                {
                    isHazard = true;
                }
                else
                    isHazard = false;
            }

            if (isHazard == true)
            {
                int hazardSize = Mathf.RoundToInt(Random.Range(1, maxHazardSize));

                if (Random.value < spikeChance)
                {
                    //generate spikes
                    for (int tiles = 0; tiles < hazardSize; tiles++)
                    {
                        Instantiate(spikes, new Vector2(blockNum, blockHeight - 2), Quaternion.identity);

                        for (int gndMid = 1; gndMid < 5; gndMid++)
                        {
                            Instantiate(groundMid, new Vector2(blockNum, (blockHeight - gndMid) - 2), Quaternion.identity);
                        }

                        blockNum++;
                    }
                }
                else {
                    //hole

                    blockNum += hazardSize;
                }
            }
            else {

                if (Random.value < bridgeChance)
                {

                    //bridge generation
                    int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
                    blockHeight = blockHeight + Random.Range(maxDrop, maxheight);

                    //Coin generation
                    if (Random.value < coinChance)
                    {
                        int startTile = Mathf.RoundToInt(Random.Range(0, platformSize));
                        GetComponent<ObjectP2>().PlaceCoin(new Vector2(blockNum, blockHeight), Mathf.RoundToInt(Random.Range(1, platformSize - startTile)), startTile);
                    }

                    for (int tiles = 0; tiles < platformSize; tiles++)
                    {
                        if (tiles == 0 || tiles == platformSize - 1)
                        {
                            Instantiate(groundTop, new Vector2(blockNum, blockHeight), Quaternion.identity);

                            for (int gndMid = 1; gndMid < 5; gndMid++)
                            {
                                Instantiate(groundMid, new Vector2(blockNum, blockHeight - gndMid), Quaternion.identity);
                            }

                            blockNum++;
                        }
                        else {
                            Instantiate(bridge, new Vector2(blockNum, blockHeight), Quaternion.identity);
                            blockNum++;
                        }
                    }
                }
                else {

                    bool isEnemyPlatform = false;

                    //Platform generation
                    int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
                    blockHeight = blockHeight + Random.Range(maxDrop, maxheight);

                    //Coin generation
                    if (Random.value < coinChance)
                    {
                        int startTile = Mathf.RoundToInt(Random.Range(0, platformSize));
                        GetComponent<ObjectP2>().PlaceCoin(new Vector2(blockNum, blockHeight), Mathf.RoundToInt(Random.Range(1, platformSize - startTile)), startTile);
                    }

                    //enemy generation
                    if (platformSize >= 3)
                    {
                        if (Random.value < 0.3f)
                        {
                            GetComponent<EnemyPlacement2>().PlaceEnemy(new Vector2(blockNum + 1, blockHeight));
                            isEnemyPlatform = true;
                        }
                    }

                    //tile generation
                    for (int tiles = 0; tiles < platformSize; tiles++)
                    {
                        Instantiate(groundTop, new Vector2(blockNum, blockHeight), Quaternion.identity);

                        for (int gndMid = 1; gndMid < 5; gndMid++)
                        {
                            Instantiate(groundMid, new Vector2(blockNum, blockHeight - gndMid), Quaternion.identity);
                        }

                        //object placement
                        if (tiles > 0 && tiles < platformSize - 1)
                        {
                            if (Random.value < 0.2f)
                            {
                                GetComponent<ObjectP2>().PlaceObject(new Vector2(blockNum, blockHeight), isEnemyPlatform);
                            }
                        }

                        blockNum++;
                    }

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
